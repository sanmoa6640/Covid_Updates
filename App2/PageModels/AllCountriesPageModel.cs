using App2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2.PageModels
{
    class AllCountriesPageModel : BasePageModel
    {
        List<Country> countryList;
        public List<Country> CountryList
        {
            get { return countryList; }
            set { countryList = value; RaisePropertyChanged(); }
        }
        Country countrySelected;
        public Country CountrySelected
        {
            get { return countrySelected; }
            set
            {
                if(value != null)
                {
                    countrySelected = value;
                    RaisePropertyChanged();
                    GoToCountryDetail();
                }
                
            }
        }
        string filter;
        public string Filter
        {
            get { return filter; }
            set
            {
                if (value != null)
                {
                    filter = value;
                    RaisePropertyChanged();
                    SearchAction();
                }

            }
        }
        public Command SearchCountryCommand => new Command(async () => await SearchAction());

        

        public AllCountriesPageModel()
        {
            GetCountries();

        }

        private void GetCountries()
        {
            if (Application.Current.Properties.ContainsKey("Report"))
            {
                string report = Application.Current.Properties["Report"].ToString();
                StatusInfo status = JsonConvert.DeserializeObject<StatusInfo>(report);
                CountryList = status.Countries;

            }
        }
        private async Task GoToCountryDetail()
        {
            Application.Current.Properties["SelectedCountry"] = JsonConvert.SerializeObject(CountrySelected);
            await PushAsync<CountryDetailPageModel>();
                
        }
        private async Task SearchAction()
        {
            string report = Application.Current.Properties["Report"].ToString();
            StatusInfo status = JsonConvert.DeserializeObject<StatusInfo>(report);
            
            if (string.IsNullOrWhiteSpace(Filter))
            {
                CountryList = status.Countries;
            }
            else
            {
                CountryList.Clear();
                CountryList = status.Countries.Where(x => x.CountryCountry.StartsWith(Filter, StringComparison.InvariantCultureIgnoreCase))
                        .ToList<Country>();
            }

        }
    }
}
