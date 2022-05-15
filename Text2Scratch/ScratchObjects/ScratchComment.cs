using Newtonsoft.Json;
namespace Text2Scratch.ScratchObjects
{
    internal class ScratchComment:IScratchSerializable, IScratchIdentifiable
    {
        public ScratchComment(string objectID,ScratchBlock parentBlock,string text,bool minimized=false)
        {
            this.ObjectID = objectID;
            this.parentBlock = parentBlock;
            parentBlock.SetComment(this);
            this.text = text;
            x = 0;
            y = 0;
            this.minimized = minimized;
            GetPositionFromBlock();
            GetSizeFromText();
        }
        public ScratchComment(string objectID, float x,float y, string text, bool minimized = false)
        {
            this.ObjectID = objectID;
            this.parentBlock = null;
            this.text = text;
            this.x = x;
            this.y = y;
            this.minimized = minimized;
            GetSizeFromText();
        }

        // To do
        private void GetPositionFromBlock()
        {
            if(parentBlock != null)
            {
                x = parentBlock.xPos + 200;
                y = parentBlock.yPos;
            }
        }
        // To do
        private void GetSizeFromText()
        {
            string[] lines = text.Split(new string[] { Environment.NewLine },StringSplitOptions.None);
            int max = 0;
            foreach(var line in lines)
            {
                if(line.Length > max)
                    max = line.Length;
            }
            width =  max*20;
            height = lines.Length * 200;
        }


        public string ObjectID { get; }
        private ScratchBlock? parentBlock;
        private float x;
        private float y;
        private float width;
        private float height;
        private bool minimized;
        private string text;

        public void WriteJSON(JsonTextWriter writer)
        {
            writer.WritePropertyName(ObjectID);
            writer.WriteStartObject();
            writer.WritePropertyName("blockId");
            writer.WriteValue(parentBlock==null?(object)null:parentBlock.ObjectID);
            writer.WritePropertyName("x");
            writer.WriteValue(x);
            writer.WritePropertyName("y");
            writer.WriteValue(y);
            writer.WritePropertyName("width");
            writer.WriteValue(width);
            writer.WritePropertyName("height");
            writer.WriteValue(height);
            writer.WritePropertyName("minimized");
            writer.WriteValue(minimized);
            writer.WritePropertyName("text");
            writer.WriteValue(text);
            writer.WriteEndObject();
        }

    }
}
