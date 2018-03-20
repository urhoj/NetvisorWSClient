'
'
' Lukee Netvisorin antaman laskentakohdelista-pyynnön vastauksen ja palauttaa
' laskentakohteet arraylistissä
'

Imports System.Xml
Imports System.Collections.Generic
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorApplicationAccountListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getAccountList() As ArrayList

            Dim accounts As List(Of NetvisorAccountListAccount) = New List(Of NetvisorAccountListAccount)()

            Dim accountListDocument As XmlDocument = New XmlDocument()
            accountListDocument.LoadXml(MyBase.responseData)

            For Each accountNode As XmlNode In accountListDocument.SelectNodes("/Root/AccountList/Account")

                Dim account As NetvisorAccountListAccount = New NetvisorAccountListAccount()
                account.NetvisorKey = CType(accountNode.SelectSingleNode("NetvisorKey").InnerText, Integer)
                account.Name = accountNode.SelectSingleNode("Name").InnerText
                account.Number = CType(accountNode.SelectSingleNode("Number").InnerText, Integer)
                account.Group = CType(accountNode.SelectSingleNode("Group").InnerText, Integer)
                account.Rank = CType(accountNode.SelectSingleNode("Rank").InnerText, Integer)

                accounts.Add(account)
            Next

            Return ArrayList.Adapter(accounts)
        End Function

    End Class
End Namespace
