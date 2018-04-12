namespace Liuweiqian.Apps.Resume.Introduce.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;
    using System.Windows;
    using System.Windows.Threading;
    using Liuweiqian.Apps.Resume.Core.Services;
    using Microsoft.Practices.Prism.ViewModel;
    using NLog;

    /// <summary>
    /// Introduce-ViewModel
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IntroduceViewModel : NotificationObject
    {
        DispatcherTimer timer;
        readonly ILogger logger;
        [ImportingConstructor]
        public IntroduceViewModel(ILogger logger, IImageService imageService)
        {
            this.logger = logger;
            IntroduceImageItems = new ObservableCollection<IntroduceImage>
            {
                new IntroduceImage(imageService){ Path = @"./Resources/Images/liuweiqian1.png" },
                new IntroduceImage(imageService){ Path = @"./Resources/Images/liuweiqian2.png" }
            };
            timer = new DispatcherTimer(
            TimeSpan.FromSeconds(5),
            DispatcherPriority.ApplicationIdle,
            DispatcherTimer_Tick,
            Application.Current.Dispatcher);
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Start();
        }
        int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                if (this.selectedIndex != value)
                {
                    this.selectedIndex = value;
                    this.RaisePropertyChanged(() => this.SelectedIndex);
                    logger.Info("FlipView SelectedIndex Property Changed:" + SelectedIndex);
                }
            }
        }
        public ObservableCollection<IntroduceImage> IntroduceImageItems { get; private set; }
        void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            int count = this.IntroduceImageItems.Count;
            if (SelectedIndex == count - 1)
                SelectedIndex = 0;
            else
                SelectedIndex++;
        }
    }
}