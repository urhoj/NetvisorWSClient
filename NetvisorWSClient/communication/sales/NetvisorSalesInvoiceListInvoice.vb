'
'
'
' Revisio $Revision$
' Myyntilaskulistan lasku. Tässä vain laskun perustiedot -> suppeampi kuin NetvisorInvoice, siksi omansa.
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication
    Public Class NetvisorSalesInvoiceListInvoice

        Private m_netvisorKey As Integer
        Private m_invoiceNumber As String
        Private m_invoiceDate As Date
        Private m_invoiceStatus As String
        Private m_invoiceSubStatus As String
        Private m_CustomerCode As String
        Private m_customerName As String
        Private m_referenceNumber As String
        Private m_invoiceSum As Decimal
        Private m_openSum As Decimal
        Private m_isInCollection As Boolean
        Private m_uri As String

        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

        Public Property invoiceNumber() As String
            Get
                Return m_invoiceNumber
            End Get
            Set(ByVal Value As String)
                m_invoiceNumber = Value
            End Set
        End Property

        Public Property invoiceDate() As Date
            Get
                Return m_invoiceDate
            End Get
            Set(ByVal Value As Date)
                m_invoiceDate = Value
            End Set
        End Property

        Public Property invoiceStatus() As String
            Get
                Return m_invoiceStatus
            End Get
            Set(ByVal Value As String)
                m_invoiceStatus = Value
            End Set
        End Property

        Public Property invoiceSubStatus() As String
            Get
                Return m_invoiceSubStatus
            End Get
            Set(ByVal Value As String)
                m_invoiceSubStatus = Value
            End Set
        End Property

		Public Property CustomerCode() As String
			Get
				Return m_CustomerCode
			End Get
			Set(ByVal value As String)
				m_CustomerCode = value
			End Set
		End Property

        Public Property customerName() As String
            Get
                Return m_customerName
            End Get
            Set(ByVal Value As String)
                m_customerName = Value
            End Set
        End Property

        Public Property referenceNumber() As String
            Get
                Return m_referenceNumber
            End Get
            Set(ByVal Value As String)
                m_referenceNumber = Value
            End Set
        End Property

        Public Property invoiceSum() As Decimal
            Get
                Return m_invoiceSum
            End Get
            Set(ByVal Value As Decimal)
                m_invoiceSum = Value
            End Set
        End Property

        Public Property openSum() As Decimal
            Get
                Return m_openSum
            End Get
            Set(ByVal Value As Decimal)
                m_openSum = Value
            End Set
        End Property

        Public Property isInCollection() As Boolean
            Get
                Return m_isInCollection
            End Get
            Set(ByVal Value As Boolean)
                m_isInCollection = Value
            End Set
        End Property

        Public Property uri() As String
            Get
                Return m_uri
            End Get
            Set(ByVal Value As String)
                m_uri = Value
            End Set
        End Property
    End Class
End Namespace
