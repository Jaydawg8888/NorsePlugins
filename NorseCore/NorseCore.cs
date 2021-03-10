using BepInEx;
using HarmonyLib;

namespace NorseCore
{
    [BepInPlugin(CoreGlobal.pluginGUID, CoreGlobal.pluginName, CoreGlobal.pluginVersion)]
    [BepInProcess("valheim.exe")]
    public class NorseCore : BaseUnityPlugin
    {
        // Awake is called once when both the game and the plug-in are loaded
        void Awake()
        {
            Logger.LogInfo("Norse Core: Loaded");

            Harmony harmony = new Harmony("mod.norse_core");
            harmony.PatchAll();
        }
    }
}
