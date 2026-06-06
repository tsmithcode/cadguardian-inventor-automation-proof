// Optional native example. Requires Autodesk Inventor interop references and a licensed Inventor runtime.
using Inventor;

public sealed class CadGuardianInventorPackageAudit
{
    public void Audit(Inventor.Application app)
    {
        Document document = app.ActiveDocument;
        PropertySets propertySets = document.PropertySets;
        string displayName = document.DisplayName;

        if (document is PartDocument part)
        {
            PartComponentDefinition definition = part.ComponentDefinition;
            _ = definition.Parameters;
        }

        if (document is AssemblyDocument assembly)
        {
            BOM bom = assembly.ComponentDefinition.BOM;
            bom.StructuredViewEnabled = true;
            BOMView structured = bom.BOMViews["Structured"];
            _ = structured.BOMRows.Count;
        }

        if (document is DrawingDocument drawing)
        {
            foreach (Sheet sheet in drawing.Sheets)
            {
                _ = sheet.Name;
            }
        }
    }
}
