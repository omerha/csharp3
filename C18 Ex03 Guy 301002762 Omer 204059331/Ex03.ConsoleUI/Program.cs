using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using static Ex03.GarageLogic.Program;

namespace Ex03.ConsoleUI
{
   public class Program
    {
        public enum eMenuChoices
        {
            AddNewVehicle = 1,
            DisplayVehiclesInGarage = 2,
            ChangeVehicleStatus = 3,
            BlowAirPressureToMax = 4,
            FillGas = 5,
            ChargeBattery = 6,
            DisplayVehicleDetailsPerLicenseID = 7,
            Quit = 0
        }

        public static void Main()
        {
            Program main = new Program();
            main.Menu();
        }

        private PrintConsoleUtils m_ConsoleUtils = new PrintConsoleUtils();
        private GarageManager m_GarageManager = new GarageManager();

        public void Menu()
        {            
            bool quitMenu = false;
          
            int attempt = 0;
            int userChoice = -1;
            while (!quitMenu)
            {
                m_ConsoleUtils.PrintMenuAndGetUserChoice(ref userChoice, attempt);
                attempt = 0;
                switch (userChoice)
                {
                    case (int)eMenuChoices.AddNewVehicle:
                        InsertNewVehicleIntoTheGarage();
                        break;
                    case (int)eMenuChoices.DisplayVehiclesInGarage:
                        DisplayVehiclesInGarage();
                        break;
                    case (int)eMenuChoices.ChangeVehicleStatus:
                        ChangeVehicleStatus();
                        break;
                    case (int)eMenuChoices.BlowAirPressureToMax:
                        BlowWheelsAirPerLicenseID();
                        break;
                    case (int)eMenuChoices.FillGas:
                        AddFuelPerLicenseID();
                        break;
                    case (int)eMenuChoices.ChargeBattery:
                        ChargeVehicleBattery();
                        break;
                    case (int)eMenuChoices.DisplayVehicleDetailsPerLicenseID:
                        DisplayVehicleDetailsPerLicenseID();
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
                m_ConsoleUtils.PrintCarSelectionAndGetInput(ref vehicleChoice, ref engineChoice, attempts);
                m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref LicenseID, attempts);
                if (m_GarageManager.CheckIfVehicleExists(vehicleChoice, engineChoice, LicenseID)) 
                {
                    m_ConsoleUtils.PrintStatusUpdated();
                }
                else
                {
                    GetRequiredDetailsForNewVehicle((eVehicleType)vehicleChoice, (eEngineType)engineChoice, LicenseID);
                }
            }
            catch (ValueOutOfRangeException ex)
            {
                m_ConsoleUtils.PrintExceptionError(ex.Message);
            }
            catch (ArgumentException)
            {
                m_ConsoleUtils.PrintSomethingWentWrong();
            }       
            catch (FormatException)
            {
                m_ConsoleUtils.PrintMessgeNotExistInMenu();
            }
        }

        public void GetRequiredDetailsForNewVehicle(eVehicleType i_VehicleChoice, eEngineType i_EngineChoice, string i_LicenseID)
        {
            string modelName = null, wheelManufac = null, vehicleOwner = null, ownerPhone = null;
            float energyLeft = 0, currentAirPressure = 0;
            m_ConsoleUtils.PrintCurrentAirPressureEnergy(ref currentAirPressure, 0);
            m_ConsoleUtils.PrintEnergyLeftQuestion(ref energyLeft, 0);
            m_ConsoleUtils.PrintModelNameQuestion(ref modelName);
            m_ConsoleUtils.PrintWheelManufacQuestion(ref wheelManufac);
            m_ConsoleUtils.PrintVehicleOwnerPhoneQuestion(ref ownerPhone);
            m_ConsoleUtils.PrintVehicleOwnerQuestion(ref vehicleOwner);
            m_GarageManager.CreateNewVehicleUtils.CreateNewVehicle(m_GarageManager.Vehicles, i_VehicleChoice, i_EngineChoice, i_LicenseID, modelName, wheelManufac, vehicleOwner, ownerPhone, energyLeft, currentAirPressure);
            try
            {
                switch (i_VehicleChoice)
                {
                    case eVehicleType.Bike:
                        int licenseType = 0, engineVolume = 0;
                        m_ConsoleUtils.PrintBikeEngineVolumeQuestion(ref engineVolume, 0);
                        m_ConsoleUtils.PrintLicenseTypeChoicesQuestion(ref licenseType, 0);
                        m_GarageManager.SetBikeUniqDetails(engineVolume, licenseType);
                        break;
                    case eVehicleType.Car:
                        int carColor = 0, carNumOfDoors = 0;
                        m_ConsoleUtils.PrintCarColorQuestion(ref carColor, 0);
                        m_ConsoleUtils.PrintCarNumOfDoorsQuestion(ref carNumOfDoors, 0);
                        m_GarageManager.SetCarUniqDetails(carColor, carNumOfDoors);
                        break;
                    case eVehicleType.Truck:
                        bool isTruckTrunkCool = false;
                        float truckTrunkVolume = 0;
                        m_ConsoleUtils.PrintTruckBoxVolume(ref truckTrunkVolume, 0);
                        m_ConsoleUtils.PrintTruckTrunkCoolQuestion(ref isTruckTrunkCool, 0);
                        m_GarageManager.SetTrunkUniqDetails(isTruckTrunkCool, truckTrunkVolume);
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                m_ConsoleUtils.PrintMessgeNotExistInMenu();
            }
        }

        public void DisplayVehiclesInGarage()
        {
            int userChoice = 0;
            StringBuilder vehiclesToDisplay = new StringBuilder();
            try
            {
                m_ConsoleUtils.VehiclesStatusFilterMenuAndGetInput(ref userChoice);

                switch ((eStatusVehicle)userChoice)
                {
                    case eStatusVehicle.Fixed:
                        vehiclesToDisplay = m_GarageManager.LogicDisplayVehiclesInGarage(eStatusVehicle.Fixed);
                        break;
                    case eStatusVehicle.PaidUp:
                        vehiclesToDisplay = m_GarageManager.LogicDisplayVehiclesInGarage(eStatusVehicle.PaidUp);
                        break;
                    case eStatusVehicle.Repair:
                        vehiclesToDisplay = m_GarageManager.LogicDisplayVehiclesInGarage(eStatusVehicle.Repair);
                        break;
                    default:
                        break;
                }
            }
            catch (FormatException)
            {
                m_ConsoleUtils.PrintMessgeNotExistInMenu();
            }

            m_ConsoleUtils.PrintLicenseIDOfVehiclesInTheGarage(vehiclesToDisplay);
        }

        public void DisplayVehicleDetailsPerLicenseID()
        {
            string licenseID = null;
            int attempts = 0;
            m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref licenseID, attempts);
            StringBuilder vehicleDeatails = new StringBuilder();
            bool isFoundCar = m_GarageManager.LogicDisplayVehicleDetailsPerLicenseID(licenseID, ref vehicleDeatails);
            m_ConsoleUtils.PrintVehicleDetails(vehicleDeatails, isFoundCar, licenseID);
        }

        public void BlowWheelsAirPerLicenseID()
        {
            string licenseID = null;
            int attempts = 0;
            bool isVehicleFound = false;
            m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref licenseID, attempts);
            isVehicleFound = m_GarageManager.BlowVehicleAirPressurePerLicenseID(licenseID);
            m_ConsoleUtils.PrintAirPressureUpdated(isVehicleFound, licenseID);
        }

        public void AddFuelPerLicenseID()
        {
            string licenseID = null;
            int attempts = 0;
            int gasType = 0;
            float amountToAdd = 0;
            bool isVehiclefound = false;
            m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref licenseID, attempts);
            try
            {
                m_ConsoleUtils.PrintHowManyLitersToFillAndGasType(ref amountToAdd, ref gasType);
                isVehiclefound = m_GarageManager.ChargeOrFuelVehicle(amountToAdd, licenseID, gasType);
                m_ConsoleUtils.PrintGasIsFilled(isVehiclefound, licenseID);
            }
            catch (ArgumentException)
            {
                m_ConsoleUtils.PrintSomethingWentWrong();
            }
            catch (ValueOutOfRangeException ex)
            {
                m_ConsoleUtils.PrintExceptionError(ex.Message);
            }
            catch (FormatException)
            {
                m_ConsoleUtils.PrintMessgeNotExistInMenu();
            }
        }

        public void ChargeVehicleBattery()
        {
            int attempts = 0;
            string licenseID = null;
            bool isVehicleFound = false;
            float minutesToCharge = 0;
            m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref licenseID, attempts);
            m_ConsoleUtils.PrintHowManyMinutesToChargeBatteryQuestion(ref minutesToCharge);
           
            try
            {
                isVehicleFound = m_GarageManager.ChargeOrFuelVehicle(minutesToCharge, licenseID, 0);
                m_ConsoleUtils.PrintBatterycharged(isVehicleFound, licenseID);
            }
            catch (ArgumentException)
            {
                m_ConsoleUtils.PrintSomethingWentWrong();
            }
            catch (ValueOutOfRangeException ex)
            {
                m_ConsoleUtils.PrintExceptionError(ex.Message);
            }
        }

        public void ChangeVehicleStatus()
        {
            int newStatusForChange = 0;
            string licenseID = null;
            int attempts = 0;

            m_ConsoleUtils.PrintInsertLicseneIDQuestion(ref licenseID, attempts);
            m_ConsoleUtils.PrintStatusOptionsMenuAndGetInput(ref newStatusForChange);
            bool isUpdateStatus = m_GarageManager.LogicChangeVehicleStatus(licenseID, newStatusForChange);
            m_ConsoleUtils.PrintStatusUpdateMsg(isUpdateStatus, newStatusForChange, licenseID);
        }
    }
}