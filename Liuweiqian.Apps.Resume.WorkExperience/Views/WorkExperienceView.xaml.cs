namespace Liuweiqian.Apps.Resume.WorkExperience.Views
{
    using Liuweiqian.Apps.Resume.WorkExperience.ViewModels;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed partial class WorkExperienceView : UserControl
    {
        public WorkExperienceView()
        {
            this.InitializeComponent();
        }
        [Import]
        WorkExperienceViewModel viewModel
        {
            set { this.DataContext = value; }
        }
    }
}
