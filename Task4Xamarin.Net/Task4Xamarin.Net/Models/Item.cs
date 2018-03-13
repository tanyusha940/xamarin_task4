using System;

namespace Task4Xamarin.Net.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public bool IsChecked { get; set; }
        public int Stepper { get; set; }
    }
}