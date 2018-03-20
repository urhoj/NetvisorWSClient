'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin esim. ostolaskun, myyntilaskun tai tositteen mukana
' vietävän liitetiedoston
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.common
    Public Class NetvisorAttachment

        Public Enum AttachmentTypes As Integer
            pdf = 1
            finvoice = 2
        End Enum

        Public Enum AttachmentCategory As Integer
            invoiceImage = 1
            otherAttachment = 2
        End Enum

        Private m_attachmentData As Byte()
        Private m_description As String
        Private m_mimeType As String
        Private m_fileName As String
        Private m_printByDefaultOnSalesInvoice As Boolean
        Private m_type As AttachmentTypes
        Private m_purchaseInvoiceAttachmentCategory As AttachmentCategory


        Public Property purchaseInvoiceAttachmentCategory() As AttachmentCategory
            Get
                Return m_purchaseInvoiceAttachmentCategory
            End Get
            Set(ByVal Value As AttachmentCategory)
                m_purchaseInvoiceAttachmentCategory = Value
            End Set
        End Property

        Public Property type() As AttachmentTypes
            Get
                Return m_type
            End Get
            Set(ByVal Value As AttachmentTypes)
                m_type = Value
            End Set
        End Property

        Public Property attachmentData() As Byte()
            Get
                Return m_attachmentData
            End Get
            Set(ByVal Value As Byte())
                m_attachmentData = Value
            End Set
        End Property

        Public Property description() As String
            Get
                Return m_description
            End Get
            Set(ByVal Value As String)
                m_description = Value
            End Set
        End Property

        Public Property mimeType() As String
            Get
                Return m_mimeType
            End Get
            Set(ByVal Value As String)
                m_mimeType = Value
            End Set
        End Property

        Public Property fileName() As String
            Get
                Return m_fileName
            End Get
            Set(ByVal Value As String)
                m_fileName = Value
            End Set
        End Property

        Public Property printByDefaultOnSalesInvoice() As Boolean
            Get
                Return m_printByDefaultOnSalesInvoice
            End Get
            Set(ByVal Value As Boolean)
                m_printByDefaultOnSalesInvoice = Value
            End Set
        End Property

    End Class
End Namespace