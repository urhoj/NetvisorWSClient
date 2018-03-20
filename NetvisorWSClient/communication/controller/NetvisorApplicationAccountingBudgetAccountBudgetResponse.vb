'
'
' Tilikohtainen ja laskentakohdelukittu budjettitaulukko
'

Imports System.Xml
Imports System.Collections.Generic
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.controller
    Public Class NetvisorApplicationAccountingBudgetAccountBudgetResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getAccountBudget() As NetvisorAccountingBudgetAccountBudget

            Dim accountBudget As NetvisorAccountingBudgetAccountBudget = New NetvisorAccountingBudgetAccountBudget()

            Dim accountBudgetingDocument As XmlDocument = New XmlDocument()
            accountBudgetingDocument.LoadXml(MyBase.responseData)

            For Each lockedDimensionNode As XmlNode In accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetAccountBudget/LockedDimension")

                Dim lockedDimension As NetvisorAccountingBudgetLockedDimension = New NetvisorAccountingBudgetLockedDimension()
                lockedDimension.DimensionName = lockedDimensionNode.SelectSingleNode("DimensionName").InnerText
                lockedDimension.DimensionItemName = lockedDimensionNode.SelectSingleNode("DimensionItemName").InnerText                

                accountBudget.addLockedDimension(lockedDimension)
            Next

            For Each accountNode As XmlNode In accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetAccountBudget/BudgetAccount")

                Dim account As NetvisorAccountingBudgetAccount = New NetvisorAccountingBudgetAccount()
                account.AccountNumber = CType(accountNode.SelectSingleNode("AccountNumber").InnerText, Int32)
                account.AccountName = accountNode.SelectSingleNode("AccountName").InnerText
                account.AccountGroup = CType(accountNode.SelectSingleNode("AccountGroup").InnerText, Int32)

                For Each monthNode As XmlNode In accountNode.SelectNodes("BudgetMonth")

                    Dim month As NetvisorAccountingBudgetMonth = New NetvisorAccountingBudgetMonth()
                    month.Sum = CType(Replace(monthNode.SelectSingleNode("Sum").InnerText, ".", ","), Double)
                    month.VAT = CType(monthNode.SelectSingleNode("Vat").InnerText, Double)
                    month.Month = CType(monthNode.SelectSingleNode("Month").InnerText, Int32)
                    month.Year = CType(monthNode.SelectSingleNode("Year").InnerText, Int32)

                    account.addMonth(month)
                Next

                accountBudget.addBudgetAccount(account)
            Next

            Return accountBudget
        End Function

    End Class
End Namespace
