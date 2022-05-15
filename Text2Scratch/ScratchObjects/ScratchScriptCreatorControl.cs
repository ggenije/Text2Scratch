using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock WaitSeconds(ArgPrimitivePositiveNumber seconds)
        {
            return AddBlock(ScratchBlockOpCode.control_wait, seconds.GetInput(InputName.DURATION));
        }

        public ScratchBlock BeginRepeat(ArgPrimitivePositiveInteger times)
        {
            return AddBlock(ScratchBlockOpCode.control_repeat, times.GetInput(InputName.TIMES));
        }

        public ScratchBlock BeginForever()
        {
            return AddBlock(ScratchBlockOpCode.control_forever);
        }

        public ScratchBlock BeginIf(ArgBoolean condition)
        {
            return AddBlock(ScratchBlockOpCode.control_if, condition.GetInput(InputName.CONDITION, this));
        }

        public ScratchBlock BeginIfElse(ArgBoolean argBoolean)
        {
            return AddBlock(ScratchBlockOpCode.control_if_else, argBoolean.GetInput(InputName.CONDITION, this));
        }

        public ScratchBlock WaitUntil(ArgBoolean condition)
        {
            return AddBlock(ScratchBlockOpCode.control_wait_until, condition.GetInput(InputName.CONDITION, this));
        }

        public ScratchBlock BeginRepeatUntil(ArgBoolean condition)
        {
            return AddBlock(ScratchBlockOpCode.control_repeat_until, condition.GetInput(InputName.CONDITION, this));
        }

        public ScratchBlock Stop(ArgPureField<StopOption> stopOption)
        {
            return AddBlock(ScratchBlockOpCode.control_stop).AddField(stopOption.GetField(InputName.STOP_OPTION))
                .SetMutation(new StopMutation(stopOption.Value==StopOption.OtherScriptsInSprite));
        }

        public ScratchBlock WhenIStartAsClone()
        {
            return AddBlock(ScratchBlockOpCode.control_start_as_clone);
        }

        public ScratchBlock CreateClone(ArgNamableInput<CreateCloneOf,ScratchSprite> cloneOption)
        {
            return AddBlock(ScratchBlockOpCode.control_create_clone_of,
                cloneOption.GetInput(InputName.CLONE_OPTION,ScratchBlockOpCode.control_create_clone_of_menu,this));
        }

        public ScratchBlock DeleteThisClone()
        {
            return AddBlock(ScratchBlockOpCode.control_delete_this_clone);
        }
    }
}
