using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal partial class ScratchScriptCreator
    {
        public ScratchBlock Touching(ArgNamableInput<TouchingObject,ScratchSprite> touchingObject)
        {
            return AddBlock(ScratchBlockOpCode.sensing_touchingobject,
                touchingObject.GetInput(InputName.TOUCHINGOBJECTMENU,ScratchBlockOpCode.sensing_touchingobjectmenu,this));
        }

        public ScratchBlock TouchingColor(ArgPrimitiveColor color)
        {
            return AddBlock(ScratchBlockOpCode.sensing_touchingcolor, color.GetInput(InputName.COLOR));
        }

        public ScratchBlock ColorTouchingColor(ArgPrimitiveColor color,ArgPrimitiveColor color2)
        {
            return AddBlock(ScratchBlockOpCode.sensing_coloristouchingcolor, color.GetInput(InputName.COLOR), color2.GetInput(InputName.COLOR2));
        }

        public ScratchBlock AskAndWait(ArgPrimitiveString question)
        {
            return AddBlock(ScratchBlockOpCode.sensing_askandwait, question.GetInput(InputName.QUESTION));
        }

        public ScratchBlock Answer()
        {
            return AddBlock(ScratchBlockOpCode.sensing_answer);
        }

        public ScratchBlock KeyPressed(ArgPureInput<KeyCode> keyCode)
        {
            return AddBlock(ScratchBlockOpCode.sensing_keypressed, keyCode.GetInput(InputName.KEY_OPTION,ScratchBlockOpCode.sensing_keyoptions ,this));
        }
        public ScratchBlock KeyPressed(char key)
        {
            return AddBlock(ScratchBlockOpCode.sensing_keypressed, new ScratchInput(InputName.KEY_OPTION, ScratchBlockOpCode.sensing_keyoptions, key.ToString(), this));
        }

        public ScratchBlock MouseDown()
        {
            return AddBlock(ScratchBlockOpCode.sensing_mousedown);
        }
        public ScratchBlock MouseX()
        {
            return AddBlock(ScratchBlockOpCode.sensing_mousex);
        }

        public ScratchBlock MouseY()
        {
            return AddBlock(ScratchBlockOpCode.sensing_mousey);
        }

        public ScratchBlock SetDragMode(ArgPureField<DragMode> dragMode)
        {
            return AddBlock(ScratchBlockOpCode.sensing_setdragmode).AddField(dragMode.GetField(InputName.DRAG_MODE));
        }

        public ScratchBlock Loudness()
        {
            return AddBlock(ScratchBlockOpCode.sensing_loudness);
        }

        public ScratchBlock Timer()
        {
            return AddBlock(ScratchBlockOpCode.sensing_timer);
        }

        public ScratchBlock ResetTimer()
        {
            return AddBlock(ScratchBlockOpCode.sensing_resettimer);
        }

        public ScratchBlock SensingOfStage(ArgPureField<BackdropOf> property)
        {
            return AddBlock(ScratchBlockOpCode.sensing_of, 
                new ScratchInput(InputName.OBJECT,ScratchBlockOpCode.sensing_of_object_menu,spriteManager.Stage,this))
                .AddField(property.GetField(InputName.PROPERTY));
        }
        public ScratchBlock SensingOfSprite(ArgNamableField<BackdropOf,IScratchIdentifiablePrimitive> property, ArgPureNamableInput<ScratchSprite> sprite)
        {
            return AddBlock(ScratchBlockOpCode.sensing_of,
                sprite.GetInput(InputName.OBJECT, ScratchBlockOpCode.sensing_of_object_menu, this))
                .AddField(property.GetField(InputName.PROPERTY));
        }

        public ScratchBlock Timer(ArgPureField<Current> current)
        {
            return AddBlock(ScratchBlockOpCode.sensing_current).AddField(current.GetField(InputName.CURRENTMENU));
        }

        public ScratchBlock DaysSince2000()
        {
            return AddBlock(ScratchBlockOpCode.sensing_dayssince2000);
        }

        public ScratchBlock Username()
        {
            return AddBlock(ScratchBlockOpCode.sensing_username);
        }
    }
}
