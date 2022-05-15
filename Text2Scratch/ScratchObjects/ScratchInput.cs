using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    public enum InputName
    {
        VARIABLE, LIST, BROADCAST_OPTION, BROADCAST_INPUT, COSTUME,
        custom_block,
        CONDITION, OPERAND,  SUBSTACK , SUBSTACK2, VALUE, NUM1, NUM2, DEGREES,TOWARDS, CHANGE, ITEM,
        INDEX, NUM, LETTER ,STRING, SECS, X, Y, MESSAGE,COLOR, COLOR2, STRING1, STRING2, STEPS, DIRECTION, DX,DY,DURATION,TIMES,
        SIZE, VOLUME, FROM, OPERAND1,OPERAND2, QUESTION,

        NOTE,DRUM, BEATS, INSTRUMENT, TEMPO,
        voices, WORDS , LANGUAGE, languages,


        //Menu
        TO, STYLE, BACKDROP, EFFECT, FRONT_BACK, NUMBER_NAME, FORWARD_BACKWARD, KEY_OPTION, WHENGREATERTHANMENU, OBJECT,
        STOP_OPTION, CLONE_OPTION, TOUCHINGOBJECTMENU, DRAG_MODE, PROPERTY, CURRENTMENU, OPERATOR, COLOR_PARAM,
        SOUND_MENU, DISTANCETOMENU ,

    }

   

    internal class ScratchInput:IScratchSerializable
    {
        static public readonly Dictionary<InputName, string> FieldMenuNames;

        static ScratchInput()
        {
            FieldMenuNames = Enum.GetValues(typeof(InputName)).Cast<InputName>().ToDictionary(t => t, t => t.ToString());
            FieldMenuNames[InputName.COLOR_PARAM] = "colorParam";
        }

        public enum ShadowType
        {
            Shadow=1, NoShadow=2 , ObscuredShadow=3
        }
        public enum InputObjectType
        {
            None,Primitive, IdentifiablePrimitive, Block
        }

        public enum InputNameType
        {
            Enum,CBArg
        }

        InputNameType inputNameType;
        public object inputName;

        public InputObjectType ShadowObjectType { get; }
        public object? ShadowValue { get; }
        public InputObjectType ValueObjectType { get; }
        public object? Value { get; }
        

        
      
        //Primitive Shadow
        public ScratchInput(InputName inputName,ScratchPrimitive scratchPrimitive)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = scratchPrimitive;
            ShadowObjectType = InputObjectType.Primitive;
        }
        //Field Shadow
        public ScratchInput(InputName inputName, ScratchBlockOpCode menuOpCode, FieldOption fieldOption,  ScratchScriptCreator scratchScriptCreator)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = scratchScriptCreator.AddShadowBlock(inputName, menuOpCode, fieldOption);
            ShadowObjectType = InputObjectType.Block;
        }

        //Namable as field option
        public ScratchInput(InputName inputName, ScratchBlockOpCode menuOpCode, IScratchNamable namable, ScratchScriptCreator scratchScriptCreator)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = scratchScriptCreator.AddShadowBlock(inputName, menuOpCode, namable);
            ShadowObjectType = InputObjectType.Block;
        }

        //Block
        public ScratchInput(InputName inputName, ScratchBlock scratchBlock, ScratchPrimitiveType shadowPrimitiveType)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = scratchBlock;
            ValueObjectType = InputObjectType.Block;
            ShadowValue = new ScratchPrimitive(shadowPrimitiveType, string.Empty);
            ShadowObjectType = InputObjectType.Primitive;
        }

        //No shadow Block
        public ScratchInput(InputName inputName, ScratchBlock scratchBlock , bool CheckBoolean)
        {
            if (CheckBoolean&&ScratchBlock.BlockTypes[scratchBlock.OpCode] != ScratchBlockType.Boolean)
                throw new ScratchException("Scratch block: " + scratchBlock.OpCode + " is not a boolean but "+ ScratchBlock.BlockTypes[scratchBlock.OpCode]);
               
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = scratchBlock;
            ValueObjectType = InputObjectType.Block;     
            ShadowValue = null;
            ShadowObjectType = InputObjectType.None;
        } 
       
        
        //Custom Block Arg
        public ScratchInput(InputName inputName, ScratchBlock scratchBlock)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = scratchBlock;
            ShadowObjectType = InputObjectType.Block;
        }

        //Block on field menu
        public ScratchInput(InputName inputName,ScratchBlockOpCode menuOpCode, ScratchBlock scratchBlock, ScratchScriptCreator scratchScriptCreator)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = scratchBlock;
            ValueObjectType = InputObjectType.Block;
            ShadowValue = scratchScriptCreator.AddShadowBlock(inputName, menuOpCode, FieldOption.Empty);
            ShadowObjectType = InputObjectType.Block;
        }

        //ScratchIdentifiablePrimitive
        public ScratchInput(InputName inputName, IScratchIdentifiablePrimitive scratchIdentifiablePrimitive, ScratchPrimitiveType shadowPrimitiveType)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = scratchIdentifiablePrimitive;
            ValueObjectType = InputObjectType.IdentifiablePrimitive;
            ShadowValue = new ScratchPrimitive(shadowPrimitiveType, string.Empty);
            ShadowObjectType = InputObjectType.Primitive;
        }

        //ScratchIdentifiablePrimitive on field menu
        public ScratchInput(InputName inputName, ScratchBlockOpCode menuOpCode, IScratchIdentifiablePrimitive scratchIdentifiablePrimitive, ScratchScriptCreator scratchScriptCreator)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = scratchIdentifiablePrimitive;
            ValueObjectType = InputObjectType.IdentifiablePrimitive;
            ShadowValue = scratchScriptCreator.AddShadowBlock(inputName, menuOpCode, FieldOption.Empty);
            ShadowObjectType = InputObjectType.Block;
        }

        //ScratchIdentifiablePrimitive as field option
        public ScratchInput(InputName inputName, IScratchIdentifiablePrimitive scratchIdentifiablePrimitive)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = scratchIdentifiablePrimitive;
            ShadowObjectType = InputObjectType.IdentifiablePrimitive;
        }

        //text instead of field for all character support
        public ScratchInput(InputName inputName, ScratchBlockOpCode menuOpCode, string text, ScratchScriptCreator scratchScriptCreator)
        {
            this.inputName = inputName;
            inputNameType = InputNameType.Enum;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = scratchScriptCreator.AddShadowBlock(inputName, menuOpCode, text);
            ShadowObjectType = InputObjectType.Block;
        }

        
        //CustomBlockArguments
        public ScratchInput(CBUsableArg arg, ScratchBlock argBlock)
        {      
            inputNameType = InputNameType.CBArg;
            inputName = arg;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = argBlock;
            ShadowObjectType = InputObjectType.Block;
        }

        //CustomBlockParameters
        public ScratchInput(CBArgNumString arg,string shadowValue)
        {
            inputNameType = InputNameType.CBArg;
            inputName = arg;
            Value = null;
            ValueObjectType = InputObjectType.None;
            ShadowValue = new ScratchPrimitive(ScratchPrimitiveType.String,shadowValue);
            ShadowObjectType = InputObjectType.Primitive;
        }
        public ScratchInput(CBArgNumString arg, ScratchBlock block)
        {
            inputNameType = InputNameType.CBArg;
            inputName = arg;
            Value = block;
            ValueObjectType = InputObjectType.Block;
            ShadowValue = new ScratchPrimitive(ScratchPrimitiveType.String, "");
            ShadowObjectType = InputObjectType.Primitive;
        }
        public ScratchInput(CBArgBool arg, ScratchBlock block)
        {
            if (ScratchBlock.BlockTypes[block.OpCode] != ScratchBlockType.Boolean)
                throw new ScratchException("Scratch block: " + block.OpCode + " is not a boolean but " + ScratchBlock.BlockTypes[block.OpCode]);

            inputNameType = InputNameType.CBArg;
            inputName = arg;
            Value = block;
            ValueObjectType = InputObjectType.Block;
            ShadowValue = null;
            ShadowObjectType = InputObjectType.None;
        }

        public ScratchInput(CBArgBool arg, bool value,ScratchScriptCreator scriptCreator)
        {     
            inputNameType = InputNameType.CBArg;
            inputName = arg;
            if(value)
            {
                Value = scriptCreator.Not(false);
                ValueObjectType = InputObjectType.Block;
            }
            else
            {
                Value = null;
                ValueObjectType = InputObjectType.None;
            }

            ShadowValue = null;
            ShadowObjectType = InputObjectType.None;
        }



        /*
        //CustomBlockPrototype
        public ScratchInput(ScratchCustomBlock customBlock, ScratchScriptCreator scratchScriptCreator)
        {
            inputNameType = InputNameType.Enum;
            inputName = InputName.custom_block;
            Value = scratchScriptCreator.AddShadowBlock()
            ValueObjectType = InputObjectType.Block
        }*/


        public void WriteJSON(JsonTextWriter writer)
        {
            if(inputNameType==InputNameType.Enum)
                writer.WritePropertyName(inputName.ToString());
            else if(inputNameType == InputNameType.CBArg)
                writer.WritePropertyName(((CBUsableArg)inputName).ObjectID);

            writer.WriteStartArray();

            if (ValueObjectType==InputObjectType.None)
                writer.WriteValue(ShadowType.Shadow);
            else if (ShadowObjectType == InputObjectType.None)
                writer.WriteValue(ShadowType.NoShadow);
            else
                writer.WriteValue(ShadowType.ObscuredShadow);

            if(ValueObjectType==InputObjectType.IdentifiablePrimitive)
            {
                IScratchIdentifiablePrimitive identifiablePrimitive = Value as IScratchIdentifiablePrimitive;
                if(identifiablePrimitive != null)
                {
                    writer.WriteStartArray();
                    writer.WriteValue(identifiablePrimitive.GetScratchPrimitiveType);
                    writer.WriteValue(identifiablePrimitive.ScratchName);
                    writer.WriteValue(identifiablePrimitive.ObjectID);
                    writer.WriteEndArray();
                }      
            }
            else if(ValueObjectType==InputObjectType.Block)
            {
                ScratchBlock block=Value as ScratchBlock;
                if (block!=null)
                {
                    writer.WriteValue(block.ObjectID);
                }
            }
            if (ShadowObjectType == InputObjectType.Primitive)
            {
                ScratchPrimitive primitive = ShadowValue as ScratchPrimitive;
                if (primitive != null)
                {
                    primitive.WriteJSON(writer);
                }
            }
            else if (ShadowObjectType == InputObjectType.Block)
            {
                ScratchBlock block = ShadowValue as ScratchBlock;
                if (block != null)
                {
                    writer.WriteValue(block.ObjectID);
                }
            }
            else if (ShadowObjectType == InputObjectType.IdentifiablePrimitive)
            {
                IScratchIdentifiablePrimitive identifiablePrimitive = ShadowValue as IScratchIdentifiablePrimitive;
                if (identifiablePrimitive != null)
                {
                    writer.WriteStartArray();
                    writer.WriteValue(identifiablePrimitive.GetScratchPrimitiveType);
                    writer.WriteValue(identifiablePrimitive.ScratchName);
                    writer.WriteValue(identifiablePrimitive.ObjectID);
                    writer.WriteEndArray();
                }
            }

            if (ShadowObjectType == InputObjectType.None && ValueObjectType == InputObjectType.None)
                writer.WriteNull();


            writer.WriteEndArray();
        }
    }
}
