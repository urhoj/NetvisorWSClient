'
'
'
' Revisio $Revision$
'
' Maksulistan maksu
'

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPaymentListPayment

        Private m_NetvisorKey As Integer
        Private m_PayerName As String
        Private m_Date As Date
        Private m_HomeCurrencySum As Decimal
        Private m_ForeignCurrencySum As Decimal
        Private m_Reference As String
        Private m_InvoiceKey As Integer
        Private m_InvoiceNumber As String
        Private m_invoiceURI As String
        Private m_VoucherKey As Integer
        Private m_VoucherNumber As Integer
        Private m_voucherURI As String

        Public Property NetvisorKey() As Integer
            Get
                Return m_NetvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_NetvisorKey = Value
            End Set
        End Property

        Public Property PayerName() As String
            Get
                Return m_PayerName
            End Get
            Set(ByVal Value As String)
                m_PayerName = Value
            End Set
        End Property

        Public Property [Date]() As Date
            Get
                Return m_Date
            End Get
            Set(ByVal Value As Date)
                m_Date = Value
            End Set
        End Property

        Public Property HomeCurrencySum() As Decimal
            Get
                Return m_HomeCurrencySum
            End Get
            Set(ByVal Value As Decimal)
                m_HomeCurrencySum = Value
            End Set
        End Property

        Public Property ForeignCurrencySum() As Decimal
            Get
                Return m_ForeignCurrencySum
            End Get
            Set(ByVal Value As Decimal)
                m_ForeignCurrencySum = Value
            End Set
        End Property

        Public Property Reference() As String
            Get
                Return m_Reference
            End Get
            Set(ByVal Value As String)
                m_Reference = Value
            End Set
        End Property

        Public Property InvoiceKey() As Integer
            Get
                Return m_InvoiceKey
            End Get
            Set(ByVal Value As Integer)
                m_InvoiceKey = Value
            End Set
        End Property

        Public Property InvoiceNumber() As String
            Get
                Return m_InvoiceNumber
            End Get
            Set(ByVal Value As String)
                m_InvoiceNumber = Value
            End Set
        End Property

        Public Property invoiceURI() As String
            Get
                Return m_invoiceURI
            End Get
            Set(ByVal Value As String)
                m_invoiceURI = Value
            End Set
        End Property

        Public Property VoucherKey() As Integer
            Get
                Return m_VoucherKey
            End Get
            Set(ByVal Value As Integer)
                m_VoucherKey = Value
            End Set
        End Property

        Public Property VoucherNumber() As Integer
            Get
                Return m_VoucherNumber
            End Get
            Set(ByVal Value As Integer)
                m_VoucherNumber = Value
            End Set
        End Property

        Public Property voucherURI() As String
            Get
                Return m_voucherURI
            End Get
            Set(ByVal Value As String)
                m_voucherURI = Value
            End Set
        End Property

    End Class
End Namespace