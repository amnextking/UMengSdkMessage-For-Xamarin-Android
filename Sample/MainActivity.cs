using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Umeng.Message;
using Android.Util;
using Android.OS;
using System.Threading.Tasks;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            PushAgent mPushAgent = PushAgent.GetInstance(this);
            mPushAgent.Enable();

            string token = UmengRegistrar.GetRegistrationId(this);
            Toast.MakeText(this, token, ToastLength.Long).Show();

            new TaskFactory().StartNew(() =>
            {
                mPushAgent.AddAlias("15050851037", "test");
            });
        }

        protected override void OnResume()
        {
            base.OnResume();
        }
    }
}

