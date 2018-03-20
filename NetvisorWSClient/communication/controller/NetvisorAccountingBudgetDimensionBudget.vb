'
' Revisio $Revision$
'
' Ilmentää laskentakohdebudjetin
'

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetDimensionBudget.ClassId, NetvisorAccountingBudgetDimensionBudget.InterfaceId, _
            NetvisorAccountingBudgetDimensionBudget.EventsId)> _
    Public Class NetvisorAccountingBudgetDimensionBudget

        Public Const ClassId As String = "2532DE39-08F1-4399-955D-9745D0E37A60"
        Public Const InterfaceId As String = "09153BE4-4382-44e4-9168-B7A7F5F7799C"
        Public Const EventsId As String = "35748843-E3F8-4d22-A57B-D65379CE77DF"

        Private ReadOnly m_lockedDimensionList As List(Of NetvisorAccountingBudgetLockedDimension) = New List(Of NetvisorAccountingBudgetLockedDimension)()
        Private ReadOnly m_budgetDimensionList As List(Of NetvisorAccountingBudgetDimension) = New List(Of NetvisorAccountingBudgetDimension)()

        Private m_AccountNumber As Integer
        Private m_AccountGroup As Integer
        Private m_AccountName As String

        Private m_Method As String

        Public Property Method As String
            Get
                Return m_Method
            End Get
            Set(ByVal Value As String)
                m_Method = Value
            End Set
        End Property

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

        Public ReadOnly Property BudgetDimensionList As ArrayList
            Get
                Return ArrayList.Adapter(m_budgetDimensionList)
            End Get
        End Property

        Public ReadOnly Property LockedDimensionList As ArrayList
            Get
                Return ArrayList.Adapter(m_lockedDimensionList)
            End Get
        End Property

        Public Sub addBudgetDimension(ByVal budgetDimension As NetvisorAccountingBudgetDimension)
            m_budgetDimensionList.Add(budgetDimension)
        End Sub

        Public Sub clearBudgetDimensionList()
            m_budgetDimensionList.Clear()
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