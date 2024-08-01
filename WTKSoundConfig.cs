using Mono.Cecil;
using System.Collections.Generic;
using Terraria.Localization;
using System.Reflection;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using static WTKSound.WTKSound;
using Terraria.ModLoader;
using System;
namespace WTKSound
{
    public class WTKSoundConfig : ModConfig
    {

        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Header("$Mods.WTKSound.Configs.WTKSoundConfig.Headers.General")]
        public bool ShowSoundMessages = true;

        [Header("$Mods.WTKSound.Configs.WTKSoundConfig.Headers.PlayerStats")]
        public SoundConfigData LOW_HP = new SoundConfigData(10, true);
        public SoundConfigData LOW_HP_REGEN = new SoundConfigData(10, true);

        [Header("$Mods.WTKSound.Configs.WTKSoundConfig.Headers.PlayerActions")]
        public SoundConfigData HEAL_MALE = new SoundConfigData(10, true);
        public SoundConfigData HEAL_FEMALE = new SoundConfigData(10, true);
        public SoundConfigData BIG_STRIKE = new SoundConfigData(10, true);
        public SoundConfigData BIG_SHOT = new SoundConfigData(10, true);
        public SoundConfigData BIG_MAGIC = new SoundConfigData(10, true);
        public SoundConfigData BIG_SUMMON = new SoundConfigData(10, true);
        public SoundConfigData HEAVY_DAMAGE = new SoundConfigData(10, true);
        public SoundConfigData BIG_DAMAGE = new SoundConfigData(10, true);
        public SoundConfigData MOVING_FIGHT = new SoundConfigData(10, true);
        public SoundConfigData MASS_LOOT = new SoundConfigData(10, true);
        public SoundConfigData PLAYER_HURT = new SoundConfigData(10, true);

        [Header("$Mods.WTKSound.Configs.WTKSoundConfig.Headers.EffectTriggers")]
        public SoundConfigData THORNS = new SoundConfigData(10, true);
        public SoundConfigData SHADOW_DODGE = new SoundConfigData(10, true);

        [Header("$Mods.WTKSound.Configs.WTKSoundConfig.Headers.DeathTriggers")]
        public SoundConfigData PLAYER_DEATH = new SoundConfigData(10, true);
        public SoundConfigData FIRE_DEATH = new SoundConfigData(10, true);
        public SoundConfigData POISON_DEATH = new SoundConfigData(10, true);
        public SoundConfigData FALL_DEATH = new SoundConfigData(10, true);

        public void ApplyConfigs()
        {
            WTKSoundConfig cfgInstance = ModContent.GetInstance<WTKSoundConfig>();
            foreach (FieldInfo entry in typeof(WTKSoundConfig).GetFields())
            {
                if (!entry.FieldType.Equals(typeof(SoundConfigData))) { continue; }
                string name = entry.Name.ToLower();
                if (SoundEffect.nameToInstance.ContainsKey(name))
                {
                    SoundEffect.nameToInstance[name].ApplyConfig((SoundConfigData)entry.GetValue(cfgInstance));
                }
            }
        }

        public override void OnChanged()
        {
            ApplyConfigs();
        }
    }

    public class SoundConfigData
    {
        public int cdSec;

        public bool enabled;

        public SoundConfigData()
        {

        }

        public SoundConfigData(int cd, bool enabled)
        {
            this.cdSec = cd;
            this.enabled = enabled;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            SoundConfigData other = (SoundConfigData)obj;
            return cdSec == other.cdSec && enabled == other.enabled;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(cdSec, enabled);
        }
    }
}

