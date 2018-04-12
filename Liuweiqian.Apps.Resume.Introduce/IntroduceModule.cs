namespace Liuweiqian.Apps.Resume.Introduce
{
    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using NLog;
    using System.ComponentModel.Composition;

    [ModuleExport("IntroduceModule", typeof(IntroduceModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class IntroduceModule : IModule
    {
        readonly ILogger logger;
        readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public IntroduceModule(ILogger logger, IRegionViewRegistry regionViewRegistry)
        {
            this.logger = logger;
            this.regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("IntroduceRegion", typeof(Views.IntroduceView));
            logger.Info("IntroduceModule Initialized");
        }
    }
}