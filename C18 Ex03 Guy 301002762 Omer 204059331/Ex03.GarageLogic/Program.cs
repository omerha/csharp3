using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Program
    {
        List<VehicleInTheGarage> m_vehicles;
    }
    
    public enum eGasType
    {
        Soler=1,
        Octan95=2,
        Octan96=3,
        Octan98=4
    }

    public enum eCarColor
    {
        Gray=1,
        White=2,
        Green=3,
        Purple=4
    }

    public enum eNumOfDoors
    {
        TwoDoors=1,
        ThreeDoors=2,
        FourDoors=3,
        FiveDoors=4
    }

    public enum eLicenseType
    {
        A1=1,
        A2=2,
        AB=3,
        B=4
    }

    public enum eStatusVehicle
    {
        Repair=1,
        Fixed=2,
        PaidUp=3
    }

    public enum eEngineType
    {
        Gas=1,
        Electric=2
    }

    public enum eVehicleType
    {
        Bike=1,
        Car=2,
        Truck=3
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

        public eStatusVehicle StatusOfVehicle
        {
            get { return m_StatusOfVehicle; }
            set { m_StatusOfVehicle = value; }
        }
        VehicleInTheGarage(eVehicleType i_VehicleType, string i_ModelName, string i_LicsenseID, string m_LicsenseID,int i_EngineVolume, float i_AmountOfEnergyLeft)
        {
            if (i_VehicleType==eVehicleType.Bike)
            {
                
            }
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
            base.m_MaximumAmountOfEnergy = i_MaximumAmoutOfEnergyToCharge;
            base.AmountOfEnergyLeft = i_AmountOfEnergyLeft;
        }

    }
    public class ElectricEngine : Engine
    {
        public ElectricEngine (float i_MaximumAmoutOfEnergyToCharge, float i_AmountOfEnergyLeft)
        {
            base.m_MaximumAmountOfEnergy = i_MaximumAmoutOfEnergyToCharge;
        }
    }

    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicsenseID;
        private float m_PrecentageOfEnergyLeft;
        public Engine m_EngineType;//not sure if it should be private or public, i think public.
        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicsenseID
        {
            get { return m_LicsenseID; }
        }

        public float PrecentageOfEnergyLeft
        {
            get { return m_PrecentageOfEnergyLeft; }
            set { m_PrecentageOfEnergyLeft = value; }
        }

    }
    
    public class  Bike : Vehicle
    {
        private const int k_NumOfWheels = 2;
        private const int k_MaxAirPressure = 28;
        private const eGasType k_GasType = eGasType.Octan95;
        private const float k_MaximumAmountOfGas = 5;
        private const float k_MaximumAmountOfElectric = (float)3.2;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;
        private Wheel[] m_Wheels = new Wheel[k_NumOfWheels];
        public Bike(string i_ModelName, string i_LicsenseID, eEngineType i_EngineType, eLicenseType i_LicenseType, int i_EngineVolume, float i_AmountOfEnergyLeft)
        {
            base.m_ModelName = i_ModelName;
            base.m_LicsenseID = i_LicsenseID;
            if (i_EngineType==eEngineType.Electric)
            {
                base.m_EngineType = new ElectricEngine(k_MaximumAmountOfElectric, i_AmountOfEnergyLeft);
            }
            else
            {
                base.m_EngineType = new GasEngine(k_GasType,k_MaximumAmountOfGas,i_AmountOfEnergyLeft);
            }
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
            for (int i=0;i<k_NumOfWheels;i++)
            {
                m_Wheels[i] = new Wheel("ThisIsTheNameOfManufacturer", k_MaxAirPressure);
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
        private const int k_NumOfWheels = 4;
        private const int k_MaxAirPressure = 30;
        private const eGasType k_GasType = eGasType.Octan96;
        private const float k_MaximumAmountOfGas = 48;
        private const float k_MaximumAmountOfElectric = (float)4.8;
        private eCarColor m_CarColor;
        private eNumOfDoors m_NumOfDoors;
        private Wheel[] m_Wheels = new Wheel[k_NumOfWheels];

        public eCarColor CarColor
        {
            get { return m_CarColor; }
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
        }

        public Car(string i_ModelName, string i_LicsenseID, eEngineType i_EngineType, eCarColor i_CarColor, eNumOfDoors i_NumOfDoors, float i_AmountOfEnergyLeft)
        {
            base.m_ModelName = i_ModelName;
            base.m_LicsenseID = i_LicsenseID;
            if (i_EngineType == eEngineType.Electric)
            {
                base.m_EngineType = new ElectricEngine(k_MaximumAmountOfElectric, i_AmountOfEnergyLeft);
            }
            else
            {
                base.m_EngineType = new GasEngine(k_GasType,k_MaximumAmountOfGas, i_AmountOfEnergyLeft);
            }
            m_CarColor = i_CarColor;
            m_NumOfDoors = i_NumOfDoors;
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels[i] = new Wheel("ThisIsTheNameOfManufacturer", k_MaxAirPressure);
            }
        }

    }

    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 16;
        private const int k_MaxAirPressure = 32;
        private const eGasType k_GasType = eGasType.Soler;
        private const float k_MaximumAmountOfGas = 105;
        private bool m_IsTrunkCool;
        private float m_TrunkVolume;
        private Wheel[] m_Wheels = new Wheel[k_NumOfWheels];

        public Truck(string i_ModelName, string i_LicsenseID, bool i_IsTrunkCool, float i_TrunkVolume, float i_AmountOfEnergyLeft)
        {
            base.m_ModelName = i_ModelName;
            base.m_LicsenseID = i_LicsenseID;
            m_IsTrunkCool = i_IsTrunkCool;
            m_TrunkVolume = i_TrunkVolume;
            base.m_EngineType = new GasEngine(k_GasType, k_MaximumAmountOfGas,i_AmountOfEnergyLeft);
            for (int i = 0; i < k_NumOfWheels; i++)
            {
                m_Wheels[i] = new Wheel("ThisIsTheNameOfManufacturer", k_MaxAirPressure);
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
            if ((i_AirToBlow+m_CurrentAirPressure)<=m_MaxAirPressure)
            {
                tirePressureUpdated = true;
            }
            return tirePressureUpdated;
        }

        public Wheel (string i_NameOfManufacturer, float i_MaxAirPressure)
        {
            m_NameOfManufacturer = i_NameOfManufacturer;
            m_MaxAirPressure = i_MaxAirPressure;
        }
    }
    
}
