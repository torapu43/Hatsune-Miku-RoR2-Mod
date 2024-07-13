using RoR2;
using MikuMod.Modules.Achievements;

namespace MikuMod.Survivors.Miku.Achievements
{
    //automatically creates language tokens "ACHIEVMENT_{identifier.ToUpper()}_NAME" and "ACHIEVMENT_{identifier.ToUpper()}_DESCRIPTION" 
    [RegisterAchievement(identifier, unlockableIdentifier, null, null)]
    public class MikuMasteryAchievement : BaseMasteryAchievement
    {
        public const string identifier = MikuSurvivor.MIKU_PREFIX + "masteryAchievement";
        public const string unlockableIdentifier = MikuSurvivor.MIKU_PREFIX + "masteryUnlockable";

        public override string RequiredCharacterBody => MikuSurvivor.instance.bodyName;

        //difficulty coeff 3 is monsoon. 3.5 is typhoon for grandmastery skins
        public override float RequiredDifficultyCoefficient => 3;
    }
}