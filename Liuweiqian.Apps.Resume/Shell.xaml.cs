namespace Liuweiqian.Apps.Resume
{
    using MahApps.Metro.Controls;
    using NLog;
    using System.ComponentModel.Composition;
    using System;
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    [Export]
    public partial class Shell : MetroWindow
    {
        ILogger logger;
        Core.Services.IResourceService resourceService;
        [ImportingConstructor]
        public Shell(ILogger logger, ShellViewModel viewModel, Core.Services.IResourceService resourceService)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            if (viewModel == null)
                throw new ArgumentNullException("viewModel");
            if (resourceService == null)
                throw new ArgumentNullException("resourceService");
            this.DataContext = viewModel;
            this.logger = logger;
            this.resourceService = resourceService;
            InitializeComponent();
            logger.Info("Shell Initialized");
            resourceService.AutoChangeLanguage();
        }
    }
}
