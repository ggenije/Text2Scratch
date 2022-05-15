using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public IdentifierGenerator IdentifierGenerator { get; }
        private int x, y;
        bool canPutHat;
        bool firstBlockInCblock;
        private ScratchObjectManager spriteManager;
        public ScratchScriptCreator(ScratchObjectManager scratchObjectManager, int x, int y)
        {
            this.spriteManager = scratchObjectManager;
            lastBlock = null;
            TotalBlocks = new List<ScratchBlock>();
            this.IdentifierGenerator = scratchObjectManager.IdentifierGenerator;
            this.x = x;
            this.y = y;
            CblockStack = new Stack<Tuple<ScratchBlock, bool,InputName>>();
            canPutHat = true;
            firstBlockInCblock = false;
        }

        private ScratchBlock? lastBlock;
        public List<ScratchBlock> TotalBlocks { get; }

        private Stack<Tuple<ScratchBlock, bool, InputName>> CblockStack;

        private ScratchBlock AddBlock(ScratchBlockOpCode opCode, params ScratchInput?[] inputs)
        {
            
            ScratchBlockType blockType = ScratchBlock.BlockTypes[opCode];

            
            if (blockType==ScratchBlockType.Reporter||blockType==ScratchBlockType.Boolean)
                return AddReporterBlock(opCode, inputs);

            

            if (lastBlock != null && 
                ((ScratchBlock.BlockTypes[lastBlock.OpCode] == ScratchBlockType.Cap)||
                (lastBlock.mutation!=null&&lastBlock.mutation is StopMutation && !((StopMutation)lastBlock.mutation).HasNext)))
            {
                throw new ScratchException("The last block is cap, you cannot add any more non-reporter blocks");
            }

            if (canPutHat)
            {
                lastBlock = new ScratchBlock(IdentifierGenerator.NextID(), opCode, x, y);
  
                TotalBlocks.Add(lastBlock);

            }
            else if(lastBlock!=null)
            {
                if (ScratchBlock.BlockTypes[opCode] == ScratchBlockType.Hat)
                {
                    throw new ScratchException("Block of type: " + opCode.ToString() + " must be the first block.");
                }

                ScratchBlock newBlock= new ScratchBlock(IdentifierGenerator.NextID(), opCode);
                if (firstBlockInCblock)
                {
                    firstBlockInCblock = false;
                    lastBlock.AddInput(new ScratchInput(CblockStack.Peek().Item3,newBlock,false));
                }    
                else
                    lastBlock.NextBlock = newBlock;
               
                newBlock.ParentBlock = lastBlock;
                
          
                lastBlock = newBlock;
                TotalBlocks.Add(lastBlock);
            }

            canPutHat = false;

            AssignInputes(lastBlock,inputs);

            if (blockType == ScratchBlockType.C)
                StartCblock(opCode==ScratchBlockOpCode.control_if_else);

            return lastBlock;
        }

    
        private ScratchBlock AddReporterBlock(ScratchBlockOpCode blockType, params ScratchInput?[] inputs)
        {
            ScratchBlock newBlock;
            TotalBlocks.Add(newBlock = new ScratchBlock(IdentifierGenerator.NextID(), blockType));
            AssignInputes(newBlock, inputs);
            return newBlock;
        }

        private void AssignInputes(ScratchBlock newBlock, ScratchInput?[] inputs)
        {
            foreach (ScratchInput? input in inputs)
            {
                if(input!=null)
                {
                    newBlock.AddInput(input);
                    if (input.ValueObjectType == ScratchInput.InputObjectType.Block && ((ScratchBlock)input.Value) != null)
                    {
                        ((ScratchBlock)input.Value).ParentBlock = newBlock;
                    }
                    if (input.ShadowObjectType == ScratchInput.InputObjectType.Block && ((ScratchBlock)input.ShadowValue) != null)
                    {
                        ((ScratchBlock)input.ShadowValue).ParentBlock = newBlock;
                      
                    }
                   
                }
               
            }
        }

        public ScratchBlock AddShadowBlock(InputName inputName, ScratchBlockOpCode menuOpCode, FieldOption fieldOption)
        {
            ScratchBlock newBlock;
            TotalBlocks.Add(newBlock = new ScratchBlock(IdentifierGenerator.NextID(), menuOpCode, true));    
            newBlock.AddField(new ScratchField(inputName, fieldOption));
            return newBlock;
        }

        public ScratchBlock AddShadowBlock(InputName inputName, ScratchBlockOpCode menuOpCode, string text)
        {
            ScratchBlock newBlock;
            TotalBlocks.Add(newBlock = new ScratchBlock(IdentifierGenerator.NextID(), menuOpCode, true));
            newBlock.AddField(new ScratchField(inputName, text));
            return newBlock;
        }

        public ScratchBlock AddShadowBlock(InputName inputName, ScratchBlockOpCode menuOpCode, IScratchNamable namable)
        {
            ScratchBlock newBlock;
            TotalBlocks.Add(newBlock = new ScratchBlock(IdentifierGenerator.NextID(), menuOpCode, true));
            newBlock.AddField(new ScratchField(inputName, namable));
            return newBlock;
        }



        private void StartCblock(bool ifElse=false)
        {
            if (lastBlock!=null)
            {
               
                if (ifElse)
                {
                    CblockStack.Push(Tuple.Create(lastBlock, true, InputName.SUBSTACK2));
                    CblockStack.Push(Tuple.Create(lastBlock, false, InputName.SUBSTACK));
                }
                else
                {
                    CblockStack.Push(Tuple.Create(lastBlock, true, InputName.SUBSTACK));
                }

                firstBlockInCblock = true;
            }  
        }

        public void EndCblock()
        {
            if (CblockStack.Count == 0)
                throw new ScratchException("Too much EndCblock methods");
            var getBlock =CblockStack.Pop();
            lastBlock = getBlock.Item1;
            if (!getBlock.Item2)
            {
                firstBlockInCblock = true;
            }
        }

        public void AddScriptToSprite(ScratchSprite sprite)
        {
            if (CblockStack.Count != 0)
                throw new ScratchException("You need more EndCblock methods");
            sprite.AddScratchScript(TotalBlocks);
        }
        
    }
}
