using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        private PrintConsoleUtils m_ConsoleUtils = new PrintConsoleUtils();
        public static void Main()
        {
        }

        public void InsertNewVehicleIntoTheGarage()
        {
            string userInput = null;
            int attemps = 0;
            bool tmp = false; //Just until we decide if we need to check validate about LicsenseId
            m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref userInput, attemps);
            while (tmp) //Need to check something about the LicsensId length or numerical??
            {
                m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref userInput, ++attemps);
            }
            if (IsTheVehiclesExsitsInTheGarage(userInput))
            {
                m_ConsoleUtils.PrintMsgExistInTheGarage();
                //move to repair mode
            }
        }

        public bool IsTheVehiclesExsitsInTheGarage(string i_LisceneID)
        {
            bool isExists = false;


            return isExists;
        }

    }
}
