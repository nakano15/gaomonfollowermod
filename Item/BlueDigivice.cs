using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria.ModLoader;
using Terraria;
using giantsummon;

namespace gaomonfollowermod.Item
{
    public class BlueDigivice : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Seems to invoke something.");
        }

        private bool UseItem
        {
            get { return !PlayerMod.PlayerHasGuardian(player, 0, this.mod) && !giantsummon.NpcMod.HasGuardianNPC(0, this.mod) && !giantsummon.NpcMod.HasMetGuardian(0, this.mod); }
        }

        public override bool CanUseItem(Terraria.Player player)
        {
            if (UseItem)
            {
                int npcPos = NPC.NewNPC((int)player.Center.X, (int)player.position.Y, ModContent.NPCType<CompanionNPCs.GaomonNPC>());
                if (npcPos < 200)
                {
                    NPC npc = Main.npc[npcPos];
                    for (int d = 0; d < 20; d++)
                    {
                        Dust.NewDust(npc.position, npc.width, npc.height, Terraria.ID.DustID.Electric);
                    }
                }
                return true;
            }
            Main.NewText("You already have a Gaomon.");
            return false;
        }

        public override bool ConsumeItem(Player player)
        {
            return UseItem;
        }

        public override void SetDefaults()
        {
            item.UseSound = Terraria.ID.SoundID.Item3;
            item.useStyle = 2;
            item.useTurn = true;
            item.useAnimation = 5;
            item.useTime = 5;
            item.maxStack = 1;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 1);
            item.width = 22;
            item.height = 22;
        }
    }
}
