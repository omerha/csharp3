using System;
using System.Collections.Generic;
using System.Text;
using static Ex03.GarageLogic.Program;
namespace Ex03.GarageLogic
{
    public class CreateNewVehicleUtils
    {

        public void CreateNewVehicle(List<VehicleInTheGarage> io_VehiclesInGarage, eVehicleType i_VehicleType, eEngineType i_EngineType, string i_LicenseID,
            string i_ModelName, string i_WheelManufac, string i_OwnerName, string i_OwnerPhoneNumber, float i_EnergyLeft, float i_CurrAirPressure)
        {
            if (i_EngineType == eEngineType.Gas)
            {
                switch (i_VehicleType)
                {
                    case eVehicleType.Bike:
                       io_VehiclesInGarage.Add(new VehicleInTheGarage(new Bike(i_ModelName,i_LicenseID, new GasEngine(k_BikeGasType, k_BikeMaximumAmountOfGas, i_EnergyLeft), i_WheelManufac, i_CurrAirPressure),i_OwnerName,i_OwnerPhoneNumber));
                        break;
                    case eVehicleType.Car:
                        io_VehiclesInGarage.Add(new VehicleInTheGarage(new Car(i_ModelName, new GasEngine(k_CarGasType, k_CarMaximumAmountOfGas, i_EnergyLeft), i_LicenseID, i_WheelManufac, i_CurrAirPressure), i_OwnerName, i_OwnerPhoneNumber));
                        break;
                    case eVehicleType.Truck:
                        io_VehiclesInGarage.Add(new VehicleInTheGarage(new Truck(i_ModelName, new GasEngine(k_TruckGasType, k_TruckMaximumAmountOfGas, i_EnergyLeft), i_LicenseID, i_WheelManufac, i_CurrAirPressure), i_OwnerName, i_OwnerPhoneNumber));
                        break;
                }
            }
            else
            {
                switch (i_VehicleType)
                {
                    case eVehicleType.Bike:
                        io_VehiclesInGarage.Add(new VehicleInTheGarage(new Bike(i_ModelName,i_LicenseID, new ElectricEngine(k_CarMaximumAmountOfElectric, i_EnergyLeft), i_WheelManufac, i_CurrAirPressure), i_OwnerName, i_OwnerPhoneNumber));
                        break;
                    case eVehicleType.Car:
                        io_VehiclesInGarage.Add(new VehicleInTheGarage(new Car(i_ModelName, new ElectricEngine(k_CarMaximumAmountOfElectric, i_EnergyLeft), i_LicenseID, i_WheelManufac, i_CurrAirPressure), i_OwnerName, i_OwnerPhoneNumber));
                        break;
                }
            }
        }
    }
}
