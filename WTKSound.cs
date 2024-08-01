
using System.Collections.Generic;
using Terraria.Graphics;
using Terraria.ModLoader;

namespace WTKSound
{
	public class WTKSound : Mod
	{

        public static readonly SoundEffect LOW_HP = new SoundEffect("low_hp", 2);
        public static readonly SoundEffect LOW_HP_REGEN = new SoundEffect("low_hp_regen", 2);

            MOVING_FIGHT = new SoundEffect("moving_fight", 7);
            MASS_LOOT = new SoundEffect("mass_loot", 2, 60);

        public static readonly SoundEffect BIG_STRIKE = new SoundEffect("big_strike", 2);
        public static readonly SoundEffect BIG_SHOT = new SoundEffect("big_shot", 2);
        public static readonly SoundEffect BIG_MAGIC = new SoundEffect("big_magic", 2);
        public static readonly SoundEffect HEAVY_DAMAGE = new SoundEffect("heavy_damage");
        public static readonly SoundEffect BIG_DAMAGE = new SoundEffect("big_damage");

        public static readonly SoundEffect MOVING_FIGHT = new SoundEffect("moving_fight", 7);
        public static readonly SoundEffect MASS_LOOT = new SoundEffect("mass_loot", 2, 60);

        public static readonly SoundEffect PLAYER_HURT = new SoundEffect("player_hurt", 3);
        public static readonly SoundEffect PLAYER_DEATH = new SoundEffect("player_death", 2);
        public static readonly SoundEffect FIRE_DEATH = new SoundEffect("fire_death");
        public static readonly SoundEffect POISON_DEATH = new SoundEffect("poison_death");
        public static readonly SoundEffect FALL_DEATH = new SoundEffect("fall_death");
        
    }
}