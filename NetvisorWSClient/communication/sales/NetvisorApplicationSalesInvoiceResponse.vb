'
'
'
' Revisio $Revision$
'
' Lukee Netvisorin antaman laskuhaku-pyynnön vastauksen ja palauttaa laskun
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationSalesInvoiceResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub
    End Class
End Namespace

