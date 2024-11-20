using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WPFAndMVVM2.Models;

namespace WPFAndMVVM2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private PersonViewModel _selectedPerson;

        public PersonViewModel SelectedPerson
        {
            get { return _selectedPerson; }
            set 
            { 
                _selectedPerson = value;
                OnPropertyChanged(nameof(SelectedPerson));
            }
        }

        public ObservableCollection<PersonViewModel> PersonsVM { get; set; }
        private PersonRepository personRepo = new PersonRepository();

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainViewModel()
        {
            PersonsVM = new ObservableCollection<PersonViewModel>();
            foreach (var person in personRepo.GetAll())
            {
                PersonsVM.Add(new PersonViewModel(person));
            }
        }
        public void AddDefaultPerson()
        {
           Person person = personRepo.Add("Specify FirstName", "Specify LastName", 0, "Specify Phone");
           PersonViewModel personViewModel = new PersonViewModel(person);
           SelectedPerson = personViewModel;
            PersonsVM.Add(new PersonViewModel(person));
        }
    }
}
