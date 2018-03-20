'
' Revisio $Revision$
'
' Netvisoriin lähetettävä ulkoinen maksu
'

Imports System.Xml
Imports System.Text
Imports System.IO

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorApplicationPayrollExternalPaymentRequest
        Public Function getPayrollExternalPaymentAsXML(ByVal externalPayment As NetvisorPayrollExternalPayment) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("PayrollExternalSalaryPayment")

                .WriteElementString("Description", externalPayment.Description)

                .WriteElementString("PaymentDate", Format(externalPayment.PaymentDate, "yyyy-MM-dd"))
                .WriteStartElement("ExternalPaymentSum")

                .WriteString(externalPayment.ExternalPaymentSum)

                .WriteEndElement() '/ExternalPaymentSum

                .WriteElementString("IBAN", externalPayment.IBAN)
                .WriteElementString("BIC", externalPayment.BIC)

                .WriteElementString("HETU", externalPayment.HETU)
                .WriteElementString("Realname", externalPayment.Realname)


                .WriteEndElement() '/ExternalPayment
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace
