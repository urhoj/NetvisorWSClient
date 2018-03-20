'
' Revisio $Revision$
'
' Ilmentää Netvisorin matkalaskun muun kulurivin
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector

    Public Class NetvisorCollectorTripExpenseCustomLine

        Public Enum employeeIdentifierTypes As Integer
            finnishPersonalIdentifier = 1
            number = 2
        End Enum

        Public Enum customerIdentifierTypes As Integer
            netvisor = 1
            customerCode = 2
        End Enum

        Public Enum LineStatuses As Integer
            OPEN = 1
            CONFIRMED = 2
            CONTENTSUPERVISORED = 6
            ACCEPTED = 3
            PAID = 5
        End Enum


        Private m_employeeIdentifier As String
        Private m_employeeIdentifierType As employeeIdentifierTypes
        Private m_ratio As String
        Private m_amount As Decimal
        Private m_customLineUnitPrice As Decimal
        Private m_vatPercentage As String
        Private m_lineDescription As String
        Private m_CRMProcessIdentifier As String
        Private m_customerIdentifier As String
        Private m_customerIdentifierType As customerIdentifierTypes
        Private m_ExpenseAccountNumber As String
        Private m_dimensions As New ArrayList
        Private m_attachments As New ArrayList
        Private m_lineStatus As LineStatuses

        Public Property employeeIdentifier() As String
            Get
                Return m_employeeIdentifier
            End Get
            Set(ByVal Value As String)
                m_employeeIdentifier = Value
            End Set
        End Property

        Public Property employeeIdentifierType() As employeeIdentifierTypes
            Get
                Return m_employeeIdentifierType
            End Get
            Set(ByVal Value As employeeIdentifierTypes)
                m_employeeIdentifierType = Value
            End Set
        End Property

        Public Property ratio() As String
            Get
                Return m_ratio
            End Get
            Set(ByVal Value As String)
                m_ratio = Value
            End Set
        End Property

        Public Property amount() As Decimal
            Get
                Return m_amount
            End Get
            Set(ByVal Value As Decimal)
                m_amount = Value
            End Set
        End Property

        Public Property customLineUnitPrice() As Decimal
            Get
                Return m_customLineUnitPrice
            End Get
            Set(ByVal Value As Decimal)
                m_customLineUnitPrice = Value
            End Set
        End Property

        Public Property vatPercentage() As String
            Get
                Return m_vatPercentage
            End Get
            Set(ByVal Value As String)
                m_vatPercentage = Value
            End Set
        End Property

        Public Property lineDescription() As String
            Get
                Return m_lineDescription
            End Get
            Set(ByVal Value As String)
                m_lineDescription = Value
            End Set
        End Property

        Public Property CRMProcessIdentifier() As String
            Get
                Return m_CRMProcessIdentifier
            End Get
            Set(ByVal Value As String)
                m_CRMProcessIdentifier = Value
            End Set
        End Property

        Public Property customerIdentifier() As String
            Get
                Return m_customerIdentifier
            End Get
            Set(ByVal Value As String)
                m_customerIdentifier = Value
            End Set
        End Property

        Public Property customerIdentifierType() As customerIdentifierTypes
            Get
                Return m_customerIdentifierType
            End Get
            Set(ByVal Value As customerIdentifierTypes)
                m_customerIdentifierType = Value
            End Set
        End Property

        Public Property ExpenseAccountNumber() As String
            Get
                Return m_ExpenseAccountNumber
            End Get
            Set(ByVal Value As String)
                m_ExpenseAccountNumber = Value
            End Set
        End Property

        Public Property lineStatus As LineStatuses
            Get
                Return m_lineStatus
            End Get
            Set(value As LineStatuses)
                m_lineStatus = value
            End Set
        End Property


        Public Sub addDimension(ByVal dimension As NetvisorDimension)
            m_dimensions.Add(dimension)
        End Sub

        Public Sub addAttachment(ByVal attachment As NetvisorAttachment)
            m_attachments.Add(attachment)
        End Sub

        Public ReadOnly Property dimensions() As ArrayList
            Get
                Return m_dimensions
            End Get
        End Property

        Public ReadOnly Property attachments() As ArrayList
            Get
                Return m_attachments
            End Get
        End Property

    End Class

End Namespace