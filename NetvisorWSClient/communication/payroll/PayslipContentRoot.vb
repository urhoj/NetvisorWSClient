
'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("Root", IsNullable:=False)>
Partial Public Class PayslipContentRoot

    Private responseStatusField As PayslipContentResponseStatusXml

    Private payslipDataField As String

    '''<remarks/>
    Public Property ResponseStatus() As PayslipContentResponseStatusXml
        Get
            Return Me.responseStatusField
        End Get
        Set
            Me.responseStatusField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PayslipData() As String
        Get
            Return Me.payslipDataField
        End Get
        Set
            Me.payslipDataField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("ResponseStatus", IsNullable:=False)>
Partial Public Class PayslipContentResponseStatusXml

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


