using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Program;


namespace Ex03.ConsoleUI
{
    public class PrintConsoleUtils
    {
        public void PrintInsertLicseneIDQuestion(ref string io_LicsenseID, int i_Attempts)
        {
            if (i_Attempts == 0)
            {
                Console.WriteLine("Type the licsense ID:");
            }
            else
            {
                Console.WriteLine("Wrong input, please try again.{0}Type the licsense ID:", Environment.NewLine);
            }
            io_LicsenseID = Console.ReadLine();
        }
        public void PrintModelNameQuestion(ref string io_LicsenseID)
        {
            Console.WriteLine("Type the vehicle model name:");
            io_LicsenseID = Console.ReadLine();
        }
        public void PrintWheelManufacQuestion(ref string io_LicsenseID)
        {
            Console.WriteLine("Type the wheel Manufacturer name:");
            io_LicsenseID = Console.ReadLine();
        }
        public void PrintVehicleOwnerQuestion(ref string io_LicsenseID)
        {
            Console.WriteLine("Type the vehicle owner name:");
            io_LicsenseID = Console.ReadLine();
        }
        public void PrintVehicleOwnerPhoneQuestion(ref string io_LicsenseID)
        {
            Console.WriteLine("Type the vehicle owner phone number:");
            io_LicsenseID = Console.ReadLine();
        }
        public void PrintExceptionError(string i_ExceptionMessage)
        {
            Console.WriteLine(i_ExceptionMessage);
        }
        public void PrintEnergyLeftQuestion(ref float io_UserChoice, int i_Attempts)
        {
            bool inputIsOk = false;
            string userInput;
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type how much energy is left in your vehicle (liters or hours):");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type how much energy is left in your vehicle (liters or hours):", Environment.NewLine);
                }
                userInput = Console.ReadLine();
                if (float.TryParse(userInput, out io_UserChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;
            }
        }
        public void PrintTruckBoxVolume(ref float io_UserChoice, int i_Attempts)
        {
            bool inputIsOk = false;
            string userInput;
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type your truck trunk volume:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type your truck trunk volume:", Environment.NewLine);
                }
                userInput = Console.ReadLine();
                if (float.TryParse(userInput, out io_UserChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;
            }
        }
        public void PrintTruckTrunkCoolQuestion(ref bool io_UserChoice, int i_Attempts)
        {
            StringBuilder menuOptions = new StringBuilder();
            bool inputIsOk = false;
            string userInput;
            int userAnswer = 0;
            menuOptions.AppendLine("1. Yes");
            menuOptions.AppendLine("2. No");
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Is your truck's trunk has cooling system? (Choose one of the options below)");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type your truck trunk volume:", Environment.NewLine);

                }
                Console.WriteLine(menuOptions);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out userAnswer))
                {
                    inputIsOk = true;
                    if (userAnswer == 2)
                    {
                        io_UserChoice = false;
                    }
                    else
                    {
                        io_UserChoice = true;
                    }
                }
                i_Attempts++;
            }
        }
        public void PrintCurrentAirPressureEnergy(ref float io_UserChoice, int i_Attempts)
        {
            bool inputIsOk = false;
            string userInput;
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type the current wheels air pressure:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type the current wheels air pressure:", Environment.NewLine);
                }
                userInput = Console.ReadLine();
                if (float.TryParse(userInput, out io_UserChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;
            }
        }
        public void PrintBikeEngineVolumeQuestion(ref int io_UserChoice, int i_Attempts)
        {
            bool inputIsOk = false;
            string userInput;
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type your bike engine's volume:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type your bike engine's volume:", Environment.NewLine);
                }
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out io_UserChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;
            }
        }
        public void PrintMenuAndGetUserChoice(ref int io_UserChoice, int i_Attempts)
        {
            bool inputIsOk = false;
            string userInput;
            StringBuilder menu = new StringBuilder();
            menu.AppendLine("1. Insert new vehicle to the Garage");
            menu.AppendLine("2. Display the vehicles in the garage based on license ID");
            menu.AppendLine("3. Change the status of vehicle in the garage");
            menu.AppendLine("4. Blow your vehcile's wheels air pressure");
            menu.AppendLine("5. Fill gas in your vehicle");
            menu.AppendLine("6. Charge you vehcile's battery");
            menu.AppendLine("7. Display full details of vehicle according to license number");
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type your choice from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type your choice from the list below:", Environment.NewLine);
                }
                Console.WriteLine(menu);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out io_UserChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;
            }
        }
        public void PrintCarSelectionAndGetInput(ref int io_UserChoice, ref int io_EngineChoice, int i_Attempts)
        {
            StringBuilder menuChoices = new StringBuilder();
            int lineNum = 1;
            bool inputIsOk = false;
            string userInput;
            foreach (string value in Enum.GetNames(typeof(GarageLogic.Program.eVehicleType)))
            {
                menuChoices.AppendLine(lineNum + ". " + value);
                lineNum++;
            }
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type your choice from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type your choice from the list below:", Environment.NewLine);
                }
                Console.WriteLine(menuChoices);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out io_UserChoice))
                {
                    if (io_UserChoice != (int)GarageLogic.Program.eVehicleType.Truck)
                    {
                        PrintEngineSelectionAndGetInput(ref io_EngineChoice, 0);
                    }
                    else
                    {
                        io_EngineChoice = (int)eEngineType.Gas;
                    }
                    inputIsOk = true;
                }
                i_Attempts++;

            }

        }
        public void PrintStatusUpdated()
        {
            Console.WriteLine("Vehicle stats updated. ");
        }
        public void PrintEngineSelectionAndGetInput(ref int io_EngineChoice, int i_Attempts)
        {
            StringBuilder menuChoices = new StringBuilder();
            int lineNum = 1;
            bool inputIsOk = false;
            string userInput;
            foreach (string value in Enum.GetNames(typeof(GarageLogic.Program.eEngineType)))
            {
                menuChoices.AppendLine(lineNum + ". " + value);
                lineNum++;
            }
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type your choice from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type your choice from the list below:", Environment.NewLine);
                }
                Console.WriteLine(menuChoices);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out io_EngineChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;

            }

        }
        public void PrintMsgExistInTheGarage()
        {
            Console.WriteLine("The vehicle is exists in the garage. The vehicle is put into repair mode");
        }
        public void PrintLicenseTypeChoicesQuestion(ref int io_LicenseTypeChoice, int i_Attempts)
        {
            StringBuilder menuChoices = new StringBuilder();
            int lineNum = 1;
            bool inputIsOk = false;
            string userInput;
            foreach (string value in Enum.GetNames(typeof(GarageLogic.Program.eLicenseType)))
            {
                menuChoices.AppendLine(lineNum + ". " + value);
                lineNum++;
            }
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Type your choice from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Type your choice from the list below:", Environment.NewLine);
                }
                Console.WriteLine(menuChoices);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out io_LicenseTypeChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;

            }

        }
        public void PrintCarColorQuestion(ref int io_ColorChoice, int i_Attempts)
        {
            StringBuilder menuChoices = new StringBuilder();
            int lineNum = 1;
            bool inputIsOk = false;
            string userInput;
            foreach (string value in Enum.GetNames(typeof(GarageLogic.Program.eCarColor)))
            {
                menuChoices.AppendLine(lineNum + ". " + value);
                lineNum++;
            }
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Select the color from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Select the color from the list below:", Environment.NewLine);
                }
                Console.WriteLine(menuChoices);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out io_ColorChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;

            }

        }
        public void PrintCarNumOfDoorsQuestion(ref int io_ColorChoice, int i_Attempts)
        {
            StringBuilder menuChoices = new StringBuilder();
            int lineNum = 1;
            bool inputIsOk = false;
            string userInput;
            foreach (string value in Enum.GetNames(typeof(GarageLogic.Program.eNumOfDoors)))
            {
                menuChoices.AppendLine(lineNum + ". " + value);
                lineNum++;
            }
            while (!inputIsOk)
            {
                if (i_Attempts == 0)
                {
                    Console.WriteLine("Select the number of doors from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Select the number of doors from the list below:", Environment.NewLine);
                }
                Console.WriteLine(menuChoices);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out io_ColorChoice))
                {
                    inputIsOk = true;
                }
                i_Attempts++;

            }

        }

        public void VehiclesStatusFilterMenuAndGetInput(ref int o_UserChoice)
        {
            StringBuilder menuChoices = new StringBuilder();
            int lineNum = 1;
            int attemptsSelection = 0;
            bool inputIsOk = false;
            string userInput;
            string msgLine;
            foreach (string value in Enum.GetNames(typeof(GarageLogic.Program.eStatusVehicle)))
            {
                msgLine = string.Format("{0}. Display just the vehicles in {1} status.", lineNum, value);
                menuChoices.AppendLine(msgLine);
                lineNum++;
            }
            msgLine = string.Format("{0}. Display all the vehicles.", lineNum);
            menuChoices.AppendLine(msgLine);
            while (!inputIsOk)
            {
                if (attemptsSelection == 0)
                {
                    Console.WriteLine("Select the status filter from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Select the status filter from the list below: ", Environment.NewLine);
                }
                Console.WriteLine(menuChoices);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out o_UserChoice))
                {
                    inputIsOk = true;
                }
                attemptsSelection++;
            }
        }

        public void PrintLicenseIDOfVehiclesInTheGarage(StringBuilder i_LicenseIDToPrint)
        {
            if (i_LicenseIDToPrint.Length > 0)
            {
                Console.WriteLine(i_LicenseIDToPrint);
            }
            else
            {
                Console.WriteLine("Not exist vehicle in the garage! (with your selected filter)");
            }
        }

        public void PrintVehicleDetails(StringBuilder i_VehicleDetails, bool i_IsFoundCar, string i_LicenseID)
        {
            if (i_IsFoundCar)
            {
                Console.WriteLine(i_VehicleDetails);
            }
            else
            {
                Console.WriteLine("There isn't vehicle with the license number: {0} in the garage!!!", i_LicenseID);
            }
        }
        public void PrintAirPressureUpdated( bool i_IsFoundCar, string i_LicenseID)
        {
            if (i_IsFoundCar)
            {
                Console.WriteLine(string.Format("The wheels air pressure for vehicle {0} is now maximum",i_LicenseID));
            }
            else
            {
                Console.WriteLine("There isn't vehicle with the license number: {0} in the garage!!!", i_LicenseID);
            }
        }
        public void PrintBatterycharged(bool i_IsFoundCar, string i_LicenseID)
        {
            if (i_IsFoundCar)
            {
                Console.WriteLine(string.Format("The battery for vehicle {0} is now charged", i_LicenseID));
            }
            else
            {
                Console.WriteLine("There isn't vehicle with the license number: {0} in the garage!!!", i_LicenseID);
            }
        }
        public void PrintGasIsFilled(bool i_IsFoundCar, string i_LicenseID)
        {

            if (i_IsFoundCar)
            {
                Console.WriteLine(string.Format("Successfully filled fuel for vehicle license {0}", i_LicenseID));
            }
            else
            {
                Console.WriteLine("There isn't vehicle with the license number: {0} in the garage!!!", i_LicenseID);
            }
        }
        public void PrintSomethingWentWrong()
        {
            Console.WriteLine("Unfortunatley this cannot be done, please try again with different values.");
        }
        public void PrintHowManyMinutesToChargeBatteryQuestion(ref float io_MinutesTOCharge)
        {
            string userInput = null;
            bool userInputCorrect = false;
           
            while (!userInputCorrect)
            {
                Console.WriteLine("Please enter how many minutes you wish to charge your vehicle's battery");
                userInput = Console.ReadLine();
                if(float.TryParse(userInput, out io_MinutesTOCharge))
                {
                    userInputCorrect = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input,Please try again.");
                }
                
            }
        }
        public void PrintHowManyLitersToFillAndGasType(ref float io_LitersToAdd,ref int io_GasType)
        {
            string userInput = null;
            bool userInputCorrect = false;
            StringBuilder gasOptions = new StringBuilder();
            int lineNum = 1;
            foreach (string value in Enum.GetNames(typeof(GarageLogic.Program.eGasType)))
            {
                gasOptions.AppendLine(lineNum + ". " + value);
                lineNum++;
            }
            while (!userInputCorrect)
            {
                Console.WriteLine("Please enter how many liters you wish to fuel your vehicle");
                userInput = Console.ReadLine();
                if (float.TryParse(userInput, out io_LitersToAdd))
                {
                    Console.WriteLine("Please enter the gas type of your vehicle");
                    Console.WriteLine(gasOptions);
                    userInput = Console.ReadLine();
                    int.TryParse(userInput, out io_GasType);
                    userInputCorrect = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input,Please try again.");
                }

            }
        }
        public void PrintStatusOptionsMenuAndGetInput(ref int o_NewStatus)
        {
            StringBuilder menuChoices = new StringBuilder();
            int lineNum = 1;
            int attempts = 0;
            bool inputIsOk = false;
            string userInput;
            foreach (string value in Enum.GetNames(typeof(eStatusVehicle)))
            {
                menuChoices.AppendLine(lineNum + ". " + value);
                lineNum++;
            }
            while (!inputIsOk)
            {
                if (attempts == 0)
                {
                    Console.WriteLine("Select the new mode from the list below:");
                }
                else
                {
                    Console.WriteLine("Wrong input, please try again.{0}Select the new mode from the list below:", Environment.NewLine);
                }
                Console.WriteLine(menuChoices);
                userInput = Console.ReadLine();
                if (int.TryParse(userInput, out o_NewStatus) && o_NewStatus<lineNum)
                {
                    inputIsOk = true;
                }
                attempts++;
            }
        }

        public void PrintStatusUpdateMsg(bool i_IsUpdate, int i_StatusVehicle, string i_LicenseID)
        {
            if (i_IsUpdate)
            {
                Console.WriteLine("The status of vehicle with license number: {0} changed to status: {1} ", i_LicenseID, Enum.GetName(typeof(eStatusVehicle),(eStatusVehicle)i_StatusVehicle));
            }
            else
            {
                Console.WriteLine("There isn't vehicle with the license number: {0} in the garage!!!", i_LicenseID);
            }
        }
    }
}
