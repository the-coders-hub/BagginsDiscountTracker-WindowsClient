using Baggins.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.Storage;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Live;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Storage;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Baggins
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        private bool logged_in = false;
 
        public SettingsPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
            populateLV();
        }

        private void ClickFunction(Object sender, ItemClickEventArgs e)
        {
            /*ListView lv = ((ListView) sender);
            Advertisement ad = lv.*/
            SettingsItem ad = e.ClickedItem as SettingsItem;
            if (ad != null)
            {
                if (ad.Id == 0)
                {
                    logOut();
                }
                if (ad.Id == 1)
                {

                }
                if (ad.Id == 2)
                {
                    ConnectToLive(sender,e);
                }
                if (ad.Id == 3)
                {

                }
                if (ad.Id == 4)
                {

                }
            }
        }

        private void getUserData(dynamic meData)
        {
            //var d = meData["id"];

            localSettings.Values["OUTLOOK_ID"] = meData.id;
            localSettings.Values["OUTLOOK_NAME"] = meData.name;
            localSettings.Values["OUTLOOK_FN"] = meData.first_name;
            localSettings.Values["OUTLOOK_LN"] = meData.last_name;
        }
        private void logOut()
        {
            //var d = meData["id"];

            localSettings.Values["OUTLOOK_ID"] = null;
            localSettings.Values["OUTLOOK_NAME"] = null;
            localSettings.Values["OUTLOOK_FN"] = null;
            localSettings.Values["OUTLOOK_LN"] = null;
            goHome();
        }
        private async void ConnectToLive(Object sender, RoutedEventArgs e)
        {

            bool connected = false;
            try
            {
                var authClient = new LiveAuthClient();
                LiveLoginResult result = await authClient.LoginAsync(new string[] { "wl.signin" });

                if (result.Status == LiveConnectSessionStatus.Connected)
                {
                    connected = true;
                    var connectClient = new LiveConnectClient(result.Session);
                    var meResult = await connectClient.GetAsync("me");
                    dynamic meData = meResult.Result;
                    getUserData(meData);
                }
            }
            catch (LiveAuthException ex)
            {
                // Display an error message.
            }
            catch (LiveConnectException ex)
            {
                // Display an error message.
            }

            // Turn off the display of the connection button in the UI.
            //connectButton.Visibility = connected ? Visibility.Collapsed : Visibility.Visible;
            goHome();
        }

        public void goHome()
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        public void populateLV()
        {
            List<SettingsItem> items = new List<SettingsItem>();
            if ((localSettings.Values["OUTLOOK_ID"] as string) != null)
            {
                logged_in = true;
                items.Add(new SettingsItem("Assets/profile.PNG", "Logged In", "Click To Log Out Of The Application",0));
                items.Add(new SettingsItem("Assets/face.PNG", "Profile", "Click To See Your Profile",1));
            }
            else
            {
                items.Add(new SettingsItem("Assets/profile.PNG", "Log In", "Click To Log In Of The Application",2));
            }

            items.Add(new SettingsItem("Assets/bookmarks.PNG", "Bookmarks", "Click To View  Your Games",3));
            //items.Add(new SettingsItem("Assets/following.PNG", "Following", "Click To View The Brands You Follow",4));

            SettingsList.ItemTemplate = (DataTemplate)Application.Current.Resources["lvTemplate"];
            SettingsList.ItemsSource = items;

        }
        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Gets the view model for this <see cref="Page"/>.
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
       

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }
    class SettingsItem
    {
        public String ImagePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }

        public SettingsItem(string image_name,string title,string desc, int id)
        {
            this.ImagePath = image_name;
            this.Title = title;
            this.Description = desc;
            this.Id = id;
        }
    }
}
