using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamarinProjektZaliczeniowy
{

    //Klasa, Baza danych
    public class Word
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(30), NotNull]
        public string word { get; set; }
        [MaxLength(30), NotNull]
        public string translation { get; set; }
        [MaxLength(15), NotNull]
        public string language { get; set; }
        [MaxLength(30)]
        public string category { get; set; }

    }
}
