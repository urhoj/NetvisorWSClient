'
' Revisio $Revision$
'
' Ilmentää Budjetin kuukausijakson
'

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetMonth.ClassId, NetvisorAccountingBudgetMonth.InterfaceId, _
    NetvisorAccountingBudgetMonth.EventsId)> _
    Public Class NetvisorAccountingBudgetMonth

        Public Const ClassId As String = "077027E6-CAC3-41d2-811C-870D826CBA99"
        Public Const InterfaceId As String = "159DF0E5-4AFB-400e-A571-5DA343F50801"
        Public Const EventsId As String = "A42EA02E-8864-472b-A010-79BFB79064F3"

        Private m_sum As Double
        Private m_vat As Double
        Private m_year As Integer
        Private m_month As Integer

        Public Property Sum As Double
            Get
                Return m_sum
            End Get
            Set(ByVal Value As Double)
                m_sum = Value
            End Set
        End Property

        Public Property Year As Integer
            Get
                Return m_year
            End Get
            Set(ByVal Value As Integer)
                m_year = Value
            End Set
        End Property

        Public Property Month As Integer
            Get
                Return m_month
            End Get
            Set(ByVal Value As Integer)
                m_month = Value
            End Set
        End Property

        Public Property VAT As Double
            Get
                Return m_vat
            End Get
            Set(ByVal Value As Double)
                m_vat = Value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class
End Namespace