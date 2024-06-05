using Bloodstone.API;
using ProjectM;
using ProjectM.CastleBuilding;
using Unity.Collections;
using Unity.Entities;

namespace AutoCloseDoors.Systems
{
    public static class AutoCloseDoor
    {
        public static bool isAutoCloseDoor = false;
        public static float AutoCloseTimer = 2.0f;

        public static EntityManager em = VWorld.Server.EntityManager;

        public static void DoorReceiver(Entity entity, EntityManager em)
        {
            if (em.HasComponent<Door>(entity) && em.HasComponent<CastleHeartConnection>(entity))
            {
                var Door = em.GetComponentData<Door>(entity);
                if (isAutoCloseDoor)
                {
                    Door.AutoCloseTime = AutoCloseTimer;
                    em.SetComponentData(entity, Door);
                }
            }
        }

        public static void RevertAutoClose()
        {
            var DoorQuery = em.CreateEntityQuery(new EntityQueryDesc()
            {
                All = new ComponentType[] {
                            ComponentType.ReadOnly<Door>(),
                        },
                Options = EntityQueryOptions.IncludeDisabled
            });

            var DoorEntities = DoorQuery.ToEntityArray(Allocator.Temp);
            if (DoorEntities.Length <= 0)
            {         
                return;
            }
            foreach (var entity in DoorEntities)
            {
                var Door = em.GetComponentData<Door>(entity);
                Door.AutoCloseTime = 0;
                em.SetComponentData(entity, Door);
            }
        }

        public static void InitializeAutoClose()
        {
            if (isAutoCloseDoor)
            {
                var DoorQuery = em.CreateEntityQuery(new EntityQueryDesc()
                {
                    All = new ComponentType[] {
                            ComponentType.ReadOnly<Door>(),
                        },
                    Options = EntityQueryOptions.IncludeDisabled
                });

                var DoorEntities = DoorQuery.ToEntityArray(Allocator.Temp);
                if (DoorEntities.Length <= 0)
                {
                    return;
                }
                foreach (var entity in DoorEntities)
                {
                    var Door = em.GetComponentData<Door>(entity);
                    Door.AutoCloseTime = AutoCloseTimer;
                    em.SetComponentData(entity, Door);
                }
            }
        }
    }
}
