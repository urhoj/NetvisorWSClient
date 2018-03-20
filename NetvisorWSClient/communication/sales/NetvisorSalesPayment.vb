'
'
'
' Revisio $Revision$
'
' Ilmentää netvisorin myyntisuorituksen
'

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorSalesPayment

        Public Const CURRENCY_EURO As String = "EUR"

        Public Enum targetTypes As Integer
            invoice = 1
            order = 2
        End Enum

        Public Enum targetIdentifierTypes As Integer
            invoiceId = 1
            invoiceNumber = 2
            invoiceReferenceNumber = 3
        End Enum

        Public Enum paymentMethodTypes As Integer
            bankaccount = 1
            alternative = 2
        End Enum

        Private m_sum As Decimal
        Private m_currency As String        
        Private m_paymentDate As Date
        Private m_targetType As targetTypes
        Private m_targetIdentifierType As targetIdentifierTypes
        Private m_targetIdentifier As String
        Private m_sourceName As String
        Private m_overrideAccountingAccountNumber As Integer
        Private m_overrideSalesReceivablesAccountNumber As Integer
        Private m_paymentMethodType As paymentMethodTypes
        Private m_paymentMethod As String

        Public Property sum() As Decimal
            Get
                Return m_sum
            End Get
            Set(ByVal value As Decimal)
                m_sum = value
            End Set
        End Property

        Public Property currency() As String
            Get
                Return m_currency
            End Get
            Set(ByVal Value As String)
                m_currency = Value
            End Set
        End Property

        Public Property paymentDate() As Date
            Get
                Return m_paymentDate
            End Get
            Set(ByVal value As Date)
                m_paymentDate = value
            End Set
        End Property

        Public Property targetType() As targetTypes
            Get
                Return m_targetType
            End Get
            Set(ByVal Value As targetTypes)
                m_targetType = Value
            End Set
        End Property

        Public Property targetIdentifierType() As targetIdentifierTypes
            Get
                Return m_targetIdentifierType
            End Get
            Set(ByVal Value As targetIdentifierTypes)
                m_targetIdentifierType = Value
            End Set
        End Property

        Public Property targetIdentifier() As String
            Get
                Return m_targetIdentifier
            End Get
            Set(ByVal value As String)
                m_targetIdentifier = value
            End Set
        End Property

        Public Property sourceName() As String
            Get
                Return m_sourceName
            End Get
            Set(ByVal value As String)
                m_sourceName = value
            End Set
        End Property

        Public Property overrideAccountingAccountNumber() As Integer
            Get
                Return m_overrideAccountingAccountNumber
            End Get
            Set(ByVal value As Integer)
                m_overrideAccountingAccountNumber = value
            End Set
        End Property

        Public Property overrideSalesReceivablesAccountNumber() As Integer
            Get
                Return m_overrideSalesReceivablesAccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_overrideSalesReceivablesAccountNumber = Value
            End Set
        End Property

        Public ReadOnly Property doOverrideSalesRecivablesAccountNumber() As Boolean
            Get
                Return m_overrideSalesReceivablesAccountNumber > 0
            End Get
        End Property

        Public ReadOnly Property doOverrideAccountingAccountNumber() As Boolean
            Get
                Return m_overrideAccountingAccountNumber > 0
            End Get
        End Property

        Public Property paymentMethodType() As paymentMethodTypes
            Get
                Return m_paymentMethodType
            End Get
            Set(ByVal Value As paymentMethodTypes)
                m_paymentMethodType = Value
            End Set
        End Property

        Public Property paymentMethod() As String
            Get
                Return m_paymentMethod
            End Get
            Set(ByVal Value As String)
                m_paymentMethod = Value
            End Set
        End Property
    End Class
End Namespace