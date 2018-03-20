'
'
'
' Revisio $Revision$
' 
' Suomalainen y-tunnus
'
' www.ytj.fi

Namespace NetvisorWSClient.util
    <ComClass(FinnishOrganisationIdentifier.ClassId, FinnishOrganisationIdentifier.InterfaceId, FinnishOrganisationIdentifier.EventsId)> Public Class FinnishOrganisationIdentifier

        Public Const ClassId As String = "98349785-8BE2-4604-848D-F5B103D61722"
        Public Const InterfaceId As String = "36613EE9-125F-493d-9968-771E18C22222"
        Public Const EventsId As String = "A036F02F-F87E-4548-A536-7DD7EA8E6222"

        Private m_identifier As String

        Public Sub New()
        End Sub

        Public Property Identifier() As String
            Get
                Return m_identifier
            End Get
            Set(ByVal value As String)
                m_identifier = value
            End Set
        End Property

        Public Sub New(ByVal identifier As String)

            If FinnishOrganisationIdentifier.isOrganisationIdentifierCorrect(identifier) = True Then
                m_identifier = identifier
            Else
                Throw New Exception("Y-tunnus ei ole oikeassa muodossa")
            End If

        End Sub

        Public Function getHumanReadableFormat() As String

            Dim machineReadableIdentifier As String = m_identifier.Replace("-", "").Replace(" ", "")
            Dim humanReadableIdentifier As String = FixedLengthFieldFormatter.FormatInteger(Left(machineReadableIdentifier, machineReadableIdentifier.Length - 1), 7) & "-" & Right(machineReadableIdentifier, 1)

            Return humanReadableIdentifier
        End Function

        Public Function getMachineReadableFormat() As String

            Dim machineReadableIdentifier As String = ""

            machineReadableIdentifier = m_identifier.Replace("-", "").Replace(" ", "")
            machineReadableIdentifier = FixedLengthFieldFormatter.FormatInteger(Left(machineReadableIdentifier, machineReadableIdentifier.Length - 1), 7) & Right(machineReadableIdentifier, 1)

            Return machineReadableIdentifier
        End Function

        ''' <summary>
        ''' Tarkistaa onko suomalainen ytunnus oikein
        ''' 1. Tunnuksen numeroita (7 kpl, tarvittaessa lisätään alkuun nolla; numeroita oli aikaisemmin kuusi, 
        ''' ja tätä vanhaa muotoa voi hyvin harvoin nähdä vieläkin) painotetaan vasemmalta lähtien kertoimilla 7, 9, 10, 5, 8, 4 ja 2. 
        ''' 2. Tulot lasketaan yhteen. 
        ''' 3. Summa jaetaan 11:llä. 
        ''' 4. Jos jakojäännös on 0, tarkistusnumero on 0.
        ''' 5. Ei anneta tunnuksia, jotka tuottaisivat jakojäännöksen 1.
        ''' 6. Jos jakojäännös on 2..10, tarkistusnumero on 11 miinus jakojäännös.
        ''' </summary>
        Public Shared Function isOrganisationIdentifierCorrect(ByVal identifier As String) As Boolean

            Dim ret As Boolean = False

            If identifier.Length > 0 Then
                If identifier.Contains("-") Then
                    identifier = identifier.Replace("-", "")
                End If

                identifier = identifier.Replace(" ", "")

                If identifier.Length = 8 Then
                    Dim businessID As String = Left(identifier, identifier.Length - 1)

                    If IsNumeric(businessID) Then

                        ' tunnuksen vasemman puolen, osan ennen viivaa, on oltava seitsämän merkkiä. 
                        ' jos ei ole lisätään etunollia tarpeeksi
                        businessID = FixedLengthFieldFormatter.FormatInteger(businessID, 7)

                        Dim multiplier() As Integer = {7, 9, 10, 5, 8, 4, 2}
                        Dim product(6) As Integer

                        Dim i As Integer = 0
                        Do
                            product(i) = multiplier(i) * CInt(Mid(businessID, i + 1, 1))
                            i += 1
                        Loop Until i = businessID.Length

                        Dim sum As Integer
                        Dim check As Integer

                        ' lasketaan tulot yhteen
                        For Each i In product
                            sum = sum + i
                        Next

                        check = sum Mod 11

                        If check >= 2 And check <= 10 Then
                            check = 11 - check
                        End If

                        ' tarkastetaan onko tarkistussumma sama
                        If CStr(check) = Right(identifier, 1) Then
                            ret = True
                        End If
                    End If
                End If
            End If

            Return ret

        End Function

    End Class
End Namespace
