'
'
'
' Revisio $Revision$
'
' Ilmentää netvisoriin laskun mukana lähetettävän custom-tositerivin
'

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorInvoiceVoucherLine

        Public Enum lineSumTypes As Integer
            NET = 1
            GROSS = 2
        End Enum

        Private m_lineSum As Decimal
        Private m_lineSumType As lineSumTypes
        Private m_AccountNumber As Integer
        Private m_vatClass As Decimal
        Private m_vatCode As String
        Private m_lineDescription As String
        Private m_skipAccrual As Boolean

        Private m_dimensionName As String
        Private m_dimensionItem As String

        Private m_dimensions As New ArrayList

        Public Property lineSum() As Decimal
            Get
                Return m_lineSum
            End Get
            Set(ByVal Value As Decimal)
                m_lineSum = Value
            End Set
        End Property

        Public Property AccountNumber() As Integer
            Get
                Return m_AccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_AccountNumber = Value
            End Set
        End Property

        Public Property vatClass() As Decimal
            Get
                Return m_vatClass
            End Get
            Set(ByVal Value As Decimal)
                m_vatClass = Value
            End Set
        End Property

        Public Property vatCode() As String
            Get
                Return m_vatCode
            End Get
            Set(ByVal Value As String)
                m_vatCode = Value
            End Set
        End Property

        Public Property LineSumType() As lineSumTypes
            Get
                Return m_lineSumType
            End Get
            Set(ByVal Value As lineSumTypes)
                m_lineSumType = Value
            End Set
        End Property

        Public Property LineDescription() As String
            Get
                Return m_lineDescription
            End Get
            Set(ByVal Value As String)
                m_lineDescription = Value
            End Set
        End Property

        Public Property dimensionName() As String
            Get
                Return m_dimensionName
            End Get
            Set(ByVal Value As String)
                m_dimensionName = Value
            End Set
        End Property

        Public Property dimensionItem() As String
            Get
                Return m_dimensionItem
            End Get
            Set(ByVal Value As String)
                m_dimensionItem = Value
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

        Public ReadOnly Property Dimensions As ArrayList
            Get
                Return m_dimensions
            End Get
        End Property

        Public Sub addDimension(ByVal netvisorDimension As common.NetvisorDimension)
            m_dimensions.Add(netvisorDimension)
        End Sub

    End Class
End Namespace
