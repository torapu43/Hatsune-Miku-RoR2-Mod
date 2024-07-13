using MikuMod.Survivors.Miku.Achievements;
using RoR2;
using UnityEngine;

namespace MikuMod.Survivors.Miku
{
    public static class MikuUnlockables
    {
        public static UnlockableDef characterUnlockableDef = null;
        public static UnlockableDef masterySkinUnlockableDef = null;

        public static void Init()
        {
            masterySkinUnlockableDef = Modules.Content.CreateAndAddUnlockbleDef(
                MikuMasteryAchievement.unlockableIdentifier,
                Modules.Tokens.GetAchievementNameToken(MikuMasteryAchievement.identifier),
                MikuSurvivor.instance.assetBundle.LoadAsset<Sprite>("texMasteryAchievement"));
        }
    }
}
