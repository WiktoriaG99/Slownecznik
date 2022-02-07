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
    public partial class WordsDatabasePage : ContentPage
    {
        private List<Word> listofWords;

        public WordsDatabasePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listofWords = new List<Word>();

            //Pobranie wszystkich słów z bazy danych
            listofWords = await App.Database.GetWordsAsync();

            //Przypisanie słów z bazy danych do listView
            listViewWords.ItemsSource = listofWords;

            BindingContext = this;

        }


        private async void  button_BackToMainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void button_AddWord_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddWordPage());
        }

        private async void listViewWords_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedWord = e.SelectedItem as Word;
            var languageToPicker = selectedWord.language;

            //Przesłanie danych z wybranego słowa do EditWordPage poprzez BindingContext
            // i języka do pickera przez konstruktor
            var EditWordPage = new EditWordPage(languageToPicker);
            EditWordPage.BindingContext = selectedWord;
            await Navigation.PushAsync(EditWordPage);
        }
    }
}