using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{

    internal class ScratchMonitor : IScratchSerializable, IScratchIdentifiable
    {
        private enum MonitorType
        {
            Default,Large,Slider,List
        }

        public ScratchMonitor(ScratchVariable var,bool isBig,int x, int y, bool visible=true)
        {
            this.ObjectID = var.ObjectID;
            this.monitorType = isBig ? MonitorType.Large : MonitorType.Default;
            this.isList = false;
            this.idable = var;
            this.x = x;
            this.y = y;
            this.width = 0;
            this.height = 0;
            this.visible = visible;
            this.sliderMax = 0;
            this.sliderMin = 0;
            this.isDiscrete = true;
        }


        public ScratchMonitor( ScratchVariable var, int x, int y,float sliderMin=0f,float sliderMax=100f, bool isDiscrete=true, bool visible = true)
        {
            this.ObjectID = var.ObjectID;
            this.monitorType = MonitorType.Slider;
            this.isList = false;
            this.idable = var;
            this.x = x;
            this.y = y;
            this.width = 0;
            this.height = 0;
            this.visible = visible;

            this.sliderMin=sliderMin;
            this.sliderMax = sliderMax;
            this.isDiscrete = isDiscrete;
        }

        public ScratchMonitor(ScratchList list, int x, int y,int width=0,int height=0, bool visible = true)
        {
            this.ObjectID = list.ObjectID;
            this.monitorType = MonitorType.List;
            this.isList = true;
            this.idable = list;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.visible = visible;

            this.sliderMin = 0;
            this.sliderMax = 0;
            this.isDiscrete = true;
        }


        public string ObjectID { get; }
        MonitorType monitorType;
        bool isList;
        IScratchIdentifiablePrimitive idable;
        int width;
        int height;
        int x;
        int y;
        bool visible;
        float sliderMin;
        float sliderMax;
        bool isDiscrete;

        public void WriteJSON(JsonTextWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("id");
            writer.WriteValue(ObjectID);

            writer.WritePropertyName("mode");
            writer.WriteValue(monitorType.ToString().ToLower());

            writer.WritePropertyName("opcode");
            writer.WriteValue((isList? ScratchBlockOpCode.data_listcontents:ScratchBlockOpCode.data_variable).ToString());

            writer.WritePropertyName("params");
            writer.WriteStartObject();
            writer.WritePropertyName((isList ? InputName.LIST : InputName.VARIABLE).ToString());
            writer.WriteValue(idable.ScratchName);
            writer.WriteEndObject();

            writer.WritePropertyName("spriteName");
            writer.WriteValue(idable.Sprite==null?null:idable.Sprite.ScratchName);

            writer.WritePropertyName("value");
            if (isList)
            {
                writer.WriteStartArray();
                writer.WriteEndArray();
            }
            else
            {
                writer.WriteValue(string.Empty);
            }
                

            writer.WritePropertyName("width");
            writer.WriteValue(width);

            writer.WritePropertyName("height");
            writer.WriteValue(height);

            writer.WritePropertyName("x");
            writer.WriteValue(x);

            writer.WritePropertyName("y");
            writer.WriteValue(y);

            writer.WritePropertyName("visible");
            writer.WriteValue(visible.ToString().ToLower());

            if(!isList)
            {
                writer.WritePropertyName("sliderMin");
                writer.WriteValue(sliderMin);

                writer.WritePropertyName("sliderMax");
                writer.WriteValue(sliderMax);

                writer.WritePropertyName("isDiscrete");
                writer.WriteValue(isDiscrete.ToString().ToLower());
            }
            
            writer.WriteEndObject();
        }
    }
}
