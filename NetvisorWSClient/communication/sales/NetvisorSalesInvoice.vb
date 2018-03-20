'
' Revisio $Revision$
' 
' Ilmentää myyntilaskun Netvisorin asiakkuuden hallinnan taloustiedoissa
'

Namespace NetvisorWSClient.communication.sales

    Public Class NetvisorSalesInvoice

        Private m_InvoiceNumber As String
        Private m_InvoiceDate As Date
        Private m_TotalSumWithTax As Double
        Private m_PaymentSum As Double

        Public Property InvoiceNumber() As String
            Get
                Return m_InvoiceNumber
            End Get
            Set(ByVal value As String)
                m_InvoiceNumber = value
            End Set
        End Property

        Public Property InvoiceDate() As Date
            Get
                Return m_InvoiceDate
            End Get
            Set(ByVal value As Date)
                m_InvoiceDate = value
            End Set
        End Property

        Public Property TotalSumWithTax() As Double
            Get
                Return m_TotalSumWithTax
            End Get
            Set(ByVal value As Double)
                m_TotalSumWithTax = value
            End Set
        End Property

        Public Property PaymentSum() As Double
            Get
                Return m_PaymentSum
            End Get
            Set(ByVal value As Double)
                m_PaymentSum = value
            End Set
        End Property

    End Class
End Namespace
