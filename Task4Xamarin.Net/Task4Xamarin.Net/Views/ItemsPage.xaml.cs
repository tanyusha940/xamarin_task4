using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Task4Xamarin.Net.Models;
using Task4Xamarin.Net.Views;
using Task4Xamarin.Net.ViewModels;

namespace Task4Xamarin.Net.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        ItemsViewModel viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        private void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Нажато!";
            button.BackgroundColor = Color.Red;
        }

        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (headerStepper != null)
                headerStepper.Text = String.Format("Будет пить: {0:F1}", e.NewValue);
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            headerPickter.Text = "Вы выбрали: " + picker.Items[picker.SelectedIndex];
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}