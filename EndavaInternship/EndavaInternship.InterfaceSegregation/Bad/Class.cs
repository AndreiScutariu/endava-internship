using System;
using System.Collections.Generic;

namespace EndavaInternship.InterfaceSegregation.Bad
{
    internal interface IWorker
    {
        void Work();

        void Eat();
    }

    internal class Worker : IWorker
    {
        public void Work()
        {
            // ....working
        }

        public void Eat()
        {
            // ...... eating in launch break
        }
    }

    internal class SuperWorker : IWorker
    {
        public void Work()
        {
            //.... working much more
        }

        public void Eat()
        {
            //.... eating in launch break
        }
    }

    internal class Robot : IWorker
    {
        public void Work()
        {
            //.... working much more
        }

        public void Eat()
        {
            //.... what to do here 
            throw new NotImplementedException();
        }
    }

    internal class WorkManager
    {
        private readonly IEnumerable<IWorker> _workers;

        public WorkManager(IEnumerable<IWorker> workers)
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
        private readonly IEnumerable<IWorker> _workers;

        public LaunchManager(IEnumerable<IWorker> workers)
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