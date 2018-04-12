namespace Liuweiqian.Apps.Resume.Skills.Views
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public sealed partial class SkillsView : UserControl
    {
        public SkillsView()
        {
            this.InitializeComponent();
        }
    }
}
