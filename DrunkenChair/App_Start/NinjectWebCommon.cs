[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Niklasson.DrunkenChair.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Niklasson.DrunkenChair.App_Start.NinjectWebCommon), "Stop")]


namespace Niklasson.DrunkenChair.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    using Niklasson.EonIV.CharacterGeneration.Contracts;
    using Niklasson.EonIV.CharacterGeneration;
    using Niklasson.EonIV.CharacterGeneration.Service;
    using Niklasson.EonIV.CharacterGeneration.Repository;
    using Niklasson.EonIV.CharacterRepository;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //kernel.Bind<EonIVCharacterGenerationDbContext>().ToSelf().InRequestScope();
                //kernel.Bind<IEonIVCharacterGenerationTables>().ToSelf().InRequestScope();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IEonIVCharacterGenerationService>().To<EonIVCharacterGenerationService>().InRequestScope();
            kernel.Bind<IEonIVCharacterGenerationTables>().To<EonIVCharacterGenerationTables>().InRequestScope();
        }        
    }
}
