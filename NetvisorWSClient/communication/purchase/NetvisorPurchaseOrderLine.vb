Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPurchaseOrderLine

        Private m_productCode As String
        Private m_productCode_type As String
        Private m_productName As String
        Private m_vendorCode As String
        Private m_orderedAmount As Decimal
        Private m_deliveredAmount As Decimal
        Private m_unitPrice As Decimal
        Private m_rowSum As Decimal
        Private m_freightRate As Decimal
        Private m_accountingAccountSuggestion As Integer
        Private m_vatPercent As Decimal
        Private m_vatCode As String
        Private m_deliveryDate As Date
        Private m_inventoryPlace As String
        Private m_inventoryPlace_type As String

        Private m_Dimensions As New ArrayList()

        Public Property productCode As String
            Get
                Return m_productCode
            End Get
            Set(ByVal value As String)
                m_productCode = value
            End Set
        End Property

        Public Property productCode_type As String
            Get
                Return m_productCode_type
            End Get
            Set(ByVal value As String)
                m_productCode_type = value
            End Set
        End Property

        Public Property productName As String
            Get
                Return m_productName
            End Get
            Set(ByVal value As String)
                m_productName = value
            End Set
        End Property

        Public Property vendorProductCode As String
            Get
                Return m_vendorCode
            End Get
            Set(ByVal value As String)
                    m_vendorCode = value
            End Set
        End Property

        Public Property orderedAmount As Decimal
            Get
                Return m_orderedAmount
            End Get
            Set(ByVal value As Decimal)
                m_orderedAmount = value
            End Set
        End Property

        Public Property deliveredAmount As Decimal
            Get
                Return m_deliveredAmount
            End Get
            Set(ByVal value As Decimal)
                m_deliveredAmount = value
            End Set
        End Property

        Public Property unitPrice As Decimal
            Get
                Return m_unitPrice
            End Get
            Set(ByVal value As Decimal)
                m_unitPrice = value
            End Set
        End Property

        Public Property lineSum As Decimal
            Get
                Return m_rowSum
            End Get
            Set(ByVal value As Decimal)
                m_rowSum = value
            End Set
        End Property

        Public Property freightRate As Decimal
            Get
                Return m_freightRate
            End Get
            Set(ByVal value As Decimal)
                m_freightRate = value
            End Set
        End Property

        Public Property accountingSuggestion As Integer
            Get
                Return m_accountingAccountSuggestion
            End Get
            Set(ByVal value As Integer)
                m_accountingAccountSuggestion = value
            End Set
        End Property

        Public Property vatPercent As Decimal
            Get
                Return m_vatPercent
            End Get
            Set(ByVal value As Decimal)
                m_vatPercent = value
            End Set
        End Property

        Public Property vatCode As String
            Get
                Return m_vatCode
            End Get
            Set(ByVal value As String)
                m_vatCode = value
            End Set
        End Property

        Public Property DeliveryDate() As Date
            Get
                Return m_deliveryDate
            End Get
            Set(ByVal Value As Date)
                m_deliveryDate = Value
            End Set
        End Property

        Public Property inventoryPlace As String
            Get
                Return m_inventoryPlace
            End Get
            Set(ByVal Value As String)
                m_inventoryPlace = Value
            End Set
        End Property

        Public Property inventoryPlace_type As String
            Get
                Return m_inventoryPlace_type
            End Get
            Set(ByVal value As String)
                m_inventoryPlace_type = value
            End Set
        End Property

        Public ReadOnly Property dimensions() As ArrayList
            Get
                Return m_Dimensions
            End Get
        End Property

        Public Sub addDimension(ByVal dimension As NetvisorDimension)
            m_Dimensions.Add(dimension)
        End Sub

        Public Sub clearDimensions()
            m_Dimensions.Clear()
        End Sub

    End Class
End Namespace
