using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AndroidFileManager.Droid.Services
{
    public class services
    {
        /*public void OpenFile(string path)
        {
            string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(new Java.IO.File(path)).ToString());
            string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
            var tt = File.Exists(path);
            Context context = Android.App.Application.Context;
            Android.Net.Uri uri = FileProvider.GetUriForFile(context, context.PackageName + ".provider", new Java.IO.File(path));
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(uri, mimeType);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            Intent chooserInten = Intent.CreateChooser(intent, "Open with:");
            chooserInten.AddFlags(ActivityFlags.NewTask);

            try
            {
                context.StartActivity(intent);
            }
            catch (Exception exp)
            {
                Toast.MakeText(context, "No application available to View PDF", ToastLength.Short).Show();
            }
        }*/
    }
}