'
'
'
' Revisio $Revision$
'
' Lukee Netvisorin antaman tuotehaku-pyynnön vastauksen ja palauttaa tuotteen
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationProductResponse
        Inherits NetvisorApplicationResponse

        Private Const UNIT_PRICE_TYPE_NET As String = "net"
        Private Const PRODUCT_BASE_INFORMATION_PATH As String = "/Root/Product/ProductBaseInformation/"
        Private Const PRODUCT_BOOKKEEPING_DETAILS_PATH As String = "/Root/Product/ProductBookKeepingDetails/"
        Private Const PRODUCT_INVENTORY_DETAILS_PATH As String = "/Root/Product/ProductInventoryDetails/"

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getProduct() As NetvisorProduct

            Dim productDocument As New XmlDocument()
            productDocument.LoadXml(MyBase.responseData)

            Dim product As New NetvisorProduct()
            With product
                .netvisorKey = CType(productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "NetvisorKey").InnerText, Integer)
                .productCode = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "ProductCode").InnerText
                .productGroup = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "ProductGroup").InnerText
                .name = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "Name").InnerText
                .description = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "Description").InnerText

                Dim unitPrice As String = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "UnitPrice").InnerText
                If Not String.IsNullOrEmpty(unitPrice) Then
                    .unitPrice = CType(unitPrice, Decimal)
                End If

                If productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "UnitPrice").Attributes("type").InnerText = UNIT_PRICE_TYPE_NET Then
                    .unitPriceType = NetvisorProduct.unitPriceTypes.net
                Else
                    .unitPriceType = NetvisorProduct.unitPriceTypes.gross
                End If

                .unit = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "Unit").InnerText

                Dim unitWeight As String = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "UnitWeight").InnerText
                If Not String.IsNullOrEmpty(unitWeight) Then
                    .unitWeight = CType(unitWeight, Decimal)
                End If

                Dim purchasePrice As String = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "PurchasePrice").InnerText
                If Not String.IsNullOrEmpty(purchasePrice) Then
                    .purchaseprice = CType(purchasePrice, Decimal)
                End If

                .tariffHeading = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "TariffHeading").InnerText

                Dim comissionPercentage As String = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "ComissionPercentage").InnerText
                If Not String.IsNullOrEmpty(comissionPercentage) Then
                    .comissionPercentage = CType(comissionPercentage, Decimal)
                End If

                Dim isActive As String = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "IsActive").InnerText
                If Not String.IsNullOrEmpty(isActive) Then
                    .isActive = (CType(isActive, Integer) = 1)
                End If

                Dim isSalesProduct As String = productDocument.SelectSingleNode(PRODUCT_BASE_INFORMATION_PATH & "IsSalesProduct").InnerText
                If Not String.IsNullOrEmpty(isSalesProduct) Then
                    .isSalesproduct = (CType(isSalesProduct, Integer) = 1)
                End If

                Dim defaultVatPercentage As String = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH & "DefaultVatPercent").InnerText
                If Not String.IsNullOrEmpty(defaultVatPercentage) Then
                    .defaultVatPercentage = CType(defaultVatPercentage, Decimal)
                End If

                Dim defaultDomesticAccountNumber As String = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH & "DefaultDomesticAccountNumber").InnerText
                If Not String.IsNullOrEmpty(defaultDomesticAccountNumber) Then
                    .DefaultDomesticAccountNumber = CType(defaultDomesticAccountNumber, Integer)
                End If

                Dim defaultEuAccountNumber As String = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH & "DefaultEuAccountNumber").InnerText
                If Not String.IsNullOrEmpty(defaultEuAccountNumber) Then
                    .DefaultEuAccountNumber = CType(defaultEuAccountNumber, Integer)
                End If

                Dim defaultOutsideEUAccountNumber As String = productDocument.SelectSingleNode(PRODUCT_BOOKKEEPING_DETAILS_PATH & "DefaultOutsideEUAccountNumber").InnerText
                If Not String.IsNullOrEmpty(DefaultOutsideEUAccountNumber) Then
                    .DefaultOutsideEUAccountNumber = CType(defaultOutsideEUAccountNumber, Decimal)
                End If

                Dim InventoryAmount As String = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH & "InventoryAmount").InnerText
                If Not String.IsNullOrEmpty(InventoryAmount) Then
                    .InventoryAmount = CType(InventoryAmount, Decimal)
                End If

                Dim InventoryMidPrice As String = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH & "InventoryMidPrice").InnerText
                If Not String.IsNullOrEmpty(InventoryMidPrice) Then
                    .InventoryMidPrice = CType(InventoryMidPrice, Decimal)
                End If

                Dim InventoryValue As String = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH & "InventoryValue").InnerText
                If Not String.IsNullOrEmpty(InventoryValue) Then
                    .InventoryValue = CType(InventoryValue, Decimal)
                End If

                Dim InventoryReservedAmount As String = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH & "InventoryReservedAmount").InnerText
                If Not String.IsNullOrEmpty(InventoryReservedAmount) Then
                    .InventoryReservedAmount = CType(InventoryReservedAmount, Decimal)
                End If

                Dim InventoryOrderedAmount As String = productDocument.SelectSingleNode(PRODUCT_INVENTORY_DETAILS_PATH & "InventoryOrderedAmount").InnerText
                If Not String.IsNullOrEmpty(InventoryOrderedAmount) Then
                    .InventoryOrderedAmount = CType(InventoryOrderedAmount, Decimal)
                End If
            End With

            Return product
        End Function
    End Class
End Namespace