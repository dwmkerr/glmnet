using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GlmNet;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var rads = 60.0 * 2 * Math.PI / 360.0;

            var result = GlmNet.glm.perspective(60.0f, (float)800 / (float)600, 0.1f, 100);
        }
        
    }
}
