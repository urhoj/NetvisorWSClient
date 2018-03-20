'
'
' Ilmentää netvisorin Laskentakohdeotsikon

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorDimensionName

        Private m_netvisorKey As Integer
        Private m_name As String
        Private m_IsHidden As Boolean
        Private m_linkType As Integer
        Private m_details As New ArrayList

        Public Property NetvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

        Public Property Name As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
            End Set
        End Property

        Public Property IsHidden() As Boolean
            Get
                Return m_IsHidden
            End Get
            Set(ByVal value As Boolean)
                m_IsHidden = value
            End Set
        End Property

        Public Property LinkType() As Integer
            Get
                Return m_linkType
            End Get
            Set(ByVal Value As Integer)
                m_linkType = Value
            End Set
        End Property

        Public Property DimensionDetails As ArrayList
            Get
                Return m_details
            End Get
            Set(ByVal value As ArrayList)
                m_details = value
            End Set
        End Property

    End Class
End Namespace
