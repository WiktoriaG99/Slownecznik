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
    public partial class EditWordPage : ContentPage
    {
        private int word_id;
        private string word_word;
        private string word_translation;
        private string word_language;
        private string word_category;

        string selectedLanguage;

        public EditWordPage(string receivedLanguage)
        {
            InitializeComponent();

            selectedLanguage = receivedLanguage;

            //Uzupełnienie pickra w wartości - pełne nazwy języków
            foreach (string language in Languages.languagesDict.Keys)
            {
                picker.Items.Add(language);
            }

            //Przypisanie do pickera języka pobranego z konstruktora
            picker.SelectedItem = selectedLanguage;
        }

        private async void goBackButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void saveWordButton_Clicked(object sender, EventArgs e)
        {
            //Jeżeli pola nie są puste
            if (!string.IsNullOrWhiteSpace(wordEntry.Text) &&
              !string.IsNullOrWhiteSpace(translationEntry.Text) &&
              !string.IsNullOrWhiteSpace(selectedLanguage) &&
              !string.IsNullOrWhiteSpace(categoryEntry.Text))
            {
                word_id = Convert.ToInt32(BindedID.Text);
                word_word = wordEntry.Text;
                word_translation = translationEntry.Text;
                word_language = selectedLanguage;
                word_category = categoryEntry.Text;

                await App.Database.UpdateWordAsync(word_id, word_word, word_translation, word_language, word_category);

                await DisplayAlert("Sukces!", "Słowo zostało zmienione", "Ok");

            }
            //Jeżeli przynajmniej jedno z pól jest puste
            else
            {
                await DisplayAlert("Uwaga", "Żadne pole nie może być puste", "OK");
            }
        }

        private async void deleteWordButton_Clicked(object sender, EventArgs e)
        {
            word_id = Convert.ToInt32(BindedID.Text);

            await App.Database.DeleteWordAsync(word_id);

            await DisplayAlert("Sukces!", "Słowo zostało usunięte", "Ok");

            await Navigation.PopAsync();
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLanguage = picker.Items[picker.SelectedIndex];
        }
    }
}