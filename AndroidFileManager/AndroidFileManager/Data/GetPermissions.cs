using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AndroidFileManager.Data
{
    /// <summary>
    /// Function to check if the user has authorized the application to access the storage of his phone
    /// If the user has not given their authorization, the application cannot be used
    /// </summary>
    public class GetPermissions
    {
        public async void GetStoragePermissions()
        {
            var permissions = await Permissions.CheckStatusAsync<Permissions.StorageWrite>();
            if (permissions != PermissionStatus.Granted)
            {
                permissions = await Permissions.RequestAsync<Permissions.StorageWrite>();
            }
            if (permissions != PermissionStatus.Granted)
            {
                return;
            }
        }
    }
}
