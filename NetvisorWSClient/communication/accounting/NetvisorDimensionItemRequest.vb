'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin lähetettävän laskentakohteen lisäys tai muokkaus-pyynnön
' Muodostaa aineistosta xml-sanoman
'

Imports System.Xml
Imports System.Text
Imports System.IO

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorDimensionItemRequest

        Public Const PARAMETER_METHOD As String = "method"
        Public Const PARAMETER_METHOD_ADD As String = "add"
        Public Const PARAMETER_METHOD_EDIT As String = "edit"

        Public Function getDimensionItemAsXML(ByVal dimensionItem As NetvisorDimension) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4


                .WriteStartElement("Root")
                .WriteStartElement("DimensionItem")
                .WriteElementString("Name", dimensionItem.dimensionName)
                .WriteElementString("Item", dimensionItem.dimensionDetail)

                If Len(dimensionItem.dimensionDetailOldItem) > 0 Then
                    .WriteElementString("OldItem", dimensionItem.dimensionDetailOldItem)
                End If

                If Len(dimensionItem.integrationDimensionDetailGuid) > 0 Then
                    .WriteElementString("IntegrationDimensionDetailGuid", dimensionItem.integrationDimensionDetailGuid)
                End If

                If dimensionItem.dimensionDetailFatherID > 0 Then
                    .WriteElementString("FatherId", dimensionItem.dimensionDetailFatherID)
                End If

                If Len(dimensionItem.dimensionDetailFatherItem) > 0 Then
                    .WriteElementString("FatherItem", dimensionItem.dimensionDetailFatherItem)
                End If

                If Len(dimensionItem.integrationDimensionDetailFatherGuid) > 0 Then
                    .WriteElementString("IntegrationDimensionDetailFatherGuid", dimensionItem.integrationDimensionDetailFatherGuid)
                End If

                If dimensionItem.dimensionDetailMetaDataList.Count > 0 Then

                    For Each data As KeyValuePair(Of String, NetvisorDimension.DimensionMetadataType?) In dimensionItem.dimensionDetailMetaDataListWithType

                        Dim dataValue As String = data.Key
                        Dim dataType As NetvisorDimension.DimensionMetadataType? = data.Value

                        .WriteStartElement("MetaData")
                        .WriteElementString("Data", dataValue)
                        .WriteElementString("Type", If(dataType.HasValue, dataType.Value, ""))
                        .WriteEndElement() '/MetaData

                    Next

                End If

                .WriteEndElement() '/DimensionItem
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace