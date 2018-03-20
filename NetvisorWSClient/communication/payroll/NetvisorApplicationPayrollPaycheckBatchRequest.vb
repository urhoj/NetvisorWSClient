'
'
'
' Revisio $Revision$
' 
' Ilmentää Netvisoriin lähetettävän palkkalaskelmapyynnön
' muodostaa xml-sanoman
'

Imports System.IO
Imports System.Xml
Imports System.Text
Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorApplicationPayrollPaycheckBatchRequest

        Public Function getPaycheckBatchAsXML(ByVal batch As NetvisorPayrollPaycheckBatch) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("PayrollPaycheckBatch")

                Dim employeeIdentifierType As String
                Dim employeeIdentifier As String
                Select Case batch.employeeIdentifierType
                    Case NetvisorPayrollPaycheckBatch.employeeIdentifierTypes.employeeNumber
                        employeeIdentifierType = NetvisorPayrollPaycheckBatch.IDENTIFIER_EMPLOYEE_NUMBER
                        employeeIdentifier = CType(batch.employeeIdentifier, Integer)

                    Case NetvisorPayrollPaycheckBatch.employeeIdentifierTypes.finnishPersonalIdentifier
                        employeeIdentifierType = NetvisorPayrollPaycheckBatch.IDENTIFIER_FINNISH_PERSONAL_IDENTIFIER
                        employeeIdentifier = CType(batch.employeeIdentifier, FinnishPersonalIdentificationNumber).getHumanReadableLongFormat()

                    Case Else
                        Throw New ApplicationException("Invalid employee identifiertype: " & batch.employeeIdentifierType)
                End Select

                .WriteStartElement("EmployeeIdentifier")
                .WriteAttributeString("type", employeeIdentifierType)
                .WriteString(employeeIdentifier)
                .WriteEndElement() '/EmployeeIdentifier

                .WriteStartElement("RuleGroupPeriodStart")
                .WriteAttributeString("format", "ansi")
                .WriteString(Format(batch.ruleGroupPeriodStart, "yyyy-MM-dd"))
                .WriteEndElement() '/RuleGroupPeriodStart

                .WriteStartElement("RuleGroupPeriodEnd")
                .WriteAttributeString("format", "ansi")
                .WriteString(Format(batch.ruleGroupPeriodEnd, "yyyy-MM-dd"))
                .WriteEndElement() '/RuleGroupPeriodEnd

                .WriteElementString("FreeTextBeforeLines", batch.freeTextBeforeLines)
                .WriteElementString("FreeTextAfterLines", batch.freeTextAfterLines)

                If batch.dueDate > Date.MinValue Then
                    .WriteStartElement("DueDate")
                    .WriteAttributeString("format", "ansi")
                    .WriteString(Format(batch.dueDate, "yyyy-MM-dd"))
                    .WriteEndElement() '/RuleGroupPeriodStart
                End If

                If batch.valueDate > Date.MinValue Then
                    .WriteStartElement("ValueDate")
                    .WriteAttributeString("format", "ansi")
                    .WriteString(Format(batch.valueDate, "yyyy-MM-dd"))
                    .WriteEndElement() '/RuleGroupPeriodStart
                End If

                For Each line As NetvisorPayrollPaycheckBatchLine In batch.batchLines
                    .WriteStartElement("PayrollPaycheckBatchLine")

                    Dim ratioIdentifierType As String
                    Select Case line.payrollRatioIdentifierType
                        Case NetvisorPayrollPaycheckBatchLine.payrollRatioIdentifierTypes.rationumber
                            ratioIdentifierType = NetvisorPayrollPaycheckBatchLine.RATIO_IDENTIFIER_RATIO_NUMBER
                        Case Else
                            Throw New ApplicationException("Invalid payroll ratio identifier type: " & line.payrollRatioIdentifierType)
                    End Select

                    .WriteStartElement("PayrollRatioIdentifier")
                    .WriteAttributeString("type", ratioIdentifierType)
                    .WriteString(line.payrollRatioIdentifier)
                    .WriteEndElement() '/RuleGroupPeriodEnd

                    .WriteElementString("Units", line.units)
                    .WriteElementString("UnitAmount", line.unitAmount)
                    .WriteElementString("LineSum", line.lineSum)
                    .WriteElementString("LineDescription", line.description)

                    If line.batchLineDimensions.Count > 0 Then
                        For Each dimension As NetvisorDimension In line.batchLineDimensions
                            .WriteStartElement("Dimension")
                            .WriteElementString("DimensionName", dimension.dimensionName)
                            .WriteElementString("DimensionItem", dimension.dimensionDetail)
                            .WriteEndElement() '/Dimension
                        Next
                    End If


                    .WriteEndElement() '/ PayrollPaycheckBatchLine
                Next

                .WriteEndElement() '/ PayrollPaycheckBatch
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace