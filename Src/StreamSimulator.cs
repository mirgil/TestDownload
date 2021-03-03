using System;
using System.IO;
using System.Threading;

namespace TestDownload.Src
{
    public class StreamSimulator : Stream
    {
        private long _size;
        private long _location = 0;
        private int _delayMilliseconds = -1;
        public StreamSimulator(long size, int delayMilliseconda = -1)
        {
            _size = size;
            _delayMilliseconds = delayMilliseconda;
        }


        public override bool CanRead
        {
            get { return _location < _size; }
        }

        public override bool CanSeek => true;

        public override bool CanWrite => false;

        public override long Length => _size;

        public override long Position
        {
            get => _location;
            set
            {
                _location = value;
            }
        }

        public override void Flush()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int nBytes = count;
            if (_location + count > _size)
            {
                nBytes = (int)(_size - _location);
            }

            for (int i = offset; i < offset + nBytes; i++)
            {
                buffer[i] = 35;
                _location++;
            }
            if (_delayMilliseconds > 0)
            {
                Thread.Sleep(_delayMilliseconds);
            }
            return nBytes;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch(origin)
            {
                case SeekOrigin.Begin:
                    _location = offset;
                    break;
                case SeekOrigin.Current:
                    _location += offset;
                    break;
                case SeekOrigin.End:
                    _location = _size + offset;
                    break;
            }
            if (_location < 0) _location = 0;
            if (_location > _size) _location = _size;
            return _location;
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }
}