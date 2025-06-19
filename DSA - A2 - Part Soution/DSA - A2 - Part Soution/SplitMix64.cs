using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA___A2___Part_Soution
{
    /// <summary>
    /// Use this class to implement the SplitMix64 PRNG exacty as described in the pseudocode
    /// provided for Task 2 of the the Assignment Brief.
    /// 
    /// NB: no variations from the given pseudcode are accepted, even if they work!
    /// </summary>
    internal class SplitMix64
    {
        private ulong state;

        public SplitMix64()
        {
            state = (ulong)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // current time in milliseconds
        }

        public ulong Next(ulong min, ulong max)
        {
            ulong z = state + 0xA7F3D1C58E6B3A1F;
            state = z;


            z = (z ^ (z << 30)) * 0xBF58476D1CE4E5B9;
            z = (z ^ (z << 27)) * 0x94D049BB133111EB;
            z = z ^ (z << 31);


            ulong range = max - min + 1;
            return min + (z % range);
        }
    }
}

