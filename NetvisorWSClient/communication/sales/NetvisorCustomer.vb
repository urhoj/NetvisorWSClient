'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisorin asiakkaan
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorCustomer

        Private Const NAME_MAXIMUM_LENGTH As Integer = 250
        Private Const NAME_EXTENSION_MAXIMUM_LENGTH As Integer = 250

        Private Const CITY_MAXIMUM_LENGTH As Integer = 80
        Private Const STREET_ADDRESS_MAXIMUM_LENGTH As Integer = 80

        Private Const DELIVERY_CITY_MAXIMUM_LENGTH As Integer = 80
        Private Const DELIVERY_NAME_MAXIMUM_LENGTH As Integer = 250
        Private Const DELIVERY_STREET_ADDRESS_MAXIMUM_LENGTH As Integer = 80

        Private Const YOUR_DEFAULT_REFERENCE_NUMBER As Integer = 200

        Private Const DEFAULT_TEXT_AFTER_INVOICE_LINES_MAXIMUM_LENGTH As Integer = 500
        Private Const DEFAULT_TEXT_BEFORE_INVOICE_LINES_MAXIMUM_LENGTH As Integer = 500

        Private m_netvisorKey As Integer
        Private m_customerGroupNetvisorKey As Integer
        Private m_customerGroupName As String
        Private m_customerIdentifier As String
        Private m_name As String
        Private m_nameExtension As String
        Private m_organisationIdentifier As String
        Private m_city As String
        Private m_streetAddress As String
        Private m_postNumber As String
        Private m_countryISO3166Code As String
        Private m_phoneNumber As String
        Private m_faxNumber As String
        Private m_email As String
        Private m_homePageUri As String
        Private m_finvoiceAddress As String
        Private m_finvoiceRouter As String
        Private m_deliveryName As String
        Private m_deliveryStreetAddress As String
        Private m_deliveryCity As String
        Private m_deliveryPostNumber As String
        Private m_deliveryCountryISO3166Code As String
        Private m_contactName As String
        Private m_contactPerson As String
        Private m_contactPersonEmail As String
        Private m_contactPersonPhone As String
        Private m_comment As String
        Private m_balanceLimit As Decimal
        Private m_invoicingLanguage As String
        Private m_invoicePrintChannelFormat As Integer
        Private m_isActive As Object
        Private m_DefaultSalesPerson As String
        Private m_SalesPersonID As String
        Private m_isPrivateCustomer As Boolean?
        Private m_emailInvoicingAddress As String
        Private m_yourDefaultReference As String
        Private m_defaultTextBeforeInvoiceLines As String
        Private m_defaultTextAfterInvoiceLines As String

        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

        Public Property customerGroupNetvisorKey() As Integer
            Get
                Return m_customerGroupNetvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_customerGroupNetvisorKey = Value
            End Set
        End Property

        Public Property customerGroupName() As String
            Get
                Return m_customerGroupName
            End Get
            Set(ByVal Value As String)
                m_customerGroupName = Value
            End Set
        End Property

        Public Property CustomerIdentifier() As String
            Get
                Return m_customerIdentifier
            End Get
            Set(ByVal value As String)
                m_customerIdentifier = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                If Len(value) > NAME_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Customername too long")
                Else
                    m_name = value
                End If
            End Set
        End Property

        Public Property NameExtension() As String
            Get
                Return m_nameExtension
            End Get
            Set(ByVal value As String)
                If Len(value) > NAME_EXTENSION_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Customername extension too long")
                Else
                    m_nameExtension = value
                End If
            End Set
        End Property

        Public Property OrganisationIdentifier() As String
            Get
                Return m_organisationIdentifier
            End Get
            Set(ByVal value As String)
                m_organisationIdentifier = value
            End Set
        End Property


        Public Property City() As String
            Get
                Return m_city
            End Get
            Set(ByVal Value As String)
                If Len(Value) > CITY_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("City too long")
                Else
                    m_city = Value
                End If
            End Set
        End Property

        Public Property StreetAddress() As String
            Get
                Return m_streetAddress
            End Get
            Set(ByVal Value As String)
                If Len(Value) > STREET_ADDRESS_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Streetaddress too long")
                Else
                    m_streetAddress = Value
                End If
            End Set
        End Property

        Public Property PostNumber() As String
            Get
                Return m_postNumber
            End Get
            Set(ByVal Value As String)
                m_postNumber = Value
            End Set
        End Property

        Public Property CountryISO3166Code() As String
            Get
                Return m_countryISO3166Code
            End Get
            Set(ByVal Value As String)
                m_countryISO3166Code = Value
            End Set
        End Property

        Public Property PhoneNumber() As String
            Get
                Return m_phoneNumber
            End Get
            Set(ByVal Value As String)
                m_phoneNumber = Value
            End Set
        End Property

        Public Property FaxNumber() As String
            Get
                Return m_faxNumber
            End Get
            Set(ByVal Value As String)
                m_faxNumber = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return m_email
            End Get
            Set(ByVal Value As String)
                m_email = Value
            End Set
        End Property

        Public Property HomePageUri() As String
            Get
                Return m_homePageUri
            End Get
            Set(ByVal Value As String)
                m_homePageUri = Value
            End Set
        End Property

        Public Property FinvoiceAddress() As String
            Get
                Return m_finvoiceAddress
            End Get
            Set(ByVal Value As String)
                m_finvoiceAddress = Value
            End Set
        End Property

        Public Property FinvoiceRouter() As String
            Get
                Return m_finvoiceRouter
            End Get
            Set(ByVal Value As String)
                m_finvoiceRouter = Value
            End Set
        End Property

        Public Property DeliveryName() As String
            Get
                Return m_deliveryName
            End Get
            Set(ByVal Value As String)
                If Len(Value) > DELIVERY_NAME_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Deliveryname too long")
                Else
                    m_deliveryName = Value
                End If
            End Set
        End Property

        Public Property DeliveryStreetAddress() As String
            Get
                Return m_deliveryStreetAddress
            End Get
            Set(ByVal Value As String)
                If Len(Value) > DELIVERY_STREET_ADDRESS_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Delivery streetaddress too long")
                Else
                    m_deliveryStreetAddress = Value
                End If
            End Set
        End Property

        Public Property DeliveryCity() As String
            Get
                Return m_deliveryCity
            End Get
            Set(ByVal Value As String)
                If Len(Value) > DELIVERY_CITY_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Deliverycity too long")
                Else
                    m_deliveryCity = Value
                End If
            End Set
        End Property

        Public Property DeliveryPostNumber() As String
            Get
                Return m_deliveryPostNumber
            End Get
            Set(ByVal Value As String)
                m_deliveryPostNumber = Value
            End Set
        End Property

        Public Property DeliveryCountryISO3166Code() As String
            Get
                Return m_deliveryCountryISO3166Code
            End Get
            Set(ByVal Value As String)
                m_deliveryCountryISO3166Code = Value
            End Set
        End Property

        Public Property ContactName() As String
            Get
                Return m_contactName
            End Get
            Set(ByVal Value As String)
                m_contactName = Value
            End Set
        End Property

        Public Property ContactPerson() As String
            Get
                Return m_contactPerson
            End Get
            Set(ByVal Value As String)
                m_contactPerson = Value
            End Set
        End Property

        Public Property ContactPersonEmail() As String
            Get
                Return m_contactPersonEmail
            End Get
            Set(ByVal Value As String)
                m_contactPersonEmail = Value
            End Set
        End Property

        Public Property ContactPersonPhone() As String
            Get
                Return m_contactPersonPhone
            End Get
            Set(ByVal Value As String)
                m_contactPersonPhone = Value
            End Set
        End Property

        Public Property Comment() As String
            Get
                Return m_comment
            End Get
            Set(ByVal Value As String)
                m_comment = Value
            End Set
        End Property

        Public Property balanceLimit() As Decimal
            Get
                Return m_balanceLimit
            End Get
            Set(ByVal Value As Decimal)
                m_balanceLimit = Value
            End Set
        End Property

        Public Property invoicingLanguage() As String
            Get
                Return m_invoicingLanguage
            End Get
            Set(ByVal Value As String)
                m_invoicingLanguage = Value
            End Set
        End Property

        Public Property invoicePrintChannelFormat() As Integer
            Get
                Return m_invoicePrintChannelFormat
            End Get
            Set(ByVal Value As Integer)
                m_invoicePrintChannelFormat = Value
            End Set
        End Property

        Public Property isActive() As Object
            Get
                Return m_isActive
            End Get
            Set(ByVal Value As Object)
                m_isActive = Value
            End Set
        End Property

        Public Property DefaultSalesPerson() As String
            Get
                Return m_DefaultSalesPerson
            End Get
            Set(value As String)
                m_DefaultSalesPerson = value
            End Set
        End Property

        Public Property SalesPersonID() As String
            Set(ByVal Value As String)
                m_SalesPersonID = Value
            End Set
            Get
                Return m_SalesPersonID
            End Get
        End Property

        Public Property IsPrivateCustomer As Boolean?
            Get
                Return m_isPrivateCustomer
            End Get
            Set(ByVal value As Boolean?)
                m_isPrivateCustomer = value
            End Set
        End Property

        Public Property EmailInvoicingAddress() As String
            Get
                Return m_emailInvoicingAddress
            End Get
            Set(ByVal Value As String)
                m_emailInvoicingAddress = Value
            End Set
        End Property

        Public Property YourDefaultReference() As String
            Get
                Return m_yourDefaultReference
            End Get
            Set(ByVal value As String)
                If Len(value) > YOUR_DEFAULT_REFERENCE_NUMBER Then
                    Throw New ApplicationException("Your default reference too long")
                Else
                    m_yourDefaultReference = value
                End If
            End Set
        End Property

        Public Property DefaultTextBeforeInvoiceLines() As String
            Get
                Return m_defaultTextBeforeInvoiceLines
            End Get
            Set(ByVal value As String)

                If Len(value) > DEFAULT_TEXT_BEFORE_INVOICE_LINES_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Default text before invoice lines too long")
                Else
                    m_defaultTextBeforeInvoiceLines = value
                End If

            End Set
        End Property

        Public Property DefaultTextAfterInvoiceLines() As String
            Get
                Return m_defaultTextAfterInvoiceLines
            End Get
            Set(ByVal value As String)

                If Len(value) > DEFAULT_TEXT_AFTER_INVOICE_LINES_MAXIMUM_LENGTH Then
                    Throw New ApplicationException("Default text after invoice lines too long")
                Else
                    m_defaultTextAfterInvoiceLines = value
                End If

            End Set
        End Property

    End Class
End Namespace
