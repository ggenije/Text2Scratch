﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text2Scratch.ScratchObjects
{
    internal interface IScratchIdentifiablePrimitive:IScratchNamable,IScratchIdentifiable
    {
        public ScratchSprite? Sprite { get; }
        public ScratchPrimitiveType GetScratchPrimitiveType { get; }
    }
}
