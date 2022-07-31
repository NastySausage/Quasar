using ProtoBuf;
using System;
using System.IO;

namespace Quasar.Common
{
    public class PayloadWriter : MemoryStream
    {
        private readonly Stream _innerStream;
        private readonly BinaryWriter _writer;
        public bool LeaveInnerStreamOpen { get; }

        public PayloadWriter(Stream stream, bool leaveInnerStreamOpen)
        {
            _innerStream = stream;
            _writer=new BinaryWriter(stream);
            LeaveInnerStreamOpen = leaveInnerStreamOpen;
        }

        /// <summary>
        /// Writes a serialized message as payload to the stream.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <returns>The amount of written bytes to the stream.</returns>
        public int WriteMessage(IMessage message)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, message);
                byte[] payload = ms.ToArray();
                _writer.Write(BitConverter.GetBytes(payload.Length), 0, sizeof(int));
                _writer.Write(payload, 0, payload.Length);
                // Console.WriteLine(payload.Length);
                return sizeof(int) + payload.Length;
            }
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (LeaveInnerStreamOpen)
                {
                    _innerStream.Flush();
                }
                else
                {
                    _innerStream.Close();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
    }
}
