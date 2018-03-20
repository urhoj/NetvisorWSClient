Imports System.Xml
Imports System.IO
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPurchaseOrderRequest

        Public Function getOrderAsXML(ByVal sourceOrder As NetvisorPurchaseOrder) As String
            Dim stream As New MemoryStream()
            Dim writer As New XmlTextWriter(stream, System.Text.Encoding.UTF8)

            With writer
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("PurchaseOrder")

                .WriteElementString("OrderNumber", sourceOrder.orderNumber)
                .WriteElementString("OrderStatus", sourceOrder.orderStatus)

                .WriteStartElement("OrderDate")
                .WriteAttributeString("format", "ansi")
                .WriteString(Format(sourceOrder.orderDate, "yyyy-MM-dd"))
                .WriteEndElement()

                .WriteStartElement("VendorIdentifier")
                .WriteAttributeString("type", sourceOrder.vendorIdentifier_type)
                .WriteString(sourceOrder.vendorIdentifier)
                .WriteEndElement()

                .WriteElementString("VendorAddressline", sourceOrder.vendorAddressline)
                .WriteElementString("VendorPostNumber", sourceOrder.vendorPostnumber)
                .WriteElementString("VendorCity", sourceOrder.vendorCity)

                .WriteStartElement("VendorCountry")
                .WriteAttributeString("type", "ISO-3166")
                .WriteString(sourceOrder.vendorCountry)
                .WriteEndElement()

                .WriteElementString("DeliveryTerm", sourceOrder.deliveryTerm)
                .WriteElementString("DeliveryMethod", sourceOrder.deliveryMethod)
                .WriteElementString("DeliveryAddressline", sourceOrder.deliveryAddressLine)
                .WriteElementString("DeliveryPostNumber", sourceOrder.deliveryPostNumber)
                .WriteElementString("DeliveryCity", sourceOrder.deliveryCity)

                .WriteStartElement("DeliveryCountry")
                .WriteAttributeString("type", "ISO-3166")
                .WriteString(sourceOrder.deliveryCountry)
                .WriteEndElement()

                .WriteElementString("PrivateComment", sourceOrder.privateComment)
                .WriteElementString("Comment", sourceOrder.comment)
                .WriteElementString("OurReference", sourceOrder.ourReference)

                .WriteElementString("PaymentTermNetDays", sourceOrder.paymentTermNetDays.ToString())
                .WriteElementString("PaymentTermCashDiscountDays", sourceOrder.paymentTermCashDiscountDays.ToString())
                .WriteElementString("PaymentTermDiscountPercent", sourceOrder.paymentTermDiscountPercent.ToString())

                .WriteStartElement("Amount")

                If Not String.IsNullOrEmpty(sourceOrder.currency) Then
                    .WriteAttributeString("iso4217currencycode", sourceOrder.currency)
                End If

                If sourceOrder.currency_ExchangeRate > 0 Then
                    .WriteAttributeString("exchangerate", sourceOrder.currency_ExchangeRate.ToString())
                End If

                .WriteString(sourceOrder.amount.ToString())
                .WriteEndElement() 'amount

                .WriteStartElement("PurchaseOrderLines")

                For Each line As NetvisorPurchaseOrderLine In sourceOrder.ProductLines
                    .WriteStartElement("PurchaseOrderProductLine")

                    .WriteStartElement("ProductCode")
                    .WriteAttributeString("type", line.productCode_type)
                    .WriteString(line.productCode)
                    .WriteEndElement()

                    .WriteElementString("ProductName", line.productName)
                    .WriteElementString("VendorProductCode", line.vendorProductCode)
                    .WriteElementString("OrderedAmount", line.orderedAmount.ToString())
                    .WriteElementString("UnitPrice", line.unitPrice.ToString())
                    .WriteElementString("VatPercent", line.vatPercent.ToString())

                    .WriteStartElement("DeliveryDate")
                    .WriteAttributeString("format", "ansi")
                    .WriteString(Format(line.DeliveryDate, "yyyy-MM-dd"))
                    .WriteEndElement()


                    If Not String.IsNullOrEmpty(line.inventoryPlace) Then
                        .WriteStartElement("InventoryPlace")
                        .WriteAttributeString("type", line.inventoryPlace_type)
                        .WriteString(line.inventoryPlace)
                        .WriteEndElement()
                    End If


                    .WriteElementString("AccountingSuggestion", line.accountingSuggestion)

                    For Each dimension As NetvisorDimension In line.dimensions
                        .WriteStartElement("Dimension")

                        .WriteElementString("DimensionName", dimension.dimensionName)
                        .WriteElementString("DimensionItem", dimension.dimensionDetail)

                        .WriteEndElement() 'Dimension
                    Next

                    .WriteEndElement() 'PurchaseOrderProductLine
                Next

                For Each commentLine As NetvisorPurchaseOrderCommentLine In sourceOrder.CommentLines
                    .WriteStartElement("PurchaseOrderComment")

                    .WriteElementString("Comment", commentLine.comment)

                    .WriteEndElement() 'PurchaseOrderComment
                Next

                .WriteEndElement() 'PurchaseOrderLines
                .WriteEndElement() 'PurchaseOrder
                .WriteEndElement() 'Root
                .Flush()
            End With

            Dim doc As New XmlDocument

            stream.Seek(0, SeekOrigin.Begin)
            Dim reader As New StreamReader(stream)
            doc.LoadXml(reader.ReadToEnd())
            Return reader.ReadToEnd()
        End Function
    End Class
End Namespace
