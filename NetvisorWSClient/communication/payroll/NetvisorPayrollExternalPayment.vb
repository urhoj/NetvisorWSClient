Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.payroll


    Public Class NetvisorPayrollExternalPayment

        Private m_Description As String
        Private m_PaymentDate As Date
        Private m_ExternalPaymentSum As String
        Private m_IBAN As String
        Private m_BIC As String
        Private m_HETU As String
        Private m_Realname As String


        Public Property IBAN() As String
            Get
                Return m_IBAN
            End Get
            Set(ByVal Value As String)
                m_IBAN = Value
            End Set
        End Property


        Public Property BIC() As String
            Get
                Return m_BIC
            End Get
            Set(ByVal Value As String)
                m_BIC = Value
            End Set
        End Property


        Public Property HETU() As String
            Get
                Return m_HETU
            End Get
            Set(ByVal Value As String)
                m_HETU = Value
            End Set
        End Property


        Public Property Realname() As String
            Get
                Return m_Realname
            End Get
            Set(ByVal Value As String)
                m_Realname = Value
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


        Public Property PaymentDate() As Date
            Get
                Return m_PaymentDate
            End Get
            Set(ByVal Value As Date)
                m_PaymentDate = Value
            End Set
        End Property


        Public Property ExternalPaymentSum() As String
            Get
                Return m_ExternalPaymentSum
            End Get
            Set(ByVal Value As String)
                m_ExternalPaymentSum = Value
            End Set
        End Property

    End Class

End Namespace