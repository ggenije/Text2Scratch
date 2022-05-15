using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchBroadcast:IScratchSerializable,IScratchIdentifiablePrimitive
    {
        public ScratchBroadcast(string objectID, string scratchName)
        {
            this.ObjectID = objectID;
            this.ScratchName = scratchName;
        }

        public string ObjectID { get; }
        public string ScratchName { get; }
  
        public void WriteJSON(JsonTextWriter writer)
        {
            writer.WritePropertyName(ObjectID);
            writer.WriteValue(ScratchName);
        }

        public ScratchPrimitiveType GetScratchPrimitiveType { get { return ScratchPrimitiveType.Broadcast; } }

        public ScratchSprite? Sprite { get { return null; } }
    }
}
