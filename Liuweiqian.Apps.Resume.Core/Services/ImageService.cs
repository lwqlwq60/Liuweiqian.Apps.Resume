namespace Liuweiqian.Apps.Resume.Core.Services
{
    using System;
    using System.ComponentModel.Composition;
    using System.Threading.Tasks;
    using System.Windows.Media.Imaging;
    using Liuweiqian.IO;
    using System.IO;
    using NLog;

    [Export(typeof(IImageService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ImageService : IImageService
    {
        readonly ILogger logger;
        [ImportingConstructor]
        public ImageService(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            this.logger = logger;
            logger.Info("ImageService Initialized");
        }

        public async Task<BitmapImage> ReadImageAsync(string path)
        {
            logger.Info("Do ReadImageAsync:" + path);
            using (AsyncFileStream afs = new AsyncFileStream(path, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[afs.Length];
                await afs.ReadAsync(buffer, 0, (int)afs.Length); // 图片不能超过4G
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(buffer);
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}
