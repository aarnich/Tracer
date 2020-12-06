using System;
using System.Collections.Generic;
using System.Text;
using Tracer.Models;

namespace Tracer.Services
{
    public class DataService
    {
        private static DataService _instance;
        public static DataService Instance
        {
            get { if (_instance == null) _instance = new DataService();
                return _instance;
            }
        }
        public List<Item> GetItems()
        {
            return new List<Item>
            {
                new Item{Name ="Item 1", Image="calendar.png",Price= 10, Description= "Test1"},
                new Item{Name ="Item 2", Image="function.png",Price= 20, Description= "Test2"},
                new Item{Name ="Item 3", Image="delete.png",Price= 30, Description= "Test3"},
                new Item{Name ="Item 4", Image="copy.png",Price= 40, Description= "Test4"}
            };
        }
    }
}
