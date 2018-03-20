Public Class NetvisorPurchaseOrderListOrder

    Private m_netvisorKey As Integer
    Private m_orderNumber As String
    Private m_orderDate As Date
    Private m_orderStatus As String
    Private m_vendorName As String
    Private m_amount As Double
    Private m_uri As String

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

    Public Property orderDate As Date
        Get
            Return m_orderDate
        End Get
        Set(ByVal value As Date)
            m_orderDate = value
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

    Public Property vendorName As String
        Get
            Return m_vendorName
        End Get
        Set(ByVal value As String)
            m_vendorName = value
        End Set
    End Property

    Public Property amount As Double
        Get
            Return m_amount
        End Get
        Set(ByVal value As Double)
            m_amount = value
        End Set
    End Property

    Public Property uri As String
        Get
            Return m_uri
        End Get
        Set(ByVal value As String)
            m_uri = value
        End Set
    End Property
End Class
