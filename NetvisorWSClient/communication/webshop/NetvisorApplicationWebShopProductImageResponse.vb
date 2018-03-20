'
'
' Lukee Netvisorissa olevan tuotevariaation kaikki kuvat
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.webshop
    Public Class NetvisorApplicationWebShopProductImageResponse
        Inherits NetvisorApplicationResponse

        Public Const PARAMETER_IDENTIFIER As String = "identifier"

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getNetvisorWebShopProductImageList() As ArrayList
            Dim images As New ArrayList
            Dim productImagesListDocument As New XmlDocument()

            productImagesListDocument.LoadXml(MyBase.responseData)

            For Each imageNode As XmlNode In productImagesListDocument.SelectNodes("/Root/WebShopProductImages/WebShopProductImage")
                Dim image As New NetvisorWebShopProductImage()

                With image
                    .MimeType = CType(imageNode.SelectSingleNode("MimeType").InnerText, String)
                    .Title = CType(imageNode.SelectSingleNode("Title").InnerText, String)
                    .FileName = CType(imageNode.SelectSingleNode("FileName").InnerText, String)
                    .DocumentData = Convert.FromBase64String(CType(imageNode.SelectSingleNode("DocumentData").InnerText, String))
                End With

                images.Add(image)
            Next

            Return images
        End Function

    End Class
End Namespace