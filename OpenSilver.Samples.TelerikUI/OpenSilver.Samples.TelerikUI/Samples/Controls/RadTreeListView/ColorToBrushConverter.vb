Imports System
Imports System.Globalization
Imports System.Windows.Data
Imports System.Windows.Media

Namespace OpenSilver.Samples.TelerikUI.TreeListView
    Public NotInheritable Class ColorToBrushConverter
        Implements IValueConverter
        Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            If TypeOf value Is Color Then
                Dim color As Color = CType(value, Color)
                Return New SolidColorBrush(color)
            End If
            Return Nothing
        End Function

        Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
