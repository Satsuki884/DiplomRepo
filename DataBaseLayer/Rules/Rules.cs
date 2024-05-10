using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Rules
{
    public static class Rules
    {
        public static Dictionary<int, int> bossLevelAcssesRule = new Dictionary<int, int>() 
        {
            { 17, 25 },
            { 30, 45 },
            { 33, 50 },
            { 43, 65 },
            { 57, 85 },
            { 68, 100 }
        };
    }
}
