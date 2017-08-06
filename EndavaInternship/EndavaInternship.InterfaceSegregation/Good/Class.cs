using System.Collections.Generic;

namespace EndavaInternship.InterfaceSegregation.Good
{
    internal interface IWorkable
    {
        void Work();
    }

    internal interface IFeedable
    {
        void Eat();
    }


    internal class Worker : IWorkable, IFeedable
    {
        public void Eat()
        {
            // ...... eating in launch break
        }

        public void Work()
        {
            // ....working
        }
    }

    internal class SuperWorker : IWorkable, IFeedable
    {
        public void Eat()
        {
            //.... eating in launch break
        }

        public void Work()
        {
            //.... working much more
        }
    }

    internal class Robot : IWorkable
    {
        public void Work()
        {
            //.... working much more
        }
    }

    internal class WorkManager
    {
        private readonly IEnumerable<IWorkable> _workers;

        public WorkManager(IEnumerable<IWorkable> workers)
        {
            _workers = workers;
        }

        public void StartWorking()
        {
            foreach (var worker in _workers)
                worker.Work();
        }
    }

    internal class LaunchManager
    {
        private readonly IEnumerable<IFeedable> _workers;

        public LaunchManager(IEnumerable<IFeedable> workers)
        {
            _workers = workers;
        }

        public void StartWorking()
        {
            foreach (var worker in _workers)
                worker.Eat();
        }
    }
}