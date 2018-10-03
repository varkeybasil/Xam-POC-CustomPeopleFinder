using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using static PeopleFinder.Model;

namespace PeopleFinder
{
    public class MainPageViewModel : INotifyPropertyChanged  
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;   
            }
            set
            {
                if (_name!= value)  
                {  
                    _name= value;  
                    OnPropertyChanged("Name");  
                }  
            }
        }

        public Employee selectedPerson;
        public Employee SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                if (selectedPerson!= value)  
                {  
                    selectedPerson= value;  
                    OnPropertyChanged("SelectedPerson");  
                }  
            }
        }

        public ICommand ClickCommand => new Command(() => OnClickCommand());

        private void OnClickCommand()
        {
            var p = SelectedPerson;
        }
        public MainPageViewModel()
        {
            Name = "PeopleFinder"; 
        }
      
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
