using VampireCommandFramework;
using ScarletRCON.Shared;

namespace AutoCloseDoors.Commands
{
    [CommandGroup("acd")]
    public static class AutoCloseDoorCommands
    {

        [Command("disable", usage: "", description: "Command to globally disable AutoCloseDoors", adminOnly: true)]
        public static void DisableCommand(ChatCommandContext ctx)
        {
            Helper.DisableMod();
            ctx.Reply($"AutoCloseDoor globally disabled");

        }

        [Command("enable", usage: "", description: "Command to globally enable AutoCloseDoors", adminOnly: true)]
        public static void EnableCommand(ChatCommandContext ctx)
        {
            Helper.EnableMod();
            ctx.Reply($"AutoCloseDoor globally enabled");

        }

        [Command("time", usage: "time <seconds>", description: "Set the AutoCloseDoors timer", adminOnly: true)]
        public static void TimeCommand(ChatCommandContext ctx, string time)
        {
            float newtime;
            if (float.TryParse(time, out newtime))
            {
                Helper.SetModTimer(newtime);
                ctx.Reply($"AutoCloseDoor time set");
            }
            else
            {
                ctx.Reply($"Invalid timer format, please use int or float");
            }
        }
    }

    [RconCommandCategory("AutoCloseDoors")]
    public class AutoCloseDoorRconCommands
    {
        [RconCommand("disable", "Disable AutoCloseDoors.")]
        public static string DisableCommand()
        {
            Helper.DisableMod();
            return "AutoCloseDoors disabled";
        }

        [RconCommand("enable", "Enable AutoCloseDoors.")]
        public static string EnableCommand()
        {
            Helper.EnableMod();
            return "AutoCloseDoors enabled";
        }

        [RconCommand("time", "Set the AutoCloseDoors timer in seconds.")]
        public static string TimeCommand(string time)
        {
            float newtime;
            if (float.TryParse(time, out newtime))
            {
                Helper.SetModTimer(newtime);
                return "AutoCloseDoor time set";
            } else
            {
                return "Invalid timer format, please use int or float";
            }
        }
    }

}
