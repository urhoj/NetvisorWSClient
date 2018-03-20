'
'
'
' Revisio $Revision$
'
' Netvisoriin lähetettävä asiakas-sanoma
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationCustomerRequest

        Public Const PARAMETER_METHOD As String = "method"
        Public Const PARAMETER_METHOD_ADD As String = "add"
        Public Const PARAMETER_METHOD_EDIT As String = "edit"

        Public Function getCustomerAsXML(ByVal customer As NetvisorCustomer) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("Customer")

                .WriteStartElement("CustomerBaseInformation")

                If Len(customer.CustomerIdentifier) > 0 Then
                    .WriteElementString("InternalIdentifier", customer.CustomerIdentifier)
                End If

                If Len(customer.OrganisationIdentifier) > 0 Then
                    .WriteElementString("ExternalIdentifier", customer.OrganisationIdentifier)
                End If

                If Len(customer.Name) > 0 Then
                    .WriteElementString("Name", customer.Name)
                End If

                If Len(customer.NameExtension) > 0 Then
                    .WriteElementString("NameExtension", customer.NameExtension)
                End If

                If Len(customer.StreetAddress) > 0 Then
                    .WriteElementString("StreetAddress", customer.StreetAddress)
                End If

                If Len(customer.City) > 0 Then
                    .WriteElementString("City", customer.City)
                End If

                If Len(customer.PostNumber) > 0 Then
                    .WriteElementString("PostNumber", customer.PostNumber)
                End If

                If Len(customer.CountryISO3166Code) > 0 Then
                    .WriteElementString("Country", customer.CountryISO3166Code)
                End If

                If Len(customer.customerGroupName) > 0 Then
                    .WriteElementString("CustomerGroupName", customer.customerGroupName)
                End If

                If Len(customer.PhoneNumber) > 0 Then
                    .WriteElementString("PhoneNumber", customer.PhoneNumber)
                End If

                If Len(customer.FaxNumber) > 0 Then
                    .WriteElementString("FaxNumber", customer.FaxNumber)
                End If

                If Len(customer.Email) > 0 Then
                    .WriteElementString("Email", customer.Email)
                End If

                If Len(customer.HomePageUri) > 0 Then
                    .WriteElementString("HomePageUri", customer.HomePageUri)
                End If

                Dim active As Integer = 1

                If Not customer.isActive Is Nothing Then

                    If CType(customer.isActive, Boolean) Then
                        active = 1
                    Else
                        active = 0
                    End If

                End If

                .WriteElementString("IsActive", active)

                If customer.IsPrivateCustomer.HasValue Then
                    .WriteElementString("IsPrivateCustomer", If(customer.IsPrivateCustomer, 1, 0))
                End If

                If Len(customer.EmailInvoicingAddress) > 0 Then
                    .WriteElementString("EmailInvoicingAddress", customer.EmailInvoicingAddress)
                End If


                .WriteEndElement()

                .WriteStartElement("CustomerFinvoiceDetails")

                If Len(customer.FinvoiceAddress) > 0 Then
                    .WriteElementString("FinvoiceAddress", customer.FinvoiceAddress)
                End If

                If Len(customer.FinvoiceRouter) > 0 Then
                    .WriteElementString("FinvoiceRouterCode", customer.FinvoiceRouter)
                End If

                .WriteEndElement()

                .WriteStartElement("CustomerDeliveryDetails")

                If Len(customer.DeliveryName) > 0 Then
                    .WriteElementString("DeliveryName", customer.DeliveryName)
                End If

                If Len(customer.DeliveryStreetAddress) > 0 Then
                    .WriteElementString("DeliveryStreetAddress", customer.DeliveryStreetAddress)
                End If

                If Len(customer.DeliveryCity) > 0 Then
                    .WriteElementString("DeliveryCity", customer.DeliveryCity)
                End If

                If Len(customer.DeliveryPostNumber) > 0 Then
                    .WriteElementString("DeliveryPostNumber", customer.DeliveryPostNumber)
                End If

                If Len(customer.DeliveryCountryISO3166Code) > 0 Then
                    .WriteElementString("DeliveryCountry", customer.DeliveryCountryISO3166Code)
                End If

                .WriteEndElement()

                .WriteStartElement("CustomerContactDetails")

                If Len(customer.ContactName) > 0 Then
                    .WriteElementString("ContactName", customer.ContactName)
                End If

                If Len(customer.ContactPerson) > 0 Then
                    .WriteElementString("ContactPerson", customer.ContactPerson)
                End If

                If Len(customer.ContactPersonEmail) > 0 Then
                    .WriteElementString("ContactPersonEmail", customer.ContactPersonEmail)
                End If

                If Len(customer.ContactPersonPhone) > 0 Then
                    .WriteElementString("ContactPersonPhone", customer.ContactPersonPhone)
                End If

                .WriteEndElement()

                .WriteStartElement("CustomerAdditionalInformation")

                If Len(customer.Comment) > 0 Then
                    .WriteElementString("Comment", customer.Comment)
                End If

                If Len(customer.invoicingLanguage) > 0 Then
                    .WriteElementString("InvoicingLanguage", customer.invoicingLanguage)
                End If

                If customer.invoicePrintChannelFormat > 0 Then
                    .WriteStartElement("InvoicePrintChannelFormat")
                    .WriteAttributeString("type", "netvisor")
                    .WriteString(customer.invoicePrintChannelFormat)
                    .WriteEndElement()
                End If

                If Len(customer.YourDefaultReference) > 0 Then
                    .WriteElementString("YourDefaultReference", customer.YourDefaultReference)
                End If

                If Len(customer.DefaultTextBeforeInvoiceLines) > 0 Then
                    .WriteElementString("DefaultTextBeforeInvoiceLines", customer.DefaultTextBeforeInvoiceLines)
                End If

                If Len(customer.DefaultTextAfterInvoiceLines) > 0 Then
                    .WriteElementString("DefaultTextAfterInvoiceLines", customer.DefaultTextAfterInvoiceLines)
                End If

                If Len(customer.SalesPersonID) > 0 Then
                    .WriteStartElement("DefaultSalesPerson")
                    .WriteStartElement("SalesPersonID")
                    .WriteAttributeString("type", "netvisor")
                    If customer.SalesPersonID = "0" Then
                        .WriteString("")
                    Else
                        .WriteString(customer.SalesPersonID)
                    End If
                    .WriteEndElement()
                    .WriteEndElement()
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