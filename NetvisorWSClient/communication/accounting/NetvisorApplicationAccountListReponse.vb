'
' Revisio $Revision$
'
' Netvisorin antaman kirjanpitoaineiston hakupyynnön vastaus
'

Imports System.Xml
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.accounting

    Public Class NetvisorApplicationAccountListReponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getNetvisorAccountList() As NetvisorAccountList

            Dim accountList As New NetvisorAccountList

            Dim accountListDocument As New XmlDocument()
            accountListDocument.LoadXml(MyBase.responseData)

            Dim defaultAccounts As New Hashtable
            Dim accounts As New List(Of NetvisorAccount)

            For Each companyDefaultAccountNode As XmlNode In accountListDocument.SelectNodes("/Root/AccountList/CompanyDefaultAccounts")

                For Each child As XmlNode In companyDefaultAccountNode.ChildNodes
                    defaultAccounts.Add(child.Name, child.InnerText)
                Next

            Next

            For Each accountNode As XmlNode In accountListDocument.SelectNodes("/Root/AccountList/Accounts/Account")

                Dim account As New NetvisorAccount

                With account
                    .NetvisorKey = CType(accountNode.SelectSingleNode("NetvisorKey").InnerText, String)
                    .Number = CType(accountNode.SelectSingleNode("Number").InnerText, String)
                    .Name = CType(accountNode.SelectSingleNode("Name").InnerText, String)
                    .AccountType = CType(accountNode.SelectSingleNode("AccountType").InnerText, String)
                    .FatherNetvisorKey = CType(accountNode.SelectSingleNode("FatherNetvisorKey").InnerText, Integer)

                    If Len(accountNode.SelectSingleNode("IsActive").InnerText) > 0 Then
                        .IsActive = CType(accountNode.SelectSingleNode("IsActive").InnerText, Integer) = 1
                    End If

                    If Len(accountNode.SelectSingleNode("IsCumulative").InnerText) > 0 Then
                        .IsCumulative = CType(accountNode.SelectSingleNode("IsCumulative").InnerText, Integer) = 1
                    End If

                    If Len(accountNode.SelectSingleNode("Sort").InnerText) > 0 Then
                        .Sort = CType(accountNode.SelectSingleNode("Sort").InnerText, Integer) = 1
                    End If

                    If Len(accountNode.SelectSingleNode("EndSort").InnerText) > 0 Then
                        .EndSort = CType(accountNode.SelectSingleNode("EndSort").InnerText, Integer) = 1
                    End If

                    If Len(accountNode.SelectSingleNode("IsNaturalNegative").InnerText) > 0 Then
                        .IsNaturalNegative = CType(accountNode.SelectSingleNode("IsNaturalNegative").InnerText, Integer) = 1
                    End If

                End With

                accounts.Add(account)

            Next

            accountList.accountList = accounts
            accountList.companyDefaultAccounts = defaultAccounts

            Return accountList

        End Function
    End Class

End Namespace