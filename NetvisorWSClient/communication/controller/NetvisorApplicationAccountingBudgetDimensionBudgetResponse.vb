
'
'
' Laskentakohdekohtainen, tili- ja kohdelukittu budjettitaulukko
'

Imports System.Xml
Imports System.Collections.Generic
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.controller
    Public Class NetvisorApplicationAccountingBudgetDimensionBudgetResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getDimensionBudget() As NetvisorAccountingBudgetDimensionBudget

            Dim dimensionBudget As NetvisorAccountingBudgetDimensionBudget = New NetvisorAccountingBudgetDimensionBudget()

            Dim accountBudgetingDocument As XmlDocument = New XmlDocument()
            accountBudgetingDocument.LoadXml(MyBase.responseData)

            For Each lockedDimensionNode As XmlNode In accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetDimensionBudget/LockedDimension")

                Dim lockedDimension As NetvisorAccountingBudgetLockedDimension = New NetvisorAccountingBudgetLockedDimension()
                lockedDimension.DimensionName = lockedDimensionNode.SelectSingleNode("DimensionName").InnerText
                lockedDimension.DimensionItemName = lockedDimensionNode.SelectSingleNode("DimensionItemName").InnerText                

                dimensionBudget.addLockedDimension(lockedDimension)
            Next

            dimensionBudget.AccountGroup = CType(accountBudgetingDocument.SelectSingleNode("/Root/AccountingBudgetDimensionBudget/AccountGroup").InnerText, Int32)
            dimensionBudget.AccountNumber = CType(accountBudgetingDocument.SelectSingleNode("/Root/AccountingBudgetDimensionBudget/AccountNumber").InnerText, Int32)
            dimensionBudget.AccountName = accountBudgetingDocument.SelectSingleNode("/Root/AccountingBudgetDimensionBudget/AccountName").InnerText

            For Each dimensionNode As XmlNode In accountBudgetingDocument.SelectNodes("/Root/AccountingBudgetDimensionBudget/BudgetDimension")

                Dim dimension As NetvisorAccountingBudgetDimension = New NetvisorAccountingBudgetDimension()
                dimension.DimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText
                dimension.DimensionItemName = dimensionNode.SelectSingleNode("DimensionItemName").InnerText

                For Each monthNode As XmlNode In dimensionNode.SelectNodes("BudgetMonth")

                    Dim month As NetvisorAccountingBudgetMonth = New NetvisorAccountingBudgetMonth()
                    month.Sum = CType(Replace(monthNode.SelectSingleNode("Sum").InnerText, ".", ","), Double)
                    month.VAT = CType(monthNode.SelectSingleNode("Vat").InnerText, Double)
                    month.Month = CType(monthNode.SelectSingleNode("Month").InnerText, Int32)
                    month.Year = CType(monthNode.SelectSingleNode("Year").InnerText, Int32)

                    dimension.addMonth(month)
                Next

                dimensionBudget.addBudgetDimension(dimension)
            Next

            Return dimensionBudget
        End Function

    End Class
End Namespace
