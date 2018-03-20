'
'
'
' Revisio $Revision$
'
' Ilmentää netvisoriin vietävän ostolaskun
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorPurchaseInvoice

        Public Const MAX_VENDOR_NAME_LENGTH As Integer = 250
        Public Const MAX_VENDOR_ADDRESSLINE_LENGTH As Integer = 80
        Public Const MAX_VENDOR_POST_NUMBER_LENGTH As Integer = 50
        Public Const MAX_VENDOR_TOWN_LENGTH As Integer = 50
        Public Const MAX_VENDOR_COUNTRY_LENGTH As Integer = 50
        Public Const MAX_VENDOR_PHONENUMBER_LENGTH As Integer = 80
        Public Const MAX_VENDOR_FAXNUMBER_LENGTH As Integer = 80
        Public Const MAX_VENDOR_EMAIL_LENGTH As Integer = 80
        Public Const MAX_VENDOR_HOMEPAGE_LENGTH As Integer = 80
        Public Const MAX_INVOICE_BANKREFERENCENUMBER_LENGTH As Integer = 70
        Public Const MAX_INVOICE_OURREFERENCE_LENGTH As Integer = 200
        Public Const MAX_INVOICE_YOURREFERENCE_LENGTH As Integer = 200
        Public Const MAX_INVOICE_DELIVERYTERMS_LENGTH As Integer = 255
        Public Const MAX_INVOICE_DELIVERYMETHOD_LENGTH As Integer = 255
        Public Const MAX_INVOICE_COMMENT_LENGTH As Integer = 255

        Public Enum invoiceSources As Integer
            MANUAL = 1
            FINVOICE = 2
			CLARUS = 3
            ITELLA = 4
            MAVENTA_SCAN = 5
            MAVENTA_FINVOICE = 6
        End Enum

        Public Enum NetvisorPurchaseInvoiceRounds As Integer
            UNHANDLED = 0
            CONTENTSUPERVISORED = 2
            ACCEPTED = 4
        End Enum

        Private m_invoiceNumber As String
        Private m_invoiceDate As Date
        Private m_valueDate As Date
        Private m_dueDate As Date
        Private m_InvoiceRound As NetvisorPurchaseInvoiceRounds
        Private m_vendorName As String
        Private m_vendorAddressline As String
        Private m_vendorPostNumber As String
        Private m_vendorCity As String
        Private m_vendorCountry As String
        Private m_vendorPhoneNumber As String
        Private m_vendorFaxNumber As String
        Private m_vendorEmail As String
        Private m_vendorHomepage As String
        Private m_amount As Decimal
        Private m_accountNumber As String
        Private m_organizationIdentifier As String
        Private m_invoiceSource As invoiceSources
        Private m_deliveryDate As Date
        Private m_overdueFinePercent As Decimal
        Private m_bankReferenceNumber As String
        Private m_ourReference As String
        Private m_yourReference As String
        Private m_currencyCode As String
        Private m_deliveryTerms As String
        Private m_deliveryMethod As String
        Private m_comment As String
        Private m_checkSum As String
        Private m_pdfExtraPages As Integer
        Private m_findNextOpenDateIfInLockedPeriod As Boolean
        Private m_NetvisorKey As Integer
        Private m_readyForAccounting As Boolean

        Private m_invoiceLines As New ArrayList()
        Private m_attachments As New ArrayList()
        Private m_invoiceCommentLines As New ArrayList()
        Private m_invoiceSubLines = New ArrayList()

        Private m_lineCounter As Integer = 1


        Public Property NetvisorKey() As Integer
            Get
                Return m_NetvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_NetvisorKey = Value
            End Set
        End Property

        Public Property findNextOpenDateIfInLockedPeriod() As Boolean
            Get
                Return m_findNextOpenDateIfInLockedPeriod
            End Get
            Set(ByVal Value As Boolean)
                m_findNextOpenDateIfInLockedPeriod = Value
            End Set
        End Property

        Public Property comment() As String
            Get
                Return m_comment
            End Get
            Set(ByVal Value As String)
                m_comment = Value
            End Set
        End Property

        Public Property pdfExtraPages() As Integer
            Get
                Return m_pdfExtraPages
            End Get
            Set(ByVal Value As Integer)
                m_pdfExtraPages = Value
            End Set
        End Property

        Public Property checkSum() As String
            Get
                Return m_checkSum
            End Get
            Set(ByVal Value As String)
                m_checkSum = Value
            End Set
        End Property

        Public Property organizationIdentifier() As String
            Get
                Return m_organizationIdentifier
            End Get
            Set(ByVal Value As String)
                m_organizationIdentifier = Value
            End Set
        End Property

        Public Property invoiceSource() As invoiceSources
            Get
                Return m_invoiceSource
            End Get
            Set(ByVal Value As invoiceSources)
                m_invoiceSource = Value
            End Set
        End Property

        Public Property deliveryDate() As Date
            Get
                Return m_deliveryDate
            End Get
            Set(ByVal Value As Date)
                m_deliveryDate = Value
            End Set
        End Property

        Public Property overdueFinePercent() As Decimal
            Get
                Return m_overdueFinePercent
            End Get
            Set(ByVal Value As Decimal)
                m_overdueFinePercent = Value
            End Set
        End Property

        Public Property bankReferenceNumber() As String
            Get
                Return m_bankReferenceNumber
            End Get
            Set(ByVal Value As String)
                m_bankReferenceNumber = Value
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

        Public Property currencyCode() As String
            Get
                Return m_currencyCode
            End Get
            Set(ByVal Value As String)
                m_currencyCode = Value
            End Set
        End Property

        Public Property deliveryTerms() As String
            Get
                Return m_deliveryTerms
            End Get
            Set(ByVal Value As String)
                m_deliveryTerms = Value
            End Set
        End Property

        Public Property deliveryMethod() As String
            Get
                Return m_deliveryMethod
            End Get
            Set(ByVal Value As String)
                m_deliveryMethod = Value
            End Set
        End Property

        Public Property vendorCountry() As String
            Get
                Return m_vendorCountry
            End Get
            Set(ByVal Value As String)
                m_vendorCountry = Value
            End Set
        End Property

        Public Property vendorPhoneNumber() As String
            Get
                Return m_vendorPhoneNumber
            End Get
            Set(ByVal Value As String)
                m_vendorPhoneNumber = Value
            End Set
        End Property

        Public Property vendorFaxNumber() As String
            Get
                Return m_vendorFaxNumber
            End Get
            Set(ByVal Value As String)
                m_vendorFaxNumber = Value
            End Set
        End Property

        Public Property vendorEmail() As String
            Get
                Return m_vendorEmail
            End Get
            Set(ByVal Value As String)
                m_vendorEmail = Value
            End Set
        End Property

        Public Property vendorHomepage() As String
            Get
                Return m_vendorHomepage
            End Get
            Set(ByVal Value As String)
                m_vendorHomepage = Value
            End Set
        End Property

        Public Property InvoiceNumber() As String
            Get
                Return m_invoiceNumber
            End Get
            Set(ByVal Value As String)
                m_invoiceNumber = Value
            End Set
        End Property

        Public Property InvoiceDate() As Date
            Get
                Return m_invoiceDate
            End Get
            Set(ByVal Value As Date)
                m_invoiceDate = Value
            End Set
        End Property

        Public Property ValueDate() As Date
            Get
                Return m_valueDate
            End Get
            Set(ByVal Value As Date)
                m_valueDate = Value
            End Set
        End Property

        Public Property DueDate() As Date
            Get
                Return m_dueDate
            End Get
            Set(ByVal Value As Date)
                m_dueDate = Value
            End Set
        End Property

        Public Property InvoiceRound() As NetvisorPurchaseInvoiceRounds
            Get
                Return m_InvoiceRound
            End Get
            Set(ByVal value As NetvisorPurchaseInvoiceRounds)
                m_InvoiceRound = value
            End Set
        End Property

        Public Property VendorName() As String
            Get
                Return m_vendorName
            End Get
            Set(ByVal Value As String)
                m_vendorName = Value
            End Set
        End Property

        Public Property VendorAddressline() As String
            Get
                Return m_vendorAddressline
            End Get
            Set(ByVal Value As String)
                m_vendorAddressline = Value
            End Set
        End Property

        Public Property VendorPostNumber() As String
            Get
                Return m_vendorPostNumber
            End Get
            Set(ByVal Value As String)
                m_vendorPostNumber = Value
            End Set
        End Property

        Public Property VendorCity() As String
            Get
                Return m_vendorCity
            End Get
            Set(ByVal Value As String)
                m_vendorCity = Value
            End Set
        End Property

        Public Property Amount() As Decimal
            Get
                Return m_amount
            End Get
            Set(ByVal Value As Decimal)
                m_amount = Value
            End Set
        End Property

        Public Property AccountNumber() As String
            Get
                Return m_accountNumber
            End Get
            Set(ByVal Value As String)
                m_accountNumber = Value
            End Set
        End Property

        Public ReadOnly Property invoiceSubLines() As ArrayList
            Get
                Return m_invoiceSubLines
            End Get
        End Property

        Public Property readyForAccounting As Boolean
            Get
                Return m_readyForAccounting
            End Get
            Set(value As Boolean)
                m_readyForAccounting = value
            End Set
        End Property

        Public ReadOnly Property invoiceLines() As ArrayList
            Get
                Return m_invoiceLines
            End Get
        End Property


        Public Sub addInvoiceLine(ByVal line As NetvisorPurchaseInvoiceLine)
            If line.sort = 0 Then
                line.sort = m_lineCounter
            ElseIf line.sort > m_lineCounter Then
                m_lineCounter = line.sort
            End If

            m_lineCounter += 1

            m_invoiceLines.Add(line)
        End Sub

        Public Sub clearInvoiceLines()
            m_invoiceLines.Clear()
        End Sub

        Public ReadOnly Property attachments() As ArrayList
            Get
                Return m_attachments
            End Get
        End Property

        Public Sub addAttachment(ByVal attachment As NetvisorAttachment)
            m_attachments.Add(attachment)
        End Sub

        Public Sub clearAttachments()
            m_attachments.Clear()
        End Sub

        Public ReadOnly Property invoiceCommentLines() As ArrayList
            Get
                Return m_invoiceCommentLines
            End Get
        End Property

        Public Sub addInvoiceCommentLine(ByVal line As NetvisorPurchaseInvoiceCommentLine)
            If line.sort = 0 Then
                line.sort = m_lineCounter
            ElseIf line.sort > m_lineCounter Then
                m_lineCounter = line.sort
            End If

            m_lineCounter += 1

            m_invoiceCommentLines.Add(line)
        End Sub

        Public Sub clearInvoiceCommentLines()
            m_invoiceCommentLines.Clear()
        End Sub

        Public Sub addInvoiceSubLine(ByVal line As NetvisorPurchaseInvoiceSubLine)
            If line.sort = 0 Then
                line.sort = m_lineCounter
            ElseIf line.sort > m_lineCounter Then
                m_lineCounter = line.sort
            End If

            m_lineCounter += 1

            m_invoiceSubLines.Add(line)
        End Sub

        Public Sub clearInvoiceSubLines()
            m_invoiceSubLines.Clear()
        End Sub

    End Class
End Namespace