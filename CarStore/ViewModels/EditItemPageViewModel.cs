using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Core.Contracts.Services;
using CarStore.Core.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarStore.ViewModels
{
    public class EditItemPageViewModel:ObservableObject,INotifyPropertyChanged
    {
        IDao<Manufacturer> _manufacture;
        IDao<EngineType> _engineType;
        IDao<TypeOfCar> _typeOfCar;

        public readonly List<string> colors = new() { "AliceBlue", "AntiqueWhite", "Aqua", "Aquamarine", "Azure", "Beige", "Bisque", "Black", "BlanchedAlmond", "Blue", "BlueViolet", "Brown", "BurlyWood", "CadetBlue", "Chartreuse", "Chocolate", "Coral", "CornflowerBlue", "Cornsilk", "Crimson", "Cyan", "DarkBlue", "DarkCyan", "DarkGoldenrod", "DarkGray", "DarkGreen", "DarkKhaki", "DarkMagenta", "DarkOliveGreen", "DarkOrange", "DarkOrchid", "DarkRed", "DarkSalmon", "DarkSeaGreen", "DarkSlateBlue", "DarkSlateGray", "DarkTurquoise", "DarkViolet", "DeepPink", "DeepSkyBlue", "DimGray", "DodgerBlue", "Firebrick", "FloralWhite", "ForestGreen", "Fuchsia", "Gainsboro", "GhostWhite", "Gold", "Goldenrod", "Gray", "Green", "GreenYellow", "Honeydew", "HotPink", "IndianRed", "Indigo", "Ivory", "Khaki", "Lavender", "LavenderBlush", "LawnGreen", "LemonChiffon", "LightBlue", "LightCoral", "LightCyan", "LightGoldenrodYellow", "LightGray", "LightGreen", "LightPink", "LightSalmon", "LightSeaGreen", "LightSkyBlue", "LightSlateGray", "LightSteelBlue", "LightYellow", "Lime", "LimeGreen", "Linen", "Magenta", "Maroon", "MediumAquamarine", "MediumBlue", "MediumOrchid", "MediumPurple", "MediumSeaGreen", "MediumSlateBlue", "MediumSpringGreen", "MediumTurquoise", "MediumVioletRed", "MidnightBlue", "MintCream", "MistyRose", "Moccasin", "NavajoWhite", "Navy", "OldLace", "Olive", "OliveDrab", "Orange", "OrangeRed", "Orchid", "PaleGoldenrod", "PaleGreen", "PaleTurquoise", "PaleVioletRed", "PapayaWhip", "PeachPuff", "Peru", "Pink", "Plum", "PowderBlue", "Purple", "Red", "RosyBrown", "RoyalBlue", "SaddleBrown", "Salmon", "SandyBrown", "SeaGreen", "Seashell", "Sienna", "Silver", "SkyBlue", "SlateBlue", "SlateGray", "Snow", "SpringGreen", "SteelBlue", "Tan", "Teal", "Thistle", "Tomato", "Turquoise", "Violet", "Wheat", "White", "WhiteSmoke", "Yellow", "YellowGreen" };
        public ObservableCollection<VariantOfCar> Variants { get; set; } = new();
        public ObservableCollection<Manufacturer> Manufacturers
        {
            get; set;
        }
        public ObservableCollection<EngineType> EngineTypes
        {
            get; set;
        }
        public ObservableCollection<TypeOfCar> TypeOfCars
        {
            get; set;
        }
        public EditItemPageViewModel(IDao<Manufacturer> manufacture, IDao<EngineType> engineType, IDao<TypeOfCar> typeOfCar)
        {
            //Manufacturers = new ObservableCollection<Manufacturer>(dao.getAllManufacturers());
            //EngineTypes = new ObservableCollection<EngineType>(dao.GetEngineTypes());
            //TypeOfCars = new ObservableCollection<TypeOfCar>(dao.GetTypeOfCar());
            _manufacture = manufacture;
            _engineType = engineType;
            _typeOfCar = typeOfCar;
            Task.Run(async () =>
            {
                Manufacturers = new ObservableCollection<Manufacturer>(await _manufacture.GetAllAsync());
                EngineTypes = new ObservableCollection<EngineType>(await _engineType.GetAllAsync());
                TypeOfCars = new ObservableCollection<TypeOfCar>(await _typeOfCar.GetAllAsync());
            }).Wait();
        }

    }
}
