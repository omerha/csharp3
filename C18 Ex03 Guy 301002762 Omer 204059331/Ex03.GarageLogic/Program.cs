using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Program
    {
        public class ValueOutOfRangeException : Exception
        {
            private float m_MinValue;
            private float m_MaxValue;
            private string m_ValueName;
            public float MinValue
            {
                get { return m_MinValue; }
            }
            public float MaxValue
            {
                get { return m_MaxValue; }
            }
            public string ValueName
            {
                get { return m_ValueName; }
            }
            public ValueOutOfRangeException(float i_MinValue,float i_MaxValue,string i_ValueName) :base(string.Format("Invalid value for {0}, the value should be in the range" +
                " between {1} to {2}", i_ValueName,i_MinValue, i_MaxValue))
            {}
        }
        public const int k_BikeNumOfWheels = 2;
        public const int k_BikeMaxAirPressure = 28;
        public const eGasType k_BikeGasType = eGasType.Octan95;
        public const float k_BikeMaximumAmountOfGas = 5;
        public const float k_BikeMaximumAmountOfElectric = (float)3.2;
        public const int k_CarNumOfWheels = 4;
        public const int k_CarMaxAirPressure = 30;
        public const eGasType k_CarGasType = eGasType.Octan96;
        public const float k_CarMaximumAmountOfGas = 48;
        public const float k_CarMaximumAmountOfElectric = (float)4.8;
        public const int k_TruckNumOfWheels = 16;
        public const int k_TruckMaxAirPressure = 32;
        public const eGasType k_TruckGasType = eGasType.Soler;
        public const float k_TruckMaximumAmountOfGas = 105;
        public class GarageManager
        {
            private List<VehicleInTheGarage> m_Vehicles = new List<VehicleInTheGarage>();
            private CreateNewVehicleUtils m_CreateVehicleUtils = new CreateNewVehicleUtils();

            public bool CheckIfVehicleExists(int i_UserCarChoice, int i_UserEngineChoice, string i_LicenseID)
            {
                eVehicleType vehicleChoice = (eVehicleType)i_UserCarChoice;
                eEngineType engineChoice = 0;
                if (vehicleChoice != eVehicleType.Truck) 
                {
                     engineChoice = (eEngineType)i_UserEngineChoice;
                }
                else
                {
                    engineChoice = eEngineType.Gas;
                }
                
                bool isCarExists = false;
                if (m_Vehicles != null)
                {
                    foreach (VehicleInTheGarage vehicle in m_Vehicles)
                    {
                        if (vehicle.Vehicle.LicenseID == i_LicenseID)
                        {
                            if (vehicle.StatusOfVehicle != eStatusVehicle.Repair)
                            {
                                vehicle.StatusOfVehicle = eStatusVehicle.Repair;
                            }
                            isCarExists = true;
                            break;
                        }
                    }
                }
                return isCarExists;
            }
            public List<VehicleInTheGarage> Vehicles
            {
                get { return m_Vehicles; }
            }
            public CreateNewVehicleUtils CreateNewVehicleUtils
            {
                get { return m_CreateVehicleUtils; }
            }
        }
        public enum eGasType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4
        }

        public enum eCarColor
        {
            Gray = 1,
            White = 2,
            Green = 3,
            Purple = 4
        }

        public enum eNumOfDoors
        {
            TwoDoors = 1,
            ThreeDoors = 2,
            FourDoors = 3,
            FiveDoors = 4
        }

        public enum eLicenseType
        {
            A1 = 1,
            A2 = 2,
            AB = 3,
            B = 4
        }

        public enum eStatusVehicle
        {
            Repair = 1,
            Fixed = 2,
            PaidUp = 3
        }

        public enum eEngineType
        {
            Gas = 1,
            Electric = 2
        }

        public enum eVehicleType
        {
            Bike = 1,
            Car = 2,
            Truck = 3
        }

        public class VehicleInTheGarage
        {
            private string m_NameOfOwner;
            private string m_PhoneOfOwner;
            private eStatusVehicle m_StatusOfVehicle;
            private Vehicle m_Vehicle;

            public string NameOfOwner
            {
                get { return m_NameOfOwner; }
            }

            public string PhoneOfOwner
            {
                get { return m_PhoneOfOwner; }
            }
            public Vehicle Vehicle
            {
                get { return m_Vehicle; }
                set { m_Vehicle = value; }
            }
            public eStatusVehicle StatusOfVehicle
            {
                get { return m_StatusOfVehicle; }
                set { m_StatusOfVehicle = value; }
            }
           public VehicleInTheGarage(Vehicle i_VehicleToAdd,string i_NameOfOwner,string i_PhoneOfOwner)
            {
                m_Vehicle = i_VehicleToAdd;
                m_StatusOfVehicle = eStatusVehicle.Repair;
                m_NameOfOwner = i_NameOfOwner;
                m_PhoneOfOwner = i_PhoneOfOwner;
            }
        }

        public abstract class Engine
        {
            private float m_AmountOfEnergyLeft;
            protected float m_MaximumAmountOfEnergy;
            public void Recharge(float i_AmountOfEnergyToCharge)
            {
                if ((i_AmountOfEnergyToCharge + m_AmountOfEnergyLeft) <= m_MaximumAmountOfEnergy)
                {
                    m_AmountOfEnergyLeft += i_AmountOfEnergyToCharge;
                }
            }

            public float MaximumAmountOfEnergy
            {
                get { return m_MaximumAmountOfEnergy; }
            }

            public float AmountOfEnergyLeft
            {
                get { return m_AmountOfEnergyLeft; }
                set { m_AmountOfEnergyLeft = value; }
            }
            public void ValidateEnergyValues(float i_NewValueForEnergyLeft)
            {
                if(i_NewValueForEnergyLeft>m_MaximumAmountOfEnergy || i_NewValueForEnergyLeft < 0)
                {
                    throw new ValueOutOfRangeException(0, m_MaximumAmountOfEnergy,"Energy");
                }
            }
        }
        public class GasEngine : Engine
        {
            private eGasType m_GasType;

            public eGasType GasType
            {
                get { return m_GasType; }
            }

            public GasEngine(eGasType i_GasType, float i_MaximumAmoutOfEnergyToCharge, float i_AmountOfEnergyLeft)
            {
                m_GasType = i_GasType;
                m_MaximumAmountOfEnergy = i_MaximumAmoutOfEnergyToCharge;
                ValidateEnergyValues(i_AmountOfEnergyLeft);
                AmountOfEnergyLeft = i_AmountOfEnergyLeft;
            }

        }
        public class ElectricEngine : Engine
        {
            public ElectricEngine(float i_MaximumAmoutOfEnergyToCharge, float i_AmountOfEnergyLeft)
            {
                m_MaximumAmountOfEnergy = i_MaximumAmoutOfEnergyToCharge;
                ValidateEnergyValues(i_AmountOfEnergyLeft);
                AmountOfEnergyLeft = i_AmountOfEnergyLeft;
            }
        }

        public abstract class Vehicle
        {
            protected string m_ModelName;
            protected string m_LicenseID;
            private float m_PrecentageOfEnergyLeft;
            public Engine m_EngineType;//not sure if it should be private or public, i think public.
            public string ModelName
            {
                get { return m_ModelName; }
            }

            public string LicenseID
            {
                get { return m_LicenseID; }
            }

            public float PrecentageOfEnergyLeft
            {
                get { return m_PrecentageOfEnergyLeft; }
                set { m_PrecentageOfEnergyLeft = value; }
            }
            public void ValidateValueInRange(float i_MaxValue,float i_Value,string i_ValueName)
            {
                if (i_Value > i_MaxValue || i_Value < 0)
                {
                    throw new ValueOutOfRangeException(0, i_MaxValue, i_ValueName);
                }
            }
            public virtual StringBuilder GetVehicleDetails()
            {
                StringBuilder carDetails = new StringBuilder();
                return carDetails;
            }
        }

        public class Bike : Vehicle
        {

            private eLicenseType m_LicenseType;
            private int m_EngineVolume;
            private Wheel[] m_Wheels = new Wheel[k_BikeNumOfWheels];
            public Bike(string i_LicenseID,Engine i_Engine,string i_WheelManufac,float i_CurrAirPressure)
            {
                m_LicenseID = i_LicenseID;
                m_EngineType = i_Engine;
                ValidateValueInRange(k_BikeMaxAirPressure, i_CurrAirPressure, "Wheel air pressure");
                for (int i = 0; i < k_BikeNumOfWheels; i++)
                {
                    m_Wheels[i] = new Wheel(i_WheelManufac, k_BikeMaxAirPressure,i_CurrAirPressure);
                }
            }

            public eLicenseType LicenseType
            {
                get { return m_LicenseType; }
            }

            public int EngineVolume
            {
                get { return m_EngineVolume; }
            }

        }
        public class Car : Vehicle
        {

            private eCarColor m_CarColor;
            private eNumOfDoors m_NumOfDoors;
            private Wheel[] m_Wheels = new Wheel[k_CarNumOfWheels];

            public eCarColor CarColor
            {
                get { return m_CarColor; }
            }

            public eNumOfDoors NumOfDoors
            {
                get { return m_NumOfDoors; }
            }

            public Car(string i_ModelName, Engine i_Engine, string i_LicsenseID, string i_WheelManufac, float i_CurrAirPressure)
            {
                m_ModelName = i_ModelName;
                m_LicenseID = i_LicsenseID;
                m_EngineType = i_Engine;
                ValidateValueInRange(k_CarMaxAirPressure, i_CurrAirPressure, "Wheel air pressure");
                for (int i = 0; i < k_CarNumOfWheels; i++)
                {
                    m_Wheels[i] = new Wheel(i_WheelManufac, k_CarMaxAirPressure, i_CurrAirPressure);
                }

            }

        }

        public class Truck : Vehicle
        {

            private bool m_IsTrunkCool;
            private float m_TrunkVolume;
            private Wheel[] m_Wheels = new Wheel[k_CarNumOfWheels];

            public Truck(string i_ModelName, Engine i_Engine, string i_LicsenseID, string i_WheelManufac, float i_CurrAirPressure)
            {
                m_ModelName = i_ModelName;
                m_LicenseID = i_LicsenseID;
                m_EngineType = i_Engine;
                ValidateValueInRange(k_TruckMaximumAmountOfGas, i_CurrAirPressure, "Wheel air pressure");
                for (int i = 0; i < k_TruckNumOfWheels; i++)
                {
                    m_Wheels[i] = new Wheel(i_WheelManufac, k_TruckMaxAirPressure,i_CurrAirPressure);
                }
            }

        }

        public class Wheel
        {
            private string m_NameOfManufacturer;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressure;

            public float CurrentAirPressure
            {
                get { return m_CurrentAirPressure; }
                set { m_CurrentAirPressure = value; }
            }

            public string NameOfManufacturer
            {
                get { return m_NameOfManufacturer; }
            }

            public float MaxAirPressure
            {
                get { return m_MaxAirPressure; }
            }

            public bool BlowUpWheel(float i_AirToBlow)
            {
                bool tirePressureUpdated = false;
                if ((i_AirToBlow + m_CurrentAirPressure) <= m_MaxAirPressure)
                {
                    tirePressureUpdated = true;
                }
                return tirePressureUpdated;
            }

            public Wheel(string i_NameOfManufacturer, float i_MaxAirPressure,float i_CurrAirPressure)
            {
                m_NameOfManufacturer = i_NameOfManufacturer;
                m_MaxAirPressure = i_MaxAirPressure;
                m_CurrentAirPressure = i_CurrAirPressure;
            }
        }
    }   
}
