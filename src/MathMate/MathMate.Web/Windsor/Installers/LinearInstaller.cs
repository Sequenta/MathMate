using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MathMate.Linear;

namespace MathMate.Web.Windsor.Installers
{
    public class LinearInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ILinearEquationSystemSolver>().ImplementedBy<Solver>());
        }
    }
}