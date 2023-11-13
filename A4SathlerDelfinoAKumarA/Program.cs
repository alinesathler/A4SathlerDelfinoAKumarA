using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Aline Sathler Delfino & Ankit Kumar - Assignment 4
//Name of Project: Characters for an Adventure Game
//Purpose: C# console application to create and store records of characters for a simple adventure game. The program will track the name, character type, and the level of each character. The user will be able to add new characters, edit characters, delete characters, and view all characters stored in the program.
//Revision History:
//REV00 - 2023/11/13 - Initial version, adding and displaying characters

public static class Globals {
    public static List<string> characterName = new List<string>();
    public static List<string> characterType = new List<string>();
    public static List<uint> characterLevel = new List<uint>();
}

namespace A4SathlerDelfinoAKumarA {
    internal class Program {
        //Method Menu to read user input
        static uint Menu(string prompt, uint menuMin, uint menuMax) {
            uint menuChoice;

            Console.WriteLine("\n" + prompt);
            Console.Write("Please, enter your choice: ");

            Console.ForegroundColor = ConsoleColor.Yellow;  //Change text color the yellow
            menuChoice = Convert.ToUInt16(Console.ReadLine());
            Console.ResetColor();   //Reset color

            //Checking if input in the range
            if (menuChoice < menuMin || menuChoice > menuMax) {
                throw new ArgumentOutOfRangeException();
            } else {
                return menuChoice;
            }
        }

        //Method AddNewCharacter to add new character
        static void AddNewCharacter() {
            string characterName, characterType;
            uint characterLevel = 0;
            bool isName = false, isType = false, isLevel = false;

            try {
                //Adding a name
                Console.Write("Please enter character name: ");

                Console.ForegroundColor = ConsoleColor.Yellow;  //Change text color the yellow
                characterName = Console.ReadLine();
                Console.ResetColor();   //Reset color

                if (characterName == "") {  //Check is name is blanket
                    throw new ArgumentNullException("Character name cannot be null.");   //Throw ArgumentNullException
                } else if (Globals.characterName.Contains(characterName)) { //Check if name already exists
                    throw new ArgumentException("Character already exists.");   //Throw ArgumentException
                } else {
                    isName = true; //Character name is ok
                }

                //Adding a type
                Console.Write("Please enter character type: ");

                Console.ForegroundColor = ConsoleColor.Yellow;  //Change text color the yellow
                characterType = Console.ReadLine();
                Console.ResetColor();   //Reset color

                if (characterType == "") {  //Check is type is blanket
                    throw new ArgumentNullException("Character type cannot be null.");   //Throw ArgumentNullException
                } else {
                    isType = true; //Character type is ok
                }


                //Adding a level
                Console.Write("Please enter character level (10 - 25): ");

                Console.ForegroundColor = ConsoleColor.Yellow;  //Change text color the yellow
                characterLevel = Convert.ToUInt16(Console.ReadLine());
                Console.ResetColor();   //Reset color

                if (characterLevel < 10 || characterLevel > 25) {  //Check is level is in the correct range
                    throw new ArgumentOutOfRangeException("Character level must be between 10 - 25.");
                } else {
                    isLevel = true; //Character level is ok
                }


                //Adding character in the list
                if (isName && isType && isLevel) {
                    Globals.characterName.Add(characterName);   //Add character name
                    Globals.characterType.Add(characterType);   //Add character type
                    Globals.characterLevel.Add(characterLevel);   //Add character level

                    Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                    Console.WriteLine("\nYour record has been saved.");
                    Console.ResetColor();   //Reset color
                }
            } catch (ArgumentNullException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                AddNewCharacter(); //Calls AddNewCharacter again
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                AddNewCharacter(); //Calls AddNewCharacter again
            } catch (ArgumentException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                AddNewCharacter(); //Calls AddNewCharacter again
            } catch (Exception) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Something went wrong. Let's try again.\n"); //Print error message
                AddNewCharacter(); //Calls AddNewCharacter again
            }
        }

        //Method DisplayCharacters to display all characters
        static void DisplayCharacters() {
            Console.WriteLine($"\nName\tType\tLevel");
            for (int i = 0; i < Globals.characterName.Count; i++) {
                Console.WriteLine($"{Globals.characterName[i]}\t{Globals.characterType[i]}\t{Globals.characterLevel[i]}");
            }
        }

        static void Main() {
            uint menuChoice;

            Console.WriteLine("Welcome!!!");
            Console.WriteLine("------------------------");

            try {
                do {
                    //Calls method Menu nad give prompt, minimun and maximum menu
                    menuChoice = Menu("1. Add New Character\r\n2. Edit Existing Character\r\n3. Delete Character\r\n4. Display All Characters \r\n5. Exit \r\n", 1, 5);

                    switch (menuChoice) {
                        case 1:
                            //Call method to add new character
                            AddNewCharacter();

                            break;
                        case 2:
                            Console.WriteLine();

                            break;
                        case 3:
                            Console.WriteLine();

                            break;
                        case 4:
                            //Call method to display all characters
                            DisplayCharacters();

                            break;
                        case 5:
                            Console.WriteLine("\nThe program will be closed.");
                            break;
                        default: throw new ArgumentOutOfRangeException();
                    }

                } while (menuChoice != 5);
                

            } catch (ArgumentOutOfRangeException) {
                Console.ResetColor();   //Reset color

                Console.WriteLine("\nInput out of the range.");
            } catch (OverflowException) {
                Console.ResetColor();   //Reset color

                Console.WriteLine("\nThe format of the input isn't valid.");
            } catch (FormatException) {
                Console.ResetColor();   //Reset color

                Console.WriteLine("\nThe format of the input isn't valid.");
            } catch (Exception) {
                Console.ResetColor();   //Reset color

                Console.WriteLine("\nSomething went wrong.");
            } finally {
                Console.WriteLine("\nThanks for playing!\n");
            }
        }
    }
}
