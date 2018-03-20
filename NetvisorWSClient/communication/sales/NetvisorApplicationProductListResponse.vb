'
'
'
' Revisio $Revision$
'
' Lukee Netvisorin antaman tuotelista-pyynnön vastauksen ja palauttaa
' tuotteet arraylistissä
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationProductListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getProductList() As ArrayList
            Dim productList As New ArrayList
            Dim productListDocument As New XmlDocument()

            productListDocument.LoadXml(MyBase.responseData)

            For Each productNode As XmlNode In productListDocument.SelectNodes("/Root/ProductList/Product")
                Dim productListProduct As New NetvisorProductListProduct()

                With productListProduct
                    .netvisorKey = CType(productNode.SelectSingleNode("NetvisorKey").InnerText, Integer)
                    .productCode = CType(productNode.SelectSingleNode("ProductCode").InnerText, String)
                    .name = CType(productNode.SelectSingleNode("Name").InnerText, String)
                    .unitPrice = CType(productNode.SelectSingleNode("UnitPrice").InnerText, Decimal)
                    .uri = CType(productNode.SelectSingleNode("Uri").InnerText, String)
                End With

                productList.Add(productListProduct)
            Next

            Return productList
        End Function
    End Class
End Namespace