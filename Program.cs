using System;
using Weather = CSLab.CoreTypes.Enums.Weather;
using TypeChecker = CSLab.BasicTypes.TypeChecker;
using InterfaceMain = CSLab.CoreTypes.Interfaces.Main;
using DelegateMain = CSLab.CoreTypes.Delegates.Main;
using SerializationMain = CSLab.DataIntegrityAndState.Serialization.Main;
using ListsMain = CSLab.Collections.Lists.Main;

namespace CSLab
{
    class CSLab
    {
        static void Main(string[] args)
        {
            InterfaceMain.Run();
            DelegateMain.Run();
            SerializationMain.Run();            
        }
    }
}