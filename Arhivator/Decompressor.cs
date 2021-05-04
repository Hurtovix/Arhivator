using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arhivator
{
    class Decompressor : Zip
    {
        int counter = 0;
        Form1 form;
        public Decompressor(Form1 form, string input, string output) : base(input, output)
        {
            this.form = form;
        }

        public override void Launch()
        {
            Task _reader = Task.Run(Read);
            Task[] tasks = new Task[0];
            for (int i = 0; i < _threads; i++)
            {
                tasks.Append(Task.Run(() => { Decompress(i); })
            );
            }
            Task _writer = Task.Run(Write);
            Task.WaitAll(tasks);

            if (!_cancelled)
            {
                MessageBox.Show("\nDecompressing has been succesfully finished");
                _success = true;
            }
        }

        private void Read()
        {
            try
            {
                using (FileStream _compressedFile = new FileStream(sourceFile, FileMode.Open))
                {
                    form.Progress.Maximum = (int)_compressedFile.Length;
                    while (_compressedFile.Position < _compressedFile.Length)
                    {
                        byte[] lengthBuffer = new byte[8];
                        _compressedFile.Read(lengthBuffer, 0, lengthBuffer.Length);
                        int blockLength = BitConverter.ToInt32(lengthBuffer, 4);
                        byte[] compressedData = new byte[blockLength];
                        lengthBuffer.CopyTo(compressedData, 0);

                        _compressedFile.Read(compressedData, 8, blockLength - 8);
                        int _dataSize = BitConverter.ToInt32(compressedData, blockLength - 4);
                        byte[] lastBuffer = new byte[_dataSize];

                        ByteBlock _block = new ByteBlock(counter, lastBuffer, compressedData);
                        _queueReader.EnqueueForWriting(_block);
                        counter++;
                        form.Progress.Value = (int)_compressedFile.Position;

                    }
                    _queueReader.Stop();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _cancelled = true;
            }
        }

        private void Decompress(object i)
        {
            try
            {
                while (true && !_cancelled)
                {
                    ByteBlock _block = _queueReader.Dequeue();
                    if (_block == null)
                        return;

                    using (MemoryStream ms = new MemoryStream(_block.CompressedBuffer))
                    {
                        using (GZipStream _gz = new GZipStream(ms, CompressionMode.Decompress))
                        {
                            _gz.Read(_block.Buffer, 0, _block.Buffer.Length);
                            byte[] decompressedData = _block.Buffer.ToArray();
                            ByteBlock block = new ByteBlock(_block.ID, decompressedData);
                            _queueWriter.EnqueueForWriting(block);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error in thread number {0}. \n Error description: {1}", i, ex.Message);
                _cancelled = true;
            }
        }

        private void Write()
        {
            try
            {
                using (FileStream _decompressedFile = new FileStream(sourceFile.Remove(sourceFile.Length - 3), FileMode.Append))
                {
                    while (true && !_cancelled)
                    {
                        ByteBlock _block = _queueWriter.Dequeue();
                        if (_block == null)
                            return;

                        _decompressedFile.Write(_block.Buffer, 0, _block.Buffer.Length);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _cancelled = true;
            }
        }
    }
}
