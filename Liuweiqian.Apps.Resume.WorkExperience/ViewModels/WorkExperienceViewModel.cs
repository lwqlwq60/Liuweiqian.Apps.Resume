namespace Liuweiqian.Apps.Resume.WorkExperience.ViewModels
{
    using NLog;
    using System.ComponentModel.Composition;
    using System;
    using System.Windows.Input;
    using Microsoft.Practices.Prism.Commands;
    using Liuweiqian.Apps.Resume.Utils;
    using System.Diagnostics;

    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class WorkExperienceViewModel
    {
        readonly ILogger logger;
        [ImportingConstructor]
        public WorkExperienceViewModel(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            this.logger = logger;
            JumpUrlCommand = new DelegateCommand<string>(JumpUrl);
        }

        public ICommand JumpUrlCommand { get; set; }
        void JumpUrl(string url)
        {
            logger.Info("Do JumpUrlCommand:" + url);
            if (Formatter.MatchWebUrl(url))
                Process.Start(url);
        }
    }
}