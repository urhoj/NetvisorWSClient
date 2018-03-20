'
' Revisio $Revision$
'
' Ilmentää Netvisorin matkalaskun kilometrikorvauksen
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector
    Public Class NetvisorCollectorTripExpenseTravelLine

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

        Public Enum travelTypes As Integer
            CAR = 1
            CAR_WITH_TRAILER = 2
            CAR_WITH_CARAVAN = 3
            CAR_WITH_HEAVY_CARGO = 4
            CAR_WITH_BIG_MACHINERY = 5
            CAR_WITH_DOG = 6
            CAR_TRAVEL_IN_ROUGH_TERRAIN = 7
            MOTORBOAT_MAX_50HP = 8
            MOTORBOAT_OVER_50HP = 9
            SNOWMOBILE = 10
            ATV = 11
            MOTORBIKE = 12
            MOPED = 13
            OTHER = 14
        End Enum

        Private m_employeeIdentifier As String
        Private m_employeeIdentifierType As employeeIdentifierTypes
        Private m_travelType As travelTypes
        Private m_passangerAmount As Decimal
        Private m_kilometerAmount As Decimal
        Private m_unitPrice As Decimal
        Private m_routeDescription As String
        Private m_lineDescription As String
        Private m_travelDate As Date
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

        Public Property travelType() As travelTypes
            Get
                Return m_travelType
            End Get
            Set(ByVal Value As travelTypes)
                m_travelType = Value
            End Set
        End Property

        Public Property passangerAmount() As Decimal
            Get
                Return m_passangerAmount
            End Get
            Set(ByVal Value As Decimal)
                m_passangerAmount = Value
            End Set
        End Property

        Public Property kilometerAmount() As Decimal
            Get
                Return m_kilometerAmount
            End Get
            Set(ByVal Value As Decimal)
                m_kilometerAmount = Value
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

        Public Property routeDescription() As String
            Get
                Return m_routeDescription
            End Get
            Set(ByVal Value As String)
                m_routeDescription = Value
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

        Public Property travelDate() As Date
            Get
                Return m_travelDate
            End Get
            Set(ByVal Value As Date)
                m_travelDate = Value
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