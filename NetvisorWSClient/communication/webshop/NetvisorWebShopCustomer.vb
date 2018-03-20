'
'
' Ilmentää Netvisorin verkkokauppayrittäjän
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.webshop
    Public Class NetvisorWebShopCustomer

        Private m_OrganisationIdentifier As String
        Private m_Name As String
        Private m_Address As String
        Private m_PostNumber As String
        Private m_City As String
        Private m_Phone As String
        Private m_Email As String
        Private m_ProductListURI As String

        Public Property OrganisationIdentifier() As String
            Get
                Return m_OrganisationIdentifier
            End Get
            Set(ByVal Value As String)
                m_OrganisationIdentifier = Value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal Value As String)
                m_Name = Value
            End Set
        End Property

        Public Property Address() As String
            Get
                Return m_Address
            End Get
            Set(ByVal Value As String)
                m_Address = Value
            End Set
        End Property

        Public Property PostNumber() As String
            Get
                Return m_PostNumber
            End Get
            Set(ByVal Value As String)
                m_PostNumber = Value
            End Set
        End Property

        Public Property City() As String
            Get
                Return m_City
            End Get
            Set(ByVal Value As String)
                m_City = Value
            End Set
        End Property

        Public Property Phone() As String
            Get
                Return m_Phone
            End Get
            Set(ByVal Value As String)
                m_Phone = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return m_Email
            End Get
            Set(ByVal Value As String)
                m_Email = Value
            End Set
        End Property

        Public Property ProductListURI() As String
            Get
                Return m_ProductListURI
            End Get
            Set(ByVal Value As String)
                m_ProductListURI = Value
            End Set
        End Property

    End Class
End Namespace