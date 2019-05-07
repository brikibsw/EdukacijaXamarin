using Adresar.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Adresar.ViewModels
{
    public class PersonListViewModel : BaseViewModel
    {
        public PersonListViewModel()
        {
            var a = new GroupedPerson
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
                        }
                    };
            a.Group = "A";
            var b = new GroupedPerson
                    {
                        new Person
                        {
                            Name = "Djuro Basariček",
                            Gender = "M",
                            BirthDate = new DateTime(1955, 9, 5),
                            Group = "B"
                        }
                    };
            b.Group = "B";
            GroupedPersons = new List<GroupedPerson>
            {
                a,
                b
            };
        }




        private List<GroupedPerson> _groupedPersons;

        public List<GroupedPerson> GroupedPersons
        {
            get { return _groupedPersons; }
            set
            {
                _groupedPersons = value;
                OnPropertyChanged(nameof(GroupedPersons));
            }
        }
    }

    public class GroupedPerson : List<Person>
    {
        public string Group { get; set; }

        public List<Person> Persons => this;
    }
}
