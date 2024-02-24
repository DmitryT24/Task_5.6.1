using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_5._6._1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Outscreen(EnterUserData());
            Console.ReadKey();
        }

        static (string Name, string Surname, int Age, string[] AnimalsName, string[] LikeColors) EnterUserData()
        {
            (string Name, string Surname, int Age, string[] AnimalsName, string[] LikeColors) UserData;
            Console.WriteLine("Здравствуйте, расскажите немного о себе!");
            Console.Write("Введите ваше Имя: ");
            UserData.Name = Console.ReadLine();

            Console.Write("Введите вашу Фамилию: ");
            UserData.Surname = Console.ReadLine();

            string str;
            do
            {
                Console.Write("Введите ваш возраст: ");
                str = Console.ReadLine();
            } while (!EnterCorrect(str, out UserData.Age));

            UserData.AnimalsName = UserInfo("питомец");
            UserData.LikeColors = UserInfo("любимый цвет");
            
            return UserData;
        }

        static string[] UserInfo(string str)
        {
            string[] UserStr;
        UserGoto:
            Console.Write("У вас есть {0} (да/нет)?: ", str);
            string strNum;
            switch (Console.ReadLine())
            {
                case "да":
                    {
                        int numb;
                        do
                        {
                            Console.Write("Введите их количество : ");
                            strNum = Console.ReadLine();
                        } while (!EnterCorrect(strNum, out numb));
                        UserStr = EnterData(numb, str); 

                        break;
                    }
                case "нет":
                    UserStr = null;
                    break;
                default:
                    Console.Write("Неверный ввод, пожалуйта повторите!");
                    goto UserGoto;
                    //break;
            }
            return UserStr;
        }


        static string[] EnterData(int number, string str)
        {
            string[] data = new string[number];
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("Введите (имя/название) {0} из {1}: ", i + 1, number);
                data[i] = Console.ReadLine();
                if(data[i].Length == 0)
                {
                    Console.WriteLine("Некорректный ввод, повторите!");
                    i--;
                }
            }
            return data;
        }

        static bool EnterCorrect(string str, out int namber)
        {
            namber = 0;

            if (int.TryParse(str, out int result) && (result > 0))
            {
                namber = result;
                return true;
            }
            Console.WriteLine("Некоректный ввод, повторите пожалуйста!");
            return false;
        }

        static void Outscreen((string Name, string Surname, int Age, string[] AnimalsName, string[] LikeColors) userdata)
        {
            Console.WriteLine("\nВаше имя: {0}", userdata.Name);
            Console.WriteLine("Ваша фамилия: {0}", userdata.Surname);
            Console.WriteLine("Ваш возраст: {0}", userdata.Age);

            if (userdata.AnimalsName != null)
            {
                Console.WriteLine("Клички ваших питомцев:");
                foreach (string s in userdata.AnimalsName)
                {
                    Console.WriteLine("   " + s);
                }
            }

            if (userdata.LikeColors != null)
            {
                Console.WriteLine("Любимый цвет:");
                foreach (string s in userdata.LikeColors)
                {
                    Console.WriteLine("   " + s);
                }
            }
        }
    }
}
