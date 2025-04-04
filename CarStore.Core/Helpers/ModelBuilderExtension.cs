﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarStore.Core.Models;

namespace CarStore.Core.Helpers;
public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Username = "admin",
                Email = "admin@gmail.com",
                IsShowroom = false,
            },

            new User
            {
                Id = 2,
                Username = "anycar",
                Email = "anycar@gmail.com",
                IsShowroom = true,
            },

            new User
            {
                Id = 3,
                Username = "StarupShow",
                Email = "StarupShow@gmail.com",
                IsShowroom = true,
            }
        );

        modelBuilder.Entity<Showroom>().HasData(
            new Showroom
            {
                Id = 1,
                UserId = 2,
                Hotline = "18006216",
                Email = "info@anycar.vn",
                IsReputation = true,
                Facebook = "https://www.facebook.com/anycar.vn/",
                Home = "https://anycar.vn/",
                Name = "Anycar.vn",
                Img = "../Assets/ShowRoomAvatar.jpg"
            },

            new Showroom
            {
                Id = 2,
                UserId = 3,
                Hotline = "18006215",
                Email = "info@StarupShow.vn",
                Name = "Star-up Show",
                Img = "../Assets/ShowRoom2.png"
            }
        );

        modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id=1,
                ShowroomId = 1,
                Street = "Số 3-5 Nguyễn Văn Linh, P. Gia Thụy, Q. Long Biên, Hà Nội",
                City = "Hà Nội"
            },
            new Address
            {
                Id = 2,
                ShowroomId = 1,
                Street = "Số 250 Lương Định Của, P. An Phú, TP. Thủ Đức, TP Hồ Chí Minh",
                City = "Hồ Chí Minh"
            },
            new Address
            {
                Id = 3,
                ShowroomId = 2,
                Street = "Vành đài ktx B, TP. Thủ Đức, TP Hồ Chí Minh",
                City = "Hồ Chí Minh"
            }
        );

        modelBuilder.Entity<EngineType>().HasData(
            new EngineType { Id = 1, Name = "Xăng" },
            new EngineType { Id = 2, Name = "Điện" },
            new EngineType { Id = 3, Name = "Diesel" },
            new EngineType { Id = 4, Name = "Hybrid" }
        );

        modelBuilder.Entity<Manufacturer>().HasData(
            new Manufacturer { Id = 1, Name = "Honda" },
            new Manufacturer { Id = 2, Name = "Volkswagen" },
            new Manufacturer { Id = 3, Name = "Toyota" },
            new Manufacturer { Id = 4, Name = "Mercedes" },
            new Manufacturer { Id = 5, Name = "Ford" },
            new Manufacturer { Id = 6, Name = "Tesla" },
            new Manufacturer { Id = 7, Name = "Nissan" },
            new Manufacturer { Id = 8, Name = "Vinfast" },
            new Manufacturer { Id = 9, Name = "Porsche" },
            new Manufacturer { Id = 10, Name = "Chevrolet" },
            new Manufacturer { Id = 11, Name = "Mercedes-Benz" },
            new Manufacturer { Id = 12, Name = "Hyundai" },
            new Manufacturer { Id = 13, Name = "Isuzu" },
            new Manufacturer { Id = 14, Name = "Suzuki" },
            new Manufacturer { Id = 15, Name = "Kia" },
            new Manufacturer { Id = 16, Name = "Mitsubishi" },
            new Manufacturer { Id = 17, Name = "Lexus" },
            new Manufacturer { Id = 18, Name = "Mazda" },
            new Manufacturer { Id = 19, Name = "BMW" },
            new Manufacturer { Id = 20, Name = "Peugeot" },
            new Manufacturer { Id = 21, Name = "Audi" },
            new Manufacturer { Id = 22, Name = "Land Rover" },
            new Manufacturer { Id = 23, Name = "Lamborghini" },
            new Manufacturer { Id = 24, Name = "Volvo" },
            new Manufacturer { Id = 25, Name = "Jaguar" },
            new Manufacturer { Id = 26, Name = "Bentley" }
        );

        modelBuilder.Entity<TypeOfCar>().HasData(
            new()
            {
                Id = 1,
                Name = "Sedan",
                ImageLocation = "../Assets/CategoryBackground/sedan.png",
            },
            new()
            {
                Id = 2,
                Name = "HatchBack",
                ImageLocation = "../Assets/CategoryBackground/hatchback.png",
            },
            new()
            {
                Id = 3,
                Name = "SUV",
                ImageLocation = "../Assets/CategoryBackground/suv.png",
            },
            new()
            {
                Id = 4,
                Name = "CUV",
                ImageLocation = "../Assets/CategoryBackground/cuv.png",
            },
            new()
            {
                Id = 5,
                Name = "Minivan",
                ImageLocation = "../Assets/CategoryBackground/minivan.png",
            },
            new()
            {
                Id = 6,
                Name = "Coupe",
                ImageLocation = "../Assets/CategoryBackground/coupe.png",
            },
            new()
            {
                Id = 7,
                Name = "Convertible",
                ImageLocation = "../Assets/CategoryBackground/convertible.png",
            },
            new()
            {
                Id = 8,
                Name = "Pickup",
                ImageLocation = "../Assets/CategoryBackground/pickup.png",
            }
        );

        modelBuilder.Entity<PriceOfCar>().HasData(
            new()
            {
                Id = 1,
                Name = "Dưới 500 triệu",
            },
            new()
            {
                Id = 2,
                Name = "500 triệu - 1 tỷ",
            },
            new()
            {
                Id = 3,
                Name = "1 tỷ - 2 tỷ",
            },
            new()
            {
                Id = 4,
                Name = "2 tỷ - 3 tỷ",
            },
            new()
            {
                Id = 5,
                Name = "Trên 3 tỷ",
            }
        );

        modelBuilder.Entity<Variant>().HasData(
            new Variant { Id = 1, Code = "White" },
            new Variant { Id = 2, Code = "Gray" },
            new Variant { Id = 3, Code = "Black" },
            new Variant { Id = 4, Code = "Blue" },
            new Variant { Id = 5, Code = "Green" },
            new Variant { Id = 6, Code = "Red" },
            new Variant { Id = 7, Code = "AliceBlue" },
            new Variant { Id = 8, Code = "AntiqueWhite" },
            new Variant { Id = 9, Code = "Aqua" },
            new Variant { Id = 10, Code = "Aquamarine" },
            new Variant { Id = 11, Code = "Azure" },
            new Variant { Id = 12, Code = "Beige" },
            new Variant { Id = 13, Code = "Bisque" },
            new Variant { Id = 14, Code = "BlanchedAlmond" },
            new Variant { Id = 15, Code = "BlueViolet" },
            new Variant { Id = 16, Code = "Brown" },
            new Variant { Id = 17, Code = "BurlyWood" },
            new Variant { Id = 18, Code = "CadetBlue" },
            new Variant { Id = 19, Code = "Chartreuse" },
            new Variant { Id = 20, Code = "Chocolate" },
            new Variant { Id = 21, Code = "Coral" },
            new Variant { Id = 22, Code = "CornflowerBlue" },
            new Variant { Id = 23, Code = "Cornsilk" },
            new Variant { Id = 24, Code = "Crimson" },
            new Variant { Id = 25, Code = "Cyan" },
            new Variant { Id = 26, Code = "DarkBlue" },
            new Variant { Id = 27, Code = "DarkCyan" },
            new Variant { Id = 28, Code = "DarkGoldenrod" },
            new Variant { Id = 29, Code = "DarkGray" },
            new Variant { Id = 30, Code = "DarkGreen" },
            new Variant { Id = 31, Code = "DarkKhaki" },
            new Variant { Id = 32, Code = "DarkMagenta" },
            new Variant { Id = 33, Code = "DarkOliveGreen" },
            new Variant { Id = 34, Code = "DarkOrange" },
            new Variant { Id = 35, Code = "DarkOrchid" },
            new Variant { Id = 36, Code = "DarkRed" },
            new Variant { Id = 37, Code = "DarkSalmon" },
            new Variant { Id = 38, Code = "DarkSeaGreen" },
            new Variant { Id = 39, Code = "DarkSlateBlue" },
            new Variant { Id = 40, Code = "DarkSlateGray" },
            new Variant { Id = 41, Code = "DarkTurquoise" },
            new Variant { Id = 42, Code = "DarkViolet" },
            new Variant { Id = 43, Code = "DeepPink" },
            new Variant { Id = 44, Code = "DeepSkyBlue" },
            new Variant { Id = 45, Code = "DimGray" },
            new Variant { Id = 46, Code = "DodgerBlue" },
            new Variant { Id = 47, Code = "Firebrick" },
            new Variant { Id = 48, Code = "FloralWhite" },
            new Variant { Id = 49, Code = "ForestGreen" },
            new Variant { Id = 50, Code = "Fuchsia" },
            new Variant { Id = 51, Code = "Gainsboro" },
            new Variant { Id = 52, Code = "GhostWhite" },
            new Variant { Id = 53, Code = "Gold" },
            new Variant { Id = 54, Code = "Goldenrod" },
            new Variant { Id = 55, Code = "GreenYellow" },
            new Variant { Id = 56, Code = "Honeydew" },
            new Variant { Id = 57, Code = "HotPink" },
            new Variant { Id = 58, Code = "IndianRed" },
            new Variant { Id = 59, Code = "Indigo" },
            new Variant { Id = 60, Code = "Ivory" },
            new Variant { Id = 61, Code = "Khaki" },
            new Variant { Id = 62, Code = "Lavender" },
            new Variant { Id = 63, Code = "LavenderBlush" },
            new Variant { Id = 64, Code = "LawnGreen" },
            new Variant { Id = 65, Code = "LemonChiffon" },
            new Variant { Id = 66, Code = "LightBlue" },
            new Variant { Id = 67, Code = "LightCoral" },
            new Variant { Id = 68, Code = "LightCyan" },
            new Variant { Id = 69, Code = "LightGoldenrodYellow" },
            new Variant { Id = 70, Code = "LightGray" },
            new Variant { Id = 71, Code = "LightGreen" },
            new Variant { Id = 72, Code = "LightPink" },
            new Variant { Id = 73, Code = "LightSalmon" },
            new Variant { Id = 74, Code = "LightSeaGreen" },
            new Variant { Id = 75, Code = "LightSkyBlue" },
            new Variant { Id = 76, Code = "LightSlateGray" },
            new Variant { Id = 77, Code = "LightSteelBlue" },
            new Variant { Id = 78, Code = "LightYellow" },
            new Variant { Id = 79, Code = "Lime" },
            new Variant { Id = 80, Code = "LimeGreen" },
            new Variant { Id = 81, Code = "Linen" },
            new Variant { Id = 82, Code = "Magenta" },
            new Variant { Id = 83, Code = "Maroon" },
            new Variant { Id = 84, Code = "MediumAquamarine" },
            new Variant { Id = 85, Code = "MediumBlue" },
            new Variant { Id = 86, Code = "MediumOrchid" },
            new Variant { Id = 87, Code = "MediumPurple" },
            new Variant { Id = 88, Code = "MediumSeaGreen" },
            new Variant { Id = 89, Code = "MediumSlateBlue" },
            new Variant { Id = 90, Code = "MediumSpringGreen" },
            new Variant { Id = 91, Code = "MediumTurquoise" },
            new Variant { Id = 92, Code = "MediumVioletRed" },
            new Variant { Id = 93, Code = "MidnightBlue" },
            new Variant { Id = 94, Code = "MintCream" },
            new Variant { Id = 95, Code = "MistyRose" },
            new Variant { Id = 96, Code = "Moccasin" },
            new Variant { Id = 97, Code = "NavajoWhite" },
            new Variant { Id = 98, Code = "Navy" },
            new Variant { Id = 99, Code = "OldLace" },
            new Variant { Id = 100, Code = "Olive" },
            new Variant { Id = 101, Code = "OliveDrab" },
            new Variant { Id = 102, Code = "Orange" },
            new Variant { Id = 103, Code = "OrangeRed" },
            new Variant { Id = 104, Code = "Orchid" },
            new Variant { Id = 105, Code = "PaleGoldenrod" },
            new Variant { Id = 106, Code = "PaleGreen" },
            new Variant { Id = 107, Code = "PaleTurquoise" },
            new Variant { Id = 108, Code = "PaleVioletRed" },
            new Variant { Id = 109, Code = "PapayaWhip" },
            new Variant { Id = 110, Code = "PeachPuff" },
            new Variant { Id = 111, Code = "Peru" },
            new Variant { Id = 112, Code = "Pink" },
            new Variant { Id = 113, Code = "Plum" },
            new Variant { Id = 114, Code = "PowderBlue" },
            new Variant { Id = 115, Code = "Purple" },
            new Variant { Id = 116, Code = "RosyBrown" },
            new Variant { Id = 117, Code = "RoyalBlue" },
            new Variant { Id = 118, Code = "SaddleBrown" },
            new Variant { Id = 119, Code = "Salmon" },
            new Variant { Id = 120, Code = "SandyBrown" },
            new Variant { Id = 121, Code = "SeaGreen" },
            new Variant { Id = 122, Code = "Seashell" },
            new Variant { Id = 123, Code = "Sienna" },
            new Variant { Id = 124, Code = "Silver" },
            new Variant { Id = 125, Code = "SkyBlue" },
            new Variant { Id = 126, Code = "SlateBlue" },
            new Variant { Id = 127, Code = "SlateGray" },
            new Variant { Id = 128, Code = "Snow" },
            new Variant { Id = 129, Code = "SpringGreen" },
            new Variant { Id = 130, Code = "SteelBlue" },
            new Variant { Id = 131, Code = "Tan" },
            new Variant { Id = 132, Code = "Teal" },
            new Variant { Id = 133, Code = "Thistle" },
            new Variant { Id = 134, Code = "Tomato" },
            new Variant { Id = 135, Code = "Turquoise" },
            new Variant { Id = 136, Code = "Violet" },
            new Variant { Id = 137, Code = "Wheat" },
            new Variant { Id = 138, Code = "WhiteSmoke" },
            new Variant { Id = 139, Code = "Yellow" },
            new Variant { Id = 140, Code = "YellowGreen" }
        );

        modelBuilder.Entity<Car>().HasData(
            new()
            {
                CarId = 1,
                Name = "Honda Accord",
                ManufacturerId = 1,
                EngineTypeId = 4,
                TypeOfCarId = 3,
                Price = 1319000000,
                UsageStatus = "New",
                Description = "Engine Options:\r\n1.5L DI VTEC Turbo:\r\n\r\nHorsepower: 192 hp @ 6,000 rpm\r\n\r\nTorque: 192 lb-ft @ 1,700-5,000 rpm\r\n\r\nFuel Efficiency: 29 mpg city / 37 mpg highway / 32 mpg combined\r\n\r\n2.0L DI Atkinson (Hybrid):\r\n\r\nHorsepower: 146 hp @ 6,100 rpm\r\n\r\nTorque: 134 lb-ft @ 4,500 rpm\r\n\r\nFuel Efficiency: 46 mpg city / 41 mpg highway / 44 mpg combined\r\n\r\n2.0L DI Atkinson (Hybrid):\r\n\r\nTotal System Horsepower: 204 hp\r\n\r\nTorque: 247 lb-ft @ 0-2,000 rpm\r\n\r\nDrivetrain:\r\nFront-Wheel Drive\r\n\r\nContinuously Variable Transmission (CVT) for non-hybrid models\r\n\r\nTwo-Motor Hybrid System for hybrid models\r\n\r\nDimensions:\r\nLength: 195.7 inches\r\n\r\nWidth: 73.3 inches\r\n\r\nHeight: 57.1 inches\r\n\r\nWheelbase: 111.4 inches\r\n\r\nGround Clearance: 5.3 inches\r\n\r\nInterior:\r\nSeating Capacity: 5\r\n\r\nCargo Capacity: 16.7 cubic feet\r\n\r\nHeadroom (First Row): 39.5 inches\r\n\r\nLegroom (First Row): 42.3 inches\r\n\r\nLegroom (Second Row): 40.8 inches\r\n\r\nSafety Features:\r\nHonda Sensing® Suite: Includes adaptive cruise control, lane-keeping assist, collision mitigation braking, and road departure mitigation2\r\n\r\nBlind Spot and Lane Departure Warnings\r\n\r\nRear Cross Traffic Alert\r\n\r\nDriver Attention Monitor\r\n\r\nPre-Collision System with Pedestrian Detection\r\n\r\nMultiple Airbags: Front, side, and curtain airbags\r\n\r\nAdditional Features:\r\n12.3-inch Touch-Screen Display\r\n\r\nApple CarPlay® and Android Auto™ Compatibility\r\n\r\nWireless Charging\r\n\r\nPremium Audio System\r\n\r\nMultiple Drive Modes: Econ, Normal, Sport, and Individual (for hybrid trims)",
                Images = "Honda Accord",
                DefautlImageLocation = "../Assets/Cars/Honda Accord/White/1.png",
                PriceOfCarId = 3,
                OwnerId = 2,
            },
            new()
            {
                CarId = 2,
                Name = "Honda Civic City Rs",
                ManufacturerId = 1,
                EngineTypeId = 1,
                TypeOfCarId = 1,
                Price = 889000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: 1.5-liter VTEC Turbocharged Inline-4\r\n\r\nPower Output: 180 horsepower @ 6,000 rpm\r\n\r\nTorque: 177 lb-ft @ 1,700-4,500 rpm\r\n\r\nTransmission: Continuously Variable Transmission (CVT) with paddle shifters\r\n\r\nDrive Type: Front-Wheel Drive\r\n\r\nFuel Efficiency:\r\n\r\nCity: Approximately 30 mpg\r\n\r\nHighway: Approximately 38 mpg\r\n\r\nCombined: Approximately 33-34 mpg\r\n\r\nDimensions:\r\nLength: 184 inches\r\n\r\nWidth: 70.9 inches\r\n\r\nHeight: 55.7 inches\r\n\r\nWheelbase: 107.7 inches\r\n\r\nCurb Weight: 2,950 lbs (approx.)\r\n\r\nExterior Features:\r\nDesign: Aggressive sporty styling with a RS-specific body kit\r\n\r\nLighting: Full LED headlights and taillights\r\n\r\nWheels: 18-inch alloy wheels with a distinctive design\r\n\r\nSpoiler: Rear spoiler for enhanced aerodynamics\r\n\r\nInterior Features:\r\nSeating: Sporty front seats with RS-specific upholstery\r\n\r\nDashboard: Digital instrument cluster with customizable displays\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 9-inch touchscreen with high-resolution\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility\r\n\r\nAudio: Premium sound system with multiple speakers\r\n\r\nComfort: Dual-zone automatic climate control, heated front seats, leather-wrapped steering wheel\r\n\r\nSafety and Driver-Assistance:\r\nHonda Sensing® Suite:\r\n\r\nAdaptive Cruise Control (ACC)\r\n\r\nLane Keeping Assist System (LKAS)\r\n\r\nCollision Mitigation Braking System™ (CMBS)\r\n\r\nRoad Departure Mitigation System (RDM)\r\n\r\nAdditional Safety Features:\r\n\r\nBlind Spot Information System (BSI)\r\n\r\nCross Traffic Monitor\r\n\r\nMulti-angle Rearview Camera with Dynamic Guidelines\r\n\r\nTraffic Sign Recognition (TSR)\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nSunroof: Power-operated moonroof\r\n\r\nStorage: Spacious trunk with split-folding rear seats for additional cargo space\r\n\r\nTechnology: Wireless charging pad, multiple USB ports, Bluetooth connectivity\r\n\r\nColors and Customization:\r\nExterior Color Options: Wide range of colors including Platinum White Pearl, Sonic Gray Pearl, Rallye Red, and more\r\n\r\nInterior Options: Sporty black with red stitching",
                Images = "Honda Civic City Rs",
                DefautlImageLocation = "../Assets/Cars/Honda Civic City Rs/Black/1.png",
                PriceOfCarId = 2,
                OwnerId = 2,
            },
            new()
            {
                CarId = 3,
                Name = "Honda Type R",
                ManufacturerId = 1,
                EngineTypeId = 1,
                TypeOfCarId = 6,
                Price = 2399000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: 2.0-liter turbocharged VTEC Inline-4\r\n\r\nHorsepower: 315 hp @ 6,500 rpm\r\n\r\nTorque: 310 lb-ft @ 2,600-4,000 rpm\r\n\r\nTransmission: 6-speed manual with rev-match control\r\n\r\nFuel Efficiency:\r\n\r\nCity: 22 mpg\r\n\r\nHighway: 28 mpg\r\n\r\nCombined: 24 mpg\r\n\r\nDrive Type: Front-Wheel Drive\r\n\r\nDimensions:\r\nLength: 180.9 inches\r\n\r\nWidth: 74.4 inches\r\n\r\nHeight: 55.4 inches\r\n\r\nWheelbase: 107.7 inches\r\n\r\nGround Clearance: 4.8 inches\r\n\r\nExterior Features:\r\nDesign: Aggressive sporty styling with a Type R-specific body kit\r\n\r\nLighting: Full LED headlights and taillights\r\n\r\nWheels: 19-inch matte black alloy wheels\r\n\r\nSpoiler: Rear spoiler for enhanced aerodynamics\r\n\r\nExhaust: Center-mounted triple-outlet exhaust with Active Exhaust Valve\r\n\r\nInterior Features:\r\nSeating: High-bolstered sport seats with red/black suede-effect fabric and double red stitching\r\n\r\nDashboard: Digital instrument cluster with customizable displays\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 9-inch touchscreen with high-resolution\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility\r\n\r\nAudio: Bose premium sound system with 12 speakers, including a subwoofer\r\n\r\nComfort: Dual-zone automatic climate control, heated front seats, leather-wrapped steering wheel\r\n\r\nSafety and Driver-Assistance:\r\nHonda Sensing® Suite: Includes adaptive cruise control, lane-keeping assist, collision mitigation braking, and road departure mitigation\r\n\r\nAdditional Safety Features: Blind Spot Information System (BSI), Cross Traffic Monitor, Multi-angle rearview camera with dynamic guidelines, Traffic Sign Recognition (TSR), Driver Attention Monitor\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nSunroof: Power-operated moonroof\r\n\r\nStorage: Spacious trunk with split-folding rear seats for additional cargo space\r\n\r\nTechnology: Wireless charging pad, multiple USB ports, Bluetooth connectivity",
                Images = "Honda Type R",
                DefautlImageLocation = "../Assets/Cars/Honda Type R/Black/2.png",
                PriceOfCarId = 4,
                OwnerId = 3,
            },
            new()
            {
                CarId = 4,
                Name = "Porche 992 Carrera Cabriolet",
                ManufacturerId = 9,
                EngineTypeId = 1,
                TypeOfCarId = 7,
                Price = 8910000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: 3.0-liter twin-turbocharged flat-six engine.\r\n\r\nPower: Produces 379 horsepower and 331 lb-ft of torque.\r\n\r\nTransmission: 8-speed Porsche Doppelkupplung (PDK) automatic transmission with manual shift mode.\r\n\r\n0-60 mph: Approximately 4.2 seconds.\r\n\r\nTop Speed: Around 180 mph.\r\n\r\nFuel Efficiency: Approximately 20 mpg combined (18 mpg city / 24 mpg highway).\r\n\r\nDrive Mode: Features multiple drive modes, including Normal, Sport, Sport Plus, and Individual, allowing you to tailor the driving experience to your preferences.\r\n\r\nDimensions and Design:\r\nLength: 177.9 inches.\r\n\r\nWidth: 72.9 inches.\r\n\r\nHeight: 51.1 inches.\r\n\r\nWheelbase: 96.5 inches.\r\n\r\nCurb Weight: Approximately 3,472 lbs.\r\n\r\nExterior: Sleek design with iconic Porsche styling cues, including the distinctive rear light strip and wide rear stance.\r\n\r\nRoof: Retractable soft top that can be operated at speeds up to 31 mph, providing open-air driving experience in under 12 seconds.\r\n\r\nInterior Features:\r\nSeating: Luxurious and supportive sports seats with multiple adjustment options for enhanced comfort.\r\n\r\nDashboard: Digital and analog instrument cluster combining traditional elements with modern digital displays.\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 10.9-inch high-resolution touchscreen with Porsche Communication Management (PCM).\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility.\r\n\r\nAudio: High-end Bose Surround Sound System for immersive audio experience.\r\n\r\nComfort: Dual-zone automatic climate control, heated and ventilated front seats, premium materials including leather, Alcantara, and optional carbon fiber trims.\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Advanced system to maintain stability and control in various driving conditions.\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead.\r\n\r\nLane Keeping Assist: Helps to keep the vehicle centered in its lane.\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle for easier maneuvering.\r\n\r\nNight Vision Assist: Uses an infrared camera to detect pedestrians and animals in low-light conditions.\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start.\r\n\r\nDrive Modes: Normal, Sport, Sport Plus, and Individual settings.\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel based on current driving conditions and driver preferences.\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Enhances stability and reduces body roll during dynamic cornering.\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including Carrara White, Jet Black Metallic, Racing Yellow, and more.\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber.\r\n\r\nWheels: Multiple designs and sizes to choose from.",
                Images = "Porche 992 Carrera Cabriolet",
                DefautlImageLocation = "../Assets/Cars/Porche 992 Carrera Cabriolet/Red/1.jpg",
                PriceOfCarId = 5,
                OwnerId = 3,
            },
            new()
            {
                CarId = 5,
                Name = "Porche 718 Cayman S",
                ManufacturerId = 9,
                EngineTypeId = 1,
                TypeOfCarId = 6,
                Price = 4260000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: 2.5-liter turbocharged flat-four\r\n\r\nPower: 350 horsepower @ 6,500 rpm\r\n\r\nTorque: 309 lb-ft @ 1,900-4,500 rpm\r\n\r\nTransmission: 6-speed manual or 7-speed PDK automatic\r\n\r\n0-60 mph: Approximately 4.6 seconds\r\n\r\nTop Speed: Around 177 mph\r\n\r\nFuel Efficiency:\r\n\r\nCity: 22 mpg\r\n\r\nHighway: 36 mpg\r\n\r\nCombined: 29 mpg\r\n\r\nDimensions:\r\nLength: 172.4 inches\r\n\r\nWidth: 70.9 inches\r\n\r\nHeight: 50.9 inches\r\n\r\nWheelbase: 97.4 inches\r\n\r\nCurb Weight: Approximately 3,153 lbs\r\n\r\nExterior Features:\r\nDesign: Sporty and aerodynamic with a distinctive Porsche look\r\n\r\nLighting: Full LED headlights and taillights\r\n\r\nWheels: 19-inch alloy wheels with performance tires\r\n\r\nSpoiler: Rear spoiler for improved downforce\r\n\r\nInterior Features:\r\nSeating: Comfortable sports seats with adjustable settings\r\n\r\nDashboard: Digital and analog instrument cluster\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 7-inch touchscreen with Porsche Communication Management (PCM)\r\n\r\nConnectivity: Apple CarPlay and Android Auto compatibility\r\n\r\nAudio: High-quality sound system\r\n\r\nComfort: Dual-zone automatic climate control, heated and ventilated seats, leather-wrapped steering wheel\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Helps maintain stability and control\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead\r\n\r\nLane Keeping Assist: Helps keep the vehicle centered in its lane\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nDrive Modes: Includes Normal, Sport, and Sport Plus settings\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Enhances stability and reduces body roll during dynamic cornering",
                Images = "Porche 718 Cayman S",
                DefautlImageLocation = "../Assets/Cars/Porche 718 Cayman S/Blue/1.jpg",
                PriceOfCarId = 5,
                OwnerId = 2,
            },
            new()
            {
                CarId = 6,
                Name = "Porche 992 Carrera GTS",
                ManufacturerId = 9,
                EngineTypeId = 1,
                TypeOfCarId = 6,
                Price = 9630000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: 3.0-liter twin-turbocharged flat-six engine\r\n\r\nPower Output: 473 horsepower (480 PS) @ 6,500 rpm\r\n\r\nTorque: 420 lb-ft (570 Nm) @ 2,300-5,000 rpm\r\n\r\nTransmission:\r\n\r\nStandard: 8-speed Porsche Doppelkupplung (PDK) dual-clutch automatic\r\n\r\nOptional: 7-speed manual transmission\r\n\r\nAcceleration:\r\n\r\n0-60 mph: Approximately 3.3 seconds with PDK\r\n\r\n0-60 mph: Approximately 3.4 seconds with manual transmission\r\n\r\nTop Speed: 193 mph (311 km/h)\r\n\r\nFuel Efficiency:\r\n\r\nCity: 18 mpg\r\n\r\nHighway: 24 mpg\r\n\r\nCombined: 20 mpg\r\n\r\nDimensions and Design:\r\nLength: 178.4 inches\r\n\r\nWidth: 72.9 inches\r\n\r\nHeight: 50.8 inches\r\n\r\nWheelbase: 96.5 inches\r\n\r\nCurb Weight: Approximately 3,453 lbs (1,566 kg)\r\n\r\nExterior:\r\n\r\nGTS-specific front fascia and rear diffuser\r\n\r\nSport Design side skirts\r\n\r\nDarkened LED headlights with Porsche Dynamic Light System (PDLS)\r\n\r\nBlack trim elements and badging\r\n\r\nOptional lightweight glass and carbon fiber roof\r\n\r\nInterior Features:\r\nSeating: Sports seats Plus with GTS logo, 4-way electric adjustment\r\n\r\nDashboard: Combination of digital and analog instrument cluster\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 10.9-inch Porsche Communication Management (PCM)\r\n\r\nConnectivity: Apple CarPlay, Android Auto, Porsche Connect\r\n\r\nAudio: BOSE Surround Sound System or optional Burmester High-End Surround Sound System\r\n\r\nComfort: Dual-zone automatic climate control, Alcantara and leather upholstery, optional carbon fiber trim\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Enhances stability by controlling braking and engine torque\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead\r\n\r\nLane Keeping Assist: Helps keep the vehicle centered in its lane\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle\r\n\r\nPorsche InnoDrive: Predicts driving conditions and adjusts speed accordingly\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nDrive Modes: Includes Normal, Sport, Sport Plus, and Individual settings\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Reduces body roll during dynamic cornering\r\n\r\nPorsche Torque Vectoring Plus (PTV Plus): Enhances traction and handling\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including GT Silver Metallic, Carrara White, Guards Red, and more\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber\r\n\r\nWheels: Multiple designs and sizes to choose from, including 20/21-inch staggered wheels",
                Images = "Porche 992 Carrera GTS",
                DefautlImageLocation = "../Assets/Cars/Porche 992 Carrera GTS/Red/1.jpg",
                PriceOfCarId = 5,
                OwnerId = 2,
            },
            new()
            {
                CarId = 7,
                Name = "Porche 992 Carrera T",
                ManufacturerId = 9,
                EngineTypeId = 1,
                TypeOfCarId = 6,
                Price = 8310000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: 3.0-liter twin-turbocharged flat-six engine.\r\n\r\nPower Output: 379 horsepower @ 6,500 rpm.\r\n\r\nTorque: 331 lb-ft @ 1,950-5,000 rpm.\r\n\r\nTransmission: 7-speed manual gearbox or optional 8-speed PDK dual-clutch automatic.\r\n\r\nAcceleration:\r\n\r\n0-60 mph: Approximately 4.3 seconds with manual transmission.\r\n\r\n0-60 mph: Approximately 4.0 seconds with PDK.\r\n\r\nTop Speed: 182 mph (293 km/h).\r\n\r\nFuel Efficiency: Approximately 20 mpg city / 26 mpg highway / 22 mpg combined.\r\n\r\nDimensions and Design:\r\nLength: 177.9 inches.\r\n\r\nWidth: 72.9 inches.\r\n\r\nHeight: 50.8 inches.\r\n\r\nWheelbase: 96.5 inches.\r\n\r\nCurb Weight: Approximately 3,197 lbs (1,450 kg).\r\n\r\nExterior:\r\n\r\nCarrera T-specific front fascia and rear diffuser.\r\n\r\nSport Design side skirts.\r\n\r\nBlack trim elements and badging.\r\n\r\nOptional lightweight glass and carbon fiber roof.\r\n\r\nStandard 20-inch front and 21-inch rear alloy wheels.\r\n\r\nInterior Features:\r\nSeating: 4-way adjustable Sport Seats Plus with Carrera T logo, available in Race-Tex.\r\n\r\nDashboard: Digital and analog instrument cluster combining traditional elements with modern digital displays.\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 10.9-inch high-resolution touchscreen with Porsche Communication Management (PCM).\r\n\r\nConnectivity: Apple CarPlay, Android Auto, Porsche Connect.\r\n\r\nAudio: High-end BOSE Surround Sound System or optional Burmester High-End Surround Sound System.\r\n\r\nComfort: Dual-zone automatic climate control, Alcantara-wrapped steering wheel and gear selector, optional carbon fiber trim.\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Advanced system to maintain stability and control in various driving conditions.\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead.\r\n\r\nLane Keeping Assist: Helps to keep the vehicle centered in its lane.\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle for easier maneuvering.\r\n\r\nNight Vision Assist: Uses an infrared camera to detect pedestrians and animals in low-light conditions.\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start.\r\n\r\nDrive Modes: Includes Normal, Sport, Sport Plus, and Individual settings.\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel based on current driving conditions and driver preferences.\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Enhances stability and reduces body roll during dynamic cornering.\r\n\r\nPorsche Torque Vectoring Plus (PTV Plus): Enhances traction and handling.\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including GT Silver Metallic, Carrara White, Guards Red, and more.\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber.\r\n\r\nWheels",
                Images = "Porche 992 Carrera T",
                DefautlImageLocation = "../Assets/Cars/Porche 992 Carrera T/Green/1.jpg",
                PriceOfCarId = 5,
                OwnerId = 2,
            },
            new()
            {
                CarId = 8,
                Name = "Porche Taycan J1II",
                ManufacturerId = 9,
                EngineTypeId = 2,
                TypeOfCarId = 6,
                Price = 4620000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: Electric motor\r\n\r\nPower Output: 872 bhp (884 PS / 650 kW)\r\n\r\nTorque: 940 Nm (693 lb-ft / 95.9 kgm)\r\n\r\nTransmission: 2-speed automatic transmission\r\n\r\nAcceleration:\r\n\r\n0-60 mph: 2.5 seconds\r\n\r\n0-100 km/h: 2.7 seconds\r\n\r\nTop Speed: 260 km/h (162 mph)\r\n\r\nFuel Efficiency: Approximately 20 kWh/100 km\r\n\r\nDimensions and Design:\r\nLength: 4962 mm (195.4 inches)\r\n\r\nWidth: 1966 mm (77.4 inches)\r\n\r\nHeight: 1381 mm (54.4 inches)\r\n\r\nWheelbase: 2900 mm (114.2 inches)\r\n\r\nCurb Weight: 2290 kg (5049 lbs)\r\n\r\nExterior: Sleek sedan design with aerodynamic features\r\n\r\nInterior Features:\r\nSeating: 4/5 seats\r\n\r\nInfotainment System: High-resolution touchscreen with Porsche Communication Management (PCM)\r\n\r\nConnectivity: Apple CarPlay, Android Auto, Porsche Connect\r\n\r\nAudio: BOSE Surround Sound System or optional Burmester High-End Surround Sound System\r\n\r\nComfort: Dual-zone automatic climate control, Alcantara and leather upholstery, optional carbon fiber trim\r\n\r\nSafety and Driver-Assistance:\r\nPorsche Stability Management (PSM): Enhances stability by controlling braking and engine torque\r\n\r\nAdaptive Cruise Control (ACC): Maintains a set speed and distance from the vehicle ahead\r\n\r\nLane Keeping Assist: Helps keep the vehicle centered in its lane\r\n\r\nSurround View Camera System: Provides a 360-degree view around the vehicle\r\n\r\nNight Vision Assist: Uses an infrared camera to detect pedestrians and animals in low-light conditions\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Proximity key entry with push-button start\r\n\r\nDrive Modes: Includes Normal, Sport, Sport Plus, and Individual settings\r\n\r\nPorsche Active Suspension Management (PASM): Electronically adjusts the damping force on each wheel\r\n\r\nPorsche Dynamic Chassis Control (PDCC): Reduces body roll during dynamic cornering\r\n\r\nPorsche Torque Vectoring Plus (PTV Plus): Enhances traction and handling\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options\r\n\r\nInterior Options: Various upholstery options and trim materials including leather, Alcantara, and carbon fiber\r\n\r\nWheels: Multiple designs and sizes to choose from",
                Images = "Porche Taycan J1II",
                DefautlImageLocation = "../Assets/Cars/Porche Taycan J1II/Blue/1.jpg",
                PriceOfCarId = 5,
                OwnerId = 2,
            },
            new()
            {
                CarId = 9,
                Name = "Toyota Corolla Altis 1.8G",
                ManufacturerId = 3,
                EngineTypeId = 1,
                TypeOfCarId = 1,
                Price = 725000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine Type: 1.8-liter 4-cylinder DOHC Dual VVT-i\r\n\r\nPower Output: 140 horsepower @ 6,200 rpm\r\n\r\nTorque: 173 Nm @ 4,000 rpm\r\n\r\nTransmission: CVT (Continuously Variable Transmission) with Sequential Shift\r\n\r\nFuel Efficiency:\r\n\r\nCity: Approximately 7-8 km/l\r\n\r\nHighway: Approximately 10-12 km/l\r\n\r\nDrive Type: Front-Wheel Drive\r\n\r\nDimensions and Design:\r\nLength: 4,630 mm\r\n\r\nWidth: 1,780 mm\r\n\r\nHeight: 1,435 mm\r\n\r\nWheelbase: 2,700 mm\r\n\r\nGround Clearance: 130 mm\r\n\r\nCurb Weight: Approximately 1,325 kg\r\n\r\nExterior Features:\r\n\r\nLED Headlights with LED Daytime Running Lights\r\n\r\nFront Fog Lamps\r\n\r\nChrome Accents on Grille and Door Handles\r\n\r\n16-inch Alloy Wheels\r\n\r\nInterior Features:\r\nSeating Capacity: 5 passengers\r\n\r\nUpholstery: High-quality fabric seats\r\n\r\nDashboard: Clean and ergonomic design with a combination of analog and digital displays\r\n\r\nInfotainment System:\r\n\r\nTouchscreen Display: 7-inch touchscreen with user-friendly interface\r\n\r\nConnectivity: Bluetooth, USB, and AUX compatibility\r\n\r\nAudio System: 6-speaker audio system\r\n\r\nComfort and Convenience:\r\n\r\nDual-zone automatic climate control\r\n\r\nPower-adjustable driver's seat\r\n\r\nRear seats with 60:40 split-folding feature\r\n\r\nMultifunction steering wheel with audio and cruise control buttons\r\n\r\nSafety and Driver-Assistance:\r\nSafety Ratings: 5-star ASEAN NCAP rating\r\n\r\nAirbags: Dual front airbags, side airbags, and curtain airbags\r\n\r\nBraking Systems:\r\n\r\nAnti-lock Braking System (ABS)\r\n\r\nElectronic Brake-force Distribution (EBD)\r\n\r\nBrake Assist (BA)\r\n\r\nStability and Traction:\r\n\r\nVehicle Stability Control (VSC)\r\n\r\nTraction Control System (TCS)\r\n\r\nAdditional Safety Features:\r\n\r\nRear Parking Sensors with Reverse Camera\r\n\r\nHill-start Assist Control (HAC)\r\n\r\nTire Pressure Monitoring System (TPMS)\r\n\r\nPre-Collision System (PCS) with pedestrian detection\r\n\r\nLane Departure Alert (LDA) with Steering Assist\r\n\r\nAdditional Features:\r\nKeyless Entry and Start: Smart Entry with push-button start\r\n\r\nLighting: Ambient interior lighting\r\n\r\nStorage: Spacious trunk with a capacity of 470 liters\r\n\r\nTechnology: Optitron meter with 4.2-inch TFT MID (Multi-Information Display)\r\n\r\nCustomization and Personalization:\r\nExterior Colors: Wide range of color options including Super White, Silver Metallic, Attitude Black, Phantom Brown, and Red Mica Metallic\r\n\r\nInterior Options: Various upholstery options and trim materials including fabric and leather\r\n\r\nWheels",
                Images = "Toyota Corolla Altis 1.8G",
                DefautlImageLocation = "../Assets/Cars/Toyota Corolla Altis 1.8G/Black/1.jpg",
                PriceOfCarId = 2,
                OwnerId = 3,
            },
            new()
            {
                CarId = 10,
                Name = "Vinfast VF7",
                ManufacturerId = 8,
                EngineTypeId = 2,
                TypeOfCarId = 2,
                Price = 850000000,
                UsageStatus = "New",
                Description = "Engine and Performance:\r\nEngine: Dual electric motors (VF7 Plus)\r\n\r\nPower Output: 174 horsepower (VF7 S), 348 horsepower (VF7 Plus)\r\n\r\nTorque: 250 Nm (VF7 S), 500 Nm (VF7 Plus)\r\n\r\nTransmission: Single-speed (VF7 S), Dual-speed (VF7 Plus)\r\n\r\nAcceleration: 0-100 km/h in 11 seconds (VF7 S), 5.8 seconds (VF7 Plus)\r\n\r\nTop Speed: 150 km/h (VF7 S), 175 km/h (VF7 Plus)\r\n\r\nBattery Capacity: 59.6 kWh (VF7 S), 75.3 kWh (VF7 Plus)\r\n\r\nRange: 375 km (VF7 S), 431 km (VF7 Plus)\r\n\r\nCharging Time: 10-70% in 24.1 minutes (VF7 S), 24.6 minutes (VF7 Plus)\r\n\r\nDimensions and Design:\r\nLength: 4,545 mm\r\n\r\nWidth: 1,890 mm\r\n\r\nHeight: 1,635 mm\r\n\r\nWheelbase: 2,840 mm\r\n\r\nCurb Weight: 2,085 kg (VF7 S), 2,205 kg (VF7 Plus)\r\n\r\nExterior Features: LED light bars, smooth body panels, flush door handles, bold A-wing front apron, aggressive rear design\r\n\r\nInterior Features:\r\nSeating Capacity: 5 passengers\r\n\r\nUpholstery: Vegan leather seats with ventilation (VF7 Plus)\r\n\r\nInfotainment System: 12.9-inch touchscreen (VF7 S), 15.6-inch touchscreen (VF7 Plus)\r\n\r\nConnectivity: USB Type C charger, wireless charging, WiFi hotspot\r\n\r\nComfort and Convenience: Dual-zone climate control, 8-way powered driver's seat, panoramic sunroof (VF7 Plus)\r\n\r\nSafety and Driver-Assistance:\r\nAirbags: 6 SRS airbags\r\n\r\nBraking Systems: ABS with EBD, stability control\r\n\r\nAdditional Safety Features: Blind spot detection, parking sensors with rearview camera, 360-degree camera (VF7 Plus), Level 2 self-driving tech with lane keeping assist, adaptive cruise control with traffic jam assist, forward collision warning with automatic braking\r\n\r\nAdditional Features:\r\nDriving Modes: Eco, Normal, Sport\r\n\r\nSuspension: Independent MacPherson strut (front), independent control blade (rear)\r\n\r\nWheels: 19-inch wheels (VF7 S), 20-inch wheels (VF7 Plus)",
                Images = "Vinfast VF7",
                DefautlImageLocation = "../Assets/Cars/Vinfast VF7/Blue/1.png",
                PriceOfCarId = 2,
                OwnerId = 2,
            }
        );

        modelBuilder.Entity<VariantOfCar>().HasData(
            new VariantOfCar()
            {
                CarId = 1,
                VariantId = 1,
                Name = "Trắng Ngọc Trai"
            },
            new VariantOfCar()
            {
                CarId = 1,
                VariantId = 2,
                Name = "Xám khói"
            },
            new VariantOfCar()
            {
                CarId = 1,
                VariantId = 3,
                Name = "Đen huyền bí"
            },
            new VariantOfCar()
            {
                CarId = 2,
                VariantId = 3,
                Name = "Đen huyền bí"
            },
            new VariantOfCar()
            {
                CarId = 2,
                VariantId = 6,
                Name = "Đỏ hoàng hôn"
            },
            new VariantOfCar()
            {
                CarId = 2,
                VariantId = 1,
                Name = "Trắng tuyết"
            },
            new VariantOfCar()
            {
                CarId = 3,
                VariantId = 3,
                Name = "Đen huyền bí"
            },
            new VariantOfCar()
            {
                CarId = 3,
                VariantId = 6,
                Name = "Đỏ hoàng hôn"
            },
            new VariantOfCar()
            {
                CarId = 3,
                VariantId = 1,
                Name = "Trắng tuyết"
            },
            new VariantOfCar()
            {
                CarId = 3,
                VariantId = 4,
                Name = "Xanh thẳm"
            },
            new VariantOfCar()
            {
                CarId = 4,
                VariantId = 6,
                Name = "Đỏ hoàng hôn"
            },
            new VariantOfCar()
            {
                CarId = 5,
                VariantId = 4,
                Name = "Xanh đại dương"
            },
            new VariantOfCar()
            {
                CarId = 6,
                VariantId = 6,
                Name = "Đỏ hoàng hôn"
            },
            new VariantOfCar()
            {
                CarId = 7,
                VariantId = 5,
                Name = "Xanh đọt chuối"
            },
            new VariantOfCar()
            {
                CarId = 8,
                VariantId = 4,
                Name = "Xanh hy vọng"
            },
            new VariantOfCar()
            {
                CarId = 9,
                VariantId = 3,
                Name = "Đen khói"
            },
            new VariantOfCar()
            {
                CarId = 10,
                VariantId = 4,
                Name = "Xanh hy vọng"
            }
        );

        modelBuilder.Entity<NumberSeat>().HasData(
            new()
            {
                Id = 1,
                Name = "2 chỗ",
            },
            new()
            {
                Id = 2,
                Name = "4 chỗ",
            },
            new()
            {
                Id = 3,
                Name = "5 chỗ",
            },
            new()
            {
                Id = 4,
                Name = "7 chỗ",
            }
        );

        modelBuilder.Entity<CarDetail>().HasData(
            new CarDetail()
            {
                CarId = 1,
                TimeGet100 = 8.7,
                MaxDistance = 770,
                Year = 2022,
                NumberSeatId = 3
            },
            new CarDetail()
            {
                CarId = 2,
                TimeGet100 = 10.2,
                MaxDistance = 640,
                Year = 2020,
                NumberSeatId = 2
            },
            new CarDetail()
            {
                CarId = 3,
                TimeGet100 = 5.2,
                MaxDistance = 850,
                Year = 2022,
                NumberSeatId = 2
            },
            new CarDetail()
            {
                CarId = 4,
                TimeGet100 = 3.4,
                MaxDistance = 710,
                Year = 2018,
                NumberSeatId = 1
            },
            new CarDetail()
            {
                CarId = 5,
                TimeGet100 = 4.2,
                MaxDistance = 800,
                Year = 2023,
                NumberSeatId = 2
            },
            new CarDetail()
            {
                CarId = 6,
                TimeGet100 = 3.4,
                MaxDistance = 750,
                Year = 2023,
                NumberSeatId = 2
            },
            new CarDetail()
            {
                CarId = 7,
                TimeGet100 = 4.5,
                MaxDistance = 780,
                Year = 2023,
                NumberSeatId = 2
            },
            new CarDetail()
            {
                CarId = 8,
                TimeGet100 = 3.9,
                MaxDistance = 480,
                Year = 2023,
                NumberSeatId = 2
            },
            new CarDetail()
            {
                CarId = 9,
                TimeGet100 = 10.0,
                MaxDistance = 900,
                Year = 2023,
                NumberSeatId = 3
            },
            new CarDetail()
            {
                CarId = 10,
                TimeGet100 = 8.5,
                MaxDistance = 470,
                Year = 2023,
                NumberSeatId = 3
            }
        );

    }
}
