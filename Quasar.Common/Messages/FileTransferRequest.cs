﻿using ProtoBuf;

namespace Quasar.Common
{
    [ProtoContract]
    public class FileTransferRequest : IMessage
    {
        [ProtoMember(1)]
        public int Id { get; set; }

        [ProtoMember(2)]
        public string RemotePath { get; set; }
    }
}
