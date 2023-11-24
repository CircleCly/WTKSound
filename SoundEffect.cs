using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria;

namespace WTKSound
{
    public class SoundEffect : ModSystem
    {
        public static HashSet<SoundEffect> inCooldown = new HashSet<SoundEffect>();
        public SoundStyle[] soundStyles;
        public int numVariants;
        public int timer = 0;
        public Random random = new Random();

        public SoundEffect(String name)
        {
            soundStyles = new SoundStyle[1];
            soundStyles[0] = new SoundStyle("WTKSound/Sounds/" + name);
        }

        public SoundEffect(String name, int numVariants)
        {
            soundStyles = new SoundStyle[numVariants];
            for (int i = 0; i < numVariants; i++)
            {
                soundStyles[i] = new SoundStyle("WTKSound/Sounds/" + name + "_" + (i + 1));
            }
        }

        public void PlaySound(int cd)
        {
            if (timer == 0)
            {
                SoundEngine.PlaySound(soundStyles[random.Next(soundStyles.Length)]);
                timer = cd;
                inCooldown.Add(this);
            }
        }

        public void PlaySound()
        {
            PlaySound(600);
        }

        public override string ToString()
        {
            return $"name: {soundStyles[0]}, cd: {timer}";
        }
    }
}
