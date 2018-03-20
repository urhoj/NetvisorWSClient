'
'
'
' Revisio $Revision$
'
' Netvisorin antaman kirjanpitoaineiston hakupyynnön vastaus
'

Imports System.Xml
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorApplicationAccountingLedgerResponse
        Inherits NetvisorApplicationResponse

        Public Enum VoucherRequestStatus As Integer

            ALL = 1
            VALID = 2
            INVALIDATED_AND_DELETED = 3

        End Enum

        ReadOnly m_voucherStatuses As New Dictionary(Of String, NetvisorAccountingLedgerVoucher.VoucherResponseStatus)

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)

            m_voucherStatuses.Add("valid", NetvisorAccountingLedgerVoucher.VoucherResponseStatus.VALID)
            m_voucherStatuses.Add("deleted", NetvisorAccountingLedgerVoucher.VoucherResponseStatus.DELETED)
            m_voucherStatuses.Add("invalidated", NetvisorAccountingLedgerVoucher.VoucherResponseStatus.INVALIDATED)

        End Sub

        Public Function getAccountingLedgers() As ArrayList

            Dim netvisorAccountingLedgers As New ArrayList
            Dim netvisorAccountingLedgerDocument As New XmlDocument

            netvisorAccountingLedgerDocument.LoadXml(MyBase.responseData)
            For Each voucherNode As XmlNode In netvisorAccountingLedgerDocument.SelectNodes("/Root/Vouchers/Voucher")
                Dim voucher As New NetvisorAccountingLedgerVoucher

                Dim voucherStatus As NetvisorAccountingLedgerVoucher.VoucherResponseStatus? = Nothing
                If m_voucherStatuses.ContainsKey(voucherNode.Attributes("Status").Value) Then
                    voucherStatus = m_voucherStatuses(voucherNode.Attributes("Status").Value)
                End If

                Dim voucherSourceNode As XmlNode = voucherNode.SelectSingleNode("LinkedSourceNetvisorKey")
                Dim isLinkedSourceProvided As Boolean = Len(voucherSourceNode.Attributes("type").InnerText) > 0

                ' tositteen tiedot
                With voucher

                    If isLinkedSourceProvided Then
                        .LinkedSourceType = voucherSourceNode.Attributes("type").InnerText
                        .LinkedSourceNetvisorKey = CInt(voucherSourceNode.InnerText)
                    End If

                    If voucherStatus.HasValue Then
                        .Status = voucherStatus
                    End If

                    .netvisorKey = voucherNode.SelectSingleNode("NetvisorKey").InnerText
                    .VoucherDate = CType(voucherNode.SelectSingleNode("VoucherDate").InnerText, Date)
                    .voucherNumber = CType(voucherNode.SelectSingleNode("VoucherNumber").InnerText, Integer)

                    If Not IsNothing(voucherNode.SelectSingleNode("Description")) Then
                        .Description = voucherNode.SelectSingleNode("Description").InnerText
                    End If

                    .VoucherClass = voucherNode.SelectSingleNode("VoucherClass").InnerText
                    .voucherNetvisorURI = voucherNode.SelectSingleNode("VoucherNetvisorURI").InnerText
                End With

                ' tositerivit
                For Each voucherLineNode As XmlNode In voucherNode.SelectNodes("VoucherLine")
                    Dim voucherline As New NetvisorVoucherLine

                    With voucherline
                        .lineSum = voucherLineNode.SelectSingleNode("LineSum").InnerText

                        If Not IsNothing(voucherLineNode.SelectSingleNode("Description")) Then
                            .lineDescription = voucherLineNode.SelectSingleNode("Description").InnerText
                        End If

                        .accountNumber = voucherLineNode.SelectSingleNode("AccountNumber").InnerText
                        .vatPercent = voucherLineNode.SelectSingleNode("VatPercent").InnerText
                        .vatCodeAbbreviation = voucherLineNode.SelectSingleNode("VatCode").InnerText

                        ' tositerivin laskentakohteet
                        For Each dimensionNode As XmlNode In voucherLineNode.SelectNodes("Dimension")
                            Dim dimensionName As String = dimensionNode.SelectSingleNode("DimensionName").InnerText
                            Dim dimensionItem As String = dimensionNode.SelectSingleNode("DimensionItem").InnerText

                            voucherline.addVoucherLineDimension(New NetvisorDimension(dimensionName, dimensionItem))
                        Next
                    End With

                    voucher.addVoucherLine(voucherline)
                Next

                netvisorAccountingLedgers.Add(voucher)
            Next

            Return netvisorAccountingLedgers
        End Function
    End Class
End Namespace