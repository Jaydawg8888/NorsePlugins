using BepInEx;
using HarmonyLib;

namespace NorseCore
{
    [BepInPlugin(NorseCoreGlobal.pluginGUID, NorseCoreGlobal.pluginName, NorseCoreGlobal.pluginVersion)]
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
