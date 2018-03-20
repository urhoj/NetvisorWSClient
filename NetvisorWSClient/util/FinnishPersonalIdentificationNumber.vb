'
'
'
' Revisio $Revision$
'
' Ilmentää suomalaisen henkilötunnuksen, jolla voidaan suomen kansalainen yksilöidä
'
' http://vrk.fi/henkilotunnus
' 
' Suomalainen henkilötunnus on muotoa DDMMYY-999X
' Jossa: DDMMYY             = syntymäaika
'        Välimerkki (-+A)   = tieto vuosisadasta jolloin syntynyt, + 1800, - 1900, A 2000
'        999                = yksilönumero, erottaa samana päivänä syntyneet. Naisilla parillinen, miehillä pariton
'        X                  = tarkastemerkki

Option Explicit On

Namespace NetvisorWSClient.util
    Public Class FinnishPersonalIdentificationNumber

        Private m_PersonalID As String

        Public Sub New(ByVal personalID As String)
            If Not FinnishPersonalIdentificationNumber.isPersonalIdCorrect(personalID) Then
                Throw New ApplicationException("Henkilötunnus ei ole oikeassa muodossa")
            End If

            m_PersonalID = personalID.ToUpper
        End Sub

        Public Function getHumanReadableLongFormat() As String

            If m_PersonalID.Contains("-") _
                    Or m_PersonalID.Contains("+") _
                    Or m_PersonalID.Substring(0, m_PersonalID.Length - 1).Contains("A") Then

                Return m_PersonalID
            Else
                Return m_PersonalID.Substring(0, 6) & "-" & m_PersonalID.Substring(6, 4)
            End If
        End Function

        Public Function getMachineReadableLongFormat() As String

            If m_PersonalID.Contains("-") _
                    Or m_PersonalID.Contains("+") _
                    Or m_PersonalID.Substring(0, m_PersonalID.Length - 1).Contains("A") Then

                Return m_PersonalID.Substring(0, 6) & m_PersonalID.Substring(7, 4)

            Else
                Return m_PersonalID
            End If
        End Function

        ''' <summary>
        ''' Tarkastaa onko henkilötunnus oikeanlainen
        ''' </summary>
        ''' <returns>True jos oikein, false jos väärin</returns>
        Public Shared Function isPersonalIdCorrect(ByVal personalID As String) As Boolean

            Dim chars As String = "0123456789ABCDEFHJKLMNPRSTUVWXY"

            Dim ownCheckSum As String
            Dim checkSum As String

            If Len(personalID) <> 11 Then
                Return False
            End If

            personalID = personalID.ToUpper

            ' Lasketaan tarkisteen järjestysnumero syntymäajasta ja henkilötunnuksen henkilönumerosta
            ownCheckSum = Val(Left(personalID, 6) + Mid(personalID, 8, 3)) Mod 31 + 1

            ' Otetaan omaksi tarkistenumeroksi merkki chars merkkijonosta järjestysnumeron mukaan
            ownCheckSum = Mid(chars, ownCheckSum, 1)
            checkSum = Right(personalID, 1)

            If ownCheckSum = checkSum Then
                Return True
            Else
                Return False
            End If

        End Function
    End Class
End Namespace
