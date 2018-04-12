namespace Liuweiqian.Apps.Resume.ProjectExperience.Views
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed partial class ProjectExperienceView : UserControl
    {
        public ProjectExperienceView()
        {
            this.InitializeComponent();
        }
    }
}
