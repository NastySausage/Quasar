using ProtoBuf;
using System.Collections.Generic;

namespace Quasar.Common
{
    [ProtoContract]
    public class GetStartupItemsResponse : IMessage
    {
        [ProtoMember(1)]
        public List<StartupItem> StartupItems { get; set; }
    }
}
