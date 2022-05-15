using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text2Scratch.ScratchObjects
{
    internal class IdentifierGenerator
    {
        private uint counter;
        private int layerOrder;
        private readonly char[] characterSet;
        public IdentifierGenerator()
        {
            counter = 0;
            layerOrder = 0;
            characterSet = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/".ToCharArray();
            
        }

        private string GetIDFromNumber(uint number)
        {
            StringBuilder sb = new StringBuilder();

            do
            {
                var character = characterSet[number % 64];
                sb.Insert(0,character);
                number /= 64;
            } while (number > 0);



            return sb.ToString();
        }

        public string NextID()
        {
            string newID = GetIDFromNumber(counter+64*64);
            counter++;
            return newID;
        }

        public int NextLayerOrder()
        {
            return layerOrder++;
        }
    }
}
