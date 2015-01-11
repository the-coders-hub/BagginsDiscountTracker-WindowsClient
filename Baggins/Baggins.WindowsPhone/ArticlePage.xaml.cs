using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;
using Baggins.Models;
using Windows.Storage;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Baggins
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ArticlePage : Page
    {
        bool bookmarked = false;
        private Advertisement showing;
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            Advertisement ad =(Advertisement) e.Parameter;
            if (ad != null)
            {
                showing = ad;
                getBookmarkedAdvertisements();
                //CoverImage.Source = ad.ImageLink;
                Title.Text = ad.Title;
                Description.Text = ad.Description;
                Likes.Text = "" + ad.Likes;
                Dislikes.Text = "" + ad.Dislikes;
                SourceName.Text = ad.SourceName;
                SourceDescription.Text = ad.Link;
            }

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        public void getBookmarkedAdvertisements()
        {
            List<Advertisement> lst = new List<Advertisement>();
            string count = localSettings.Values["BOOKMARK_COUNT"] as string;
            int new_count = 0;
            if (count != null)
            {
                new_count = int.Parse(count);
            }

            for (int i = 1; i <= new_count; i++)
            {
                Advertisement ad = localSettings.Values["BOOKMARK_" + i] as Advertisement;
                //lst.Add(ad);
                if (ad.Title == showing.Title)
                {
                    bookmarked = true;
                }
            }
        }

        public void Bookmark(Object sender, RoutedEventArgs e){
            if (this.bookmarked == false)
            {
                string count = localSettings.Values["BOOKMARK_COUNT"] as string;
                int new_count = 1;
                if (count != null)
                {
                    new_count = int.Parse(count);
                }
                localSettings.Values["BOOKMARK_" + new_count] = showing;
                this.bookmarked = true;
            }
        }
        private void HardwareButtons_BackPressed(Object sender, BackPressedEventArgs e){
            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {

            }
            else if(frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
        }
    }
}
