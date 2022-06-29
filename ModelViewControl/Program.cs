using Models;
Console.WriteLine("Hello, World!");
// string[] love = {"Sex","Love","Fornication","Truth","Focus","Compassion"};

// for(int i = 0; i < love.Length; i++){
//   Console.WriteLine($"{love[i]}");
// }

// Array.Sort(love);
// Console.WriteLine();
// foreach(string Thing in love)
// {
//   Console.WriteLine($"{Thing}");
// }

FromModel manager = new FromModel();
FromModel manager2 = new FromModel();
manager.employeeName = "Tarzan";
manager2.employeeName = "peter";
string n = manager.employeeName;
Console.WriteLine(n);
Console.WriteLine(manager2.employeeName);