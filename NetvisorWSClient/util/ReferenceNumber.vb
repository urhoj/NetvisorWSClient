'
'
'
' Revisio $Revision$
'
' Ilmentää viitenumeron
'

Namespace NetvisorWSClient.util
    Public Class ReferenceNumber

        Private m_fullReferenceNumber As String

        Public Sub New(ByVal referenceNumber As String, ByVal isFullReferenceNumber As Boolean)

            If isReferenceNumberValid(referenceNumber, isFullReferenceNumber) Then
                If isFullReferenceNumber Then
                    m_fullReferenceNumber = referenceNumber
                Else
                    m_fullReferenceNumber = referenceNumber & calculateCheckSum(referenceNumber)
                End If
            Else
                Throw New ApplicationException("Invalid referencenumber: " & referenceNumber)
            End If
        End Sub

        Public Function getMachineReadableFormat() As String
            Return m_fullReferenceNumber
        End Function

        Public Function getHumanReadableFormat() As String

            Dim formattedReferenceNumber As String = vbNullString
            Dim reversedReferenceNumber() As Char = removeLeadingZeros(m_fullReferenceNumber).Replace(" ", "").ToCharArray
            Dim counter As Integer

            Array.Reverse(reversedReferenceNumber)
            For Each s As String In reversedReferenceNumber
                formattedReferenceNumber = s & formattedReferenceNumber

                counter += 1
                If counter = 5 Then
                    formattedReferenceNumber = " " & formattedReferenceNumber
                    counter = 0
                End If
            Next

            Return formattedReferenceNumber.TrimStart
        End Function

        Private Shared Function calculateCheckSum(ByVal referenceNumberBody As String) As Short

            Dim multiplier() As Integer = {7, 3, 1}
            Dim position As Integer
            Dim referenceNumberForCalculation() As Char = removeLeadingZeros(referenceNumberBody).Replace(" ", "").ToCharArray
            Dim sum As Integer

            Array.Reverse(referenceNumberForCalculation)
            For Each s As String In referenceNumberForCalculation
                sum += s * multiplier(position)

                position += 1
                If position > 2 Then
                    position = 0
                End If
            Next

            Dim nextTenth As Integer = sum
            Do Until nextTenth Mod 10 = 0
                nextTenth = nextTenth + 1
            Loop

            Return nextTenth - sum
        End Function

        Public Shared Function isReferenceNumberValid(ByVal referenceNumber As String, Optional ByVal isFullReferenceNumber As Boolean = True) As Boolean

            Dim referenceNumberForCheck As String = removeLeadingZeros(referenceNumber).Replace(" ", "")
            Dim ret As Boolean = True

            If Not IsNumeric(referenceNumberForCheck) Then
                ret = False
            Else
                If Not isFullReferenceNumber Then
                    If referenceNumberForCheck.Length < 3 Or referenceNumberForCheck.Length > 19 Then
                        ret = False
                    End If
                Else
                    If referenceNumberForCheck.Length < 3 Or referenceNumberForCheck.Length > 20 Then
                        ret = False
                    Else
                        If Not calculateCheckSum(referenceNumberForCheck.Substring(0, referenceNumberForCheck.Length - 1)) = Right(referenceNumberForCheck, 1) Then
                            ret = False
                        End If
                    End If
                End If
            End If

            Return ret
        End Function

        Private Shared Function removeLeadingZeros(ByVal referencenumber As String) As String

            Dim formattedReferencenumber As String = referencenumber

            If formattedReferencenumber.Length > 0 Then
                Do While formattedReferencenumber.Substring(0, 1) = "0"
                    formattedReferencenumber = formattedReferencenumber.Substring(1)
                Loop
            End If

            Return formattedReferencenumber
        End Function
    End Class
End Namespace
