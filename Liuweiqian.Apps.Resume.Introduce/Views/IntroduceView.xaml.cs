namespace Liuweiqian.Apps.Resume.Introduce.Views
{
    using Liuweiqian.Apps.Resume.Introduce.ViewModels;
    using System.ComponentModel.Composition;
    using System.Windows.Controls;
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class IntroduceView : UserControl
    {
        public IntroduceView()
        {
            this.InitializeComponent();
        }
        [Import]
        IntroduceViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }

    }
}
