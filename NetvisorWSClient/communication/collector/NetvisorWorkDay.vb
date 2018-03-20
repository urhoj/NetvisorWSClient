'
'
'
' Revisio $Revision$
'
' Ilmentää työpäivän työntekijälle
'

Namespace NetvisorWSClient.communication.collector
    <ComClass(NetvisorWorkDay.ClassId, NetvisorWorkDay.InterfaceId, NetvisorWorkDay.EventsId)> Public Class NetvisorWorkDay

        Public Const ClassId As String = "AB758C8C-AA5E-436e-B11D-8ADAEAB9C9CA"
        Public Const InterfaceId As String = "C4E7FB7C-EDFA-4603-BEF3-F03FEB8BB7F6"
        Public Const EventsId As String = "EB420946-69FF-4239-B28D-DC2D464B3DA0"

        Public Enum employeeIdentifierTypes As Integer
            number = 1
            personalidentificationnumber = 2
        End Enum

        Public Enum dateMethods As Integer
            replace = 1
            increment = 2
        End Enum

        Public Enum employeeDefaultDimensionHandlingTypes As Integer
            none = 1
            usedefault = 2
        End Enum

        Private m_date As Date
        Private m_dateMethod As dateMethods
        Private m_employeeIdentifier As String
        Private m_employeeIdentifierType As employeeIdentifierTypes
        Private m_employeeDefaultDimensionHandlingType As employeeDefaultDimensionHandlingTypes
        Private m_workDayHours As New ArrayList

        Public Sub New()
        End Sub

        Public Property [date]() As Date
            Get
                Return m_date
            End Get
            Set(ByVal Value As Date)
                m_date = Value
            End Set
        End Property

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

        Public Property dateMethod() As dateMethods
            Get
                Return m_dateMethod
            End Get
            Set(ByVal Value As dateMethods)
                m_dateMethod = Value
            End Set
        End Property

        Public Property employeeDefaultDimensionHandlingType() As employeeDefaultDimensionHandlingTypes
            Get
                Return m_employeeDefaultDimensionHandlingType
            End Get
            Set(ByVal Value As employeeDefaultDimensionHandlingTypes)
                m_employeeDefaultDimensionHandlingType = Value
            End Set
        End Property


        Public ReadOnly Property workDayHours() As ArrayList
            Get
                Return m_workDayHours
            End Get
        End Property

        Public Sub addHours(ByVal hour As NetvisorWorkDayHour)
            m_workDayHours.Add(hour)
        End Sub

        Public Sub clearHours()
            m_workDayHours.Clear()
        End Sub
    End Class
End Namespace