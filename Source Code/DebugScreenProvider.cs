using StudioForge.TotalMiner.API;

namespace DebugScreenMod
{
    public class DebugScreenPluginProvider : ITMPluginProvider
    {
        public ITMPlugin GetPlugin() => new DebugScreenPlugin();

        public ITMPluginArcade GetPluginArcade() => null;

        public ITMPluginBlocks GetPluginBlocks() => null;

        public ITMPluginGUI GetPluginGUI() => null;

        public ITMPluginNet GetPluginNet() => null;
    }
}
