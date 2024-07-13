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
        }
    }
}
