using AutoCloseDoors.Systems;
using HarmonyLib;
using ProjectM;

namespace AutoCloseDoors.Hooks
{
    [HarmonyPatch(typeof(SettingsManager), nameof(SettingsManager.VerifyServerGameSettings))]
    public class ServerGameSetting_Patch
    {
        private static bool isInitialized = false;
        public static void Postfix()
        {
            if (isInitialized == false)
            {
                // Remove Autoclose first, so config on Linux/wine comes into effect, otherwise it just keeps the last state (enabled/disabled)
                AutoCloseDoor.RevertAutoClose();
                if (AutoCloseDoor.isAutoCloseDoor)
                {
                    AutoCloseDoor.InitializeAutoClose();
                }
                isInitialized = true;
            }
        }
    }
}
