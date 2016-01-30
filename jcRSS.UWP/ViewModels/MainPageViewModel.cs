using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Windows.UI.Xaml.Navigation;

using Template10.Mvvm;

using jcRSS.PCL.Objects.Feeds;

namespace jcRSS.UWP.ViewModels {
    public class MainPageViewModel : ViewModelBase {
        private ObservableCollection<FeedListingItem> _feedListing;

        public ObservableCollection<FeedListingItem> FeedListing {
            get {  return _feedListing; }
            set { _feedListing = value; RaisePropertyChanged("FeedListing"); }
        } 

        public MainPageViewModel() { }

        private int _feedID;

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state) {
            FeedListing = new ObservableCollection<FeedListingItem> {
                new FeedListingItem {
                    FeedSiteTitle = "Jarred Capellman",
                    PostTime = DateTime.Now.AddDays(-3),
                    ShortDescription = "This release is the best yet.",
                    Title = "jcRSS Released"
                }
            };

            return Task.CompletedTask;
        }
        
        public void GotoDetailsPage() =>
            NavigationService.Navigate(typeof(Views.DetailPage), _feedID);

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}