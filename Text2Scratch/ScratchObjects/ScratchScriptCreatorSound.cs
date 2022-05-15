using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock PlaySoundUntilDone(ArgPureNamableInput<ScratchSound> sound)
        {
            return AddBlock(ScratchBlockOpCode.sound_playuntildone, sound.GetInput(InputName.SOUND_MENU, ScratchBlockOpCode.sound_sounds_menu, this));
        }

        public ScratchBlock PlaySound(ArgPureNamableInput<ScratchSound> sound)
        {
            return AddBlock(ScratchBlockOpCode.sound_play, sound.GetInput(InputName.SOUND_MENU, ScratchBlockOpCode.sound_sounds_menu, this));
        }

        public ScratchBlock StopAllSounds()
        {
            return AddBlock(ScratchBlockOpCode.sound_stopallsounds);
        }

        public ScratchBlock ChangeSoundEffect(ArgPureField<SoundEffect> effect, ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.sound_changeeffectby, value.GetInput(InputName.VALUE)).AddField(effect.GetField(InputName.EFFECT));
        }

        public ScratchBlock SetSoundEffect(ArgPureField<SoundEffect> effect, ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.sound_seteffectto, value.GetInput(InputName.VALUE)).AddField(effect.GetField(InputName.EFFECT));
        }

        public ScratchBlock ClearSoundEffects()
        {
            return AddBlock(ScratchBlockOpCode.sound_cleareffects);
        }

        public ScratchBlock ChangeVolumeBy(ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.sound_changevolumeby, value.GetInput(InputName.VOLUME));
        }
        public ScratchBlock SetVolumeTo(ArgPrimitiveNumber value)
        {
            return AddBlock(ScratchBlockOpCode.sound_setvolumeto, value.GetInput(InputName.VOLUME));
        }

        public ScratchBlock Volume()
        {
            return AddBlock(ScratchBlockOpCode.sound_volume);
        }
    }
}
