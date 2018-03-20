'
' Revisio $Revision$
'
' Netvisoriin lähetettävä työntekijä-sanoma
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorApplicationEmployeeRequest

        Public Const PARAMETER_METHOD As String = "method"
        Public Const PARAMETER_METHOD_ADD As String = "add"
        Public Const PARAMETER_METHOD_EDIT As String = "edit"

        Public Function getEmployeeAsXML(ByVal employee As NetvisorEmployee) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("Employee")

                .WriteStartElement("EmployeeBaseInformation")

                If Len(employee.Employeeidentifier) > 0 Then
                    .WriteElementString("employeeidentifier", employee.Employeeidentifier)
                End If

                If Len(employee.FirstName) > 0 Then
                    .WriteElementString("FirstName", employee.FirstName)
                End If

                If Len(employee.LastName) > 0 Then
                    .WriteElementString("LastName", employee.LastName)
                End If

                If Len(employee.PhoneNumber) > 0 Then
                    .WriteElementString("PhoneNumber", employee.PhoneNumber)
                End If

                If Len(employee.Email) > 0 Then
                    .WriteElementString("Email", employee.Email)
                End If

                .WriteEndElement()

                .WriteStartElement("EmployeePayrollInformation")

                If Len(employee.StreetAddress) > 0 Then
                    .WriteElementString("StreetAddress", employee.StreetAddress)
                End If

                If Len(employee.PostNumber) > 0 Then
                    .WriteElementString("PostNumber", employee.PostNumber)
                End If

                If Len(employee.City) > 0 Then
                    .WriteElementString("City", employee.City)
                End If

                If Len(employee.Municipality) > 0 Then
                    .WriteElementString("Municipality", employee.Municipality)
                End If

                If Len(employee.Country) > 0 Then
                    .WriteElementString("Country", employee.Country)
                End If

                If Len(employee.Nationality) > 0 Then
                    .WriteElementString("Nationality", employee.Nationality)
                End If

                If Len(employee.Language) > 0 Then
                    .WriteElementString("Language", employee.Language)
                End If

                If employee.EmployeeNumber > -1 Then
                    .WriteElementString("EmployeeNumber", employee.EmployeeNumber.ToString)
                End If

                If Len(employee.Profession) > 0 Then
                    .WriteElementString("Profession", employee.Profession)
                End If

                If Len(employee.JobBeginDate) > 0 Then
                    .WriteStartElement("JobBeginDate")
                    .WriteAttributeString("format", "ansi")
                    .WriteString(Format(employee.JobBeginDate, "yyyy-MM-dd"))
                    .WriteEndElement()
                End If

                If Len(employee.Payrollrulegroupname) > 0 Then
                    .WriteElementString("PayrollRuleGroupName", employee.Payrollrulegroupname)
                End If

                If Len(employee.Bankaccountnumber) > 0 Then
                    .WriteElementString("BankAccountNumber", employee.Bankaccountnumber)
                End If

                If Len(employee.BankIdentificationCode) > 0 Then
                    .WriteElementString("BankIdentificationCode", employee.BankIdentificationCode)
                End If

                If employee.Accountingaccountnumber > -1 Then
                    .WriteElementString("AccountingAccountNumber", employee.Accountingaccountnumber.ToString)
                End If

                .WriteEndElement()

                .WriteEndElement()
                .WriteEndElement()

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace