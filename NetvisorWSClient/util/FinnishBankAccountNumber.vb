'
'
'
' Revisio $Revision$
'
' K‰sitt‰‰ perinteisen suomalaisen pankkitilinumeron ilmentym‰n
' T‰h‰n on k‰ytetty Finanssialan keskusliiton m‰‰rityst‰
'
' SUOMALAISTEN TILINUMEROIDEN RAKENNE JA TARKISTE
'
' Pankit ja niiden tilinumeron alku:
'
' 1,2 =  Nordea Pankki (Nordea)
' 31  =  Handelsbanken (SHB)
' 33  =  Skandinaviska Enskilda Banken (SEB)
' 34  =  Danske Bank
' 36  =  Tapiola Pankki (Tapiola)
' 37  =  DnB NOR Bank ASA (DnB NOR)
' 38  =  Swedbank
' 39  =  S-Pankki
' 4   =  s‰‰stˆpankit (Sp) ja paikallisosuuspankit (Pop) sek‰ Aktia
' 5   =  osuuspankit (Op), OKO ja Okopankki
' 6   =  ≈landsbanken ≈AB)
' 8   =  Sampo Pankki (Sampo)
'

Option Explicit On

Imports System.IO

Namespace NetvisorWSClient.util
    Public Class FinnishBankAccountNumber
        Implements IBankAccountNumber

        Private m_accountNumber As String

        Public Sub New(ByVal accountNumber As String)

            m_accountNumber = accountNumber

            If FinnishBankAccountNumber.isAccountNumberCorrect(accountNumber) = False Then
                Throw New InvalidDataException("Finnish accountnumber is not valid")
                m_accountNumber = vbNullString
            End If
        End Sub

        Private Sub New(ByVal accountNumber As String, ByVal noAccountnumberCheck As Boolean)
            m_accountNumber = accountNumber
        End Sub

        ''' <summary>
        ''' T‰ydent‰‰ luokan alustuksen yhteydess‰ saamansa tilinumeron nollilla
        ''' 14-merkkiseen muotoon. J‰tt‰‰ v‰limerkin.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function getHumanReadableLongFormat() As String Implements IBankAccountNumber.getHumanReadableLongFormat
            Return modifyAccountNumberIntoLongFormat(True)
        End Function

        ''' <summary>
        ''' T‰ydent‰‰ luokan alustuksen yhteydess‰ saaman tilinumeron nollilla
        ''' 14-merkkiseen muotoon ilman v‰limerkki‰
        ''' </summary>
        ''' <returns>Tilinumeron pitk‰ss‰ muodossa</returns>
        Public Function getMachineReadableLongFormat() As String Implements IBankAccountNumber.getMachineReadableLongFormat
            Return modifyAccountNumberIntoLongFormat(False)
        End Function

        ''' <summary>
        ''' Muokkaa tilinumeron pitk‰‰n muotoon. 
        ''' K‰ytet‰‰n getMachineReadableLongFormat ja getHumanReadableLongFormat funktioista
        ''' </summary>
        ''' <param name="leaveSeparatorLine">M‰‰r‰‰ j‰tet‰‰nkˆ v‰liviiva. True j‰tt‰‰, false ei</param>
        ''' <returns>Palauttaa muokatun tilinumeron</returns>
        Private Function modifyAccountNumberIntoLongFormat(ByVal leaveSeparatorLine As Boolean) As String

            Dim numIn As String = m_accountNumber
            numIn = numIn.Replace(" ", "")
            numIn = numIn.Replace("-", "")

            If Len(numIn) < 8 Then
                Return numIn
            End If

            Dim numOut As String
            If numIn.Length = 14 Then
                numOut = numIn
            Else

                Dim beginPart As String = numIn.Substring(0, 6)
                Dim endPart As String = numIn.Substring(6)

                Dim isAktiaOrOPAccountNumber As Boolean = CStr(beginPart.Substring(0, 1)) = "4" Or CStr(beginPart.Substring(0, 1)) = "5"

                If isAktiaOrOPAccountNumber Then
                    numOut = beginPart
                    numOut = numOut & endPart.Substring(0, 1)

                    Dim i As Integer
                    For i = 1 To (8 - endPart.Length)
                        numOut = numOut & "0"
                    Next

                    numOut = numOut & endPart.Substring(1)
                Else
                    numOut = beginPart

                    Dim i As Integer
                    For i = 1 To (8 - endPart.Length)
                        numOut = numOut & "0"
                    Next

                    numOut = numOut & endPart
                End If
            End If

            If leaveSeparatorLine = True Then
                numOut = numOut.Substring(0, 6) & "-" & numOut.Substring(6)
            End If

            Return numOut

        End Function

        ''' <summary>
        ''' Testaa onko luokan alustuksen yhteydess‰ saatu tilinumero oikeassa muodossa
        ''' Tarkistettava numero voi olla joko pitk‰ss‰ tai lyhyess‰ muodossa
        ''' </summary>
        ''' <returns>True jos tilinumero ok, false jos ei</returns>
        Public Shared Function isAccountNumberCorrect(ByVal accountNumberToCheck As String) As Boolean

            Dim accNumber As String = accountNumberToCheck

            If Not accNumber = vbNullString Then
                accNumber = accNumber.Replace(" ", "")
                accNumber = accNumber.Replace("-", "")
            Else
                Return False
            End If

            If accNumber.Length < 8 Then
                Return False
            End If

            If IsNumeric(accNumber) Then
                If accNumber.Length <> 14 Then

                    Dim objFinnishBankAccountNumber As New FinnishBankAccountNumber(accNumber, True)
                    Try
                        accNumber = objFinnishBankAccountNumber.getMachineReadableLongFormat()
                    Catch
                        Return False
                    End Try
                End If

                Dim sum As Long
                Dim product As Long
                Dim weight As Single = 2
                Dim nextTenth As Long
                Dim ownCheckSum As Integer
                Dim checkSum As Integer = CInt(accNumber.Substring(accNumber.Length - 1))
                accNumber = accNumber.Substring(0, accNumber.Length - 1)

                Dim i As Integer
                For i = accNumber.Length To 1 Step -1
                    product = weight * CInt(accNumber.Substring(i - 1, 1))

                    If Len(product.ToString) = 2 Then
                        sum = sum + CInt(Mid(product.ToString, 1, 1))
                        sum = sum + CInt(Mid(product.ToString, 2, 1))
                    Else
                        sum = sum + product
                    End If

                    If weight = 2 Then
                        weight = 1
                    Else
                        weight = 2
                    End If
                Next

                nextTenth = sum
                Do While nextTenth Mod 10 <> 0
                    nextTenth = nextTenth + 1
                Loop
                ownCheckSum = nextTenth - sum

                If ownCheckSum = checkSum Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End Function

    End Class
End Namespace
