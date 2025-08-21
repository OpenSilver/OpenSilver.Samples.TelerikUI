Imports System
Imports System.ComponentModel
Imports System.Runtime.Serialization
Imports Telerik.Windows.Controls.Docking

Namespace OpenSilver.Samples.TelerikUI.Docking
    <DataContract>
    Public Class PaneViewModel
        Implements INotifyPropertyChanged

        Private _ContentType As System.Type
        Private headerField As String
        Private initialPositionField As DockState
        Private isActiveField As Boolean
        Private isHiddenField As Boolean
        Private isDocumentField As Boolean

        Public Sub New()
        End Sub

        Public Sub New(contentType As Type)
            Me.ContentType = contentType
        End Sub

        <DataMember>
        Public Property Header As String
            Get
                Return headerField
            End Get
            Set(value As String)
                If Not Equals(headerField, value) Then
                    headerField = value
                    OnPropertyChanged("Header")
                End If
            End Set
        End Property

        <DataMember>
        Public Property InitialPosition As DockState
            Get
                Return initialPositionField
            End Get
            Set(value As DockState)
                If initialPositionField <> value Then
                    initialPositionField = value
                    OnPropertyChanged("InitialPosition")
                End If
            End Set
        End Property

        <DataMember>
        Public Property IsActive As Boolean
            Get
                Return isActiveField
            End Get
            Set(value As Boolean)
                If isActiveField <> value Then
                    isActiveField = value
                    OnPropertyChanged("IsActive")
                End If
            End Set
        End Property

        <DataMember>
        Public Property IsHidden As Boolean
            Get
                Return isHiddenField
            End Get
            Set(value As Boolean)
                If isHiddenField <> value Then
                    isHiddenField = value
                    OnPropertyChanged("IsHidden")
                End If
            End Set
        End Property

        <DataMember>
        Public Property IsDocument As Boolean
            Get
                Return isDocumentField
            End Get
            Set(value As Boolean)
                If isDocumentField <> value Then
                    isDocumentField = value
                    OnPropertyChanged("IsDocument")
                End If
            End Set
        End Property

        Public Property ContentType As Type
            Get
                Return _ContentType
            End Get
            Private Set(value As Type)
                _ContentType = value
            End Set
        End Property

        <DataMember>
        Public Property TypeName As String
            Get
                Return If(ContentType Is Nothing, String.Empty, ContentType.AssemblyQualifiedName)
            End Get
            Set(value As String)
                ContentType = If(Equals(value, Nothing), Nothing, Type.GetType(value))
            End Set
        End Property

        Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

        Private Sub OnPropertyChanged(propertyName As String)
            RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
        End Sub
    End Class
End Namespace
