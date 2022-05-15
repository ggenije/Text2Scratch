using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    internal interface IScratchSerializable
    {
        public void WriteJSON(JsonTextWriter writer);
    }
}
