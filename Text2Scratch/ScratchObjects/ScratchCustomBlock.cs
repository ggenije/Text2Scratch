using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{

    public enum CBArgType
    {
        NumberString, Boolean, Text
    }


   

    internal class CBArg
    {
        public string NameOrValue { get; }
        public CBArgType argType;
        public CBArg(string nameOrValue) 
        { 
            NameOrValue = nameOrValue;
            argType = GetArgType();
        }
        public virtual CBArgType GetArgType()
        {
            return CBArgType.Text;
        }

        public static implicit operator CBArg(string value)
        { return new CBArg(value); }
    }

    internal class CBUsableArg:CBArg
    {
        protected ScratchScriptCreator? scriptCreator;
        public ScratchBlock? block;
        public string? ObjectID { get; private set; }
        public CBUsableArg(string name) : base(name)
        {
            scriptCreator = null;
            this.block = null;
            ObjectID = null;
        }
        public void Set(ScratchScriptCreator scratchScriptCreator, ScratchBlock block)
        {
            scriptCreator = scratchScriptCreator;
            ObjectID = scratchScriptCreator.IdentifierGenerator.NextID();
            this.block = block;
        }
    }


    internal class CBArgNumString: CBUsableArg
    {
        public CBArgNumString(string name) :base(name){}
        public override CBArgType GetArgType()
        {
            return CBArgType.NumberString;
        }
        public static implicit operator ScratchBlock(CBArgNumString arg)
        {
            if (arg.scriptCreator == null)
                throw new ScratchException("Use of unassigned custom block argument: " + arg.NameOrValue);
            return arg.scriptCreator.CreateArgumentBlock(arg);
        }

        public static implicit operator ArgPrimitiveNumber(CBArgNumString arg) { return new ArgPrimitiveNumber((ScratchBlock)arg); }
        public static implicit operator ArgPrimitivePositiveNumber(CBArgNumString arg) { return new ArgPrimitivePositiveNumber((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveInteger(CBArgNumString arg) { return new ArgPrimitiveInteger((ScratchBlock)arg); }
        public static implicit operator ArgPrimitivePositiveInteger(CBArgNumString arg) { return new ArgPrimitivePositiveInteger((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveColor(CBArgNumString arg) { return new ArgPrimitiveColor((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveAngle(CBArgNumString arg) { return new ArgPrimitiveAngle((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveString(CBArgNumString arg) { return new ArgPrimitiveString((ScratchBlock)arg); }
        public static implicit operator ArgBoolean(CBArgNumString arg) { return new ArgBoolean((ScratchBlock)arg); }
        public static implicit operator ArgPureInput<Enum>(CBArgNumString arg){ return new ArgPureInput<Enum>((ScratchBlock)arg); }
        public static implicit operator ArgNamableInput<Enum, IScratchNamable>(CBArgNumString arg) { return new ArgNamableInput<Enum, IScratchNamable>((ScratchBlock)arg); }
    }

    internal class CBArgBool : CBUsableArg
    {
        
        public CBArgBool(string name) : base(name) { }
        public override CBArgType GetArgType()
        {
            return CBArgType.Boolean;
        }
        public static implicit operator ScratchBlock(CBArgBool arg)
        {
            if (arg.scriptCreator==null)
                throw new ScratchException("Use of unassigned custom block argument: " + arg.NameOrValue);
            return arg.scriptCreator.CreateArgumentBlock(arg);
        }

        public static implicit operator ArgPrimitiveNumber(CBArgBool arg){ return new ArgPrimitiveNumber((ScratchBlock)arg); }
        public static implicit operator ArgPrimitivePositiveNumber(CBArgBool arg) { return new ArgPrimitivePositiveNumber((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveInteger(CBArgBool arg) { return new ArgPrimitiveInteger((ScratchBlock)arg); }
        public static implicit operator ArgPrimitivePositiveInteger(CBArgBool arg) { return new ArgPrimitivePositiveInteger((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveColor(CBArgBool arg) { return new ArgPrimitiveColor((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveAngle(CBArgBool arg) { return new ArgPrimitiveAngle((ScratchBlock)arg); }
        public static implicit operator ArgPrimitiveString(CBArgBool arg) { return new ArgPrimitiveString((ScratchBlock)arg); }
        public static implicit operator ArgBoolean(CBArgBool arg) { return new ArgBoolean((ScratchBlock)arg); }
        public static implicit operator ArgPureInput<Enum>(CBArgBool arg) { return new ArgPureInput<Enum>((ScratchBlock)arg); }
        public static implicit operator ArgNamableInput<Enum,IScratchNamable>(CBArgBool arg) { return new ArgNamableInput<Enum, IScratchNamable>((ScratchBlock)arg); }      
    }


    internal class CBParam
    {
        public object Value { get; }

        public CBParam(long v) { Value = v; }
        public CBParam(float v) { Value = v; }
        public CBParam(bool v) { Value = v; }
        public CBParam(ScratchBlock v) { Value = v; }

        public static implicit operator CBParam(long v) { return new CBParam(v); }
        public static implicit operator CBParam(bool v) { return new CBParam(v); }
        public static implicit operator CBParam(float v) { return new CBParam(v); }
        public static implicit operator CBParam(ScratchBlock v) { return new CBParam(v); }
    }



    internal class ScratchCustomBlock
    {
        CBArg[] args;
        public CBUsableArg[] UsableArgs { get; }
        public bool Warp { get; }
        public ScratchCustomBlock(bool runWithoutScreenRefresh, params CBArg[] args)
        {
            List<CBUsableArg> usableArgs = new List<CBUsableArg>();

            for (int i = 0; i < args.Length; i++)
            {
                CBUsableArg arg = args[i] as CBUsableArg;

                if (arg != null)
                {
                    usableArgs.Add(arg);
                }

            }

            Warp =runWithoutScreenRefresh;
            this.args = args;
            this.UsableArgs = usableArgs.ToArray();
        }

        public string ArgumentIDs()
        {
            StringBuilder sb=new StringBuilder();
            sb.Append("[");
            foreach(CBUsableArg arg in UsableArgs)
            {
                sb.Append("\"");
                if(arg.ObjectID!=null)
                    sb.Append(arg.ObjectID.ToString()); 
                sb.Append("\",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            
            return sb.ToString();
        }

        public string ArgumentNames()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (CBUsableArg arg in UsableArgs)
            {
                sb.Append("\""); sb.Append(arg.NameOrValue); sb.Append("\",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            
            return sb.ToString();
        }

        public string ArgumentDefaults()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (CBUsableArg arg in UsableArgs)
            {
                
                sb.Append("\"");
                if (arg is CBArgBool)
                    sb.Append("false");
                sb.Append("\",");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }

        public string Proccode()
        {
            StringBuilder sb = new StringBuilder();
            foreach (CBArg arg in args)
            {
                if (arg is CBArgBool)
                    sb.Append("%b");
                else if (arg is CBArgNumString)
                    sb.Append("%s");
                else
                    sb.Append(arg.NameOrValue);
                sb.Append(' ');
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
        }

    }
}
