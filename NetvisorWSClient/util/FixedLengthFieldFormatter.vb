'
'
'
' Revisio $Revision$
'
' Luokka määrämittaisen tiedon käsittelyyn. Etumerkkitäytöt yms.
'

Namespace NetvisorWSClient.util
    Public Class FixedLengthFieldFormatter

        Public Enum FiedType
            TYPE_INT = 1
            TYPE_FLOAT = 2
            TYPE_STRING = 3
        End Enum

        Public Shared Function FormatString(ByRef value As String, ByVal maxLength As Integer, Optional ByVal stripOverflow As Boolean = False) As String

            If Len(value) > maxLength Then
                If stripOverflow Then
                    value = Mid(value, 1, maxLength)
                Else
                    Throw New ApplicationException("Too long value in FormatString: " & value & ", maximun allowed: " & maxLength)
                End If
            End If

            Return String.Format("{0," & -maxLength & "}", value)

        End Function

        Public Shared Function FormatDouble(ByRef value As Double, ByVal maxLength As Integer, ByVal decimals As Integer) As String

			' ensin pyöristetään haluttuihin desimaaleihin, sitten kerrotaan desimaalien määrällä
            ' jonka jälkeen meillä on haluttu tulos

			value = Math.Round(value, decimals, MidpointRounding.AwayFromZero)

			If Len(value.ToString()) > maxLength Then
				Throw New ApplicationException("Too long value in FormatInteger: " & value & ", maximun allowed: " & maxLength)
			End If

            Dim valueAsInteger As Integer = CType(value * Math.Pow(10, decimals), Integer)

            Return FormatInteger(valueAsInteger, maxLength)

        End Function

        Public Shared Function FormatInteger(ByRef value As UInt64, ByVal maxLength As Integer) As String
            If Len(value.ToString()) > maxLength Then
                Throw New ApplicationException("Too long value in FormatInteger: " & value & ", maximun allowed: " & maxLength)
            End If

            Return String.Format("{0," & maxLength & "}", value.ToString()).Replace(" ", "0")
        End Function

    End Class
End Namespace
