using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchBlock : IScratchSerializable,IScratchIdentifiable
    {
        public ScratchBlockOpCode OpCode { get; }
        public ScratchBlock? NextBlock { get; set; }
        public ScratchBlock? ParentBlock { get; set; }
        private bool topLevel;
        public int xPos { get; }
        public int yPos { get; }

        public string ObjectID { get; }

        private bool shadow;

        private List<ScratchInput> inputs;
        private List<ScratchField> fields;

        public Mutation? mutation;
        ScratchComment? comment;

        public ScratchBlock(string objectID, ScratchBlockOpCode blockType,int x, int y)
        {
            OpCode = blockType;
            NextBlock = null;
            ParentBlock = null;
            topLevel = true;
            this.ObjectID = objectID;
            this.xPos = x;
            this.yPos = y;
            shadow = false;

            inputs = new List<ScratchInput>();
            fields = new List<ScratchField>();
            mutation = null;
            comment = null;
        }
        public ScratchBlock(string objectID, ScratchBlockOpCode blockType,bool shadow=false)
        {
            OpCode = blockType;
            NextBlock = null;
            ParentBlock = null;
            topLevel = false;
            this.ObjectID = objectID;
            this.xPos = 0;
            this.yPos = 0;
            this.shadow = shadow;

            inputs = new List<ScratchInput>();
            fields = new List<ScratchField>();
            mutation = null;
            comment = null;
        }

        public ScratchBlock AddInput(ScratchInput input)
        {
            inputs.Add(input);
            return this;
        }
        public ScratchBlock AddField(ScratchField field)
        {
            fields.Add(field);
            return this;
        }
        public ScratchBlock SetComment(ScratchComment comment)
        {     
            this.comment = comment;
            return this;
        }


        public void WriteJSON(JsonTextWriter writer)
        {
            writer.WritePropertyName(ObjectID);
            writer.WriteStartObject();

            writer.WritePropertyName("opcode");
            writer.WriteValue(OpCode.ToString());
            writer.WritePropertyName("next");
            writer.WriteValue(NextBlock == null ? (object)null : NextBlock.ObjectID);
            writer.WritePropertyName("parent");
            writer.WriteValue(ParentBlock == null ? (object)null : ParentBlock.ObjectID);

            writer.WritePropertyName("inputs");
            writer.WriteStartObject();
            foreach(var i in inputs)
                i.WriteJSON(writer);
            writer.WriteEndObject();

            writer.WritePropertyName("fields");
            writer.WriteStartObject();
            foreach (var f in fields)
                f.WriteJSON(writer);
            writer.WriteEndObject();

            writer.WritePropertyName("shadow");
            writer.WriteValue(shadow);

            writer.WritePropertyName("topLevel");
            writer.WriteValue(topLevel);

            if(topLevel)
            {
                writer.WritePropertyName("x");
                writer.WriteValue(xPos);
                writer.WritePropertyName("y");
                writer.WriteValue(yPos);
            }

            if(mutation!=null)
            {
                mutation.WriteJSON(writer);
            }

            if(comment!=null)
            {
                writer.WritePropertyName("comment");
                writer.WriteValue(comment.ObjectID);
            }
            writer.WriteEndObject();
        }

        public ScratchBlock SetMutation(Mutation mutation)
        {
            this.mutation = mutation;
            return this;
        }
    }

    internal abstract class Mutation:IScratchSerializable
    {
        public void WriteJSON(JsonTextWriter writer)
        {
            writer.WritePropertyName("mutation");
            writer.WriteStartObject();

            writer.WritePropertyName("tagName");
            writer.WriteValue("mutation");

            writer.WritePropertyName("children");
            writer.WriteStartArray();
            writer.WriteEndArray();

            WriteMutation(writer);

            writer.WriteEndObject();
        }

        public abstract void WriteMutation(JsonTextWriter writer);
    }

    internal class CustomBlockMutation : Mutation
    {
        bool isCalling;
        ScratchCustomBlock customBlock;

        public CustomBlockMutation(ScratchCustomBlock customBlock, bool isCalling)
        {
            this.customBlock = customBlock;
            this.isCalling = isCalling;
        }

        public override void WriteMutation(JsonTextWriter writer)
        {

            writer.WritePropertyName("proccode");
            writer.WriteValue(customBlock.Proccode());

            writer.WritePropertyName("argumentids");
            writer.WriteValue(customBlock.ArgumentIDs());

            if(!isCalling)
            {
                writer.WritePropertyName("argumentnames");
                writer.WriteValue(customBlock.ArgumentNames());
                writer.WritePropertyName("argumentdefaults");
                writer.WriteValue(customBlock.ArgumentDefaults());
            }

            writer.WritePropertyName("warp");
            writer.WriteValue(customBlock.Warp.ToString().ToLower());
        }
    }

    internal class StopMutation : Mutation
    {
        public bool HasNext { get; }
        public StopMutation(bool hasNext)
        {
            this.HasNext = hasNext;
        }
        public override void WriteMutation(JsonTextWriter writer)
        {
            writer.WritePropertyName("hasnext");
            writer.WriteValue(HasNext.ToString().ToLower());
        }
    }
}
