using Windows.UI.Xaml.Controls;

using jcRSS.WindowsUniversal.ViewModels;

namespace jcRSS.WindowsUniversal.Views {
    public partial class ManageFeedsPage : Page {
        private ManageFeedsModel viewModel {
            get { return (ManageFeedsModel) DataContext; }
        }

        public ManageFeedsPage() {
            this.InitializeComponent();

            DataContext = new ManageFeedsModel();

            viewModel.LoadData();
        }
    }
}