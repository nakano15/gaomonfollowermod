using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using giantsummon;

namespace gaomonfollowermod
{
    public class GaomonBase : GuardianBase
    {
        public GaomonBase()
        {
            Name = "Gaomon";
            SpriteWidth = SpriteHeight = 64;
            Width = 18;
            Height = 32;
            SetTerraGuardian();
            Age = 0;
            CanChangeGender = true;
            InitialMHP = 60; //480
            LifeCrystalHPBonus = 20;
            LifeFruitHPBonus = 6;
            DodgeRate = 15;
            CanDuck = false;
            ReverseMount = true;
            DontUseHeavyWeapons = true;
            CallUnlockLevel = 0;
            MountUnlockLevel = 255; //First need chair sitting animation.

            StandingFrame = 0;
            WalkingFrames = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};
            JumpFrame = 9;
            ItemUseFrames = new int[] { 10, 11, 12, 13 };

            LeftHandPoints.AddFramePoint2x(10, 12, 15);
            LeftHandPoints.AddFramePoint2x(11, 20, 21);
            LeftHandPoints.AddFramePoint2x(12, 21, 24);
            LeftHandPoints.AddFramePoint2x(13, 18, 27);

            RightHandPoints.AddFramePoint2x(10, 17, 15);
            RightHandPoints.AddFramePoint2x(11, 22, 21);
            RightHandPoints.AddFramePoint2x(12, 23, 24);
            RightHandPoints.AddFramePoint2x(13, 20, 27);

            HeadVanityPosition.DefaultCoordinate2x = new Microsoft.Xna.Framework.Point(15, 19);
        }

        public override void Attributes(TerraGuardian g)
        {
            g.MeleeCriticalRate += 15;
            g.DefenseRate += 0.05f;
            g.HealthRegenPower++;
        }

        public override string FriendLevelMessage
        {
            get
            {
                return "You're the best!";
            }
        }

        public override string BestFriendLevelMessage
        {
            get
            {
                return "We are doing great in our adventure.";
            }
        }

        public override string BFFLevelMessage
        {
            get
            {
                return "Come on, let's go punch some more things!";
            }
        }

        public override string BuddyForLifeLevelMessage
        {
            get
            {
                return "I will gladly follow you on your adventure, master.";
            }
        }

        public override string GreetMessage(Terraria.Player player, TerraGuardian guardian)
        {
            return "Woah! Are you my new master?";
        }

        public override string NormalMessage(Terraria.Player player, TerraGuardian guardian)
        {
            List<string> Mes = new List<string>();
            Mes.Add("Why I have to use weapons? I can use my first!");
            Mes.Add("It kind of feels like I'm in a completelly different universe.");
            Mes.Add("I don't think I'm ready for digivolution, but I will keep doing my best either way.");
            Mes.Add("So, you will fight too? Good, I would love fighting alongside you.");
            Mes.Add("In the world I came from, we fight while our masters gives us orders. It is quite nice that he I'm fighting alongside my master.");
            Mes.Add("If you get hurt, pull back for a while until you recover. I can handle them.");
            if (!Main.dayTime)
            {
                if (Main.bloodMoon)
                {
                    Mes.Add("Look at all those punching bags!");
                    Mes.Add("I can't wait to punch something.");
                    Mes.Add("I think that even If I tell you to stay behind me, you wont. Right?");
                }
                else
                {
                    Mes.Add("I don't think there are zombies in the world I came from. Not talking about zombie digimons, I mean.");
                    Mes.Add("Do you think we could go outside, to get some extra exp?");
                }
            }
            else
            {
                if (Main.eclipse)
                {
                    Mes.Add("Aack! What are those things?!");
                    Mes.Add("They will feel the power of my upper cut!");
                }
                else
                {
                    Mes.Add("Hey, boss!");
                    Mes.Add("It's weird being the only digimon in this world.");
                }
            }
            if (Main.raining && !Main.eclipse && !Main.bloodMoon)
            {
                Mes.Add("This... This isn't great... I preffer dry places.");
                Mes.Add("I think my gloves are filled with water.");
                Mes.Add("The rain sound is great. But only the sound.");
            }
            if (Main.hardMode)
            {
                Mes.Add("That giant flesh creature we fought was so scary! We aren't going to face It again, right?");
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Guide))
            {
                Mes.Add("I have been talking with [nn:" + Terraria.ID.NPCID.Guide + "], and he said that the reason I'm here, is because of third party intervention. What does that mean?");
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Merchant))
            {
                Mes.Add("Absurd that [nn:" + Terraria.ID.NPCID.Merchant + "] doesn't have any cards to sell. But for some reason, I can get benefits from potions.");
            }
            if (NPC.AnyNPCs(Terraria.ID.NPCID.Nurse))
            {
                Mes.Add("You have been talking with [nn:" + Terraria.ID.NPCID.Nurse+ "]? She probably complained that I visit her too frequently, right?");
            }

            if (giantsummon.NpcMod.GetTerraGuardianNPCCount() > 0)
            {
                Mes.Add("What are those creatures? They look like you, but taller, with fur, snout, ears, tail, and more wild.");
                Mes.Add("I was a bit scared of those creatures, until one of them talked to me. They are really nice guys.");
                Mes.Add("How I can speak with the TerraGuardians? I don't know. I just can hear them on my head.");
            }

            if (giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Rococo))
            {
                Mes.Add("[gn:" + 0 + "] asked me earlier If I'm like him. It didn't looked like he liked to know that I'm not.");
            }
            if (giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Blue))
            {
                if (giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Zacks))
                {
                    Mes.Add("Whaaaaaaaat? [gn:" + giantsummon.GuardianBase.Blue + "] has a boyfriend? And her boyfriend is a zombie?! Whaaaaaaaaaaaat?");
                }
                else
                {
                    Mes.Add("Say... Do you think I would have a chance with [gn:" + giantsummon.GuardianBase.Blue + "]?");
                }
            }
            if (giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Sardine) || giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Bree))
            {
                Mes.Add("It's good to see someone of my size in this world.");
            }
            if (giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Zacks))
            {
                Mes.Add("Uh... I guess It's all fine, having [gn:" + giantsummon.GuardianBase.Zacks + "] around. Right? Right??");
            }
            if (giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Brutus))
            {
                Mes.Add("You don't need a bodyguard, you has me.");
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }
    }
}
