﻿using RoR2;
using UnityEngine;
using MikuMod.Modules;
using System;
using RoR2.Projectile;

namespace MikuMod.Survivors.Miku
{
    public static class MikuAssets
    {
        // particle effects
        public static GameObject swordSwingEffect;
        public static GameObject swordHitImpactEffect;

        public static GameObject bombExplosionEffect;
        public static GameObject leekBreakEffect;

        // networked hit sounds
        public static NetworkSoundEventDef swordHitSoundEvent;

        //projectiles
        public static GameObject bombProjectilePrefab;
        public static GameObject leekProjectilePrefab;
        public static GameObject shoutEffect;

        public static  Sprite popularityIcon;

        private static AssetBundle _assetBundle;

        public static void Init(AssetBundle assetBundle)
        {

            _assetBundle = assetBundle;

            popularityIcon = assetBundle.LoadAsset<Sprite>("texMikuPopularity");

            swordHitSoundEvent = Content.CreateAndAddNetworkSoundEventDef("HenrySwordHit");

            CreateEffects();

            CreateProjectiles();
        }

        #region effects
        private static void CreateEffects()
        {
            CreateBombExplosionEffect();
            CreateLeekBreakEffect();

            shoutEffect = _assetBundle.LoadEffect("mikuShoutEffect");

            swordSwingEffect = _assetBundle.LoadEffect("HenrySwordSwingEffect", true);
            swordHitImpactEffect = _assetBundle.LoadEffect("ImpactHenrySlash");
        }
        private static void CreateLeekBreakEffect()
        {
            leekBreakEffect = _assetBundle.LoadEffect("mikuLeekExplosionEffect");
        }

        private static void CreateBombExplosionEffect()
        {
            bombExplosionEffect = _assetBundle.LoadEffect("BombExplosionEffect", "HenryBombExplosion");

            if (!bombExplosionEffect)
                return;

       //    ShakeEmitter shakeEmitter = bombExplosionEffect.AddComponent<ShakeEmitter>();
       //    shakeEmitter.amplitudeTimeDecay = true;
       //    shakeEmitter.duration = 0.5f;
       //    shakeEmitter.radius = 200f;
       //    shakeEmitter.scaleShakeRadiusWithLocalScale = false;
       //
       //    shakeEmitter.wave = new Wave
       //    {
       //        amplitude = 1f,
       //        frequency = 40f,
       //        cycleOffset = 0f
       //    };

        }
        #endregion effects

        #region projectiles
        private static void CreateProjectiles()
        {
            CreateBombProjectile();
            CreateLeekProjectile();
            Content.AddProjectilePrefab(bombProjectilePrefab);
            Content.AddProjectilePrefab(leekProjectilePrefab);
        }

        private static void CreateBombProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            bombProjectilePrefab = Assets.CloneProjectilePrefab("CommandoGrenadeProjectile", "HenryBombProjectile");

            //remove their ProjectileImpactExplosion component and start from default values
            UnityEngine.Object.Destroy(bombProjectilePrefab.GetComponent<ProjectileImpactExplosion>());
            ProjectileImpactExplosion bombImpactExplosion = bombProjectilePrefab.AddComponent<ProjectileImpactExplosion>();
            
            bombImpactExplosion.blastRadius = 16f;
            bombImpactExplosion.blastDamageCoefficient = 1f;
            bombImpactExplosion.falloffModel = BlastAttack.FalloffModel.None;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.lifetime = 12f;
            bombImpactExplosion.impactEffect = bombExplosionEffect;
            bombImpactExplosion.lifetimeExpiredSound = Content.CreateAndAddNetworkSoundEventDef("HenryBombExplosion");
            bombImpactExplosion.timerAfterImpact = true;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = bombProjectilePrefab.GetComponent<ProjectileController>();

            if (_assetBundle.LoadAsset<GameObject>("HenryBombGhost") != null)
                bombController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("HenryBombGhost");
            
            bombController.startSound = "";
        }

        private static void CreateLeekProjectile()
        {
            //highly recommend setting up projectiles in editor, but this is a quick and dirty way to prototype if you want
            leekProjectilePrefab = _assetBundle.LoadAndAddProjectilePrefab("MikuLeekProjectile");
            ProjectileController leekController = leekProjectilePrefab.GetComponent<ProjectileController>();

            ProjectileImpactExplosion impactExplosion = leekProjectilePrefab.GetComponent<ProjectileImpactExplosion>();
            impactExplosion.blastProcCoefficient = 1;
            impactExplosion.impactEffect = leekBreakEffect;

            if (_assetBundle.LoadAsset<GameObject>("MikuLeekGhost") != null)
                leekController.ghostPrefab = _assetBundle.CreateProjectileGhostPrefab("MikuLeekGhost");

            leekController.startSound = "";
        }
        #endregion projectiles
    }
}
