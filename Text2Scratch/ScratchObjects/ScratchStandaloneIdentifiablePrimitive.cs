using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal class ScratchStandaloneIdentifiablePrimitive:ScratchPrimitive
    {
        public IScratchIdentifiablePrimitive ScratchIdentifiablePrimitive { get; set; }
        private bool TopLevel;
        private int x;
        private int y;

        private static ScratchPrimitiveType GetPrimitiveType(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive)
        {
            if (scratchIdentifiablePrimitive.GetType() == typeof(ScratchVariable))
                return ScratchPrimitiveType.Variable;
            else if (scratchIdentifiablePrimitive.GetType() == typeof(ScratchList))
                return ScratchPrimitiveType.List;
            else if (scratchIdentifiablePrimitive.GetType() == typeof(ScratchBroadcast))
                return ScratchPrimitiveType.Broadcast;
            else
                throw new ScratchException("Object of type: " + scratchIdentifiablePrimitive.GetType().ToString() + " is not supported as primitive");
            
            //return ScratchPrimitiveType.None;
        }

        public ScratchStandaloneIdentifiablePrimitive(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive):base(GetPrimitiveType(scratchIdentifiablePrimitive),scratchIdentifiablePrimitive.ObjectID)
        {
            ScratchIdentifiablePrimitive = scratchIdentifiablePrimitive;
            TopLevel = false;
        }

        public ScratchStandaloneIdentifiablePrimitive(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive,int x,int y) : base(GetPrimitiveType(scratchIdentifiablePrimitive), scratchIdentifiablePrimitive.ObjectID)
        {
            this.ScratchPrimitiveType = ScratchPrimitiveType.Variable;
            ScratchIdentifiablePrimitive = scratchIdentifiablePrimitive;
            TopLevel = false;
            this.x = x;
            this.y = y;
            TopLevel = scratchIdentifiablePrimitive.GetType() != typeof(ScratchBroadcast);      
        }

        public override void WriteJSON(JsonTextWriter writer)
        {
            writer.WriteStartArray();
            writer.WriteValue((int)ScratchPrimitiveType);
            writer.WriteValue(ScratchIdentifiablePrimitive.ScratchName);
            writer.WriteValue(ScratchIdentifiablePrimitive.ObjectID);
            if(TopLevel)
            {
                writer.WriteValue(x);
                writer.WriteValue(y);
            }
            writer.WriteEndArray();
        }
    }
}
