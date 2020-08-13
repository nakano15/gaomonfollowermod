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

        private bool UseItem(Player player)
        {
            return player.whoAmI == Main.myPlayer && !PlayerMod.PlayerHasGuardian(player, 0, this.mod) && !giantsummon.NpcMod.HasGuardianNPC(0, this.mod) && !giantsummon.NpcMod.HasMetGuardian(0, this.mod);
        }

        public override bool CanUseItem(Player player)
        {
            if (UseItem(player))
            {
                //This script makes so the item spawns Gaomon on the player position.
                TerraGuardian tg = giantsummon.NpcMod.SpawnGuardianNPC((int)player.Center.X, (int)player.position.Y, MainMod.GaomonID, mod.Name, true);
                // int npcPos = NPC.NewNPC((int)player.Center.X, (int)player.position.Y, ModContent.NPCType<CompanionNPCs.GaomonNPC>());
                for (int d = 0; d < 20; d++)
                {
                    Dust.NewDust(tg.TopLeftPosition, tg.Width, tg.Height, Terraria.ID.DustID.Electric);
                }
                Main.NewText("After using It, the Digivice broke, and a creature came out.");
                item.SetDefaults(0);
                return true;
            }
            Main.NewText("There is already a Gaomon.");
            return false;
        }

        public override void SetDefaults()
        {
            item.UseSound = Terraria.ID.SoundID.Item4;
            item.useStyle = 4;
            item.useTurn = false;
            item.useAnimation = 5;
            item.useTime = 5;
            item.maxStack = 1;
            item.consumable = true;
            item.value = Terraria.Item.buyPrice(0, 1);
            item.width = 22;
            item.height = 22;
            item.rare = 2;
            item.value = 1;
        }
    }
}
