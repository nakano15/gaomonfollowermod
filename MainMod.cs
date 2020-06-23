using Terraria.ModLoader;
using giantsummon;

namespace gaomonfollowermod
{
	public class MainMod : Mod
	{
        public static giantsummon.MainMod tgmod;

        public override void Load()
        {
            tgmod = (giantsummon.MainMod)ModLoader.GetMod("giantsummon");
            if (tgmod != null)
            {
                giantsummon.MainMod.AddGuardianList(this, CompanionDB);
            }
        }

        public static void CompanionDB(int ID, out GuardianBase gb)
        {
            switch (ID)
            {
                case 0:
                    gb = new GaomonBase();
                    break;
                default:
                    gb = new GuardianBase();
                    break;
            }
        }
	}
}