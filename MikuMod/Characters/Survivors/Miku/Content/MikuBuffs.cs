using RoR2;
using UnityEngine;

namespace MikuMod.Survivors.Miku
{
    public static class MikuBuffs
    {
        // armor buff gained during roll
        public static BuffDef armorBuff;
        public static BuffDef popularity;

        public static void Init(AssetBundle assetBundle)
        {
            armorBuff = Modules.Content.CreateAndAddBuff("HenryArmorBuff",
                LegacyResourcesAPI.Load<BuffDef>("BuffDefs/HiddenInvincibility").iconSprite,
                Color.white,
                false,
                false);

            popularity = Modules.Content.CreateAndAddBuff("MikuPopularityBuff",
                MikuAssets.popularityIcon,
                Color.cyan,
                true,
                false);

            
        }
    }
}
