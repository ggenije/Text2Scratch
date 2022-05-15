using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchList:IScratchSerializable,IScratchIdentifiablePrimitive
    {
        public ScratchList(string objectID, string scratchName,ScratchSprite sprite)
        {
            this.ObjectID = objectID;
            this.ScratchName = scratchName;
            values = new object[0];
            this.Sprite = sprite;
        }
        public ScratchList(string objectID, string scratchName, ScratchSprite sprite, object[] values)
        {
            this.ObjectID = objectID;
            this.ScratchName = scratchName;
            this.values = values;
            this.Sprite = sprite;
        }

        public string ObjectID { get; }
        public string ScratchName { get; }
        private object[] values;


        public void WriteJSON(JsonTextWriter writer)
        {
            writer.WritePropertyName(ObjectID);
            writer.WriteStartArray();
            writer.WriteValue(ScratchName);
            writer.WriteStartArray();
            foreach(object o in values)
                writer.WriteValue(o.ToString());
            writer.WriteEndArray();
            writer.WriteEndArray();
        }

        public ScratchPrimitiveType GetScratchPrimitiveType { get { return ScratchPrimitiveType.List; } }

        public ScratchSprite? Sprite { get; }
    }
}
