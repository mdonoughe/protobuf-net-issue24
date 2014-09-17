using ProtoBuf;
using System.ComponentModel;

namespace BreakProtobufNet.Payload
{
    [ProtoContract]
    public class ChildType : BaseType
    {
        [DefaultValue("Pass")]
        [ProtoMember(1)]
        public string Status { get; set; }

        [ProtoMember(2, DataFormat = DataFormat.FixedSize)]
        public int Fail { get; set; }

        public ChildType()
        {
            Status = "Pass";
            Fail = 0x4C494146;
        }
    }
}
