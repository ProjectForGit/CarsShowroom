﻿using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarsShowroom
{
    public partial class TypePage : Page
    {
        private List<Classes.Type> Items;

        public TypePage()
        {
            InitializeComponent();
            Get();
        }

        private void Get()
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Types"));

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();


            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())   //modified from your code since the using statement disposes the stream automatically when done
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            Items = JsonConvert.DeserializeObject<List<Classes.Type>>(jsonString);
            dataGrid.ItemsSource = Items;

            foreach (var item in Items)
            {
                item.PropertyChanged += delegate
                {
                    PUT(item);
                };
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].TypeId;

                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Types/" + id));
                WebReq.Method = "DELETE";
                HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

                Get();
            }
            catch
            {

            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (Validation() == true)
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Types"));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "POST";

                Classes.Type type = new Classes.Type
                {
                    Name = nameTxt.Text,
                };
                Items.Add(type);


                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(type);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)WebReq.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }

                Get();
            }
        }

        private void PUT(Classes.Type type)
        {
            try
            {
                int id = Items[dataGrid.SelectedIndex].TypeId;


                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://localhost:44387/api/Types/" + id));
                WebReq.ContentType = "application/json; charset=utf-8";
                WebReq.Accept = "application/json; charset=utf-8";
                WebReq.Method = "PUT";

                using (var streamWriter = new StreamWriter(WebReq.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(type);
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)WebReq.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch
            {

            }
        }

        private bool Validation()
        {
            bool valid = true;
            if (nameTxt.Text == "")
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Необходимо заполнить все поля";
                errorWindow.Show();
            }
            else if (!nameTxt.Text.ToCharArray().All(x => Char.IsLetter(x)))
            {
                valid = false;
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.errorText.Text = "Данные заполнены неверно";
                errorWindow.Show();
            }

            return valid;
        }
    }
}
