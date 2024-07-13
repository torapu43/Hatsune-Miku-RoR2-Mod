using EntityStates;
using IL.RoR2.Mecanim;
using MikuMod.Survivors.Miku;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace MikuMod.Survivors.Miku.SkillStates
{
    public class ThrowLeek : BaseState
    {
        GameObject projectilePrefab = MikuAssets.leekProjectilePrefab;
        float damageCoefficient = MikuStaticValues.leekDamageCoefficient;
        float force = 1f;
        float fireTime = .5f;
       
        float baseDuration = 0.65f;
        float duration;
        string attackSoundString = "HenryBombThrow";
        Ray aimRay;
        public override void OnEnter()
        {
            base.OnEnter();
            aimRay = GetAimRay();
            duration = baseDuration / attackSpeedStat;
            StartAimMode(duration + 2f, false);
            PlayAnimation(duration);
            Util.PlaySound(attackSoundString, gameObject);
            if (base.isAuthority)
            {
                Throw();
            }
        }

        
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (fixedAge >= duration && isAuthority)
            {
                outer.SetNextStateToMain();
                return;
            }
        }
        private void Throw()
        {
            var popularityMultiplier = 1 + characterBody.GetBuffCount(MikuBuffs.popularity);
            FireProjectileInfo fireProjectileInfo = new FireProjectileInfo
            {
                projectilePrefab = this.projectilePrefab,
                position = aimRay.origin,
                rotation = Util.QuaternionSafeLookRotation(aimRay.direction),
                owner = base.gameObject,
                damage = base.damageStat * damageCoefficient * popularityMultiplier,
                force = this.force,
                crit = base.RollCrit(),
            };
            ProjectileManager.instance.FireProjectile(fireProjectileInfo);

  
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

        public void PlayAnimation(float duration)
        {

            if (GetModelAnimator())
            {
                PlayAnimation("Gesture, Override", "ThrowBomb", "ThrowBomb.playbackRate", this.duration);
            }
        }
    }
}