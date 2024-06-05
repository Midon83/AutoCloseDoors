using AutoCloseDoors.Systems;
using BepInEx.Configuration;

public static class AutoCloseDoorsConfig
{
    public static ConfigFile Config;
    public static ConfigEntry<bool> EnableAutoCloseDoors { get; private set; }
    public static ConfigEntry<float> AutoCloseTimer { get; private set; }

    public static void Init(ConfigFile config)
    {
        Config = config;

        EnableAutoCloseDoors = config.Bind(
            section: "General",
            key: "EnableAutoCloseDoors",
            defaultValue: true,
            description: "Enable AutoCloseDoors"
        );

        AutoCloseTimer = config.Bind(
            section: "General",
            key: "AutoCloseTimer",
            defaultValue: 2.0f,
            description: "How many second(s) to wait before door is automatically closed"
        );

    }

    public static void Save()
    {
        EnableAutoCloseDoors.Value = AutoCloseDoor.isAutoCloseDoor;
        AutoCloseTimer.Value = AutoCloseDoor.AutoCloseTimer;
        Config.Save();
    }

}