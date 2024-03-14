using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace Projeto_Orientado_a_Objeto
{
    internal class GraphicInterface
    {
        //Method for string comparison
        public enum comperarison
        {
            sucess = 0,
            error = 1,
            depart = 2
        }

        //Method for message presentation
        public void messages(string pMessage)
        {
            ConsoleKeyInfo keyboard = new ConsoleKeyInfo();
            do
            {
                Console.WriteLine(pMessage);
                Console.WriteLine("Press enter to continue...");
                keyboard = Console.ReadKey(true);
            } while (keyboard.Key != ConsoleKey.Enter);
            Console.Clear();
        }

        //Method to add string in the system
        public comperarison inputString(ref string pInputString, string message)
        {
            comperarison goBack;
            Console.Write(message);
            string temporary = Console.ReadLine();
            if ((temporary == "e") || (temporary == "E"))
                goBack = comperarison.depart;
            else
            {
                pInputString = temporary;
                goBack = comperarison.sucess;
            }
            Console.Clear();
            return goBack;
        }

        //Method for adding dates to the system
        public comperarison inputDateTime(ref DateTime pInputDateTime, string message)
        {
            comperarison goBack;
            do
            {
                try
                {
                    Console.Write(message);
                    string temporary = Console.ReadLine();
                    if (temporary.ToLower() == "e")
                        goBack = comperarison.depart;
                    else
                    {
                        pInputDateTime = Convert.ToDateTime(temporary);
                        goBack = comperarison.sucess;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Exception: " + error.Message);
                    goBack = comperarison.error;
                    messages("");
                }
            } while (goBack == comperarison.error);
            Console.Clear();
            return goBack;
        }

        //Method for adding number to the system
        public comperarison inputNumber(ref UInt32 pInputNumber, string message)
        {
            comperarison goBack;
            do
            {
                try
                {
                    Console.Write(message);
                    string temporary = Console.ReadLine();
                    if (temporary.ToLower() == "e")
                        goBack = comperarison.depart;
                    else
                    {
                        pInputNumber = Convert.ToUInt32(temporary);
                        goBack = comperarison.sucess;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("Exception: " + error.Message);
                    goBack = comperarison.error;
                    messages("");
                }
            } while (goBack == comperarison.error);
            Console.Clear();
            return goBack;
        }

        //Attributes that point to date base
        DateBase dateBase;

        //Constructor
        public GraphicInterface(DateBase pDateBase)
        {
            dateBase = pDateBase;
        }

        //Method to print on screen
        public void printScreen(Registers pPerson)
        {
            Console.WriteLine("Begin-");
            Console.WriteLine("Name: " + pPerson.Name);
            Console.WriteLine("Doc: " + pPerson.Doc);
            Console.WriteLine("Birth: " + pPerson.DateOfBirth.ToString("dd/MM/yyyy"));
            Console.WriteLine("House: " + pPerson.HouseNumber);
            Console.WriteLine("end-");
        }

        //method to print on the screen the file in the list
        public void printScreenList(List<Registers> pDateList)
        {
            foreach (Registers person in pDateList)
            {
                printScreen(person);
            }
        }

        //Main method to register all user
        public comperarison registerUser()
        {
            Console.Clear();
            string name = "";
            string doc = "";
            DateTime birth = new DateTime();
            UInt32 house = 0;
            if (inputString(ref name, "Type the name, or press [E] to the exit: ") == comperarison.depart)
                return comperarison.depart;
            if (inputString(ref doc, "Type the doc, or press [E] to the exit: ") == comperarison.depart)
                return comperarison.depart;
            if (inputDateTime(ref birth, "Type the date of brth, or press [E] to the exit: ") == comperarison.depart)
                return comperarison.depart;
            if (inputNumber(ref house, "Type the house number, or press [E] to the exit: ") == comperarison.depart)
                return comperarison.depart;
            Registers resgistring = new Registers(name, doc, birth, house);
            dateBase.putPeople(resgistring);
            Console.WriteLine("Added user to file successfully");
            Console.WriteLine("-");
            printScreen(resgistring);
            messages("");
            return comperarison.sucess;
        }

        //Method call to search in the list
        public void searchInList()
        {
            Console.Clear();
            Console.Write("Type the doc, or press [S] to the exit: ");
            string temporary = Console.ReadLine();
            if (temporary.ToLower() == "s")
                return;
            else
            {
                List<Registers> temporaryList = dateBase.searchInList(temporary);
                Console.Clear();
                if (temporaryList != null)
                {
                    Console.WriteLine("Successfully found the user in the file");
                    printScreenList(temporaryList);
                }
                else
                    Console.WriteLine("Unable to find user in file successfully");
                messages("");
            }
        }

        //Method call to remove in the list
        public void removeInList()
        {
            Console.Clear();
            Console.Write("Type the doc, or press [S] to the exit: ");
            string temporary = Console.ReadLine();
            if (temporary.ToLower() == "s")
                return;
            else
            {
                List<Registers> temporaryList = dateBase.removeInList(temporary);
                Console.Clear();
                if (temporaryList != null)
                {
                    Console.WriteLine("Successfully found the user in the file");
                    printScreenList(temporaryList);
                }
                else
                    Console.WriteLine("Unable to find user in file successfully");
                messages("");
            }
        }

        //Method to end the system
        public void end()
        {
            Console.Clear();
            messages("Shutting down the system");
        }

        //Method to non-existent key
        public void non_existent()
        {
            Console.Clear();
            messages("Non-existent option in system");
        }

        //Initialization of system methods
        public void initialization()
        {
            string option;
            do
            {
                Console.WriteLine("Press [R] to register the user");
                Console.WriteLine("-");
                Console.WriteLine("Press [S] to search for a user in  the system");
                Console.WriteLine("-");
                Console.WriteLine("Press [D] to delete a user in the system");
                Console.WriteLine("-");
                Console.WriteLine("Press [E] to shutting the system");
                Console.WriteLine("-");
                option = Console.ReadKey(true).KeyChar.ToString().ToLower();
                switch (option)
                {
                    case "r":
                        registerUser();
                        break;
                    case "s":
                        searchInList();
                        break;
                    case "d":
                        removeInList();
                        break;
                    case "e":
                        end();
                        break;
                    default:
                        non_existent();
                        break;
                }
            } while (option != "e");
        }
    }
}
