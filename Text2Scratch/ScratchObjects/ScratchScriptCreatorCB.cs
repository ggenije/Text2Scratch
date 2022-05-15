using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        
        private ScratchInput GetInputFromCBParam(CBUsableArg arg, CBParam param)
        {
            if(arg is CBArgNumString)
            {
                if (param.Value is ScratchBlock)
                {
                    return new ScratchInput((CBArgNumString)arg,(ScratchBlock)param.Value);
                }
                else
                {
                    return new ScratchInput((CBArgNumString)arg, param.Value.ToString());
                }
                throw new ScratchException("Parameter "+arg.NameOrValue+" must be a block , number or text");
            }
            else if(arg is CBArgBool)
            {
                if (param.Value is ScratchBlock)
                {
                    return new ScratchInput((CBArgBool)arg, (ScratchBlock)param.Value);
                }
                else if(param.Value is bool)
                {
                    return new ScratchInput((CBArgBool)arg, (bool)param.Value,this);
                }
                throw new ScratchException("Parameter " + arg.NameOrValue + " must be a block or boolean");
            }

            throw new ScratchException();
        }

        public ScratchBlock CallCustomBlock(ScratchCustomBlock customBlock,params CBParam[] param)
        {
            if (param.Length != customBlock.UsableArgs.Length)
                throw new ScratchException("This custom block must have" + customBlock.UsableArgs.Length + " parameters");


            ScratchInput[] inputs=new ScratchInput[param.Length];
            for(int i=0;i<inputs.Length;i++)
            {
                inputs[i] =GetInputFromCBParam(customBlock.UsableArgs[i],param[i]); 
            }
            return AddBlock(ScratchBlockOpCode.procedures_call, inputs).SetMutation(new CustomBlockMutation(customBlock, true));

        }

        public ScratchBlock DefineCustomBlock(ScratchCustomBlock customBlock)
        {
            ScratchBlock block = AddBlock(ScratchBlockOpCode.procedures_definition);
            ScratchBlock shadowBlock = new ScratchBlock(IdentifierGenerator.NextID(), ScratchBlockOpCode.procedures_prototype, true);
            block.AddInput(new ScratchInput(InputName.custom_block, shadowBlock));
            shadowBlock.ParentBlock = block;
            TotalBlocks.Add(shadowBlock);

           
            foreach(var usableArg in customBlock.UsableArgs)
            {
                ScratchBlock fieldBlock = AddCBUsableArgBlock(usableArg);
                usableArg.Set(this, fieldBlock);
                shadowBlock.AddInput(new ScratchInput(usableArg, fieldBlock));
                fieldBlock.ParentBlock = shadowBlock;
                TotalBlocks.Add(fieldBlock);
            }

            //ScratchCustomBlock newCustomBlock = new ScratchCustomBlock(runWithoutScreenRefresh, arguments, usableArgs.ToArray());

            shadowBlock.SetMutation(new CustomBlockMutation(customBlock, false));


            return block;
        }

        private ScratchBlock AddCBUsableArgBlock(CBUsableArg arg)
        {
            ScratchBlockOpCode blockType = (arg is CBArgNumString) ? ScratchBlockOpCode.argument_reporter_string_number : ScratchBlockOpCode.argument_reporter_boolean;
            ScratchBlock block = new ScratchBlock(IdentifierGenerator.NextID(), blockType, true);
            block.AddField(new ScratchField(arg));
            return block;
        }

        public ScratchBlock CreateArgumentBlock(CBUsableArg arg)
        {
            return AddBlock((arg is CBArgNumString)
                ? ScratchBlockOpCode.argument_reporter_string_number : ScratchBlockOpCode.argument_reporter_boolean)
                .AddField(new ScratchField(arg));
        }

        
    }
}
