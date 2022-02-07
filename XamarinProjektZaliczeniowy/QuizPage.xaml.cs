using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace XamarinProjektZaliczeniowy
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizPage : ContentPage
    {

        private string _category;
        private string _language;
        private List<Word> _wordsList;
        private int randomIndex;

        static Random rnd = new Random();

        public QuizPage(string lang, string cat)
        {
            InitializeComponent();
            _category = cat;
            _language = lang;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Przypisanie do listy wszystkich słow z danego języka i kategorii
            _wordsList = await App.Database.GetWordsByCategoryAsync(_language, _category);

            getRandomWord();
        }

        private void randomizeWord_button_Clicked(object sender, EventArgs e)
        {
            getRandomWord();
        }

        //Wylosowanie nowego słowa i wyczyszczenie pól
        private void getRandomWord()
        {
            randomIndex = rnd.Next(_wordsList.Count);
            Word w = _wordsList[randomIndex];
            randomWord.Text = w.word;
            result.Text = "";
            enteredWord.Text = "";
        }

        //Metoda sprawdzająca czy podane tłumaczenie jest prawidłowe
        private void checkWord_button_Clicked(object sender, EventArgs e)
        {
            //zmienienie wszystkich liter na małe w celu wyeliminowania błędu na podstawie wielkości liter
            if(enteredWord.Text.ToLower() == _wordsList[randomIndex].translation.ToLower())
            {
                result.Text = "Dobrze! 🌻";
            }
            else
            {
                result.Text = $"Niepoprawnie! \nPoprawna odpowiedź to: {_wordsList[randomIndex].translation}";
            }
        }

        private async void soundPron_Clicked(object sender, EventArgs e)
        {

            var locales = await TextToSpeech.GetLocalesAsync();

            foreach (Locale l in locales)
            {
                //Contains by działało i na Androidzie i UWP
                //Inne kodowanie języków np. Android: pl, UWP: pl_PL

                //Jeżeli kod języka ze słowa zawiera się w kodzie języka z locales
                //Pobranie kodu języka ze słownika na podstawie klucza, będącego pełną nazwą języka
                if (l.Language.Contains(Languages.languagesDict[_language]))
                {
                    //await DisplayAlert(l.Language, l.Name, "OK");

                    SpeechOptions speechOptions = new SpeechOptions();

                    speechOptions.Locale = l;

                    await TextToSpeech.SpeakAsync(randomWord.Text, speechOptions);

                    break;
                
                }

            }
        }
    }
}