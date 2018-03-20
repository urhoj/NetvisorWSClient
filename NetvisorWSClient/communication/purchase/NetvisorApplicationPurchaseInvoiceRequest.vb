'
'
'
' Revisio $Revision$
'
' Ilmentää netvisoriin vietävän ostolaskupyynnön
' kirjoittaa annetusta laskusta xml-sanoman
'

Imports System.IO
Imports System.Xml
Imports System.Text
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPurchaseInvoiceRequest

        Public Function getInvoiceAsXML(ByVal invoice As NetvisorPurchaseInvoice) As String
            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("PurchaseInvoice")

                .WriteElementString("InvoiceNumber", invoice.InvoiceNumber)

                .WriteStartElement("InvoiceDate")
                .WriteAttributeString("format", "ansi")
                If invoice.findNextOpenDateIfInLockedPeriod Then
                    .WriteAttributeString("findopendate", "true")
                End If
                .WriteString(Format(invoice.InvoiceDate, "yyyy-MM-dd"))
                .WriteEndElement() ' /IvoiceDate

                Dim invoiceSource As String
                Select Case invoice.invoiceSource
                    Case NetvisorPurchaseInvoice.invoiceSources.MANUAL
                        invoiceSource = "manual"
                    Case NetvisorPurchaseInvoice.invoiceSources.FINVOICE
                        invoiceSource = "finvoice"
					Case NetvisorPurchaseInvoice.invoiceSources.CLARUS
						invoiceSource = "clarus"
					Case NetvisorPurchaseInvoice.invoiceSources.ITELLA
                        invoiceSource = "itella"
                    Case NetvisorPurchaseInvoice.invoiceSources.MAVENTA_SCAN
                        invoiceSource = "maventascan"
                    Case NetvisorPurchaseInvoice.invoiceSources.MAVENTA_FINVOICE
                        invoiceSource = "maventafinvoice"
                    Case Else
                        Throw New ApplicationException("Invalid invoiceSource: " & invoice.invoiceSource)
                End Select

                .WriteElementString("InvoiceSource", invoiceSource)

                .WriteStartElement("ValueDate")
                .WriteAttributeString("format", "ansi")
                .WriteString(Format(invoice.ValueDate, "yyyy-MM-dd"))
                .WriteEndElement() ' /ValueDate

                .WriteStartElement("DueDate")
                .WriteAttributeString("format", "ansi")
                .WriteString(Format(invoice.DueDate, "yyyy-MM-dd"))
                .WriteEndElement() ' /DueDate

                .WriteStartElement("PurchaseInvoiceOnRound")
                .WriteAttributeString("type", "netvisor")
                Select Case invoice.InvoiceRound
                    Case NetvisorPurchaseInvoice.NetvisorPurchaseInvoiceRounds.UNHANDLED
                        .WriteString("open")
                    Case NetvisorPurchaseInvoice.NetvisorPurchaseInvoiceRounds.CONTENTSUPERVISORED
                        .WriteString("approved")
                    Case NetvisorPurchaseInvoice.NetvisorPurchaseInvoiceRounds.ACCEPTED
                        .WriteString("accepted")
                    Case Else
                        Throw New ApplicationException("Invalid purchaseinvoiceround: " & invoice.InvoiceRound)
                End Select
                .WriteEndElement() ' /PurchaseInvoiceOnRound

                .WriteElementString("VendorName", invoice.VendorName)
                .WriteElementString("VendorAddressLine", invoice.VendorAddressline)
                .WriteElementString("VendorPostNumber", invoice.VendorPostNumber)
                .WriteElementString("VendorCity", invoice.VendorCity)
                .WriteElementString("VendorCountry", invoice.vendorCountry)
                .WriteElementString("VendorPhoneNumber", invoice.vendorPhoneNumber)
                .WriteElementString("VendorFaxNumber", invoice.vendorFaxNumber)
                .WriteElementString("VendorEmail", invoice.vendorEmail)
                .WriteElementString("VendorHomepage", invoice.vendorHomepage)

                .WriteElementString("Amount", invoice.Amount)
                .WriteElementString("AccountNumber", invoice.AccountNumber)
                .WriteElementString("OrganizationIdentifier", invoice.organizationIdentifier)

                If invoice.deliveryDate <> Date.MinValue Then
                    .WriteStartElement("DeliveryDate")
                    .WriteAttributeString("format", "ansi")
                    .WriteString(Format(invoice.deliveryDate, "yyyy-MM-dd"))
                    .WriteEndElement()
                End If

                .WriteElementString("OverdueFinePercent", invoice.overdueFinePercent)
                .WriteElementString("BankReferenceNumber", invoice.bankReferenceNumber)
                .WriteElementString("OurReference", invoice.ourReference)
                .WriteElementString("YourReference", invoice.yourReference)
                .WriteElementString("CurrencyCode", invoice.currencyCode)
                .WriteElementString("DeliveryTerms", invoice.deliveryTerms)
                .WriteElementString("DeliveryMethod", invoice.deliveryMethod)
                .WriteElementString("Comment", invoice.comment)

                .WriteElementString("CheckSum", invoice.checkSum)
                .WriteElementString("PdfExtraPages", invoice.pdfExtraPages)

                If invoice.readyForAccounting Then
                    .WriteElementString("ReadyForAccounting", 1)
                End If

                If invoice.invoiceLines.Count > 0 Then

                    .WriteStartElement("PurchaseInvoiceLines")

                    For Each line As NetvisorPurchaseInvoiceLine In invoice.invoiceLines
                        .WriteStartElement("PurchaseInvoiceLine")

                        .WriteElementString("ProductCode", line.ProductCode)
                        .WriteElementString("ProductName", line.ProductName)
                        .WriteElementString("OrderedAmount", line.OrderedAmount)
                        .WriteElementString("DeliveredAmount", line.DeliveredAmount)
                        .WriteElementString("UnitName", line.UnitName)
                        .WriteElementString("UnitPrice", line.UnitPrice)
                        .WriteElementString("DiscountPercentage", line.DiscountPercentage)
                        .WriteElementString("VatPercent", line.VatPercent)

                        .WriteStartElement("LineSum")
                        .WriteAttributeString("type", "brutto")
                        .WriteString(line.LineSum)
                        .WriteEndElement() '/LineSum

                        .WriteElementString("Description", line.Description)
                        .WriteElementString("Sort", line.sort)
                        .WriteElementString("AccountingSuggestion", line.accountNumberSuggestion)

                        If line.Dimensions.Count > 0 Then

                            For Each dimension As NetvisorDimension In line.Dimensions

                                .WriteStartElement("Dimension")

                                .WriteElementString("DimensionName", dimension.dimensionName)
                                .WriteElementString("DimensionItem", dimension.dimensionDetail)

                                .WriteEndElement() '/Dimension

                            Next

                        End If


                        .WriteEndElement() ' /PurchaseInvoiceLine
                    Next

                    .WriteEndElement() ' /PurchaseInvoiceLines

                End If

                If invoice.invoiceSubLines.Count > 0 Then

                    .WriteStartElement("PurchaseInvoiceSubLines")

                    For Each subLine As NetvisorPurchaseInvoiceSubLine In invoice.invoiceSubLines
                        .WriteStartElement("PurchaseInvoiceSubLine")

                        .WriteElementString("ProductCode", subLine.ProductCode)
                        .WriteElementString("ProductName", subLine.ProductName)
                        .WriteElementString("OrderedAmount", subLine.OrderedAmount)
                        .WriteElementString("DeliveredAmount", subLine.DeliveredAmount)
                        .WriteElementString("UnitName", subLine.UnitName)
                        .WriteElementString("UnitPrice", subLine.UnitPrice)
                        .WriteElementString("DiscountPercentage", subLine.DiscountPercentage)
                        .WriteElementString("VatPercent", subLine.VatPercent)

                        .WriteStartElement("LineSum")
                        .WriteAttributeString("type", "brutto")
                        .WriteString(subLine.LineSum)
                        .WriteEndElement() '/LineSum

                        .WriteElementString("Description", subLine.Description)
                        .WriteElementString("Sort", subLine.sort)

                        .WriteEndElement() ' /PurchaseInvoiceSubLine
                    Next

                    .WriteEndElement() ' /PurchaseInvoiceSubLines

                End If

                If invoice.invoiceCommentLines.Count > 0 Then

                    .WriteStartElement("PurchaseInvoiceCommentLines")

                    For Each line As NetvisorPurchaseInvoiceCommentLine In invoice.invoiceCommentLines
                        .WriteStartElement("PurchaseInvoiceCommentLine")
                        .WriteElementString("Comment", line.comment)
                        .WriteElementString("Sort", line.sort)
                        .WriteEndElement() ' /PurchaseInvoiceCommentLine
                    Next

                    .WriteEndElement() ' /PurchaseInvoiceCommentLines

                End If

                If invoice.attachments.Count > 0 Then
                    .WriteStartElement("PurchaseInvoiceAttachments")

                    For Each attachment As NetvisorAttachment In invoice.attachments
                        .WriteStartElement("PurchaseInvoiceAttachment")

                        .WriteElementString("MimeType", attachment.mimeType)
                        .WriteElementString("AttachmentDescription", attachment.description)
                        .WriteElementString("Filename", attachment.fileName)
                        .WriteStartElement("DocumentData")
                        If attachment.purchaseInvoiceAttachmentCategory > 0 Then
                            Select Case attachment.purchaseInvoiceAttachmentCategory
                                Case NetvisorAttachment.AttachmentCategory.invoiceImage
                                    .WriteAttributeString("documenttype", "invoiceimage")
                                Case NetvisorAttachment.AttachmentCategory.otherAttachment
                                    .WriteAttributeString("documenttype", "otherattachment")
                                Case Else
                                    Throw New ApplicationException("Invalid purchaseInvoiceAttachmentCategory: " & attachment.purchaseInvoiceAttachmentCategory)
                            End Select
                        End If

                        .WriteString(Convert.ToBase64String(attachment.attachmentData))
                        .WriteEndElement() ' /DocumentData

                        .WriteEndElement() ' /PurchaseInvoiceAttachment
                    Next

                    .WriteEndElement() ' /PurchaseInvoiceAttachments
                End If

                .WriteEndElement() ' /PurchaseInvoice
                .WriteEndElement() ' /Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace