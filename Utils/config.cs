using BepInEx.Configuration;

public static class AutoCloseDoorsConfig
{
    public static ConfigEntry<bool> EnableAutoCloseDoors { get; private set; }
    public static ConfigEntry<float> AutoCloseTimer { get; private set; }
    public static ConfigEntry<bool> AlwaysAutoCloseDoors { get; private set; }

    public static void Init(ConfigFile config)
    {

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

        AlwaysAutoCloseDoors = config.Bind(
            section: "General",
            key: "AlwaysAutoCloseDoors",
            defaultValue: true,
            description: "When this is set to false, doors will not automatically close if castle is decaying, under attack, or being sieged"
        );

    }

}