namespace Liuweiqian.Apps.Resume.ProjectExperience
{
    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using NLog;
    using System.ComponentModel.Composition;

    [ModuleExport("ProjectExperienceModule", typeof(ProjectExperienceModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ProjectExperienceModule : IModule
    {
        readonly ILogger logger;
        readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public ProjectExperienceModule(ILogger logger, IRegionViewRegistry regionViewRegistry)
        {
            this.logger = logger;
            this.regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("ProjectExperienceRegion", typeof(Views.ProjectExperienceView));
            logger.Info("ProjectExperienceModule Initialized");
        }
    }
}

