using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Com.Igalata.Bubblepicker;
using Com.Igalata.Bubblepicker.Adapter;
using Com.Igalata.Bubblepicker.Model;
using Com.Igalata.Bubblepicker.Rendering;

namespace testBubblePicker
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            var fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            var picker = FindViewById<BubblePicker>(Resource.Id.picker);
            picker.BubbleSize = 20;
            picker.Adapter = new BubblePickerAdapter();
            picker.Listener = new BubblePickerListener(picker);


            //        return PickerItem().apply {
            //            title = titles[position]
            //            gradient = BubbleGradient(colors.getColor((position * 2) % 8, 0),
            //                    colors.getColor((position * 2) % 8 + 1, 0), BubbleGradient.VERTICAL)
            //            typeface = mediumTypeface
            //            textColor = ContextCompat.getColor(this@DemoActivity, android.R.color.white)
            //            backgroundImage = ContextCompat.getDrawable(this@DemoActivity, images.getResourceId(position, 0))
            //                    }
            //        }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var result = "Please create your native control";
            //var control = new Com.Microsoft.CoolcontrolsLibrary.CoolKotlinControl();
            //var result = control.DoIt("Alexey");

            var control = new BubblePicker(this);
            result = control.ToString();

            View view = (View)sender;
            Snackbar.Make(view, result, Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class BubblePickerAdapter : Java.Lang.Object, IBubblePickerAdapter
    {
        private List<string> _bubbles = new List<string>();

        public int TotalCount => _bubbles.Count;

        public BubblePickerAdapter()
        {
            for (int i = 0; i < 10; i++)
            {
                _bubbles.Add($"Item {i}");
            }
        }

        public PickerItem GetItem(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= _bubbles.Count)
                return null;

            var result = _bubbles[itemIndex];
            var item = new PickerItem(result);
            return item;
        }
    }

    public class BubblePickerListener : Java.Lang.Object, IBubblePickerListener
    {
        public View Picker { get; }

        public BubblePickerListener(View picker)
        {
            Picker = picker;
        }

        public void OnBubbleDeselected(PickerItem item)
        {
            System.Diagnostics.Debug.WriteLine($"Deselected: {item.Title}");
            Snackbar.Make(Picker, $"Deselected: {item.Title}", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null)
                .Show();
        }

        public void OnBubbleSelected(PickerItem item)
        {
            System.Diagnostics.Debug.WriteLine($"Selected: {item.Title}");
            Snackbar.Make(Picker, $"Selected: {item.Title}", Snackbar.LengthLong)
               .SetAction("Action", (Android.Views.View.IOnClickListener)null)
               .Show();
        }
    }
}

