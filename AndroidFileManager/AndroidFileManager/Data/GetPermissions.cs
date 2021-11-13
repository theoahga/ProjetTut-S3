using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace AndroidFileManager.Data
{
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
