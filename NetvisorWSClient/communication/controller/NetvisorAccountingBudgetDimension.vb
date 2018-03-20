'
' Revisio $Revision$
'
' Ilmentää budjetin laskentakohteen
'

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetDimension.ClassId, NetvisorAccountingBudgetDimension.InterfaceId, _
            NetvisorAccountingBudgetDimension.EventsId)> _
    Public Class NetvisorAccountingBudgetDimension

        Public Const ClassId As String = "36C0D319-0B7C-4fda-BF59-3B33B63EA2D7"
        Public Const InterfaceId As String = "2726145E-2AEF-4b12-BAE8-3F0E35985529"
        Public Const EventsId As String = "407C8874-ECB5-42ff-88CA-077727463ED0"

        Private ReadOnly m_monthList As List(Of NetvisorAccountingBudgetMonth) = New List(Of NetvisorAccountingBudgetMonth)()

        Private m_DimensionName As String
        Private m_DimensionItemName As String

        Public Property DimensionName As String
            Get
                Return m_DimensionName
            End Get
            Set(ByVal Value As String)
                m_DimensionName = Value
            End Set
        End Property

        Public Property DimensionItemName As String
            Get
                Return m_DimensionItemName
            End Get
            Set(ByVal Value As String)
                m_DimensionItemName = Value
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