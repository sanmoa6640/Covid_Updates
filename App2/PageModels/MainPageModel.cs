using App2.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.PageModels
{
    class MainPageModel : BasePageModel
    {
        globalData globalData;
        public globalData GlobalData
        {
            get { return globalData; }
            set { globalData = value; RaisePropertyChanged(); }
        }
        StatusInfo statusData;
        public StatusInfo StatusData
        {
            get { return statusData; }
            set { statusData = value; RaisePropertyChanged(); }
         }

        public Command ListCountriescommand => new Command(async () => await GoToListCountries());

        public MainPageModel()
        {
            GetInfo();
        }

        private void GetInfo()
        {
            IsBusy = true;
            var client = new RestClient("https://api.covid19api.com/summary");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            StatusInfo status  = JsonConvert.DeserializeObject<StatusInfo>(response.Content);
            GlobalData = status.Global;
            StatusData = status;
            Application.Current.Properties["Report"] = response.Content;
            IsBusy = false;

        }

        private async Task GoToListCountries()
        {
            await PushAsync<AllCountriesPageModel>();
        }

    }

}
