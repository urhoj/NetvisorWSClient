'
' Revisio $Revision$
'

Namespace NetvisorWSClient.communication.accounting

    Public Class NetvisorPeriod

        Private m_netvisorKey As Integer
        Private m_Name As String
        Private m_beginDate As Date
        Private m_endDate As Date

        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
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

        Public Property beginDate() As Date
            Get
                Return m_beginDate
            End Get
            Set(ByVal Value As Date)
                m_beginDate = Value
            End Set
        End Property

        Public Property endDate() As Date
            Get
                Return m_endDate
            End Get
            Set(ByVal Value As Date)
                m_endDate = Value
            End Set
        End Property

    End Class

End Namespace