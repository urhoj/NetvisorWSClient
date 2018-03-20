'
'
'
' Revisio $Revision$
' 
' Ilmentää Netvisoriin lähetettävän palkkajaksokirjauksen työntekijälle
' muodostaa xml-sanoman
'

Imports System.IO
Imports System.Xml
Imports System.Text
Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector
    <ComClass(NetvisorApplicationPayrollPeriodCollectorRequest.ClassId, NetvisorApplicationPayrollPeriodCollectorRequest.InterfaceId, NetvisorApplicationPayrollPeriodCollectorRequest.EventsId)> Public Class NetvisorApplicationPayrollPeriodCollectorRequest

        Public Const ClassId As String = "34201F8D-D80F-4B46-94FE-B54A1BEFD21C"
        Public Const InterfaceId As String = "29B94EFC-30A9-4039-B810-A454940F68C7"
        Public Const EventsId As String = "E1188AE8-C8A6-42A5-8287-9A191054B90D"

        Public Function getPeriodCollectorAsXML(ByVal periodCollector As NetvisorPayrollPeriodCollector) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("PayrollPeriodCollector")

                .WriteStartElement("Date")
                .WriteAttributeString("format", "ansi")
                .WriteString(Format(periodCollector.date, "yyyy-MM-dd"))
                .WriteEndElement()

                Dim employeeIdentifierType As String

                Select Case periodCollector.employeeIdentifierType
                    Case NetvisorWorkDay.employeeIdentifierTypes.number
                        employeeIdentifierType = "number"

                    Case NetvisorWorkDay.employeeIdentifierTypes.personalidentificationnumber
                        employeeIdentifierType = "personalidentificationnumber"

                    Case Else
                        Throw New ApplicationException("Invalid employee identifiertype: " & periodCollector.employeeIdentifierType)

                End Select

                .WriteStartElement("EmployeeIdentifier")
                .WriteAttributeString("type", employeeIdentifierType)
                .WriteString(periodCollector.employeeIdentifier)
                .WriteEndElement()

                For Each ratioLine As NetvisorPayrollRatioLine In periodCollector.ratioLines
                    .WriteStartElement("PayrollRatioLine")

                    .WriteElementString("Amount", ratioLine.Amount)

                    .WriteStartElement("PayrollRatio")
                    .WriteAttributeString("type", "number")
                    .WriteString(ratioLine.PayrollRatioNumber)
                    .WriteEndElement()

                    For Each dimension As NetvisorDimension In ratioLine.dimensions
                        .WriteStartElement("Dimension")
                        .WriteElementString("DimensionName", dimension.dimensionName)
                        .WriteStartElement("DimensionItem")

                        If dimension.dimensionDetailFatherID > 0 Then
                            .WriteAttributeString("fatherid", dimension.dimensionDetailFatherID)
                        End If

                        .WriteString(dimension.dimensionDetail)
                        .WriteEndElement() '/ DimensionItem
                        .WriteEndElement() '/ Dimension
                    Next

                    .WriteEndElement() '/PayrollRatioLine
                Next

                .WriteEndElement() '/PayrollPeriodCollector
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace