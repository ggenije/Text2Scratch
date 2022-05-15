using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {

        public ScratchBlock Add(ArgPrimitiveString num1, ArgPrimitiveString num2)
        {
            return AddBlock(ScratchBlockOpCode.operator_add,
                num1.GetInput(InputName.NUM1), num2.GetInput(InputName.NUM2));
        }

        public ScratchBlock Substract(ArgPrimitiveString num1, ArgPrimitiveString num2)
        {
            return AddBlock(ScratchBlockOpCode.operator_add,
                num1.GetInput(InputName.NUM1), num2.GetInput(InputName.NUM2));
        }

        public ScratchBlock Multiply(ArgPrimitiveString num1, ArgPrimitiveString num2)
        {
            return AddBlock(ScratchBlockOpCode.operator_multiply,
                num1.GetInput(InputName.NUM1), num2.GetInput(InputName.NUM2));
        }

        public ScratchBlock Divide(ArgPrimitiveString num1, ArgPrimitiveString num2)
        {
            return AddBlock(ScratchBlockOpCode.operator_divide,
                num1.GetInput(InputName.NUM1), num2.GetInput(InputName.NUM2));
        }

        public ScratchBlock PickRandom(ArgPrimitiveNumber from, ArgPrimitiveNumber to)
        {
            return AddBlock(ScratchBlockOpCode.operator_random,
                from.GetInput(InputName.FROM), to.GetInput(InputName.TO));
        }

        public ScratchBlock GreaterThan(ArgPrimitiveString operand1, ArgPrimitiveString operand2)
        {
            return AddBlock(ScratchBlockOpCode.operator_gt,
                operand1.GetInput(InputName.OPERAND1), operand2.GetInput(InputName.OPERAND2));
        }

        public ScratchBlock LesserThan(ArgPrimitiveString operand1, ArgPrimitiveString operand2)
        {
            return AddBlock(ScratchBlockOpCode.operator_lt,
                operand1.GetInput(InputName.OPERAND1), operand2.GetInput(InputName.OPERAND2));
        }

        public ScratchBlock Equals(ArgPrimitiveString operand1, ArgPrimitiveString operand2)
        {
            return AddBlock(ScratchBlockOpCode.operator_equals,
                operand1.GetInput(InputName.OPERAND1), operand2.GetInput(InputName.OPERAND2));
        }

        public ScratchBlock And(ArgBoolean operand1, ArgBoolean operand2)
        {
            return AddBlock(ScratchBlockOpCode.operator_and,
                operand1.GetInput(InputName.OPERAND1,this), operand2.GetInput(InputName.OPERAND2, this));
        }
        public ScratchBlock Or(ArgBoolean operand1, ArgBoolean operand2)
        {
            return AddBlock(ScratchBlockOpCode.operator_or,
                operand1.GetInput(InputName.OPERAND1, this), operand2.GetInput(InputName.OPERAND2, this));
        }
      
        public ScratchBlock Not(ArgBoolean value)
        {
            return AddBlock(ScratchBlockOpCode.operator_not,
                value.GetInput(InputName.OPERAND,this));
        }

        public ScratchBlock Join(ArgPrimitiveString string1, ArgPrimitiveString string2)
        {
            return AddBlock(ScratchBlockOpCode.operator_join,
                  string1.GetInput(InputName.STRING1), string2.GetInput(InputName.STRING2));
        }

        public ScratchBlock LetterOf(ArgPrimitivePositiveInteger letter, ArgPrimitiveString _string)
        {
            return AddBlock(ScratchBlockOpCode.operator_letter_of,
                  letter.GetInput(InputName.LETTER), _string.GetInput(InputName.STRING));
        }

        public ScratchBlock LengthOf(ArgPrimitiveString _string)
        {
            return AddBlock(ScratchBlockOpCode.operator_length,
                  _string.GetInput(InputName.STRING));
        }

        public ScratchBlock Contains(ArgPrimitiveString string1, ArgPrimitiveString string2)
        {
            return AddBlock(ScratchBlockOpCode.operator_contains,
                  string1.GetInput(InputName.STRING1), string2.GetInput(InputName.STRING2));
        }

        public ScratchBlock Add(ArgPrimitiveNumber num1, ArgPrimitiveNumber num2)
        {
            return AddBlock(ScratchBlockOpCode.operator_mod,
                num1.GetInput(InputName.NUM1), num2.GetInput(InputName.NUM2));
        }

        public ScratchBlock Round(ArgPrimitiveNumber num)
        {
            return AddBlock(ScratchBlockOpCode.operator_mod,
                num.GetInput(InputName.NUM));
        }

        public ScratchBlock MathOp(ArgPureField<MathOp> _operator, ArgPrimitiveNumber num)
        {
            return AddBlock(ScratchBlockOpCode.operator_mod,
                num.GetInput(InputName.NUM)).AddField(_operator.GetField(InputName.OPERATOR));
        }

    }
}
