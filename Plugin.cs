using BepInEx;
using HarmonyLib;
using UnityEngine;
using BepInEx.Unity.IL2CPP;
using VampireCommandFramework;
using ScarletRCON.Shared;
using System.Collections;
using AutoCloseDoors.Systems;

namespace AutoCloseDoors
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInDependency("gg.deca.VampireCommandFramework")]
    [BepInDependency("markvaaz.ScarletRCON", BepInDependency.DependencyFlags.SoftDependency)]

    public class Plugin : BasePlugin
    {
        Harmony _harmony;

        public override void Load()
        {
            LogUtil.Init(Log);

            if (Application.productName != "VRisingServer")
            {
                Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} NOT loaded. This is a server mod only.!");
                return;
            }

            AutoCloseDoorsConfig.Init(Config);

            Log.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} version {MyPluginInfo.PLUGIN_VERSION} is loaded!");

            _harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
            _harmony.PatchAll(System.Reflection.Assembly.GetExecutingAssembly());

            CommandRegistry.RegisterAll();
            RconCommandRegistrar.RegisterAll();
        }

        public override bool Unload()
        {
            CommandRegistry.UnregisterAssembly();
            RconCommandRegistrar.UnregisterAssembly();
            _harmony?.UnpatchSelf();
            return true;
        }

        public void OnGameInitialized()
        {
            Core.InitializeAfterLoaded();
            Core.StartCoroutine(RefreshDoorList());
        }

        public static IEnumerator RefreshDoorList()
        {
            while (true)
            {
                if (AutoCloseDoor.isAutoCloseDoor)
                {
                    AutoCloseDoor.InitializeAutoClose();
                }
                yield return new WaitForSeconds(5f);
            }
        }

    }
}
