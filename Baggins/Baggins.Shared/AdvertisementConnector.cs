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
        private MobileServiceCollection<Advertisement, Advertisement> items;
        private IMobileServiceTable<Advertisement> discountTable = App.MobileService.GetTable<Advertisement>();
        private MobileServiceCollection<UARelation, UARelation> relations;
        private IMobileServiceTable<UARelation> relationTable = App.MobileService.GetTable<UARelation>();
        private MobileServiceCollection<UserProfile, UserProfile> users;
        private IMobileServiceTable<UserProfile> userTable = App.MobileService.GetTable<UserProfile>();

        private async Task InsertDiscountItem(Advertisement discountItem)
        {
            // This code inserts a new DiscountItem into the database. When the operation completes
            // and Mobile Services has assigned an Id, the item is added to the CollectionView
            await discountTable.InsertAsync(discountItem);
            items.Add(discountItem);

            //await SyncAsync(); // offline sync
        }

        //This will fetch the advertisements from the table as if it wasn't apparent.
        private async Task FetchItems(ListView ListName, String Category)
        {
            MobileServiceInvalidOperationException exception = null;
            try
            {
                items = await discountTable
                    .Where(discountItem => discountItem.IsActive == true)
                    .Where(discountItem => discountItem.Category == "Category")
                    .ToCollectionAsync();
            }
            catch (MobileServiceInvalidOperationException e)
            {
                exception = e;
            }

            if (exception != null)
            {
                await new MessageDialog(exception.Message, "Error loading items").ShowAsync();
            }
            else
            {
                ListName.ItemsSource = items;
            }
        }

        private async Task LikeAdvertisement(Advertisement item, UARelation relation)
        {
            //This updates likes
            await discountTable.UpdateAsync(item);
            item.Likes = item.Likes + 1;

            //This tells that the user has liked the item
            await relationTable.UpdateAsync(relation);
            relation.Flag = 1;

            //Now, to give score to the one who deserves
            string deserver = item.SourceName;
            users = await userTable
                .Where(auser => auser.Username == deserver)
                .ToCollectionAsync();
            UserProfile acredited = users[0];
            await userTable.UpdateAsync(acredited);
            acredited.Score = acredited.Score + 1;
            //await SyncAsync(); // offline sync
        }

        private async Task DisikeAdvertisement(Advertisement item, UARelation relation)
        {
            //This updates dislikes
            await discountTable.UpdateAsync(item);
            item.Dislikes = item.Dislikes + 1;

            //This ad is fake, ditch it
            if (item.Dislikes > item.Likes + 10)
            {
                item.IsActive = false;
            }

            //This tells that the user has disliked the item
            await relationTable.UpdateAsync(relation);
            relation.Flag = -1;

            //Now, to punish the one who fakes
            string nondeserver = item.SourceName;
            users = await userTable
                .Where(auser => auser.Username == nondeserver)
                .ToCollectionAsync();
            UserProfile faker = users[0];
            await userTable.UpdateAsync(faker);
            faker.Score = faker.Score - 1;
            //await SyncAsync(); // offline sync
        }


    }
}
