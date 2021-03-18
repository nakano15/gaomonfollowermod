using Terraria.ModLoader;
using giantsummon;

namespace gaomonfollowermod
{
	public class MainMod : Mod
	{
        public const string DigimonGroupID = "digimon"; //I set It as const, so I can just get the ID for all the companions in the mod with ease.
        public const int GaomonID = 0;

        public override void Load()
        {
        }

        public override object Call(params object[] args)
        {
            foreach (object arg in args)
            {
                if (arg is string) //
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

        /*public override void ModifyInterfaceLayers(System.Collections.Generic.List<Terraria.UI.GameInterfaceLayer> layers)
        {
            Terraria.UI.LegacyGameInterfaceLayer debuglayer = new Terraria.UI.LegacyGameInterfaceLayer("Gaomon Mod: Debug Layer", DrawDebugLayer, Terraria.UI.InterfaceScaleType.UI);
            layers.Add(debuglayer);
        }

        public static bool DrawDebugLayer()
        {
            TerraGuardian tg = giantsummon.PlayerMod.GetPlayerMainGuardian(Terraria.Main.player[Terraria.Main.myPlayer]);
            if (tg.Active)
            {
                Terraria.Utils.DrawBorderString(Terraria.Main.spriteBatch, "Body Frame: " + tg.BodyAnimationFrame + "  Left Arm Frame: " + tg.LeftArmAnimationFrame + "  Right Arm Frame: " + tg.RightArmAnimationFrame, new Microsoft.Xna.Framework.Vector2(Terraria.Main.screenWidth * 0.5f, Terraria.Main.screenHeight), Microsoft.Xna.Framework.Color.White, 1f, 0.5f, 1f);
                System.Collections.Generic.List<string> Texts = new System.Collections.Generic.List<string>();
                Texts.Add("Name: " + tg.Base.Name);
                Texts.Add("Invalid: " + tg.Base.InvalidGuardian);
                Texts.Add("Head Vanity Position: " + tg.Base.HeadVanityPosition.DefaultCoordinate);
                Texts.Add("Standing Frame: " + tg.Base.StandingFrame);
                Texts.Add("Jump Frame: " + tg.Base.JumpFrame);
                Texts.Add("Sitting Frame: " + tg.Base.SittingFrame);
                Texts.Add("Chair Sitting Frame: " + tg.Base.ChairSittingFrame);
                Texts.Add("Bed Sleeping Frame: " + tg.Base.BedSleepingFrame);
                Texts.Add("Revive Frame: " + tg.Base.ReviveFrame);
                Texts.Add("KO'd Frame: " + tg.Base.DownedFrame);
                Texts.Add("Throne Sitting Frame: " + tg.Base.ThroneSittingFrame);
                for (int t = 0; t < Texts.Count; t++)
                {
                    Terraria.Utils.DrawBorderString(Terraria.Main.spriteBatch, Texts[t], new Microsoft.Xna.Framework.Vector2(Terraria.Main.screenWidth * 0.5f, Terraria.Main.screenHeight - (24 * (t + 1))), Microsoft.Xna.Framework.Color.White, 1f, 0.5f, 1f);
                }
            }
            return true;
        }*/

        public static void CompanionDB(int ID, out GuardianBase gb) //Your very own companion DB.
        {
            switch (ID)
            {
                case 0:
                    gb = new GaomonBase(); //Make a class for your companion, extending GuardianBase to create a companion, then set a new instance of it as the GuardianBase value returned.
                    break;
                default:
                    gb = new GuardianBase(); //Always set the value to a new GuardianBase when the ID doesn't leads to a companion, this will recognize the companion as a non existing companion.
                    break;
            }
        }
	}
}