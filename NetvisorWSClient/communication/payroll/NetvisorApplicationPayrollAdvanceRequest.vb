'
' Revisio $Revision$
'
' Netvisoriin lähetettävä matka-/palkkaennakkosanoma
'

Imports System.Xml
Imports System.Text
Imports System.IO

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorApplicationPayrollAdvanceRequest
        Public Function getPayrollAdvanceAsXML(ByVal advance As NetvisorPayrollAdvance) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("PayrollAdvance")

                .WriteElementString("Description", advance.Description)
                .WriteStartElement("EmployeeIdentifier")

                If FinnishPersonalIdentificationNumber.isPersonalIdCorrect(advance.EmployeeIdentifier) Then
                    .WriteAttributeString("type", "finnishpersonalidentifier")
                Else
                    .WriteAttributeString("type", "number")
                End If

                .WriteString(advance.EmployeeIdentifier)

                .WriteEndElement() '/EmployeeIdentifier

                .WriteElementString("PaymentDate", Format(advance.PaymentDate, "yyyy-MM-dd"))
                .WriteStartElement("AdvanceSum")

                If advance.AdvancePaymentStatusType = NetvisorPayrollAdvance.advancePaymentTypes.ispaid Then
                    .WriteAttributeString("paymentstatus", "ispaid")
                Else
                    .WriteAttributeString("paymentstatus", "notpaid")
                End If

                .WriteString(advance.AdvanceSum)

                .WriteEndElement() '/AdvanceSum

                If advance.AdvanceType = NetvisorPayrollAdvance.advanceTypes.payroll Then
                    .WriteElementString("PaymentType", "payroll")
                Else
                    .WriteElementString("PaymentType", "tripexpence")
                End If


                .WriteEndElement() '/PayrollAdvance
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace
