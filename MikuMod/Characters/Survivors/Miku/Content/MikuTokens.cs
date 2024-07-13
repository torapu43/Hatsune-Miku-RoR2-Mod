using System;
using MikuMod.Modules;
using MikuMod.Survivors.Miku.Achievements;

namespace MikuMod.Survivors.Miku
{
    public static class MikuTokens
    {
        public static void Init()
        {
            AddMikuTokens();

            ////uncomment this to spit out a lanuage file with all the above tokens that people can translate
            ////make sure you set Language.usingLanguageFolder and printingEnabled to true
            //Language.PrintOutput("Miku.txt");
            ////refer to guide on how to build and distribute your mod with the proper folders
        }

        public static void AddMikuTokens()
        {
            string prefix = MikuSurvivor.MIKU_PREFIX;

            string desc = "Miku is a virtual singer who uses a leek and several songs to fight<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine
             + "< ! > Leek throw is a damage" + Environment.NewLine + Environment.NewLine
             + "< ! > I dont have a secondary plan yet" + Environment.NewLine + Environment.NewLine
             + "< ! > Roll has a lingering armor buff that helps to use it aggressively." + Environment.NewLine + Environment.NewLine
             + "< ! > Shout has different helpful effects based on which song is chosen" + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, searching for a new identity.";
            string outroFailure = "..and so he vanished, forever a blank slate.";

            Language.Add(prefix + "NAME", "Hatsune Miku");
            Language.Add(prefix + "DESCRIPTION", desc);
            Language.Add(prefix + "SUBTITLE", "The Chosen One");
            Language.Add(prefix + "LORE", "sample lore");
            Language.Add(prefix + "OUTRO_FLAVOR", outro);
            Language.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            Language.Add(prefix + "MASTERY_SKIN_NAME", "Alternate");
            #endregion

            #region Passive
            Language.Add(prefix + "PASSIVE_NAME", "Performer");
            Language.Add(prefix + "PASSIVE_DESCRIPTION", "Miku gains a damage buff based on how many enemies are within range.");
            #endregion

            #region Primary
            Language.Add(prefix + "PRIMARY_LEEK_NAME", "Throw Leek");
            Language.Add(prefix + "PRIMARY_LEEK_DESCRIPTION", Tokens.agilePrefix + $" Throw a leek for <style=cIsDamage>{100f * MikuStaticValues.leekDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            Language.Add(prefix + "SECONDARY_SHOUT_NAME", "World is Mine");
            Language.Add(prefix + "SECONDARY_SHOUT_DESCRIPTION", Tokens.agilePrefix + $" Scream really loud");
            #endregion

            #region Utility
            Language.Add(prefix + "UTILITY_ROLL_NAME", "Rolling Girl");
            Language.Add(prefix + "UTILITY_ROLL_DESCRIPTION", "Roll a short distance, gaining <style=cIsUtility>300 armor</style>. <style=cIsUtility>You cannot be hit during the roll.</style>");
            #endregion

            #region Special
            Language.Add(prefix + "SPECIAL_BEAM_NAME", "Miku Miku Beam");
            Language.Add(prefix + "SPECIAL_BEAM_DESCRIPTION", $"Stop all enemies in their tracks with a performance, finishing with laserbeams damaging them for <style=cIsDamage>{100f * MikuStaticValues.beamDamageCoefficient}% damage</style>.");
            #endregion

            #region Achievements
            Language.Add(Tokens.GetAchievementNameToken(MikuMasteryAchievement.identifier), "Miku: Mastery");
            Language.Add(Tokens.GetAchievementDescriptionToken(MikuMasteryAchievement.identifier), "As Miku, beat the game or obliterate on Monsoon.");
            #endregion
        }
    }
}
