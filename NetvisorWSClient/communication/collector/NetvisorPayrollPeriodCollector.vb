'
'
'
' Revisio $Revision$
'
' Ilmentää palkkajaksokirjaukset työntekijälle ja päivälle
'

Namespace NetvisorWSClient.communication.collector
    <ComClass(NetvisorPayrollPeriodCollector.ClassId, NetvisorPayrollPeriodCollector.InterfaceId, NetvisorPayrollPeriodCollector.EventsId)> Public Class NetvisorPayrollPeriodCollector

        Public Const ClassId As String = "EF904C27-BCFF-489C-95A1-628460820344"
        Public Const InterfaceId As String = "4EA0AC1A-5A96-4FB5-A79C-9DD1D6298D39"
        Public Const EventsId As String = "F4E0C456-C339-44D9-81C8-44A5C88D4FBF"

        Public Enum employeeIdentifierTypes As Integer
            number = 1
            personalidentificationnumber = 2
        End Enum

        Private m_date As Date
        Private m_employeeIdentifier As String
        Private m_employeeIdentifierType As employeeIdentifierTypes
        Private m_ratioLines As New ArrayList

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

        Public ReadOnly Property ratioLines() As ArrayList
            Get
                Return m_ratioLines
            End Get
        End Property

        Public Sub addRatioLine(ByVal line As NetvisorPayrollRatioLine)
            m_ratioLines.Add(line)
        End Sub

        Public Sub clearRatioLines()
            m_ratioLines.Clear()
        End Sub

    End Class
End Namespace