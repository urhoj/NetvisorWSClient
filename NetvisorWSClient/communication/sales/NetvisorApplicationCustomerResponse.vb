'
'
'
' Revisio $Revision$
'
' Netvisorin palauttama asiakassanoma. Saadaan asiakkaan täydelliset tiedot tyypitetysti.
'

Imports System.Xml
Imports System.Text
Imports System.IO

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationCustomerResponse
        Inherits NetvisorApplicationResponse

        Private Const CUSTOMER_BASE_INFORMATION_PATH As String = "/Root/Customer/CustomerBaseInformation/"
        Private Const CUSTOMER_FINVOICEDETAILS_PATH As String = "/Root/Customer/CustomerFinvoiceDetails/"
        Private Const CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH As String = "/Root/Customer/CustomerDeliveryDetails/"
        Private Const CUSTOMER_CUSTOMERCONTACTDETAILS_PATH As String = "/Root/Customer/CustomerContactDetails/"
        Private Const CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH As String = "/Root/Customer/CustomerAdditionalInformation/"

        Public Const PARAMETER_ID As String = "id"

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getCustomer() As NetvisorCustomer

            Dim customer As New NetvisorCustomer
            Dim customerDocument As New XmlDocument
            customerDocument.LoadXml(MyBase.responseData)

            With customer
                .CustomerIdentifier = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "InternalIdentifier").InnerText

                If Len(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "ExternalIdentifier").InnerText) > 0 Then
                    .OrganisationIdentifier = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "ExternalIdentifier").InnerText
                End If

                If Not IsNothing(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "CustomerGroupNetvisorKey")) AndAlso _
                        Len(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "CustomerGroupNetvisorKey").InnerText) > 0 Then

                    .customerGroupNetvisorKey = CType(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "CustomerGroupNetvisorKey").InnerText, Integer)
                    .customerGroupName = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "CustomerGroupName").InnerText
                End If

                .Name = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "Name").InnerText
                .NameExtension = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "NameExtension").InnerText
                .StreetAddress = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "StreetAddress").InnerText
                .City = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "City").InnerText
                .PostNumber = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "PostNumber").InnerText

                If Not IsNothing(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "Country")) Then
                    .CountryISO3166Code = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "Country").InnerText
                End If

                .PhoneNumber = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "PhoneNumber").InnerText
                .FaxNumber = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "FaxNumber").InnerText
                .Email = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "Email").InnerText
                .HomePageUri = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "HomePageUri").InnerText

                If Not IsNothing(customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "IsActive")) Then
                    .isActive = customerDocument.SelectSingleNode(CUSTOMER_BASE_INFORMATION_PATH & "IsActive").InnerText
                End If

                .FinvoiceAddress = customerDocument.SelectSingleNode(CUSTOMER_FINVOICEDETAILS_PATH & "FinvoiceAddress").InnerText
                .FinvoiceRouter = customerDocument.SelectSingleNode(CUSTOMER_FINVOICEDETAILS_PATH & "FinvoiceRouterCode").InnerText

                .DeliveryName = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH & "DeliveryName").InnerText
                .DeliveryStreetAddress = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH & "DeliveryStreetAddress").InnerText
                .DeliveryCity = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH & "DeliveryCity").InnerText
                .DeliveryPostNumber = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH & "DeliveryPostNumber").InnerText
                If Not IsNothing(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH & "DeliveryCountry")) Then
                    .DeliveryCountryISO3166Code = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERDELIVERYDETAILS_PATH & "DeliveryCountry").InnerText
                End If

                .ContactPerson = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERCONTACTDETAILS_PATH & "ContactPerson").InnerText
                .ContactPersonEmail = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERCONTACTDETAILS_PATH & "ContactPersonEmail").InnerText
                .ContactPersonPhone = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERCONTACTDETAILS_PATH & "ContactPersonPhone").InnerText

                .Comment = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "Comment").InnerText
                .YourDefaultReference = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "YourDefaultReference").InnerText
                .DefaultTextBeforeInvoiceLines = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "DefaultTextBeforeInvoiceLines").InnerText
                .DefaultTextAfterInvoiceLines = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "DefaultTextAfterInvoiceLines").InnerText

                If Not IsNothing(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "DefaultSalesPerson")) Then
                    .DefaultSalesPerson = customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "DefaultSalesPerson").InnerText
                End If

                If Len(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "BalanceLimit").InnerText) > 0 Then
                    .balanceLimit = CType(customerDocument.SelectSingleNode(CUSTOMER_CUSTOMERADDITIONALINFORMATION_PATH & "BalanceLimit").InnerText, Decimal)
                End If
            End With

            Return customer
        End Function
    End Class
End Namespace