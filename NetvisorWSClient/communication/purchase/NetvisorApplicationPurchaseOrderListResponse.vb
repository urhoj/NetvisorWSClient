Imports System.Xml

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPurchaseOrderListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPurchaseOrderList() As ArrayList
            Dim response As New ArrayList()
            Dim purchaseOrderListDocument As New XmlDocument()
            purchaseOrderListDocument.LoadXml(MyBase.responseData)

            For Each node As XmlNode In purchaseOrderListDocument.SelectNodes("/Root/PurchaseOrderList/PurchaseOrder")
                Dim orderListOrder As New NetvisorPurchaseOrderListOrder()

                With orderListOrder
                    Integer.TryParse(node.SelectSingleNode("NetvisorKey").InnerText, .netvisorKey)
                    .orderNumber = node.SelectSingleNode("OrderNumber").InnerText
                    Date.TryParse(node.SelectSingleNode("OrderDate").InnerText, .orderDate)
                    .orderStatus = node.SelectSingleNode("OrderStatus").InnerText
                    .vendorName = node.SelectSingleNode("VendorName").InnerText
                    Double.TryParse(node.SelectSingleNode("Amount").InnerText, .amount)
                    .uri = node.SelectSingleNode("Uri").InnerText
                End With
                response.Add(orderListOrder)
            Next

            Return response
        End Function
    End Class
End Namespace

