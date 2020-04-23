using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.PageModels
{
    class CountryDetailPageModel : BasePageModel
    {
        Country  countrySelected;
        public Country CountrySelected
        {
            get { return countrySelected; }
            set { countrySelected = value; RaisePropertyChanged(); }
        }

        public CountryDetailPageModel()
        {
            CallDataCountry();
        }

        private void CallDataCountry()
        {
            if (Application.Current.Properties.ContainsKey("SelectedCountry"))
            {
                string countrySelected = Application.Current.Properties["SelectedCountry"].ToString();
                Country CountryData = JsonConvert.DeserializeObject<Country>(countrySelected);
                CountrySelected = CountryData;
            }
        }
    }
}
