'
'
'
' Revisio $Revision$
'
' Ilmentää työpäivän tuntikirjauksen
'

Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector
	<ComClass(NetvisorWorkDayHour.ClassId, NetvisorWorkDayHour.InterfaceId, NetvisorWorkDayHour.EventsId)> Public Class NetvisorWorkDayHour

		Public Const ClassId As String = "C02FCE26-F759-4d5f-9D6A-4CF98125CCDE"
		Public Const InterfaceId As String = "C475FD80-2C8B-4047-8E72-0042687E7086"
		Public Const EventsId As String = "662D2733-E899-4e5c-8CC7-16CCB27930F1"

		Public Enum acceptanceStatuses As Integer
			confirmed = 1
			accepted = 2
        End Enum

        Public Enum billingType As Integer
            unbillable = 1
            billable = 2
        End Enum

		Private m_Hours As Decimal
		Private m_CollectorRatioNumber As String
		Private m_AcceptanceStatus As acceptanceStatuses
        Private m_Description As String
        Private m_CrmProcessIdentifier As String
        Private m_CrmProcessIdentifierBillingType As billingType
        Private m_InvoicingProductIdentifier As String
        Private m_dimensions As New ArrayList

		Public Property Hours() As Decimal
			Get
				Return m_Hours
			End Get
			Set(ByVal Value As Decimal)
				m_Hours = Value
			End Set
		End Property

		Public Sub setHours(ByVal hours As String)
			m_Hours = Decimal.Parse(hours)
		End Sub

		Public Property CollectorRatioNumber() As String
			Get
				Return m_CollectorRatioNumber
			End Get
			Set(ByVal Value As String)
				m_CollectorRatioNumber = Value
			End Set
		End Property

		Public Property AcceptanceStatus() As acceptanceStatuses
			Get
				Return m_AcceptanceStatus
			End Get
			Set(ByVal Value As acceptanceStatuses)
				m_AcceptanceStatus = Value
			End Set
		End Property

        Public Property CrmProcessIdentifier() As String
            Get
                Return m_CrmProcessIdentifier
            End Get
            Set(ByVal Value As String)
                m_CrmProcessIdentifier = Value
            End Set
        End Property

        Public Property CrmProcessIdentifierBillingType() As billingType
            Get
                Return m_CrmProcessIdentifierBillingType
            End Get
            Set(ByVal Value As billingType)
                m_CrmProcessIdentifierBillingType = Value
            End Set
        End Property

        Public Property InvoicingProductIdentifier() As String
            Get
                Return m_InvoicingProductIdentifier
            End Get
            Set(ByVal Value As String)
                m_InvoicingProductIdentifier = Value
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

		Public ReadOnly Property dimensions() As ArrayList
			Get
				Return m_dimensions
			End Get
		End Property

		Public Sub setAcceptanceConfirmed()
			m_AcceptanceStatus = acceptanceStatuses.confirmed
		End Sub

		Public Sub addDimension(ByVal dimension As NetvisorDimension)
			m_dimensions.Add(dimension)
		End Sub

		Public Sub clearDimensions()
			m_dimensions.Clear()
		End Sub
	End Class
End Namespace