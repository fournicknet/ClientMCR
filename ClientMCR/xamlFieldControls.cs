using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientMCR
{
    //this class might be able to be optimized if it was static,  static wasn't used since i'm still new 3/31/2022
    internal class xamlFieldControls
    {
        int maxTextLength = 40;

        public int MaxTextLengthControlMethod()
        {
            return maxTextLength;
        }

    }
}