'
'
'
' Revisio $Revision$
'
' Ostolaskulistan lasku. Tässä vain laskun perustiedot -> suppeampi kuin täysi lasku
'

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPurchaseInvoiceListInvoice

        Private m_NetvisorKey As Integer
        Private m_invoiceNumber As String
        Private m_invoiceDate As Date
        Private m_vendor As String
        Private m_sum As Decimal
        Private m_payments As Decimal
        Private m_openSum As Decimal
        Private m_Uri As String


		Public Property Uri() As String
			 Get
				 Return m_Uri
			 End Get			
			 Set(ByVal Value As String)
				 m_Uri = Value
			 End Set
		 End Property


        Public Property NetvisorKey() As Integer
            Get
                Return m_NetvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_NetvisorKey = Value
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

        Public Property vendor() As String
            Get
                Return m_vendor
            End Get
            Set(ByVal Value As String)
                m_vendor = Value
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

        Public Property payments() As Decimal
            Get
                Return m_payments
            End Get
            Set(ByVal Value As Decimal)
                m_payments = Value
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
    End Class
End Namespace