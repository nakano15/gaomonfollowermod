using Terraria.ModLoader;
using giantsummon;

namespace gaomonfollowermod
{
	public class MainMod : Mod
	{
        public const string DigimonGroupID = "digimon"; //I set It as const, so I can just get the ID for all the companions in the mod with ease.
        public const int GaomonID = 0; //This is a constant. I use this to tell that 0 is basically Gaomon's ID. I just need to call that constant to tell that I want his Id.

        public override void Load()
        {
        }

        public override object Call(params object[] args)
        {
            foreach (object arg in args)
            {
                if (arg is string) //To check if the message is the kind we want to get.
                {
                    if ((string)arg == giantsummon.MainMod.CustomCompanionCallString)
                    {
                        giantsummon.Group group = giantsummon.MainMod.AddNewGroup(DigimonGroupID, "Digimon",true, true); //Add custom groups BEFORE adding custom companions.
                        group.AgeAffectsScale = false; //To disable the scaling based on age.
                        giantsummon.MainMod.AddGuardianList(this, CompanionDB); //Linking the mod companion db to the TerraGuardians mod.
                    }
                    if ((string)arg == giantsummon.MainMod.CustomStarterCallString)
                    {
                        giantsummon.MainMod.AddInitialGuardian(new GuardianID(GaomonID, this.Name)); //Adds a companion npc as possible starter companion when creating a new world.
                    }
                }
            }
            return base.Call(args);
        }

        public override void Unload()
        {
            giantsummon.MainMod.UnloadModGuardians(this);
        }

        public static void CompanionDB(int ID, out GuardianBase gb) //Your very own companion DB.
        {
            switch (ID)
            {
                case GaomonID: //Remember that constant I set above? I can use It as a value on this switch, to make It easier to find out who the id belongs.
                    gb = new GaomonBase(); //Make a class for your companion, extending GuardianBase to create a companion, then set a new instance of it as the GuardianBase value returned.
                    break;
                default:
                    gb = new GuardianBase(); //Always set the value to a new GuardianBase when the ID doesn't leads to a companion, this will recognize the companion as a non existing companion.
                    break;
            }
        }
	}
}