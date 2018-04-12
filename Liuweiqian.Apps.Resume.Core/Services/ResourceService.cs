namespace Liuweiqian.Apps.Resume.Core.Services
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System;
    using System.Windows;
    using NLog;
    using System.IO;
    using System.Globalization;
    using System.Linq;

    [Export(typeof(IResourceService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ResourceService : IResourceService
    {
        [ImportingConstructor]
        public ResourceService(ILogger logger)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            logger.Info("ResourceService Initialized");
        }
        public IEnumerable<string> SupportLanguages
        {
            get
            {
                var languages = new List<string>();
                foreach (string file in Directory.GetFiles(@"Resources/Languages/"))
                {
                    if (file.Contains("StringResource.") && file.EndsWith(".xaml"))
                        languages.Add(Path.GetFileName(file).Replace("StringResource.", "").Replace(".xaml", ""));
                }
                return languages;
            }
        }

        public void AutoChangeLanguage()
        {
            ManualChangeLanaguage(CultureInfo.CurrentUICulture.Name);
        }

        public string GetString(string key)
        {
            return Application.Current.Resources[key] as string;
        }

        public void ManualChangeLanaguage(string culture)
        {
            var currentDict = Application.Current.Resources.MergedDictionaries[0];
            if (!currentDict.Source.OriginalString.Contains(culture) && SupportLanguages.Contains(culture))
            {
                ResourceDictionary resource = new ResourceDictionary();
                string requestedCulture = string.Format(@"Resources\Languages\StringResource.{0}.xaml", culture);
                resource.Source = new Uri(requestedCulture, UriKind.Relative);
                Application.Current.Resources.MergedDictionaries[0] = resource;
            }
        }
    }
}
