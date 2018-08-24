using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Program
    {
        List<Vehicle> vehicles;
    }
    public abstract class Vehicle
    {
        private string m_ModelName;//Should be const?
        private string m_LicsenseID;//Should be const?
        private float m_EnergyLeft;
        public Engine m_Engine;//not sure if it should be private or public, i think public.
    }
    public abstract class Engine
    {
        //All the virtual methods
    }
    public class GasEngine : Engine
    {
        string m_GasType;//const
        private float m_CurrentGasLiters;
        private float m_MaxGasLiters;//Const

        public bool FillGas(float i_NumOfLitersToFill,string i_GasType)
        {

        }
    }
    public class ElectricEngine : Engine
    {

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

        }
    }
    
}
