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
    public partial class ChooseLangPage : ContentPage
    {
        public ChooseLangPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Pobranie języków z bazy danych do listView
            listViewLanguages.ItemsSource = await App.Database.GetLanguageAsync();
        }

        private async void button_BackToMainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void listViewLanguages_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedItem = e.SelectedItem as Word;
            string selectedLang = selectedItem.language;

            //Przesłanie wybranego języka do ChooseCoursePage poprzez konstruktor
            await Navigation.PushAsync(new ChooseCoursePage(selectedLang));
        }
    }
}