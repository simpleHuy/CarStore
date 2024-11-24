using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarStore.Core.Migrations;

/// <inheritdoc />
public partial class add_seed_data : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            table: "EngineTypes",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "Xăng" },
                { 2, "Điện" },
                { 3, "Diesel" },
                { 4, "Hybrid" }
            });

        migrationBuilder.InsertData(
            table: "Manufacturers",
            columns: new[] { "Id", "Name" },
            values: new object[,]
            {
                { 1, "Honda" },
                { 2, "Volkswagen" },
                { 3, "Toyota" },
                { 4, "Mercedes" },
                { 5, "Ford" },
                { 6, "Tesla" },
                { 7, "Nissan" },
                { 8, "Vinfast" },
                { 9, "Porsche" }
            });

        migrationBuilder.InsertData(
            table: "TypeOfCars",
            columns: new[] { "Id", "ImageLocation", "Name" },
            values: new object[,]
            {
                { 1, "../Assets/CategoryBackground/sedan.png", "Sedan" },
                { 2, "../Assets/CategoryBackground/hatchback.png", "HatchBack" },
                { 3, "../Assets/CategoryBackground/suv.png", "SUV" },
                { 4, "../Assets/CategoryBackground/cuv.png", "CUV" },
                { 5, "../Assets/CategoryBackground/minivan.png", "Minivan" },
                { 6, "../Assets/CategoryBackground/coupe.png", "Coupe" },
                { 7, "../Assets/CategoryBackground/convertible.png", "Convertible" },
                { 8, "../Assets/CategoryBackground/pickup.png", "Pickup" }
            });

        migrationBuilder.InsertData(
            table: "variants",
            columns: new[] { "Id", "Code" },
            values: new object[,]
            {
                { 1, "White" },
                { 2, "Grey" },
                { 3, "Black" },
                { 4, "Blue" },
                { 5, "Green" },
                { 6, "Red" }
            });

        migrationBuilder.InsertData(
            table: "Cars",
            columns: new[] { "CarId", "DefautlImageLocation", "Description", "EngineTypeId", "Images", "ManufacturerId", "Name", "Price", "TypeOfCarId", "UsageStatus" },
            values: new object[,]
            {
                { 1, "../Assets/Cars/Honda Accord/White/1.png", "Engine Options:\r\n1.5L DI VTEC Turbo:\r\n\r\nHorsepower: 192 hp @ 6,000 rpm\r\n\r\nTorque: 192 lb-ft @ 1,700-5,000 rpm\r\n\r\nFuel Efficiency: 29 mpg city / 37 mpg highway / 32 mpg combined\r\n\r\n2.0L DI Atkinson (Hybrid):\r\n\r\nHorsepower: 146 hp @ 6,100 rpm\r\n\r\nTorque: 134 lb-ft @ 4,500 rpm\r\n\r\nFuel Efficiency: 46 mpg city / 41 mpg highway / 44 mpg combined\r\n\r\n2.0L DI Atkinson (Hybrid):\r\n\r\nTotal System Horsepower: 204 hp\r\n\r\nTorque: 247 lb-ft @ 0-2,000 rpm\r\n\r\nDrivetrain:\r\nFront-Wheel Drive\r\n\r\nContinuously Variable Transmission (CVT) for non-hybrid models\r\n\r\nTwo-Motor Hybrid System for hybrid models\r\n\r\nDimensions:\r\nLength: 195.7 inches\r\n\r\nWidth: 73.3 inches\r\n\r\nHeight: 57.1 inches\r\n\r\nWheelbase: 111.4 inches\r\n\r\nGround Clearance: 5.3 inches\r\n\r\nInterior:\r\nSeating Capacity: 5\r\n\r\nCargo Capacity: 16.7 cubic feet\r\n\r\nHeadroom (First Row): 39.5 inches\r\n\r\nLegroom (First Row): 42.3 inches\r\n\r\nLegroom (Second Row): 40.8 inches\r\n\r\nSafety Features:\r\nHonda Sensing® Suite: Includes adaptive cruise control, lane-keeping assist, collision mitigation braking, and road departure mitigation2\r\n\r\nBlind Spot and Lane Departure Warnings\r\n\r\nRear Cross Traffic Alert\r\n\r\nDriver Attention Monitor\r\n\r\nPre-Collision System with Pedestrian Detection\r\n\r\nMultiple Airbags: Front, side, and curtain airbags\r\n\r\nAdditional Features:\r\n12.3-inch Touch-Screen Display\r\n\r\nApple CarPlay® and Android Auto™ Compatibility\r\n\r\nWireless Charging\r\n\r\nPremium Audio System\r\n\r\nMultiple Drive Modes: Econ, Normal, Sport, and Individual (for hybrid trims)", 4, "Honda Accord", 1, "Honda Accord", 1319000000L, 3, "New" },
                { 2, "../Assets/Cars/Honda Civic City Rs/Black/1.png", "Engine and Performance:\r\nEngine: 1.5-liter VTEC Turbocharged Inline-4\r\n\r\nPower Output: 180 horsepower @ 6,000 rpm\r\n\r\nTorque: 177 lb-ft @ 1,700-4,500 rpm\r\n\r\nTransmission: Continuously Variable Transmission (CVT) with paddle shifters\r\n\r\nDrive Type: Front-Wheel Drive\r\n\r\nFuel Efficiency:\r\n\r\nCity: Approximately 30 mpg\r\n\r\nHighway: Approximately 38 mpg\r\n\r\nCombined: Approximately 33-34 mpg\r\n\r\nDimensions:\r\nLength: 184 inches\r\n\r\nWidth: 70.9 inches\r\n\r\nHeight: 55.7 inches\r\n\r\nWheelbase: 107.7 inches\r\n\r\nCurb Weight: 2,950 lbs (approx.)\r\n\r\nExterior Features:\r\nDesign: Aggressive sporty styling with a RS-specific body kit\r\n\r\nLighting: Full LED headlights and taillights\r\n\r\nWheels: 18-inch alloy wheels with a distinctive design\r\n\r\nSpoiler: Rear spoiler for enhanced aerodynamics\r\n\r\nInterior Features:\r\nSeating: Sporty front seats with RS-specific upholstery\r\n\r\nDashboard: Digital instrument cluster with customizable displays\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 9-inch touchscreen with high-resolution\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility\r\n\r\nAudio: Premium sound system with multiple speakers\r\n\r\nComfort: Dual-zone automatic climate control, heated front seats, leather-wrapped steering wheel\r\n\r\nSafety and Driver-Assistance:\r\nHonda Sensing® Suite:\r\n\r\nAdaptive Cruise Control (ACC)\r\n\r\nLane Keeping Assist System (LKAS)\r\n\r\nCollision Mitigation Braking System™ (CMBS)\r\n\r\nRoad Departure Mitigation System (RDM)\r\n\r\nAdditional Safety Features:\r\n\r\nBlind Spot Information System (BSI)\r\n\r\nCross Traffic Monitor\r\n\r\nMulti-angle Rearview Camera with Dynamic Guidelines\r\n\r\nTraffic Sign Recognition (TSR)\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nSunroof: Power-operated moonroof\r\n\r\nStorage: Spacious trunk with split-folding rear seats for additional cargo space\r\n\r\nTechnology: Wireless charging pad, multiple USB ports, Bluetooth connectivity\r\n\r\nColors and Customization:\r\nExterior Color Options: Wide range of colors including Platinum White Pearl, Sonic Gray Pearl, Rallye Red, and more\r\n\r\nInterior Options: Sporty black with red stitching", 1, "Honda Civic City Rs", 1, "Honda Civic City Rs", 889000000L, 1, "New" },
                { 3, "../Assets/Cars/Honda Type R/Black/2.png", "Engine and Performance:\r\nEngine: 2.0-liter turbocharged VTEC Inline-4\r\n\r\nHorsepower: 315 hp @ 6,500 rpm\r\n\r\nTorque: 310 lb-ft @ 2,600-4,000 rpm\r\n\r\nTransmission: 6-speed manual with rev-match control\r\n\r\nFuel Efficiency:\r\n\r\nCity: 22 mpg\r\n\r\nHighway: 28 mpg\r\n\r\nCombined: 24 mpg\r\n\r\nDrive Type: Front-Wheel Drive\r\n\r\nDimensions:\r\nLength: 180.9 inches\r\n\r\nWidth: 74.4 inches\r\n\r\nHeight: 55.4 inches\r\n\r\nWheelbase: 107.7 inches\r\n\r\nGround Clearance: 4.8 inches\r\n\r\nExterior Features:\r\nDesign: Aggressive sporty styling with a Type R-specific body kit\r\n\r\nLighting: Full LED headlights and taillights\r\n\r\nWheels: 19-inch matte black alloy wheels\r\n\r\nSpoiler: Rear spoiler for enhanced aerodynamics\r\n\r\nExhaust: Center-mounted triple-outlet exhaust with Active Exhaust Valve\r\n\r\nInterior Features:\r\nSeating: High-bolstered sport seats with red/black suede-effect fabric and double red stitching\r\n\r\nDashboard: Digital instrument cluster with customizable displays\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 9-inch touchscreen with high-resolution\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility\r\n\r\nAudio: Bose premium sound system with 12 speakers, including a subwoofer\r\n\r\nComfort: Dual-zone automatic climate control, heated front seats, leather-wrapped steering wheel\r\n\r\nSafety and Driver-Assistance:\r\nHonda Sensing® Suite: Includes adaptive cruise control, lane-keeping assist, collision mitigation braking, and road departure mitigation\r\n\r\nAdditional Safety Features: Blind Spot Information System (BSI), Cross Traffic Monitor, Multi-angle rearview camera with dynamic guidelines, Traffic Sign Recognition (TSR), Driver Attention Monitor\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nSunroof: Power-operated moonroof\r\n\r\nStorage: Spacious trunk with split-folding rear seats for additional cargo space\r\n\r\nTechnology: Wireless charging pad, multiple USB ports, Bluetooth connectivity", 1, "Honda Type R", 1, "Honda Type R", 2399000000L, 6, "New" },
                { 4, "../Assets/Cars/Porche 992 Carrera Cabriolet/Red/1.jpg", "Engine and Performance:\r\nEngine: 3.0-liter twin-turbocharged flat-six engine.\r\n\r\nPower: Produces 379 horsepower and 331 lb-ft of torque.\r\n\r\nTransmission: 8-speed Porsche Doppelkupplung (PDK) automatic transmission with manual shift mode.\r\n\r\n0-60 mph: Approximately 4.2 seconds.\r\n\r\nTop Speed: Around 180 mph.\r\n\r\nFuel Efficiency: Approximately 20 mpg combined (18 mpg city / 24 mpg highway).\r\n\r\nDrive Mode: Features multiple drive modes, including Normal, Sport, Sport Plus, and Individual, allowing you to tailor the driving experience to your preferences.\r\n\r\nDimensions and Design:\r\nLength: 177.9 inches.\r\n\r\nWidth: 72.9 inches.\r\n\r\nHeight: 51.1 inches.\r\n\r\nWheelbase: 96.5 inches.\r\n\r\nCurb Weight: Approximately 3,472 lbs.\r\n\r\nExterior: Sleek design with iconic Porsche styling cues, including the distinctive rear light strip and wide rear stance.\r\n\r\nRoof: Retractable soft top that can be operated at speeds up to 31 mph, providing open-air driving experience in under 12 seconds.\r\n\r\nInterior Features:\r\nSeating: Luxurious and supportive sports seats with multiple adjustment options for enhanced comfort.\r\n\r\nDashboard: Digital and analog instrument cluster combining traditional elements with modern digital displays.\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 10.9-inch high-resolution touchscreen with Porsche Communication Management (PCM).\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility.\r\n\r\nAudio: High-end Bose Surround Sound System for immersive audio experience.\r\n\r\nComfort: Dual-zone automatic climate control, heated and ventilated front seats, premium materials including leather, Alcantara, and optional carbon fiber trims.\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Advanced system to maintain stability and control in various driving conditions.\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead.\r\n\r\nLane Keeping Assist: Helps to keep the vehicle centered in its lane.\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle for easier maneuvering.\r\n\r\nNight Vision Assist: Uses an infrared camera to detect pedestrians and animals in low-light conditions.\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start.\r\n\r\nDrive Modes: Normal, Sport, Sport Plus, and Individual settings.\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel based on current driving conditions and driver preferences.\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Enhances stability and reduces body roll during dynamic cornering.\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including Carrara White, Jet Black Metallic, Racing Yellow, and more.\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber.\r\n\r\nWheels: Multiple designs and sizes to choose from.", 1, "Porche 992 Carrera Cabriolet", 9, "Porche 992 Carrera Cabriolet", 8910000000L, 7, "New" },
                { 5, "../Assets/Cars/Porche 718 Cayman S/Blue/1.jpg", "Engine and Performance:\r\nEngine: 2.5-liter turbocharged flat-four\r\n\r\nPower: 350 horsepower @ 6,500 rpm\r\n\r\nTorque: 309 lb-ft @ 1,900-4,500 rpm\r\n\r\nTransmission: 6-speed manual or 7-speed PDK automatic\r\n\r\n0-60 mph: Approximately 4.6 seconds\r\n\r\nTop Speed: Around 177 mph\r\n\r\nFuel Efficiency:\r\n\r\nCity: 22 mpg\r\n\r\nHighway: 36 mpg\r\n\r\nCombined: 29 mpg\r\n\r\nDimensions:\r\nLength: 172.4 inches\r\n\r\nWidth: 70.9 inches\r\n\r\nHeight: 50.9 inches\r\n\r\nWheelbase: 97.4 inches\r\n\r\nCurb Weight: Approximately 3,153 lbs\r\n\r\nExterior Features:\r\nDesign: Sporty and aerodynamic with a distinctive Porsche look\r\n\r\nLighting: Full LED headlights and taillights\r\n\r\nWheels: 19-inch alloy wheels with performance tires\r\n\r\nSpoiler: Rear spoiler for improved downforce\r\n\r\nInterior Features:\r\nSeating: Comfortable sports seats with adjustable settings\r\n\r\nDashboard: Digital and analog instrument cluster\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 7-inch touchscreen with Porsche Communication Management (PCM)\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility\r\n\r\nAudio: High-quality sound system\r\n\r\nComfort: Dual-zone automatic climate control, heated and ventilated seats, leather-wrapped steering wheel\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Helps maintain stability and control\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead\r\n\r\nLane Keeping Assist: Helps keep the vehicle centered in its lane\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nDrive Modes: Includes Normal, Sport, and Sport Plus settings\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Enhances stability and reduces body roll during dynamic cornering", 1, "Porche 718 Cayman S", 9, "Porche 718 Cayman S", 4260000000L, 6, "New" },
                { 6, "../Assets/Cars/Porche 992 Carrera GTS/Red/1.jpg", "Engine and Performance:\r\nEngine: 3.0-liter twin-turbocharged flat-six engine\r\n\r\nPower Output: 473 horsepower (480 PS) @ 6,500 rpm\r\n\r\nTorque: 420 lb-ft (570 Nm) @ 2,300-5,000 rpm\r\n\r\nTransmission:\r\n\r\nStandard: 8-speed Porsche Doppelkupplung (PDK) dual-clutch automatic\r\n\r\nOptional: 7-speed manual transmission\r\n\r\nAcceleration:\r\n\r\n0-60 mph: Approximately 3.3 seconds with PDK\r\n\r\n0-60 mph: Approximately 3.4 seconds with manual transmission\r\n\r\nTop Speed: 193 mph (311 km/h)\r\n\r\nFuel Efficiency:\r\n\r\nCity: 18 mpg\r\n\r\nHighway: 24 mpg\r\n\r\nCombined: 20 mpg\r\n\r\nDimensions and Design:\r\nLength: 178.4 inches\r\n\r\nWidth: 72.9 inches\r\n\r\nHeight: 50.8 inches\r\n\r\nWheelbase: 96.5 inches\r\n\r\nCurb Weight: Approximately 3,453 lbs (1,566 kg)\r\n\r\nExterior:\r\n\r\nGTS-specific front fascia and rear diffuser\r\n\r\nSport Design side skirts\r\n\r\nDarkened LED headlights with Porsche Dynamic Light System (PDLS)\r\n\r\nBlack trim elements and badging\r\n\r\nOptional lightweight glass and carbon fiber roof\r\n\r\nInterior Features:\r\nSeating: Sports seats Plus with GTS logo, 4-way electric adjustment\r\n\r\nDashboard: Combination of digital and analog instrument cluster\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 10.9-inch Porsche Communication Management (PCM)\r\n\r\nConnectivity: Apple CarPlay, Android Auto, Porsche Connect\r\n\r\nAudio: BOSE Surround Sound System or optional Burmester High-End Surround Sound System\r\n\r\nComfort: Dual-zone automatic climate control, Alcantara and leather upholstery, optional carbon fiber trim\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Enhances stability by controlling braking and engine torque\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead\r\n\r\nLane Keeping Assist: Helps keep the vehicle centered in its lane\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle\r\n\r\nPorsche InnoDrive: Predicts driving conditions and adjusts speed accordingly\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nDrive Modes: Includes Normal, Sport, Sport Plus, and Individual settings\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Reduces body roll during dynamic cornering\r\n\r\nPorsche Torque Vectoring Plus (PTV Plus): Enhances traction and handling\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including GT Silver Metallic, Carrara White, Guards Red, and more\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber\r\n\r\nWheels: Multiple designs and sizes to choose from, including 20/21-inch staggered wheels", 1, "Porche 992 Carrera GTS", 9, "Porche 992 Carrera GTS", 9630000000L, 6, "New" },
                { 7, "../Assets/Cars/Porche 992 Carrera T/Green/1.jpg", "Engine and Performance:\r\nEngine: 3.0-liter twin-turbocharged flat-six engine.\r\n\r\nPower Output: 379 horsepower @ 6,500 rpm.\r\n\r\nTorque: 331 lb-ft @ 1,950-5,000 rpm.\r\n\r\nTransmission: 7-speed manual gearbox or optional 8-speed PDK dual-clutch automatic.\r\n\r\nAcceleration:\r\n\r\n0-60 mph: Approximately 4.3 seconds with manual transmission.\r\n\r\n0-60 mph: Approximately 4.0 seconds with PDK.\r\n\r\nTop Speed: 182 mph (293 km/h).\r\n\r\nFuel Efficiency: Approximately 20 mpg city / 26 mpg highway / 22 mpg combined.\r\n\r\nDimensions and Design:\r\nLength: 177.9 inches.\r\n\r\nWidth: 72.9 inches.\r\n\r\nHeight: 50.8 inches.\r\n\r\nWheelbase: 96.5 inches.\r\n\r\nCurb Weight: Approximately 3,197 lbs (1,450 kg).\r\n\r\nExterior:\r\n\r\nCarrera T-specific front fascia and rear diffuser.\r\n\r\nSport Design side skirts.\r\n\r\nBlack trim elements and badging.\r\n\r\nOptional lightweight glass and carbon fiber roof.\r\n\r\nStandard 20-inch front and 21-inch rear alloy wheels.\r\n\r\nInterior Features:\r\nSeating: 4-way adjustable Sport Seats Plus with Carrera T logo, available in Race-Tex.\r\n\r\nDashboard: Digital and analog instrument cluster combining traditional elements with modern digital displays.\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 10.9-inch high-resolution touchscreen with Porsche Communication Management (PCM).\r\n\r\nConnectivity: Apple CarPlay, Android Auto, Porsche Connect.\r\n\r\nAudio: High-end BOSE Surround Sound System or optional Burmester High-End Surround Sound System.\r\n\r\nComfort: Dual-zone automatic climate control, Alcantara-wrapped steering wheel and gear selector, optional carbon fiber trim.\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Advanced system to maintain stability and control in various driving conditions.\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead.\r\n\r\nLane Keeping Assist: Helps to keep the vehicle centered in its lane.\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle for easier maneuvering.\r\n\r\nNight Vision Assist: Uses an infrared camera to detect pedestrians and animals in low-light conditions.\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start.\r\n\r\nDrive Modes: Includes Normal, Sport, Sport Plus, and Individual settings.\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel based on current driving conditions and driver preferences.\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Enhances stability and reduces body roll during dynamic cornering.\r\n\r\nPorsche Torque Vectoring Plus (PTV Plus): Enhances traction and handling.\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including GT Silver Metallic, Carrara White, Guards Red, and more.\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber.\r\n\r\nWheels", 1, "Porche 992 Carrera T", 9, "Porche 992 Carrera T", 8310000000L, 6, "New" },
                { 8, "../Assets/Cars/Porche Taycan J1II/Blue/1.jpg", "Engine and Performance:\r\nEngine: Electric motor\r\n\r\nPower Output: 872 bhp (884 PS / 650 kW)\r\n\r\nTorque: 940 Nm (693 lb-ft / 95.9 kgm)\r\n\r\nTransmission: 2-speed automatic transmission\r\n\r\nAcceleration:\r\n\r\n0-60 mph: 2.5 seconds\r\n\r\n0-100 km/h: 2.7 seconds\r\n\r\nTop Speed: 260 km/h (162 mph)\r\n\r\nFuel Efficiency: Approximately 20 kWh/100 km\r\n\r\nDimensions and Design:\r\nLength: 4962 mm (195.4 inches)\r\n\r\nWidth: 1966 mm (77.4 inches)\r\n\r\nHeight: 1381 mm (54.4 inches)\r\n\r\nWheelbase: 2900 mm (114.2 inches)\r\n\r\nCurb Weight: 2290 kg (5049 lbs)\r\n\r\nExterior: Sleek sedan design with aerodynamic features\r\n\r\nInterior Features:\r\nSeating: 4/5 seats\r\n\r\nInfotainment System: High-resolution touchscreen with Porsche Communication Management (PCM)\r\n\r\nConnectivity: Apple CarPlay, Android Auto, Porsche Connect\r\n\r\nAudio: BOSE Surround Sound System or optional Burmester High-End Surround Sound System\r\n\r\nComfort: Dual-zone automatic climate control, Alcantara and leather upholstery, optional carbon fiber trim\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Enhances stability by controlling braking and engine torque\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead\r\n\r\nLane Keeping Assist: Helps keep the vehicle centered in its lane\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle\r\n\r\nNight Vision Assist: Uses an infrared camera to detect pedestrians and animals in low-light conditions\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nDrive Modes: Includes Normal, Sport, Sport Plus, and Individual settings\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Reduces body roll during dynamic cornering\r\n\r\nPorsche Torque Vectoring Plus (PTV Plus): Enhances traction and handling\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber\r\n\r\nWheels: Multiple designs and sizes to choose from", 2, "Porche Taycan J1II", 9, "Porche Taycan J1II", 4620000000L, 6, "New" },
                { 9, "../Assets/Cars/Toyota Corolla Altis 1.8G/Black/1.jpg", "Engine and Performance:\r\nEngine Type: 1.8-liter 4-cylinder DOHC Dual VVT-i\r\n\r\nPower Output: 140 horsepower @ 6,200 rpm\r\n\r\nTorque: 173 Nm @ 4,000 rpm\r\n\r\nTransmission: CVT (Continuously Variable Transmission) with Sequential Shift\r\n\r\nFuel Efficiency:\r\n\r\nCity: Approximately 7-8 km/l\r\n\r\nHighway: Approximately 10-12 km/l\r\n\r\nDrive Type: Front-Wheel Drive\r\n\r\nDimensions and Design:\r\nLength: 4,630 mm\r\n\r\nWidth: 1,780 mm\r\n\r\nHeight: 1,435 mm\r\n\r\nWheelbase: 2,700 mm\r\n\r\nGround Clearance: 130 mm\r\n\r\nCurb Weight: Approximately 1,325 kg\r\n\r\nExterior Features:\r\n\r\nLED Headlights with LED Daytime Running Lights\r\n\r\nFront Fog Lamps\r\n\r\nChrome Accents on Grille and Door Handles\r\n\r\n16-inch Alloy Wheels\r\n\r\nInterior Features:\r\nSeating Capacity: 5 passengers\r\n\r\nUpholstery: High-quality fabric seats\r\n\r\nDashboard: Clean and ergonomic design with a combination of analog and digital displays\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 7-inch touchscreen with user-friendly interface\r\n\r\nConnectivity: Bluetooth, USB, and AUX compatibility\r\n\r\nAudio System: 6-speaker audio system\r\n\r\nComfort and Convenience:\r\n\r\nDual-zone automatic climate control\r\n\r\nPower-adjustable driver's seat\r\n\r\nRear seats with 60:40 split-folding feature\r\n\r\nMultifunction steering wheel with audio and cruise control buttons\r\n\r\nSafety and Driver-Assistance:\r\nSafety Ratings: 5-star ASEAN NCAP rating\r\n\r\nAirbags: Dual front airbags, side airbags, and curtain airbags\r\n\r\nBraking Systems:\r\n\r\nAnti-lock Braking System (ABS)\r\n\r\nElectronic Brake-force Distribution (EBD)\r\n\r\nBrake Assist (BA)\r\n\r\nStability and Traction:\r\n\r\nVehicle Stability Control (VSC)\r\n\r\nTraction Control System (TCS)\r\n\r\nAdditional Safety Features:\r\n\r\nRear Parking Sensors with Reverse Camera\r\n\r\nHill-start Assist Control (HAC)\r\n\r\nTire Pressure Monitoring System (TPMS)\r\n\r\nPre-Collision System (PCS) with pedestrian detection\r\n\r\nLane Departure Alert (LDA) with Steering Assist\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Smart Entry with push-button start\r\n\r\nLighting: Ambient interior lighting\r\n\r\nStorage: Spacious trunk with a capacity of 470 liters\r\n\r\nTechnology: Optitron meter with 4.2-inch TFT MID (Multi-Information Display)\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including Super White, Silver Metallic, Attitude Black, Phantom Brown, and Red Mica Metallic\r\n\r\nInterior Options: Various upholstery options and trim materials including fabric and leather\r\n\r\nWheels", 1, "Toyota Corolla Altis 1.8G", 3, "Toyota Corolla Altis 1.8G", 725000000L, 1, "New" },
                { 10, "../Assets/Cars/Vinfast VF7/Blue/1.png", "Engine and Performance:\r\nEngine: Dual electric motors (VF7 Plus)\r\n\r\nPower Output: 174 horsepower (VF7 S), 348 horsepower (VF7 Plus)\r\n\r\nTorque: 250 Nm (VF7 S), 500 Nm (VF7 Plus)\r\n\r\nTransmission: Single-speed (VF7 S), Dual-speed (VF7 Plus)\r\n\r\nAcceleration: 0-100 km/h in 11 seconds (VF7 S), 5.8 seconds (VF7 Plus)\r\n\r\nTop Speed: 150 km/h (VF7 S), 175 km/h (VF7 Plus)\r\n\r\nBattery Capacity: 59.6 kWh (VF7 S), 75.3 kWh (VF7 Plus)\r\n\r\nRange: 375 km (VF7 S), 431 km (VF7 Plus)\r\n\r\nCharging Time: 10-70% in 24.1 minutes (VF7 S), 24.6 minutes (VF7 Plus)\r\n\r\nDimensions and Design:\r\nLength: 4,545 mm\r\n\r\nWidth: 1,890 mm\r\n\r\nHeight: 1,635 mm\r\n\r\nWheelbase: 2,840 mm\r\n\r\nCurb Weight: 2,085 kg (VF7 S), 2,205 kg (VF7 Plus)\r\n\r\nExterior Features: LED light bars, smooth body panels, flush door handles, bold A-wing front apron, aggressive rear design\r\n\r\nInterior Features:\r\nSeating Capacity: 5 passengers\r\n\r\nUpholstery: Vegan leather seats with ventilation (VF7 Plus)\r\n\r\nInfotainment System: 12.9-inch touchscreen (VF7 S), 15.6-inch touchscreen (VF7 Plus)\r\n\r\nConnectivity: USB Type C charger, wireless charging, WiFi hotspot\r\n\r\nComfort and Convenience: Dual-zone climate control, 8-way powered driver's seat, panoramic sunroof (VF7 Plus)\r\n\r\nSafety and Driver-Assistance:\r\nAirbags: 6 SRS airbags\r\n\r\nBraking Systems: ABS with EBD, stability control\r\n\r\nAdditional Safety Features: Blind spot detection, parking sensors with rearview camera, 360-degree camera (VF7 Plus), Level 2 self-driving tech with lane keeping assist, adaptive cruise control with traffic jam assist, forward collision warning with automatic braking\r\n\r\nAdditional Features:\r\nDriving Modes: Eco, Normal, Sport\r\n\r\nSuspension: Independent MacPherson strut (front), independent control blade (rear)\r\n\r\nWheels: 19-inch wheels (VF7 S), 20-inch wheels (VF7 Plus)", 2, "Vinfast VF7", 8, "Vinfast VF7", 850000000L, 2, "New" }
            });

        migrationBuilder.InsertData(
            table: "Details",
            columns: new[] { "CarId", "MaxDistance", "NumberSeat", "TimeGet100", "Year" },
            values: new object[,]
            {
                { 1, 770, 5, 8.6999999999999993, 2022 },
                { 2, 640, 5, 10.199999999999999, 2020 },
                { 3, 850, 4, 5.2000000000000002, 2022 },
                { 4, 710, 4, 3.3999999999999999, 2018 },
                { 5, 800, 2, 4.2000000000000002, 2023 },
                { 6, 750, 4, 3.3999999999999999, 2023 },
                { 7, 780, 4, 4.5, 2023 },
                { 8, 480, 4, 3.8999999999999999, 2023 },
                { 9, 900, 5, 10.0, 2023 },
                { 10, 470, 5, 8.5, 2023 }
            });

        migrationBuilder.InsertData(
            table: "variantsOfCars",
            columns: new[] { "CarId", "VariantId", "Name" },
            values: new object[,]
            {
                { 1, 1, "Trắng Ngọc Trai" },
                { 1, 2, "Xám khói" },
                { 1, 3, "Đen huyền bí" },
                { 2, 1, "Trắng tuyết" },
                { 2, 3, "Đen huyền bí" },
                { 2, 6, "Đỏ hoàng hôn" },
                { 3, 1, "Trắng tuyết" },
                { 3, 3, "Đen huyền bí" },
                { 3, 4, "Xanh thẳm" },
                { 3, 6, "Đỏ hoàng hôn" },
                { 4, 6, "Đỏ hoàng hôn" },
                { 5, 4, "Xanh đại dương" },
                { 6, 6, "Đỏ hoàng hôn" },
                { 7, 5, "Xanh đọt chuối" },
                { 8, 4, "Xanh hy vọng" },
                { 9, 3, "Đen khói" },
                { 10, 4, "Xanh hy vọng" }
            });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Details",
            keyColumn: "CarId",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "EngineTypes",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 1, 1 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 1, 2 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 1, 3 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 2, 1 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 2, 3 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 2, 6 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 3, 1 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 3, 3 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 3, 4 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 3, 6 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 4, 6 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 5, 4 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 6, 6 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 7, 5 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 8, 4 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 9, 3 });

        migrationBuilder.DeleteData(
            table: "variantsOfCars",
            keyColumns: new[] { "CarId", "VariantId" },
            keyValues: new object[] { 10, 4 });

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 7);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "Cars",
            keyColumn: "CarId",
            keyValue: 10);

        migrationBuilder.DeleteData(
            table: "variants",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "variants",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "variants",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "variants",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "variants",
            keyColumn: "Id",
            keyValue: 5);

        migrationBuilder.DeleteData(
            table: "variants",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "EngineTypes",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "EngineTypes",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "EngineTypes",
            keyColumn: "Id",
            keyValue: 4);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 8);

        migrationBuilder.DeleteData(
            table: "Manufacturers",
            keyColumn: "Id",
            keyValue: 9);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 1);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 2);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 3);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 6);

        migrationBuilder.DeleteData(
            table: "TypeOfCars",
            keyColumn: "Id",
            keyValue: 7);
    }
}
