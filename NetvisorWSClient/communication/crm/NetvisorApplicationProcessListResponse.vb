'
' Revisio $Revision$
'
' Lukee Netvisorin antaman tehtävälista-pyynnön vastauksen ja palauttaa
' tehtävät arraylistissä
'

Imports System.Xml
Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.sales

Namespace NetvisorWSClient.communication.crm
    Public Class NetvisorApplicationProcessListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getProcessList() As ArrayList
            Dim processList As New ArrayList
            Dim processListDocument As New XmlDocument()
            Dim netvisorKey As String

            processListDocument.LoadXml(MyBase.responseData)

            For Each processNode As XmlNode In processListDocument.SelectNodes("/Root/Processes/Process")
                Dim processListProcess As New NetvisorProcessListProcess()

                With processListProcess
                    .NetvisorKey = CType(processNode.Attributes("netvisorKey").Value, Integer)
                    .Duedate = CType(processNode.SelectSingleNode("DueDate").InnerText, Date)
                    .IsClosed = CType(processNode.SelectSingleNode("IsClosed").InnerText, Boolean)
                    .ProcessIdentifier = CType(processNode.SelectSingleNode("ProcessIdentifier").InnerText, String)
                    .Name = CType(processNode.SelectSingleNode("ProcessName").InnerText, String)

                    Dim template As New NetvisorProcessTemplate

                    netvisorKey = processNode.SelectSingleNode("ProcessTemplate").Attributes("netvisorKey").Value

                    If Len(netvisorKey) > 0 Then
                        template.netvisorKey = CType(netvisorKey, Integer)
                    End If

                    template.Name = CType(processNode.SelectSingleNode("ProcessTemplate").InnerText, String)
                    .ProcessTemplate = template

                    Dim customer As New NetvisorCustomer

                    netvisorKey = processNode.SelectSingleNode("Customer").Attributes("netvisorKey").Value

                    If Len(netvisorKey) > 0 Then
                        customer.netvisorKey = CType(netvisorKey, Integer)
                    End If

                    customer.Name = CType(processNode.SelectSingleNode("Customer").InnerText, String)
                    .Customer = customer

                    .Description = CType(processNode.SelectSingleNode("ProcessDescription").InnerText, String)
                    .CurrentProcessStageName = CType(processNode.SelectSingleNode("CurrentProcessStageName").InnerText, String)
                End With

                processList.Add(processListProcess)
            Next

            Return processList
        End Function
    End Class
End Namespace