'
' Revisio $Revision$
'
' Ilmentää Netvisorin matkalaskun päiväraharivin
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector
    Public Class NetvisorCollectorTripExpenseDailyCompensationLine

        Public Enum employeeIdentifierTypes As Integer
            finnishPersonalIdentifier = 1
            number = 2
        End Enum

        Public Enum customerIdentifierTypes As Integer
            netvisor = 1
            customerCode = 2
        End Enum

        Public Enum compensationTypes As Integer
            domesticFull = 1
            domesticHalf = 2
            foreign = 3
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
        Private m_compensationType As compensationTypes
        Private m_amount As Decimal
        Private m_unitPrice As Decimal
        Private m_lineDescription As String
        Private m_timeOfDeparture As Date
        Private m_returnTime As Date
        Private m_CRMProcessIdentifier As String
        Private m_customerIdentifier As String
        Private m_customerIdentifierType As customerIdentifierTypes
        Private m_lineStatus As LineStatuses

        Private m_dimensions As New ArrayList
        Private m_attachments As New ArrayList

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

        Public Property compensationType() As compensationTypes
            Get
                Return m_compensationType
            End Get
            Set(ByVal Value As compensationTypes)
                m_compensationType = Value
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

        Public Property unitPrice() As Decimal
            Get
                Return m_unitPrice
            End Get
            Set(ByVal Value As Decimal)
                m_unitPrice = Value
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

        Public Property timeOfDeparture() As Date
            Get
                Return m_timeOfDeparture
            End Get
            Set(ByVal Value As Date)
                m_timeOfDeparture = Value
            End Set
        End Property

        Public Property returnTime() As Date
            Get
                Return m_returnTime
            End Get
            Set(ByVal Value As Date)
                m_returnTime = Value
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

    End Class
End Namespace