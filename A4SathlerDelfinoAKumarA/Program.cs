using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Aline Sathler Delfino & Ankit Kumar - Assignment 4
//Name of Project: Characters for an Adventure Game
//Purpose: C# console application to create and store records of characters for a simple adventure game. The program will track the name, character type, and the level of each character. The user will be able to add new characters, edit characters, delete characters, and view all characters stored in the program.
//Revision History:
//REV00 - 2023/11/13 - Initial version, adding and displaying characters
//REV01 - 2023/11/14 - Deleting characters
//REV02 - 2023/11/14 - Editing characters and refactoring methods
//REV03 - 2023/11/19 - Test Cases
//REV04 - 2023/11/21 - Refactoring methods

public static class Globals {
    public static List<string> characterName = new List<string>();
    public static List<string> characterType = new List<string>();
    public static List<uint> characterLevel = new List<uint>();
}

namespace A4SathlerDelfinoAKumarA {
    internal class Program {
        //Auxiliary methods

        //User's input
        //Method UserInputUInt to read an uint
        static uint UserInputUInt(string prompt) {
            uint userInput;

            Console.Write(prompt); //Ask the user an input

            Console.ForegroundColor = ConsoleColor.Yellow;  //Change text color the yellow
            userInput = Convert.ToUInt16(Console.ReadLine()); //Read the input
            Console.ResetColor();   //Reset color

            return userInput;
        }

        //User's input
        //Method UserInputString to read a string
        static string UserInputString(string prompt) {
            string userInput;

            Console.Write(prompt); //Ask the user an input

            Console.ForegroundColor = ConsoleColor.Yellow;  //Change text color the yellow
            userInput = Console.ReadLine(); //Read the input
            Console.ResetColor();   //Reset color

            return userInput;
        }

        //Method Menu to read user input
        static uint Menu(string prompt, uint menuMin, uint menuMax) {
            uint menuChoice;

            Console.WriteLine("\n" + prompt); //Printing the menu options

            //Calls method UserInputUInt and give prompt
            menuChoice = UserInputUInt("Please, enter your choice: ");

            //Checking if input in the range
            if (menuChoice < menuMin || menuChoice > menuMax) {
                throw new ArgumentOutOfRangeException();
            } else {
                return menuChoice;
            }
        }

        //Method AddName to add a character name
        static string AddName() {
            string characterName = "";

            //Adding a name
            //Calls method UserInputString and give prompt
            characterName = UserInputString("Please enter character name: ");

            if (string.IsNullOrEmpty(characterName)) {  //Check is name is blanket
                throw new ArgumentNullException("Character name cannot be null.");   //Throw ArgumentNullException
            } else if (Globals.characterName.Contains(characterName)) { //Check if name already exists
                throw new ArgumentException("Character already exists.");   //Throw ArgumentException
            }

            return characterName;
        }

        //Method AddType to add a character type
        static string AddType() {
            string characterType = "";

            //Adding a type
            //Calls method UserInputString and give prompt
            characterType = UserInputString("Please enter character type: ");

            if (string.IsNullOrEmpty(characterType)) {  //Check is type is blanket
                throw new ArgumentNullException("Character type cannot be null.");   //Throw ArgumentNullException
            }

            return characterType;
        }

        //Method AddLevel to add a character level
        static uint AddLevel() {
            uint characterLevel = 0;

            //Adding a level
            //Calls method UserInputUInt and give prompt
            characterLevel = UserInputUInt("Please enter character level (10 - 25): ");

            if (characterLevel < 10 || characterLevel > 25) {  //Check is level is in the correct range
                throw new ArgumentOutOfRangeException("Character level must be between 10 - 25.");
            }

            return characterLevel;
        }

        //Method Name to add character name
        static void Name() {
            string characterName;

            try {
                //Adding a name
                //Calls method AddName to add a character name
                characterName = AddName();

                //Replacing character name
                Globals.characterName.Add(characterName);
            } catch (ArgumentNullException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                Name(); //Calls Name again
            } catch (ArgumentException ex) {
                Console.WriteLine(ex.Message + " Let's try again.\n"); //Print error message
                Name(); //Calls Name again
            } catch (Exception) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Something went wrong. Let's try again.\n"); //Print error message
                Name(); //Calls Name again
            }
        }

        //Method Name to edit character name
        static void Name(int index) {
            string characterName;

            try {
                //Adding a name
                //Calls method AddName to add a character name
                characterName = AddName();

                //Adding character name
                Globals.characterName[index] = characterName;

                //Confirmation that the character name was edited
                Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                Console.WriteLine("\nThe name of the character has been changed.");
                Console.ResetColor();   //Reset color
            } catch (ArgumentNullException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                Name(index); //Calls Name again
            } catch (ArgumentException ex) {
                Console.WriteLine(ex.Message + " Let's try again.\n"); //Print error message
                Name(index); //Calls Name again
            } catch (Exception) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Something went wrong. Let's try again.\n"); //Print error message
                Name(index); //Calls Name again
            }
        }

        //Method Type to add character type
        static void Type() {
            string characterType;

            try {
                //Adding a type
                //Calls method AddType to add a character type
                characterType = AddType();

                //Adding character type
                Globals.characterType.Add(characterType);
            } catch (ArgumentNullException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                Type(); //Calls Type again
            } catch (Exception) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Something went wrong. Let's try again.\n"); //Print error message
                Type(); //Calls Type again
            }
        }

        //Method Type to edit character type
        static void Type(int index) {
            string characterType;

            try {
                //Adding a type
                //Calls method AddType to add a character type
                characterType = AddType();

                //Replacing character type
                Globals.characterType[index] = characterType;

                //Confirmation that the character name was edited
                Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                Console.WriteLine("\nThe type of the character has been changed.");
                Console.ResetColor();   //Reset color
            } catch (ArgumentNullException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                Type(index); //Calls EditType again
            } catch (Exception) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Something went wrong. Let's try again.\n"); //Print error message
                Type(index); //Calls EditType again
            }
        }

        //Method Level to add character level
        static void Level() {
            uint characterLevel;

            try {
                //Adding a level
                //Calls method AddLevel to add a character level
                characterLevel = AddLevel();

                //Adding character name
                Globals.characterLevel.Add(characterLevel);
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                Level(); //Calls Level again
            } catch (FormatException) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Invalid input. Let's try again.\n"); //Print error message
                Level(); //Calls Level again
            } catch (OverflowException) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Invalid input. Let's try again.\n"); //Print error message
                Level(); //Calls Level again
            } catch (Exception) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Something went wrong. Let's try again.\n"); //Print error message
                Level(); //Calls Level again
            }
        }

        //Method Level to edit character level
        static void Level(int index) {
            uint characterLevel;

            try {
                //Adding a level
                //Calls method AddLevel to add a character level
                characterLevel = AddLevel();

                //Replacing character name
                Globals.characterLevel[index] = characterLevel;

                //Confirmation that the character name was edited
                Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                Console.WriteLine("\nThe level of the character has been changed.");
                Console.ResetColor();   //Reset color
            } catch (ArgumentOutOfRangeException ex) {
                Console.WriteLine(ex.ParamName + " Let's try again.\n"); //Print error message
                Level(index); //Calls Level again
            } catch (FormatException) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Invalid input. Let's try again.\n"); //Print error message
                Level(index); //Calls Level again
            } catch (OverflowException) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Invalid input. Let's try again.\n"); //Print error message
                Level(index); //Calls Level again
            } catch (Exception) {
                Console.ResetColor();   //Reset color
                Console.WriteLine("Something went wrong. Let's try again.\n"); //Print error message
                Level(index); //Calls Level again
            }
        }

        //Main Methods
        //Method AddNewCharacter to add new character
        static void AddNewCharacter() {
            //Adding a name
            //Calls method Name to add a character name
            Name();

            //Adding a type
            //Calls method Type to add a character type
            Type();

            //Adding a level
            //Calls method Level to add a character level
            Level();

            //Confirmation that the character was added
            Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
            Console.WriteLine("\nYour record has been saved.");
            Console.ResetColor();   //Reset color
        }

        //Method EditCharacter to edit a character
        static void EditCharacter() {
            string characterName;
            uint menuChoice;
            int index;

            //Calls method UserInputString and give prompt
            characterName = UserInputString("\nPlease enter character name you would like to edit: ");

            index = Globals.characterName.IndexOf(characterName); //Index where character is

            if (index == -1) {  //Check if name doesn't exists
                Console.WriteLine("Character not found.");
            } else {
                //Display character information
                Console.WriteLine($"\nName\tType\tLevel");
                Console.WriteLine($"{Globals.characterName[index]}\t{Globals.characterType[index]}\t{Globals.characterLevel[index]}");

                do {
                    //Calls method Menu nad give prompt, minimun and maximum menu
                    menuChoice = Menu("1. Edit name\r\n2. Edit type\r\n3. Edit level\r\n4. Exit\r\n", 1, 4);

                    switch (menuChoice) {
                        case 1:
                            //Call method to edit name
                            Name(index);
                            break;
                        case 2:
                            //Call method to edit type
                            Type(index);
                            break;
                        case 3:
                            //Call method to edit level
                            Level(index);
                            break;
                        case 4:
                            Console.WriteLine("\nThe edition option will be closed.");
                            break;
                        default: throw new ArgumentOutOfRangeException(); //Throw error if input not between 1-4
                    }

                } while (menuChoice != 4);
            }
        }

        //Method DeleteCharacter to delete a character
        static void DeleteCharacter() {
            string characterName;
            int index;

            //Calls method UserInputString and give prompt
            characterName = UserInputString("\nPlease enter character name you would like to delete: ");

            index = Globals.characterName.IndexOf(characterName); //Index where character is

            if (index == -1) {  //Check if name doesn't exists
                Console.WriteLine("Character not found.");
            } else {
                string confirmation;

                //Calls method UserInputString and give prompt
                confirmation = UserInputString("Character found. Confirm delete (y/n)? "); //Confirm before deleting

                if (confirmation.ToLower() == "y") {
                    Globals.characterName.Remove(characterName); //Delete name
                    Globals.characterType.RemoveAt(index); //Delete type
                    Globals.characterLevel.RemoveAt(index); //Delete level

                    Console.ForegroundColor = ConsoleColor.Green;  //Change text color the green
                    Console.WriteLine("\nCharacter deleted.");
                    Console.ResetColor();   //Reset color
                } else if (confirmation.ToLower() == "n") {
                    Console.WriteLine("Delete canceled.");
                } else {
                    throw new ArgumentOutOfRangeException(); //Throw error if input not y or n
                }
            }
        }

        //Method DisplayCharacters to display all characters
        static void DisplayCharacters() {
            Console.WriteLine($"Name\tType\tLevel");
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
                            //Call method to edit a character
                            EditCharacter();

                            break;
                        case 3:
                            //Call method to delete a character
                            DeleteCharacter();

                            break;
                        case 4:
                            //Call method to display all characters
                            DisplayCharacters();

                            break;
                        case 5:
                            Console.WriteLine("\nThe program will be closed.");
                            break;
                        default: throw new ArgumentOutOfRangeException(); //Throw error if input not between 1-5
                    }

                } while (menuChoice != 5);


            } catch (ArgumentOutOfRangeException) {
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
