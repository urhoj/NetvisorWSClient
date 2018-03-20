'
'
'
' Revisio $Revision$
'
' Ilmentää netvisorin tuotelistauksessa tulevan tuotteen
'

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorProductListProduct

        Private m_netvisorKey As Integer
        Private m_productCode As String
        Private m_name As String
        Private m_unitPrice As Decimal
        Private m_uri As String

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

        Public Property name() As String
            Get
                Return m_name
            End Get
            Set(ByVal Value As String)
                m_name = Value
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