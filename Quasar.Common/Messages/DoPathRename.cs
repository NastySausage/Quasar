﻿using ProtoBuf;

namespace Quasar.Common
{
    [ProtoContract]
    public class DoPathRename : IMessage
    {
        [ProtoMember(1)]
        public string Path { get; set; }

        [ProtoMember(2)]
        public string NewPath { get; set; }

        [ProtoMember(3)]
        public FileType PathType { get; set; }
    }
}
