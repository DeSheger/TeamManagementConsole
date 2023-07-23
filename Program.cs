// See https://aka.ms/new-console-template for more information
using LearningWithDotNet.Application;
using LearningWithDotNet.Models;
using LearningWithDotNet.Persistence;
using Microsoft.EntityFrameworkCore.Design;

DataContext context = new DataContext();

var loginScreen = new LoginScreen(context);

loginScreen.Screen();