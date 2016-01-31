using System;
using jcRSS.UWP.ViewModels;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using jcRSS.PCL.Objects.Feeds;
using Newtonsoft.Json;

namespace jcRSS.UWP.Views {
    public sealed partial class DetailPage : Page {
        public DetailPage() {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Disabled;
        }
    }
}