using System.Collections.Generic;
using System.Linq;

namespace EndavaInternship.Liskov.Good
{
    public interface IPersistResource
    {
        void Persist();
    }

    public interface ILoadResource
    {
        void Load();
    }

    public class GoodApplicationSettings : IPersistResource, ILoadResource
    {
        public void Load()
        {
            //stuff
        }

        public void Persist()
        {
            //stuff
        }
    }

    public class GoodUserSettings : IPersistResource, ILoadResource
    {
        public void Load()
        {
            //stuff
        }

        public void Persist()
        {
            //stuff
        }
    }

    public class GoodApplication
    {
        public void Start()
        {
            var res = GoodResourcesRepository.LoadAll();
            //...
            var saveble = res.Select(x => x as IPersistResource);
            GoodResourcesRepository.SaveAll(saveble);
        }
    }

    public static class GoodResourcesRepository
    {
        internal static IEnumerable<ILoadResource> LoadAll()
        {
            var allResources = new List<ILoadResource>
            {
                new GoodUserSettings(),
                new GoodApplicationSettings(),
                new StillNotPersistedSettings()
            };
            allResources.ForEach(r => r.Load());
            return allResources;
        }

        internal static void SaveAll(IEnumerable<IPersistResource> resources)
        {
            resources.ToList().ForEach(r =>
            {
                if (r != null) r.Persist();
            });
        }
    }

    public class StillNotPersistedSettings : ILoadResource
    {
        public void Load()
        {
            //stuff
        }
    }
}