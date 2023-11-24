using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Terraria.ID;

namespace WTKSound
{
    public class SoundedPlayer : ModPlayer
    {
        Boolean prevPotionSick = false;
        Boolean potionSick = false;
        int prevNumItems = 0;
        int numItems = 0;

        public override void OnEnterWorld()
        {
            numItems = 0;
            for (int i = 0; i < Player.inventory.Length; i++)
            {
                if (Player.inventory[i].Name.Length > 0)
                {
                    numItems++;
                }
            }
            prevNumItems = numItems;
            potionSick = Player.HasBuff(BuffID.PotionSickness);
            prevPotionSick = potionSick;
        }
        public override void PostUpdate()
        {
            if (isLocalPlayer())
            {
                if (Player.lifeRegen < 0)
                {
                    WTKSound.LOW_HP_REGEN.PlaySound();
                }

                float healthPercent = (float)Player.statLife / Player.statLifeMax;
                if (healthPercent < 0.25 && healthPercent > 0)
                {
                    WTKSound.LOW_HP.PlaySound();
                }

                prevPotionSick = potionSick;
                potionSick = Player.HasBuff(BuffID.PotionSickness);
                if (potionSick && !prevPotionSick)
                {
                    if (Player.Male)
                    {
                        WTKSound.HEAL_MALE.PlaySound();
                    }
                    else
                    {
                        WTKSound.HEAL_FEMALE.PlaySound();
                    }
                }
                

                prevNumItems = numItems;
                numItems = 0;
                for (int i = 0; i < Player.inventory.Length; i++)
                {
                    if (Player.inventory[i].Name.Length > 0)
                    {
                        numItems++;
                    }
                }

                if (numItems - prevNumItems >= 3)
                {
                    WTKSound.MASS_LOOT.PlaySound(60);
                }

            }
            UpdateSoundCooldown();
        }

        private void UpdateSoundCooldown()
        {
            foreach (SoundEffect s in SoundEffect.inCooldown)
            {
                if (s.timer > 0)
                {
                    s.timer--;
                }
                if (s.timer == 0)
                {
                    SoundEffect.inCooldown.Remove(s);
                }
            }
        }
        
        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            if (isLocalPlayer())
            {
                if (damageSource == Utils.DEATH_BY_BURN)
                {
                    WTKSound.FIRE_DEATH.PlaySound();
                } else if (damageSource == Utils.DEATH_BY_POISON)
                {
                    WTKSound.POISON_DEATH.PlaySound();
                } else
                {
                    WTKSound.PLAYER_DEATH.PlaySound();
                }
            }
        }

        public override void OnHurt(Player.HurtInfo info)
        {
            if (isLocalPlayer())
            {
                WTKSound.PLAYER_HURT.PlaySound();
            }
        }

        public override void OnHitAnything(float x, float y, Entity victim)
        {
            if (victim.GetType() == typeof(NPC))
            {
                NPC npc = (NPC)victim;
                if (!npc.friendly && Main.LocalPlayer.velocity.Length() >= 5)
                {
                    WTKSound.MOVING_FIGHT.PlaySound();
                }
            }
        }


        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!target.friendly && target.lifeMax > 5)
            {
                if (damageDone > 2 * target.lifeMax) {
                    WTKSound.HEAVY_DAMAGE.PlaySound();
                    if (hit.DamageType == DamageClass.Melee)
                    {
                        WTKSound.BIG_STRIKE.PlaySound();
                    } else if (hit.DamageType == DamageClass.Ranged)
                    {
                        WTKSound.BIG_SHOT.PlaySound();
                    } else if (hit.DamageType == DamageClass.Magic)
                    {
                        WTKSound.BIG_MAGIC.PlaySound();
                    }
                } else if (damageDone > 1.5 * target.lifeMax)
                {
                    WTKSound.BIG_DAMAGE.PlaySound();
                }
            }
            
        }

        private bool isLocalPlayer()
        {
            return Player.whoAmI == Main.LocalPlayer.whoAmI;
        }
    }
}
