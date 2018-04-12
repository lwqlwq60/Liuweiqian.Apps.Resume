namespace Liuweiqian.Apps.Resume.Education.Views
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed partial class EducationView : UserControl
    {
        public EducationView()
        {
            this.InitializeComponent();
        }
    }
}
