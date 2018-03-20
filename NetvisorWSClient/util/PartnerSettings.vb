'
'
'
' Revisio $Revision$
'
' Integraatiokumppanin tunnukset. 
'

Namespace NetvisorWSClient.util
    <ComClass(PartnerSettings.ClassId, PartnerSettings.InterfaceId, PartnerSettings.EventsId)> Public Class PartnerSettings

        Public Const ClassId As String = "98349785-8BE2-4604-848D-F5B103D61712"
        Public Const InterfaceId As String = "36613EE9-125F-493d-9968-771E18C2226B"
        Public Const EventsId As String = "A036F02F-F87E-4548-A536-7DD7EA8E62BC"

        Private m_clientName As String
        Private m_partnerIdentifier As String
        Private m_partnerPrivateKey As String

        Public Sub New()
        End Sub

        Public Sub New(ByVal clientName As String, ByVal partnerIdentifier As String, ByVal partnerPrivateKey As String)
            m_clientName = clientName
            m_partnerIdentifier = partnerIdentifier
            m_partnerPrivateKey = partnerPrivateKey
        End Sub

        Public Property ClientName() As String
            Get
                Return m_clientName
            End Get
            Set(ByVal value As String)
                m_clientName = value
            End Set
        End Property

        Public Property PartnerIdentifier() As String
            Get
                Return m_partnerIdentifier
            End Get
            Set(ByVal value As String)
                m_partnerIdentifier = value
            End Set
        End Property

        Public Property PartnerPrivateKey() As String
            Get
                Return m_partnerPrivateKey
            End Get
            Set(ByVal value As String)
                m_partnerPrivateKey = value
            End Set
        End Property

    End Class
End Namespace