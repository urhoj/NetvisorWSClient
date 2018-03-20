'
'
'
' Revisio $Revision$
'
' Netvisorin antaman ostolaskulistan vastaus
'

Imports System.Xml

Namespace NetvisorWSClient.communication.purchase
    Public Class NetvisorApplicationPurchaseInvoiceListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getPurchaseInvoiceList() As ArrayList

            Dim purchaseInvoiceList As New ArrayList
            Dim purchaseInvoiceListDocument As New XmlDocument()

            purchaseInvoiceListDocument.LoadXml(MyBase.responseData)

            For Each invoiceNode As XmlNode In purchaseInvoiceListDocument.SelectNodes("/Root/PurchaseInvoiceList/PurchaseInvoice")
                Dim invoiceListInvoice As New NetvisorPurchaseInvoiceListInvoice

                With invoiceListInvoice
                    .NetvisorKey = invoiceNode.SelectSingleNode("NetvisorKey").InnerText
                    .invoiceNumber = invoiceNode.SelectSingleNode("InvoiceNumber").InnerText

                    If Not String.IsNullOrEmpty(invoiceNode.SelectSingleNode("InvoiceDate").InnerText) Then
                        .invoiceDate = CType(invoiceNode.SelectSingleNode("InvoiceDate").InnerText, Date)
                    End If

                    .vendor = invoiceNode.SelectSingleNode("Vendor").InnerText
                    .sum = CType(invoiceNode.SelectSingleNode("Sum").InnerText, Decimal)
                    .payments = CType(invoiceNode.SelectSingleNode("Payments").InnerText, Decimal)
                    .openSum = CType(invoiceNode.SelectSingleNode("OpenSum").InnerText, Decimal)
                    .Uri = CType(invoiceNode.SelectSingleNode("Uri").InnerText, String)
                End With

                purchaseInvoiceList.Add(invoiceListInvoice)
            Next

            Return purchaseInvoiceList
        End Function
    End Class
End Namespace
