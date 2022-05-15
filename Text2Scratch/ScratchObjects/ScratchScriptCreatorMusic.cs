using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock PlayDrum(ArgPureInput<Drum> drum, ArgPrimitiveNumber beats)
        {
            return AddBlock(ScratchBlockOpCode.music_playDrumForBeats,
                drum.GetInput(InputName.DRUM, ScratchBlockOpCode.music_menu_DRUM, this),
                beats.GetInput(InputName.BEATS));
        }

        public ScratchBlock RestFor(ArgPrimitiveNumber beats)
        {
            return AddBlock(ScratchBlockOpCode.music_playDrumForBeats,
                beats.GetInput(InputName.BEATS));
        }

        public ScratchBlock PlayNote(uint note, ArgPrimitiveNumber beats)
        {
            return AddBlock(ScratchBlockOpCode.music_playNoteForBeats,
                new ScratchInput(InputName.NOTE, ScratchBlockOpCode.note, Math.Clamp(note,0,130).ToString(), this),
                beats.GetInput(InputName.BEATS));
        }

        public ScratchBlock SetInstrument(ArgPureInput<Instrument> instrument)
        {
            return AddBlock(ScratchBlockOpCode.music_playDrumForBeats,
                instrument.GetInput(InputName.INSTRUMENT, ScratchBlockOpCode.music_menu_INSTRUMENT, this));
        }

        public ScratchBlock SetTempo(ArgPrimitiveNumber tempo)
        {
            return AddBlock(ScratchBlockOpCode.music_setTempo,
                tempo.GetInput(InputName.TEMPO));
        }

        public ScratchBlock ChangeTempo(ArgPrimitiveNumber tempo)
        {
            return AddBlock(ScratchBlockOpCode.music_changeTempo,
                tempo.GetInput(InputName.TEMPO));
        }

        public ScratchBlock GetTempo()
        {
            return AddBlock(ScratchBlockOpCode.music_getTempo);
        }

    }
}
