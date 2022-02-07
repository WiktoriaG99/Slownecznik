using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace XamarinProjektZaliczeniowy
{
    public partial class App : Application
    {

        static Database database;

        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "words.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            Page mainPage = new MainPage();
            MainPage = new NavigationPage(mainPage)
            {
                BarBackgroundColor = Color.FromHex("#ebbb38"),
                BarTextColor = Color.FromHex("#3d3d3d"),
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
