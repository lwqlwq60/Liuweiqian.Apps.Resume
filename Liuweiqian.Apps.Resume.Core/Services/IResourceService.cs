namespace Liuweiqian.Apps.Resume.Core.Services
{
    using System.Collections.Generic;

    public interface IResourceService
    {
        /// <summary>
        /// 手动切换语言
        /// </summary>
        void ManualChangeLanaguage(string path);
        /// <summary>
        /// 自动切换语言
        /// </summary>
        void AutoChangeLanguage();
        /// <summary>
        /// 支持的语言
        /// </summary>
        IEnumerable<string> SupportLanguages { get; }
        string GetString(string key);
    }
}
