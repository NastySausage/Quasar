﻿using ProtoBuf;

namespace Quasar.Common
{
    [ProtoContract]
    public class QuasarProcess
    {
        [ProtoMember(1)]
        public string Name { get; set; }

        [ProtoMember(2)]
        public int Id { get; set; }

        [ProtoMember(3)]
        public string MainWindowTitle { get; set; }
    }
}
