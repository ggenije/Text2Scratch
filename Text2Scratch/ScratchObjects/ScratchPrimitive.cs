using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    public enum ScratchPrimitiveType
    {
        None = 0,
        Number = 4,
        PositiveNumber = 5,
        PositiveInteger = 6,
        Integer = 7,
        Angle = 8,
        Color = 9,
        String = 10,
        Broadcast = 11,
        Variable = 12,
        List = 13
    }

    internal class ScratchPrimitive : IScratchSerializable
    {  
        public ScratchPrimitiveType ScratchPrimitiveType;
        public object Value;

        public ScratchPrimitive(ScratchPrimitiveType type,object value) {
            this.ScratchPrimitiveType = type;
            this.Value = value;
        }

        public virtual void WriteJSON(JsonTextWriter writer) {

            writer.WriteStartArray();
            writer.WriteValue((int)ScratchPrimitiveType);
            writer.WriteValue(Value.ToString());
            writer.WriteEndArray();
        }

   

    }



}
