using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using Windows.Storage;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Transloc10Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            abc();
        }

        private async void  abc()
        {
            //string URL = "https://transloc-api-1-2.p.mashape.com/agencies.json";
            //string urlParams = "";
            //HttpClient client = new HttpClient();

            //// Add headers for JSON format.
            //client.BaseAddress = new Uri(URL, UriKind.Absolute);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("X-Mashape-Key", "y1ussTz5ltmshVQrmpOiaCRBkpxip1zmwU3jsnX2QyR0SA2QaH");
            //var respose = await client.GetAsync(urlParams);
            //string result = await respose.Content.ReadAsStringAsync();

            //fu.Text = result;

            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            //StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt", CreationCollisionOption.ReplaceExisting);
            //await FileIO.WriteTextAsync(sampleFile, result);
            try
            {
                StorageFile sampleFile1 = await localFolder.GetFileAsync("dataFile.txt");
                String timestamp = await FileIO.ReadTextAsync(sampleFile1);
                fu2.Text = timestamp;
            }
            catch (Exception)
            {
                fu2.Text = "FU2";
            }



            //fu2.Text = (String)localSettings.Values["exampleSetting"];


            //RootObject ro = await GetAllAgency.GetAll();
            //RootObject roC = await GetAllAgency.GetClose(35.771560, -78.692563);
            //var realList = ro.data;
            //lb.ItemsSource = realList;

            //var products = from id1 in ro.data
            //               join id2 in roC.data on id1.agency_id equals id2.agency_id
            //               select id1;

            //foreach(var p in products)
            //{
            //    foreach(var item in realList)
            //    {
            //        if (p == item)
            //            lb.SelectedItems.Add(item);
            //    }
            //}

            //var selList = lb.SelectedItems;
            //sel.ItemsSource = selList;
            //GreekGod greekGod = (GreekGod)(listBox.Items[0]);

        }


    }
}
    
