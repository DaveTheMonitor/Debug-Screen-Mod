using Microsoft.Xna.Framework.Graphics;
using StudioForge.TotalMiner.API;
using StudioForge.TotalMiner;
using StudioForge.Engine.Core;
using StudioForge.Engine;

namespace DebugScreenMod
{
    public class DebugScreenPlugin : ITMPlugin
    {
        bool holdingDebugKey = false;
        int debugScreen = 0;
        float debugScale = 0.9f;
        SpriteBatchSafe debugSpriteBatch = new SpriteBatchSafe(CoreGlobals.GraphicsDevice);
        SpriteFont debugFont = Globals1.FontConsolas;

        void ITMPlugin.PlayerJoined(ITMPlayer player) { }
        void ITMPlugin.PlayerLeft(ITMPlayer player) { }
        void ITMPlugin.WorldSaved(int version) { }
        void ITMPlugin.Initialize(ITMPluginManager mgr, string path) { }
        void ITMPlugin.InitializeGame(ITMGame game) { }
        void ITMPlugin.UnloadMod() { }

        bool ITMPlugin.HandleInput(ITMPlayer player)
        {
            bool handledInput = false;
            if (InputManager.IsKeyPressed(player.PlayerIndex, Microsoft.Xna.Framework.Input.Keys.F5))
            {
                if (!holdingDebugKey) debugScreen = debugScreen == 1 ? 0 : 1;
                holdingDebugKey = true;
                handledInput = true;
            }
            else holdingDebugKey = false;
            return handledInput;
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