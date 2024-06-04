using VampireCommandFramework;
using AutoCloseDoors.Systems;

namespace AutoCloseDoors.Commands
{
    [CommandGroup("acd")]
    public static class AutoCloseDoorCommands
	{

		[Command("disable", usage: "", description: "Command to globally disable AutoCloseDoors", adminOnly: true)]
		public static void DisableCommand(ChatCommandContext ctx, string name = "null", string channal = "all", int bantime = 60)
		{
			AutoCloseDoor.isAutoCloseDoor = false;
			AutoCloseDoor.RevertAutoClose();
            ctx.Reply($"AutoCloseDoor globally disabled");

        }

        [Command("enable", usage: "", description: "Command to globally enable AutoCloseDoors", adminOnly: true)]
        public static void EnableCommand(ChatCommandContext ctx, string name = "null", string channal = "all", int bantime = 60)
        {
            AutoCloseDoor.isAutoCloseDoor = true;
            AutoCloseDoor.InitializeAutoClose();
            ctx.Reply($"AutoCloseDoor globally enabled");

        }

    }
}
