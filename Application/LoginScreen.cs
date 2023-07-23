using LearningWithDotNet.Models;
using LearningWithDotNet.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningWithDotNet.Application
{
    public class LoginScreen
    {
        private string Name;
        private string Email;
        private string Password;
        public DataContext context;
        public LoginScreen(DataContext _context)
        {
            context = _context;
        }
        public void Screen()
        {
            Console.Clear();
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            int key = Convert.ToInt16(Console.ReadLine());
            switch (key) 
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Register();
                    break;
                default:
                    Console.WriteLine("Bad number");
                    Screen();
                    break;
            }
        }

        public void Login()
        {
            Console.Clear();
            Console.WriteLine("Type name");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Type password");
            Password = Convert.ToString(Console.ReadLine());

            var loggedUser = context.Users
                .Where(user => user.Name == Name)
                .Include(user => user.Password == Password);

            Console.WriteLine(loggedUser);
           
        }

        public void Register()
        {
            Console.Clear();
            Console.WriteLine("Type name");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Type email");
            Email = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Type password");
            Password = Convert.ToString(Console.ReadLine());
       
            Console.ReadKey();
            User registerUser = new User()
            {
                Name = Name,
                Email = Email,
                Password = Password
            };
            context.Users.Add(registerUser);
            context.SaveChanges();
            Console.WriteLine("Succesfull registred - enter key to back");
            Console.ReadKey();
        }
    }
}
