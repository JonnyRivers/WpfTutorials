using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewSource
{
    public class MainViewModel
    {
        private ObservableCollection<Person> m_items;
        private Person m_selectedItem;

        public MainViewModel()
        {
            m_items = new ObservableCollection<Person>
            {
                new Person { Name = "Frank", DateOfBirth = new DateTime(1989, 12, 6)},
                new Person { Name = "Mary", DateOfBirth = new DateTime(1977, 11, 21)},
                new Person { Name = "Bob", DateOfBirth = new DateTime(1993, 10, 21)},
                new Person { Name = "Tim", DateOfBirth = new DateTime(1979, 9, 21)},
            };
        }

        public ObservableCollection<Person> Items => m_items;
        public Person SelectedItem
        {
            get { return m_selectedItem; }
            set
            {
                if (value != m_selectedItem)
                {
                    m_selectedItem = value;
                }
            }
        }
    }
}
