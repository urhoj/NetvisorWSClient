'
'
' Ilmentää netvisorin Laskentakohteen

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorDimensionNameDimensionDetail

        Private m_netvisorKey As Integer
        Private m_name As String
        Private m_IsHidden As Boolean
        Private m_sort As Integer
        Private m_endSort As Integer
        Private m_level As Integer
        Private m_fatherID As Integer

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

        Public Property Level() As Integer
            Get
                Return m_level
            End Get
            Set(ByVal Value As Integer)
                m_level = Value
            End Set
        End Property

        Public Property Sort() As Integer
            Get
                Return m_sort
            End Get
            Set(ByVal Value As Integer)
                m_sort = Value
            End Set
        End Property

        Public Property EndSort() As Integer
            Get
                Return m_endSort
            End Get
            Set(ByVal Value As Integer)
                m_endSort = Value
            End Set
        End Property

        Public Property FatherID() As Integer
            Get
                Return m_fatherID
            End Get
            Set(ByVal Value As Integer)
                m_fatherID = Value
            End Set
        End Property

        Public Sub New()
        End Sub
    End Class

    Public Class NetvisorDimenisonNameDimensionDetail
        Inherits NetvisorDimensionNameDimensionDetail

        ' To support old misnamed class 

        Public Sub New()
            MyBase.New()
        End Sub
    End Class
End Namespace
