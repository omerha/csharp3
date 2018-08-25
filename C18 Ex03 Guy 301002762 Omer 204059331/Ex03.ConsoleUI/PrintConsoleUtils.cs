using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class PrintConsoleUtils
    {
        public void PrintInsertLicseneIDQuestion (ref string io_LicsenseID, int i_Attemps)
        {
            if (i_Attemps==0)
            {
                Console.WriteLine("Type the licsense ID:");
            }
            else
            {
                Console.WriteLine("Wrong input, please try again.{0}Type the licsense ID:", Environment.NewLine);
            }
            io_LicsenseID = Console.ReadLine();
        }

        public void PrintMsgExistInTheGarage()
        {
            Console.WriteLine("The vehicle is exists in the garage. The vehicle is put into repair mode");
        }
    }
}
