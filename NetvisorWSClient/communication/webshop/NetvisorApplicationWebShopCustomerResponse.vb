'
'
' Lukee Netvisorissa olevat verkkokauppayritykset
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.webshop
    Public Class NetvisorApplicationWebShopCustomerResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getNetvisorWebShopCustomerList() As ArrayList
            Dim webShopCustomers As New ArrayList
            Dim webShopCustomerListDocument As New XmlDocument()

            webShopCustomerListDocument.LoadXml(MyBase.responseData)

            For Each webShopCustomerNode As XmlNode In webShopCustomerListDocument.SelectNodes("/Root/NetvisorWebShopCustomers/NetvisorWebShopCustomer")
                Dim customer As New NetvisorWebShopCustomer()

                With customer
                    .OrganisationIdentifier = CType(webShopCustomerNode.SelectSingleNode("OrganisationIdentifier").InnerText, String)
                    .Name = CType(webShopCustomerNode.SelectSingleNode("Name").InnerText, String)
                    .Address = CType(webShopCustomerNode.SelectSingleNode("Address").InnerText, String)
                    .PostNumber = CType(webShopCustomerNode.SelectSingleNode("PostNumber").InnerText, String)
                    .City = CType(webShopCustomerNode.SelectSingleNode("City").InnerText, String)
                    .Phone = CType(webShopCustomerNode.SelectSingleNode("Phone").InnerText, String)
                    .Email = CType(webShopCustomerNode.SelectSingleNode("Email").InnerText, String)
                    .ProductListURI = CType(webShopCustomerNode.SelectSingleNode("ProductListURI").InnerText, String)
                End With
                
                webShopCustomers.Add(customer)
            Next

            Return webShopCustomers
        End Function

    End Class
End Namespace