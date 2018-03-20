'
'
' Ilmentää netvisor tilin

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorAccountListAccount

        Private m_netvisorKey As Integer
        Private m_name As String
        Private m_number As Integer
        Private m_group As Integer
        Private m_Rank As Integer

        Public Property NetvisorKey As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(value As Integer)
                m_netvisorKey = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return m_name
            End Get
            Set(value As String)
                m_name = value
            End Set
        End Property

        Public Property Number As Integer
            Get
                Return m_number
            End Get
            Set(value As Integer)
                m_number = value
            End Set
        End Property

        Public Property Group As Integer
            Get
                Return m_group
            End Get
            Set(value As Integer)
                m_group = value
            End Set
        End Property

        Public Property Rank As Integer
            Get
                Return m_Rank
            End Get
            Set(value As Integer)
                m_Rank = value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class
End Namespace

