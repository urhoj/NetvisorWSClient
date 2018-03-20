'
'
' Ilmentää Netvisorin verkkokauppatuotteen
'

Imports System.Xml
Imports NetvisorWSClient.util
Imports System.Collections.Specialized

Namespace NetvisorWSClient.communication.webshop

    Public Class NetvisorWebShopProduct

        Private m_Names As New NameValueCollection
        Private m_Descriptions As New NameValueCollection
        Private m_ProductGroups As New ArrayList
        Private m_ProductVariants As New ArrayList

        Public Sub addNameWithCountryCode(ByVal countryCode As String, ByVal name As String)
            m_Names.Add(countryCode, name)
        End Sub

        Public Sub addDescriptionWithCountryCode(ByVal countryCode As String, ByVal description As String)
            m_Descriptions.Add(countryCode, description)
        End Sub

        Public Sub addProductGroup(ByVal productGroup As NetvisorWebShopProductGroup)
            m_ProductGroups.Add(productGroup)
        End Sub

        Public Sub addProductVariant(ByVal productVariant As NetvisorWebShopProductVariant)
            m_ProductVariants.Add(productVariant)
        End Sub

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

        Public ReadOnly Property ProductGroups() As ArrayList
            Get
                Return m_ProductGroups
            End Get
        End Property

        Public ReadOnly Property ProductVariants() As ArrayList
            Get
                Return m_ProductVariants
            End Get
        End Property

    End Class

End Namespace