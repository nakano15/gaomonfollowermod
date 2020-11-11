using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using giantsummon;

namespace gaomonfollowermod
{
    public class GaomonBase : giantsummon.GuardianBase
    {
        //Don't just copy and paste everything in this code.
        //Do mind that I'm not really a digifan, so take It easy if something is incorrect based on the anime/games.
        public GaomonBase()
        {
            //TODO - There is a confusion happening here, some datas and overriden methods are working correctly, others are still using the GuardianBase default value.
            Name = "Gaomon";
            SpriteWidth = SpriteHeight = 64; //When creating a companion sprite sheet, never let It's total width or height exceed 2000, for some reason that causes bugs to XNA.
            Width = 18; //Hitbox Width based on the sprite center.
            Height = 32; //Hitbox Height based on sprite bottom.
            //DuckingHeight = 32; //Height when companion is crouching.
            FramesInRows = 20; //Set here the maximum number of frames a row will have, until skip the animation to the next row.
            SetTerraGuardian();
            GroupID = MainMod.DigimonGroupID; //Set group ids AFTER you use SetTerraGuardian() or SetTerrarian(). Those methods overrides GroupID by default.
            Size = GuardianSize.Medium; //Things like the wind push from the sandstorm affecting the companion are related ot this.
            Age = 0; //Lorewise, give them some average age, for immersion. Due to this companion just appearing after you use the Digivice, literally It's age is 0 (beside I wont try explaining why he spawns on child stage).
            CanChangeGender = true; //May be male or female.
            //Male = true; //Tells the companion gender. King and Queen Statue makes use of this. Some future dialogues may make use of It too.
            InitialMHP = 140; //480 - Initial Health the companion starts with. The 480 I placed on comment is the total health when all life crystals and life fruits the companion will have. It's good if you log It too.
            LifeCrystalHPBonus = 16; //How much max health bonus each life crystal will give. Remember that a maximum of 15 life crystals can be used by the companion.
            LifeFruitHPBonus = 6; //How much max health bonus each Life Fruit will give. Remember that a maximum of 20 life fruits can be used by the companion.
            //CalculateHealthToGive(480, 0.5f,0.5f); //If you are lazy to calculate the max health given by each life increasing item, you can use this method instead.
            //InitialMP = 20; //Initial MP the companion has.
            //ManaCrystalMPBonus = 20; //Extra MP the companion will get for using Mana Crystal. Remember that they can use up to 9.
            DodgeRate = 5; //Default dodge rate of the companion. Default is 0.
            BlockRate = 0; //Default block rate of the companion. Default is 0.
            DrinksBeverage = false; //Drinks alcoholic stuffs?
            CanDuck = false; //Tells if companion can crouch or not.
            ReverseMount = true; //Tells the game that the follower will mount on your character back, instead of the inverse.
            DontUseHeavyWeapons = true; //The companion will not use heavy weapons, like the heavy swords the mod adds.
            //There are other settings you can make use of, just check out GuardianBase class on TerraGuardians mod.

            CallUnlockLevel = 0; //Level necessary to be able to call your companion for help. 0 = always possible. 255 = most likelly never possible.
            //LootingUnlockLevel = 3; //Companion loot unlock level.
            //MaySellYourLoot = 4; //Loot selling unlock level.
            //MountUnlockLevel = 5; //Mount unlock level.
            //StopMindingAFK = 7; //Level necessary for the follower to stop minding afk.
            //MountDamageReductionLevel = 9; //Level to have a damage reduction when mounted on follower.
            //ControlUnlockLevel = 10; //Level to unlock companion control.
            //FriendshipBondUnlockLevel = 12; //Level to get status bonus based on friendship level.
            //FallDamageReductionLevel = 15; //Level to unlock fall damage reduction.

            StandingFrame = 0;
            WalkingFrames = new int[] { 1, 2, 3, 4, 5, 6, 7, 8};
            JumpFrame = 9;
            ItemUseFrames = new int[] { 10, 11, 12, 13 };
            //Past here is optional, but animation bugs will happen If you don't make a sprite. (Ex:. Companion standing when you share mount)
            //For Sitting and Chair Sitting frames, sprite them on the same sitting point.
            //PlayerMountedArmAnimation = 0; //If ReverseMount is off, sets the frame the companion arm will be used for when the player is mounting on companion. By default, uses the jump frame.
            SittingFrame = 14; //Animation when companion is sitting on your mount. Also used by ReverseMount. Add a BodyFront frame for this, so the left(right) leg is shown in front of the player when sharing mount.
            ChairSittingFrame = 14; //Animation when companion is sitting on a chair. Same frame because both frames are used.
            ReviveFrame = 15; //Revive animation frame.
            DownedFrame = 16; //Downed = Knocked Out
            BedSleepingFrame = 17; //Sleeping animation for beds.
            ThroneSittingFrame = 18; //Animation when the companion is sitting on a throne.
            //DuckingFrame = 0; //Animation frame played when the companion is crouching.
            //DuckingSwingFrames = new int[] { 1, 2, 3}; //Attack animation frame for when the companion is ducking. 3 frames. Animation should be, Up, Up right, and Down right swing. On Up Right, set it somewhat above mouth, for when the companion uses potions.
            //PetrifiedFrame = 0; //Animation frame for when the companion is petrified. If there is no value set here, the game will freeze the animation, and apply some coloring to look like the follower is petrified.

            /*If you needed to move arrange the character sprite to fit the spritesheet, add the offset here.
             * For example, The bed is to the left of the spritesheet, based on the center of the sprite, add the number of pixels to the left 
             * the bed is at.
             * Sprite is 64x64? Bed sprite is at 0. Set the SleepingOffset to 16, so It will discount 16 pixels from the animation.*/
            SleepingOffset = new Microsoft.Xna.Framework.Point(0,0);

            SittingPoint = new Microsoft.Xna.Framework.Point(16 * 2, 27 * 2); //The position where the companion will sit on mount or chair. Take in consideration the center of It's legs.

            //Mounted position (aka mount sitting point).
            //If isn't a ReverseMount, will tell the position the player will sit on in each frame.
            //If is a ReverseMount, will tell the position the companion will sit on when mounting on the player.
            MountShoulderPoints.DefaultCoordinate2x = new Microsoft.Xna.Framework.Point(16, 27);

            //When set to true, tells the game that sprites drawn in front player on special occasions are on specified frames. This helps save memory.
            SpecificBodyFrontFramePositions = true;
            //Tells that Body Front frame 14 is 0.
            BodyFrontFrameSwap.Add(14, 0);

            //LeftHand is the same as the arm drawn in front of the body.
            //Since here, is to setup the center position of each hand. This is used for item positioning and other functions.
            //AddFramePoint2x automatically multiplicates the dimensions by 2, so you can speed up a bit this part.
            LeftHandPoints.AddFramePoint2x(10, 12, 15);
            LeftHandPoints.AddFramePoint2x(11, 20, 21);
            LeftHandPoints.AddFramePoint2x(12, 21, 24);
            LeftHandPoints.AddFramePoint2x(13, 18, 27);

            //I recommend setting points for the hands on the revive animation. It may be useful in the future.
            LeftHandPoints.AddFramePoint2x(15, 18, 28);

            //RightHand is the same as the arm drawn behind the body.
            RightHandPoints.AddFramePoint2x(10, 17, 15);
            RightHandPoints.AddFramePoint2x(11, 22, 21);
            RightHandPoints.AddFramePoint2x(12, 23, 24);
            RightHandPoints.AddFramePoint2x(13, 20, 27);

            RightHandPoints.AddFramePoint2x(13, 21, 28);

            /*Setups the position of the vanity items on the companion head. You will most likelly want to test this right after setting up, since the result may not be what you want. 
             * At least until you find the exact point that makes hats looks okay on your companions.
             Give your companion a Wizard Hat, It is perfect for testing this.*/
            HeadVanityPosition.DefaultCoordinate2x = new Microsoft.Xna.Framework.Point(16, 21);
            HeadVanityPosition.AddFramePoint2x(15, 18, 23);

            /*Sets the wing center position.
             * The mod automatically places It at the center of the companion sprite, but not always 
             * It will be displayed correctly.
             */
            //WingPosition.DefaultCoordinate2x = new Microsoft.Xna.Framework.Point();
            WingPosition.AddFramePoint2x(15, 15, 25);

            //Links to a method I made in this script to handle the companion specific requests.
            AddRequests();
            //Links to companion specific rewards method.
            AddRewards();
        }
        
        public override void Attributes(TerraGuardian g) //If you want to directly give boosts to the companion, use this. It updates every time the companion status updates, but that doesn't happens every mod frame.
        {
            g.MeleeCriticalRate += 10;
            g.DefenseRate += 0.05f;
            g.HealthRegenPower++;
        }


        //A few notes.
        //[name] = Speaking companion name.
        //[nickname] = The nickname given to your character. (By default is Terrarian, you can change It in-game.)
        //[gn:id:modid] = Gets a companion name.
        //[nn:type] = Gets a npc name.
        //Place those on the companion dialogue as you see fitting.
        public void AddRequests()
        {
            ///Request basics.
            ///Requests added to the companion are special requests. They only trigger after 5 requests are completed.
            ///Request Score affects the rewards you can receive, from type to count. There is a score bonus based on the objectives.
            ///Every time you use AddNewRequest, It creates a new request. The other options adds the new info to the latest request added to your companion request list.
            AddNewRequest("The Best Food?", 380, "I want to experiement a tasty food your world has to offer. I heard a lot of people saying that they like Soup, so what about giving me one?",
                "You will make a Soup for me? Amazing! I will be waiting.", "Is It too hard to make? Sad...", 
                "T-That's soup? Give It to me. *Gulps the soup in* Yay! Amazing! I really love It! This is my favorite food ever now!",
                "I don't know how to make a soup, but everything starts from a bowl, right?");
            AddItemCollectionObjective(Terraria.ID.ItemID.BowlofSoup, 1, 0);
            //Another Request
            AddNewRequest("No Peeking", 420, 
                "Remember the Eye of Cthulhu? I kind of have nightmares of It. Maybe If we defeat It again, the nightmares will go away?",
                "Let's do It tonight. I hope this works.",
                "Are you terrified by It too?",
                "We did a great job! But I'll only find out If It worked once I get some sleep.",
                "The Eye of Cthulhu appears during the night. We should try facing It some place that gives us advantage, though.");
            AddRequestRequirement(delegate(Player player)
            {
                return NPC.downedBoss1; //This request requires Eye of Cthulhu defeated to appear.
            });
            AddKillBossRequest(Terraria.ID.NPCID.EyeofCthulhu, 1); //Boss is 1 gem level tougher.
        }

        public void AddRewards()
        {
            //To setup the unique rewards the companion can give you for doing It's requests.
            //Those rewards will be given by the companion when you complete requests, or by other methods, If something else makes use of 
            //the companion rewards.
            AddReward(Terraria.ID.ItemID.Salmon, 2, 200, 0.75f, 1); //Adds chance of getting 2 Salmons, with 75% chance, if the spare reward score is 200 or above. For each extra stack (the 1 value), the reward score is depleted again to try giving another of the item.
            AddReward(Terraria.ID.ItemID.KOCannon, 1, 1000, 0.01f); //KO Cannon, 1% chance of appearing, 1000 reward score necessary.
            AddReward(Terraria.ID.ItemID.IronskinPotion, 3, 250, 0.4f, 2);
        }

        /// From here on is optional, the companion will use default messages when necessary, 
        /// but to make your companion richer in dialogue, It's recommended that you add dialogues 
        /// to It.
        /// 
        /// Due to being methods, you have more freedom and options to use when making the companion 
        /// dialogue.

        public override string LeavingWorldMessage //Message shown when the companion moves out of the world.
        {
            get
            {
                return "returned to the Digital World.";
            }
        }

        public override string LeavingWorldMessageGuardianSummoned //Same as above, but when the companion is following you.
        {
            get
            {
                return "had It's things packed to the Digital World.";
            }
        }

        public override string CallUnlockMessage //Message shown when you can call the companion for help.
        {
            get
            {
                return "";
            }
        }

        public override string MountUnlockMessage
        {
            get
            {
                return "Hey boss, my feet are tired, would you mind If I sit on your shoulder?";
            }
        }

        public override string ControlUnlockMessage
        {
            get
            {
                return "I get really worried when you get into fights with me. If you want, you can send me to do something dangerous instead.";
            }
        }
                
        public override string GreetMessage(Terraria.Player player, TerraGuardian guardian) //Message shown when you first meet the companion, adding It to your companion list.
        {
            return "Woah! Are you my new master?";
        }

        public override string NormalMessage(Terraria.Player player, TerraGuardian guardian) //Normal message displayed when you talk to the companion.
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
                Mes.Add("Absurd that [nn:" + Terraria.ID.NPCID.Merchant + "] doesn't have any disks to sell. But It seems like potions works too.");
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

        public override string TalkMessage(Player player, TerraGuardian guardian) //Messages that can be shown when you complete a Talk request. You can place personal things here, for hidden lore of the character.
        {
            List<string> Mes = new List<string>();
            Mes.Add("This place is kind of great! Adventure everywhere!");
            Mes.Add("Do you think we could go to my world?");
            Mes.Add("I think you're the best tamer ever.");
            Mes.Add("I kind of find the " + (WorldGen.crimson ? "Crimson" : "Corruption") + " creepy.");
            if (giantsummon.NpcMod.HasGuardianNPC(giantsummon.GuardianBase.Blue))
            {
                Mes.Add("Why does [gn:" + giantsummon.GuardianBase.Blue + "] rejects me? Is It because I'm small?");
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string HomelessMessage(Player player, TerraGuardian guardian) //Messages displayed when the companion is homeless.
        {
            List<string> Mes = new List<string>();
            if (Main.bloodMoon)
            {
                Mes.Add("*Arf* *Arf* Sorry, I'm not quite used to consecutive fights. Would be cool If I could avoid them.");
                Mes.Add("I can handle them, but I also need a moment to rest some times.");
            }
            else if (!Main.dayTime)
            {
                Mes.Add("I think danger could be anywhere like this. Don't you know some place I could stay?");
                Mes.Add("Zombies on the ground, Demon Eyes on the sky. This consecutive grinding isn't healthy for me.");
            }
            else
            {
                Mes.Add("The digivice seems to be busted, so there is no way I can return to It.");
                Mes.Add("I don't think that digivice works anymore. I think I may need a house.");
                if (Main.raining)
                {
                    Mes.Add("This isn't good for my fur. Is there some dry place I could stay on?");
                    Mes.Add("I dislike rain, do you know some place I could get dry?");
                }
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string NoRequestMessage(Player player, TerraGuardian guardian) //When companion has no request disponible.
        {
            List<string> Mes = new List<string>();
            Mes.Add("I don't need anything right now.");
            Mes.Add("The only thing I need, is to practice my punches.");
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string HasRequestMessage(Player player, TerraGuardian guardian) //When companion has request disponible.
        {
            List<string> Mes = new List<string>();
            Mes.Add("It is really weird for me to ask, but I need your help for something.");
            Mes.Add("Hey boss! Can you help me with something?");
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string CompletedRequestMessage(Player player, TerraGuardian guardian) //Message the companion says when you complete It's request.
        {
            List<string> Mes = new List<string>();
            Mes.Add("You're the best, boss!");
            Mes.Add("Amazing! You really did It!");
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string ReviveMessage(TerraGuardian Guardian, bool IsPlayer, Player RevivePlayer, TerraGuardian ReviveGuardian) //Messages the companion says when reviving someone.
        {
            List<string> Mes = new List<string>();
            if (IsPlayer && RevivePlayer.whoAmI == Guardian.OwnerPos) //If Is the companion owner...
            {
                Mes.Add("Come on boss, stand up!");
                Mes.Add("Master! Master! Can you hear me? Wake up!");
                Mes.Add("Come on! Wake up boss!");
            }
            else
            {
                Mes.Add("I never thought I would be helping someone be revived.");
                Mes.Add("This would be very useful in my world.");
                Mes.Add("You can't fight while lying down.");
                Mes.Add("Am I doing this right?");
                Mes.Add("All this blood... Ugh...");
            }
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        public override string BirthdayMessage(Player player, TerraGuardian guardian)
        {
            List<string> Mes = new List<string>();
            if (!giantsummon.PlayerMod.HasGuardianBeenGifted(player, guardian.ID, guardian.ModID)) //Checks if companion has received a gift.
            {
                Mes.Add("Do you have a gift for me? What could It be?");
            }
            Mes.Add("You guys prepared a birthday party for me? Wow! I liked!");
            Mes.Add("This is my birthday party, so this mean let the fun start!");
            return Mes[Terraria.Main.rand.Next(Mes.Count)];
        }

        /// <summary>
        /// For some extra dialogue lines the companion can say.
        /// Check out on the mod source, at GuardianBase.cs, on the class "MessageIDs", the constants you can use to call a dialogue.
        /// </summary>
        /// <param name="MessageID"></param>
        /// <returns></returns>
        public override string GetSpecialMessage(string MessageID)
        {
            switch (MessageID)
            {
                    //For Leopold's recruitment messages, I recommend you to check out his recruitment messages scripts, at Npcs/LeopoldNPCs.cs. There is a moment where he speaks to the companion leader of your party.
                case MessageIDs.LeopoldMessage1: //This dialogue is attached to Leopold's recruitment. He monologues by himself, and even thinks the player enslaved the TerraGuardians following him. This dialogue appears after he says to himself how he'll rescue them.
                    return "That guy seems a bit glitched out.";
                case MessageIDs.LeopoldMessage2: //Leopold's answer to above. TerraGuardians dialogues are between * because they speak through bond, so whoever has a bond with them, can hear what they say from within.
                    return "*What are you talking about? What is even a glitch?*";
                case MessageIDs.LeopoldMessage3: //Your companion answers Leopold, and finally makes him get It that your character could hear him monologuing all the time.
                    return "You must not really be normal, to think that the Terrarian didn't heard your monologuing.";
                    //End of leopold's recruitment message.
                case MessageIDs.BuddySelected: //This dialogue appears when you pick this companion on Buddy Mode.
                    return "Master! You really picked me! I... I don't even know what to say. You're the best!";
                case MessageIDs.GuardianWokeUpByPlayerMessage: //Appears when you wakes up the companion.
                    return "[nickname], It's too early... Let me sleep some more.";
                case MessageIDs.GuardianWokeUpByPlayerRequestActiveMessage: //The same as above, but only if you have a request active for that companion.
                    return "[nickname], you woke up. Did you do my request?";
                case MessageIDs.AfterAskingCompanionToJoinYourGroupSuccess: //When the companion agrees to join the team, and has a slot for him to join.
                    return "Yes, [nickname]!";
                case MessageIDs.AfterAskingCompanionToJoinYourGroupFullParty: //When the companion agrees to join the team, but has no slot for him on the party.
                    return "But [nickname], there's too many people with you.";
                case MessageIDs.AfterAskingCompanionToJoinYourGroupFail: //When companion doesn't want to follow you on an adventure. Related to friendship level, but Gaomon will never trigger this message.
                    return "Sorry [nickname], but not right now.";
                case MessageIDs.AfterAskingCompanionToLeaveYourGroupAskIfYoureSure: //When you ask the companion to leave the party while away from safe place.
                    return "But [nickname], I want to explore the world with you some more.";
                case MessageIDs.AfterAskingCompanionToLeaveYourGroupYesAnswerDangerousPlace: //When you ask the companion to leave the party while away from safe place.
                    return "[nickname]! Are you sure you want to leave me here? I will have to fight my way back home.";
                case MessageIDs.AfterAskingCompanionToLeaveYourGroupYesAnswer: //When you answer yes after the companion asks if you really will let him leave the party.
                    return "Okay [nickname], If you need me, just call me.";
                case MessageIDs.AfterAskingCompanionToLeaveYourGroupNoAnswer: //When you answer no to the above question.
                    return "Thanks [nickname], I wasn't really wanting to leave the group.";

            }
            return "";
        }
    }
}
