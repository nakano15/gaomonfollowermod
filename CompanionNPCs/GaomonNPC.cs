using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using giantsummon;
using Terraria;
using Terraria.ModLoader;

namespace gaomonfollowermod.CompanionNPCs
{
    [AutoloadHead]
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
            name = "BeastDigimon";
            return base.Autoload(ref name);
        }

        public GaomonNPC()
            : base(0, "gaomonfollowermod")
        {

        }
    }
}
