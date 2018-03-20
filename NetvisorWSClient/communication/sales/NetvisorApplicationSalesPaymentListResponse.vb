'
'
'
' Revisio $Revision$
'
' Lukee ja parsii Netvisorin antaman suorituslista-pyynnön vastauksen ja antaa 
' suoritukset tyypitettynä arraylistissä
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationSalesPaymentListResponse
        Inherits NetvisorApplicationResponse

        Private Const BANK_STATUS_ERROR_NO_ACCOUNT_FOUND As String = "NO_ACCOUNT_FOUND"
        Private Const BANK_STATUS_ERROR_NO_PAYMENT_SERVICE_ACCOUNT As String = "NO_PAYMENT_SERVICE_ACCOUNT"
        Private Const BANK_STATUS_ERROR_IN_DUE_DATE As String = "ERROR_IN_DUE_DATE"
        Private Const BANK_STATUS_ERROR_BALANCE_IS_EXCEEDED As String = "BALANCE_IS_EXCEEDED"
        Private Const BANK_STATUS_ERROR_PAYER_HAS_CANCELLED As String = "PAYER_HAS_CANCELLED"
        Private Const BANK_STATUS_ERROR_FORM_NOT_CORRECT As String = "FORM_NOT_CORRECT"
        Private Const BANK_STATUS_ERROR_BANK_HAS_CANCELLED As String = "BANK_HAS_CANCELLED"
        Private Const BANK_STATUS_ERROR_CANCELLATION_NOT_CLEARING As String = "CANCELLATION_NOT_CLEARING"
        Private Const BANK_STATUS_ERROR_AUTHORIZATION_IS_MISSING As String = "AUTHORIZATION_IS_MISSING"

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPaymentList() As ArrayList
            Dim paymentList As New ArrayList
            Dim paymentListDocument As New XmlDocument()

            paymentListDocument.LoadXml(MyBase.responseData)

            For Each paymentNode As XmlNode In paymentListDocument.SelectNodes("/Root/SalesPaymentList/SalesPayment")
                Dim paymentListPayment As New NetvisorSalesPaymentListPayment()

                With paymentListPayment
                    .netvisorKey = CType(paymentNode.SelectSingleNode("NetvisorKey").InnerText, Integer)
                    .name = paymentNode.SelectSingleNode("Name").InnerText
                    .paymentDate = CType(paymentNode.SelectSingleNode("Date").InnerText, Date)
                    .sum = CType(paymentNode.SelectSingleNode("Sum").InnerText, Decimal)
                    .referenceNumber = paymentNode.SelectSingleNode("ReferenceNumber").InnerText

                    If Len(paymentNode.SelectSingleNode("ForeignCurrencyAmount").InnerText) > 0 Then
                        .foreignCurrencyAmount = CType(paymentNode.SelectSingleNode("ForeignCurrencyAmount").InnerText, Decimal)
                    End If

                    .invoiceNumber = paymentNode.SelectSingleNode("InvoiceNumber").InnerText

                    If paymentNode.SelectSingleNode("BankStatus").InnerText = "OK" Then
                        .bankStatus = NetvisorSalesPaymentListPayment.bankStatuses.ok
                    Else
                        .bankStatus = NetvisorSalesPaymentListPayment.bankStatuses.failed

                        Dim errorDescriptionCode As String = paymentNode.SelectSingleNode("BankStatusErrorDescription").Attributes("code").InnerText
                        Select Case errorDescriptionCode
                            Case BANK_STATUS_ERROR_NO_ACCOUNT_FOUND
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.noAccountFound
                            Case BANK_STATUS_ERROR_NO_PAYMENT_SERVICE_ACCOUNT
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.noPaymentServiceAccount
                            Case BANK_STATUS_ERROR_IN_DUE_DATE
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.errorInDueDate
                            Case BANK_STATUS_ERROR_BALANCE_IS_EXCEEDED
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.balanceIsExceeded
                            Case BANK_STATUS_ERROR_PAYER_HAS_CANCELLED
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.payerHasCancelled
                            Case BANK_STATUS_ERROR_FORM_NOT_CORRECT
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.formNotCorrect
                            Case BANK_STATUS_ERROR_BANK_HAS_CANCELLED
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.bankHasCancelled
                            Case BANK_STATUS_ERROR_CANCELLATION_NOT_CLEARING
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.cancellationNotClearing
                            Case BANK_STATUS_ERROR_AUTHORIZATION_IS_MISSING
                                .returnCode = NetvisorSalesPaymentListPayment.returnCodes.authorizationIsMissing
                            Case Else
                                Throw New ApplicationException("Invalid BankStatusErrorDescription code: " & _
                                                                 errorDescriptionCode)
                        End Select

                        .returnCodeDescription = paymentNode.SelectSingleNode("BankStatusErrorDescription").InnerText
                    End If
                End With

                paymentList.Add(paymentListPayment)
            Next

            Return paymentList
        End Function
    End Class
End Namespace