namespace Liuweiqian.Apps.Resume.Skills
{
    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using NLog;
    using System.ComponentModel.Composition;

    [ModuleExport("SkillsModule", typeof(SkillsModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class SkillsModule : IModule
    {
        readonly ILogger logger;
        readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public SkillsModule(ILogger logger, IRegionViewRegistry regionViewRegistry)
        {
            this.logger = logger;
            this.regionViewRegistry = regionViewRegistry;
        }
        public void Initialize()
        {
            regionViewRegistry.RegisterViewWithRegion("SkillsRegion", typeof(Views.SkillsView));
            logger.Info("SkillsModule Initialized");
        }
    }
}
