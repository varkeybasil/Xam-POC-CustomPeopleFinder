using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static PeopleFinder.Model;

namespace PeopleFinder
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void newpersonpicked(object sender, ItemTappedEventArgs e)
        {
           

            ((MainPageViewModel)this.BindingContext).SelectedPerson = (Employee)e.Item;
           
           
        }
    }
}
