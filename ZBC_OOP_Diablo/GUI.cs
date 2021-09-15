using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZBC_OOP_Diablo
{
    public class GUI
    {
        private WeaponsFactory factory;

        public GUI(WeaponsFactory factory)
        {
            this.factory = factory;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;

                WeaponType weaponType;
                WeaponCategory weaponCategory = WeaponCategory.OneHanded;
                WeaponQuality weaponQuality = WeaponQuality.Legendary;
                Console.Clear();
                Console.WriteLine("Select weapon type:");

                int enumCount = Enum.GetValues(typeof(WeaponType)).Length;

                for (int i = 0; i < enumCount; i++)
                {
                    Console.WriteLine($"{i + 1} - {(WeaponType)i}");
                }

                Console.WriteLine();
                int typeInput = GetUserInputInteger(false, true);
                typeInput--;
                weaponType = (WeaponType)typeInput;
                bool correctInput = false;
                Console.Clear();

                while (!correctInput)
                {
                    Console.WriteLine("Select Category:");

                    Console.WriteLine("1 - One Handed");
                    Console.WriteLine("2 - Two Handed");

                    ConsoleKeyInfo c = Console.ReadKey();

                    if(c.Key == ConsoleKey.D1)
                    {
                        weaponCategory = (WeaponCategory)0;
                        correctInput = true;
                    } else if(c.Key == ConsoleKey.D2)
                    {
                        weaponCategory = (WeaponCategory)1;
                        correctInput = true;
                    } else
                    {
                        Console.WriteLine("\n\rIncorrect input!\n\r");
                    }
                }

                // WEAPON QUALITY
                Console.Clear();
                correctInput = false;

                while (!correctInput)
                {
                    Console.WriteLine("Select Quality:");

                    Console.WriteLine("1 - Blue");
                    Console.WriteLine("2 - Yellow");
                    Console.WriteLine("3 - Legendary");

                    ConsoleKeyInfo c = Console.ReadKey();

                    if (c.Key == ConsoleKey.D1)
                    {
                        weaponQuality = WeaponQuality.Blue;
                        correctInput = true;
                    }
                    else if (c.Key == ConsoleKey.D2)
                    {
                        weaponQuality = WeaponQuality.Yellow;
                        correctInput = true;
                    }
                    else if (c.Key == ConsoleKey.D3)
                    {
                        weaponQuality = WeaponQuality.Legendary;
                        correctInput = true;
                    }
                    else
                    {
                        Console.WriteLine("\n\rIncorrect input!\n\r");
                    }
                }

                Console.Clear();
                Weapon wpn = factory.CreateWeapon(weaponType, weaponCategory, weaponQuality);
                ShowWeapon(wpn);

                Console.ReadKey();


            }

           
        }

        /// <summary>
        /// Displays the weapon graphically
        /// </summary>
        /// <param name="weapon"></param>
        public void ShowWeapon(Weapon weapon)
        {
            Console.WriteLine("______________________________");
            if(weapon.Quality == WeaponQuality.Legendary)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Legendary {FormatWeaponCategory(weapon.Category)} {FormatWeaponTypeName(weapon)}");
            } else if (weapon.Quality == WeaponQuality.Yellow)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine($"{FormatWeaponCategory(weapon.Category)} {FormatWeaponTypeName(weapon)}");
                Console.WriteLine(weapon.Name);
            } else if(weapon.Quality == WeaponQuality.Blue)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                //Console.WriteLine($"{FormatWeaponCategory(weapon.Category)} {FormatWeaponTypeName(weapon)}");
                Console.WriteLine(weapon.Name);
            }

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"Dps: {weapon.WeaponDPS}");
            Console.WriteLine($"{weapon.BaseDamageMin}-{weapon.BaseDamageMax} Damage");
            Console.Write($"{weapon.BaseAttackSpeed}");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(" Attacks per Second\n\r");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Primary");

            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (WeaponAttribute attribute in weapon.Attributes)
            {
                if(attribute.Type == AttributeType.Primary)
                {
                    Console.WriteLine(attribute.GetTooltip());
                }                
            }

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Secondary");

            Console.ForegroundColor = ConsoleColor.Blue;

            foreach (WeaponAttribute attribute in weapon.Attributes)
            {
                if (attribute.Type == AttributeType.Secondary)
                {
                    Console.WriteLine(attribute.GetTooltip());
                }
            }

        }

        private string FormatWeaponCategory(WeaponCategory category)
        {
            if(category == WeaponCategory.OneHanded)
            {
                return "One-Handed";
            }
            else
            {
                return "Two-Handed";
            }
        }

        private string FormatWeaponTypeName(Weapon weapon)
        {
            switch (weapon.Type)
            {
                case WeaponType.CeremonialKnife:
                    return "Ceremonial Knife";

                case WeaponType.FistWeapon:
                    return "Fist Weapon";

                case WeaponType.MightyWeapon:
                    return "Mighty Weapon";

                default:
                    return weapon.Type.ToString();

            }
        }

        /// <summary>
        /// Requests the user to enter an integer with the corresponding request string, and
        /// makes sure the input is sanitized
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public int GetUserInputInteger(bool hideCursor = false, bool printError = false, string phrase = "")
        {
            string userInput = "";
            bool mainLoopRunning = true;

            while (mainLoopRunning)
            {
                if (phrase != "")
                {
                    Console.WriteLine(phrase);
                }

                // If we're hiding the cursor, use another method of collecting the input
                if (hideCursor)
                {
                    bool loopRunning = true;

                    while (loopRunning)
                    {
                        var key = Console.ReadKey(true);

                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }

                        userInput += key.KeyChar;
                    }
                }
                else
                {
                    userInput = Console.ReadLine();
                }


                // Empty input (only pressed enter for example)
                if (userInput.Length <= 0)
                {
                    if (printError) Console.WriteLine("Invalid input");
                    continue;
                }

                // Check that it only contains numbers
                if (!IsInputOnlyDigits(userInput))
                {
                    if (printError) Console.WriteLine("Invalid input: must only contain numbers");
                    continue;
                }
                else
                {
                    mainLoopRunning = false;
                }
            }

            return int.Parse(userInput);
        }

        /// <summary>
        /// Returns true if the string only contains digits
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool IsInputOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                // check that it's a number (unicode)
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
