
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorApplicationGetPayslipResponse
        Inherits NetvisorApplicationResponse

        Public Const FORMAT_PARAMETER As String = "Format"
        Public Const FORMAT_PAYSLIP_XML As String = "1"
        Public Const PAYSLIPID_PARAMETER As String = "PayslipID"

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPayslip() As PayslipContentRoot

            Dim payslipDocument As New XmlDocument()

            Try
                payslipDocument.LoadXml(MyBase.responseData)
            Catch ex As XmlException
                Throw New FormatException("Loading of XML failed.", ex)
            End Try


            Dim reader As New StringReader(payslipDocument.InnerXml)
            Dim xmlSerializer As New XmlSerializer(GetType(PayslipContentRoot))

            Dim payslip As New PayslipContentRoot

            Try
                payslip = xmlSerializer.Deserialize(reader)
            Catch ex As InvalidOperationException
                Throw New FormatException("Deserialization of XML failed.", ex)
            End Try

            Return payslip

        End Function

    End Class

End Namespace
