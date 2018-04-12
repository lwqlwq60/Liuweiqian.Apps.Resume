namespace Liuweiqian.Apps.Resume.WorkExperience
{
    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using NLog;
    using System.ComponentModel.Composition;

    [ModuleExport("WorkExperienceModule", typeof(WorkExperienceModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class WorkExperienceModule : IModule
    {
        readonly ILogger logger;
        readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public WorkExperienceModule(ILogger logger, IRegionViewRegistry regionViewRegistry)
        {
            this.logger = logger;
            this.regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("WorkExperienceRegion", typeof(Views.WorkExperienceView));
            logger.Info("WorkExperienceModule Initialized");
        }
    }
}
