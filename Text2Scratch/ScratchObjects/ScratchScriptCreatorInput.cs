using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    
        internal class ArgPrimitiveBase
        {
            protected object value;
            protected virtual ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.None; }

            public ArgPrimitiveBase(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) { value = scratchIdentifiablePrimitive; }
            public ArgPrimitiveBase(ScratchBlock scratchBlock){value = scratchBlock; }

            public ArgPrimitiveBase(object value){ this.value = value == null ? string.Empty : (value.ToString() ?? string.Empty); }

            public ScratchInput GetInput(InputName inputName)
            {
                if (value.GetType() == typeof(string))
                    return new ScratchInput(inputName, new ScratchPrimitive(PrimitiveType(),value));
                if (typeof(IScratchIdentifiablePrimitive).IsAssignableFrom(value.GetType()))
                    return new ScratchInput(inputName, value as IScratchIdentifiablePrimitive, PrimitiveType());
                if (value.GetType() == typeof(ScratchBlock))
                    return new ScratchInput(inputName, value as ScratchBlock, PrimitiveType());

                throw new ScratchException("Scratch input of type :" + value.GetType() + " is invalid");
            }      
        }

        internal class ArgPrimitiveNumber:ArgPrimitiveBase
        {
            protected override ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.Number; }
            public ArgPrimitiveNumber(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive):base(scratchIdentifiablePrimitive) { }
            public ArgPrimitiveNumber(ScratchBlock block) : base(block) { }

            public ArgPrimitiveNumber(float value) : base(value) { }

            public static implicit operator ArgPrimitiveNumber(float value)
            { return new ArgPrimitiveNumber(value); }
            public static implicit operator ArgPrimitiveNumber(ScratchVariable var)
            { return new ArgPrimitiveNumber(var); }
            public static implicit operator ArgPrimitiveNumber(ScratchList list)
            { return new ArgPrimitiveNumber(list); }
            public static implicit operator ArgPrimitiveNumber(ScratchBlock block)
            { return new ArgPrimitiveNumber(block); }
        }

        internal class ArgPrimitivePositiveNumber : ArgPrimitiveBase
        {
            protected override ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.PositiveNumber; }
            public ArgPrimitivePositiveNumber(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }
            public ArgPrimitivePositiveNumber(ScratchBlock block) : base(block) { }
            public ArgPrimitivePositiveNumber(float value) : base(value) { }

            public static implicit operator ArgPrimitivePositiveNumber(float value)
            {return new ArgPrimitivePositiveNumber(Math.Abs(value));}
            public static implicit operator ArgPrimitivePositiveNumber(ScratchVariable var)
            { return new ArgPrimitivePositiveNumber(var); }
            public static implicit operator ArgPrimitivePositiveNumber(ScratchList list)
            { return new ArgPrimitivePositiveNumber(list); }
            public static implicit operator ArgPrimitivePositiveNumber(ScratchBlock block)
            { return new ArgPrimitivePositiveNumber(block); }
        }

        internal class ArgPrimitiveInteger : ArgPrimitiveBase
        {
            protected override ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.Integer; }
            public ArgPrimitiveInteger(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }
            public ArgPrimitiveInteger(ScratchBlock block) : base(block) { }
            public ArgPrimitiveInteger(long value) : base(value) { }

            public static implicit operator ArgPrimitiveInteger(long value)
            { return new ArgPrimitiveInteger(value); }
            public static implicit operator ArgPrimitiveInteger(ScratchVariable var)
            { return new ArgPrimitiveInteger(var); }
            public static implicit operator ArgPrimitiveInteger(ScratchList list)
            { return new ArgPrimitiveInteger(list); }
            public static implicit operator ArgPrimitiveInteger(ScratchBlock block)
            { return new ArgPrimitiveInteger(block); }
        }

        internal class ArgPrimitivePositiveInteger : ArgPrimitiveBase
        {
            protected override ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.PositiveInteger; }
            public ArgPrimitivePositiveInteger(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }
            public ArgPrimitivePositiveInteger(ScratchBlock block) : base(block) { }
            public ArgPrimitivePositiveInteger(ulong value) : base(value) { }

            public static implicit operator ArgPrimitivePositiveInteger(ulong value)
            { return new ArgPrimitivePositiveInteger(value); }
            public static implicit operator ArgPrimitivePositiveInteger(ScratchVariable var)
            { return new ArgPrimitivePositiveInteger(var); }
            public static implicit operator ArgPrimitivePositiveInteger(ScratchList list)
            { return new ArgPrimitivePositiveInteger(list); }
            public static implicit operator ArgPrimitivePositiveInteger(ScratchBlock block)
            { return new ArgPrimitivePositiveInteger(block); }
        }

        internal class ArgPrimitiveColor : ArgPrimitiveBase
        {
            protected override ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.Color; }
            public ArgPrimitiveColor(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }
            public ArgPrimitiveColor(ScratchBlock block) : base(block) { }
            public ArgPrimitiveColor(ScratchColor value) : base(value) { }

            public static implicit operator ArgPrimitiveColor(ScratchColor value)
            { return new ArgPrimitiveColor(value); }
            public static implicit operator ArgPrimitiveColor(ScratchVariable var)
            { return new ArgPrimitiveColor(var); }
            public static implicit operator ArgPrimitiveColor(ScratchList list)
            { return new ArgPrimitiveColor(list); }
            public static implicit operator ArgPrimitiveColor(ScratchBlock block)
            { return new ArgPrimitiveColor(block); }
        }

        internal class ArgPrimitiveAngle : ArgPrimitiveBase
        {
            protected override ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.Angle; }
            public ArgPrimitiveAngle(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }
            public ArgPrimitiveAngle(ScratchBlock block) : base(block) { }
            public ArgPrimitiveAngle(double value) : base(value) { }

            public static implicit operator ArgPrimitiveAngle(double value)
            { return new ArgPrimitiveAngle(value - 360.0 * Math.Floor(value / 360.0)); }
            public static implicit operator ArgPrimitiveAngle(ScratchVariable var)
            { return new ArgPrimitiveAngle(var); }
            public static implicit operator ArgPrimitiveAngle(ScratchList list)
            { return new ArgPrimitiveAngle(list); }
            public static implicit operator ArgPrimitiveAngle(ScratchBlock block)
            { return new ArgPrimitiveAngle(block); }
        }

        internal class ArgPrimitiveString : ArgPrimitiveBase
        {
            protected override ScratchPrimitiveType PrimitiveType() { return ScratchPrimitiveType.String; }
            public ArgPrimitiveString(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }
            public ArgPrimitiveString(ScratchBlock block) : base(block) { }
            public ArgPrimitiveString(object value) : base(value) { }

            public static implicit operator ArgPrimitiveString(string value)
            { return new ArgPrimitiveString(value); }
            public static implicit operator ArgPrimitiveString(int value)
            { return new ArgPrimitiveString(value); }
            public static implicit operator ArgPrimitiveString(float value)
            { return new ArgPrimitiveString(value); }
            public static implicit operator ArgPrimitiveString(double value)
            { return new ArgPrimitiveString(value); }
            public static implicit operator ArgPrimitiveString(bool value)
            { return new ArgPrimitiveString(value); }
            public static implicit operator ArgPrimitiveString(ScratchVariable var)
            { return new ArgPrimitiveString(var); }
            public static implicit operator ArgPrimitiveString(ScratchList list)
            { return new ArgPrimitiveString(list); }
            public static implicit operator ArgPrimitiveString(ScratchBlock block)
            { return new ArgPrimitiveString(block); }
        }






        internal class ArgBoolean
        {
            object value;

            public ArgBoolean(ScratchBlock scratchBlock) { value = scratchBlock; }
            public ArgBoolean(bool val) { value = val; }
            public ScratchInput? GetInput(InputName inputName, ScratchScriptCreator scratchScriptCreator)
            {
                if (value.GetType() == typeof(bool))
                {
                    if ((bool)value)
                        return new ScratchInput(inputName, scratchScriptCreator.Not(false),true);
                    else
                        return null;
                }              
                if (value.GetType() == typeof(ScratchBlock))
                {
                    ScratchBlock scratchBlock = (ScratchBlock)value;
                    if(ScratchBlock.BlockTypes[scratchBlock.OpCode]!=ScratchBlockType.Boolean)
                        throw new ScratchException("Scratch block of type :" + scratchBlock.OpCode + " must be a boolean block");
                    return new ScratchInput(inputName, value as ScratchBlock, true);
                }
                   
                throw new ScratchException("Scratch input of type :" + value.GetType() + " is invalid");
            }
            public static implicit operator ArgBoolean(ScratchBlock block)
            { return new ArgBoolean(block); }
            public static implicit operator ArgBoolean(bool b)
            { return new ArgBoolean(b); }
        }

        internal class ArgInputBase<T> where T : Enum
        {
            protected object value;
            public ArgInputBase(T fieldOption) { value = (FieldOption)(object)fieldOption; }
            public ArgInputBase(ScratchBlock scratchBlock) { value = scratchBlock; }
            public ArgInputBase(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) { value = scratchIdentifiablePrimitive; }
            protected ArgInputBase(object value) { this.value = value; }

            public ScratchInput GetInput(InputName inputName, ScratchBlockOpCode menuOpCode, ScratchScriptCreator scratchScriptCreator)
            {
                if (value.GetType() == typeof(FieldOption))
                    return new ScratchInput(inputName,menuOpCode, (FieldOption)value, scratchScriptCreator);
                if (value.GetType() == typeof(ScratchBlock))
                    return new ScratchInput(inputName, menuOpCode, (ScratchBlock)value, scratchScriptCreator);
                if (typeof(IScratchIdentifiablePrimitive).IsAssignableFrom(value.GetType()))
                    return new ScratchInput(inputName, menuOpCode, value as IScratchIdentifiablePrimitive, scratchScriptCreator);

                ScratchInput input = GetInputAdditional(inputName, menuOpCode, scratchScriptCreator);

                if (input != null)
                    return input;
                throw new ScratchException("Scratch input of type :" + value.GetType() + " is invalid");
            }
            protected virtual ScratchInput? GetInputAdditional(InputName inputName, ScratchBlockOpCode menuOpCode, ScratchScriptCreator scratchScriptCreator) { return null; }
        }

        internal class ArgPureInput<T> : ArgInputBase<T>
            where T : Enum
        {
            public ArgPureInput(T fieldOption) : base(fieldOption) { }
            public ArgPureInput(ScratchBlock scratchBlock) : base(scratchBlock) { }
            public ArgPureInput(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }

            public static implicit operator ArgPureInput<T>(T fieldOption)
            { return new ArgPureInput<T>(fieldOption); }
            public static implicit operator ArgPureInput<T>(ScratchBlock block)
            { return new ArgPureInput<T>(block); }
            public static implicit operator ArgPureInput<T>(ScratchVariable var)
            { return new ArgPureInput<T>(var); }
            public static implicit operator ArgPureInput<T>(ScratchList list)
            { return new ArgPureInput<T>(list); }
        }

        internal class ArgNamableInput<T, V> : ArgInputBase<T>
            where T : Enum
            where V : IScratchNamable
        {
            public ArgNamableInput(T fieldOption) : base(fieldOption) { }
            public ArgNamableInput(ScratchBlock scratchBlock) : base(scratchBlock) { }
            public ArgNamableInput(V scratchNamable) : base(scratchNamable) { }
            public ArgNamableInput(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) : base(scratchIdentifiablePrimitive) { }

            protected override ScratchInput? GetInputAdditional(InputName inputName, ScratchBlockOpCode menuOpCode, ScratchScriptCreator scratchScriptCreator)
            {
                if (typeof(IScratchNamable).IsAssignableFrom(value.GetType()))
                    return new ScratchInput(inputName, menuOpCode, (IScratchNamable)value, scratchScriptCreator);

                return null;
            }

            public static implicit operator ArgNamableInput<T, V>(V scratchNamable)
            { return new ArgNamableInput<T, V>(scratchNamable); }

            public static implicit operator ArgNamableInput<T, V>(T fieldOption)
            { return new ArgNamableInput<T, V>(fieldOption); }
            public static implicit operator ArgNamableInput<T, V>(ScratchBlock block)
            { return new ArgNamableInput<T, V>(block); }
            public static implicit operator ArgNamableInput<T, V>(ScratchVariable var)
            { return new ArgNamableInput<T, V>(var); }
            public static implicit operator ArgNamableInput<T, V>(ScratchList list)
            { return new ArgNamableInput<T, V>(list); }
        }

        internal class ArgPureNamableInput<T> where T : IScratchNamable
        {
            protected object value;
            public ArgPureNamableInput(T namable) { value = namable; }
            public ArgPureNamableInput(ScratchBlock scratchBlock) { value = scratchBlock; }
            public ArgPureNamableInput(IScratchIdentifiablePrimitive scratchIdentifiablePrimitive) { value = scratchIdentifiablePrimitive; }
        
            public ScratchInput GetInput(InputName inputName, ScratchBlockOpCode menuOpCode, ScratchScriptCreator scratchScriptCreator)
            {
                if (value.GetType() == typeof(IScratchNamable))
                    return new ScratchInput(inputName, menuOpCode, (IScratchNamable)value, scratchScriptCreator);
                if (value.GetType() == typeof(ScratchBlock))
                    return new ScratchInput(inputName, menuOpCode, (ScratchBlock)value, scratchScriptCreator);
                if (typeof(IScratchIdentifiablePrimitive).IsAssignableFrom(value.GetType()))
                    return new ScratchInput(inputName, menuOpCode, value as IScratchIdentifiablePrimitive, scratchScriptCreator);
        
                throw new ScratchException("Scratch input of type :" + value.GetType() + " is invalid");
            }
        
            public static implicit operator ArgPureNamableInput<T>(T scratchNamable)
            { return new ArgPureNamableInput<T>(scratchNamable); }
            public static implicit operator ArgPureNamableInput<T>(ScratchBlock block)
            { return new ArgPureNamableInput<T>(block); }
            public static implicit operator ArgPureNamableInput<T>(ScratchVariable var)
            { return new ArgPureNamableInput<T>(var); }
            public static implicit operator ArgPureNamableInput<T>(ScratchList list)
            { return new ArgPureNamableInput<T>(list); }
        
        }


        internal class ArgIdentifiablePrimitiveInput<T>
           where T : IScratchIdentifiablePrimitive
        {
            private T value;
            public ArgIdentifiablePrimitiveInput(T identifiablePrimitive)  { value = identifiablePrimitive; }

            public ScratchInput GetInput(InputName inputName)
            {
                return new ScratchInput(inputName, value);
            }

            public static implicit operator ArgIdentifiablePrimitiveInput<T>(T identifiablePrimitive)
            { return new ArgIdentifiablePrimitiveInput<T>(identifiablePrimitive); }
        }


        internal class ArgFieldBase<T> where T : Enum
        {
            protected object value;

            public ArgFieldBase(T fieldOption) { value = (FieldOption)(object)fieldOption; }
            protected ArgFieldBase(object value) { this.value = value; }

            public ScratchField GetField(InputName inputName)
            {
                if (value.GetType() == typeof(FieldOption))
                    return new ScratchField(inputName, (FieldOption)value);

                ScratchField input = GetFieldAdditional(inputName);

                if (input != null)
                    return input;
                throw new ScratchException("Scratch field of type :" + value.GetType() + " is invalid");
            }
            protected virtual ScratchField? GetFieldAdditional(InputName inputName) { return null; }
        }

        internal class ArgPureField<T> : ArgFieldBase<T>
           where T : Enum
        {

            public T Value { get { return (T)value; } }
            public ArgPureField(T fieldOption) : base(fieldOption) { }

            public static implicit operator ArgPureField<T>(T fieldOption)
            { return new ArgPureField<T>(fieldOption); }
        }

        internal class ArgNamableField<T, V> : ArgFieldBase<T>
        where T : Enum
        where V :IScratchNamable
        {
            public ArgNamableField(T fieldOption) : base(fieldOption) { }
            public ArgNamableField(V namable) : base(namable) { }

            protected override ScratchField? GetFieldAdditional(InputName inputName)
            {
                if (typeof(IScratchNamable).IsAssignableFrom(value.GetType()))
                    return new ScratchField(inputName, (IScratchNamable)value);

                return null;
            }

            public static implicit operator ArgNamableField<T, V>(V scratchNamable)
            { return new ArgNamableField<T, V>(scratchNamable); }

            public static implicit operator ArgNamableField<T,V>(T fieldOption)
            { return new ArgNamableField<T, V>(fieldOption); }

        }

        internal class ArgPureNamableField<T> where T : IScratchNamable
        {
            object value;

            public ArgPureNamableField(T namable) { value = namable; }

            public ScratchField GetField(InputName inputName)
            {
                if (typeof(IScratchNamable).IsAssignableFrom(value.GetType()))
                    return new ScratchField(inputName, (IScratchNamable)value);


                throw new ScratchException("Scratch field of type :" + value.GetType() + " is invalid");
            }

            public static implicit operator ArgPureNamableField<T>(T scratchNamable)
            { return new ArgPureNamableField<T>(scratchNamable); }
        }



    
}
