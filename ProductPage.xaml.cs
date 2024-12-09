using SocaciuAlexiaLab7.Models;

namespace SocaciuAlexiaLab7
{
    public partial class ProductPage : ContentPage
    {
        public ProductPage(ShopList shopList)
        {
            InitializeComponent();
            BindingContext = shopList;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            await App.Database.SaveProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var product = listView.SelectedItem as Product;
            await App.Database.DeleteProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
    }
}