using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "Работа со стенами";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath = @"C:\Program Files\RevitAPITrainig\";

            var panel = application.CreateRibbonPanel(tabName, "Стены");

            var button = new PushButtonData("Стены", "Смена типа стен", Path.Combine(utilsFolderPath, "RevitAPITrainingWallChange.dll"), "RevitAPITrainingWallChange.Main");

            //Uri uriImage = new Uri(@"C:\Program Files\RevitAPITrainig\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            //BitmapImage largeImage = new BitmapImage(uriImage);
            //button.LargeImage = largeImage;

            panel.AddItem(button);

            return Result.Succeeded;
        }
    }
}
