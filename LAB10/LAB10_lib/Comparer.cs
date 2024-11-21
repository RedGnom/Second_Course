using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_lib
{
    public class Comparer : IComparer<Place>
    {
        public int Compare(Place placeOne, Place placeTwo)
        {
            if (placeOne == null && placeTwo == null) return 0;
            if (placeOne == null) return -1;
            if (placeTwo == null) return 1;

            return placeOne.Name.CompareTo(placeTwo.Name);
        }
    }

}
