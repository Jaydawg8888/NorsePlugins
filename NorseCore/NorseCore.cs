using System;
using BepInEx;
using HarmonyLib;
using NorseCore;

namespace NorseCore
{
    [BepInPlugin(CoreGlobal.pluginGUID, CoreGlobal.pluginName, CoreGlobal.pluginVersion)]
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
