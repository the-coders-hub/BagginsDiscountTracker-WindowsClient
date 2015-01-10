using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Baggins
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {

        private List<Advertisement> getData(int type)
        {
            //String title, String description, String source_name, String source_details,String link, String image, int likes, int dislikes
            List<Advertisement> itemsList = new List<Advertisement>();
            itemsList.Add(new Advertisement("Heading Of The App, will be showed here!", "This is the description", "Bijoy Singh", "20 years old", "http://google.com", "", 12, 2));
            itemsList.Add(new Advertisement("Heading", "This is the description", "Bijoy Singh", "20 years old", "http://google.com", "", 12, 2));
            itemsList.Add(new Advertisement("Heading", "This is the description", "Bijoy Singh", "20 years old", "http://google.com", "", 12, 2));

            return itemsList;
        }

        private void ClickFunction(Object sender, RoutedEventArgs e)
        {
            var lv = (ListViewItem) sender;
            if (lv != null)
            {
                this.Frame.Navigate(typeof(Baggins.ArticlePage));
            }            
        }

        private void CreateListView(ListView lv, int type)
        {
            List<Advertisement> items = getData(type);

            lv.ItemTemplate = (DataTemplate)Application.Current.Resources["cardTemplate"];
            //lv.HorizontalContentAlignment = Windows.UI.Xaml.HorizontalAlignment.Stretch;
            lv.ItemsSource = items;
            lv.ItemClick += ClickFunction;
            lv.SelectionChanged += ListView_SelectionChanged;

        }

        private void StartCreation()
        {
            CreateListView(FeaturedList, 0);

            //Grid FeaturedGrid = new Grid(); 
            //CreateListView(FeaturedGrid,0);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.
            StartCreation();

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Add code to perform some action here.
        }

        private void TextBlock_SelectionChanged_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
