'
'
'
' Revisio $Revision$
'
' Lukee Netvisorin antaman myyntilaskulistan vastauksen ja palauttaa
' laskut arraylistissä
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationSalesInvoiceListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getSalesInvoiceList() As ArrayList
            Dim salesInvoiceList As New ArrayList
            Dim invoiceListDocument As New XmlDocument()

            invoiceListDocument.LoadXml(MyBase.responseData)

            For Each invoiceNode As XmlNode In invoiceListDocument.SelectNodes("/Root/SalesInvoiceList/SalesInvoice")
                Dim invoiceListInvoice As New NetvisorSalesInvoiceListInvoice()

                With invoiceListInvoice
                    .netvisorKey = CType(invoiceNode.SelectSingleNode("NetvisorKey").InnerText, Integer)
                    .invoiceNumber = invoiceNode.SelectSingleNode("InvoiceNumber").InnerText
					.invoiceDate = CType(invoiceNode.SelectSingleNode("Invoicedate").InnerText, Date)
                    .invoiceStatus = invoiceNode.SelectSingleNode("InvoiceStatus").InnerText

                    Dim invoiceStatusNode As XmlNode = invoiceNode.SelectSingleNode("InvoiceStatus")
                    If invoiceStatusNode.Attributes.Count > 0 Then
                        If invoiceStatusNode.Attributes.ItemOf("substatus") IsNot Nothing Then
                            .invoiceSubStatus = invoiceStatusNode.Attributes("substatus").InnerText
                        End If

                        If invoiceStatusNode.Attributes.ItemOf("isincollection") IsNot Nothing Then
                            .isInCollection = invoiceStatusNode.Attributes("isincollection").InnerText
                        End If
                    End If

                    .CustomerCode = invoiceNode.SelectSingleNode("CustomerCode").InnerText
                    .customerName = invoiceNode.SelectSingleNode("CustomerName").InnerText
                    .referenceNumber = invoiceNode.SelectSingleNode("InvoiceNumber").InnerText
                    .invoiceSum = CType(invoiceNode.SelectSingleNode("InvoiceSum").InnerText, Decimal)
                    .openSum = CType(invoiceNode.SelectSingleNode("OpenSum").InnerText, Decimal)
                    .uri = invoiceNode.SelectSingleNode("Uri").InnerText
                End With

                salesInvoiceList.Add(invoiceListInvoice)
            Next

            Return salesInvoiceList
        End Function
    End Class
End Namespace