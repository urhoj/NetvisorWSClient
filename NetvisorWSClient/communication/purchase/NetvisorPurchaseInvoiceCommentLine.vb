Imports NetvisorWSClient.communication.common

'
'
'
' Revisio $Revision$
'
' Ilmentää netvisoriin vietävän ostolaskun kommenttirivin
'

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPurchaseInvoiceCommentLine

        Private m_comment As String
        Private m_sort As Integer


        Public Property comment() As String
            Get
                Return m_comment
            End Get
            Set(ByVal Value As String)
                m_comment = Value
            End Set
        End Property

        Public Property sort() As Integer
            Get
                Return m_sort
            End Get
            Set(ByVal Value As Integer)
                m_sort = Value
            End Set
        End Property

    End Class
End Namespace