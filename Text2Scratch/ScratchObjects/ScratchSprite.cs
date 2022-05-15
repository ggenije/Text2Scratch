using Newtonsoft.Json;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchSprite : IScratchSerializable,IScratchNamable
    {
        private IdentifierGenerator identifierGenerator;
        public ScratchSprite(IdentifierGenerator identifierGenerator)
        {
            this.isStage = true;
            this.ScratchName = "Stage";
            this.identifierGenerator = identifierGenerator;
            variables = new Dictionary<string, ScratchVariable>();
            lists = new Dictionary<string, ScratchList>();
            broadcasts = new Dictionary<string, ScratchBroadcast>();
            costumes = new Dictionary<string, ScratchCostume>();
            sounds = new Dictionary<string, ScratchSound>();
            comments = new Dictionary<string, ScratchComment>();
            blocks = new List<ScratchBlock>();
        }

        public ScratchSprite(IdentifierGenerator identifierGenerator,string name)
        {
            this.isStage = false;
            this.ScratchName = name;
            this.identifierGenerator = identifierGenerator;
            variables = new Dictionary<string, ScratchVariable>();
            lists = new Dictionary<string, ScratchList>();
            broadcasts = new Dictionary<string, ScratchBroadcast>();
            costumes = new Dictionary<string, ScratchCostume>();
            sounds = new Dictionary<string, ScratchSound>();
            comments = new Dictionary<string, ScratchComment>();
            blocks = new List<ScratchBlock>();
        }

        private bool isStage;
        public string ScratchName { get; }
        public Dictionary<string,ScratchVariable> variables;
        public Dictionary<string, ScratchList> lists;
        public Dictionary<string, ScratchBroadcast> broadcasts;
        public Dictionary<string, ScratchCostume> costumes;
        public Dictionary<string, ScratchSound> sounds;
        public Dictionary<string, ScratchComment> comments;
        public List<ScratchBlock> blocks;

        public ScratchVariable AddVariable(string scratchName, object value, bool isCloud = false)
        {
            string newId = identifierGenerator.NextID();
            ScratchVariable scratchVariable = new ScratchVariable(newId, scratchName,isStage?null:this, value,isCloud);
            variables.Add(newId,scratchVariable);
            return scratchVariable;
        }
        public ScratchVariable AddVariable(string scratchName, bool isCloud = false)
        {
            string newId = identifierGenerator.NextID();
            ScratchVariable scratchVariable = new ScratchVariable(newId, scratchName, isStage ? null : this, isCloud);
            variables.Add(newId, scratchVariable);
            return scratchVariable;
        }


        public ScratchList AddList(string scratchName, object[] values)
        {
            string newId = identifierGenerator.NextID();
            ScratchList scratchList = new ScratchList(newId, scratchName, isStage ? null : this, values);
            lists.Add(newId, scratchList);
            return scratchList;
        }
        public ScratchList AddList(string scratchName)
        {
            string newId = identifierGenerator.NextID();
            ScratchList scratchList = new ScratchList(newId, scratchName, isStage ? null : this);
            lists.Add(newId, scratchList);
            return scratchList;
        }
        public ScratchBroadcast AddBroadcast(string scratchName)
        {
            if (!isStage)
                throw new ScratchException("Sprites other than Stage cannot have local broadcasts.");
            string newId = identifierGenerator.NextID();
            ScratchBroadcast scratchBroadcast = new ScratchBroadcast(newId, scratchName);   
            broadcasts.Add(newId,scratchBroadcast );
            return scratchBroadcast;
        }
        public ScratchComment AddComment(ScratchBlock parentBlock, string text, bool minimized = false)
        {
            string newId = identifierGenerator.NextID();
            ScratchComment scratchComment= new ScratchComment(newId, parentBlock, text, minimized);
            comments.Add(newId, scratchComment);
            return scratchComment;
        }

        public ScratchComment AddComment(float x,float y,string text, bool minimized = false)
        {
            string newId = identifierGenerator.NextID();
            ScratchComment scratchComment = new ScratchComment(newId, x,y,text, minimized);
            comments.Add(newId, scratchComment);
            return scratchComment;
        }

        public void AddCostume(ScratchCostume newCostume)
        {
            costumes.Add(newCostume.AssetID,newCostume);
        }
        public void AddSound(ScratchSound newSound)
        {
            sounds.Add(newSound.AssetID, newSound);
        }

        public void AddScratchScript(List<ScratchBlock> blocks)
        {
            this.blocks.AddRange(blocks);
        }


        public void PrepareForWriting()
        {
            if(costumes.Count==0)
            {
                ScratchCostume newCostume = new ScratchCostume(Properties.Resources.defaultCostume, "svg", "default", 240, 180);
                costumes.Add(newCostume.AssetID,newCostume);
            }
        }

        public void WriteJSON(JsonTextWriter writer)
        {

            writer.WriteStartObject();
       

            writer.WritePropertyName("isStage");
            writer.WriteValue(isStage);

            writer.WritePropertyName("name");
            writer.WriteValue(ScratchName);

            writer.WritePropertyName("variables");
            writer.WriteStartObject();
            foreach(var v in variables)
                v.Value.WriteJSON(writer);
            writer.WriteEndObject();
            
            writer.WritePropertyName("lists");
            writer.WriteStartObject();
            foreach (var l in lists)
                l.Value.WriteJSON(writer);
            writer.WriteEndObject();

            writer.WritePropertyName("broadcasts");
            writer.WriteStartObject();
            foreach (var b in broadcasts)
                b.Value.WriteJSON(writer);
            writer.WriteEndObject();

            writer.WritePropertyName("blocks");
            writer.WriteStartObject();
            foreach (var b in blocks)
                b.WriteJSON(writer);
            writer.WriteEndObject();

            writer.WritePropertyName("comments");
            writer.WriteStartObject();
            foreach (var c in comments)
                c.Value.WriteJSON(writer);
            writer.WriteEndObject();

            writer.WritePropertyName("currentCostume");
            writer.WriteValue(0);
       
            writer.WritePropertyName("costumes");
            writer.WriteStartArray();
            foreach (var c in costumes)
                c.Value.WriteJSON(writer);
            writer.WriteEndArray();

            writer.WritePropertyName("sounds");
            writer.WriteStartArray();
            foreach (var s in sounds)
                s.Value.WriteJSON(writer);
            writer.WriteEndArray();

            writer.WritePropertyName("volume");
            writer.WriteValue(100);

            writer.WritePropertyName("layerOrder");
            writer.WriteValue(identifierGenerator.NextLayerOrder());

            if(isStage)
            {
                writer.WritePropertyName("tempo");
                writer.WriteValue(60);

                writer.WritePropertyName("videoTransparency");
                writer.WriteValue(50);

                writer.WritePropertyName("videoState");
                writer.WriteValue("on");

                writer.WritePropertyName("textToSpeechLanguage");
                writer.WriteNull();
            }
            else
            {
                writer.WritePropertyName("visible");
                writer.WriteValue(true);

                writer.WritePropertyName("x");
                writer.WriteValue(0);

                writer.WritePropertyName("y");
                writer.WriteValue(0);

                writer.WritePropertyName("size");
                writer.WriteValue(100);

                writer.WritePropertyName("direction");
                writer.WriteValue(90);

                writer.WritePropertyName("draggable");
                writer.WriteValue(false);

                writer.WritePropertyName("rotationStyle");
                writer.WriteValue("all around");
            }
           

            writer.WriteEndObject();
            

        }
    }
}
