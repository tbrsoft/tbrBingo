Imports Excel
Imports System.Data
Public Class ExcelInterface

    Public Shared Sub Exportar(ByVal template As String, ByVal dt As Data.DataTable)
        Dim Obj_Excel As Excel.Application
        Dim Obj_Libro As Object
        Dim Obj_Hoja As Object

        Dim filas As Integer = dt.Rows.Count
        Dim columnas As Integer = dt.Columns.Count

        Dim i As Integer, j As Integer = 0

        Obj_Excel = CreateObject("excel.application")
        If Not Obj_Excel Is Nothing Then

            Obj_Libro = Obj_Excel.Workbooks.Open(template, , True)

            'Ponemos la aplicación excel visible
            Obj_Excel.Visible = True

            'Hoja activa
            Obj_Hoja = Obj_Excel.Sheets.Item("Cartones")

            j = j + 1
            ' poner los caption
            For i = 0 To columnas - 1
                Obj_Hoja.Cells(j, i + 1) = dt.Columns(i).ColumnName
            Next
            'Obj_Hoja.Cells(1, iCol) = enc.nombre


            Dim obj As DataRow
            For Each obj In dt.Rows
                j = j + 1
                Obj_Hoja.Cells(j, 1) = obj(0).ToString
                For i = 0 To columnas - 1
                    Obj_Hoja.Cells(j, i + 1) = IIf(IsNumeric(obj(i)), Replace(obj(i).ToString, ",", "."), obj(i).ToString)
                Next
            Next
            'Opcional : colocamos en negrita y de color rojo los enbezados en la hoja
            Obj_Hoja.Rows(1).Font.Bold = True
            'Obj_Hoja.Rows(1).Font.Color = vbRed

            'Autoajustamos
            Obj_Hoja.Columns("A:Z").AutoFit()

            'Eliminamos las variables de objeto excel

            Obj_Hoja = Nothing
            Obj_Libro = Nothing
            Obj_Excel = Nothing
        End If
    End Sub

End Class
