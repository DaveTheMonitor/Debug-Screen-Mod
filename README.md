# Debug-Screen-Mod
A mod for Total Miner that adds a Debug Screen. The mod can easily be added to your own mod to display your own values for debugging.

This Debug Screen Mod adds a four debug screens similar to Minecraft's F3 screen, which display information about the targeted block, player, targeted actor, or world, and can be toggled with F4, F5, F6, and F7 respectively.

The source code includes a file named "DebugMod.cs" that contains the methods that the Debug Mod uses, including FriendlyPoint(), FriendlyBox(), DrawDebugHud(), and DrawDebugHudString(). This file can copy/pasted into your own mod for use. There's an additional file "Minimum.cs" that includes the minimum required code to get the Debug Screen working for your own mod.

You can use the Debug Screen for your mod with or without credit to me.

Note: Unfortunately the Consolas font in Total Miner isn't actually monospaced, so the width of boxes might change rapidly.
