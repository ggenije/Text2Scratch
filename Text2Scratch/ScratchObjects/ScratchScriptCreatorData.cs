using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock SetVariableTo(ScratchVariable variable, ArgPrimitiveString value)
        {
            return AddBlock(ScratchBlockOpCode.data_setvariableto, value.GetInput(InputName.VALUE))
                .AddField(new ScratchField(InputName.VARIABLE, variable));
        }

        public ScratchBlock ChangeVariableBy(ScratchVariable variable, ArgPrimitiveString value)
        {
            return AddBlock(ScratchBlockOpCode.data_changevariableby, value.GetInput(InputName.VALUE))
                .AddField(new ScratchField(InputName.VARIABLE, variable));
        }

        public ScratchBlock ShowVariable(ScratchVariable variable)
        {
            return AddBlock(ScratchBlockOpCode.data_showvariable)
                .AddField(new ScratchField(InputName.VARIABLE, variable));
        }
        public ScratchBlock HideVariable(ScratchVariable variable)
        {
            return AddBlock(ScratchBlockOpCode.data_hidevariable)
                .AddField(new ScratchField(InputName.VARIABLE, variable));
        }

        public ScratchBlock AddToList(ArgPrimitiveString value, ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_addtolist,value.GetInput(InputName.ITEM))
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock DeleteFromList(ArgPrimitiveInteger index, ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_deleteoflist, index.GetInput(InputName.INDEX))
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock DeleteAllOfList(ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_deletealloflist)
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock InsertAtList(ArgPrimitiveString item ,ScratchList list, ArgPrimitiveInteger index)
        {
            return AddBlock(ScratchBlockOpCode.data_insertatlist, item.GetInput(InputName.ITEM),index.GetInput(InputName.INDEX))
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock ReplaceItemOfList(ArgPrimitiveInteger index, ScratchList list, ArgPrimitiveString item)
        {
            return AddBlock(ScratchBlockOpCode.data_replaceitemoflist, item.GetInput(InputName.ITEM), index.GetInput(InputName.INDEX))
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock ItemOfList(ArgPrimitiveInteger index, ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_itemoflist, index.GetInput(InputName.INDEX))
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock ItemNumOfList(ArgPrimitiveString item, ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_itemnumoflist, item.GetInput(InputName.ITEM))
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock LengthList(ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_lengthoflist)
                .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock ListContainsItem(ScratchList list, ArgPrimitiveString item)
        {
            return AddBlock(ScratchBlockOpCode.data_listcontainsitem, item.GetInput(InputName.ITEM))
              .AddField(new ScratchField(InputName.LIST, list));
        }

        public ScratchBlock ShowList(ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_showlist)
                .AddField(new ScratchField(InputName.LIST, list));
        }
        public ScratchBlock HideList(ScratchList list)
        {
            return AddBlock(ScratchBlockOpCode.data_hidelist)
                .AddField(new ScratchField(InputName.LIST, list));
        }
    }
}
