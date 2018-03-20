'
' Revisio $Revision$
' 
' Ilmentää tehtävän taloudellisen kulutiedon Netvisorin asiakkuuden hallinnassa
'

Namespace NetvisorWSClient.communication.crm

    Public Class NetvisorProcessExpence

        Public Shared ReadOnly _
        purchaseInvoice As String = "PurchaseInvoice", _
        tripCustomExpence As String = "TripCustomExpence", _
        tripCompensationExpence As String = "TripCompensationExpence", _
        tripTravelExpence As String = "TripTravelExpence", _
        workHours As String = "WorkHours"

        Public Enum ExpenceTypes
            purchaseInvoice = 1
            tripCustomExpence = 2
            tripCompensationExpence = 3
            tripTravelExpence = 4
            workHours = 5
        End Enum

        Private m_ExpenceType As ExpenceTypes
        Private m_ExpenceDescription As String
        Private m_ExpenceSum As Double

        Public Property ExpenceType() As ExpenceTypes
            Get
                Return m_ExpenceType
            End Get
            Set(ByVal value As ExpenceTypes)
                m_ExpenceType = value
            End Set
        End Property

        Public Property ExpenceDescription() As String
            Get
                Return m_ExpenceDescription
            End Get
            Set(ByVal value As String)
                m_ExpenceDescription = value
            End Set
        End Property

        Public Property ExpenceSum() As Double
            Get
                Return m_ExpenceSum
            End Get
            Set(ByVal value As Double)
                m_ExpenceSum = value
            End Set
        End Property

        Public Function getExpenceType(ByVal typeString As String) As ExpenceTypes

            Select Case typeString
                Case purchaseInvoice
                    Return ExpenceTypes.purchaseInvoice
                Case tripCompensationExpence
                    Return ExpenceTypes.tripCompensationExpence
                Case tripCustomExpence
                    Return ExpenceTypes.tripCustomExpence
                Case tripTravelExpence
                    Return ExpenceTypes.tripTravelExpence
                Case workHours
                    Return ExpenceTypes.workHours
                Case Else
                    Throw New Exception("not supported expence type")
            End Select

        End Function
    End Class

End Namespace
