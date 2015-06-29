using System.Web.Mvc;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace MathMate.Web.Windsor
{
    public class WindsorConfig
    {
        private static IWindsorContainer container;
        public static void RegisterWindsor()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        public static void Dispose()
        {
            container.Dispose();
        }
    }
}