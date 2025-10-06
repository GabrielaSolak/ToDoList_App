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
                Zadanie nowe = new Zadanie();
                nowe.Name = nowe_zadanie.Text;
                nowe.czyZrobione = false;

                Zadania.Add(nowe);
                nowe_zadanie.Text = string.Empty;

                AkutualizujPodsumowanie();
            }
        }

        private void usun_zadanie(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is Zadanie zadanie)
            {
                Zadania.Remove(zadanie);
                AkutualizujPodsumowanie();
            }
        }

        private void zmien_status(object sender, CheckedChangedEventArgs e)
        {
            if (sender is CheckBox check && check.BindingContext is Zadanie zadanie)
            {
                zadanie.czyZrobione = e.Value;

                if (check.Parent is Frame ramkaCheckBoxa && ramkaCheckBoxa.Parent is Grid wiersz)
                {
                    if (wiersz.Children[0] is Frame ramkaTekstu && ramkaTekstu.Content is Grid siatka)
                    {
                        if (siatka.Children[0] is Label etykieta)
                        {
                            etykieta.TextColor = e.Value ? Color.FromArgb("#6A7EE2") : Color.FromArgb("#C8EAFF");
                        }
                    }
                }

                AkutualizujPodsumowanie();
            }
        }

        private void AkutualizujPodsumowanie()
        {
            int wykonane = 0;
            foreach (Zadanie z in Zadania)
            {
                if (z.czyZrobione)
                    wykonane++;
            }
            podsumowanie.Text = $"Wykonano {wykonane}/{Zadania.Count} zadań";

        }

    }

    public class Zadanie
    {
        public string Name { get; set; }
        public bool czyZrobione { get; set; }

        public Color TextColor
            {
                get
                {
                    if (czyZrobione)
                        return Colors.Gray;
                    else
                        return Color.FromArgb("#C8EAFF");
                }
            }
    }

    

}
