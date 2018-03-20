'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin lähetettävän budjettipyynnön
'

Imports System.Xml
Imports System.Text
Imports System.IO

Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorApplicationAccountingBudgetRequest.ClassId, NetvisorApplicationAccountingBudgetRequest.InterfaceId, _
      NetvisorApplicationAccountingBudgetRequest.EventsId)> _
    Public Class NetvisorApplicationAccountingBudgetRequest

        Public Const ClassId As String = "44EC4D56-F050-4d21-AD24-C2470EF01FA7"
        Public Const InterfaceId As String = "08BDB619-5B5B-4eab-BF86-3B7F487AF05F"
        Public Const EventsId As String = "08DA49A9-0EF9-42c8-9569-7392759B8D3E"

        Public Function getAccountingBudgetAsXML(ByVal budget As NetvisorAccountingBudget) As String
            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("AccountingBudget")

                Dim ratioType As String

                Select Case budget.ratioType
                    Case NetvisorAccountingBudget.ratioTypes.accountNumber
                        ratioType = "account"

                    Case Else
                        Throw New ApplicationException("Invalid ratiotype: " & budget.ratioType)

                End Select

                .WriteStartElement("Ratio")
                .WriteAttributeString("type", ratioType)
                .WriteString(budget.ratio)
                .WriteEndElement()

                .WriteElementString("Sum", budget.sum)
                .WriteElementString("Year", budget.year)
                .WriteElementString("Month", budget.month)
                .WriteElementString("Version", budget.budgetVersion)
                .WriteElementString("VatClass", budget.vatClass)

                .WriteStartElement("Combinations")

                For Each combination As NetvisorAccountingBudgetCombination In budget.combinations
                    .WriteStartElement("Combination")

                    .WriteElementString("CombinationSum", combination.combinationSum)

                    For Each dimension As NetvisorDimension In combination.dimensions
                        dimension.writeDimensionElement(xmlWriter)
                    Next

                    .WriteEndElement() '/Combination
                Next

                .WriteEndElement() '/Combinations

                .WriteEndElement() '/AccountingBudget
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace