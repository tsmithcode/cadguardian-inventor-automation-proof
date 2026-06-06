' Optional iLogic / VB.NET rule sketch for Inventor.
' Use only inside an approved Inventor document or private runtime receipt.

Dim requiredProperties As String() = {"Part Number", "Description", "Stock Number"}
For Each propertyName As String In requiredProperties
    Try
        Dim value = iProperties.Value("Project", propertyName)
        If String.IsNullOrWhiteSpace(CStr(value)) Then
            Logger.Info("CADG review required: missing " & propertyName)
        End If
    Catch
        Logger.Info("CADG review required: property not found " & propertyName)
    End Try
Next

ThisDoc.Document.Update()
