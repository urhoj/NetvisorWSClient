'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisorin eScan-dokumentin
'

Namespace NetvisorWSClient.communication.escan
    Public Class EScanDocument

        Public Const TARGET_SALES_INVOICE As String = "salesinvoice"
        Public Const TARGET_PURCHASE_INVOICE As String = "purchaseinvoice"
        Public Const TARGET_TRIP_EXPENSE_MONEY_TRANSFER As String = "tripexpensemoneytransfer"

        Public Enum EScanDocumentTargets As Integer
            SALES_INVOICE = 1
            PURCHASE_INVOICE = 2
            TRIP_EXPENSE_MONEY_TRANSFER = 3
        End Enum

        Public Enum CompressionSettings As Integer
            GZIP = 1
            NO_COMPRESSION = 2
        End Enum

        Public Enum SupportedDocumentMimeTypes As Integer
            IMAGE_BMP = 1
            IMAGE_EMF = 2
            IMAGE_EXIF = 3
            IMAGE_GIF = 4
            IMAGE_ICON = 5
            IMAGE_JPEG = 6
            IMAGE_PNG = 7
            IMAGE_TIFF = 8
            APPLICATION_PDF = 9
            IMAGE_WMF = 10
        End Enum

        Private m_Version As Integer
        Private m_DocumentType As String
        Private m_Description As String
        Private m_DocumentMimeType As String
        Private m_Compression As CompressionSettings
        Private m_documentData As Byte()
        Private m_fileSize As Integer
        Private m_targets As New ArrayList

        Public Property Version() As Integer
            Get
                Return m_Version
            End Get
            Set(ByVal Value As Integer)
                m_Version = Value
            End Set
        End Property

        Public Property DocumentType() As String
            Get
                Return m_DocumentType
            End Get
            Set(ByVal Value As String)
                m_DocumentType = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal Value As String)
                m_Description = Value
            End Set
        End Property

        Public Property DocumentMimeType() As SupportedDocumentMimeTypes
            Get
                Return m_DocumentMimeType
            End Get
            Set(ByVal Value As SupportedDocumentMimeTypes)
                m_DocumentMimeType = Value
            End Set
        End Property

        Public Property Compression() As CompressionSettings
            Get
                Return m_Compression
            End Get
            Set(ByVal Value As CompressionSettings)
                m_Compression = Value
            End Set
        End Property

        Public Property documentData() As Byte()
            Get
                Return m_documentData
            End Get
            Set(ByVal Value As Byte())
                m_documentData = Value
            End Set
        End Property

        Public Property fileSize() As Integer
            Get
                Return m_fileSize
            End Get
            Set(ByVal Value As Integer)
                m_fileSize = Value
            End Set
        End Property

        Public ReadOnly Property targets() As ArrayList
            Get
                Return m_targets
            End Get
        End Property

        Public Sub addTarget(ByVal target As EScanDocumentTargets, ByVal targetIdentifier As Integer)
            m_targets.Add(New Integer() {target, targetIdentifier})
        End Sub
    End Class
End Namespace