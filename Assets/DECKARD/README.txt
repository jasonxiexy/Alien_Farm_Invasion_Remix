Since the player is actully the Owlet object(the child object under player that attaches all scripts).
When doing further development, we need to change major amount of scripts to the player object, SO REMINDER: many object assigned 
things on the editor to Owlet should change to player.

Chang player(& Owlet) tag to "player".

If Player object assigned gravaity to it, then the health bar will drop as well, should be PlayerThings->player||UI ->characters