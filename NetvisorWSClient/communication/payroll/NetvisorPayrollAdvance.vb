Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.payroll


    Public Class NetvisorPayrollAdvance

        Public Enum advancePaymentTypes As Integer
            ispaid = 1
            notpaid = 2
        End Enum

        Public Enum advanceTypes As Integer
            payroll = 1
            tripExpence = 2
        End Enum

        Private m_Description As String
        Private m_EmployeeIdentifier As String
        Private m_PaymentDate As Date
        Private m_AdvanceSum As Double
        Private m_AdvancePaymentStatusType As advancePaymentTypes
        Private m_AdvanceType As advanceTypes


        Public Property AdvanceType() As advanceTypes
            Get
                Return m_AdvanceType
            End Get
            Set(ByVal Value As advanceTypes)
                m_AdvanceType = Value
            End Set
        End Property


        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal Value As String)
                m_Description = Value
            End Set
        End Property


        Public Property EmployeeIdentifier() As String
            Get
                Return m_EmployeeIdentifier
            End Get
            Set(ByVal Value As String)
                m_EmployeeIdentifier = Value
            End Set
        End Property


        Public Property PaymentDate() As Date
            Get
                Return m_PaymentDate
            End Get
            Set(ByVal Value As Date)
                m_PaymentDate = Value
            End Set
        End Property


        Public Property AdvanceSum() As Double
            Get
                Return m_AdvanceSum
            End Get
            Set(ByVal Value As Double)
                m_AdvanceSum = Value
            End Set
        End Property

        Public Property AdvancePaymentStatusType() As advancePaymentTypes
            Get
                Return m_AdvancePaymentStatusType
            End Get
            Set(ByVal Value As advancePaymentTypes)
                m_AdvancePaymentStatusType = Value
            End Set
        End Property

    End Class

End Namespace