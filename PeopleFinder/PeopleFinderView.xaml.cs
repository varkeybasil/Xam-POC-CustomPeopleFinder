using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static PeopleFinder.Model;

namespace PeopleFinder
{
    public partial class PeopleFinderView : ContentView
    {


        public PeopleFinderView()
        {
            InitializeComponent();

        }
        private void rideAlongListItemTapped(object sender, EventArgs e)
        {

            var item  = RideAlongList.SelectedItem;
            this.People = (Employee)item;
            Peoplepicked?.Invoke(this, e);

        }

        Employee temp = new Employee();
        public static readonly BindableProperty PeopleProperty = BindableProperty.Create(
            nameof(People),
            typeof(Employee),   // The type of the property you are creating
            typeof(ContentView),    // The type of your containing class
            default(Employee),      // The default value of the property you are creating
    propertyChanged: (BindableObject bindable, object old_value, object new_value) =>
    {
        ((PeopleFinderView)bindable).UpdatePeopleValue((Employee)old_value, (Employee)new_value);
    });

        private void UpdatePeopleValue(Employee old_value, Employee new_value)
        {
        //    Peoplepicked?.Invoke(this, e);
           
        }



        public Employee People
        {
            get
            {
                return (Employee)GetValue(PeopleProperty);
            }
            set
            {
                SetValue(PeopleProperty, value);
            }
        }

        public event EventHandler<EventArgs> Peoplepicked;


    }
}
