using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{

    /*
         public enum InputName
    {
        VALUE,

        VARIABLE, LIST, BROADCAST, OBJECT,
        TO, STYLE, BACKDROP, EFFECT, FRONT_BACK, NUMBER_NAME, FORWARD_BACKWARD, KEY_OPTION, WHENGREATERTHANMENU,
        STOP_OPTION, CLONE_OPTION, TOUCHINGOBJECTMENU, DRAG_MODE, PROPERTY, CURRENTMENU, OPERATOR, COLOR_PARAM,

    }
     
     */

   


    internal class ScratchField : IScratchSerializable
    {
      
        
        static readonly Dictionary<FieldOption, string> FieldOptionScratchNames;

        static ScratchField()
        {
            FieldOptionScratchNames = new Dictionary<FieldOption, string>
            {
                { FieldOption.Empty,string.Empty },
                { FieldOption.Random,"_random_" },                   { FieldOption.Mouse,"_mouse_" },                { FieldOption.LeftRight,"left-right" },
                { FieldOption.DontRotate,"don't rotate" },           { FieldOption.AllAround,"all around" },         { FieldOption.NextBackdrop,"next backdrop" },
                { FieldOption.PreviousBackdrop,"previous backdrop" },{ FieldOption.RandomBackdrop,"RandomBackDrop" },{ FieldOption.ColorEffect,"COLOR" },
                { FieldOption.FisheyeEffect,"FISHEYE" },             { FieldOption.WhirlEffect,"WHIRL" },            { FieldOption.PixelateEffect,"PIXELATE" },
                { FieldOption.MosaicEffect,"MOSAIC" },               { FieldOption.BrightnessEffect,"BRIGHTNESS" },  { FieldOption.GhostEffect,"GHOST" },
                { FieldOption.Front,"front" },                       { FieldOption.Back,"back" },                    { FieldOption.Number,"number" },
                { FieldOption.Name,"name" },                         { FieldOption.Forward,"forward" },              { FieldOption.Backward,"backward" },
                { FieldOption.Pitch,"PITCH" },                       { FieldOption.Pan,"PAN" },                      { FieldOption.Space,"space" },
                { FieldOption.UpArrow,"up arrow" },                  { FieldOption.DownArrow,"down arrow" },         { FieldOption.LeftArrow,"left arrow" },
                { FieldOption.RightArrow,"right arrow" },            { FieldOption.Loudness,"LOUDNESS" },            { FieldOption.Timer,"TIMER" },
                { FieldOption.All,"all" },                           { FieldOption.ThisScript,"this script" },       { FieldOption.OtherScriptsInSprite,"other scripts in sprite" },
                { FieldOption.Myself,"_myself_" },                   { FieldOption.Edge,"_edge_" },                  { FieldOption.Draggable,"draggable" },
                { FieldOption.NotDraggable,"not draggable" },        { FieldOption.BackdropNumber,"backdrop #" },    { FieldOption.Stage,"_stage_"  },
                { FieldOption.BackdropName,"backdrop name" },        { FieldOption.Volume,"volume" },
                { FieldOption.Year,"YEAR" },                         { FieldOption.Month,"MONTH" },                  { FieldOption.Date,"DATE" },
                { FieldOption.DayOfWeek,"DAYOFWEEK" },               { FieldOption.Hour,"HOUR" },                    { FieldOption.Minute,"MINUTE" },          { FieldOption.Second,"SECOND" },
                { FieldOption.Abs,"abs" },                           { FieldOption.Floor,"floor" },                  { FieldOption.Ceiling,"ceiling" },        { FieldOption.Sqrt,"sqrt" },
                { FieldOption.Sin,"sin" },                           { FieldOption.Cos,"cos" },                      { FieldOption.Tan,"tan" },
                { FieldOption.Asin,"asin" },                         { FieldOption.Acos,"acos" },                    { FieldOption.Atan,"atan" },
                { FieldOption.Ln,"ln" },                             { FieldOption.Log,"log" },                      { FieldOption.PowerE,"e ^" },
                { FieldOption.Power10,"10 ^" },       
                //Pen
                { FieldOption.PenColor,"color" },                   { FieldOption.PenSaturation,"saturation" },      { FieldOption.PenBrightness,"brightness" },
                { FieldOption.PenTransparency,"transparency" },
                //Drums
                { FieldOption.SnareDrum,"1" },{ FieldOption.BassDrum,"2" },{ FieldOption.SideStick,"3" },{ FieldOption.CrashCymbal,"4" },{ FieldOption.OpenHiHat,"5" },
                { FieldOption.ClosedHiHat,"6" },{ FieldOption.Tambourine,"7" },{ FieldOption.HandClap,"8" },{ FieldOption.Claves,"9" },{ FieldOption.WoodBlock,"10" },
                { FieldOption.Cowbell,"11" },{ FieldOption.Triangle,"12" },{ FieldOption.Bongo,"13" },{ FieldOption.Conga,"14" },{ FieldOption.Cabasa,"15" },
                { FieldOption.Guiro,"16" },{ FieldOption.Vibraslap,"17" },{ FieldOption.Cuica,"18" },
                //Insturment
                { FieldOption.Piano,"1" },{ FieldOption.ElectricPiano,"2" },{ FieldOption.Organ,"3" },{ FieldOption.Guitar,"4" },{ FieldOption.ElectricGuitar,"5" },
                { FieldOption.Bass,"6" },{ FieldOption.Pizziciato,"7" },{ FieldOption.Cello,"8" },{ FieldOption.Trombone,"9" },{ FieldOption.Clarinet,"10" },
                { FieldOption.Saxophone,"11" },{ FieldOption.Flute,"12" },{ FieldOption.WoodenFlute,"13" },{ FieldOption.Basson,"14" },{ FieldOption.Choir,"15" },
                { FieldOption.Vibraphone,"15" },{ FieldOption.MusicBox,"16" },{ FieldOption.SteelDrum,"18" },{ FieldOption.Marimba,"19" },{ FieldOption.SynthLead,"20" },
                { FieldOption.SynthPad,"21" },


            };
;
        }
        

        public enum FieldObjectType
        {
            FieldOption,Text,Namable,IdentifiablePrimitive, Arg
        }
       


        FieldObjectType fieldObjectType;
        public object Value { get; }
      
        public InputName InputName;
        public ScratchField(InputName InputName,IScratchIdentifiablePrimitive scratchIdentifiablePrimitive)
        {
            fieldObjectType = FieldObjectType.IdentifiablePrimitive;
            Value = scratchIdentifiablePrimitive;  
            this.InputName = InputName;
        }
        public ScratchField(InputName InputName,IScratchNamable scratchNamable)
        {
            fieldObjectType = FieldObjectType.Namable;
            Value = scratchNamable;
            this.InputName = InputName;
        }

        public ScratchField(InputName InputName, FieldOption fieldOption)
        {
            fieldObjectType = FieldObjectType.FieldOption;
            Value = fieldOption;
            this.InputName = InputName;
        }

        public ScratchField(InputName InputName, string text)
        {
            fieldObjectType = FieldObjectType.Text;
            Value = text;
            this.InputName = InputName;
        }

        public ScratchField(CBUsableArg arg)
        {
            fieldObjectType = FieldObjectType.Arg;
            Value = arg;
            this.InputName = InputName.VALUE;
        }


        public void WriteJSON(JsonTextWriter writer)
        {
            
            writer.WritePropertyName(ScratchInput.FieldMenuNames[InputName]);
        

            writer.WriteStartArray();
            if(fieldObjectType==FieldObjectType.IdentifiablePrimitive)
            {
                writer.WriteValue(((IScratchIdentifiablePrimitive)Value).ScratchName);
                writer.WriteValue(((IScratchIdentifiablePrimitive)Value).ObjectID);
            }
            else if (fieldObjectType == FieldObjectType.Namable)
            {

                writer.WriteValue(((IScratchNamable)Value).ScratchName);
                writer.WriteNull();
            }
            else if (fieldObjectType == FieldObjectType.FieldOption)
            {
                writer.WriteValue(FieldOptionScratchNames[(FieldOption)Value]);
                writer.WriteNull();
            }
            else if(fieldObjectType == FieldObjectType.Text)
            {
                writer.WriteValue(Value.ToString());
                writer.WriteNull();
            }
            else if (fieldObjectType == FieldObjectType.Arg)
            {
                writer.WriteValue(((CBUsableArg)Value).NameOrValue);
                writer.WriteNull();
            }

            writer.WriteEndArray();
        }
    }
}
