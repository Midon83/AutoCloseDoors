using AutoCloseDoors.Systems;

namespace AutoCloseDoors
{
    internal static class Helper
    {
        public static void EnableMod()
        {
            AutoCloseDoor.isAutoCloseDoor = true;
            AutoCloseDoorsConfig.Save();
        }

        public static void DisableMod()
        {
            AutoCloseDoor.isAutoCloseDoor = false;
            AutoCloseDoorsConfig.Save();
            AutoCloseDoor.RevertAutoClose();
        }

        public static void SetModTimer(float time)
        {
            AutoCloseDoor.AutoCloseTimer = time;
            AutoCloseDoorsConfig.Save();
            AutoCloseDoor.RevertAutoClose();
            AutoCloseDoor.InitializeAutoClose();
        }
    }
}
