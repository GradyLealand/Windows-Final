using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
// This page was made by matt Williamson

namespace Magic_Card_Search
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailsPage : Page
    {
        public DetailsPage()
        {
            this.InitializeComponent();
          
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
         //Navigate back to mainpage
            this.Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Get the card from Parameter passed by former page
            var card = (CardModel)e.Parameter;
            
            //Set all related text fields to the corresponding values
            txbName.Text = card.Name;
            txbColor.Text = card.Color;
            txbMana.Text = card.Mana;
            txbConvertedManaCost.Text = card.ConvertMana;
            txbTypes.Text = card.Type;
            txbRarity.Text = card.Rarity;
            txbArtist.Text = card.Artist;
            
            //Convert the URL string into a bitmateIMG
            BitmapImage imgUrl = new BitmapImage(new Uri(card.Url));
            //Set the img tag display
            imgCard.Source = imgUrl;
            base.OnNavigatedTo(e);
        }
    }
}
