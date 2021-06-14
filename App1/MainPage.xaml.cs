using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            empList = new ListView();
            this.InitJson();
        }
        private async void InitJson()
        {
            string FilePath = Path.Combine(Package.Current.InstalledLocation.Path, "employee.json");
            using (StreamReader file = File.OpenText(FilePath))
            {
                var json = file.ReadToEnd();
                Dictionary<string, object> result = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                string contacts = result["employee_list"].ToString();
                List<data.Employee> objResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<List<data.Employee>>(contacts);
                empList.ItemsSource = objResponse;
                System.Diagnostics.Debug.WriteLine(Package.Current.InstalledLocation.Path);

            }

        }
    }
}
