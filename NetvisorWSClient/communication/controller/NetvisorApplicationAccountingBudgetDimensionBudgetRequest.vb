'
' Revisio $Revision$
'
' Xml sanoma laskentakohdebudjetin siirtämiseksi netvisoriin
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorApplicationAccountingBudgetDimensionBudgetRequest.ClassId, NetvisorApplicationAccountingBudgetDimensionBudgetRequest.InterfaceId, _
       NetvisorApplicationAccountingBudgetDimensionBudgetRequest.EventsId)> _
    Public Class NetvisorApplicationAccountingBudgetDimensionBudgetRequest

        Public Const ClassId As String = "5FBD4975-E3A0-4a0f-B41B-7879DFD6AEF3"
        Public Const InterfaceId As String = "6C285671-DC21-46ae-8617-0AD078DE7E07"
        Public Const EventsId As String = "9D7A5F87-5F6A-499e-A499-71D0CB96B58A"

        Public Function getAccountingBudgetAsXML(ByVal dimensionBudget As NetvisorAccountingBudgetDimensionBudget) As String
            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("AccountingBudgetDimensionBudget")
                .WriteElementString("method", dimensionBudget.Method)

                For Each lockedDimension As NetvisorAccountingBudgetLockedDimension In dimensionBudget.LockedDimensionList

                    .WriteStartElement("LockedDimension")
                    .WriteElementString("DimensionName", lockedDimension.DimensionName)
                    .WriteElementString("DimensionItemName", lockedDimension.DimensionItemName)
                    .WriteEndElement()
                Next

                .WriteStartElement("AccountIdentifier")
                .WriteElementString("AccountNumber", dimensionBudget.AccountNumber)
                .WriteElementString("AccountName", dimensionBudget.AccountName)
                .WriteElementString("AccountGroup", dimensionBudget.AccountGroup)
                .WriteEndElement()

                For Each dimension As NetvisorAccountingBudgetDimension In dimensionBudget.BudgetDimensionList

                    .WriteStartElement("BudgetDimension")

                    .WriteElementString("DimensionName", dimension.DimensionName)
                    .WriteElementString("DimensionItemName", dimension.DimensionItemName)

                    For Each month As NetvisorAccountingBudgetMonth In dimension.MonthList

                        .WriteStartElement("BudgetMonth")

                        .WriteElementString("Sum", month.Sum)
                        .WriteElementString("VAT", month.VAT)
                        .WriteElementString("Month", month.Month)
                        .WriteElementString("Year", month.Year)

                        .WriteEndElement() '/BudgetMonth
                    Next

                    .WriteEndElement() ' /BudgetDimension
                Next

                .WriteEndElement() '/AccountingBudgetDimensionBudget
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace