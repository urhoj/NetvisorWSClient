Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.purchase

    Public Class NetvisorPurchaseOrder

        Private m_netvisorKey As Integer
        Private m_orderNumber As String
        Private m_orderStatus As String
        Private m_orderDate As Date
        Private m_vendoridentifier As String
        Private m_vendoridentifier_type As String
        Private m_vendorName As String
        Private m_vendorAddress As String
        Private m_vendorPostNumber As String
        Private m_vendorPostOffice As String
        Private m_vendorCountryCode As String
        Private m_orderAmount As Decimal
        Private m_deliveryName As String
        Private m_deliveryAddress As String
        Private m_deliveryPostNumber As String
        Private m_deliveryPostOffice As String
        Private m_deliveryCountryCode As String
        Private m_comment As String
        Private m_deliveryMethod As String
        Private m_deliveryTerm As String
        Private m_paymentTermNetDays As Integer
        Private m_paymentTermDiscountDays As Integer
        Private m_paymentTermDiscountPercent As Double
        Private m_paymentTermDescription As String
        Private m_ourReference As String
        Private m_privateComment As String
        Private m_currencyCode As String
        Private m_currencyExchangeRate As Double

        Private m_purchaseOrderLines As New ArrayList()
        Private m_purchaseOrderCommentLines As New ArrayList()

        Public Property netvisorKey As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal value As Integer)
                m_netvisorKey = value
            End Set
        End Property

        Public Property orderNumber As String
            Get
                Return m_orderNumber
            End Get
            Set(ByVal value As String)
                m_orderNumber = value
            End Set
        End Property

        Public Property orderStatus As String
            Get
                Return m_orderStatus
            End Get
            Set(ByVal value As String)
                m_orderStatus = value
            End Set
        End Property

        Public Property orderDate As Date
            Get
                Return m_orderDate
            End Get
            Set(ByVal value As Date)
                m_orderDate = value
            End Set
        End Property

        Public Property vendorIdentifier As String
            Get
                Return m_vendoridentifier
            End Get
            Set(ByVal value As String)
                m_vendoridentifier = value
            End Set
        End Property

        Public Property vendorIdentifier_type As String
            Get
                Return m_vendoridentifier_type
            End Get
            Set(ByVal value As String)
                m_vendoridentifier_type = value
            End Set
        End Property

        Public Property vendorName As String
            Get
                Return m_vendorName
            End Get
            Set(ByVal value As String)
                m_vendorName = value
            End Set
        End Property

        Public Property vendorAddressline As String
            Get
                Return m_vendorAddress
            End Get
            Set(ByVal value As String)
                m_vendorAddress = value
            End Set
        End Property

        Public Property vendorPostnumber As String
            Get
                Return m_vendorPostNumber
            End Get
            Set(ByVal value As String)
                m_vendorPostNumber = value
            End Set
        End Property

        Public Property vendorCity As String
            Get
                Return m_vendorPostOffice
            End Get
            Set(ByVal value As String)
                m_vendorPostOffice = value
            End Set
        End Property

        Public Property vendorCountry As String
            Get
                Return m_vendorCountryCode
            End Get
            Set(ByVal value As String)
                m_vendorCountryCode = value
            End Set
        End Property

        Public Property deliveryName As String
            Get
                Return m_deliveryName
            End Get
            Set(ByVal value As String)
                m_deliveryName = value
            End Set
        End Property

        Public Property deliveryAddressLine As String
            Get
                Return m_deliveryAddress
            End Get
            Set(ByVal value As String)
                m_deliveryAddress = value
            End Set
        End Property

        Public Property deliveryPostNumber As String
            Get
                Return m_deliveryPostNumber
            End Get
            Set(ByVal value As String)
                m_deliveryPostNumber = value
            End Set
        End Property

        Public Property deliveryCity As String
            Get
                Return m_deliveryPostOffice
            End Get
            Set(ByVal value As String)
                m_deliveryPostOffice = value
            End Set
        End Property

        Public Property deliveryCountry As String
            Get
                Return m_deliveryCountryCode
            End Get
            Set(ByVal value As String)
                m_deliveryCountryCode = value
            End Set
        End Property

        Public Property comment As String
            Get
                Return m_comment
            End Get
            Set(ByVal value As String)
                m_comment = value
            End Set
        End Property

        Public Property deliveryMethod As String
            Get
                Return m_deliveryMethod
            End Get
            Set(ByVal value As String)
                m_deliveryMethod = value
            End Set
        End Property

        Public Property deliveryTerm As String
            Get
                Return m_deliveryTerm
            End Get
            Set(ByVal value As String)
                m_deliveryTerm = value
            End Set
        End Property

        Public Property paymentTermNetDays As Integer
            Get
                Return m_paymentTermNetDays
            End Get
            Set(ByVal value As Integer)
                m_paymentTermNetDays = value
            End Set
        End Property

        Public Property paymentTermCashDiscountDays As Integer
            Get
                Return m_paymentTermDiscountDays
            End Get
            Set(ByVal value As Integer)
                m_paymentTermDiscountDays = value
            End Set
        End Property

        Public Property paymentTermDiscountPercent As Double
            Get
                Return m_paymentTermDiscountPercent
            End Get
            Set(ByVal value As Double)
                m_paymentTermDiscountPercent = value
            End Set
        End Property

        Public Property paymentTermDescription As String
            Get
                Return m_paymentTermDescription
            End Get
            Set(ByVal value As String)
                m_paymentTermDescription = value
            End Set
        End Property

        Public Property ourReference As String
            Get
                Return m_ourReference
            End Get
            Set(ByVal value As String)
                m_ourReference = value
            End Set
        End Property

        Public Property privateComment As String
            Get
                Return m_privateComment
            End Get
            Set(ByVal value As String)
                m_privateComment = value
            End Set
        End Property

        Public Property amount As Decimal
            Get
                Return m_orderAmount
            End Get
            Set(ByVal value As Decimal)
                m_orderAmount = value
            End Set
        End Property

        Public Property currency As String
            Get
                Return m_currencyCode
            End Get
            Set(ByVal value As String)
                m_currencyCode = value
            End Set
        End Property

        Public Property currency_ExchangeRate As Double
            Get
                Return m_currencyExchangeRate
            End Get
            Set(ByVal value As Double)
                m_currencyExchangeRate = value
            End Set
        End Property

        Public ReadOnly Property ProductLines() As ArrayList
            Get
                Return m_purchaseOrderLines
            End Get
        End Property

        Public Sub addProductline(ByVal line As NetvisorPurchaseOrderLine)
            m_purchaseOrderLines.Add(line)
        End Sub

        Public Sub clearProductLines()
            m_purchaseOrderLines.Clear()
        End Sub

        Public ReadOnly Property CommentLines() As ArrayList
            Get
                Return m_purchaseOrderCommentLines
            End Get
        End Property

        Public Sub addCommentLine(ByVal line As NetvisorPurchaseOrderCommentLine)
            m_purchaseOrderCommentLines.Add(line)
        End Sub

        Public Sub clearCommentLines()
            m_purchaseOrderCommentLines.Clear()
        End Sub
    End Class
End Namespace
