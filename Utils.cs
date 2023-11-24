using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace WTKSound
{
    public class Utils
    {
        public static PlayerDeathReason DEATH_BY_BURN = PlayerDeathReason.ByOther(8);

        public static PlayerDeathReason DEATH_BY_POISON = PlayerDeathReason.ByOther(9);

        public static PlayerDeathReason DEATH_BY_ELECTRIC = PlayerDeathReason.ByOther(10);
    }
}
