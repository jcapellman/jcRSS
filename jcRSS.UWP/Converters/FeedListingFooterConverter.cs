using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.UI.Xaml.Data;
using jcRSS.PCL.Objects.Feeds;

namespace jcRSS.UWP.Converters {
    public class FeedListingFooterConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value == null || parameter == null) {
                return null;
            }

            var listingItem = (FeedListingItem) value;

            var timeFrame = "just now";
            var timeDiff = DateTime.Now.Subtract(listingItem.PostTime);

            if (timeDiff.TotalDays > 1) {
                timeFrame = $"{Math.Round(timeDiff.TotalDays, 0)} days ago";
            } else if (timeDiff.TotalHours > 1) {
                timeFrame = $"{Math.Round(timeDiff.TotalHours, 0)} hours ago";
            } else if (timeDiff.TotalMinutes > 1) {
                timeFrame = $"{Math.Round(timeDiff.TotalMinutes, 0)} minutes ago";
            }

            return $"{listingItem.FeedSiteTitle} - {timeFrame}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            return null;
        }
    }
}