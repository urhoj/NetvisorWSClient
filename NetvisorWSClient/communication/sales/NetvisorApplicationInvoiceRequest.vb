'
'
'
' Revisio $Revision$
'
' Netvisoriin lähetettävä myyntilaskusanoma
'

Imports System.Xml
Imports System.Text
Imports System.IO
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationInvoiceRequest

        Public Function getInvoiceAsXML(ByVal invoice As NetvisorInvoice) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("SalesInvoice")

                If Len(invoice.InvoiceNumber) > 0 AndAlso CType(invoice.InvoiceNumber, Long) > 0 Then
                    .WriteStartElement("SalesInvoiceNumber")
                    .WriteString(invoice.InvoiceNumber)
                    .WriteEndElement()
                End If

                .WriteStartElement("SalesInvoiceDate")
                .WriteAttributeString("format", "ansi")
                .WriteString(invoice.InvoiceDate.Year & "-" & invoice.InvoiceDate.Month & "-" & invoice.InvoiceDate.Day)
                .WriteEndElement()

                .WriteStartElement("SalesInvoiceDeliveryDate")
                .WriteAttributeString("format", "ansi")
                .WriteString(invoice.DeliveryDate.Year & "-" & invoice.DeliveryDate.Month & "-" & invoice.DeliveryDate.Day)
                .WriteEndElement()

                If Not IsNothing(invoice.ReferenceNumber) Then
                    .WriteStartElement("SalesInvoiceReferenceNumber")
                    .WriteString(invoice.ReferenceNumber.getMachineReadableFormat())
                    .WriteEndElement()
                End If

                Dim totalAmount As Decimal
                Dim calculateTotalSumFromInvoiceLines As Boolean = Not invoice.InvoiceSum.HasValue

                If calculateTotalSumFromInvoiceLines Then
                    totalAmount = invoice.getInvoiceTotalAmountCalculatedFromProductLines()
                Else
                    totalAmount = Math.Round(invoice.InvoiceSum.Value, 2, MidpointRounding.AwayFromZero)
                End If

                .WriteStartElement("SalesInvoiceAmount")

                If Len(invoice.iso4217currencycode) > 0 Then
                    .WriteAttributeString("iso4217currencycode", invoice.iso4217currencycode)

                    If invoice.overrideCurrencyRate > 0 Then
                        .WriteAttributeString("currencyrate", invoice.overrideCurrencyRate)
                    End If
                End If

                .WriteString(totalAmount.ToString())
                .WriteEndElement()

                If invoice.sellerIdentifier > 0 Then
                    .WriteStartElement("SellerIdentifier")
                    .WriteAttributeString("type", "netvisor")
                    .WriteString(invoice.sellerIdentifier)
                    .WriteEndElement()
                End If

                If Not String.IsNullOrEmpty(invoice.sellerName) Then
                    .WriteStartElement("SellerName")
                    .WriteString(invoice.sellerName)
                    .WriteEndElement()
                End If

                Dim invoiceType As String
                Select Case invoice.invoiceType
                    Case NetvisorInvoice.NetvisorInvoiceTypes.invoice
                        invoiceType = "invoice"

                    Case NetvisorInvoice.NetvisorInvoiceTypes.order
                        invoiceType = "order"

                    Case Else
                        ' jos tilaa ei annettu, niin oletetaan että lasku
                        invoiceType = "invoice"
                        invoice.invoiceType = NetvisorInvoice.NetvisorInvoiceTypes.invoice
                End Select

                .WriteElementString("InvoiceType", invoiceType)

                .WriteStartElement("SalesInvoiceStatus")
                .WriteAttributeString("type", "netvisor")

                If invoice.invoiceType = NetvisorInvoice.NetvisorInvoiceTypes.invoice Then
                    If invoice.InvoiceStatus <> 0 Then
                        Select Case invoice.InvoiceStatus
                            Case NetvisorInvoice.NetvisorInvoiceStatuses.Open
                                .WriteString("open")
                            Case NetvisorInvoice.NetvisorInvoiceStatuses.UnSent
                                .WriteString("unsent")
                            Case Else
                                Throw New ApplicationException("Invalid salesinvoicestatus: " & invoice.InvoiceStatus)
                        End Select
                    Else
                        .WriteString("open")
                    End If
                ElseIf invoice.invoiceType = NetvisorInvoice.NetvisorInvoiceTypes.order Then
                    Select Case invoice.InvoiceStatus
                        Case NetvisorInvoice.NetvisorOrderStatuses.Delivered
                            .WriteString("delivered")
                        Case NetvisorInvoice.NetvisorOrderStatuses.unDelivered
                            .WriteString("undelivered")
                        Case Else
                            Throw New ApplicationException("Invalid preinvoice status: " & invoice.InvoiceStatus)
                    End Select
                End If

                .WriteEndElement()

                .WriteElementString("SalesInvoiceFreeTextBeforeLines", invoice.SalesInvoiceFreeTextBeforeLines)
                .WriteElementString("SalesInvoiceFreeTextAfterLines", invoice.SalesInvoiceFreeTextAfterLines)

                .WriteElementString("SalesInvoiceOurReference", invoice.ourReference)
                .WriteElementString("SalesInvoiceYourReference", invoice.yourReference)

                If Not String.IsNullOrEmpty(invoice.privateComment) Then
                    .WriteElementString("SalesInvoicePrivateComment", invoice.privateComment)
                End If

                .WriteStartElement("InvoicingCustomerIdentifier")

                Select Case invoice.CustomerIdentifierType
                    Case NetvisorInvoice.CustomerIdentifierSource.EXTERNAL_IDENTIFIER
                        .WriteAttributeString("type", "customer")

                    Case NetvisorInvoice.CustomerIdentifierSource.NETVISOR_IDENTIFIER
                        .WriteAttributeString("type", "netvisor")

                    Case Else
                        Throw New ApplicationException("Unkown customer identifier type: " & invoice.CustomerIdentifierType)

                End Select

                .WriteString(invoice.CustomerIdentifier)
                .WriteEndElement()

                .WriteStartElement("InvoicingCustomerName")
                .WriteString(invoice.CustomerName)
                .WriteEndElement()

                .WriteStartElement("InvoicingCustomerNameExtension")
                .WriteString(invoice.CustomerNameExtension)
                .WriteEndElement()

                .WriteStartElement("InvoicingCustomerAddressLine")
                .WriteString(invoice.CustomerAddress)
                .WriteEndElement()

                .WriteStartElement("InvoicingCustomerPostNumber")
                .WriteString(invoice.CustomerPostNumber)
                .WriteEndElement()

                .WriteStartElement("InvoicingCustomerTown")
                .WriteString(invoice.CustomerTown)
                .WriteEndElement()

                .WriteStartElement("InvoicingCustomerCountryCode")
                .WriteAttributeString("type", "ISO-3166")
                .WriteString(invoice.CustomerCountryISO3166Code)
                .WriteEndElement()

                If Not IsNothing(invoice.DeliveryAddress) AndAlso invoice.DeliveryAddress.Length() > 0 Then
                    .WriteStartElement("deliveryaddressname")
                    .WriteString(invoice.DeliveryName)
                    .WriteEndElement()

                    .WriteStartElement("deliveryaddressline")
                    .WriteString(invoice.DeliveryAddress)
                    .WriteEndElement()

                    .WriteStartElement("deliveryaddresspostnumber")
                    .WriteString(invoice.DeliveryPostNumber)
                    .WriteEndElement()

                    .WriteStartElement("deliveryaddresstown")
                    .WriteString(invoice.DeliveryTown)
                    .WriteEndElement()

                    .WriteStartElement("deliveryaddresscountrycode")
                    .WriteAttributeString("type", "ISO-3166")
                    .WriteString(invoice.DeliveryCountryISO3166Code)
                    .WriteEndElement()
                End If

                If Not String.IsNullOrEmpty(invoice.DeliveryMethod) Then
                    .WriteStartElement("DeliveryMethod")
                    .WriteString(invoice.DeliveryMethod)
                    .WriteEndElement()
                End If

                If Not String.IsNullOrEmpty(invoice.DeliveryTerm) Then
                    .WriteStartElement("DeliveryTerm")
                    .WriteString(invoice.DeliveryTerm)
                    .WriteEndElement()
                End If

                If invoice.taxHandlingType > 0 Then

                    Select Case invoice.taxHandlingType

                        Case NetvisorInvoice.NetvisorInvoiceTaxHandlingTypes.countryGroup
                            .WriteElementString("SalesInvoiceTaxHandlingType", NetvisorInvoice.TAX_HANDLING_TYPE_COUNTRY_GROUP)

                        Case NetvisorInvoice.NetvisorInvoiceTaxHandlingTypes.domesticConstructionService
                            .WriteElementString("SalesInvoiceTaxHandlingType", NetvisorInvoice.TAX_HANDLING_TYPE_DOMESTIC_CONSTRUCTION_SERVICES)

                        Case NetvisorInvoice.NetvisorInvoiceTaxHandlingTypes.noVatHandling
                            .WriteElementString("SalesInvoiceTaxHandlingType", NetvisorInvoice.TAX_HANDLING_TYPE_NO_VAT_HANDLING)

                        Case Else
                            Throw New ApplicationException("Unknow taxhandling type: " & invoice.taxHandlingType)

                    End Select

                End If

                .WriteStartElement("PaymentTermNetDays")
                .WriteString(invoice.PaymentTermNetDays.ToString())
                .WriteEndElement()

                If Not IsNothing(invoice.paymentTermCashDiscountDays) And Not IsNothing(invoice.paymentTermCashDiscount) Then
                    .WriteStartElement("paymentTermCashDiscountDays")
                    .WriteString(invoice.paymentTermCashDiscountDays.ToString())
                    .WriteEndElement()

                    Dim cashDiscountType As String

                    Select Case invoice.paymentTermCashDiscountType
                        Case NetvisorInvoice.paymentTermCashDiscountTypes.PERCENTAGE
                            cashDiscountType = "percentage"
                        Case Else
                            Throw New ApplicationException("Valid CashDiscountType must be set in order to use PaymentTermCashDiscount")
                    End Select

                    .WriteStartElement("PaymentTermCashDiscount")
                    .WriteAttributeString("type", cashDiscountType)
                    .WriteString(invoice.paymentTermCashDiscount.ToString())
                    .WriteEndElement()
                End If

                .WriteStartElement("ExpectPartialPayments")
                .WriteString("1")
                .WriteEndElement()

                If invoice.TryDirectDebitLink Then
                    .WriteStartElement("TryDirectDebitLink")

                    Dim mode As String = vbNullString
                    If invoice.IgnoreDirectDebitLinkError Then
                        mode = NetvisorInvoice.DIRECT_DEBIT_LINK_ERROR_MODE_IGNORE
                    Else
                        mode = NetvisorInvoice.DIRECT_DEBIT_LINK_ERROR_MODE_FAIL
                    End If

                    .WriteAttributeString("mode", mode)
                    .WriteString("1")
                    .WriteEndElement()
                End If

                If invoice.OverrideVoucherSalesReceivablesAccountNumber > 0 Then
                    .WriteElementString("OverrideVoucherSalesReceivablesAccountNumber", invoice.OverrideVoucherSalesReceivablesAccountNumber)
                End If

                If invoice.invoiceSubjectType > 0 Then
                    Dim subjectType As String = String.Empty

                    Select Case invoice.invoiceSubjectType
                        Case NetvisorInvoice.invoiceSubjectTypes.memberInvoice
                            subjectType = "memberinvoice"

                        Case Else
                            Throw New ApplicationException("Invalid invoice subject type: " & invoice.invoiceSubjectType)

                    End Select

                    .WriteElementString("InvoiceSubjectType", subjectType)
                End If

                If Len(invoice.printChannelFormat) > 0 Then
                    .WriteStartElement("PrintChannelFormat")
                    Select Case invoice.printChannelFormatType
                        Case NetvisorInvoice.PrintChannelFormatSource.EXTERNAL_IDENTIFIER
                            .WriteAttributeString("type", "customer")

                        Case NetvisorInvoice.PrintChannelFormatSource.NETVISOR_IDENTIFIER
                            .WriteAttributeString("type", "netvisor")

                        Case Else
                            Throw New ApplicationException("Unkown print channel format identifier type: " & invoice.printChannelFormatType)

                    End Select
                    .WriteString(invoice.printChannelFormat)
                    .WriteEndElement()
                End If

                If Len(invoice.secondname) > 0 Then
                    .WriteStartElement("SecondName")
                    Select Case invoice.secondnameType
                        Case NetvisorInvoice.SecondNameSource.EXTERNAL_IDENTIFIER
                            .WriteAttributeString("type", "customer")

                        Case NetvisorInvoice.SecondNameSource.NETVISOR_IDENTIFIER
                            .WriteAttributeString("type", "netvisor")

                        Case Else
                            Throw New ApplicationException("Unkown print channel format identifier type: " & invoice.secondnameType)

                    End Select
                    .WriteString(invoice.secondname)
                    .WriteEndElement()
                End If

                If Not IsNothing(invoice.OverrideRateOfOverdue) Then
                    .WriteElementString("OverrideRateOfOverdue", invoice.OverrideRateOfOverdue)
                End If

                .WriteStartElement("InvoiceLines")

                For Each line As INetvisorInvoiceLine In invoice.invoiceLines
                    .WriteStartElement("InvoiceLine")

                    If TypeOf (line) Is NetvisorInvoiceCommentLine Then
                        Dim invoiceLine As NetvisorInvoiceCommentLine = line

                        .WriteStartElement("SalesInvoiceCommentLine")
                        .WriteElementString("Comment", invoiceLine.comment)
                        .WriteEndElement() '/SalesInvoiceCommentLine 
                    Else
                        Dim invoiceLine As NetvisorInvoiceProductLine = line

                        .WriteStartElement("SalesInvoiceProductLine")

                        .WriteStartElement("ProductIdentifier")

                        If invoiceLine.ProductIdentifierType > 0 Then

                            Select Case invoiceLine.ProductIdentifierType
                                Case NetvisorInvoiceProductLine.productIdentifierTypes.EXTERNAL_IDENTIFIER
                                    .WriteAttributeString("type", "customer")

                                Case NetvisorInvoiceProductLine.productIdentifierTypes.NETVISOR_IDENTIFIER
                                    .WriteAttributeString("type", "netvisor")

                                Case Else
                                    Throw New ApplicationException("Unkown product identifier type: " & invoiceLine.ProductIdentifierType)

                            End Select

                        Else
                            .WriteAttributeString("type", "customer")

                        End If

                        .WriteString(invoiceLine.ProductIdentifier)
                        .WriteEndElement()

                        .WriteStartElement("ProductName")
                        .WriteString(invoiceLine.ProductName)
                        .WriteEndElement()

                        .WriteStartElement("ProductUnitPrice")

                        Dim vatType As String
                        If invoiceLine.productUnitPriceIsGross Then
                            vatType = "gross"
                        Else
                            vatType = "net"
                        End If

                        .WriteAttributeString("type", vatType)
                        .WriteString(invoiceLine.ProductUnitPrice.ToString())
                        .WriteEndElement()

                        Dim vatCode As String = vbNullString
                        Select Case invoiceLine.productVatCode
                            Case util.VatCode.vatCodes.DOMESTIC_PURCHASE
                                vatCode = util.VatCode.DOMESTIC_PURCHASE

                            Case util.VatCode.vatCodes.DOMESTIC_SALES
                                vatCode = util.VatCode.DOMESTIC_SALES

                            Case util.VatCode.vatCodes.EU_PURCHASE
                                vatCode = util.VatCode.EU_PURCHASE

                            Case util.VatCode.vatCodes.EU_SALES
                                vatCode = util.VatCode.EU_SALES

                            Case util.VatCode.vatCodes.EU_SERVICE_PURCHASE
                                vatCode = util.VatCode.EU_SERVICE_PURCHASE

                            Case util.VatCode.vatCodes.HUNDREDPERCENT_DEDUCTED_TAX
                                vatCode = util.VatCode.HUNDREDPERCENT_DEDUCTED_TAX

                            Case util.VatCode.vatCodes.NO_VAT_HANDLING
                                vatCode = util.VatCode.NO_VAT_HANDLING

                            Case util.VatCode.vatCodes.NON_EU_PURCHASE
                                vatCode = util.VatCode.NON_EU_PURCHASE

                            Case util.VatCode.vatCodes.NON_EU_SALES
                                vatCode = util.VatCode.NON_EU_SALES

                            Case util.VatCode.vatCodes.EU_SERVICE_SALES_312
                                vatCode = util.VatCode.EU_SERVICE_SALES_312

                            Case util.VatCode.vatCodes.EU_SERVICE_SALES_309
                                vatCode = util.VatCode.EU_SERVICE_SALES_309

                            Case util.VatCode.vatCodes.NO_TAX_SALES
                                vatCode = util.VatCode.NO_TAX_SALES

                            Case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_PURCHASE
                                vatCode = util.VatCode.NO_DEDUCTIBLE_EU_PURCHASE

                            Case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_SERVICEPURHASE
                                vatCode = util.VatCode.NO_DEDUCTIBLE_EU_SERVICEPURHASE

                            Case Else
                                ' päästetään läpi. jos alv-koodia ei anneta, niin sitten 
                                ' rajapinta hakee tiliöintiehdotuksen takaa
                        End Select

                        .WriteStartElement("ProductVatPercentage")

                        If Not String.IsNullOrEmpty(vatCode) Then
                            .WriteAttributeString("vatcode", vatCode)
                        End If

                        .WriteString(invoiceLine.ProductVatPercentage.ToString())
                        .WriteEndElement()

                        .WriteStartElement("SalesInvoiceProductlineQuantity")
                        .WriteString(invoiceLine.DeliveredQuantity.ToString())
                        .WriteEndElement()

                        If invoiceLine.LineDiscountPercentage <> 0 Then
                            .WriteElementString("SalesInvoiceProductLineDiscountPercentage", invoiceLine.LineDiscountPercentage)
                        End If

                        If Len(invoiceLine.LineText) > 0 Then
                            .WriteStartElement("SalesInvoiceProductLineFreeText")
                            .WriteString(invoiceLine.LineText)
                            .WriteEndElement()
                        End If

                        If invoiceLine.LineVatSum.HasValue Then
                            .WriteElementString("SalesInvoiceProductLineVatSum", invoiceLine.LineVatSum)
                        End If

                        If invoiceLine.LineSum.HasValue Then
                            .WriteElementString("SalesInvoiceProductLineSum", invoiceLine.LineSum)
                        End If

                        If invoiceLine.AccountingSuggestionAccountNumber > 0 Then
                            .WriteElementString("AccountingAccountSuggestion", invoiceLine.AccountingSuggestionAccountNumber)
                        End If

                        If invoiceLine.skipAccrual Then
                            .WriteElementString("SkipAccrual", "1")
                        End If

                        For Each dimension As NetvisorDimension In invoiceLine.dimensions
                            .WriteStartElement("Dimension")
                            .WriteElementString("DimensionName", dimension.dimensionName)
                            .WriteStartElement("DimensionItem")

                            If Len(dimension.integrationDimensionDetailGuid) > 0 Then
                                .WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid)
                            End If

                            .WriteValue(dimension.dimensionDetail)
                            .WriteEndElement() '/DimensionItem

                            If dimension.dimensionDetailMetaDataList.Count > 0 Then
                                For Each value As String In dimension.dimensionDetailMetaDataList
                                    .WriteStartElement("Metadata")
                                    .WriteElementString("data", value)
                                    .WriteEndElement() '/Metadata
                                Next
                            End If

                            .WriteEndElement() '/Dimension
                        Next

                        .WriteEndElement() '/salesinvoiceproductline
                    End If

                    .WriteEndElement() '/invoiceline
                Next

                .WriteEndElement() '/invoicelines

                If invoice.invoiceVoucherLines.Count > 0 Then

                    .WriteStartElement("InvoiceVoucherLines")

                    For Each voucherLine As NetvisorInvoiceVoucherLine In invoice.invoiceVoucherLines
                        .WriteStartElement("VoucherLine")

                        .WriteStartElement("LineSum")

                        If voucherLine.LineSumType = NetvisorInvoiceVoucherLine.lineSumTypes.NET Then
                            .WriteAttributeString("type", "net")
                        Else
                            .WriteAttributeString("type", "gross")
                        End If

                        .WriteString(voucherLine.lineSum)
                        .WriteEndElement()

                        .WriteStartElement("Description")
                        .WriteString(voucherLine.LineDescription)
                        .WriteEndElement()

                        .WriteStartElement("AccountNumber")
                        .WriteString(voucherLine.AccountNumber)
                        .WriteEndElement()

                        .WriteStartElement("VatPercent")
                        .WriteAttributeString("vatcode", voucherLine.vatCode)
                        .WriteString(voucherLine.vatClass)
                        .WriteEndElement()

                        If voucherLine.skipAccrual Then
                            .WriteElementString("SkipAccrual", "1")
                        End If

                        If voucherLine.Dimensions.Count > 0 Then

                            For Each dimension As NetvisorDimension In voucherLine.Dimensions

                                .WriteStartElement("Dimension")

                                .WriteElementString("DimensionName", dimension.dimensionName)
                                .WriteStartElement("DimensionItem")

                                If Len(dimension.integrationDimensionDetailGuid) > 0 Then
                                    .WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid)
                                End If

                                .WriteValue(dimension.dimensionDetail)
                                .WriteEndElement() '/DimensionItem

                                If dimension.dimensionDetailMetaDataList.Count > 0 Then
                                    For Each value As String In dimension.dimensionDetailMetaDataList
                                        .WriteStartElement("Metadata")
                                        .WriteElementString("data", value)
                                        .WriteEndElement() '/Metadata
                                    Next
                                End If

                                .WriteEndElement() '/Dimension

                            Next

                        ElseIf Not voucherLine.dimensionName = vbNullString And Not voucherLine.dimensionItem = vbNullString Then

                            .WriteStartElement("Dimension")

                            .WriteStartElement("DimensionName")
                            .WriteString(voucherLine.dimensionName)
                            .WriteEndElement()

                            .WriteStartElement("DimensionItem")
                            .WriteString(voucherLine.dimensionItem)
                            .WriteEndElement()

                            .WriteEndElement() '/Dimension
                        End If

                        .WriteEndElement() '/VoucherLine
                    Next

                    .WriteEndElement() '/invoicevoucherlines
                End If

                If invoice.invoiceAccrualEntries.Count > 0 Then
                    .WriteStartElement("SalesInvoiceAccrual")

                    If invoice.OverrideDefaultSalesAccrualAccountNumber > 0 Then
                        .WriteElementString("OverrideDefaultSalesAccrualAccountNumber", invoice.OverrideDefaultSalesAccrualAccountNumber)
                    End If

                    If invoice.salesinvoiceAccrualType > 0 Then

                        Select Case invoice.salesinvoiceAccrualType

                            Case NetvisorInvoice.salesinvoiceAccrualTypes.useCustomVoucher
                                .WriteElementString("SalesinvoiceAccrualType", "custom")

                            Case Else
                                .WriteElementString("SalesinvoiceAccrualType", "default")

                        End Select

                    End If

                    For Each entry As NetvisorInvoiceAccrualEntry In invoice.invoiceAccrualEntries
                        .WriteStartElement("AccrualVoucherEntry")

                        .WriteElementString("Month", entry.month)
                        .WriteElementString("Year", entry.year)
                        .WriteElementString("Sum", entry.sum)

                        .WriteEndElement() ' /AccrualVoucherEntry
                    Next

                    .WriteEndElement() ' /SalesInvoiceAccrual
                End If

                If invoice.invoiceAttachments.Count > 0 Then
                    .WriteStartElement("SalesInvoiceAttachments")

                    For Each attachment As NetvisorAttachment In invoice.invoiceAttachments
                        .WriteStartElement("SalesInvoiceAttachment")

                        .WriteElementString("MimeType", attachment.mimeType)
                        .WriteElementString("AttachmentDescription", attachment.description)
                        .WriteElementString("Filename", attachment.fileName)

                        .WriteStartElement("Documentdata")

                        If attachment.type = NetvisorAttachment.AttachmentTypes.finvoice Then
                            .WriteAttributeString("type", "finvoice")
                        End If

                        .WriteString(Convert.ToBase64String(attachment.attachmentData))
                        .WriteEndElement() '/ Documentdata

                        If attachment.printByDefaultOnSalesInvoice Then
                            .WriteElementString("PrintByDefault", "1")

                        End If

                        .WriteEndElement() ' /SalesInvoiceAttachment
                    Next

                    .WriteEndElement() ' /SalesInvoiceAttachments
                End If

                If invoice.invoiceCustomTags.Count > 0 Then
                    .WriteStartElement("CustomTags")

                    For Each tag As NetvisorInvoiceCustomTag In invoice.invoiceCustomTags
                        .WriteStartElement("Tag")

                        .WriteElementString("TagName", tag.name)

                        .WriteStartElement("TagValue")

                        Dim tagDataType As String
                        Select Case tag.valueDataType
                            Case NetvisorInvoiceCustomTag.CustomTagDataTypes.date
                                tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_DATE

                            Case NetvisorInvoiceCustomTag.CustomTagDataTypes.enum
                                tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_ENUM

                            Case NetvisorInvoiceCustomTag.CustomTagDataTypes.float
                                tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_FLOAT

                            Case NetvisorInvoiceCustomTag.CustomTagDataTypes.text
                                tagDataType = NetvisorInvoiceCustomTag.ATTRIBUTE_DATATYPE_TEXT

                            Case Else
                                Throw New ApplicationException("Invalid customtag datatype: " & tag.valueDataType)
                        End Select

                        .WriteAttributeString("datatype", tagDataType)
                        .WriteString(tag.value)
                        .WriteEndElement() ' /TagValue

                        .WriteEndElement() ' /Tag
                    Next

                    .WriteEndElement() ' /CustomTags
                End If

                .WriteEndElement() '/salesinvoice
                .WriteEndElement() '/root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace