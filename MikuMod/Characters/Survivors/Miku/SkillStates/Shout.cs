using EntityStates;
using IL.RoR2.Mecanim;
using MikuMod.Survivors.Miku;
using RoR2;
using RoR2.Projectile;
using System;
using UnityEngine;

namespace MikuMod.Survivors.Miku.SkillStates
{
    public class Shout : BaseState
    {
        public static float BaseDuration = 0.65f;
        //delays for projectiles feel absolute ass so only do this if you know what you're doing, otherwise it's best to keep it at 0
        public static float BaseDelayDuration = 0.0f;

        public static float DamageCoefficient = MikuStaticValues.shoutDamageCoefficient;

        private static string muzzleString = "Muzzle";

        public override void OnEnter()
        {
            base.OnEnter();
            Util.PlaySound("mikushout", gameObject);
            Chat.AddMessage("SEKAAAAAAAAAAAAAAAI DE");
            var aimRay = GetAimRay();
            EffectManager.SimpleEffect(MikuAssets.shoutEffect, aimRay.origin, Util.QuaternionSafeLookRotation(aimRay.direction), false);
            characterBody.AddTimedBuff(MikuBuffs.popularity, 10f);
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (fixedAge >= BaseDuration && isAuthority)
            {
                outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

    }
}