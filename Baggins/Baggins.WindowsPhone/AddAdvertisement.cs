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
        private async void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            var discountItem = new Advertisement
            {
                Title = Heading.Text,
                Description = Details.Text,
                SourceName = "",
                Likes = 0,
                Dislikes = 0,
                Link = Link.Text,
                ImageLink = "",
                Company = "",
                Category = "",
                IsActive = true,
                ValidUpto = Convert.ToDateTime(Validity.Date),
            };
            await InsertDiscountItem(discountItem);
        }
    }
}
