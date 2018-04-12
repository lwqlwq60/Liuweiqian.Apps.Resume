namespace Liuweiqian.Apps.Resume
{
    using System.ComponentModel.Composition;
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;
    using Liuweiqian.Apps.Resume.Core.Services;
    using Microsoft.Practices.Prism.Logging;
    using Microsoft.Practices.Prism.MefExtensions;
    using NLog;

    public class AppClientBootstrapper : MefBootstrapper
    {
        readonly NLogService logger = new NLogService();
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<Shell>();
        }
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Shell)this.Shell;
            Application.Current.MainWindow.Show();
        }
        protected override ILoggerFacade CreateLogger()
        {
            return this.logger;
        }
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AppClientBootstrapper).Assembly));
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.ComposeExportedValue<ILogger>(this.logger);
            logger.Info("NLogService Initialized");
        }
    }
}
