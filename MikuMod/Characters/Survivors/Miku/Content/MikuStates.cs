using EntityStates;
using IL.RoR2;
using RoR2;
using MikuMod.Survivors.Miku.SkillStates;

namespace MikuMod.Survivors.Miku
{
    public static class MikuStates
    {
        public static void Init()
        {
            Modules.Content.AddEntityState(typeof(ThrowLeek));

            Modules.Content.AddEntityState(typeof(Beam));

            Modules.Content.AddEntityState(typeof(Roll));

            Modules.Content.AddEntityState(typeof(Shout));

            Modules.Content.AddEntityState(typeof(MikuDeathState));
        }
    }

    public class MikuDeathState : GenericCharacterDeath
    {
        public override void OnEnter()
        {
            base.OnEnter();

            RoR2.Util.PlaySound("mikudeathsound", gameObject);
        }
    }
}
