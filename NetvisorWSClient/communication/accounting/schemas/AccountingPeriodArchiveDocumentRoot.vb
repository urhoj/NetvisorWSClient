'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("Root", IsNullable:=False)>
Partial Public Class AccountingPeriodArchiveDocumentXml

    Private responseStatusField As AccountingPeriodArchiveDocumentResponseStatus

    Private accountingPeriodArchiveDocumentField As RootAccountingPeriodArchiveDocument

    '''<remarks/>
    Public Property ResponseStatus() As AccountingPeriodArchiveDocumentResponseStatus
        Get
            Return Me.responseStatusField
        End Get
        Set
            Me.responseStatusField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AccountingPeriodArchiveDocument() As RootAccountingPeriodArchiveDocument
        Get
            Return Me.accountingPeriodArchiveDocumentField
        End Get
        Set
            Me.accountingPeriodArchiveDocumentField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("ResponseStatus", IsNullable:=False)>
Partial Public Class AccountingPeriodArchiveDocumentResponseStatus

    Private statusField As String

    Private timeStampField As String

    '''<remarks/>
    Public Property Status() As String
        Get
            Return Me.statusField
        End Get
        Set
            Me.statusField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property TimeStamp() As String
        Get
            Return Me.timeStampField
        End Get
        Set
            Me.timeStampField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class RootAccountingPeriodArchiveDocument

    Private documentIdField As Byte

    Private addedTimeStampField As Date

    Private filenameField As String

    Private sizeInBytesField As UShort

    Private mimeTypeField As String

    Private typeField As Byte

    Private contentField As String

    '''<remarks/>
    Public Property DocumentId() As Byte
        Get
            Return Me.documentIdField
        End Get
        Set
            Me.documentIdField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute(DataType:="date")>
    Public Property AddedTimeStamp() As Date
        Get
            Return Me.addedTimeStampField
        End Get
        Set
            Me.addedTimeStampField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Filename() As String
        Get
            Return Me.filenameField
        End Get
        Set
            Me.filenameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property SizeInBytes() As UShort
        Get
            Return Me.sizeInBytesField
        End Get
        Set
            Me.sizeInBytesField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property MimeType() As String
        Get
            Return Me.mimeTypeField
        End Get
        Set
            Me.mimeTypeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Type() As Byte
        Get
            Return Me.typeField
        End Get
        Set
            Me.typeField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Content() As String
        Get
            Return Me.contentField
        End Get
        Set
            Me.contentField = Value
        End Set
    End Property
End Class

