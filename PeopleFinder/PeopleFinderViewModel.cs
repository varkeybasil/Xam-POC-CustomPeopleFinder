using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Linq;
using MvvmHelpers;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static PeopleFinder.Model;

namespace PeopleFinder
{
    public class PeopleFinderViewModel : INotifyPropertyChanged  
    {



        public string searchText;
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                if (searchText!= value)  
                {  
                    searchText= value;  
                    OnPropertyChanged("SearchText");  
                }  
            }
        }

        public List<Employee> EmployeeList
        {
            get;
            set;
        }

        ObservableRangeCollection<Employee> employeeList = new ObservableRangeCollection<Employee>();
        public ObservableRangeCollection<Employee> EmployeeFilteredList
        {
            get
            {
                return employeeList;
            }
            set
            {
                if (employeeList!= value)  
                {  
                    employeeList= value;  
                    OnPropertyChanged("EmployeeList");  
                }  
            }
        }
        private const string Url = "http://www.json-generator.com/api/json/get/bPLlUnSVrC?indent=2";
        private HttpClient _client = new HttpClient();
        public ICommand  SearchCommand=> new Command(() => OnSearchCommand());

        private void OnSearchCommand()
        {
            var results = EmployeeList.Where(s => s.name.ToLower().Contains(SearchText.ToLower().Trim()) ).ToList();
            EmployeeFilteredList.ReplaceRange(results);
        }

        public PeopleFinderViewModel()
        {
            InitListAsync(); 
        }

        private async Task InitListAsync()
        {
            EmployeeList = new List<Employee>();
            var content = await _client.GetStringAsync(Url);
            var tr = JsonConvert.DeserializeObject<List<RootObject>>(content);
            EmployeeList = tr.ElementAt(0).employees;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
