using Xamarin.Forms;

namespace UiChallenge2
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty PlaceholderFontFamilyProperty
            = BindableProperty.Create(nameof(PlaceholderFontFamily), typeof(string), typeof(CustomEntry), default(string));

        public string PlaceholderFontFamily {
            get { return (string)GetValue(PlaceholderFontFamilyProperty); }
            set { SetValue(PlaceholderFontFamilyProperty, value); }
        }
    }
}
