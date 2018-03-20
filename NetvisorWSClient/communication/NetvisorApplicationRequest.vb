'
'
'
' Revisio $Revision$
' 

Namespace NetvisorWSClient.communication
    Public Class NetvisorApplicationRequest

        Private m_xmlData As String
        Private m_url As String

        Public Property requestURL() As String
            Set(ByVal value As String)
                m_url = value
            End Set
            Get
                Return m_url
            End Get
        End Property

        Public Property requestData() As String
            Get
                Return m_xmlData
            End Get
            Set(ByVal value As String)
                m_xmlData = value
            End Set
        End Property


    End Class
End Namespace