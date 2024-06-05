using BepInEx;
using HarmonyLib;
using UnityEngine;
using BepInEx.Unity.IL2CPP;
using VampireCommandFramework;
using AutoCloseDoors.Systems;

namespace AutoCloseDoors
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency("gg.deca.VampireCommandFramework")]

    public class Plugin : BasePlugin
    {
        Harmony _harmony;
        public static bool isInitialized = false;

        public override void Load()
        {

            // Init log
            LogUtil.Init(Log);

            // Only run on server
            if (Application.productName != "VRisingServer")
            {
                Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} NOT loaded. This is a server mod only.!");
                return;
            }

            // Init config file
            AutoCloseDoorsConfig.Init(Config);

            // Mod loaded
            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");

            // Harmony patching
            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());

            // Register all commands in the assembly with VCF
            CommandRegistry.RegisterAll();

        }

        public override bool Unload()
        {
            CommandRegistry.UnregisterAssembly();
            _harmony?.UnpatchSelf();
            return true;
        }

        public void OnGameInitialized()
        {
            if (isInitialized) return;
            AutoCloseDoor.isAutoCloseDoor = AutoCloseDoorsConfig.EnableAutoCloseDoors.Value;
            AutoCloseDoor.AutoCloseTimer = AutoCloseDoorsConfig.AutoCloseTimer.Value;
            isInitialized = true;
        }

    }
}
