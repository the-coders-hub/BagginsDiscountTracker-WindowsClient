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
using Microsoft.Live;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Baggins
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {

        private ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;


        public LoginPage()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
        }
        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>

        
        private void goToHome()
        {
            this.Frame.Navigate(typeof(HomePage));
        }

        private void goHomeClick(Object sender, RoutedEventArgs e)
        {
            goToHome();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String ID = localSettings.Values["OUTLOOK_ID"] as String;
            if (ID != null && ID != "")
            {
                connectButton.Content = "GO TO HOME PAGE";
                connectButton.Click += goHomeClick;
                //this.Frame.NavigationStopped += Frame_NavigationStopped;
                //this.Frame.StopLoading();
            }
        }


        private void Frame_NavigationStopped(object sender, NavigationEventArgs e)
        {
            this.Frame.NavigationStopped -= Frame_NavigationStopped; // Prevent infinite loop
            goToHome();
        }
        
        private void getUserData(dynamic meData)
        {
            //var d = meData["id"];

            localSettings.Values["OUTLOOK_ID"] = meData.id;
            localSettings.Values["OUTLOOK_NAME"] = meData.name;
            localSettings.Values["OUTLOOK_FN"] = meData.first_name;
            localSettings.Values["OUTLOOK_LN"] = meData.last_name;
        }
        private async void ConnectToLive(Object sender, RoutedEventArgs e)
        {
            
            bool connected = false;
            try
            {
                var authClient = new LiveAuthClient();
                LiveLoginResult result = await authClient.LoginAsync(new string[] { "wl.signin"});

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
            goToHome();
        }
    }
}
