namespace Liuweiqian.Apps.Resume.Education
{
    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using NLog;
    using System.ComponentModel.Composition;

    [ModuleExport("EducationModule", typeof(EducationModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class EducationModule : IModule
    {
        readonly ILogger logger;
        readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public EducationModule(ILogger logger, IRegionViewRegistry regionViewRegistry)
        {
            this.logger = logger;
            this.regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("EducationRegion", typeof(Views.EducationView));
            logger.Info("EducationModule Initialized");
        }
    }
}
