using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MathMate.Web.Forms;

namespace MathMate.Web.Windsor.Installers
{
    public class FormHandlersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                      .BasedOn(typeof(IFormHandler<,>))
                                      .LifestyleTransient());
        }
    }
}