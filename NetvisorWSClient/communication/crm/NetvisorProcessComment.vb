'
' Revisio $Revision$
' 
' Ilmentää tehtävän kommentin Netvisorin asiakkuuden hallinnassa
'

Namespace NetvisorWSClient.communication.crm

    Public Class NetvisorProcessComment

        Private m_WriterName As String
        Private m_Message As String
        Private m_CreatedTimeStamp As Date

        Public Property WriterName() As String
            Get
                Return m_WriterName
            End Get
            Set(ByVal value As String)
                m_WriterName = value
            End Set
        End Property

        Public Property Message() As String
            Get
                Return m_Message
            End Get
            Set(ByVal value As String)
                m_Message = value
            End Set
        End Property

        Public Property CreatedTimeStamp() As Date
            Get
                Return m_CreatedTimeStamp
            End Get
            Set(ByVal value As Date)
                m_CreatedTimeStamp = value
            End Set
        End Property

    End Class
End Namespace

