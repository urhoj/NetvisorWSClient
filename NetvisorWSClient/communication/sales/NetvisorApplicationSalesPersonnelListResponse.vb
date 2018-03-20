Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorApplicationSalesPersonnelListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getSalesPersonnelList() As ArrayList
            Dim salesPersonnelList As New ArrayList
            Dim salesPersonnelListDocument As New XmlDocument()

            salesPersonnelListDocument.LoadXml(MyBase.responseData)

            For Each salesPersonNode As XmlNode In salesPersonnelListDocument.SelectNodes("/Root/SalesPersonnelList/SalesPerson")
                Dim salesPersonnelListSalesPerson As New NetvisorSalesPersonnelListSalesPerson

                With salesPersonnelListSalesPerson
                    .netvisorKey = CType(salesPersonNode.Attributes.GetNamedItem("NetvisorKey").InnerText, Integer)
                    .firstName = CType(salesPersonNode.SelectSingleNode("FirstName").InnerText, String)
                    .lastName = CType(salesPersonNode.SelectSingleNode("LastName").InnerText, String)
                    If Len(salesPersonNode.SelectSingleNode("ProvisionPercent").InnerText) > 0 Then
                        .provisionPercent = CType(salesPersonNode.SelectSingleNode("ProvisionPercent").InnerText, Decimal)
                    End If
                End With

                salesPersonnelList.Add(salesPersonnelListSalesPerson)
            Next

            Return salesPersonnelList
        End Function
    End Class
End Namespace