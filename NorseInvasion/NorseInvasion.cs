using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using HarmonyLib.Tools;
using NorseCore;
using UnityEngine;

namespace NorseInvasion
{
    [BepInPlugin("org.bepinex.plugins.norse_invasion", "Norse Invasion", "1.0.0.0")]
    [BepInDependency(CoreGlobal.pluginGUID)]
    public class NorseInvasion : BaseUnityPlugin
    {
        public static ManualLogSource manualLogSource;
        public static NorseLogging NorseLogging = new NorseLogging(manualLogSource);

        // Awake is called once when both the game and the plug-in are loaded
        void Awake()
        {
            Configuration.bEnabled = Config.Bind("General", "Enabled", true, "Enable this mod");

            manualLogSource = Logger;

            if (!Configuration.bEnabled.Value)
            {
                Logger.LogInfo("Norse Invasion: Unloaded | Reason: Not enabled");
                return;
            }

            NorseLogging.CreateConsoleLog("Hello World!", NorseLogging.LogType.Info);
            NorseLogging.CreateConsoleLog("Hello World!", NorseLogging.LogType.Debug);
            NorseLogging.CreateConsoleLog("Hello World!", NorseLogging.LogType.Warning);
            NorseLogging.CreateConsoleLog("Hello World!", NorseLogging.LogType.Error);
            NorseLogging.CreateConsoleLog("Hello World!", NorseLogging.LogType.Fatal);

            Logger.LogInfo("Norse Invasion: Loaded");

            Harmony harmony = new Harmony("org.bepinex.plugins.norse_invasion");
            harmony.PatchAll();
        }
    }
}
