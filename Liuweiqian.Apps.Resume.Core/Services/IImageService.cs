using System;
namespace Liuweiqian.Apps.Resume.Core.Services
{
    using System.Threading.Tasks;
    using System.Windows.Media.Imaging;
    public interface IImageService
    {
        /// <summary>
        /// 异步读取图片
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns>BitmapImage</returns>
        Task<BitmapImage> ReadImageAsync(string path);
    }
}
