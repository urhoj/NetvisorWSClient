Imports NetvisorWSClient.communication.common

'
' Revisio $Revision$
'
' Ilmentää netvisoriin vietävän ostolaskun ali-/summarivin
'

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPurchaseInvoiceSubLine

        Public Const MAX_SUBLINEDESCRIPTION_LENGTH As Integer = 200
        Public Const MAX_PRODUCT_CODE_LENGTH As Integer = 50
        Public Const MAX_PRODUCT_NAME_LENGTH As Integer = 50
        Public Const MAX_PRODUCT_UNIT_NAME_LENGTH As Integer = 10

        Private m_productCode As String
        Private m_productName As String
        Private m_orderedAmount As Object
        Private m_deliveredAmount As Object
        Private m_unitName As String
        Private m_unitPrice As Object
        Private m_discountPercentage As Object
        Private m_vatPercent As Object
        Private m_lineSum As Object
        Private m_vatSum As Object
        Private m_lineSumWithoutVat As Object
        Private m_description As String
        Private m_sort As Integer


        Public Property productCode() As String
            Get
                Return m_productCode
            End Get
            Set(ByVal Value As String)
                m_productCode = Value
            End Set
        End Property


        Public Property productName() As String
            Get
                Return m_productName
            End Get
            Set(ByVal Value As String)
                m_productName = Value
            End Set
        End Property


        Public Property orderedAmount() As Object
            Get
                Return m_orderedAmount
            End Get
            Set(ByVal Value As Object)
                m_orderedAmount = Value
            End Set
        End Property


        Public Property deliveredAmount() As Object
            Get
                Return m_deliveredAmount
            End Get
            Set(ByVal Value As Object)
                m_deliveredAmount = Value
            End Set
        End Property


        Public Property unitName() As String
            Get
                Return m_unitName
            End Get
            Set(ByVal Value As String)
                m_unitName = Value
            End Set
        End Property


        Public Property unitPrice() As Object
            Get
                Return m_unitPrice
            End Get
            Set(ByVal Value As Object)
                m_unitPrice = Value
            End Set
        End Property


        Public Property discountPercentage() As Object
            Get
                Return m_discountPercentage
            End Get
            Set(ByVal Value As Object)
                m_discountPercentage = Value
            End Set
        End Property


        Public Property vatPercent() As Object
            Get
                Return m_vatPercent
            End Get
            Set(ByVal Value As Object)
                m_vatPercent = Value
            End Set
        End Property


        Public Property lineSum() As Object
            Get
                Return m_lineSum
            End Get
            Set(ByVal Value As Object)
                m_lineSum = Value
            End Set
        End Property


        Public Property vatSum() As Object
            Get
                Return m_vatSum
            End Get
            Set(ByVal Value As Object)
                m_vatSum = Value
            End Set
        End Property


        Public Property lineSumWithoutVat() As Object
            Get
                Return m_lineSumWithoutVat
            End Get
            Set(ByVal Value As Object)
                m_lineSumWithoutVat = Value
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


        Public Property sort() As Integer
            Get
                Return m_sort
            End Get
            Set(ByVal Value As Integer)
                m_sort = Value
            End Set
        End Property

    End Class
End Namespace