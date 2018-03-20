'
'
'
' Revisio $Revision$
'
' Netvisoriin menevä tilisiirtopyyntö
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.common
    Public Class NetvisorApplicationOutgoingPaymentRequest

        Public Function getOutgoingPaymentAsXML(ByVal payment As NetvisorOutgoingPayment) As String

            Dim memoryStream As New IO.MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("Payment")

                .WriteStartElement("BankPaymentMessageType")
                Select Case payment.BankPaymentMessageType
                    Case NetvisorOutgoingPayment.BankPaymentMessageTypes.FINNISH_REFERENCE
                        .WriteString("FinnishReference")
                    Case NetvisorOutgoingPayment.BankPaymentMessageTypes.FREETEXT
                        .WriteString("FreeText")
                    Case Else
                        Throw New ApplicationException("Invalid outgoing payment BankPaymentMessageType: " & payment.BankPaymentMessageType)
                End Select
                .WriteEndElement() '/BankPaymentMessageType

                .WriteStartElement("BankPaymentMessage")
                .WriteString(payment.BankPaymentMessage)
                .WriteEndElement() '/BankPaymentMessage

                .WriteStartElement("Recipient")

                .WriteStartElement("OrganizationCode")
                .WriteString(payment.RecipientOrganizationCode.getHumanReadableFormat)
                .WriteEndElement() '/OrganizationCode

                .WriteStartElement("Name")
                .WriteString(payment.RecipientName)
                .WriteEndElement() '/Name

                .WriteEndElement() '/Recipient

                .WriteStartElement("SourceBankAccountNumber")
                .WriteString(payment.SourceBankAccountNumber.getHumanReadableLongFormat)
                .WriteEndElement() '/SourceBankAccountNumber

                .WriteStartElement("DestinationBankAccount")

                .WriteStartElement("BankName")
                .WriteString(payment.DestinationBankName)
                .WriteEndElement() '/BankName

                .WriteStartElement("BankBranch")
                .WriteString(payment.DestinationBankBranch)
                .WriteEndElement() '/BankBranch 

                .WriteStartElement("DestinationBankAccountNumber")
                .WriteString(payment.DestinationBankAccountNumber.getHumanReadableLongFormat)
                .WriteEndElement() '/DestinationBankAccountNumber

                .WriteEndElement() '/DestinationBankAccount

                .WriteElementString("DueDate", Format(payment.DueDate, "yyyy-MM-dd"))

                .WriteStartElement("Amount")
                .WriteString(payment.Amount)
                .WriteEndElement() '/Amount

                .WriteEndElement() '/Payment
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace