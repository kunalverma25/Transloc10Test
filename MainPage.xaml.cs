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
            RootObject ro = await GetAllAgency.GetAll();
            //RootObject roC = await GetAllAgency.GetClose(35.771560, -78.692563);
            var realList = ro.data;
            lb.ItemsSource = realList;

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
    
