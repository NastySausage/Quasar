using ProtoBuf;

namespace Quasar.Common
{
    [ProtoContract]
    public class GetProcessesResponse : IMessage
    {
        [ProtoMember(1)]
        public QuasarProcess[] Processes { get; set; }
    }
}
