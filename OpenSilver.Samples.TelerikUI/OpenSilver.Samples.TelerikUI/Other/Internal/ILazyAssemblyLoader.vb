Imports System.Collections.Generic
Imports System.Reflection
Imports System.Threading.Tasks

Namespace OpenSilver.Samples.TelerikUI
    Public Interface ILazyAssemblyLoader
        Function LoadAssembliesAsync(assembliesToLoad As IEnumerable(Of String)) As Task(Of IEnumerable(Of Assembly))
    End Interface
End Namespace
