'
'
' Lukee Netvisorin antaman laskentakohdelista-pyynnön vastauksen ja palauttaa
' laskentakohteet arraylistissä
'

Imports System.Xml
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorApplicationDimensionListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getDimensionNameList() As ArrayList
            Dim dimensionNameList As New ArrayList
            Dim dimensionNameListDocument As New XmlDocument()

            dimensionNameListDocument.LoadXml(MyBase.responseData)

            For Each dimensionNameNode As XmlNode In dimensionNameListDocument.SelectNodes("/Root/DimensionNameList/DimensionName")
                Dim dimensionNameListDimensionName As New NetvisorDimensionName()

                With dimensionNameListDimensionName
                    .NetvisorKey = CType(dimensionNameNode.SelectSingleNode("Netvisorkey").InnerText, Integer)
                    .Name = CType(dimensionNameNode.SelectSingleNode("Name").InnerText, String)
                    .IsHidden = CType(dimensionNameNode.SelectSingleNode("IsHidden").InnerText, Boolean)
                    .LinkType = CType(dimensionNameNode.SelectSingleNode("LinkType").InnerText, Integer)
                End With

                For Each detailNode As XmlNode In dimensionNameNode.SelectNodes("DimensionDetails/DimensionDetail")

                    Dim dimensionDetail As New NetvisorDimensionNameDimensionDetail

                    With dimensionDetail
                        .NetvisorKey = CType(detailNode.SelectSingleNode("Netvisorkey").InnerText, Integer)
                        .Name = CType(detailNode.SelectSingleNode("Name").InnerText, String)
                        .IsHidden = CType(detailNode.SelectSingleNode("IsHidden").InnerText, Boolean)
                        .Level = CType(detailNode.SelectSingleNode("Level").InnerText, Integer)
                        .Sort = CType(detailNode.SelectSingleNode("Sort").InnerText, Integer)
                        .EndSort = CType(detailNode.SelectSingleNode("EndSort").InnerText, Integer)
                        .FatherID = CType(detailNode.SelectSingleNode("FatherID").InnerText, Integer)
                    End With

                    dimensionNameListDimensionName.DimensionDetails.Add(dimensionDetail)

                Next

                dimensionNameList.Add(dimensionNameListDimensionName)
            Next

            Return dimensionNameList
        End Function


    End Class
End Namespace
