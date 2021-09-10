# Gaomon Companion Mod
A custom companion example for TerraGuardians mod.

When spriting a Custom Companion like this one, you need to take note of the following body parts It will need.<br>
body.png //Is the sprite of the body of the companion, includding the head.<br>
left_arm.png //The main arm the companion uses, which is currently the right arm. The Left Arm is displayed on front of the body.
right_arm.png //The off hand arm the companion uses, which is drawn behind the body.<br>
body_front.png //Optional - Used when part of the companion body needs to be drawn in front of the player body. The most evident example is when your character shares the mount with your companion. To avoid filling the mod with an animation with several empty frames, I recommend you to set "SpecificBodyFrontFramePositions" variable to true, then add a "BodyFrontFrameSwap" to swap a specific frame, to the one the body front sprite without the empty frames.<br>
head.png //Necessary, is the head sprite used for many hud features, like the companion health and mana hud, and their inventory head.<br>
right_arm_front.png //Optional - Works partially like the body_front.png, but doesn't needs a flag to mask It, since It's always active. Use "RightArmFrontFrameSwap" to add frames to swap for.

You can add as many companions you want on the mod, just be sure to create a new class for each, extending GuardianBase for the companions.

Do notice, that each custom companion needs to be placed inside Creatures/[CompanionName] folder, that is necessary for loading their sprites, and also necessary for loading Terrarian companions.

In case you want the player only to get the companion, use giantsummon.PlayerMod.AddPlayerGuardian(Player player, int ID, string ModID) to add the companion to the player. Be sure to fill ModID either with the Mod object of your mod, or with the name of your mod, or else It will think that It's to load vanilla mod companion (TerraGuardians mod companion).

Please don't make sloppy companions, give them lore and dialogues, to make them more interesting to have around. Remember that they can also end up being town npcs.

Mod Guide:
Creatures/Gaomon - Contains the sprites and scripts of the custom companion.<br>
CompanionNPCs/ - Contains the companion npc script and It's head. If you want to have that companion <br>
MainMod.cs - Contains the script that adds Gaomon as a possible initial guardian, aswell as the script adding the custom Digimon group, and the custom GuardianDB to TerraGuardians mod. Also contains the GuardianDB of the mod.<br>
NpcMod.cs - Contains a few chat scripts for npcs to make refferences about Gaomon, and adds the chance of adding the Blue Digivice to the body of a spawning Slime.<br>
Item/ - Contains the item and sprite of the Blue Digivice. The item itself checks if Gaomon haven't been met, acquired by the player, or has the npc in the world before using It. When used, will spawn Gaomon NPC on the player position.<br>
SpriteModels/ - Contains furniture sprites you may find useful, for when creating a custom companion. <br>
build.txt - Mod definitions. modReference is necessary to make this mod work.
