'
'
'
' Revisio $Revision$
'
' Antaa wsClientille oikeanlaisen responsen mikäli vastaus on tyypitetty. 
' Jos ei, niin perusvastaus
'

Imports NetvisorWSClient.communication.controller
Imports NetvisorWSClient.communication.sales
Imports NetvisorWSClient.communication.purchase
Imports NetvisorWSClient.communication.accounting
Imports NetvisorWSClient.communication.collector
Imports NetvisorWSClient.communication.crm
Imports NetvisorWSClient.communication.webshop
Imports NetvisorWSClient.communication.payroll

Namespace NetvisorWSClient.communication
    Public Class NetvisorApplicationResponseFactory
        Public Shared Function getNetvisorApplicationResponse(ByVal url As String, ByVal responseData As String) As Object

            If url.Contains(WSClient.ACTION_SALESINVOICE_LIST) Then
                Return New NetvisorApplicationSalesInvoiceListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_PURCHASEINVOICE_LIST) Then
                Return New NetvisorApplicationPurchaseInvoiceListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_CUSTOMER_LIST) Then
                Return New NetvisorApplicationCustomerListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_ACCOUNTING_LEDGER) Then
                Return New NetvisorApplicationAccountingLedgerResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_PRODUCT_LIST) And Not url.Contains(WSClient.ACTION_WEBSHOP_PRODUCT_LIST) Then
                Return New NetvisorApplicationProductListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_GETPRODUCT) Then
                Return New NetvisorApplicationProductResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_SALESPAYMENT_LIST) Then
                Return New NetvisorApplicationSalesPaymentListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_GETSALESINVOICE) Then
                Return New NetvisorApplicationSalesInvoiceResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_GETCUSTOMER) Then
                Return New NetvisorApplicationCustomerResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_DIMENSION_LIST) Then
                Return New NetvisorApplicationDimensionListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_ACCOUNTING_BUDGET_ACCOUNT_LIST) Then
                Return New NetvisorApplicationAccountingBudgetAccountListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET) Then
                Return New NetvisorApplicationAccountingBudgetAccountBudgetResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET) Then
                Return New NetvisorApplicationAccountingBudgetDimensionBudgetResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_WEBSHOP_PRODUCT_LIST) Then
                Return New NetvisorApplicationWebShopProductResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_WEBSHOP_PRODUCT_IMAGES) Then
                Return New NetvisorApplicationWebShopProductImageResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_ACCOUNTLIST) Then
                Return New NetvisorApplicationAccountListReponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_ACCOUNTING_PERIODLIST) Then
                Return New NetvisorApplicationAccountingPeriodListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_PAYMENT_LIST) Then
                Return New NetvisorApplicationPaymentListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_SALESPERSONNELLIST) Then
                Return New NetvisorApplicationSalesPersonnelListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_PURCHASEORDER_LIST) Then
                Return New NetvisorApplicationPurchaseOrderListResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_GET_PURCHASEORDER) Then
                Return New NetvisorApplicationPurchaseOrderResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_PAYSLIPLIST) Then
                Return New NetvisorApplicationPaysliplistResponse(responseData)

            ElseIf url.Contains(WSClient.ACTION_GETPAYSLIP) Then
                Return New NetvisorApplicationGetPayslipResponse(responseData)

            Else
                Return New NetvisorApplicationResponse(responseData)
            End If
        End Function
    End Class
End Namespace