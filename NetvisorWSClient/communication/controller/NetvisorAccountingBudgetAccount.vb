'
' Revisio $Revision$
'
' Ilmentää tilikohtaisen budjetin
'

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetAccount.ClassId, NetvisorAccountingBudgetAccount.InterfaceId, _
            NetvisorAccountingBudgetAccount.EventsId)> _
    Public Class NetvisorAccountingBudgetAccount

        Public Const ClassId As String = "9AD1B312-D5D0-43fc-A35A-6CF265AE7B85"
        Public Const InterfaceId As String = "90772F50-C0D5-48ca-AAE8-041540B87F4F"
        Public Const EventsId As String = "55DD8DD8-B077-4134-9617-81F3CCB2DD18"

        Private ReadOnly m_monthList As List(Of NetvisorAccountingBudgetMonth) = New List(Of NetvisorAccountingBudgetMonth)()

        Private m_AccountNumber As Integer
        Private m_AccountGroup As Integer
        Private m_AccountName As String

        Public Property AccountNumber As Integer
            Get
                Return m_AccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_AccountNumber = Value
            End Set
        End Property

        Public Property AccountGroup As Integer
            Get
                Return m_AccountGroup
            End Get
            Set(ByVal Value As Integer)
                m_AccountGroup = Value
            End Set
        End Property

        Public Property AccountName As String
            Get
                Return m_AccountName
            End Get
            Set(ByVal Value As String)
                m_AccountName = Value
            End Set
        End Property

        Public ReadOnly Property MonthList As ArrayList
            Get
                Return ArrayList.Adapter(m_monthList)
            End Get
        End Property

        Public Sub addMonth(ByVal month As NetvisorAccountingBudgetMonth)
            m_monthList.Add(month)
        End Sub

        Public Sub clearMonthList()
            m_monthList.Clear()
        End Sub

        Public Sub New()

        End Sub

    End Class
End Namespace