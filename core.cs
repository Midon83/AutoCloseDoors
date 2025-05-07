using System.Collections;
using System.Linq;
using AutoCloseDoors.Systems;
using BepInEx.Unity.IL2CPP.Utils.Collections;
using ProjectM.Physics;
using Unity.Entities;
using UnityEngine;

namespace AutoCloseDoors;
internal static class Core
{
    public static World Server { get; } = GetWorld() ?? throw new System.Exception("There is no Server world (yet)");

    public static EntityManager EntityManager { get; } = Server.EntityManager;

    public static bool _hasInitialized = false;

    static MonoBehaviour monoBehaviour;

    internal static void InitializeAfterLoaded()
    {
        if (_hasInitialized) return;

        AutoCloseDoor.isAutoCloseDoor = AutoCloseDoorsConfig.EnableAutoCloseDoors.Value;
        AutoCloseDoor.AutoCloseTimer = AutoCloseDoorsConfig.AutoCloseTimer.Value;

        _hasInitialized = true;
        LogUtil.LogInfo($"{nameof(InitializeAfterLoaded)} completed");
    }

    private static World GetWorld()
    {
        return World.s_AllWorlds.ToArray().FirstOrDefault(world => world.Name == "Server");
    }

    public static Coroutine StartCoroutine(IEnumerator routine)
    {
        if (monoBehaviour == null)
        {
            var go = new GameObject("AutoCloseDoors");
            monoBehaviour = go.AddComponent<IgnorePhysicsDebugSystem>();
            UnityEngine.Object.DontDestroyOnLoad(go);
        }
    
        return monoBehaviour.StartCoroutine(routine.WrapToIl2Cpp());
    }

    public static void StopCoroutine(Coroutine coroutine)
    {
        if (monoBehaviour == null)
        {
            return;
        }

        monoBehaviour.StopCoroutine(coroutine);
    }
}
