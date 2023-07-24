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
        public static User? session;
        public LoginScreen(DataContext _context)
        {
            context = _context;
        }
        public int Screen()
        {
            Console.Clear();
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            int? key = Convert.ToInt16(Console.ReadLine());
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
            return 0;
        }

        public int Login()
        {
            Console.Clear();
            Console.WriteLine("Type name");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Type password");
            Password = Convert.ToString(Console.ReadLine());

            var loggedUser = context.Users
                .Where(user => user.Name == Name)
                .Where(user => user.Password == Password)
                .FirstOrDefault();
            if(loggedUser == null) 
            {
                Console.WriteLine("Login incorrect");
                Console.ReadKey();
                return Screen();
            }
            Console.WriteLine(loggedUser.Name + loggedUser.Email + loggedUser.Password);
            session = loggedUser;
            Console.ReadKey();
           return 0;
        }

        public int Register()
        {
            Console.Clear();
            Console.WriteLine("Type name");
            Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Type email");
            Email = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Type password");
            Password = Convert.ToString(Console.ReadLine());

            var existUser = context.Users
                .Where(user => user.Name == Name)
                .FirstOrDefault();

            if(existUser != null) 
            { 
                Console.WriteLine("This user already exist");
                Console.ReadKey();
                return Screen();
            };

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
            return Screen();
        }
    }
}
