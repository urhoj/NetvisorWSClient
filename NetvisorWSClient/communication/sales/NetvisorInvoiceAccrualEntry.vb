'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin lähetettävän myyntilaskun jaksotuksen
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorInvoiceAccrualEntry

        Private m_month As Integer
        Private m_year As Integer
        Private m_sum As Decimal

        Public Sub New()
        End Sub

        Public Sub New(ByVal month As Integer, ByVal year As Integer, ByVal sum As Decimal)
            m_month = month
            m_year = year
            m_sum = sum
        End Sub

        Public Property month() As Integer
            Get
                Return m_month
            End Get
            Set(ByVal Value As Integer)
                m_month = Value
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

        Public Property sum() As Decimal
            Get
                Return m_sum
            End Get
            Set(ByVal Value As Decimal)
                m_sum = Value
            End Set
        End Property

    End Class
End Namespace