using System;
using Application.Models;
using Application.Services;
using System.Collections.Generic;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var userService = new UserService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nUser Management System");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. List All Users");
                Console.WriteLine("3. Search User by ID");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddUser(userService);
                        break;
                    case "2":
                        ListUsers(userService);
                        break;
                    case "3":
                        SearchUserById(userService);
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Exiting application...");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddUser(UserService userService)
        {
            Console.WriteLine("\nAdd User:");
            Console.Write("Enter ID: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter Role (Admin/Regular): ");
            string role = Console.ReadLine()?.ToLower() ?? string.Empty;

            UserBase user;

            if (role == "admin")
            {
                user = new AdminUser { Id = id, Name = name, Email = email };
            }
            else if (role == "regular")
            {
                user = new RegularUser { Id = id, Name = name, Email = email };
            }
            else
            {
                Console.WriteLine("Invalid role. User not added.");
                return;
            }

            userService.AddUser(user);
            Console.WriteLine($"User {name} added successfully!");
        }

        static void ListUsers(UserService userService)
        {
            Console.WriteLine("\nList of All Users:");
            var users = userService.GetAllUsers();

            if (users.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Role: {user.GetRole()}");
            }
        }

        static void SearchUserById(UserService userService)
        {
            Console.Write("\nEnter User ID to search: ");
            int id = int.Parse(Console.ReadLine() ?? "0");

            try
            {
                var user = userService.GetUserById(id);
                Console.WriteLine($"User found - ID: {user.Id}, Name: {user.Name}, Email: {user.Email}, Role: {user.GetRole()}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
