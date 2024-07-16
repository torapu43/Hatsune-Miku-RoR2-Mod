using EntityStates;
using MikuMod.Survivors.Miku;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace MikuMod.Survivors.Miku.SkillStates
{
    public class ThrowLeek : GenericProjectileBaseState
    {
        public static float BaseDuration = 0.65f;
        //delays for projectiles feel absolute ass so only do this if you know what you're doing, otherwise it's best to keep it at 0
        public static float BaseDelayDuration = 0.2f;

        public static float DamageCoefficient = MikuStaticValues.leekDamageCoefficient;

        public float popularityMultiplier;

        public override void OnEnter()
        {
            projectilePrefab = MikuAssets.leekProjectilePrefab;
            popularityMultiplier = 1 + (.05f * base.GetBuffCount(MikuBuffs.popularity));
            //base.effectPrefab = Modules.Assets.SomeMuzzleEffect;
            //targetmuzzle = "muzzleThrow"

            attackSoundString = "HenryBombThrow";

            baseDuration = BaseDuration;
            baseDelayBeforeFiringProjectile = BaseDelayDuration;

            damageCoefficient = DamageCoefficient * popularityMultiplier;
            //proc coefficient is set on the components of the projectile prefab
            force = 1f;

            //base.projectilePitchBonus = 0;
            //base.minSpread = 0;
            //base.maxSpread = 0;

            recoilAmplitude = 0.1f;
            bloom = 10;

            base.OnEnter();
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

        public override void PlayAnimation(float duration)
        {

            if (GetModelAnimator())
            {
                PlayAnimation("Gesture, Override", "ThrowBomb", "ThrowBomb.playbackRate", this.duration);
            }
        }
    }
}