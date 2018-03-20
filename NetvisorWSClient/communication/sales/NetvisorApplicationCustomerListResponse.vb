'
'
'
' Revisio $Revision$
'
' Lukee Netvisorin antaman asiakaslista-pyynnön vastauksen ja palauttaa
' asiakkaat arraylistissä
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationCustomerListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getCustomerList() As ArrayList
            Dim customerList As New ArrayList
            Dim customerListDocument As New XmlDocument()

            customerListDocument.LoadXml(MyBase.responseData)

            For Each customerNode As XmlNode In customerListDocument.SelectNodes("/Root/Customerlist/Customer")
                Dim customerListCustomer As New NetvisorCustomerListCustomer()

                With customerListCustomer
                    .netvisorKey = CType(customerNode.SelectSingleNode("Netvisorkey").InnerText, Integer)
                    .name = CType(customerNode.SelectSingleNode("Name").InnerText, String)
                    .code = CType(customerNode.SelectSingleNode("Code").InnerText, String)
                    .organisationIdentifier = CType(customerNode.SelectSingleNode("OrganisationIdentifier").InnerText, String)
                    .uri = CType(customerNode.SelectSingleNode("Uri").InnerText, String)
                End With

                customerList.Add(customerListCustomer)
            Next

            Return customerList
        End Function
    End Class
End Namespace