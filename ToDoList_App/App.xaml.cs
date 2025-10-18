namespace ToDoList_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new login_panel();
        }
    }
}
