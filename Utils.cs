using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;

namespace WTKSound
{
    public class Utils
    {

        public static PlayerDeathReason DEATH_BY_FALL = PlayerDeathReason.ByOther(0);

        public static PlayerDeathReason DEATH_BY_DROWNING = PlayerDeathReason.ByOther(1);

        public static PlayerDeathReason DEATH_BY_LAVA = PlayerDeathReason.ByOther(2);

        public static PlayerDeathReason DEATH_BY_PRICK = PlayerDeathReason.ByOther(3);

        public static PlayerDeathReason DEATH_BY_DEMON_ALTAR = PlayerDeathReason.ByOther(4);

        public static PlayerDeathReason DEATH_BY_STONED = PlayerDeathReason.ByOther(5);

        public static PlayerDeathReason DEATH_BY_SUFFOCATE = PlayerDeathReason.ByOther(7);

        public static PlayerDeathReason DEATH_BY_BURN = PlayerDeathReason.ByOther(8);

        public static PlayerDeathReason DEATH_BY_POISON = PlayerDeathReason.ByOther(9);

        public static PlayerDeathReason DEATH_BY_ELECTRIC = PlayerDeathReason.ByOther(10);

        public static PlayerDeathReason DEATH_BY_HORRIFIED = PlayerDeathReason.ByOther(11);

        public static PlayerDeathReason DEATH_BY_TONGUE = PlayerDeathReason.ByOther(12);
    }
}
