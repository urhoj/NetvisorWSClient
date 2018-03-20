'
'
'
' Revisio $Revision$
'
' Netvisorin antaman ostolaskulistan vastaus
'

Imports System.Xml
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPurchaseInvoiceDetailedListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPurchaseInvoiceList() As ArrayList

            Dim purchaseInvoiceList As New ArrayList
            Dim purchaseInvoiceListDocument As New XmlDocument()

            purchaseInvoiceListDocument.LoadXml(MyBase.responseData)

            For Each purchaseInvoiceNode As XmlNode In purchaseInvoiceListDocument.SelectNodes("/Root/PurchaseInvoiceList/PurchaseInvoice")
                Dim invoice As New NetvisorPurchaseInvoice

                With invoice
                    .NetvisorKey = purchaseInvoiceNode.SelectSingleNode("netvisorKey").InnerText
                    .InvoiceNumber = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceNumber").InnerText
                    .Amount = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceAmount").InnerText
                    .DueDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDueDate").InnerText
                    .InvoiceDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDate").InnerText

                    .VendorName = purchaseInvoiceNode.SelectSingleNode("VendorName").InnerText

                End With

                For Each node As XmlNode In purchaseInvoiceNode.SelectNodes("InvoiceLines/PurchaseInvoiceLine")

                    Dim line As New NetvisorPurchaseInvoiceLine

                    With line
                        .netvisorKey = node.SelectSingleNode("NetvisorKey").InnerText
                        .Description = node.SelectSingleNode("Description").InnerText
                        .UnitName = node.SelectSingleNode("Unit").InnerText

                        Dim vatPercent As Double
                        Dim orderedAmount As Double
                        Dim deliveredAmount As Double
                        Dim discountPercentage As Double
                        Dim lineSum As Double

                        Double.TryParse(node.SelectSingleNode("DeliveredAmount").InnerText, deliveredAmount)
                        Double.TryParse(node.SelectSingleNode("VatPercent").InnerText, vatPercent)
                        Double.TryParse(node.SelectSingleNode("OrderedAmount").InnerText, orderedAmount)
                        Double.TryParse(node.SelectSingleNode("DiscountPercentage").InnerText, discountPercentage)
                        Double.TryParse(node.SelectSingleNode("LineSum").InnerText, lineSum)

                        .LineSum = lineSum
                        .VatPercent = vatPercent
                        .VatCode = node.SelectSingleNode("VatCode").InnerText
                        .UnitPrice = node.SelectSingleNode("UnitPrice").InnerText
                        .OrderedAmount = orderedAmount
                        .DeliveredAmount = deliveredAmount
                        .ProductCode = node.SelectSingleNode("ProductCode").InnerText
                        .ProductName = node.SelectSingleNode("ProductName").InnerText
                        .DiscountPercentage = discountPercentage

                        For Each dimensionNode As XmlNode In node.SelectNodes("PurchaseInvoiceLineDimensions/Dimension")

                            Dim dimension As New NetvisorDimension

                            With dimension
                                .dimensionName = dimensionNode.SelectSingleNode("DimensionName").InnerText
                                .dimensionDetail = dimensionNode.SelectSingleNode("DimensionDetailName").InnerText
                            End With

                            line.addDimension(dimension)
                        Next

                    End With

                    invoice.addInvoiceLine(line)

                Next

                purchaseInvoiceList.Add(invoice)
            Next

            Return purchaseInvoiceList
        End Function
    End Class
End Namespace
