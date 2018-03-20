'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin lähetettävän myyntilaskun tuoterivin
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorInvoiceProductLine
        Implements INetvisorInvoiceLine

        Public Enum productIdentifierTypes As Integer
            EXTERNAL_IDENTIFIER = 1
            NETVISOR_IDENTIFIER = 2
        End Enum

        Private m_ProductIdentifier As String
        Private m_ProductIdentifierType As productIdentifierTypes
        Private m_ProductName As String
        Private m_ProductUnitPrice As Decimal
        Private m_ProductVatPercentage As Decimal
        Private m_productVatCode As VatCode.vatCodes
        Private m_DeliveredQuantity As Decimal
        Private m_productUnitPriceIsGross As Boolean
        Private m_AccountingSuggestionAccountNumber As Integer
        Private m_LineDiscountPercentage As Decimal
        Private m_LineSum As Decimal?
        Private m_LineVatSum As Decimal?
        Private m_lineText As String
        Private m_skipAccrual As Boolean

        Private m_dimensions As New ArrayList

        Public Property ProductIdentifier() As String
            Get
                Return m_ProductIdentifier
            End Get
            Set(ByVal value As String)
                m_ProductIdentifier = value
            End Set
        End Property

        Public Property ProductIdentifierType() As productIdentifierTypes
            Get
                Return m_ProductIdentifierType
            End Get
            Set(ByVal Value As productIdentifierTypes)
                m_ProductIdentifierType = Value
            End Set
        End Property

        Public Property ProductName() As String
            Get
                Return m_ProductName
            End Get
            Set(ByVal value As String)
                If Len(value) > 200 Then
                    Throw New ApplicationException("Invoiceline productname too long")
                Else
                    m_ProductName = value
                End If
            End Set
        End Property

        Public Property ProductUnitPrice() As Decimal
            Get
                Return m_ProductUnitPrice
            End Get
            Set(ByVal value As Decimal)
                m_ProductUnitPrice = value
            End Set
        End Property

        Public Property ProductVatPercentage() As Decimal
            Get
                Return m_ProductVatPercentage
            End Get
            Set(ByVal value As Decimal)
                m_ProductVatPercentage = value
            End Set
        End Property

        Public Property productVatCode() As VatCode.vatCodes
            Get
                Return m_productVatCode
            End Get
            Set(ByVal Value As VatCode.vatCodes)
                m_productVatCode = Value
            End Set
        End Property

        Public Property DeliveredQuantity() As Decimal
            Get
                Return m_DeliveredQuantity
            End Get
            Set(ByVal value As Decimal)
                m_DeliveredQuantity = value
            End Set
        End Property

        Public Property AccountingSuggestionAccountNumber() As Integer
            Get
                Return m_AccountingSuggestionAccountNumber
            End Get
            Set(ByVal value As Integer)
                m_AccountingSuggestionAccountNumber = value
            End Set
        End Property

        Public Property productUnitPriceIsGross() As Boolean
            Get
                Return m_productUnitPriceIsGross
            End Get
            Set(ByVal Value As Boolean)
                m_productUnitPriceIsGross = Value
            End Set
        End Property

        Public Property LineDiscountPercentage() As Decimal
            Get
                Return m_LineDiscountPercentage
            End Get
            Set(ByVal value As Decimal)
                m_LineDiscountPercentage = value
            End Set
        End Property

        Public Property LineSum() As Decimal?
            Get
                Return m_LineSum
            End Get
            Set(ByVal value As Decimal?)
                m_LineSum = value
            End Set
        End Property

        Public Property LineVatSum() As Decimal?
            Get
                Return m_LineVatSum
            End Get
            Set(ByVal value As Decimal?)
                m_LineVatSum = value
            End Set
        End Property

        Public ReadOnly Property dimensions() As ArrayList
            Get
                Return m_dimensions
            End Get
        End Property

        Public Property LineText As String
            Get
                Return m_lineText
            End Get
            Set(value As String)
                m_lineText = value
            End Set
        End Property

        Public Property skipAccrual() As Boolean
            Get
                Return m_skipAccrual
            End Get
            Set(ByVal Value As Boolean)
                m_skipAccrual = Value
            End Set
        End Property

        Public Sub addDimension(ByVal dimension As NetvisorDimension)
            m_dimensions.Add(dimension)
        End Sub
    End Class
End Namespace