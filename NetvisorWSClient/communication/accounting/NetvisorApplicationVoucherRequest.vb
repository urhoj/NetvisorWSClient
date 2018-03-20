'
'
'
' Revisio $Revision$
'
' Ilmentää netvisoriin lähetettävän kirjanpitoaineiston lisäys-pyynnön
' Muodostaa aineistosta xml-sanoman
'

Imports System.Xml
Imports System.Text
Imports System.IO

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorApplicationVoucherRequest

        Public Function getVoucherAsXML(ByVal voucher As NetvisorVoucher) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("Voucher")

                Dim calculationMode As String
                If voucher.voucherCalculationModeIsGross Then
                    calculationMode = "gross"
                Else
                    calculationMode = "net"
                End If
                .WriteElementString("CalculationMode", calculationMode)

                .WriteStartElement("VoucherDate")
                .WriteAttributeString("format", "ansi")
                .WriteString(voucher.VoucherDate)
                .WriteEndElement()

                If voucher.voucherNumber > 0 Then
                    .WriteElementString("Number", voucher.voucherNumber)
                End If

                .WriteElementString("Description", voucher.Description)
                .WriteElementString("VoucherClass", voucher.VoucherClass)

                If voucher.voucherLines.Count > 0 Then
                    For Each line As NetvisorVoucherLine In voucher.voucherLines
                        .WriteStartElement("VoucherLine")

                        .WriteElementString("LineSum", line.lineSum)
                        .WriteElementString("Description", line.lineDescription)
                        .WriteElementString("AccountNumber", line.accountNumber)

                        Dim vatCodeAsString As String = vbNullString
                        Select Case line.vatCode
                            Case VatCode.vatCodes.DOMESTIC_PURCHASE
                                vatCodeAsString = VatCode.DOMESTIC_PURCHASE

                            Case VatCode.vatCodes.DOMESTIC_SALES
                                vatCodeAsString = VatCode.DOMESTIC_SALES

                            Case VatCode.vatCodes.EU_PURCHASE
                                vatCodeAsString = VatCode.EU_PURCHASE

                            Case VatCode.vatCodes.EU_SALES
                                vatCodeAsString = VatCode.EU_SALES

                            Case VatCode.vatCodes.EU_SERVICE_PURCHASE
                                vatCodeAsString = VatCode.EU_SERVICE_PURCHASE

                            Case VatCode.vatCodes.HUNDREDPERCENT_DEDUCTED_TAX
                                vatCodeAsString = VatCode.HUNDREDPERCENT_DEDUCTED_TAX

                            Case VatCode.vatCodes.NO_VAT_HANDLING
                                vatCodeAsString = VatCode.NO_VAT_HANDLING

                            Case VatCode.vatCodes.NON_EU_PURCHASE
                                vatCodeAsString = VatCode.NON_EU_PURCHASE

                            Case VatCode.vatCodes.NON_EU_SALES
                                vatCodeAsString = VatCode.NON_EU_SALES

                            Case util.VatCode.vatCodes.EU_SERVICE_SALES_312
                                vatCodeAsString = util.VatCode.EU_SERVICE_SALES_312

                            Case util.VatCode.vatCodes.EU_SERVICE_SALES_309
                                vatCodeAsString = util.VatCode.EU_SERVICE_SALES_309

                            Case util.VatCode.vatCodes.NO_TAX_SALES
                                vatCodeAsString = util.VatCode.NO_TAX_SALES

                            Case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_PURCHASE
                                vatCodeAsString = util.VatCode.NO_DEDUCTIBLE_EU_PURCHASE

                            Case util.VatCode.vatCodes.NO_DEDUCTIBLE_EU_SERVICEPURHASE
                                vatCodeAsString = util.VatCode.NO_DEDUCTIBLE_EU_SERVICEPURHASE

                            Case Else
                                ' Alv-koodin voi jättää antamatta
                                ' Silloi se kaivetaan palvelinpuolella tilinumeron takaa
                        End Select

                        .WriteStartElement("VatPercent")

                        If Not String.IsNullOrEmpty(vatCodeAsString) Then
                            .WriteAttributeString("vatcode", vatCodeAsString)
                        End If

                        .WriteString(line.vatPercent)
                        .WriteEndElement()

                        If line.voucherLineDimensions.Count > 0 Then
                            For Each dimension As NetvisorDimension In line.voucherLineDimensions
                                .WriteStartElement("Dimension")

                                .WriteElementString("DimensionName", dimension.dimensionName)
                                .WriteElementString("DimensionItem", dimension.dimensionDetail)

                                .WriteEndElement() ' /Dimension
                            Next
                        End If

                        .WriteEndElement() ' /VoucherLine
                    Next
                End If

                If voucher.attachments.Count > 0 Then

                    .WriteStartElement("VoucherAttachments")

                    For Each attachment As NetvisorAttachment In voucher.attachments

                        .WriteStartElement("VoucherAttachment")

                        .WriteElementString("MimeType", attachment.mimeType)
                        .WriteElementString("AttachmentDescription", attachment.description)
                        .WriteElementString("FileName", attachment.fileName)
                        .WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData))

                        .WriteEndElement() '/VoucherAttachment

                    Next

                    .WriteEndElement() '/VoucherAttachments

                End If

                .WriteEndElement() '/Voucher
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace