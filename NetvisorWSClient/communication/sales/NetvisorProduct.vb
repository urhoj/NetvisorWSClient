'
'
'
' Revisio $Revision$
'
' Ilmentää netvisoriin vietävän tuotteen
'

Namespace NetvisorWSClient.communication.sales
    <ComClass(NetvisorProduct.ClassId, NetvisorProduct.InterfaceId, NetvisorProduct.EventsId)> Public Class NetvisorProduct

        Public Const ClassId As String = "98349785-8BE2-4604-848D-15B103D61715"
        Public Const InterfaceId As String = "36613EE9-125F-493d-9968-171E18C2226A"
        Public Const EventsId As String = "A036F02F-F87E-4548-A536-1DD7EA8E62B5"

        Public Enum unitPriceTypes As Integer
            net = 1
            gross = 2
        End Enum

        Private m_netvisorKey As Integer
        Private m_productCode As String
        Private m_productGroup As String
        Private m_name As String
        Private m_description As String
        Private m_unitPrice As Decimal
        Private m_unitPriceType As unitPriceTypes
        Private m_unit As String
        Private m_unitWeight As Double
        Private m_purchaseprice As Decimal
        Private m_tariffHeading As String
        Private m_comissionPercentage As Double
        Private m_isActive As Boolean
        Private m_isSalesproduct As Boolean
        Private m_defaultVatPercentage As String
        Private m_DefaultDomesticAccountNumber As Integer
        Private m_DefaultEuAccountNumber As Integer
        Private m_DefaultOutsideEUAccountNumber As Integer
        Private m_InventoryAmount As Decimal
        Private m_InventoryMidPrice As Decimal
        Private m_InventoryValue As Decimal
        Private m_InventoryReservedAmount As Decimal
        Private m_InventoryOrderedAmount As Decimal

        Public Sub New()
        End Sub

        Public Sub setUnitPrice(ByVal price As String)
            m_unitPrice = New Decimal(Double.Parse(price))
        End Sub

        Public Sub setPurchasePrice(ByVal price As String)
            m_purchaseprice = New Decimal(Double.Parse(price))
        End Sub

        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

        Public Property productCode() As String
            Get
                Return m_productCode
            End Get
            Set(ByVal Value As String)
                m_productCode = Value
            End Set
        End Property

        Public Property productGroup() As String
            Get
                Return m_productGroup
            End Get
            Set(ByVal Value As String)
                m_productGroup = Value
            End Set
        End Property

        Public Property name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
            End Set
        End Property

        Public Property description() As String
            Get
                Return m_description
            End Get
            Set(ByVal Value As String)
                m_description = Value
            End Set
        End Property

        Public Property unitPrice() As Decimal
            Get
                Return m_unitPrice
            End Get
            Set(ByVal Value As Decimal)
                m_unitPrice = Value
            End Set
        End Property

        Public Property unitPriceType() As unitPriceTypes
            Get
                Return m_unitPriceType
            End Get
            Set(ByVal Value As unitPriceTypes)
                m_unitPriceType = Value
            End Set
        End Property

        Public Property unit() As String
            Get
                Return m_unit
            End Get
            Set(ByVal Value As String)
                m_unit = Value
            End Set
        End Property

        Public Property unitWeight() As Decimal
            Get
                Return m_unitWeight
            End Get
            Set(ByVal Value As Decimal)
                m_unitWeight = Value
            End Set
        End Property

        Public Property purchaseprice() As Decimal
            Get
                Return m_purchaseprice
            End Get
            Set(ByVal Value As Decimal)
                m_purchaseprice = Value
            End Set
        End Property

        Public Property tariffHeading() As String
            Get
                Return m_tariffHeading
            End Get
            Set(ByVal Value As String)
                m_tariffHeading = Value
            End Set
        End Property

        Public Property comissionPercentage() As Decimal
            Get
                Return m_comissionPercentage
            End Get
            Set(ByVal Value As Decimal)
                m_comissionPercentage = Value
            End Set
        End Property

        Public Property isActive() As Boolean
            Get
                Return m_isActive
            End Get
            Set(ByVal Value As Boolean)
                m_isActive = Value
            End Set
        End Property

        Public Property isSalesproduct() As Boolean
            Get
                Return m_isSalesproduct
            End Get
            Set(ByVal Value As Boolean)
                m_isSalesproduct = Value
            End Set
        End Property

        Public Property defaultVatPercentage() As String
            Get
                Return m_defaultVatPercentage
            End Get
            Set(ByVal Value As String)
                m_defaultVatPercentage = Value
            End Set
        End Property

        Public Property InventoryAmount() As Decimal
            Get
                Return m_InventoryAmount
            End Get
            Set(ByVal Value As Decimal)
                m_InventoryAmount = Value
            End Set
        End Property

        Public Property InventoryMidPrice() As Decimal
            Get
                Return m_InventoryMidPrice
            End Get
            Set(ByVal Value As Decimal)
                m_InventoryMidPrice = Value
            End Set
        End Property

        Public Property InventoryValue() As Decimal
            Get
                Return m_InventoryValue
            End Get
            Set(ByVal Value As Decimal)
                m_InventoryValue = Value
            End Set
        End Property

        Public Property InventoryReservedAmount() As Decimal
            Get
                Return m_InventoryReservedAmount
            End Get
            Set(ByVal Value As Decimal)
                m_InventoryReservedAmount = Value
            End Set
        End Property

        Public Property InventoryOrderedAmount() As Decimal
            Get
                Return m_InventoryOrderedAmount
            End Get
            Set(ByVal Value As Decimal)
                m_InventoryOrderedAmount = Value
            End Set
        End Property

        Public Property DefaultDomesticAccountNumber() As Integer
            Get
                Return m_DefaultDomesticAccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_DefaultDomesticAccountNumber = Value
            End Set
        End Property

        Public Property DefaultEuAccountNumber() As Integer
            Get
                Return m_DefaultEuAccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_DefaultEuAccountNumber = Value
            End Set
        End Property

        Public Property DefaultOutsideEUAccountNumber() As Integer
            Get
                Return m_DefaultOutsideEUAccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_DefaultOutsideEUAccountNumber = Value
            End Set
        End Property

    End Class
End Namespace