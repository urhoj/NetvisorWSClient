'
'
'
' Revisio $Revision$
'
' Netvisoriin menemvä myyntisuorituspyyntö
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationSalesPaymentRequest

        Public Function getSalesPaymentAsXML(ByVal payment As NetvisorSalesPayment) As String

            Dim memoryStream As New IO.MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("SalesPayment")

                .WriteStartElement("Sum")
                .WriteAttributeString("currency", payment.currency)
                .WriteString(payment.sum)
                .WriteEndElement() '/Sum

                .WriteElementString("PaymentDate", Format(payment.paymentDate, "yyyy-MM-dd"))

                Dim targetIdentifierType As String
                Select Case payment.targetIdentifierType
                    Case NetvisorSalesPayment.targetIdentifierTypes.invoiceId
                        targetIdentifierType = "netvisor"

                    Case NetvisorSalesPayment.targetIdentifierTypes.invoiceNumber
                        targetIdentifierType = "invoicenumber"

                    Case NetvisorSalesPayment.targetIdentifierTypes.invoiceReferenceNumber
                        targetIdentifierType = "reference"

                    Case Else
                        Throw New ApplicationException("Invalid salespayment targetidentifiertype: " & payment.targetIdentifierType)
                End Select

                Dim targetType As String = ""
                Select Case payment.targetType
                    Case NetvisorSalesPayment.targetTypes.order
                        targetType = "order"

                    Case Else
                        targetType = "invoice"

                End Select

                .WriteStartElement("TargetIdentifier")
                .WriteAttributeString("type", targetIdentifierType)
                .WriteAttributeString("targettype", targetType)
                .WriteString(payment.targetIdentifier)
                .WriteEndElement() '/TargetIdentifier

                .WriteElementString("SourceName", payment.sourceName)

                Dim paymentMethodType As String
                Select Case payment.paymentMethodType
                    Case NetvisorSalesPayment.paymentMethodTypes.alternative
                        paymentMethodType = "alternative"

                    Case NetvisorSalesPayment.paymentMethodTypes.bankaccount
                        paymentMethodType = "bankaccount"

                    Case Else
                        Throw New ApplicationException("Unknow paymentMethodType: " & payment.paymentMethodType)
                End Select

                .WriteStartElement("PaymentMethod")
                .WriteAttributeString("type", paymentMethodType)

                If payment.doOverrideAccountingAccountNumber Then
                    .WriteAttributeString("overrideaccountingaccountnumber", payment.overrideAccountingAccountNumber)
                End If

                If payment.doOverrideSalesRecivablesAccountNumber Then
                    .WriteAttributeString("overridesalesreceivableaccountnumber", payment.overrideSalesReceivablesAccountNumber)
                End If

                .WriteString(payment.paymentMethod)
                .WriteEndElement() '/PaymentMethod

                .WriteEndElement() '/SalesPayment
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace