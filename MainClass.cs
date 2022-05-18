using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            ConsoleKey consoleKey;
            DateTime now = DateTime.Now;
            if (now.DayOfWeek != DayOfWeek.Sunday)
            {
                Human human = new Human();
                Human[] humans ={ new Student(), new Botan(), new Girl(), new PrettyGirl(), new SmartGirl()};

                do
                {
                    Random random = new Random();
                    var firstIndex = random.Next(humans.Length);
                    var secondIndex = random.Next(humans.Length);

                    Console.WriteLine($"Перша людина: {humans[firstIndex].GetType().Name}\n");
                    Console.WriteLine($"Друга людина: {humans[secondIndex].GetType().Name}\n");
                    try
                    {
                        Human.CheckCouple(humans[firstIndex], humans[secondIndex]);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    IHasName child = human.Couple(humans[firstIndex], humans[secondIndex]);
                    if (child != null)
                    {
                        Console.WriteLine($"\nІм'я: {child.GetType().GetProperty("Name")?.GetValue(child)}");
                        Console.WriteLine($"Surname: {child.GetType().GetProperty("Surname")?.GetValue(child)}");
                        Console.WriteLine($"ChildType: {child}");
                    }
                    consoleKey = Console.ReadKey(false).Key;
                } while (consoleKey != ConsoleKey.F10 && consoleKey != ConsoleKey.Q && consoleKey.ToString() != "q");
            }
            else
            {
                Console.WriteLine("Сьогодні неділя!");
            }
        }
    }
}
