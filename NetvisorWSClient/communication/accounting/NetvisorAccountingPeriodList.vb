'
' Revisio $Revision$
'

Namespace NetvisorWSClient.communication.accounting

    Public Class NetvisorAccountingPeriodList

        Private m_AccountingPeriodLockDate As Date
        Private m_VatPeriodLockDate As Date
        Private m_PurchaseLockDate As Date

        Private m_periods As New List(Of NetvisorPeriod)

        Public Property AccountingPeriodLockDate() As Date
            Get
                Return m_AccountingPeriodLockDate
            End Get
            Set(ByVal Value As Date)
                m_AccountingPeriodLockDate = Value
            End Set
        End Property

        Public Property VatPeriodLockDate() As Date
            Get
                Return m_VatPeriodLockDate
            End Get
            Set(ByVal Value As Date)
                m_VatPeriodLockDate = Value
            End Set
        End Property

        Public Property PurchaseLockDate() As Date
            Get
                Return m_PurchaseLockDate
            End Get
            Set(ByVal Value As Date)
                m_PurchaseLockDate = Value
            End Set
        End Property

        Public Property periods() As List(Of NetvisorPeriod)
            Get
                Return m_periods
            End Get
            Set(ByVal Value As List(Of NetvisorPeriod))
                m_periods = Value
            End Set
        End Property

    End Class

End Namespace