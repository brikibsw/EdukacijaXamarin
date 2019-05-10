using Adresar.Data;
using Adresar.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Adresar.ViewModels
{
    public class PersonListViewModel : BaseViewModel
    {
        public PersonListViewModel()
        {
            originalPersons = new List<Person>
            {
                new Person
                        {
                            Name = "Arijan Avramović",
                            Gender = "M",
                            BirthDate = new DateTime(1994, 5, 16),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Ivo Andrić",
                            Gender = "M",
                            BirthDate = new DateTime(1925, 10, 2),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Arijan Avramović",
                            Gender = "M",
                            BirthDate = new DateTime(1994, 5, 16),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Ivo Andrić",
                            Gender = "M",
                            BirthDate = new DateTime(1925, 10, 2),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Arijan Avramović",
                            Gender = "M",
                            BirthDate = new DateTime(1994, 5, 16),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Ivo Andrić",
                            Gender = "M",
                            BirthDate = new DateTime(1925, 10, 2),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Arijan Avramović",
                            Gender = "M",
                            BirthDate = new DateTime(1994, 5, 16),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Ivo Andrić",
                            Gender = "M",
                            BirthDate = new DateTime(1925, 10, 2),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Arijan Avramović",
                            Gender = "M",
                            BirthDate = new DateTime(1994, 5, 16),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Ivo Andrić",
                            Gender = "M",
                            BirthDate = new DateTime(1925, 10, 2),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Arijan Avramović",
                            Gender = "M",
                            BirthDate = new DateTime(1994, 5, 16),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Ivo Andrić",
                            Gender = "M",
                            BirthDate = new DateTime(1925, 10, 2),
                            Group = "A"
                        },
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        },
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        },
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        },
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        },
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        },
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        },
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        }
            };
            var grouped = originalPersons.GroupBy(a => a.Group).ToList();
            GroupedPersons = new List<IGrouping<string, Person>>(grouped);

            NewPersonCommand = new Command(NewPerson);
        }

        public ICommand NewPersonCommand { get; }

        private async void NewPerson()
        {
            await Navigation.PushAsync(new PersonPage());
        }

        private List<Person> originalPersons;

        private string _search;

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                OnSearch();
            }
        }

        private void OnSearch()
        {
            if (Search != null && Search.Length > 0)
            {
                var rezultat = originalPersons.Where(b => b.Name.ToUpper().Contains(Search.ToUpper()))
                                .GroupBy(a => a.Group);
                GroupedPersons = new List<IGrouping<string, Person>>(rezultat);

            }
            else
            {
                var grouped = originalPersons.GroupBy(a => a.Group).ToList();
                GroupedPersons = new List<IGrouping<string, Person>>(grouped);
            }
        }

        private List<IGrouping<string, Person>> _groupedPersons;

        public List<IGrouping<string, Person>> GroupedPersons
        {
            get { return _groupedPersons; }
            set
            {
                _groupedPersons = value;
                OnPropertyChanged(nameof(GroupedPersons));
            }
        }
    }
}
