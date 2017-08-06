using System;
using System.Collections.Generic;
using System.Linq;

namespace EndavaInternship.Liskov.Bad
{
    namespace Liskov.Bad
    {
        public interface IPersistedResource
        {
            void Load();

            void Persist();
        }

        public class ApplicationSettings : IPersistedResource
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

        public class UserSettings : IPersistedResource
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

        public class Application
        {
            public void Start()
            {
                var res = ResourcesRepository.LoadAll();
                //...
                ResourcesRepository.SaveAll(res);
            }
        }

        public static class ResourcesRepository
        {
            internal static IEnumerable<IPersistedResource> LoadAll()
            {
                var allResources = new List<IPersistedResource>
                {
                    new UserSettings(),
                    new ApplicationSettings(),
                    new NotPersistedSettings()
                };
                allResources.ForEach(r => r.Load());
                return allResources;
            }

            internal static void SaveAll(IEnumerable<IPersistedResource> resources)
            {
                resources.ToList().ForEach(r => r.Persist());
            }
        }

        public class NotPersistedSettings : IPersistedResource
        {
            public void Load()
            {
                //stuff
            }

            public void Persist()
            {
                throw new NotImplementedException();
            }
        }
    }
}