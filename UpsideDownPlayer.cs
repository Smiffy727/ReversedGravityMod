using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace ReversedGravityMod
{
	public class UpsideDownplayer : ModPlayer
	{
        public override void PreUpdateMovement()
        {
            // gravControl is activated with Gravitational Potions
            if (player.gravDir == 1 && !player.gravControl)
            {
                player.gravDir = -1;
            }
        }

        public override void PostUpdateBuffs()
        {
            // This needs to be activated to allow the changing of the player's gravity
            player.gravControl2 = true;
        }

        private int timer = 0;
        public override void PreUpdate()
        {
            // Y = 660 is approximately the height of the top of the game world
            if (player.position.Y < 660 & !player.gravControl) 
            {
                player.KillMe(PlayerDeathReason.ByCustomReason(player.name + " fell out of orbit."), 999, 0);
            }
        }
    }
}
