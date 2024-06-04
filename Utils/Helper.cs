using ProjectM;
using Unity.Entities;
using Stunlock.Core;
using Bloodstone.API;

namespace AutoCloseDoors.Utils
{
    public static class Helper
    {
        public static PrefabGUID GetPrefabGUID(Entity entity)
        {

            var entityManager = VWorld.Server.EntityManager;
            PrefabGUID guid;

            guid = entityManager.GetComponentData<PrefabGUID>(entity);

            return guid;
        }

        public static string GetPrefabName(PrefabGUID hashCode)
        {
            var entityManager = VWorld.Server.EntityManager;
            var s = VWorld.Server.GetExistingSystemManaged<PrefabCollectionSystem>();
            string name = "Nonexistent";
            if (hashCode.GuidHash == 0)
            {
                return name;
            }
            try
            {
                name = s.PrefabGuidToNameDictionary[hashCode];

            }
            catch
            {
                name = "NoPrefabName";
            }
            return name;
        }
    }
}