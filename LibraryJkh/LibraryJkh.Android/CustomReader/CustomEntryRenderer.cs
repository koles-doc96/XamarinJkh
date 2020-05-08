using System;
using Android.Content;
using Android.Runtime;
using Android.Widget;
using LibraryJkh.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace LibraryJkh.Android
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                Control.Background = null;

                var lp = new MarginLayoutParams(Control.LayoutParameters);
                lp.SetMargins(0, 0, 0, 10);
                LayoutParameters = lp;
                Control.LayoutParameters = lp;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
                
                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID (IntPtrtextViewClass, "mCursorDrawableRes", "I");
                JNIEnv.SetField (Control.Handle, mCursorDrawableResProperty, 0); 
            }
        }
    }
}