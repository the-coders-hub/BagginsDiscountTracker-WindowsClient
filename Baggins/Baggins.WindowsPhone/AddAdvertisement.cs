using Baggins.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Baggins
{
    sealed partial class AddAdvertisement: Page
    {

       

        private async void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            var blah = Validity.Date;
            var blue = blah.Date;
            var discountItem = new Advertisement(Heading.Text, Details.Text, "ranveer", Link.Text, "", 0, 0, "Amazon", "Electronics", true, Validity.Date.Date);
                
            await InsertDiscountItem(discountItem);
        }
        
        /*
        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            ButtonRefresh.IsEnabled = false;

            //await SyncAsync(); // offline sync
            await FetchItems(ListName, Category);

            ButtonRefresh.IsEnabled = true;
        }
         */
    }
}
