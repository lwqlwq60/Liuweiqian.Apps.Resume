namespace Liuweiqian.Apps.Resume
{
    using Liuweiqian.Apps.Resume.Utils;
    using MahApps.Metro;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.ViewModel;
    using NLog;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;

    /// <summary>
    /// the main viewmodel
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ShellViewModel : NotificationObject
    {
        readonly ILogger logger;
        readonly Core.Services.IResourceService resourceService;
        [ImportingConstructor]
        public ShellViewModel(ILogger logger, Core.Services.IResourceService resourceService)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            if (resourceService == null)
                throw new ArgumentNullException("resourceService");
            this.logger = logger;
            this.resourceService = resourceService;
            this.AccentColors = ThemeManager.Accents
                                    .Select(a => new AccentColorMenuData() { Name = a.Name, ColorBrush = a.Resources["AccentColorBrush"] as Brush })
                                    .ToList();
            ChangeLanguageCommand = new DelegateCommand(ChanngeLanguage);
            OpenAccentCommand = new DelegateCommand(OpenAccent);
            ChangeThemeCommand = new DelegateCommand(DoChangeTheme);
            ShowSourceCodeCommand = new DelegateCommand(ShowSourceCode);
        }
        string currentLanguage;
        bool accentIsOpen = false;
        Theme theme;
        public Theme Theme
        {
            get { return theme; }
            set
            {
                if (this.theme != value)
                {
                    this.theme = value;
                    this.RaisePropertyChanged(() => this.Theme);
                    logger.Info("Theme PropertyChanged:" + Theme);
                }
            }
        }
        public string CurrentLanguage
        {
            get { return currentLanguage; }
            set
            {
                if (this.currentLanguage != value)
                {
                    this.currentLanguage = value;
                    this.RaisePropertyChanged(() => this.CurrentLanguage);
                    logger.Info("CurrentLanguage PropertyChanged:" + CurrentLanguage);
                }
            }
        }
        public bool AccentIsOpen
        {
            get { return accentIsOpen; }
            set
            {
                this.accentIsOpen = value;
                this.RaisePropertyChanged(() => this.AccentIsOpen);
                logger.Info("AccentIsOpen PropertyChanged:" + AccentIsOpen);
            }
        }
        public ICommand ChangeLanguageCommand { get; set; }
        public ICommand OpenAccentCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ShowSourceCodeCommand { get; set; }
        public List<AccentColorMenuData> AccentColors { get; private set; }
        void ChanngeLanguage()
        {
            logger.Info("Do ChangeLanguageCommand:Change To " + CurrentLanguage);
            resourceService.ManualChangeLanaguage(CurrentLanguage);
        }
        void OpenAccent()
        {
            logger.Info("Do OpenAccentCommand");
            AccentIsOpen = true;
        }
        void DoChangeTheme()
        {
            logger.Info("Do ChangeThemeCommand");
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(this.Theme.ToString());
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
        void ShowSourceCode()
        {
            logger.Info("Do ShowSourceCodeCommand");
            string url = resourceService.GetString("GitHubUrl");
            if (Formatter.MatchWebUrl(url))
                Process.Start(url);
        }
    }
    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeAccentCommand;

        public ICommand ChangeAccentCommand
        {
            get { return this.changeAccentCommand ?? (changeAccentCommand = new DelegateCommand(DoChangeTheme)); }
        }
        void DoChangeTheme()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }
    public enum Theme
    {
        BaseLight,
        BaseDark
    }
}
