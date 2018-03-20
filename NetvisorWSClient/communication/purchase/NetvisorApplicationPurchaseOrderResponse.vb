Imports System.Xml
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPurchaseOrderResponse
        Inherits NetvisorApplicationResponse


        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPurchaseOrder() As NetvisorPurchaseOrder
            Dim response As New NetvisorPurchaseOrder()
            Dim PurchaseOrderDocument As New XmlDataDocument()

            PurchaseOrderDocument.LoadXml(MyBase.responseData)
            Dim purchaseOrderNode As XmlNode = PurchaseOrderDocument.SelectSingleNode("/Root/PurchaseOrder")

            With response
                Integer.TryParse(purchaseOrderNode.SelectSingleNode("NetvisorKey").InnerText, .netvisorKey)
                .orderNumber = purchaseOrderNode.SelectSingleNode("OrderNumber").InnerText
                .orderStatus = purchaseOrderNode.SelectSingleNode("OrderStatus").InnerText
                Date.TryParse(purchaseOrderNode.SelectSingleNode("OrderDate").InnerText, .orderDate)
                .vendorName = purchaseOrderNode.SelectSingleNode("VendorName").InnerText
                .vendorAddressline = purchaseOrderNode.SelectSingleNode("VendorAddressLine").InnerText
                .vendorPostnumber = purchaseOrderNode.SelectSingleNode("VendorPostNumber").InnerText
                .vendorCity = purchaseOrderNode.SelectSingleNode("VendorCity").InnerText
                .vendorCountry = purchaseOrderNode.SelectSingleNode("VendorCountry").InnerText
                .deliveryTerm = purchaseOrderNode.SelectSingleNode("DeliveryTerm").InnerText
                .deliveryMethod = purchaseOrderNode.SelectSingleNode("DeliveryMethod").InnerText
                .deliveryName = purchaseOrderNode.SelectSingleNode("DeliveryName").InnerText
                .deliveryAddressLine = purchaseOrderNode.SelectSingleNode("DeliveryAddressLine").InnerText
                .deliveryPostNumber = purchaseOrderNode.SelectSingleNode("DeliveryPostNumber").InnerText
                .deliveryCity = purchaseOrderNode.SelectSingleNode("DeliveryCity").InnerText
                .deliveryCountry = purchaseOrderNode.SelectSingleNode("DeliveryCountry").InnerText
                .comment = purchaseOrderNode.SelectSingleNode("Comment").InnerText
                .privateComment = purchaseOrderNode.SelectSingleNode("PrivateComment").InnerText
                .ourReference = purchaseOrderNode.SelectSingleNode("OurReference").InnerText
                .paymentTermDescription = purchaseOrderNode.SelectSingleNode("PaymentTerm").InnerText
                Decimal.TryParse(purchaseOrderNode.SelectSingleNode("Amount").InnerText, .amount)
                '.currency = purchaseOrderNode.SelectSingleNode("Amount").Attributes("iso4217currencycode").InnerText
            End With

            For Each node As XmlNode In PurchaseOrderDocument.SelectNodes("/Root/PurchaseOrder/PurchaseOrderLines/PurchaseOrderProductLine")

                Dim productLine As New NetvisorPurchaseOrderLine()
                With productLine
                    .productCode = node.SelectSingleNode("ProductCode").InnerText
                    .productName = node.SelectSingleNode("ProductName").InnerText
                    .vendorProductCode = node.SelectSingleNode("VendorProductCode").InnerText
                    Decimal.TryParse(node.SelectSingleNode("OrderedAmount").InnerText, .orderedAmount)
                    Decimal.TryParse(node.SelectSingleNode("DeliveredAmount").InnerText, .deliveredAmount)
                    Decimal.TryParse(node.SelectSingleNode("UnitPrice").InnerText, .unitPrice)
                    Decimal.TryParse(node.SelectSingleNode("VatPercent").InnerText, .vatPercent)
                    Decimal.TryParse(node.SelectSingleNode("LineSum").InnerText, .lineSum)
                    Decimal.TryParse(node.SelectSingleNode("FreightRate").InnerText, .freightRate)
                    Date.TryParse(node.SelectSingleNode("DeliveryDate").InnerText, .DeliveryDate)
                    .inventoryPlace = node.SelectSingleNode("InventoryPlace").InnerText
                    Integer.TryParse(node.SelectSingleNode("AccountingSuggestion").InnerText, .accountingSuggestion)
                End With



                For Each dimensionNode As XmlNode In node.SelectNodes("Dimension")
                    Dim lineDimension As New NetvisorDimension()

                    lineDimension.dimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText
                    lineDimension.dimensionDetail = dimensionNode.SelectSingleNode("DimensionItem").InnerText

                    productLine.addDimension(lineDimension)
                Next
                response.addProductline(productLine)
            Next

            For Each node As XmlNode In PurchaseOrderDocument.SelectNodes("/Root/PurchaseOrder/PurchaseOrderLines/PurchaseOrderCommentLine")
                Dim commentLine As New NetvisorPurchaseOrderCommentLine()
                commentLine.comment = node.InnerText

                response.addCommentLine(commentLine)
            Next

            Return response
        End Function
    End Class
End Namespace
