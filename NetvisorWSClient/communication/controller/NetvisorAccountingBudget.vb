'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin vietävän budjetin.
'

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudget.ClassId, NetvisorAccountingBudget.InterfaceId, _
            NetvisorAccountingBudget.EventsId)> _
    Public Class NetvisorAccountingBudget

        Public Const ClassId As String = "78E08F85-75B3-47ad-A7B3-5A9DB2ABAA30"
        Public Const InterfaceId As String = "B8996049-9B78-4f4d-AC95-57965D13BD2F"
        Public Const EventsId As String = "6D4218B7-B599-4257-B5DF-FE6FCE450A2F"

        Public Enum ratioTypes As Integer
            accountNumber = 1
        End Enum

        Private m_ratio As Integer
        Private m_ratioType As ratioTypes
        Private m_sum As Decimal
        Private m_year As Integer
        Private m_month As Integer
        Private m_budgetVersion As String
        Private m_vatClass As Decimal
        Private m_combinations As New ArrayList

        Public Property ratio() As Integer
            Get
                Return m_ratio
            End Get
            Set(ByVal Value As Integer)
                m_ratio = Value
            End Set
        End Property

        Public Property ratioType() As ratioTypes
            Get
                Return m_ratioType
            End Get
            Set(ByVal Value As ratioTypes)
                m_ratioType = Value
            End Set
        End Property

        Public Property sum() As Decimal
            Get
                Return m_sum
            End Get
            Set(ByVal Value As Decimal)
                m_sum = Value
            End Set
        End Property

        Public Property year() As Integer
            Get
                Return m_year
            End Get
            Set(ByVal Value As Integer)
                m_year = Value
            End Set
        End Property

        Public Property month() As Integer
            Get
                Return m_month
            End Get
            Set(ByVal Value As Integer)
                m_month = Value
            End Set
        End Property

        Public Property budgetVersion() As String
            Get
                Return m_budgetVersion
            End Get
            Set(ByVal Value As String)
                m_budgetVersion = Value
            End Set
        End Property

        Public Property vatClass() As Decimal
            Get
                Return m_vatClass
            End Get
            Set(ByVal Value As Decimal)
                m_vatClass = Value
            End Set
        End Property

        Public ReadOnly Property combinations() As ArrayList
            Get
                Return m_combinations
            End Get
        End Property

        Public Sub addCombination(ByVal combination As NetvisorAccountingBudgetCombination)
            m_combinations.Add(combination)
        End Sub

        Public Sub clearCombinations()
            m_combinations.Clear()
        End Sub
    End Class
End Namespace