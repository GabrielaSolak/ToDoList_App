namespace ToDoList_App;

public partial class login_panel : ContentPage
{
	public login_panel()
	{
		InitializeComponent();
	}

    private void logowanie(object sender, EventArgs e)
	{
		string login_uz = login.Text;
		string haslo_uz = haslo.Text;

		if(string.IsNullOrWhiteSpace(login_uz) || string.IsNullOrWhiteSpace(haslo_uz))
		{
			DisplayAlert("B³¹d", "Podaj login i has³o", "OK");
		}
		if(haslo_uz == "1234zsme")
		{
			Application.Current.MainPage = new MainPage();
		}
		else
		{
			DisplayAlert("B³¹d", "Wyst¹pi³ b³¹d podczas logowania. Nieprawid³owe has³o.", "OK");
		}
	}
}