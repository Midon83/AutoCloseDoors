using VampireCommandFramework;
using AutoCloseDoors.Systems;

namespace AutoCloseDoors.Commands
{
    [CommandGroup("acd")]
    public static class AutoCloseDoorCommands
	{

        [Command("disable", usage: "", description: "Command to globally disable AutoCloseDoors", adminOnly: true)]
		public static void DisableCommand(ChatCommandContext ctx)
		{
			AutoCloseDoor.isAutoCloseDoor = false;
            AutoCloseDoorsConfig.Save();
            AutoCloseDoor.RevertAutoClose();
            ctx.Reply($"AutoCloseDoor globally disabled");

        }

        [Command("enable", usage: "", description: "Command to globally enable AutoCloseDoors", adminOnly: true)]
        public static void EnableCommand(ChatCommandContext ctx)
        {
            AutoCloseDoor.isAutoCloseDoor = true;
            AutoCloseDoorsConfig.Save();
            AutoCloseDoor.InitializeAutoClose();
            ctx.Reply($"AutoCloseDoor globally enabled");

        }

        [Command("time", usage: "time <seconds>", description: "Set the AutoCloseDoors timer", adminOnly: true)]
        public static void TimeCommand(ChatCommandContext ctx, string time)
        {
            AutoCloseDoor.AutoCloseTimer = float.Parse(time, System.Globalization.CultureInfo.InvariantCulture);
            AutoCloseDoorsConfig.Save();
            AutoCloseDoor.RevertAutoClose();
            AutoCloseDoor.InitializeAutoClose();
            ctx.Reply($"AutoCloseDoor time set");

        }

    }
}
