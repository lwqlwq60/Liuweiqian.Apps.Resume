namespace Liuweiqian.Apps.Resume.Introduce.ViewModels
{
    using Liuweiqian.Apps.Resume.Core.Services;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.ViewModel;
    using System;
    using System.Diagnostics;
    using System.Windows.Input;
    using System.Windows.Media.Imaging;
    using System.Threading.Tasks;
    using Liuweiqian.Apps.Resume.Core.Commands;
    using Liuweiqian.Apps.Resume.Utils;

    public class IntroduceImage : NotificationObject
    {
        readonly IImageService imageService;
        readonly ICommand readImageCommand;
        string path;
        string url;
        BitmapImage source;
        public IntroduceImage(IImageService imageService)
        {
            if (imageService == null)
                throw new ArgumentNullException("imageService");
            this.imageService = imageService;
            this.JumpCommand = new DelegateCommand(JumpToUrl);
            this.readImageCommand = new AsyncCommand(InitImage);
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string Path
        {
            get { return this.path; }
            set
            {
                if (this.path != value)
                {
                    this.path = value;
                    readImageCommand.Execute(null);
                }
            }
        }
        public BitmapImage Source
        {
            get { return source; }
            private set
            {
                if (this.source != value)
                {
                    this.source = value;
                    this.RaisePropertyChanged(() => this.Source);
                }
            }
        }
        /// <summary>
        /// 广告链接
        /// </summary>
        public string Url
        {
            get { return this.url; }
            set
            {
                if (this.url != value)
                {
                    this.url = value;
                    this.RaisePropertyChanged(() => this.Url);
                }
            }
        }
        /// <summary>
        /// 跳转命令
        /// </summary>
        public ICommand JumpCommand { get; set; }
        void JumpToUrl()
        {
            if (Formatter.MatchWebUrl(this.Url))
                Process.Start(this.Url);
        }
        async Task InitImage()
        {
            Source = await imageService.ReadImageAsync(this.Path);
        }
    }
}