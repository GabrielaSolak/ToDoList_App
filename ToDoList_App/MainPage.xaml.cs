using System.Collections.ObjectModel;

namespace ToDoList_App
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Zadanie> Zadania { get; set; } = new();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void dodaj_zadanie(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nowe_zadanie.Text))
            {
                Zadania.Add(new Zadanie { Name = nowe_zadanie.Text });
                nowe_zadanie.Text = string.Empty;
            }
        }

    }

    public class Zadanie
    {
        public string Name { get; set; }
    }

}
