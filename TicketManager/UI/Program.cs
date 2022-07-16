

// See https://aka.ms/new-console-template for more information


using UI;
using Services;
using DataAccess;

 new MainMenu(new AuthServices(new UserRepository())).Start();

// char[] letterGrades = {'A','B','C','D','F'};
// List<char> grades = new List<char>(letterGrades);
//  static char getGrade(int i, int i2, int i3)
// {
//   int avg = (i + i2 + i3) / 3;
//   if (avg >= 90)
//   return 'A';
//   else if (avg >= 80)
//   return 'B';
//   else if (avg >= 70)
//   return 'C';
//   else if (avg >= 60)
//   return 'D';
//   else
//   return 'F';
// }

// List<Int16> list = new List<Int16>();
// List with capacity = 5
// List<string> authors = new List<string>(5);
// string[] animals = { "Cow", "Camel", "Elephant" };
// List<string> animalsList = new List<string>(animals);

// Console.WriteLine(getGrade(52,45,77));