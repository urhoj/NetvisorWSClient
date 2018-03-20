'
' Revisio $Revision$
'
' Ilmentää tilibudjetin
'

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetAccountBudget.ClassId, NetvisorAccountingBudgetAccountBudget.InterfaceId, _
            NetvisorAccountingBudgetAccountBudget.EventsId)> _
    Public Class NetvisorAccountingBudgetAccountBudget

        Public Const ClassId As String = "30993890-C3A7-4fbb-A33C-A0B8D0FCA95D"
        Public Const InterfaceId As String = "38A7EB5A-DBB7-4b66-B63D-685BD0930C3C"
        Public Const EventsId As String = "196E64AC-1BD8-4398-B90C-D31A659D3505"

        Private ReadOnly m_budgetAccountList As List(Of NetvisorAccountingBudgetAccount) = New List(Of NetvisorAccountingBudgetAccount)()
        Private ReadOnly m_lockedDimensionList As List(Of NetvisorAccountingBudgetLockedDimension) = New List(Of NetvisorAccountingBudgetLockedDimension)()
        Private m_Method As String

        Public Property Method As String
            Get
                Return m_Method
            End Get
            Set(ByVal Value As String)
                m_Method = Value
            End Set
        End Property

        Public ReadOnly Property BudgetAccountList As ArrayList
            Get
                Return ArrayList.Adapter(m_budgetAccountList)
            End Get
        End Property

        Public ReadOnly Property LockedDimensionList As ArrayList
            Get
                Return ArrayList.Adapter(m_lockedDimensionList)
            End Get
        End Property

        Public Sub addBudgetAccount(ByVal budgetAccount As NetvisorAccountingBudgetAccount)
            m_budgetAccountList.Add(budgetAccount)
        End Sub

        Public Sub clearBudgetAccountList()
            m_budgetAccountList.Clear()
        End Sub

        Public Sub addLockedDimension(ByVal lockedDimension As NetvisorAccountingBudgetLockedDimension)
            m_lockedDimensionList.Add(lockedDimension)
        End Sub

        Public Sub clearLockedDimensionList()
            m_lockedDimensionList.Clear()
        End Sub

        Public Sub New()

        End Sub

    End Class
End Namespace