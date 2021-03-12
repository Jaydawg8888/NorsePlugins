using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using NorseCore;
using System.Reflection;
using static Raven;

namespace NorseNoTutorial
{
    [BepInPlugin("org.bepinex.plugins.norse_no_hugin", "Norse No Hugin", "1.0.0.0")]
    [BepInDependency(NorseCoreGlobal.pluginGUID)]
    public class NorseNoHugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> isEnabled { get; private set; }
        public static NorseLogging LoggerInstance { get; protected set; }
        
        void Awake()
        {
            isEnabled = Config.Bind("General", "Enabled", true, "Enable this mod");

            LoggerInstance = new NorseLogging(Logger);

            if (isEnabled.Value)
            {
                LoggerInstance.CreateConsoleLog("Loaded");
                Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), null);
            }
            else
                LoggerInstance.CreateConsoleLog("Unloaded : Not Enabled");
        }

        [HarmonyPatch(typeof(Raven), "Spawn")]
        public static class Raven_Spawn_Patch
        {
            static bool Prefix(Raven __instance, Raven.RavenText text, bool forceTeleport)
            {
                Player localPlayer = Player.m_localPlayer;

                if (localPlayer == null)
                    return true;

                if (text.m_key.Length > 0 && localPlayer.HaveSeenTutorial(text.m_key) == false)
                {
                    LoggerInstance.CreateConsoleLog(text.m_key);
                    LoggerInstance.CreateConsoleLog(text.m_text);

                    if (text.m_label.Length > 0)
                    {
                        localPlayer.AddKnownText(text.m_label, text.m_text);
                    }

                    localPlayer.SetSeenTutorial(text.m_key);
                }

                return false; // overwrite the default function - As we don't want the Raven to spawn at all.
            }
        }
    }
}
