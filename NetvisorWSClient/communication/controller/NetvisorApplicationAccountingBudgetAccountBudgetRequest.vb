'
' Revisio $Revision$
'
' Xml sanoma tilibudjetin siirtämiseksi netvisoriin
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorApplicationAccountingBudgetAccountBudgetRequest.ClassId, NetvisorApplicationAccountingBudgetAccountBudgetRequest.InterfaceId, _
        NetvisorApplicationAccountingBudgetAccountBudgetRequest.EventsId)> _
    Public Class NetvisorApplicationAccountingBudgetAccountBudgetRequest

        Public Const ClassId As String = "A27381EF-0B5D-40e4-B547-32B060A48AB6"
        Public Const InterfaceId As String = "4B4B9C7B-3A37-4cd0-B934-312F65139B41"
        Public Const EventsId As String = "2F224C86-C41F-4604-82B4-1007E62412C6"

        Public Function getAccountingBudgetAsXML(ByVal accountBudget As NetvisorAccountingBudgetAccountBudget) As String
            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("AccountingBudgetAccountBudget")
                .WriteElementString("method", accountBudget.Method)

                For Each lockedDimension As NetvisorAccountingBudgetLockedDimension In accountBudget.LockedDimensionList

                    .WriteStartElement("LockedDimension")
                    .WriteElementString("DimensionName", lockedDimension.DimensionName)
                    .WriteElementString("DimensionItemName", lockedDimension.DimensionItemName)
                    .WriteEndElement()
                Next

                For Each account As NetvisorAccountingBudgetAccount In accountBudget.BudgetAccountList

                    .WriteStartElement("BudgetAccount")

                    .WriteStartElement("AccountIdentifier")
                    .WriteElementString("AccountNumber", account.AccountNumber)
                    .WriteElementString("AccountName", account.AccountName)
                    .WriteElementString("AccountGroup", account.AccountGroup)
                    .WriteEndElement()

                    For Each month As NetvisorAccountingBudgetMonth In account.MonthList

                        .WriteStartElement("BudgetMonth")

                        .WriteElementString("Sum", month.Sum)
                        .WriteElementString("VAT", month.VAT)
                        .WriteElementString("Month", month.Month)
                        .WriteElementString("Year", month.Year)

                        .WriteEndElement() '/BudgetMonth
                    Next

                    .WriteEndElement() ' /BudgetAccount
                Next

                .WriteEndElement() '/AccountingBudgetAccountBudget
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace