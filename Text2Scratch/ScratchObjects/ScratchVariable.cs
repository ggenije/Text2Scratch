using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchVariable : IScratchSerializable, IScratchIdentifiablePrimitive
    {



        public ScratchVariable(string objectID, string scratchName, ScratchSprite sprite,bool isCloud=false)
        {
            this.ObjectID = objectID;
            this.ScratchName = (isCloud? "☁ ":"")+scratchName;
            value = "";
            this.Sprite = sprite;
            this.isCloud = isCloud;
        }
        public ScratchVariable(string objectID, string scratchName, ScratchSprite sprite, object value, bool isCloud = false)
        {
            this.ObjectID = objectID;
            this.ScratchName = (isCloud ? "☁ " : "") + scratchName;
            this.value = value;
            this.Sprite = sprite;
            this.isCloud = isCloud;
        }


        public string ObjectID { get; }
        public string ScratchName { get; }

        bool isCloud;

        public ScratchPrimitiveType GetScratchPrimitiveType { get { return ScratchPrimitiveType.Variable; } }

        public ScratchSprite? Sprite { get; }

        private object value;
        

        public void WriteJSON(JsonTextWriter writer)
        {
            writer.WritePropertyName(ObjectID);
            writer.WriteStartArray();
            writer.WriteValue(ScratchName);       
            writer.WriteValue(value);
            if (isCloud)
                writer.WriteValue(true);
            writer.WriteEndArray();   
        }

        
    }
}
