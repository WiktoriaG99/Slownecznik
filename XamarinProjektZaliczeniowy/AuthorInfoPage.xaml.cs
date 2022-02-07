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
    public partial class AuthorInfoPage : ContentPage
    {
        public AuthorInfoPage()
        {
            InitializeComponent();
        }

        private async void button_BackToMainPage_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}