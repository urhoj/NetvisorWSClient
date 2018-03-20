
'
' Revisio $Revision$
'

Namespace NetvisorWSClient.communication.accounting

    Public Class NetvisorAccount

        Private m_NetvisorKey As Integer
        Private m_Number As String
        Private m_Name As String
        Private m_AccountType As String
        Private m_FatherNetvisorKey As Integer
        Private m_IsActive As Boolean
        Private m_IsCumulative As Boolean
        Private m_Sort As Integer
        Private m_EndSort As Integer
        Private m_IsNaturalNegative As Boolean

        Public Property NetvisorKey() As Integer
            Get
                Return m_NetvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_NetvisorKey = Value
            End Set
        End Property

        Public Property Number() As String
            Get
                Return m_Number
            End Get
            Set(ByVal Value As String)
                m_Number = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal Value As String)
                m_Name = Value
            End Set
        End Property

        Public Property AccountType() As String
            Get
                Return m_AccountType
            End Get
            Set(ByVal Value As String)
                m_AccountType = Value
            End Set
        End Property

        Public Property FatherNetvisorKey() As Integer
            Get
                Return m_FatherNetvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_FatherNetvisorKey = Value
            End Set
        End Property

        Public Property IsActive() As Boolean
            Get
                Return m_IsActive
            End Get
            Set(ByVal Value As Boolean)
                m_IsActive = Value
            End Set
        End Property

        Public Property IsCumulative() As Boolean
            Get
                Return m_IsCumulative
            End Get
            Set(ByVal Value As Boolean)
                m_IsCumulative = Value
            End Set
        End Property

        Public Property Sort() As Integer
            Get
                Return m_Sort
            End Get
            Set(ByVal Value As Integer)
                m_Sort = Value
            End Set
        End Property

        Public Property EndSort() As Integer
            Get
                Return m_EndSort
            End Get
            Set(ByVal Value As Integer)
                m_EndSort = Value
            End Set
        End Property

        Public Property IsNaturalNegative() As Boolean
            Get
                Return m_IsNaturalNegative
            End Get
            Set(ByVal Value As Boolean)
                m_IsNaturalNegative = Value
            End Set
        End Property

    End Class

End Namespace