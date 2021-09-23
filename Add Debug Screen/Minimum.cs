using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using StudioForge.TotalMiner.API;
using StudioForge.TotalMiner;
using StudioForge.Engine.Core;
using StudioForge.Engine;

namespace DebugScreenMod
{
    public class DebugScreenModPlugin : ITMPlugin
    {
        int debugScreen = 0;
        float debugScale = 0.9f;
        SpriteBatchSafe debugSpriteBatch = CoreGlobals.SpriteBatch;
        SpriteFont debugFont = Globals1.FontConsolas;

        void ITMPlugin.PlayerJoined(ITMPlayer player) { }
        void ITMPlugin.PlayerLeft(ITMPlayer player) { }
        void ITMPlugin.WorldSaved(int version) { }
        void ITMPlugin.Initialize(ITMPluginManager mgr, string path) { }
        void ITMPlugin.InitializeGame(ITMGame game) { }
        void ITMPlugin.UnloadMod() { }

        bool ITMPlugin.HandleInput(ITMPlayer player)
        {
            bool handledInput = HandledDebugInput(player.PlayerIndex);

            // If your mod has input, it can go here.
            // If not, just use return HandleDebugInput(player.PlayerIndex);

            return handledInput;
        }

        bool HandledDebugInput(PlayerIndex playerIndex)
        {
            if (InputManager.IsKeyPressedNew(playerIndex, Keys.F5))
            {
                debugScreen = debugScreen == 1 ? 0 : 1;
                return true;
            }
            return false;
        }

        void ITMPlugin.Draw(ITMPlayer player, ITMPlayer virtualPlayer)
        {
            if (debugScreen > 0)
            {
                debugSpriteBatch.Begin();
                if (debugScreen == 1)
                {
                    string[] debugInfo =
                    {
                        "Add Debug Lines here",
                        $"Include values with string interpolation: {debugScale}",
                    };
                    DebugMod.DrawDebugHud(debugInfo, debugSpriteBatch, debugFont, debugScale);
                }
                if (debugScreen == 2)
                {
                    // Use other values to add other menus.
                }
                debugSpriteBatch.End();
            }
        }

        void ITMPlugin.Update() { }
        void ITMPlugin.Update(ITMPlayer player) { }
    }
}