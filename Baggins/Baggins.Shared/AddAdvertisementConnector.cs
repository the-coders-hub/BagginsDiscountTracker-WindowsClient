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
    sealed partial class AddAdvertisementConnector: Page
    {
        private MobileServiceCollection<Advertisement, Advertisement> items;
        private IMobileServiceTable<Advertisement> discountTable = App.MobileService.GetTable<Advertisement>();

        private async Task InsertDiscountItem(Advertisement discountItem)
        {
            // This code inserts a new DiscountItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await discountTable.InsertAsync(discountItem);
            items.Add(discountItem);

            //await SyncAsync(); // offline sync
        }

    }
}
