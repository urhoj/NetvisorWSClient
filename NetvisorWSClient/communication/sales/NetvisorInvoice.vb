'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisorin myyntilaskun
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorInvoice

        Public Const DIRECT_DEBIT_LINK_ERROR_MODE_IGNORE As String = "ignore_error"
        Public Const DIRECT_DEBIT_LINK_ERROR_MODE_FAIL As String = "fail_on_error"

        Public Const NETVISOR_TEMP_CUSTOMER_CODE As String = "TEMP"

        Public Const TAX_HANDLING_TYPE_COUNTRY_GROUP As String = "countrygroup"
        Public Const TAX_HANDLING_TYPE_DOMESTIC_CONSTRUCTION_SERVICES As String = "domesticconstructionservice"
        Public Const TAX_HANDLING_TYPE_NO_VAT_HANDLING As String = "notaxhandling"

        Public Enum NetvisorInvoiceTypes
            invoice = 1
            order = 2
        End Enum

        Public Enum NetvisorInvoiceStatuses
            UnSent = 9
            Open = 1
        End Enum

        Public Enum NetvisorInvoiceTaxHandlingTypes As Integer
            countryGroup = 1
            domesticConstructionService = 2
            noVatHandling = 3
        End Enum

        Public Enum NetvisorOrderStatuses
            Delivered = 8
            unDelivered = 9
        End Enum

        Public Enum CustomerIdentifierSource As Integer
            EXTERNAL_IDENTIFIER = 1
            NETVISOR_IDENTIFIER = 2
        End Enum

        Public Enum PrintChannelFormatSource As Integer
            EXTERNAL_IDENTIFIER = 1
            NETVISOR_IDENTIFIER = 2
        End Enum

        Public Enum SecondNameSource As Integer
            EXTERNAL_IDENTIFIER = 1
            NETVISOR_IDENTIFIER = 2
        End Enum

        Public Enum paymentTermCashDiscountTypes As Integer
            PERCENTAGE = 1
        End Enum

        Public Enum invoiceSubjectTypes As Integer
            memberInvoice = 1
        End Enum

        Public Enum salesinvoiceAccrualTypes As Integer
            useCustomVoucher = 1
            [default] = 2
        End Enum

        Private m_requestNetvisorRecipientOrganisationID As FinnishOrganisationIdentifier

        Private m_invoiceLines As New ArrayList
        Private m_invoiceCustomTags As New ArrayList
        Private m_invoiceVoucherLines As New ArrayList
        Private m_invoiceAccrualEntries As New ArrayList
        Private m_invoiceAttachments As New ArrayList

        Private m_invoiceType As NetvisorInvoiceTypes
        Private m_InvoiceStatus As NetvisorInvoiceStatuses
        Private m_InvoiceNumber As String
        Private m_InvoiceDate As Date
        Private m_DeliveryDate As Date
        Private m_ReferenceNumber As ReferenceNumber
        Private m_sellerName As String
        Private m_sellerIdentifier As Integer

        Private m_CustomerIdentifierType As CustomerIdentifierSource
        Private m_CustomerIdentifier As String
        Private m_CustomerName As String
        Private m_CustomerNameExtension As String
        Private m_CustomerAddress As String
        Private m_CustomerPostNumber As String
        Private m_CustomerTown As String
        Private m_CustomerCountryISO3166Code As String

        Private m_DeliveryName As String
        Private m_DeliveryAddress As String
        Private m_DeliveryPostNumber As String
        Private m_DeliveryTown As String
        Private m_DeliveryCountryISO3166Code As String

        Private m_DeliveryTerm As String
        Private m_DeliveryMethod As String

        Private m_invoiceSum As Decimal?
        Private m_iso4217currencycode As String
        Private m_overrideCurrencyRate As Decimal
        Private m_verifyingAttachmentData As Byte()
        Private m_salesInvoiceFreeTextBeforeLines As String
        Private m_salesInvoiceFreeTextAfterLines As String
        Private m_ourReference As String
        Private m_yourReference As String
        Private m_privateComment As String
        Private m_taxHandlingType As NetvisorInvoiceTaxHandlingTypes

        Private m_PaymentTermNetDays As Integer
        Private m_paymentTermCashDiscountDays As Object
        Private m_paymentTermCashDiscount As Object
        Private m_paymentTermCashDiscountType As paymentTermCashDiscountTypes

        Private m_TryDirectDebitLink As Boolean
        Private m_IgnoreDirectDebitLinkError As Boolean

        Private m_OverrideVoucherSalesReceivablesAccountNumber As Integer
        Private m_OverrideDefaultSalesAccrualAccountNumber As Integer
        Private m_salesinvoiceAccrualType As salesinvoiceAccrualTypes

        Private m_printChannelFormat As String
        Private m_printChannelFormatType As PrintChannelFormatSource

        Private m_secondname As String
        Private m_secondnameType As SecondNameSource

        Private m_invoiceSubjectType As invoiceSubjectTypes
        Private m_OverrideRateOfOverdue As Decimal?

        Public Sub New()
            m_CustomerIdentifierType = CustomerIdentifierSource.EXTERNAL_IDENTIFIER
        End Sub

        Public Property requestNetvisorRecipientOrganisationID() As FinnishOrganisationIdentifier
            Get
                Return m_requestNetvisorRecipientOrganisationID
            End Get
            Set(ByVal value As FinnishOrganisationIdentifier)
                m_requestNetvisorRecipientOrganisationID = value
            End Set
        End Property

        Public Property invoiceType() As NetvisorInvoiceTypes
            Get
                Return m_invoiceType
            End Get
            Set(ByVal Value As NetvisorInvoiceTypes)
                m_invoiceType = Value
            End Set
        End Property

        Public Property InvoiceStatus() As String
            Get
                Return m_InvoiceStatus
            End Get
            Set(ByVal value As String)
                m_InvoiceStatus = value
            End Set
        End Property

        Public Property InvoiceNumber() As String
            Get
                Return m_InvoiceNumber
            End Get
            Set(ByVal value As String)
                m_InvoiceNumber = value
            End Set
        End Property

        Public Property InvoiceDate() As Date
            Get
                Return m_InvoiceDate
            End Get
            Set(ByVal value As Date)
                m_InvoiceDate = value
            End Set
        End Property

        Public Property DeliveryDate() As Date
            Get
                Return m_DeliveryDate
            End Get
            Set(ByVal value As Date)
                m_DeliveryDate = value
            End Set
        End Property

        Public Property ReferenceNumber() As ReferenceNumber
            Get
                Return m_ReferenceNumber
            End Get
            Set(ByVal value As ReferenceNumber)
                m_ReferenceNumber = value
            End Set
        End Property

        Public Property sellerName() As String
            Get
                Return m_sellerName
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 50 Then
                    Throw New ApplicationException("Sellername too long")
                Else
                    m_sellerName = Value
                End If
            End Set
        End Property

        Public Property sellerIdentifier() As Integer
            Get
                Return m_sellerIdentifier
            End Get
            Set(ByVal Value As Integer)
                m_sellerIdentifier = Value
            End Set
        End Property

        Public Property CustomerIdentifierType() As CustomerIdentifierSource
            Get
                Return m_CustomerIdentifierType
            End Get
            Set(ByVal value As CustomerIdentifierSource)
                m_CustomerIdentifierType = value
            End Set
        End Property

        Public Property CustomerIdentifier() As String
            Get
                Return m_CustomerIdentifier
            End Get
            Set(ByVal value As String)
                m_CustomerIdentifier = value
            End Set
        End Property

        Public Property CustomerName() As String
            Get
                Return m_CustomerName
            End Get
            Set(ByVal value As String)
                If Len(value) > 250 Then
                    Throw New ApplicationException("Customername too long")
                Else
                    m_CustomerName = value
                End If
            End Set
        End Property

        Public Property CustomerAddress() As String
            Get
                Return m_CustomerAddress
            End Get
            Set(ByVal value As String)
                If Len(value) > 100 Then
                    Throw New ApplicationException("Customeraddress too long")
                Else
                    m_CustomerAddress = value
                End If
            End Set
        End Property

        Public Property CustomerPostNumber() As String
            Get
                Return m_CustomerPostNumber
            End Get
            Set(ByVal value As String)
                m_CustomerPostNumber = value
            End Set
        End Property

        Public Property CustomerTown() As String
            Get
                Return m_CustomerTown
            End Get
            Set(ByVal value As String)
                m_CustomerTown = value
            End Set
        End Property

        Public Property CustomerCountryISO3166Code() As String
            Get
                Return m_CustomerCountryISO3166Code
            End Get
            Set(ByVal value As String)
                m_CustomerCountryISO3166Code = value
            End Set
        End Property

        Public Property CustomerNameExtension() As String
            Get
                Return m_CustomerNameExtension
            End Get
            Set(ByVal Value As String)
                m_CustomerNameExtension = Value
            End Set
        End Property

        Public Property DeliveryName() As String
            Get
                Return m_DeliveryName
            End Get
            Set(ByVal value As String)
                If Len(value) > 250 Then
                    Throw New ApplicationException("Deliveryname too long")
                Else
                    m_DeliveryName = value
                End If
            End Set
        End Property

        Public Property DeliveryAddress() As String
            Get
                Return m_DeliveryAddress
            End Get
            Set(ByVal value As String)
                If Len(value) > 100 Then
                    Throw New ApplicationException("Deliveryaddress too long")
                Else
                    m_DeliveryAddress = value
                End If
            End Set
        End Property

        Public Property DeliveryPostNumber() As String
            Get
                Return m_DeliveryPostNumber
            End Get
            Set(ByVal value As String)
                m_DeliveryPostNumber = value
            End Set
        End Property

        Public Property DeliveryTown() As String
            Get
                Return m_DeliveryTown
            End Get
            Set(ByVal value As String)
                m_DeliveryTown = value
            End Set
        End Property

        Public Property DeliveryCountryISO3166Code() As String
            Get
                Return m_DeliveryCountryISO3166Code
            End Get
            Set(ByVal value As String)
                m_DeliveryCountryISO3166Code = value
            End Set
        End Property


        Public Property DeliveryTerm() As String
            Get
                Return m_DeliveryTerm
            End Get
            Set(ByVal Value As String)
                m_DeliveryTerm = Value
            End Set
        End Property


        Public Property DeliveryMethod() As String
            Get
                Return m_DeliveryMethod
            End Get
            Set(ByVal Value As String)
                m_DeliveryMethod = Value
            End Set
        End Property

        Public Property taxHandlingType() As NetvisorInvoiceTaxHandlingTypes
            Get
                Return m_taxHandlingType
            End Get
            Set(ByVal Value As NetvisorInvoiceTaxHandlingTypes)
                m_taxHandlingType = Value
            End Set
        End Property

        Public Property PaymentTermNetDays() As Integer
            Get
                Return m_PaymentTermNetDays
            End Get
            Set(ByVal value As Integer)
                m_PaymentTermNetDays = value
            End Set
        End Property

        Public Property paymentTermCashDiscountDays() As Object
            Get
                Return m_paymentTermCashDiscountDays
            End Get
            Set(ByVal Value As Object)
                m_paymentTermCashDiscountDays = Value
            End Set
        End Property


        Public Property paymentTermCashDiscount() As Object
            Get
                Return m_paymentTermCashDiscount
            End Get
            Set(ByVal Value As Object)
                m_paymentTermCashDiscount = Value
            End Set
        End Property


        Public Property paymentTermCashDiscountType() As paymentTermCashDiscountTypes
            Get
                Return m_paymentTermCashDiscountType
            End Get
            Set(ByVal Value As paymentTermCashDiscountTypes)
                m_paymentTermCashDiscountType = Value
            End Set
        End Property

        Public Property InvoiceSum() As Decimal?
            Get
                Return m_invoiceSum
            End Get
            Set(ByVal value As Decimal?)
                m_invoiceSum = value
            End Set
        End Property

        Public Property iso4217currencycode() As String
            Get
                Return m_iso4217currencycode
            End Get
            Set(ByVal Value As String)
                m_iso4217currencycode = Value
            End Set
        End Property

        Public Property overrideCurrencyRate() As Decimal
            Get
                Return m_overrideCurrencyRate
            End Get
            Set(ByVal Value As Decimal)
                m_overrideCurrencyRate = Value
            End Set
        End Property

        Public Property VerifyingAttachmentData() As Byte()
            Get
                Return m_verifyingAttachmentData
            End Get
            Set(ByVal value As Byte())
                m_verifyingAttachmentData = value
            End Set
        End Property

        Public Property SalesInvoiceFreeTextBeforeLines() As String
            Get
                Return m_salesInvoiceFreeTextBeforeLines
            End Get
            Set(ByVal value As String)
                If Len(value) > 500 Then
                    Throw New ApplicationException("Freetext before invoicelines too long")
                Else
                    m_salesInvoiceFreeTextBeforeLines = value
                End If
            End Set
        End Property

        Public Property SalesInvoiceFreeTextAfterLines() As String
            Get
                Return m_salesInvoiceFreeTextAfterLines
            End Get
            Set(ByVal value As String)
                If Len(value) > 500 Then
                    Throw New ApplicationException("Freetext after invoicelines too long")
                Else
                    m_salesInvoiceFreeTextAfterLines = value
                End If
            End Set
        End Property

        Public Property ourReference() As String
            Get
                Return m_ourReference
            End Get
            Set(ByVal Value As String)
                m_ourReference = Value
            End Set
        End Property

        Public Property yourReference() As String
            Get
                Return m_yourReference
            End Get
            Set(ByVal Value As String)
                m_yourReference = Value
            End Set
        End Property

        Public Property privateComment() As String
            Get
                Return m_privateComment
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 255 Then
                    Throw New ApplicationException("Privatecomment too long")
                Else
                    m_privateComment = Value
                End If
            End Set
        End Property

        Public Property OverrideVoucherSalesReceivablesAccountNumber() As Integer
            Get
                Return m_OverrideVoucherSalesReceivablesAccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_OverrideVoucherSalesReceivablesAccountNumber = Value
            End Set
        End Property

        Public Property invoiceSubjectType() As invoiceSubjectTypes
            Get
                Return m_invoiceSubjectType
            End Get
            Set(ByVal Value As invoiceSubjectTypes)
                m_invoiceSubjectType = Value
            End Set
        End Property

        Public Property printChannelFormat() As String
            Get
                Return m_printChannelFormat
            End Get
            Set(ByVal Value As String)
                m_printChannelFormat = Value
            End Set
        End Property

        Public Property printChannelFormatType() As PrintChannelFormatSource
            Get
                Return m_printChannelFormatType
            End Get
            Set(ByVal Value As PrintChannelFormatSource)
                m_printChannelFormatType = Value
            End Set
        End Property


        Public Property secondname() As String
            Get
                Return m_secondname
            End Get
            Set(ByVal Value As String)
                m_secondname = Value
            End Set
        End Property

        Public Property secondnameType() As SecondNameSource
            Get
                Return m_secondnameType
            End Get
            Set(ByVal Value As SecondNameSource)
                m_secondnameType = Value
            End Set
        End Property

        Public ReadOnly Property invoiceLines() As ArrayList
            Get
                Return m_invoiceLines
            End Get
        End Property

        Public Sub addInvoiceLine(ByVal line As INetvisorInvoiceLine)
            m_invoiceLines.Add(line)
        End Sub

        Public Sub clearInvoiceLines()
            m_invoiceLines.Clear()
        End Sub

        Public ReadOnly Property invoiceAccrualEntries() As ArrayList
            Get
                Return m_invoiceAccrualEntries
            End Get
        End Property

        Public Sub addInvoiceAccrualEntry(ByVal entry As NetvisorInvoiceAccrualEntry)
            m_invoiceAccrualEntries.Add(entry)
        End Sub

        Public Sub clearInvoiceAccrualEntries()
            m_invoiceAccrualEntries.Clear()
        End Sub

        Public Property OverrideDefaultSalesAccrualAccountNumber() As Integer
            Get
                Return m_OverrideDefaultSalesAccrualAccountNumber
            End Get
            Set(ByVal Value As Integer)
                m_OverrideDefaultSalesAccrualAccountNumber = Value
            End Set
        End Property

        Public Property salesinvoiceAccrualType() As salesinvoiceAccrualTypes
            Get
                Return m_salesinvoiceAccrualType
            End Get
            Set(ByVal Value As salesinvoiceAccrualTypes)
                m_salesinvoiceAccrualType = Value
            End Set
        End Property

        Public ReadOnly Property invoiceCustomTags() As ArrayList
            Get
                Return m_invoiceCustomTags
            End Get
        End Property

        Public Property TryDirectDebitLink() As Boolean
            Get
                Return m_TryDirectDebitLink
            End Get
            Set(ByVal Value As Boolean)
                m_TryDirectDebitLink = Value
            End Set
        End Property

        Public Property IgnoreDirectDebitLinkError() As Boolean
            Get
                Return m_IgnoreDirectDebitLinkError
            End Get
            Set(ByVal Value As Boolean)
                m_IgnoreDirectDebitLinkError = Value
            End Set
        End Property

        Public Sub addInvoiceCustomTag(ByVal tag As NetvisorInvoiceCustomTag)
            m_invoiceCustomTags.Add(tag)
        End Sub

        Public Sub clearInvoiceCustomTags()
            m_invoiceCustomTags.Clear()
        End Sub

        Public ReadOnly Property invoiceVoucherLines() As ArrayList
            Get
                Return m_invoiceVoucherLines
            End Get
        End Property

        Public Property OverrideRateOfOverdue() As Decimal?
            Get
                Return m_OverrideRateOfOverdue
            End Get
            Set(ByVal Value As Decimal?)
                m_OverrideRateOfOverdue = Value
            End Set
        End Property


        Public Sub addInvoiceVoucherLine(ByVal line As NetvisorInvoiceVoucherLine)
            m_invoiceVoucherLines.Add(line)
        End Sub

        Public Sub clearInvoiceVoucherLines()
            m_invoiceVoucherLines.Clear()
        End Sub

        Public Function getInvoiceTotalAmountCalculatedFromProductLines() As Decimal
            Dim totalAmount As Decimal

            For Each line As INetvisorInvoiceLine In m_invoiceLines
                If TypeOf (line) Is NetvisorInvoiceProductLine Then
                    Dim invoiceLine As NetvisorInvoiceProductLine = line

                    If invoiceLine.productUnitPriceIsGross Then
                        totalAmount += Math.Round(invoiceLine.DeliveredQuantity * (invoiceLine.ProductUnitPrice - (invoiceLine.ProductUnitPrice * (invoiceLine.LineDiscountPercentage / 100))), 2, MidpointRounding.AwayFromZero)
                    Else
                        totalAmount += Math.Round(invoiceLine.DeliveredQuantity * (invoiceLine.ProductUnitPrice - (invoiceLine.ProductUnitPrice * (invoiceLine.LineDiscountPercentage / 100))) * (1 + invoiceLine.ProductVatPercentage / 100), 2, MidpointRounding.AwayFromZero)
                    End If
                End If
            Next

            Return totalAmount
        End Function

        Public Sub addAttachment(ByVal attachment As NetvisorAttachment)
            m_invoiceAttachments.Add(attachment)
        End Sub

        Public ReadOnly Property invoiceAttachments() As ArrayList
            Get
                Return m_invoiceAttachments
            End Get
        End Property

    End Class
End Namespace
