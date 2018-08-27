using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Program;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Program main = new Program();
            main.Menu();
        }
        public enum eMenuChoices
        {
            AddNewVehicle = 1,
            DisplayVehiclesInGarage = 2,
            ChangeVehicleStatus = 3,
            FillAirPressureToMax = 4,
            FillGas = 5,
            FillBattery = 6,
            DisplayVehicleDetailsPerLicenseID = 7,
            Quit = 0
        }
        private PrintConsoleUtils m_ConsoleUtils = new PrintConsoleUtils();
        private GarageManager m_GarageManager = new GarageManager();

        public void Menu()
        {
            
            bool quitMenu = false;
          
            int attempt = 0;
            int userChoice = -1;
            eMenuChoices eUserChoice;
            while(!quitMenu)
            {
                m_ConsoleUtils.PrintMenuAndGetUserChoice(ref  userChoice, attempt);
                attempt = 0;
                switch(userChoice)
                {
                    case (int)eMenuChoices.AddNewVehicle:
                        InsertNewVehicleIntoTheGarage();
                        break;
                    default:
                        attempt++;
                        break;
                }
                
            }
        }
        public void InsertNewVehicleIntoTheGarage()
        {
            try
            {
                string LicenseID = null;
                int attempts = 0, vehicleChoice = -1, engineChoice = -1;
                m_ConsoleUtils.PrintCarSelectionAndGetInput(ref vehicleChoice,ref engineChoice, attempts);
                m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref LicenseID, attempts);
                if(m_GarageManager.CheckIfVehicleExists(vehicleChoice,engineChoice, LicenseID))
                {
                    m_ConsoleUtils.PrintStatusUpdated();
                }
                else
                {
                    GetRequiredDetailsForNewVehicle((eVehicleType)vehicleChoice,(eEngineType) engineChoice, LicenseID);
                }
            }
            catch(ArgumentException)
            {

            }
            
        }
        public void GetRequiredDetailsForNewVehicle(eVehicleType i_VehicleChoice, eEngineType i_EngineChoice, string i_LicenseID)
        { 
            string modelName=null, wheelManufac=null, vehicleOwner=null, ownerPhone=null;
             float  energyLeft=0,currentAirPressure=0;
            m_ConsoleUtils.PrintCurrentAirPressureEnergy(ref currentAirPressure, 0);
            m_ConsoleUtils.PrintEnergyLeftQuestion(ref energyLeft, 0);
            m_ConsoleUtils.PrintModelNameQuestion(ref modelName);
            m_ConsoleUtils.PrintWheelManufacQuestion(ref wheelManufac);
            m_ConsoleUtils.PrintVehicleOwnerPhoneQuestion(ref ownerPhone);
            m_ConsoleUtils.PrintVehicleOwnerQuestion(ref vehicleOwner);
            m_GarageManager.CreateNewVehicleUtils.CreateNewVehicle( m_GarageManager.Vehicles, i_VehicleChoice, i_EngineChoice, i_LicenseID, modelName, wheelManufac, vehicleOwner, ownerPhone, energyLeft, currentAirPressure);
            switch (i_VehicleChoice)
            {
                case eVehicleType.Bike:
                    int licenseType=0, engineVolume = 0;
                    m_ConsoleUtils.PrintBikeEngineVolumeQuestion(ref engineVolume, 0);
                    m_ConsoleUtils.PrintLicenseTypeChoicesQuestion(ref licenseType, 0);
                    break;
                case eVehicleType.Car:
                    int carColor = 0, carNumOfDoors = 0;
                    m_ConsoleUtils.PrintCarColorQuestion(ref carColor, 0);
                    m_ConsoleUtils.PrintCarNumOfDoorsQuestion(ref carNumOfDoors, 0);
                    break;
                case eVehicleType.Truck:
                    bool isTruckTrunkCool = false;
                    float truckTrunkVolume = 0;
                    m_ConsoleUtils.PrintTruckBoxVolume(ref truckTrunkVolume, 0);
                    m_ConsoleUtils.PrintTruckTrunkCoolQuestion(ref isTruckTrunkCool, 0);
                    break;
                default:
                    break;

            }

        }

        public void DisplayVehiclesInGarage()
        {
            eStatusVehicle userChoice = 0;
            m_ConsoleUtils.VehiclesStatusFilterMenuAndGetInput(ref userChoice);
            switch (userChoice)
            {
                case eStatusVehicle.Fixed:
                    
                    break;

            }

        }
        public bool IsTheVehiclesExsitsInTheGarage(string i_LisceneID)
        {
            bool isExists = false;


            return isExists;
        }

    }
}

