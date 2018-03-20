'
' Revisio $Revision$
' 
' Ilmentää projektin Netvisorin asiakkuuden hallinnassa
'

Namespace NetvisorWSClient.communication.crm

    Public Class NetvisorProcessProject

        Private m_NetvisorKey As Integer = Nothing
        Private m_Name As String

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Public Property netvisorKey() As String
            Get
                Return m_NetvisorKey
            End Get
            Set(ByVal value As String)
                m_NetvisorKey = value
            End Set
        End Property

    End Class
End Namespace
