using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinProjektZaliczeniowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddWordPage : ContentPage
    {
        string selectedLanguage;

        public AddWordPage()
        {
            InitializeComponent();

            //Pobranie kluczy - pełnych nazw języków
            foreach (string language in Languages.languagesDict.Keys)
            {
                picker.Items.Add(language);
            }
        }

        private async void addWordButton_Clicked(object sender, EventArgs e)
        {

            //Sprawdzenie czy pola nie są puste
            if (!string.IsNullOrWhiteSpace(wordEntry.Text) &&
                !string.IsNullOrWhiteSpace(translationEntry.Text) &&
                !string.IsNullOrWhiteSpace(selectedLanguage) &&
                !string.IsNullOrWhiteSpace(categoryEntry.Text))
            {
                await App.Database.SaveWordAsync(new Word
                {
                    word = wordEntry.Text,
                    translation = translationEntry.Text,
                    language = selectedLanguage,
                    category = categoryEntry.Text
                });

                //Wyczyszczenie pól
                wordEntry.Text = translationEntry.Text = categoryEntry.Text = string.Empty;
                //Ustawienie pickera na brak wybranego elementu
                picker.SelectedItem = -1;

                await DisplayAlert("Sukces", "Dodano słowo do bazy", "OK");

            }
            //Jeżeli przynajmniej jedno z pól jest puste
            else
            {
                await DisplayAlert("Uwaga", "Żadne pole nie może być puste", "OK");
            }
        }

        private async void goBackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void languageEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker.SelectedIndex == -1)
            {
                selectedLanguage = "";
            }
            else
            {
                selectedLanguage = picker.Items[picker.SelectedIndex];
            }
        }
    }
}