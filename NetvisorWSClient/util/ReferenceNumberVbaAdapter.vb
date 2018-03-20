'
' Revisio $Revision$
'
' VBA compatible version of ReferenceNumber -class
'

Namespace NetvisorWSClient.util
    Public Class ReferenceNumberVbaAdapter

        Public Sub New()
        End Sub

        Public Function getReferenceNumber(ByVal number As String, ByVal hasChecksum As Boolean) As ReferenceNumber
            If isValidReferenceNumber(number, hasChecksum) Then
                Return New ReferenceNumber(number, hasChecksum)
            Else
                Return Nothing
            End If
        End Function

        Public Function isValidReferenceNumber(ByVal number As String, ByVal hasChecksum As Boolean) As Boolean
            Return ReferenceNumber.isReferenceNumberValid(number, hasChecksum)
        End Function
    End Class
End Namespace
