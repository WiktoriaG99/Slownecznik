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
    public partial class ChooseCoursePage : ContentPage
    {
        private string _selectedLang;
        private string _langToQuiz;

        public ChooseCoursePage(string selectedLang)
        {
            InitializeComponent();
            _langToQuiz = selectedLang;
            _selectedLang = selectedLang;

            //Przypisanie języka do Labela na górze strony
            BindedLang.Text = _selectedLang;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            //Pobranie kategorii z bazy danych i przypisanie ich do listView
            listView.ItemsSource = await App.Database.GetCategoryAsync(_selectedLang);
        }

        private async void button_BackToMainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var selectedWord = e.SelectedItem as Word;

            //Przesłanie języka i kategorii do QuizPage poprzez konstruktor
            string category = selectedWord.category;
            var QuizPage = new QuizPage(_langToQuiz, category);
            await Navigation.PushAsync(QuizPage);
        }
    }
}