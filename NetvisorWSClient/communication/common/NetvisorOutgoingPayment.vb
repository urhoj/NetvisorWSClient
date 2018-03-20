'
'
'
' Revisio $Revision$
'
' Ilmentää netvisorin tilisiirron
'
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.common
    Public Class NetvisorOutgoingPayment

        Public Enum BankPaymentMessageTypes
            FINNISH_REFERENCE = 1
            FREETEXT = 2
        End Enum

        Private m_RecipientOrganizationCode As FinnishOrganisationIdentifier
        Private m_RecipientName As String
        Private m_SourceBankAccountNumber As FinnishBankAccountNumber
        Private m_DestinationBankName As String
        Private m_DestinationBankBranch As String
        Private m_DestinationBankAccountNumber As FinnishBankAccountNumber
        Private m_DueDate As Date
        Private m_Amount As Decimal
        Private m_BankPaymentMessageType As BankPaymentMessageTypes
        Private m_BankPaymentMessage As String

        Public Property RecipientOrganizationCode() As FinnishOrganisationIdentifier
            Get
                Return m_RecipientOrganizationCode
            End Get
            Set(ByVal Value As FinnishOrganisationIdentifier)
                m_RecipientOrganizationCode = Value
            End Set
        End Property

        Public Property RecipientName() As String
            Get
                Return m_RecipientName
            End Get
            Set(ByVal value As String)
                m_RecipientName = value
            End Set
        End Property

        Public Property SourceBankAccountNumber() As FinnishBankAccountNumber
            Get
                Return m_SourceBankAccountNumber
            End Get
            Set(ByVal value As FinnishBankAccountNumber)
                m_SourceBankAccountNumber = value
            End Set
        End Property

        Public Property DestinationBankName() As String
            Get
                Return m_DestinationBankName
            End Get
            Set(ByVal value As String)
                m_DestinationBankName = value
            End Set
        End Property

        Public Property DestinationBankBranch() As String
            Get
                Return m_DestinationBankBranch
            End Get
            Set(ByVal value As String)
                m_DestinationBankBranch = value
            End Set
        End Property

        Public Property DestinationBankAccountNumber() As FinnishBankAccountNumber
            Get
                Return m_DestinationBankAccountNumber
            End Get
            Set(ByVal value As FinnishBankAccountNumber)
                m_DestinationBankAccountNumber = value
            End Set
        End Property

        Public Property DueDate() As Date
            Get
                Return m_DueDate
            End Get
            Set(ByVal value As Date)
                m_DueDate = value
            End Set
        End Property

        Public Property Amount() As Decimal
            Get
                Return m_Amount
            End Get
            Set(ByVal value As Decimal)
                m_Amount = value
            End Set
        End Property


        Public Property BankPaymentMessageType() As BankPaymentMessageTypes
            Get
                Return m_BankPaymentMessageType
            End Get
            Set(ByVal value As BankPaymentMessageTypes)
                m_BankPaymentMessageType = value
            End Set
        End Property

        Public Property BankPaymentMessage() As String
            Get
                Return m_BankPaymentMessage
            End Get
            Set(ByVal Value As String)
                m_BankPaymentMessage = Value
            End Set
        End Property

    End Class
End Namespace
