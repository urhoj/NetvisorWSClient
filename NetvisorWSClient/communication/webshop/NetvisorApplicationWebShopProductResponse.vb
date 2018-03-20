'
'
' Lukee Netvisorissa olevat verkkokauppayritykset
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.webshop
    Public Class NetvisorApplicationWebShopProductResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getNetvisorWebShopProductList() As ArrayList

            Dim webShopProducts As New ArrayList
            Dim webShopProductListDocument As New XmlDocument()

            webShopProductListDocument.LoadXml(MyBase.responseData)

            For Each webShopProductNode As XmlNode In webShopProductListDocument.SelectNodes("/Root/WebShopProductList/WebShopProduct")

                Dim product As New NetvisorWebShopProduct

                For Each name As XmlNode In webShopProductNode.SelectNodes("Name")
                    product.addNameWithCountryCode(name.Attributes.GetNamedItem("language").InnerText, name.InnerText)
                Next

                For Each description As XmlNode In webShopProductNode.SelectNodes("Description")
                    product.addDescriptionWithCountryCode(description.Attributes.GetNamedItem("language").InnerText, description.InnerText)
                Next

                For Each groupName As XmlNode In webShopProductNode.SelectNodes("ProductGroups/ProductGroup/Name")

                    Dim group As New NetvisorWebShopProductGroup

                    group.addNameWithCountryCode(groupName.Attributes.GetNamedItem("language").InnerText, groupName.InnerText)

                    product.addProductGroup(group)

                Next

                For Each variantNode As XmlNode In webShopProductNode.SelectNodes("Variants/Variant")

                    Dim productVariant As New NetvisorWebShopProductVariant

                    For Each name As XmlNode In variantNode.SelectNodes("Name")
                        productVariant.addNameWithCountryCode(name.Attributes.GetNamedItem("language").InnerText, name.InnerText)
                    Next

                    For Each description As XmlNode In variantNode.SelectNodes("Description")
                        productVariant.addDescriptionWithCountryCode(description.Attributes.GetNamedItem("language").InnerText, description.InnerText)
                    Next

                    productVariant.variantIdentifier = CType(variantNode.SelectSingleNode("VariantIdentifier").InnerText, String)
                    productVariant.imageURI = CType(variantNode.SelectSingleNode("ImageURI").InnerText, String)

                    If Not variantNode.SelectSingleNode("LastChangeDate") Is Nothing Then
                        productVariant.lastChangeDate = CType(variantNode.SelectSingleNode("LastChangeDate").InnerText, String)
                    End If

                    If Not variantNode.SelectSingleNode("Price") Is Nothing AndAlso Len(CType(variantNode.SelectSingleNode("Price").InnerText, String)) > 0 Then
                        productVariant.price = CType(variantNode.SelectSingleNode("Price").InnerText, String)
                    End If

                    product.addProductVariant(productVariant)
                Next

                webShopProducts.Add(product)
            Next

            Return webShopProducts
        End Function

    End Class
End Namespace