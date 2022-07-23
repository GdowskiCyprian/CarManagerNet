/*
 Auth Table
 */
    INSERT INTO `carmanager`.`Auths` (`AuthId`, `Email`, `Password`) VALUES ('1', 'client@client.com', 'Plokiploki1');
    INSERT INTO `carmanager`.`Auths` (`AuthId`, `Email`, `Password`) VALUES ('2', 'repairshop@repairshop.com', 'Plokiploki1');
/*
 RepairShop Table
 */
    INSERT INTO `carmanager`.`RepairShops` (`RepairShopId`, `PhoneNumber`, `Name`, `Nip`, `AuthId`) VALUES ('1', '123456789', 'RepairShop', '12345678', '2');
/*
Client Table
*/
    INSERT INTO `carmanager`.`Clients` (`ClientId`, `PhoneNumber`, `Name`, `Surname`, `RepairShopId`, `AuthId`) VALUES ('1', '987654321', 'Client', 'Client', '1', '1');
/*
 Car Table
 */
    INSERT INTO `carmanager`.`Cars` (`CarId`, `MakeYear`, `Manufacturer`, `Model`, `Version`, `Displacement`, `Power`, `Mileage`, `ClientId`) VALUES ('1', '2010', 'Renault', 'Megane', '3', '2000', '250', '224000', '1');
/*
 Repair Table
 */
    INSERT INTO `carmanager`.`Repairs` (`RepairId`, `ProcessDate`, `Name`, `Description`, `CarId`) VALUES ('1', '2022-07-01', 'Repair', 'Repair Description', '1');
/*
 Repair Part Table
 */
    INSERT INTO `carmanager`.`RepairParts` (`RepairPartId`, `Name`, `Description`, `Price`, `RepairId`) VALUES ('1', 'Repair Part', 'Repair Part Description', '10', '1');
/*
 Fuel Tank Table
 */
    INSERT INTO `carmanager`.`FuelTanks` (`FuelTankId`, `FuelType`, `Capacity`, `CarId`) VALUES ('1', '1', '60', '1');
/*
 Refuel Table
*/
    INSERT INTO `carmanager`.`Refuels` (`RefuelId`, `FuelType`, `Volume`, `Price`, `FuelTankId`) VALUES ('1', '1', '50', '300', '1');
