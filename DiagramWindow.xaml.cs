using Newtonsoft.Json;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarsShowroom
{
    public partial class DiagramWindow : Window
    {
        public DiagramWindow()
        {
            this.DataContext = new ViewModel();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTQ4NDYzQDMxMzkyZTMzMmUzMG1LTUE1RFVlelRlcGFIdzlzaDJPOUVGUndQNFFMOVlwVS9VTU1JbzlzZUE9");
            //SfSkinManager.SetTheme(this, new Theme("MaterialDark"));
            //SfSkinManager.ApplyStylesOnApplication = true;
            InitializeComponent();
        }

        public class ViewModel
        {
            public List<Classes.Car> Items { get; set; }

            private void Get()
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Cars"));

                WebReq.Method = "GET";

                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


                string jsonString;
                using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
                {
                    StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                    jsonString = reader.ReadToEnd();
                }

                Items = JsonConvert.DeserializeObject<List<Classes.Car>>(jsonString);
            }

            public ViewModel()
            {
                Get();
            }
        }
    }
}
