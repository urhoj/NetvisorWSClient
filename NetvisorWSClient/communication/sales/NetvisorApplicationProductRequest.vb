'
'
'
' Revisio $Revision$
'
' Netvisoriin lähetettävä tuotepyyntö
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.sales
    <ComClass(NetvisorApplicationProductRequest.ClassId, NetvisorApplicationProductRequest.InterfaceId, NetvisorApplicationProductRequest.EventsId)> Public Class NetvisorApplicationProductRequest

        Public Const ClassId As String = "98349785-8BE2-4604-848D-15B103D61712"
        Public Const InterfaceId As String = "36613EE9-125F-493d-9968-171E18C22262"
        Public Const EventsId As String = "A036F02F-F87E-4548-A536-1DD7EA8E62B2"

        Public Sub New()
        End Sub

        Public Function getProductAsXML(ByVal product As NetvisorProduct) As String
            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("Product")

                .WriteStartElement("ProductBaseInformation")

                .WriteElementString("ProductCode", product.productCode)
                .WriteElementString("ProductGroup", product.productGroup)
                .WriteElementString("Name", product.name)
                .WriteElementString("Description", product.description)

                Dim unitPriceType As String
                If product.unitPriceType = NetvisorProduct.unitPriceTypes.net Then
                    unitPriceType = "net"
                ElseIf product.unitPriceType = NetvisorProduct.unitPriceTypes.gross Then
                    unitPriceType = "gross"
                Else
                    Throw New InvalidDataException("Invalid unitpricetype")
                End If

                .WriteStartElement("UnitPrice")
                .WriteAttributeString("type", unitPriceType)
                .WriteString(product.unitPrice)
                .WriteEndElement() ' / UnitPrice

                .WriteElementString("Unit", product.unit)
                .WriteElementString("UnitWeight", product.unitWeight)
                .WriteElementString("PurchasePrice", product.purchaseprice)
                .WriteElementString("TariffHeading", product.tariffHeading)
                .WriteElementString("ComissionPercentage", product.comissionPercentage)

                Dim active As Integer
                If product.isActive Then
                    active = 1
                Else
                    active = 0
                End If

                .WriteElementString("IsActive", active)

                Dim salesproduct As Integer
                If product.isSalesproduct Then
                    salesproduct = 1
                Else
                    salesproduct = 0
                End If

                .WriteElementString("IsSalesproduct", salesproduct)

                .WriteEndElement() ' / ProductBaseInformation

                .WriteStartElement("ProductBookkeepingDetails")
                .WriteElementString("DefaultVatPercentage", product.defaultVatPercentage)
                .WriteEndElement() ' / ProductBookkeepingDetails

                .WriteEndElement() ' / Product
                .WriteEndElement() ' / Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace