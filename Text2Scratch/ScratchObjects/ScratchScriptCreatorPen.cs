using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock PenClear()
        {
            return AddBlock(ScratchBlockOpCode.pen_clear);
        }

        public ScratchBlock PenStamp()
        {
            return AddBlock(ScratchBlockOpCode.pen_stamp);
        }

        public ScratchBlock PenDown()
        {
            return AddBlock(ScratchBlockOpCode.pen_penDown);
        }

        public ScratchBlock PenUp()
        {
            return AddBlock(ScratchBlockOpCode.pen_penUp);
        }

        public ScratchBlock SetPenColor(ArgPrimitiveColor color)
        {
            return AddBlock(ScratchBlockOpCode.pen_setPenColortoColor,color.GetInput(InputName.COLOR));
        }

        public ScratchBlock ChangePenColorParam(ArgPureInput<ColorParam> colorParam, ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.pen_changePenSizeBy, 
                colorParam.GetInput(InputName.COLOR_PARAM,ScratchBlockOpCode.pen_menu_colorParam,this),
                value.GetInput(InputName.SIZE));
        }
        public ScratchBlock SetPenColorParam(ArgPureInput<ColorParam> colorParam, ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.pen_setPenColorParamTo,
                colorParam.GetInput(InputName.COLOR_PARAM, ScratchBlockOpCode.pen_menu_colorParam, this),
                value.GetInput(InputName.SIZE));
        }

        public ScratchBlock ChangePenSize(ArgPrimitiveNumber size)
        {
            return AddBlock(ScratchBlockOpCode.pen_changePenSizeBy, size.GetInput(InputName.SIZE));
        }

        public ScratchBlock SetPenSize(ArgPrimitiveNumber size)
        {
            return AddBlock(ScratchBlockOpCode.pen_setPenSizeTo, size.GetInput(InputName.SIZE));
        }


    }
}
