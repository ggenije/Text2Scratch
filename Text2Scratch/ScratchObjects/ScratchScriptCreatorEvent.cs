using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock WhenFlagClicked()
        {
            return AddBlock(ScratchBlockOpCode.event_whenflagclicked);
        }

        public ScratchBlock WhenKeyPressed(ArgPureField<KeyCode> keyCode)
        {
            return AddBlock(ScratchBlockOpCode.event_whenkeypressed).AddField(keyCode.GetField(InputName.KEY_OPTION));
        }
        public ScratchBlock WhenKeyPressed(char character)//other characters
        {
            return AddBlock(ScratchBlockOpCode.event_whenkeypressed).AddField(new ScratchField(InputName.KEY_OPTION, character.ToString()));
        }

        public ScratchBlock WhenThisSpriteClicked()
        {
            return AddBlock(ScratchBlockOpCode.event_whenthisspriteclicked);
        }

        public ScratchBlock WhenGreaterThan(ArgPureField<EventWhen> eventWhen,ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.event_whenthisspriteclicked,value.GetInput(InputName.VALUE))
                .AddField(eventWhen.GetField(InputName.WHENGREATERTHANMENU));
        }

        public ScratchBlock WhenBroadcastReceived(ArgPureNamableField<ScratchBroadcast> broadcast)
        {
            return AddBlock(ScratchBlockOpCode.event_whenbroadcastreceived).AddField(broadcast.GetField(InputName.BROADCAST_OPTION));
        }
        public ScratchBlock Broadcast(ArgIdentifiablePrimitiveInput<ScratchBroadcast> broadcast)
        {
            return AddBlock(ScratchBlockOpCode.event_broadcast,broadcast.GetInput(InputName.BROADCAST_INPUT));
        }

        public ScratchBlock BroadcastAndWait(ArgIdentifiablePrimitiveInput<ScratchBroadcast> broadcast)
        {
            return AddBlock(ScratchBlockOpCode.event_broadcastandwait, broadcast.GetInput(InputName.BROADCAST_INPUT));
        }



    }
}
