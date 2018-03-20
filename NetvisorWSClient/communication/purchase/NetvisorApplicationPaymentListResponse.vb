'
' Revisio $Revision$
'
' Netvisorin antaman ostolaskulistan vastaus
'

Imports System.Xml

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPaymentListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPaymentList() As List(Of NetvisorPaymentListPayment)

            Dim paymentList As New List(Of NetvisorPaymentListPayment)
            Dim paymentListDocument As New XmlDocument()

            paymentListDocument.LoadXml(MyBase.responseData)

            For Each paymentNode As XmlNode In paymentListDocument.SelectNodes("/Root/PaymentList/Payment")

                Dim paymentListPayment As New NetvisorPaymentListPayment

                With paymentListPayment

                    .NetvisorKey = paymentNode.SelectSingleNode("NetvisorKey").InnerText
                    .PayerName = paymentNode.SelectSingleNode("PayerName").InnerText
                    .Date = paymentNode.SelectSingleNode("Date").InnerText
                    .HomeCurrencySum = paymentNode.SelectSingleNode("HomeCurrencySum").InnerText

                    If Not String.IsNullOrEmpty(paymentNode.SelectSingleNode("ForeignCurrencySum").InnerText) Then
                        .ForeignCurrencySum = paymentNode.SelectSingleNode("ForeignCurrencySum").InnerText
                    End If

                    .Reference = paymentNode.SelectSingleNode("Reference").InnerText
                    .InvoiceKey = paymentNode.SelectSingleNode("InvoiceKey").InnerText
                    .InvoiceNumber = paymentNode.SelectSingleNode("InvoiceNumber").InnerText

                    If Not String.IsNullOrEmpty(paymentNode.SelectSingleNode("InvoiceUri").InnerText) Then
                        .invoiceURI = paymentNode.SelectSingleNode("InvoiceUri").InnerText
                    End If

                    If Not String.IsNullOrEmpty(paymentNode.SelectSingleNode("VoucherKey").InnerText) Then
                        .VoucherKey = paymentNode.SelectSingleNode("VoucherKey").InnerText
                    End If

                    If Not String.IsNullOrEmpty(paymentNode.SelectSingleNode("VoucherNumber").InnerText) Then
                        .VoucherNumber = paymentNode.SelectSingleNode("VoucherNumber").InnerText
                    End If

                End With

                paymentList.Add(paymentListPayment)
            Next

            Return paymentList
        End Function
    End Class
End Namespace