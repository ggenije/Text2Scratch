using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    public enum FieldOption
    {
        Empty,
        Random, Mouse, LeftRight, DontRotate, AllAround, NextBackdrop, PreviousBackdrop, RandomBackdrop,
        ColorEffect, FisheyeEffect, WhirlEffect, PixelateEffect, MosaicEffect, BrightnessEffect, GhostEffect,
        Front, Back, Number, Name, Forward, Backward, Pitch, Pan,
        Space, UpArrow, DownArrow, LeftArrow, RightArrow,
        Loudness, Timer, All, ThisScript, OtherScriptsInSprite, Myself, Edge, Draggable, NotDraggable,
        XPosition, YPosition, Direction, CostumeNumber,CostumeName,
        BackdropNumber, Stage, BackdropName, Volume, Year, Month, Date, DayOfWeek, Hour, Minute, Second,
        Abs, Floor, Ceiling, Sqrt, Sin, Cos, Tan, Asin, Acos, Atan, Ln, Log, PowerE, Power10,
        //Pen
        PenColor, PenSaturation, PenBrightness, PenTransparency,
        //Drums
        SnareDrum,BassDrum,SideStick,CrashCymbal,OpenHiHat,ClosedHiHat,Tambourine,HandClap,Claves,
        WoodBlock,Cowbell,Triangle,Bongo,Conga,Cabasa,Guiro,Vibraslap,Cuica,
        //Instruments
        Piano,ElectricPiano,Organ,Guitar,ElectricGuitar,Bass,Pizziciato,Cello,Trombone,Clarinet,
        Saxophone,Flute,WoodenFlute,Basson,Choir,Vibraphone,MusicBox,SteelDrum,Marimba,SynthLead,SynthPad


    }

    public enum GoToMenu
    {
        Random = FieldOption.Random, Mouse = FieldOption.Mouse,
    }

    public enum PointTowards
    {
        Mouse = FieldOption.Mouse,
    }

    public enum RotationStyle
    {
        LeftRight = FieldOption.LeftRight, DontRotate = FieldOption.DontRotate, AllAround = FieldOption.AllAround,
    }
    public enum SwitchBackdropMenu
    {
        NextBackdeop = FieldOption.NextBackdrop, PreviousBackdeop = FieldOption.PreviousBackdrop, RandomBackdrop = FieldOption.RandomBackdrop,
    }
    public enum CostumeEffect
    {
        Color = FieldOption.ColorEffect, Fisheye = FieldOption.FisheyeEffect, Whirl = FieldOption.WhirlEffect,
        Pixelate = FieldOption.PixelateEffect, Mosaic = FieldOption.MosaicEffect, Brightness = FieldOption.BrightnessEffect,
        Ghost = FieldOption.GhostEffect,
    }
    public enum LayerFrontBack
    {
        Front = FieldOption.Front, Back = FieldOption.Back,
    }
    public enum CostumeNumberName
    {
        Number = FieldOption.Number, Name = FieldOption.Name,
    }
    public enum LayerMove
    {
        Frontward = FieldOption.Forward, Backward = FieldOption.Backward,
    }
    public enum SoundEffect
    {
        Pitch = FieldOption.Pitch, Pan = FieldOption.Pan,
    }
    public enum KeyCode
    {
        Space = FieldOption.Space, UpArrow = FieldOption.UpArrow, DownArrow = FieldOption.DownArrow,
        LeftArrow = FieldOption.LeftArrow, RightArrow = FieldOption.RightArrow
    }
    public enum EventWhen
    {
        Loudness = FieldOption.Loudness, Timer = FieldOption.Timer,
    }
    public enum StopOption
    {
        All = FieldOption.All, ThisScript = FieldOption.ThisScript, OtherScriptsInSprite = FieldOption.OtherScriptsInSprite,
    }
    public enum CreateCloneOf
    {
        Myself = FieldOption.Myself
    }
    public enum TouchingObject
    {
        Mouse = FieldOption.Mouse, Edge = FieldOption.Edge
    }
    public enum DragMode
    {
        Draggable = FieldOption.Draggable, NotDraggable = FieldOption.NotDraggable
    }
    public enum BackdropOf
    {
        BackdropNumber = FieldOption.BackdropNumber, BackdropName = FieldOption.BackdropName, Volume = FieldOption.Volume
    }

    public enum SpriteOf
    {
        XPosition = FieldOption.XPosition, YPosition = FieldOption.YPosition, Direction = FieldOption.Direction,
        CostumeNumber = FieldOption.CostumeNumber, CostumeName = FieldOption.CostumeName,
    }

    public enum Current
    {
        Year = FieldOption.Year, Month = FieldOption.Month, Date = FieldOption.Date,
        DayOfWeek = FieldOption.DayOfWeek, Hour = FieldOption.Hour, Minute = FieldOption.Minute,
        Second = FieldOption.Second,
    }
    public enum MathOp
    {
        Abs = FieldOption.Abs, Floor = FieldOption.Floor, Ceiling = FieldOption.Ceiling,
        Sqrt = FieldOption.Sqrt, Sin = FieldOption.Sin, Cos = FieldOption.Cos,
        Tan = FieldOption.Tan, Asin = FieldOption.Asin, Acos = FieldOption.Acos,
        Atan = FieldOption.Atan, Ln = FieldOption.Ln, Log = FieldOption.Log,
        PowerE = FieldOption.PowerE, Power10 = FieldOption.Power10,
    }

    public enum ColorParam
    {
        Color = FieldOption.PenColor, Saturation = FieldOption.PenSaturation,
        Brightness = FieldOption.PenBrightness, Transparency = FieldOption.PenTransparency
    }

    public enum Drum
    {
        SnareDrum = FieldOption.SnareDrum, BassDrum = FieldOption.BassDrum, SideStick = FieldOption.SideStick,
        CrashCymbal = FieldOption.CrashCymbal, OpenHiHat = FieldOption.OpenHiHat, ClosedHiHat = FieldOption.ClosedHiHat,
        Tambourine = FieldOption.Tambourine, HandClap = FieldOption.HandClap, Claves = FieldOption.Claves,
        WoodBlock = FieldOption.WoodBlock, Cowbell = FieldOption.Cowbell, Triangle = FieldOption.Triangle,
        Bongo = FieldOption.Bongo, Conga = FieldOption.Conga, Cabasa = FieldOption.Cabasa, 
        Guiro = FieldOption.Guiro, Vibraslap = FieldOption.Vibraslap, Cuica = FieldOption.Cuica,
    }

    public enum Instrument
    {
        Piano = FieldOption.Piano, ElectricPiano = FieldOption.ElectricPiano, Organ = FieldOption.Organ,
        Guitar = FieldOption.Guitar, ElectricGuitar = FieldOption.ElectricGuitar, Bass = FieldOption.Bass,
        Pizziciato = FieldOption.Pizziciato, Cello = FieldOption.Cello, Trombone = FieldOption.Trombone,
        Clarinet = FieldOption.Clarinet, Saxophone = FieldOption.Saxophone, Flute = FieldOption.Flute,
        WoodenFlute = FieldOption.WoodenFlute, Basson = FieldOption.Basson, Choir = FieldOption.Choir,
        Vibraphone = FieldOption.Vibraphone, MusicBox = FieldOption.MusicBox, SteelDrum = FieldOption.SteelDrum,
        Marimba = FieldOption.Marimba, SynthLead = FieldOption.SynthLead, SynthPad = FieldOption.SynthPad,
    }

  
}
