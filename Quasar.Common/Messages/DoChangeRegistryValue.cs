﻿using ProtoBuf;

namespace Quasar.Common
{
    [ProtoContract]
    public class DoChangeRegistryValue : IMessage
    {
        [ProtoMember(1)]
        public string KeyPath { get; set; }

        [ProtoMember(2)]
        public RegValueData Value { get; set; }
    }
}
