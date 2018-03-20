Imports System.Xml
Imports NetvisorWSClient.communication.common

'
'
'
' Revisio $Revision$
'
' 
'

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPurchaseInvoiceResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPurchaseInvoice() As NetvisorPurchaseInvoice
            Dim invoice As New NetvisorPurchaseInvoice
            Dim purchaseInvoiceDocument As New XmlDocument()

            purchaseInvoiceDocument.LoadXml(MyBase.responseData)

            Dim purchaseInvoiceNode As XmlNode = purchaseInvoiceDocument.SelectSingleNode("/Root/PurchaseInvoice")

            With invoice
                .InvoiceNumber = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceNumber").InnerText
                .Amount = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceAmount").InnerText
                .DueDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDueDate").InnerText
                .ourReference = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceOurReference").InnerText
                .yourReference = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceYourReference").InnerText
                .ValueDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceValueDate").InnerText
                .comment = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDescription").InnerText
                .InvoiceDate = purchaseInvoiceNode.SelectSingleNode("PurchaseInvoiceDate").InnerText

                .VendorName = purchaseInvoiceNode.SelectSingleNode("VendorName").InnerText
                .VendorAddressline = purchaseInvoiceNode.SelectSingleNode("VendorAddressline").InnerText
                .VendorPostNumber = purchaseInvoiceNode.SelectSingleNode("VendorPostnumber").InnerText
                .VendorCity = purchaseInvoiceNode.SelectSingleNode("VendorTown").InnerText
                .vendorCountry = purchaseInvoiceNode.SelectSingleNode("VendorCountry").InnerText

            End With

            For Each node As XmlNode In purchaseInvoiceNode.SelectNodes("Attachments/Attachment")

                Dim attachment As New NetvisorAttachment

                With attachment
                    .attachmentData = Convert.FromBase64String(node.SelectSingleNode("AttachmentBase64Data").InnerText)
                    .fileName = node.SelectSingleNode("FileName").InnerText
                    .description = node.SelectSingleNode("Comment").InnerText
                    .mimeType = node.SelectSingleNode("ContentType").InnerText
                End With

                invoice.addAttachment(attachment)

            Next


            For Each node As XmlNode In purchaseInvoiceNode.SelectNodes("InvoiceLines/PurchaseInvoiceLine")

                Dim line As New NetvisorPurchaseInvoiceLine

                With line
                    .netvisorKey = node.SelectSingleNode("NetvisorKey").InnerText
                    .Description = node.SelectSingleNode("Description").InnerText
                    .LineSum = node.SelectSingleNode("LineSum").InnerText
                    .UnitName = node.SelectSingleNode("Unit").InnerText

                    Dim vatPercent As Double
                    Dim orderedAmount As Double
                    Dim deliveredAmount As Double
                    Dim discountPercentage As Double

                    Double.TryParse(node.SelectSingleNode("DeliveredAmount").InnerText, DeliveredAmount)
                    Double.TryParse(node.SelectSingleNode("VatPercent").InnerText, vatPercent)
                    Double.TryParse(node.SelectSingleNode("OrderedAmount").InnerText, orderedAmount)
                    Double.TryParse(node.SelectSingleNode("DiscountPercentage").InnerText, discountPercentage)

                    .VatPercent = vatPercent
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

            Return invoice

        End Function

    End Class
End Namespace

