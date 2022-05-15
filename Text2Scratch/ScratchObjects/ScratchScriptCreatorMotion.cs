using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock MoveSteps(ArgPrimitiveNumber steps)
        {
            return AddBlock(ScratchBlockOpCode.motion_movesteps, steps.GetInput(InputName.STEPS));
        }
        
        public ScratchBlock TurnCW(ArgPrimitiveNumber degrees)
        {
            return AddBlock(ScratchBlockOpCode.motion_turnright, degrees.GetInput(InputName.DEGREES));
        }
        public ScratchBlock TurnCCW(ArgPrimitiveNumber degrees)
        {
            return AddBlock(ScratchBlockOpCode.motion_turnleft, degrees.GetInput(InputName.DEGREES));
        }

        public ScratchBlock GoTo(ArgNamableInput<GoToMenu,ScratchSprite> to)
        {
            return AddBlock(ScratchBlockOpCode.motion_goto, to.GetInput(InputName.TO,ScratchBlockOpCode.motion_goto_menu, this));
        }

        public ScratchBlock GoToXY(ArgPrimitiveNumber x, ArgPrimitiveNumber y)
        {
            return AddBlock(ScratchBlockOpCode.motion_gotoxy, x.GetInput(InputName.X), y.GetInput(InputName.Y));
        }

        public ScratchBlock GlideTo(ArgPrimitiveNumber secs, ArgNamableInput<GoToMenu, ScratchSprite> to)
        {
            return AddBlock(ScratchBlockOpCode.motion_glideto,secs.GetInput(InputName.SECS), to.GetInput(InputName.TO, ScratchBlockOpCode.motion_glideto_menu, this));
        }

        public ScratchBlock GlideToXY(ArgPrimitiveNumber secs, ArgPrimitiveNumber x, ArgPrimitiveNumber y)
        {
            return AddBlock(ScratchBlockOpCode.motion_glidesecstoxy, secs.GetInput(InputName.SECS), x.GetInput(InputName.X), y.GetInput(InputName.Y));
        }

        public ScratchBlock PointInDir(ArgPrimitiveAngle direction)
        {
            return AddBlock(ScratchBlockOpCode.motion_pointindirection, direction.GetInput(InputName.DIRECTION));
        }

        public ScratchBlock PointTowards(ArgNamableInput<PointTowards, ScratchSprite> towards)
        {
            return AddBlock(ScratchBlockOpCode.motion_pointtowards, towards.GetInput(InputName.TOWARDS, ScratchBlockOpCode.motion_pointtowards_menu,this));
        }

        public ScratchBlock ChangeXBy(ArgPrimitiveNumber x)
        {
            return AddBlock(ScratchBlockOpCode.motion_changexby, x.GetInput(InputName.DX));
        }
        public ScratchBlock SetX(ArgPrimitiveNumber x)
        {
            return AddBlock(ScratchBlockOpCode.motion_setx, x.GetInput(InputName.X));
        }

        public ScratchBlock ChangeYBy(ArgPrimitiveNumber y)
        {
            return AddBlock(ScratchBlockOpCode.motion_changeyby, y.GetInput(InputName.DY));
        }

        public ScratchBlock SetY(ArgPrimitiveNumber y)
        {
            return AddBlock(ScratchBlockOpCode.motion_sety, y.GetInput(InputName.Y));
        }

        public ScratchBlock IfOnEdgeBounce()
        {
            return AddBlock(ScratchBlockOpCode.motion_ifonedgebounce);
        }

        public ScratchBlock SetRotationStyle(ArgPureField<RotationStyle> rotStyle)
        {
            return AddBlock(ScratchBlockOpCode.motion_setrotationstyle).AddField(rotStyle.GetField(InputName.STYLE));
        }

        public ScratchBlock XPosition()
        {
            return AddBlock(ScratchBlockOpCode.motion_xposition);
        }

        public ScratchBlock YPosition()
        {
            return AddBlock(ScratchBlockOpCode.motion_yposition);
        }
        public ScratchBlock Direction()
        {
            return AddBlock(ScratchBlockOpCode.motion_direction);
        }
    }
}
