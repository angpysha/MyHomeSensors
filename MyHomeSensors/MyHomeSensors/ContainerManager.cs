using System;
using System.Collections.Generic;
using System.Text;
using Prism.Ioc;

namespace MyHomeSensors
{
    public class ContainerManager
    {
        public static ContainerManager Instance { get; set; }
        public IContainerProvider Container { get; private set; }
        public ContainerManager(IContainerProvider containerProvider)
        {
            Container = containerProvider;
            Instance = this;
        }
    }
}
