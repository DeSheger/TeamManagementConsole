using LearningWithDotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWithDotNet.Application
{
    public class MainScreen
    {
        public User _loggedUser;

        public MainScreen(User loggedUser) 
        {
            _loggedUser = loggedUser;
        }

        public void Screen()
        {
            Console.Clear();
            Console.WriteLine("Hello "+_loggedUser.Name);
            Console.ReadKey();
        }
    }
}
