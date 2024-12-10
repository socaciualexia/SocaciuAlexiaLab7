using Plugin.LocalNotification;
using SocaciuAlexiaLab7.Models;
namespace SocaciuAlexiaLab7;

public partial class ShopPage : ContentPage
{
    public ShopPage()
    {
        InitializeComponent();

        BindingContext = new Shop
        {
            Adress = "123 Main Street",
            ShopName = "Default Shop Name"
        };
    }

    private async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var shop = (Shop)this.BindingContext;
        await App.Database.SaveShopAsync(shop);
        await DisplayAlert("Success", "Shop saved successfully!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnShowMapButtonClicked(object sender, EventArgs e)
    {
        var shop = (Shop)this.BindingContext;
        var address = shop.Adress;

        var shoplocation = new Location(46.7492379, 23.5745597);

        var options = new MapLaunchOptions
        {
            Name = "Magazinul meu preferat"
        };

        var myLocation = new Location(46.7731796289, 23.6213886738);

        var distance = myLocation.CalculateDistance(shoplocation, DistanceUnits.Kilometers);

        if (distance < 5)
        {
            var request = new NotificationRequest
            {
                Title = "Ai de facut cumparaturi in apropiere!",
                Description = address,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            LocalNotificationCenter.Current.Show(request);
        }

        await Map.OpenAsync(shoplocation, options);
    }
}
