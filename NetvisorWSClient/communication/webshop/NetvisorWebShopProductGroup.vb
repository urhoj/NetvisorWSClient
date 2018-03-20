'
'
' Ilmentää Netvisorin verkkokauppatuotteen tuoteryhmän
'

Imports System.Xml
Imports NetvisorWSClient.util
Imports System.Collections.Specialized

Namespace NetvisorWSClient.communication.webshop

    Public Class NetvisorWebShopProductGroup

        Private m_Names As New NameValueCollection

        Public Sub addNameWithCountryCode(ByVal countryCode As String, ByVal name As String)
            m_Names.Add(countryCode, name)
        End Sub

        Public ReadOnly Property Names() As NameValueCollection
            Get
                Return m_Names
            End Get
        End Property

    End Class

End Namespace