using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria.ModLoader;
using Terraria;
using giantsummon;

namespace gaomonfollowermod
{
    class NpcMod : GlobalNPC
    {
        public override void GetChat(NPC npc, ref string chat)
        {
            if (Main.rand.Next(2) == 0 && giantsummon.NpcMod.HasGuardianNPC(0, mod.Name))
            {
                switch (npc.type) //A number of examples on how to refference custom companion on npcs dialogues.
                {
                    case Terraria.ID.NPCID.Nurse:
                        chat = "It is a bit tiring having to heal " + giantsummon.NpcMod.GetGuardianNPCName(0, this.mod) + " everytime. He may want to get stronger for you, but he shouldn't work that hard.";
                        break;
                    case Terraria.ID.NPCID.Guide:
                        chat = "I think " + giantsummon.NpcMod.GetGuardianNPCName(0, this.mod) + "'s existence in this world is related to you. Right?";
                        break;
                    case Terraria.ID.NPCID.Merchant:
                        chat = "I never ever heard of those... Discs... " + giantsummon.NpcMod.GetGuardianNPCName(0, this.mod) + " keeps asking for. So I try giving potions instead.";
                        break;
                }
            }
        }

        public override bool PreAI(NPC npc)
        {
            if (npc.type == Terraria.ID.NPCID.BlueSlime && npc.ai[1] == 0)
            {
                int NearestPlayer = npc.FindClosestPlayer();
                if (NearestPlayer > -1 && !giantsummon.NpcMod.HasMetGuardian(0, mod) && !giantsummon.NpcMod.HasGuardianNPC(0, mod) && !PlayerMod.PlayerHasGuardian(Main.player[NearestPlayer], 0, mod.Name) && Main.rand.Next(10) == 0) //Adds a chance of adding a Blue Digivice to a Slime body, so the player can loot It and use to get Gaomon. 
                {
                    npc.ai[1] = ModContent.ItemType<Item.BlueDigivice>();
                    npc.netUpdate = true;
                }
            }
            return base.PreAI(npc);
        }
    }
}
