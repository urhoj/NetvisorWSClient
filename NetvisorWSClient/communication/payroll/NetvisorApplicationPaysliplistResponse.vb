Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Namespace NetvisorWSClient.communication.payroll

    Public Class NetvisorApplicationPaysliplistResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPayslipList() As PaysliplistXml

            Dim paysliplistDocument As New XmlDocument()

            Try
                paysliplistDocument.LoadXml(MyBase.responseData)
            Catch ex As XmlException
                Throw New FormatException("Loading of XML failed.", ex)
            End Try

            Dim reader As New StringReader(paysliplistDocument.InnerXml)
            Dim xmlSerializer As New XmlSerializer(GetType(PaysliplistXml))

            Dim payslipList As New PaysliplistXml

            Try
                payslipList = xmlSerializer.Deserialize(reader)
            Catch ex As InvalidOperationException
                Throw New FormatException("Deserialization of XML failed.", ex)
            End Try

            Return payslipList

        End Function

    End Class

End Namespace
