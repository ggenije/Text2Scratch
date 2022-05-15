

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchObjectManager
    {
        public IdentifierGenerator IdentifierGenerator { get; }

        public ScratchSprite Stage { get; }
        public List<ScratchSprite> sprites { get; }
        public List<ScratchMonitor> monitors { get; }

        private uint cloudVarCount;
        public ScratchObjectManager()
        {
            IdentifierGenerator = new IdentifierGenerator();
            Stage=new ScratchSprite(IdentifierGenerator);
            sprites=new List<ScratchSprite>();
            monitors = new List<ScratchMonitor>();
            cloudVarCount=0;
        }

        public ScratchSprite AddSprite(string name)
        {
            ScratchSprite scratchSprite=new ScratchSprite(IdentifierGenerator, name);
            sprites.Add(scratchSprite);
            return scratchSprite;
        }

        public ScratchBroadcast AddBroadcast(string name)
        {
            return Stage.AddBroadcast(name);
        }

        public ScratchVariable AddGlobalVariable(string name)
        {
            return Stage.AddVariable(name);
        }

        public ScratchVariable AddGlobalVariable(string name,object value)
        {
            return Stage.AddVariable(name,value);
        }
        public ScratchList AddGlobalList(string name)
        {
            return Stage.AddList(name);
        }
        public ScratchList AddGlobalList(string name, object[] values)
        {
            return Stage.AddList(name,values);
        }

        public ScratchVariable AddCloudVariable(string name)
        {
            if (cloudVarCount == 10)
                throw new ScratchException("You can't have more that 10 cloud variables");
            cloudVarCount++;
            return Stage.AddVariable(name,true);   
        }

        public ScratchVariable AddCloudVariable(string name,object value)
        {
            if (cloudVarCount == 10)
                throw new ScratchException("You can't have more that 10 cloud variables");
            cloudVarCount++;
            return Stage.AddVariable(name,value, true);
        }

        public void AddMonitor(ScratchVariable var,bool isBig,int x,int y,bool visible=true)
        {
            monitors.Add(new ScratchMonitor(var, isBig, x, y,visible));
        }

        public void AddMonitor(ScratchVariable var, int x, int y,float sliderMin=0f,float sliderMax=100f,bool isDiscrete=true, bool visible = true)
        {
            monitors.Add(new ScratchMonitor(var, x, y, sliderMin,sliderMax,isDiscrete,visible));
        }

        public void AddMonitor(ScratchList list, int x, int y, int width =0,int height=0, bool visible = true)
        {
            monitors.Add(new ScratchMonitor(list,x,y,width,height,visible));
        }


        public void WriteAllAssets(string filePath)
        {
            foreach(ScratchAsset a in Stage.sounds.Values)
                a.WriteToFile(filePath);
            foreach (ScratchAsset a in Stage.costumes.Values)
                a.WriteToFile(filePath);

            foreach(ScratchSprite s in sprites)
            {
                foreach (ScratchAsset a in s.sounds.Values)
                    a.WriteToFile(filePath);
                foreach (ScratchAsset a in s.costumes.Values)
                    a.WriteToFile(filePath);
            }
        }
    }
}
