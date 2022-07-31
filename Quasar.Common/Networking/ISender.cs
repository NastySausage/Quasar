namespace Quasar.Common
{
    public interface ISender
    {
        void Send<T>(T message) where T : IMessage;
        void Disconnect(string reason);
    }
}
