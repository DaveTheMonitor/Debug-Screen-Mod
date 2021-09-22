using Microsoft.Xna.Framework.Graphics;
using StudioForge.TotalMiner.API;
using StudioForge.TotalMiner;
using StudioForge.Engine.Core;
using StudioForge.Engine;
using StudioForge.BlockWorld;

namespace DebugScreenMod
{
    public class DebugScreenPlugin : ITMPlugin
    {
        bool holdingDebugKey = false;
        int debugScreen = 0;
        float debugScale = 0.9f;
        char separatorChar = '|';
        SpriteBatchSafe debugSpriteBatch = CoreGlobals.SpriteBatch;
        SpriteFont debugFont = Globals1.FontConsolas;
        ITMGame game;
        ITMWorld world;
        ITMMap map;
        SaveMapHead header;
        void ITMPlugin.PlayerJoined(ITMPlayer player) { }
        void ITMPlugin.PlayerLeft(ITMPlayer player) { }
        void ITMPlugin.WorldSaved(int version)
        {
            header = world.Header;
        }
        void ITMPlugin.Initialize(ITMPluginManager mgr, string path) { }
        void ITMPlugin.InitializeGame(ITMGame game)
        {
            this.game = game;
            world = game.World;
            map = world.Map;
            header = world.Header;
        }
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
            else if (InputManager.IsKeyPressed(player.PlayerIndex, Microsoft.Xna.Framework.Input.Keys.F6))
            {
                if (!holdingDebugKey) debugScreen = debugScreen == 2 ? 0 : 2;
                holdingDebugKey = true;
                handledInput = true;
            }
            else if (InputManager.IsKeyPressed(player.PlayerIndex, Microsoft.Xna.Framework.Input.Keys.F7))
            {
                if (!holdingDebugKey) debugScreen = debugScreen == 3 ? 0 : 3;
                holdingDebugKey = true;
                handledInput = true;
            }
            else if (InputManager.IsKeyPressed(player.PlayerIndex, Microsoft.Xna.Framework.Input.Keys.F4))
            {
                if (!holdingDebugKey) debugScreen = debugScreen == 4 ? 0 : 4;
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
                        $"Player Index: {player.PlayerIndex}",
                        $"Position: {DebugMod.FriendlyPoint(player.Position, 3)}",
                        $"Eye Offset: {DebugMod.FriendlyPoint(player.EyeOffset)} {separatorChar} Eye Position: {DebugMod.FriendlyPoint(player.EyePosition, 3)}",
                        $"Velocity: {DebugMod.FriendlyPoint(player.Velocity, 3)}",
                        $"View Direction: {DebugMod.FriendlyPoint(player.ViewDirection, 4)}",
                        $"Swing Face: {player.SwingFace} {separatorChar} Swing Face Position: {player.SwingFacePos}",
                        $"Swing Target Distance: {DebugMod.ToFixed(player.SwingTargetDistance, 3)}",
                        $"Place Target: {DebugMod.FriendlyPoint(player.PlaceTarget)}",
                        $"Reach: {player.Reach}",
                        $"Max Health: {player.MaxHealth} {separatorChar} Health: {DebugMod.ToFixed(player.Health, 3)}",
                        $"Oxygen: {DebugMod.ToFixed(player.Oxygen, 3)}",
                        $"Name: {player.Name} {separatorChar} Clan: {player.ClanName}",
                        $"Fly Mode: {player.FlyMode} {separatorChar} Is On Ground: {player.IsOnGround}",
                        $"Collision Box: [{DebugMod.FriendlyBox(player.Box, 3)}]",
                        $"Actor Type: {player.ActorType}",
                        $"State: {player.ActorState}"
                    };
                    DebugMod.DrawDebugHud(debugInfo, debugSpriteBatch, debugFont, debugScale);
                }
                else if (debugScreen == 2)
                {
                    ITMActor actor = player.ActorInReticle;
                    if (actor != null)
                    {
                        string[] debugInfo =
                        {
                            $"Position: {DebugMod.FriendlyPoint(actor.Position, 3)}",
                            $"Eye Offset: {DebugMod.FriendlyPoint(actor.EyeOffset)} {separatorChar} Eye Position: {DebugMod.FriendlyPoint(actor.EyePosition, 3)}",
                            $"Velocity: {DebugMod.FriendlyPoint(actor.Velocity, 3)}",
                            $"View Direction: {DebugMod.FriendlyPoint(actor.ViewDirection, 4)}",
                            $"Reach: {actor.Reach}",
                            $"Max Health: {actor.MaxHealth} {separatorChar} Health: {DebugMod.ToFixed(actor.Health, 3)}",
                            $"Oxygen: {DebugMod.ToFixed(actor.Oxygen, 3)}",
                            $"Fly Mode: {actor.FlyMode} {separatorChar} Is On Ground: {actor.IsOnGround}",
                            $"Collision Box: [{DebugMod.FriendlyBox(actor.Box, 3)}]",
                            $"Actor Type: {actor.ActorType}",
                            $"State: {actor.ActorState}"
                        };
                        DebugMod.DrawDebugHud(debugInfo, debugSpriteBatch, debugFont, debugScale);
                    }
                    else DebugMod.DrawDebugHudString("No Target Actor", 0, debugSpriteBatch, debugFont, debugScale);
                }
                else if (debugScreen == 3)
                {
                    string[] debugInfo =
                    {
                        $"Map Name: {header.MapName} {separatorChar} Game Version: {header.SaveVersion}",
                        $"Seed: {header.MapSeed}",
                        $"World Attribute: {header.Attribute}",
                        $"World Biome: {world.CurrentBiome}",
                        $"Mode: {header.GameMode} {separatorChar} Difficulty: {header.GameDifficulty}",
                        $"Combat: {header.CombatEnabled} {separatorChar} PvP: {header.PvPCombat}",
                        $"Passive Mobs: {header.PassiveMobs} {separatorChar} Hostile Mobs: {header.EnemyMobs}",
                        $"Finite Resources: {world.IsFiniteResources}",
                        $"Skills Type: {(world.IsLocalSkills ? "Local" : "Global")} {separatorChar} Skills Enabled: {world.IsSkillsEnabled}",
                        $"Skills XP Multiplier: {header.XPMultiplier}",
                        $"World Path: {world.WorldPath}",
                        $"Texture Pack: {game.TexturePack.Name}"
                    };
                    DebugMod.DrawDebugHud(debugInfo, debugSpriteBatch, debugFont, debugScale);
                }
                else if (debugScreen == 4)
                {
                    GlobalPoint3D blockPoint = player.SwingTarget;
                    Block blockId = map.GetBlockID(blockPoint);
                    if (blockId != Block.zLastBlockID)
                    {
                        ITMInventory blockInventory = map.GetBlockInventory(blockPoint, player.GamerID, true);
                        Map map2 = (Map)map;
                        MapChunk chunk = map2.GetChunk(blockPoint);
                        string[] debugInfo =
                        {
                            $"Target Block: {blockId} {separatorChar} Position: {DebugMod.FriendlyPoint(blockPoint)}",
                            $"Low Aux: {map.GetAuxData(blockPoint)} {separatorChar} High Aux: {map.GetAuxHighData(blockPoint)}",
                            $"Light: {map.GetBlockLight(blockPoint)} {separatorChar} Normalized Light: {map.GetBlockLightNormalized(blockPoint)}",
                            $"Can See Sky: {map.CanBlockSeeTheSky(blockPoint)}",
                            $"Has Changed: {map.HasChanged(blockPoint)}",
                            $"Block Box: [{DebugMod.FriendlyBox(world.GetBlockBox(blockPoint, blockId), 4)}]",
                            $"{(blockInventory != null ? $"Inventory Used: {blockInventory.Items.Count}/{blockInventory.TotalSize}" : "No Inventory")}",
                            $"Chunk Global Offset: {DebugMod.FriendlyPoint(chunk.GlobalOffset)} {separatorChar} Chunk Offset: {DebugMod.FriendlyPoint(chunk.Offset)}"
                        };
                        DebugMod.DrawDebugHud(debugInfo, debugSpriteBatch, debugFont, debugScale);
                    }
                    else DebugMod.DrawDebugHudString("No Target Block (zLastBlockID)", 0, debugSpriteBatch, debugFont, debugScale);
                }
                debugSpriteBatch.End();
            }
        }
        void ITMPlugin.Update() { }
        void ITMPlugin.Update(ITMPlayer player) { }
    }
}
