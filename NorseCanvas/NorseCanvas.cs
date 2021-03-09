using System;
using System.Reflection;
using BepInEx;
using HarmonyLib;
using NorseCore;
using UnityEngine;

namespace NorseCanvas
{
    [BepInPlugin("org.bepinex.plugins.norse_canvas", "Norse Canvas", "1.0.0.0")]
    [BepInDependency(CoreGlobal.pluginGUID)]
    public class NorseCanvas : BaseUnityPlugin
    {
        // Awake is called once when both the game and the plug-in are loaded
        void Awake()
        {
            Logger.LogInfo("Norse Canvas: Loaded");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
        }
    }
}
