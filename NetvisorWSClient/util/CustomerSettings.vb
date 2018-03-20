'
'
'
' Revisio $Revision$
'
' Integraatioasiakkaan tiedot 
'

Namespace NetvisorWSClient.util
    <ComClass(CustomerSettings.ClassId, CustomerSettings.InterfaceId, CustomerSettings.EventsId)> Public Class CustomerSettings

        Public Const ClassId As String = "98349785-8BE2-4604-848D-F5B103D61715"
        Public Const InterfaceId As String = "36613EE9-125F-493d-9968-771E18C2226A"
        Public Const EventsId As String = "A036F02F-F87E-4548-A536-7DD7EA8E62B5"

        Public Const InterfaceLanguage_Finnish As String = "FI"
        Public Const InterfaceLanguage_English As String = "EN"
        Public Const InterfaceLanguage_Swedish As String = "SE"

        Private m_customerIdentifier As String
        Private m_customerPrivateKey As String
        Private m_customerLanguage As String

        Public Sub New()
        End Sub

        Public Sub New(ByVal customerIdentifier As String, ByVal customerPrivateKey As String, ByVal customerLanguage As String)
            m_customerIdentifier = customerIdentifier
            m_customerPrivateKey = customerPrivateKey
            m_customerLanguage = customerLanguage
        End Sub

        Public Property CustomerIdentifier() As String
            Get
                Return m_customerIdentifier
            End Get
            Set(ByVal value As String)
                m_customerIdentifier = value
            End Set
        End Property

        Public Property CustomerPrivateKey() As String
            Get
                Return m_customerPrivateKey
            End Get
            Set(ByVal value As String)
                m_customerPrivateKey = value
            End Set
        End Property

        Public Property CustomerLanguage() As String
            Get
                Return m_customerLanguage
            End Get
            Set(ByVal value As String)
                m_customerLanguage = value
            End Set
        End Property

    End Class
End Namespace
