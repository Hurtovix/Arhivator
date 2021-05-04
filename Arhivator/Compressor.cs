using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Arhivator
{
    class Compressor : Zip
    {
        Form1 form;
        public Compressor(Form1 form, string input, string output) : base(input, output)
        {
            this.form = form;
        }

        public override void Launch()
        {
            Task _reader = Task.Run(Read);
            Task[] tasks = new Task[0];
            for (int i = 0; i < _threads; i++)
            {
                tasks.Append(Task.Run(() => { Compress(i); })
            );
            }
            Task _writer = Task.Run(Write);
            Task.WaitAll(tasks);

            if (!_cancelled)
            {
                MessageBox.Show("\nCompressing has been succesfully finished");
                _success = true;
            }
        }

        private void Read()
        {
            try
            {

                using (FileStream _fileToBeCompressed = new FileStream(sourceFile, FileMode.Open))
                {
                    form.Progress.Maximum = (int)_fileToBeCompressed.Length;


                    int bytesRead;
                    byte[] lastBuffer;

                    while (_fileToBeCompressed.Position < _fileToBeCompressed.Length && !_cancelled)
                    {
                        if (_fileToBeCompressed.Length - _fileToBeCompressed.Position <= blockSize)
                        {
                            bytesRead = (int)(_fileToBeCompressed.Length - _fileToBeCompressed.Position);
                        }

                        else
                        {
                            bytesRead = blockSize;
                        }

                        lastBuffer = new byte[bytesRead];
                        _fileToBeCompressed.Read(lastBuffer, 0, bytesRead);
                        _queueReader.EnqueueForCompressing(lastBuffer);
                        form.Progress.Value = (int)_fileToBeCompressed.Position;
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

        private void Compress(object i)
        {
            try
            {
                while (true && !_cancelled)
                {
                    ByteBlock _block = _queueReader.Dequeue();

                    if (_block == null)
                        return;

                    using (MemoryStream _memoryStream = new MemoryStream())
                    {
                        using (GZipStream cs = new GZipStream(_memoryStream, CompressionMode.Compress))
                        {
                            cs.Write(_block.Buffer, 0, _block.Buffer.Length);
                        }

                        byte[] compressedData = _memoryStream.ToArray();
                        ByteBlock _out = new ByteBlock(_block.ID, compressedData);
                        _queueWriter.EnqueueForWriting(_out);
                    }
                    ManualResetEvent doneEvent = doneEvents[(int)i];
                    doneEvent.Set();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in thread number {i}. \n Error description: {ex.Message}");
                _cancelled = true;
            }
        }

        private void Write()
        {
            try
            {
                using (FileStream _fileCompressed = new FileStream(destinationFile + ".gz", FileMode.Append))
                {
                    while (true && !_cancelled)
                    {
                        ByteBlock _block = _queueWriter.Dequeue();
                        if (_block == null)
                            return;

                        BitConverter.GetBytes(_block.Buffer.Length).CopyTo(_block.Buffer, 4);
                        _fileCompressed.Write(_block.Buffer, 0, _block.Buffer.Length);
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
