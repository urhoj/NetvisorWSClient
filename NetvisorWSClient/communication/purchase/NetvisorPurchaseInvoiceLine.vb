Imports NetvisorWSClient.communication.common

'
'
'
' Revisio $Revision$
'
' Ilmentää netvisoriin vietävän ostolaskun rivin
'

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPurchaseInvoiceLine

        Public Const MAX_LINEDESCRIPTION_LENGTH As Integer = 200
        Public Const MAX_PRODUCT_CODE_LENGTH As Integer = 50
        Public Const MAX_PRODUCT_NAME_LENGTH As Integer = 50
        Public Const MAX_PRODUCT_UNIT_NAME_LENGTH As Integer = 10

        Private m_productCode As String
        Private m_productName As String
        Private m_orderedAmount As Decimal
        Private m_deliveredAmount As Decimal
        Private m_unitName As String
        Private m_unitPrice As Decimal
        Private m_discountPercentage As Decimal
        Private m_vatPercent As Decimal
        Private m_vatCode As String
        Private m_lineSum As Decimal
        Private m_vatSum As Decimal
        Private m_lineSumWithoutVat As Decimal
        Private m_description As String
        Private m_sort As Integer
        Private m_Dimensions As New ArrayList
        Private m_netvisorKey As Integer
        Private m_accountNumberSuggestion As String

        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

        Public ReadOnly Property Dimensions() As ArrayList
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

        Public Property vatSum() As Decimal
            Get
                Return m_vatSum
            End Get
            Set(ByVal Value As Decimal)
                m_vatSum = Value
            End Set
        End Property

        Public Property lineSumWithoutVat() As Decimal
            Get
                Return m_lineSumWithoutVat
            End Get
            Set(ByVal Value As Decimal)
                m_lineSumWithoutVat = Value
            End Set
        End Property

        Public Property ProductCode() As String
            Get
                Return m_productCode
            End Get
            Set(ByVal Value As String)
                m_productCode = Value
            End Set
        End Property

        Public Property ProductName() As String
            Get
                Return m_productName
            End Get
            Set(ByVal Value As String)
                m_productName = Value
            End Set
        End Property

        Public Property OrderedAmount() As Decimal
            Get
                Return m_orderedAmount
            End Get
            Set(ByVal Value As Decimal)
                m_orderedAmount = Value
            End Set
        End Property

        Public Property DeliveredAmount() As Decimal
            Get
                Return m_deliveredAmount
            End Get
            Set(ByVal Value As Decimal)
                m_deliveredAmount = Value
            End Set
        End Property

        Public Property UnitName() As String
            Get
                Return m_unitName
            End Get
            Set(ByVal Value As String)
                m_unitName = Value
            End Set
        End Property

        Public Property UnitPrice() As Decimal
            Get
                Return m_unitPrice
            End Get
            Set(ByVal Value As Decimal)
                m_unitPrice = Value
            End Set
        End Property

        Public Property DiscountPercentage() As Decimal
            Get
                Return m_discountPercentage
            End Get
            Set(ByVal Value As Decimal)
                m_discountPercentage = Value
            End Set
        End Property

        Public Property VatPercent() As Decimal
            Get
                Return m_vatPercent
            End Get
            Set(ByVal Value As Decimal)
                m_vatPercent = Value
            End Set
        End Property

        Public Property VatCode() As String
            Get
                Return m_vatCode
            End Get
            Set(ByVal Value As String)
                m_vatCode = Value
            End Set
        End Property

        Public Property LineSum() As Decimal
            Get
                Return m_lineSum
            End Get
            Set(ByVal Value As Decimal)
                m_lineSum = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal Value As String)
                m_description = Value
            End Set
        End Property

        Public Property sort() As Integer
            Get
                Return m_sort
            End Get
            Set(ByVal Value As Integer)
                m_sort = Value
            End Set
        End Property

        Public Property accountNumberSuggestion As String
            Get
                Return m_accountNumberSuggestion
            End Get
            Set(ByVal Value As String)
                m_accountNumberSuggestion = Value
            End Set
        End Property
    End Class
End Namespace