using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock Say(ArgPrimitiveString message)
        {
            return AddBlock(ScratchBlockOpCode.looks_say, message.GetInput(InputName.MESSAGE));
        }

        public ScratchBlock SayForSecs(ArgPrimitiveString message,ArgPrimitivePositiveNumber seconds)
        {
            return AddBlock(ScratchBlockOpCode.looks_sayforsecs, message.GetInput(InputName.MESSAGE),seconds.GetInput(InputName.SECS));
        }

        public ScratchBlock Think(ArgPrimitiveString message)
        {
            return AddBlock(ScratchBlockOpCode.looks_think, message.GetInput(InputName.MESSAGE));
        }

        public ScratchBlock ThinkForSecs(ArgPrimitiveString message, ArgPrimitivePositiveNumber seconds)
        {
            return AddBlock(ScratchBlockOpCode.looks_thinkforsecs, message.GetInput(InputName.MESSAGE), seconds.GetInput(InputName.SECS));
        }

        //There is also hacked block where you can switch to previous costume
        public ScratchBlock SwitchCostumeTo(ArgPureNamableInput<ScratchCostume> costume)
        {
            return AddBlock(ScratchBlockOpCode.looks_thinkforsecs, costume.GetInput(InputName.COSTUME,ScratchBlockOpCode.looks_costume,this));
        }

        public ScratchBlock NextCostume()
        {
            return AddBlock(ScratchBlockOpCode.looks_nextcostume);
        }

        public ScratchBlock SwitchBackdropTo(ArgNamableInput<SwitchBackdropMenu,ScratchCostume> backdrop)
        {
            return AddBlock(ScratchBlockOpCode.looks_thinkforsecs, backdrop.GetInput(InputName.BACKDROP, ScratchBlockOpCode.looks_backdrops, this));
        }

        public ScratchBlock NextBackdrop()
        {
            return AddBlock(ScratchBlockOpCode.looks_nextbackdrop);
        }

        public ScratchBlock ChangeSizeBy(ArgPrimitiveNumber change)
        {
            return AddBlock(ScratchBlockOpCode.looks_changesizeby,change.GetInput(InputName.CHANGE));
        }

        public ScratchBlock SetSizeTo(ArgPrimitiveNumber change)
        {
            return AddBlock(ScratchBlockOpCode.looks_setsizeto, change.GetInput(InputName.SIZE));
        }

        public ScratchBlock ChangeEffectBy(ArgPureField<CostumeEffect> effect, ArgPrimitiveNumber change)
        {
            return AddBlock(ScratchBlockOpCode.looks_changeeffectby, change.GetInput(InputName.CHANGE)).AddField(effect.GetField(InputName.EFFECT));
        }

        public ScratchBlock SetEffectTo(ArgPureField<CostumeEffect> effect, ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.looks_seteffectto, value.GetInput(InputName.CHANGE)).AddField(effect.GetField(InputName.EFFECT));
        }

        public ScratchBlock ClearGraphicsEffects()
        {
            return AddBlock(ScratchBlockOpCode.looks_cleargraphiceffects);
        }

        public ScratchBlock Show()
        {
            return AddBlock(ScratchBlockOpCode.looks_show);
        }

        public ScratchBlock Hide()
        {
            return AddBlock(ScratchBlockOpCode.looks_hide);
        }

        public ScratchBlock GoToFrontBack(ArgPureField<LayerFrontBack> frontBack)
        {
            return AddBlock(ScratchBlockOpCode.looks_gotofrontback).AddField(frontBack.GetField(InputName.FRONT_BACK)); 
        }

        public ScratchBlock GoForwardBackwardLayers(ArgPureField<LayerFrontBack> forwardBackward,ArgPrimitiveInteger num)
        {
            return AddBlock(ScratchBlockOpCode.looks_goforwardbackwardlayers, num.GetInput(InputName.NUM)).AddField(forwardBackward.GetField(InputName.FORWARD_BACKWARD));
        }

        public ScratchBlock CostumeNumberName(ArgPureField<CostumeNumberName> numberName)
        {
            return AddBlock(ScratchBlockOpCode.looks_costumenumbername).AddField(numberName.GetField(InputName.NUMBER_NAME));
        }

        public ScratchBlock BackdropNumberName(ArgPureField<CostumeNumberName> numberName)
        {
            return AddBlock(ScratchBlockOpCode.looks_backdropnumbername).AddField(numberName.GetField(InputName.NUMBER_NAME));
        }

        public ScratchBlock Size()
        {
            return AddBlock(ScratchBlockOpCode.looks_size);
        }
    }
}
