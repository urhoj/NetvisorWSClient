'
'
'
' Revisio $Revision$
'
' Ilmentää myyntilaskulle lisättävän kommenttirivin
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorInvoiceCommentLine
        Implements INetvisorInvoiceLine

        Dim m_comment As String

        Public Property comment() As String
            Get
                Return m_comment
            End Get
            Set(ByVal Value As String)
                m_comment = Value
            End Set
        End Property
    End Class
End Namespace