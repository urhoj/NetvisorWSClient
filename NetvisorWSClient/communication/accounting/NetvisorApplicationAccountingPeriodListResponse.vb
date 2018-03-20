'
' Revisio $Revision$
'

Imports System.Xml

Namespace NetvisorWSClient.communication.accounting

    Public Class NetvisorApplicationAccountingPeriodListResponse
        Inherits NetvisorApplicationResponse

        Public Sub New(ByVal responseData As String)
            MyBase.New(responseData)
        End Sub

        Public Function getNetvisorAccountingPeriods() As NetvisorAccountingPeriodList

            Dim periodList As New NetvisorAccountingPeriodList

            Dim periodListDocument As New XmlDocument()
            periodListDocument.LoadXml(MyBase.responseData)

            If Len(periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/AccountingPeriodLockDate").InnerText) > 0 Then
                periodList.AccountingPeriodLockDate = periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/AccountingPeriodLockDate").InnerText
            End If

            If Len(periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/VatPeriodLockDate").InnerText) > 0 Then
                periodList.VatPeriodLockDate = periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/VatPeriodLockDate").InnerText
            End If

            If Len(periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/PurchaseLockDate").InnerText) > 0 Then
                periodList.PurchaseLockDate = periodListDocument.SelectSingleNode("/Root/AccountingPeriodList/PeriodLockInformation/PurchaseLockDate").InnerText
            End If

            Dim periods As New List(Of NetvisorPeriod)

            For Each periodNode As XmlNode In periodListDocument.SelectNodes("/Root/AccountingPeriodList/Period")

                Dim period As New NetvisorPeriod

                With period
                    .netvisorKey = CType(periodNode.SelectSingleNode("NetvisorKey").InnerText, String)
                    .Name = CType(periodNode.SelectSingleNode("Name").InnerText, String)
                    .beginDate = CType(periodNode.SelectSingleNode("BeginDate").InnerText, Date)
                    .endDate = CType(periodNode.SelectSingleNode("EndDate").InnerText, Date)
                End With

                periods.Add(period)

            Next

            periodList.periods = periods

            Return periodList

        End Function

    End Class

End Namespace