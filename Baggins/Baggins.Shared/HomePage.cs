using Baggins.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Baggins
{
    public partial class HomePage : Page
    {
        private MobileServiceCollection<DiscountItem, DiscountItem> items;
        private IMobileServiceTable<DiscountItem> discountTable = App.MobileService.GetTable<DiscountItem>();
        public HomePage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private async Task InsertDiscountItem(DiscountItem discountItem)
        {
            // This code inserts a new DiscountItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await discountTable.InsertAsync(discountItem);
            items.Add(discountItem);

            //await SyncAsync(); // offline sync
        }

        private async void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            var discountItem = new DiscountItem 
            { 
                Title = "",
                Description = "",
                UId = "",
                CId = "",
                ValidUpto = ""
            };
            await InsertDiscountItem(discountItem);
        }

    }
}
