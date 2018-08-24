using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Program
    {
        List<Vehicle> vehicles;
    }
    public abstract class Engine
    {
        private float m_AmountOfEnergyLeft;
        private float m_MaximumAmountOfEnergy;
        public void Recharge(float i_fill)
        {
            if ((i_fill + m_AmountOfEnergyLeft) <= m_MaximumAmountOfEnergy)
            {
                m_AmountOfEnergyLeft += i_fill;
            }



        }

        public float MaximumAmountOfEnergy
        {
            get { return m_MaximumAmountOfEnergy; }
            set { m_MaximumAmountOfEnergy = value; }
        }

        public float ReaminingAmount
        {
            get { return m_AmountOfEnergyLeft; }
            set { m_AmountOfEnergyLeft = value; }
        }
    }
    public class GasEngine : Engine
    {
        private string m_GasType;//const

        public string GasType
        {
            get { return m_GasType; }
            set { m_GasType = value; }
        }
    }
    public class ElectricEngine : Engine
    {

    }

    public abstract class Vehicle
    {
        private string m_ModelName;//Should be const?
        private string m_LicsenseID;//Should be const?
        private float m_PrecentageOfEnergyLeft;
        public Engine m_Engine;//not sure if it should be private or public, i think public.
        public Wheel m_Whells; //array of whells
        public string ModelName
        {
            get { return m_ModelName; }
            set { m_ModelName = value; }
        }

        public string LicsenseID
        {
            get { return m_LicsenseID; }
            set { m_LicsenseID = value; }
        }

        public float PrecentageOfEnergyLeft
        {
            get { return m_PrecentageOfEnergyLeft; }
            set { m_PrecentageOfEnergyLeft = value; }
        }
    }
    
    public class  Bike : Vehicle
    {
        private string m_LicenseType;//Const?
        private int m_EngineVolume;//Const?
    }
    public class Car : Vehicle
    {
        private string m_Color;//Enum??
        private int m_NumOfDoors;//Const / enum?
    }
    public class Truck : Vehicle
    {
        private bool isTrunkCool;//const    
        private float m_TrunkVolume;//const
    }

    public class Wheel
    {
        private string m_NameOfManufacturer;//Const?
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;//Const?

        public bool BlowUpWheel(float i_AirToBlow)
        {
            bool tirePressureUpdated = false;
            if ((i_AirToBlow+m_CurrentAirPressure)<=m_MaxAirPressure)
            {
                tirePressureUpdated = true;
            }
            return tirePressureUpdated;
        }
    }
    
}
