using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinProjektZaliczeniowy
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void button_Begin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ChooseLangPage());
        }

        private async void button_WordsDatabase_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WordsDatabasePage());
        }

        private async void button_AuthorInfo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AuthorInfoPage());
        }
    }
}
