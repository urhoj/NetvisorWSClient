'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("Root", IsNullable:=False)>
Partial Public Class PaysliplistXml

    Private responseStatusField As PaysliplistResponseStatusXml

    Private payslipsField() As PayslipXml

    '''<remarks/>
    Public Property ResponseStatus() As PaysliplistResponseStatusXml
        Get
            Return Me.responseStatusField
        End Get
        Set
            Me.responseStatusField = Value
        End Set
    End Property

    '''<remarks/>
    <System.Xml.Serialization.XmlArrayItemAttribute("Payslip", IsNullable:=False)>
    Public Property Payslips() As PayslipXml()
        Get
            Return Me.payslipsField
        End Get
        Set
            Me.payslipsField = Value
        End Set
    End Property
End Class

'''<remarks/>
<System.SerializableAttribute(),
 System.ComponentModel.DesignerCategoryAttribute("code"),
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("ResponseStatus", IsNullable:=False)
 >
Partial Public Class PaysliplistResponseStatusXml

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
 System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=True),
 System.Xml.Serialization.XmlRootAttribute("Payslip", IsNullable:=False)
 >
Partial Public Class PayslipXml

    Private netvisorkeyField As Integer

    Private companyNameField As String

    Private employeeIdField As Integer

    Private employeeNumberField As String

    Private employeeNameField As String

    Private payperiodStartField As String

    Private payperiodEndField As String

    Private dueDateField As String

    Private paidAmountField As Decimal

    Private uriField As String

    '''<remarks/>
    Public Property Netvisorkey() As Integer
        Get
            Return Me.netvisorkeyField
        End Get
        Set
            Me.netvisorkeyField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property CompanyName() As String
        Get
            Return Me.companyNameField
        End Get
        Set
            Me.companyNameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EmployeeId() As UShort
        Get
            Return Me.employeeIdField
        End Get
        Set
            Me.employeeIdField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EmployeeNumber() As String
        Get
            Return Me.employeeNumberField
        End Get
        Set
            Me.employeeNumberField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property EmployeeName() As String
        Get
            Return Me.employeeNameField
        End Get
        Set
            Me.employeeNameField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PayperiodStart() As String
        Get
            Return Me.payperiodStartField
        End Get
        Set
            Me.payperiodStartField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PayperiodEnd() As String
        Get
            Return Me.payperiodEndField
        End Get
        Set
            Me.payperiodEndField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property DueDate() As String
        Get
            Return Me.dueDateField
        End Get
        Set
            Me.dueDateField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property PaidAmount() As String
        Get
            Return Me.paidAmountField
        End Get
        Set
            Me.paidAmountField = Value
        End Set
    End Property

    '''<remarks/>
    Public Property Uri() As String
        Get
            Return Me.uriField
        End Get
        Set
            Me.uriField = Value
        End Set
    End Property
End Class