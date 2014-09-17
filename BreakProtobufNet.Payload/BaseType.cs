using ProtoBuf;

namespace BreakProtobufNet.Payload
{
    [ProtoContract]
    [ProtoInclude(1, typeof(ChildType))]
    public class BaseType
    {
    }
}
