'
'
'
' Revisio $Revision$
'

'SHA256 Mac laskenta

Namespace NetvisorWSClient.util
    Public Class Hash

        Private m_stringToEncode As String

        Private m_32CharHexString As String
        Private m_bytes As Byte()

        Enum hashType As Integer
            byteArray = 1
            s32CharHexString = 2
        End Enum

        Public Sub New(ByVal stringToEncode As String)
            m_stringToEncode = stringToEncode
        End Sub

        Public Function getHashAsByteArray() As Byte()
            compute(hashType.byteArray)

            Return m_bytes
        End Function

        Public Function getHashAs32CharHexString() As String
            compute(hashType.s32CharHexString)

            Return m_32CharHexString
        End Function

        Private Sub compute(ByVal type As hashType)

            Dim Ne As Text.Encoding = System.Text.Encoding.Default
            Dim SHA256 As New System.Security.Cryptography.SHA256CryptoServiceProvider()
            Dim bytes As Byte() = SHA256.ComputeHash(Ne.GetBytes(m_stringToEncode))

            Select Case type

                Case hashType.byteArray
                    m_bytes = m_bytes

                Case hashType.s32CharHexString
                    Dim ret As String = vbNullString

                    For Each bytByte As Byte In bytes

                        ret &= bytByte.ToString("X2")
                    Next

                    m_32CharHexString = ret

            End Select

            Ne = Nothing
            SHA256 = Nothing
        End Sub
    End Class
End Namespace
