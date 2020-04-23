using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App2.PageModels
{
    class ChartPageModel : BasePageModel
    {

        List<Entry> entries;
        public List<Entry> Entries
        {
            get { return entries; }
            set { entries = value; RaisePropertyChanged(); }
        }

        public ChartPageModel()
        {

              
        }
    }
}
