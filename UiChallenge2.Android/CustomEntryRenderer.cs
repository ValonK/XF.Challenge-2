using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Widget;
using UiChallenge2;
using UiChallenge2.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace UiChallenge2.Droid
{
	public class CustomEntryRenderer : EntryRenderer
	{
		private CustomEntry CustomEntry => Element as CustomEntry;

		public CustomEntryRenderer(Context context) : base(context) { }

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control == null || e.NewElement == null) return;

			if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
				Control.BackgroundTintList = ColorStateList.ValueOf(Color.White.ToAndroid());
			else
				Control.Background.SetColorFilter(Color.White.ToAndroid(), PorterDuff.Mode.SrcAtop);


			Control.SetHintTextColor(Color.White.ToAndroid());

			var textField = (EditText)Control;
			var font = FindFont(CustomEntry.PlaceholderFontFamily);
			textField.Typeface = font;
			textField.Alpha = 0.65f;
			textField.SetTextSize(Android.Util.ComplexUnitType.Dip, 8f);
			textField.SetTypeface(font, TypefaceStyle.Bold);
			textField.Gravity = Android.Views.GravityFlags.Center;
			textField.SetHintTextColor(Color.White.ToAndroid());
		}

		private Typeface FindFont(string fontFamily)
		{
			if (string.IsNullOrWhiteSpace(fontFamily))
			{
				return null;
			}
			return Typeface.CreateFromAsset(Android.App.Application.Context.Assets, FontNameToFontFile(fontFamily));
		}

		private string FontNameToFontFile(string fontFamily)
		{
			int hashtagIndex = fontFamily.IndexOf('#');
			if (hashtagIndex >= 0)
				return fontFamily.Substring(0, hashtagIndex);

			return null;
		}

	}
}