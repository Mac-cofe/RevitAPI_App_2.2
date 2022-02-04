using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI_App_2
{
    [Transaction(TransactionMode.Manual)]

public class Main : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIApplication uiapp = commandData.Application;
        UIDocument uidoc = uiapp.ActiveUIDocument;
        Document doc = uidoc.Document;

        List<Pipe> pipes = new FilteredElementCollector(doc, doc.ActiveView.Id)
        .WhereElementIsNotElementType()
            .OfClass(typeof(Pipe))
            .Cast<Pipe>()
            .ToList();

        TaskDialog.Show("Количество труб на активном виде", pipes.Count.ToString());
        return Result.Succeeded;
    }
}
}
