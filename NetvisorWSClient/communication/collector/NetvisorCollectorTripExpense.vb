'
' Revisio $Revision$
'
' Ilmentää Netvisorin matkalaskun
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.collector
    Public Class NetvisorCollectorTripExpense

        Private m_header As String
        Private m_description As String

        Private m_customLines As New ArrayList
        Private m_travelLines As New ArrayList
        Private m_dailyCompensationLines As New ArrayList

        Public Property header() As String
            Get
                Return m_header
            End Get
            Set(ByVal Value As String)
                m_header = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal Value As String)
                m_description = Value
            End Set
        End Property

        Public ReadOnly Property customLines() As ArrayList
            Get
                Return m_customLines
            End Get
        End Property

        Public ReadOnly Property travelLines() As ArrayList
            Get
                Return m_travelLines
            End Get
        End Property

        Public ReadOnly Property dailyCompensationLines() As ArrayList
            Get
                Return m_dailyCompensationLines
            End Get
        End Property

        Public Sub addCustomLine(ByVal customLine As NetvisorCollectorTripExpenseCustomLine)
            m_customLines.Add(customLine)
        End Sub

        Public Sub addTravelLine(ByVal travelLine As NetvisorCollectorTripExpenseTravelLine)
            m_travelLines.Add(travelLine)
        End Sub

        Public Sub addDailyCompensationLine(ByVal compensationLine As NetvisorCollectorTripExpenseDailyCompensationLine)
            m_dailyCompensationLines.Add(compensationLine)
        End Sub

    End Class
End Namespace