Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPurchaseOrderCommentLine

        Private m_comment As String

        Public Sub New()
        End Sub

        Public Property comment As String
            Get
                Return m_comment
            End Get
            Set(ByVal value As String)
                m_comment = value
            End Set
        End Property

    End Class
End Namespace
