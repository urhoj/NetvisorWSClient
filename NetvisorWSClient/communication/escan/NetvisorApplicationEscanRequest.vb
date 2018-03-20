'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin lähetettävän escan-pyynnön
'

Imports System.Xml
Imports System.Text
Imports System.IO

Namespace NetvisorWSClient.communication.escan
    Public Class NetvisorApplicationEscanRequest

        Public Function getEScanDocumentAsXML(ByVal document As EScanDocument) As String

            Dim mimeType As String
            Select Case document.DocumentMimeType
                Case EScanDocument.SupportedDocumentMimeTypes.APPLICATION_PDF
                    mimeType = "application/pdf"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_BMP
                    mimeType = "image/bmp"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_EMF
                    mimeType = "image/emf"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_EXIF
                    mimeType = "image/exif"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_GIF
                    mimeType = "image/gif"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_ICON
                    mimeType = "image/icon"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_JPEG
                    mimeType = "image/jpeg"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_PNG
                    mimeType = "image/png"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_TIFF
                    mimeType = "image/tiff"
                Case EScanDocument.SupportedDocumentMimeTypes.IMAGE_WMF
                    mimeType = "image/wmf"
                Case Else
                    Throw New InvalidDataException("Unsupported Mime-type: " & document.DocumentMimeType)
            End Select

            Dim compression As String
            Select Case document.Compression
                Case EScanDocument.CompressionSettings.GZIP
                    compression = "gzip"
                Case EScanDocument.CompressionSettings.NO_COMPRESSION
                    compression = "none"
                Case Else
                    Throw New InvalidDataException("Unsupported compression type: " & document.Compression)
            End Select

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("EScanDocument")

                .WriteElementString("documenttype", document.DocumentType)
                .WriteElementString("description", document.Description)
                .WriteElementString("documentmimetype", mimeType)
                .WriteElementString("compression", compression)
                .WriteElementString("documentdata", Convert.ToBase64String(document.documentData))

                If document.targets.Count > 0 Then
                    .WriteStartElement("Targets")

                    For Each target() As Integer In document.targets
                        Dim escanTarget As String
                        Select Case CType(target(0), EScanDocument.EScanDocumentTargets)
                            Case EScanDocument.EScanDocumentTargets.SALES_INVOICE
                                escanTarget = EScanDocument.TARGET_SALES_INVOICE
                            Case EScanDocument.EScanDocumentTargets.PURCHASE_INVOICE
                                escanTarget = EScanDocument.TARGET_PURCHASE_INVOICE
                            Case EScanDocument.EScanDocumentTargets.TRIP_EXPENSE_MONEY_TRANSFER
                                escanTarget = escan.EScanDocument.TARGET_TRIP_EXPENSE_MONEY_TRANSFER
                            Case Else
                                Throw New InvalidDataException("Invalid escan-target type: " & target(0))
                        End Select

                        .WriteStartElement("TargetLine")
                        .WriteElementString("Target", escanTarget)
                        .WriteElementString("TargetIdentifier", target(1))
                        .WriteEndElement() '/TargetLine
                    Next

                    .WriteEndElement() '/Targets
                End If

                .WriteEndElement() '/EScanDocument
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)
            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace