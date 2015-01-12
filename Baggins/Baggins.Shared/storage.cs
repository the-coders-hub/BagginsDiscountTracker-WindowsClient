using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure;


namespace Baggins
{
    class storage
    {
        String connectionString = "DefaultEndpointsProtocol=https;AccountName=baggins;AccountKey=1paj4H4YkZqeHEkS1/L9pZpVYFP0BWKp/Dpk1brvmlw4ZJu2thEipVM/0QLix5GQuidYlI0jofkm5qRJsTiMwA==";
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
        
        
    }
}
