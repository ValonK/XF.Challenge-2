using System.Windows.Input;
using Xamarin.Forms;

namespace UiChallenge2
{
	public class MainViewModel
	{
		public MainViewModel()
		{
			LoginCommand = new Command(OnLogin);
		}

		public ICommand LoginCommand { get; set; }

		private async void OnLogin()
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
		}

	}
}
