'
'
' Ilmentää budjettitointikelpoisen netvisor tilin

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetAccountListAccount.ClassId, NetvisorAccountingBudgetAccountListAccount.InterfaceId, _
            NetvisorAccountingBudgetAccountListAccount.EventsId)> _
    Public Class NetvisorAccountingBudgetAccountListAccount

        Public Const ClassId As String = "01BE73C4-8D57-4454-9F50-5B1F793DD962"
        Public Const InterfaceId As String = "683AAC61-9052-44ce-8B5C-9771F262CDFB"
        Public Const EventsId As String = "1FE9253D-E461-4d95-B10F-984DE106D846"

        Private m_netvisorKey As Integer
        Private m_name As String
        Private m_number As Integer
        Private m_group As Integer
        Private m_type As Integer


        Public Property NetvisorKey As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal value As Integer)
                m_netvisorKey = value
            End Set
        End Property

        Public Property Name As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

        Public Property Number As Integer
            Get
                Return m_number
            End Get
            Set(ByVal value As Integer)
                m_number = value
            End Set
        End Property

        Public Property Group As Integer
            Get
                Return m_group
            End Get
            Set(ByVal value As Integer)
                m_group = value
            End Set
        End Property

        Public Property Type As Integer
            Get
                Return m_type
            End Get
            Set(ByVal value As Integer)
                m_type = value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class
End Namespace

