
'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("Root", IsNullable:=False)>
Partial Public Class AccountingPeriodArchiveXml

    Private responseStatusField As AccountingPeriodArchiveResponseStatus

    Private accountingPeriodArchiveField As RootAccountingPeriodArchive

    '''<remarks/>
    Public Property ResponseStatus() As AccountingPeriodArchiveResponseStatus
        Get
            Return Me.responseStatusField
        End Get
        Set
            Me.responseStatusField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property AccountingPeriodArchive() As RootAccountingPeriodArchive
        Get
            Return Me.accountingPeriodArchiveField
        End Get
        Set
            Me.accountingPeriodArchiveField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("ResponseStatus", IsNullable:=False)>
Partial Public Class AccountingPeriodArchiveResponseStatus

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
Partial Public Class RootAccountingPeriodArchive

    Private organizationIdentifierField As String

    Private companynameField As String

    Private accountingPeriodsField() As RootAccountingPeriodArchiveAccountingPeriod

    '''<remarks/>
    Public Property OrganizationIdentifier() As String
        Get
            Return Me.organizationIdentifierField
        End Get
        Set
            Me.organizationIdentifierField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Companyname() As String
        Get
            Return Me.companynameField
        End Get
        Set
            Me.companynameField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("AccountingPeriod", IsNullable:=False)>
    Public Property AccountingPeriods() As RootAccountingPeriodArchiveAccountingPeriod()
        Get
            Return Me.accountingPeriodsField
        End Get
        Set
            Me.accountingPeriodsField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class RootAccountingPeriodArchiveAccountingPeriod

    Private periodIdField As Byte

    Private startDateField As String

    Private endDateField As String

    Private statusField As Byte

    Private accountingPeriodArchiveDocumentField() As RootAccountingPeriodArchiveAccountingPeriodAccountingPeriodArchiveDocument

    '''<remarks/>
    Public Property PeriodId() As Byte
        Get
            Return Me.periodIdField
        End Get
        Set
            Me.periodIdField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property StartDate() As String
        Get
            Return Me.startDateField
        End Get
        Set
            Me.startDateField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EndDate() As String
        Get
            Return Me.endDateField
        End Get
        Set
            Me.endDateField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Status() As Byte
        Get
            Return Me.statusField
        End Get
        Set
            Me.statusField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlElementAttribute("AccountingPeriodArchiveDocument")>
    Public Property AccountingPeriodArchiveDocument() As RootAccountingPeriodArchiveAccountingPeriodAccountingPeriodArchiveDocument()
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
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True)>
Partial Public Class RootAccountingPeriodArchiveAccountingPeriodAccountingPeriodArchiveDocument

    Private documentIdField As Byte

    Private addedTimeStampField As String

    Private filenameField As String

    Private sizeInBytesField As UInteger

    Private mimeTypeField As String

    Private typeField As Byte

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
    Public Property AddedTimeStamp() As String
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
    Public Property SizeInBytes() As UInteger
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
End Class

