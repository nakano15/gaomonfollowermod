using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using giantsummon;
using Terraria;
using Terraria.ModLoader;

namespace gaomonfollowermod.CompanionNPCs
{
    [AutoloadHead] //Necessary, unless you don't want people to know where your companion is at.
    public class GaomonNPC : giantsummon.GuardianNPC.GuardianNPCPrefab
    {
        public override string HeadTexture //For some reason, town npcs head must be facing left, instead of right.
        {
            get
            {
                return "gaomonfollowermod/CompanionNPCs/Gaomon_Head"; //Necessary
            }
        }

        public override bool Autoload(ref string name)
        {
            name = "BeastDigimon"; //This is the identification of the npc, when this npc spawn, the name will be "Gaomon the Beast Digimon". (The space is automatically added by the mod loader). Try not to give all your companion npcs the same identification name.
            return base.Autoload(ref name);
        }

        public GaomonNPC()
            : base(0, "gaomonfollowermod") //base(ID, ModID) those are the basic identifications of the companion npc. ModID is necessary to be set, or else the mod will try loading TerraGuardians mod companion.
        {

        }
    }
}
