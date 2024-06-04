using HarmonyLib;
using Unity.Collections;
using AutoCloseDoors.Systems;
using ProjectM.Gameplay.Systems;

namespace AutoCloseDoors.Hooks
{
    [HarmonyPatch(typeof(OpenDoorSystem), nameof(OpenDoorSystem.OnUpdate))]
    public class OpenDoorSystem_Patch
    {
        private static void Prefix(OpenDoorSystem __instance)
        {
            if (AutoCloseDoor.isAutoCloseDoor)
            {

                var entities = __instance.__query_1834203323_0.ToEntityArray(Allocator.Temp);
                foreach (var entity in entities)
                {
                    AutoCloseDoor.DoorReceiver(entity, __instance.EntityManager);
                }
                
            }
        }
    }
}
