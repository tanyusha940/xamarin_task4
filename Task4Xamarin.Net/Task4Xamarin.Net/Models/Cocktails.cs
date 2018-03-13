using System;
using System.Collections.Generic;
using System.Text;

namespace Task4Xamarin.Net.Models
{
    class Cocktails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DegreesCocktail { get; set; }
        public int AmountCocktail { get; set; }
        public string ImageCocktails { get; set; }

        public override bool Equals(object obj)
        {
            Cocktails cocktails = obj as Cocktails;
            return this.Id == cocktails.Id;
        }
    }
}
