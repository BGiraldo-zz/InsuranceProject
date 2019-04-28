using System;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(Insurance.MVC.App_Start.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(Insurance.MVC.App_Start.WindsorActivator), "Shutdown")]

namespace Insurance.MVC.App_Start
{
    public static class WindsorActivator
    {
        static ContainerBootstrapper bootstrapper;

        public static void PreStart()
        {
            bootstrapper = ContainerBootstrapper.Bootstrap();
        }
        
        public static void Shutdown()
        {
            if (bootstrapper != null)
                bootstrapper.Dispose();
        }
    }
}