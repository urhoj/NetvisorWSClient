'
'
' Ilmentää Netvisorin verkkokauppatuotteen variaation
'

Imports System.Xml
Imports NetvisorWSClient.util
Imports System.Collections.Specialized

Namespace NetvisorWSClient.communication.webshop

    Public Class NetvisorWebShopProductVariant

        Private m_Names As New NameValueCollection
        Private m_Descriptions As New NameValueCollection
        Private m_variantIdentifier As String
        Private m_imageURI As String
        Private m_lastChangeDate As Date
        Private m_price As Decimal

        Public Sub addNameWithCountryCode(ByVal countryCode As String, ByVal name As String)
            m_Names.Add(countryCode, name)
        End Sub

        Public Sub addDescriptionWithCountryCode(ByVal countryCode As String, ByVal description As String)
            m_Descriptions.Add(countryCode, description)
        End Sub

        Public Property variantIdentifier() As String
            Get
                Return m_variantIdentifier
            End Get
            Set(ByVal Value As String)
                m_variantIdentifier = Value
            End Set
        End Property
        
        Public Property imageURI() As String
            Get
                Return m_imageURI
            End Get
            Set(ByVal Value As String)
                m_imageURI = Value
            End Set
        End Property
        
        Public Property lastChangeDate() As Date
            Get
                Return m_lastChangeDate
            End Get
            Set(ByVal Value As Date)
                m_lastChangeDate = Value
            End Set
        End Property
        
        Public Property price() As Decimal
            Get
                Return m_price
            End Get
            Set(ByVal Value As Decimal)
                m_price = Value
            End Set
        End Property

        Public ReadOnly Property Names() As NameValueCollection
            Get
                Return m_Names
            End Get
        End Property

        Public ReadOnly Property Descriptions() As NameValueCollection
            Get
                Return m_Descriptions
            End Get
        End Property

    End Class

End Namespace