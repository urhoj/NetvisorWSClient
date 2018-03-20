'
'
'
' Revisio $Revision$
' 
' Ilmentää Netvisoriin lähetettävän työaikakirjauksen yhdelle päivälle yhdelle työntekijälle
' muodostaa xml-sanoman
'

Imports System.IO
Imports System.Xml
Imports System.Text
Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector
	<ComClass(NetvisorApplicationWorkDayRequest.ClassId, NetvisorApplicationWorkDayRequest.InterfaceId, NetvisorApplicationWorkDayRequest.EventsId)> Public Class NetvisorApplicationWorkDayRequest

		Public Const ClassId As String = "35EE17D8-3C05-4567-82BB-6D9D64E72727"
		Public Const InterfaceId As String = "A0A09CC3-390F-4a79-A256-985C4AEF39BA"
		Public Const EventsId As String = "2C55EE33-CC13-498c-83C8-01AD419DC2D3"

		Public Function getWorkDayAsXML(ByVal workDay As NetvisorWorkDay) As String
			Dim memoryStream As New MemoryStream
			Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

			With xmlWriter
				.Formatting = Formatting.Indented
				.Indentation = 4

				.WriteStartElement("Root")
				.WriteStartElement("WorkDay")

                Dim dateMethod As String

                If workDay.dateMethod = 0 Then
                    workDay.dateMethod = NetvisorWorkDay.dateMethods.replace
                End If

                Select Case workDay.dateMethod
                    Case NetvisorWorkDay.dateMethods.replace
                        dateMethod = "replace"

                    Case NetvisorWorkDay.dateMethods.increment
                        dateMethod = "increment"

                    Case Else
                        Throw New ApplicationException("Invalid date method: " & workDay.dateMethod)

                End Select


                .WriteStartElement("Date")
                .WriteAttributeString("format", "ansi")
                .WriteAttributeString("method", dateMethod)
                .WriteString(Format(workDay.date, "yyyy-MM-dd"))
                .WriteEndElement()

                Dim employeeIdentifierType As String

                Select Case workDay.employeeIdentifierType
                    Case NetvisorWorkDay.employeeIdentifierTypes.number
                        employeeIdentifierType = "number"

                    Case NetvisorWorkDay.employeeIdentifierTypes.personalidentificationnumber
                        employeeIdentifierType = "personalidentificationnumber"

                    Case Else
                        Throw New ApplicationException("Invalid employee identifiertype: " & workDay.employeeIdentifierType)

                End Select

                Dim employeeDefaultDimensionHandlingType As String

                If workDay.employeeDefaultDimensionHandlingType = 0 Then
                    workDay.employeeDefaultDimensionHandlingType = NetvisorWorkDay.employeeDefaultDimensionHandlingTypes.none
                End If

                Select Case workDay.employeeDefaultDimensionHandlingType
                    Case NetvisorWorkDay.employeeDefaultDimensionHandlingTypes.none
                        employeeDefaultDimensionHandlingType = "none"

                    Case NetvisorWorkDay.employeeDefaultDimensionHandlingTypes.usedefault
                        employeeDefaultDimensionHandlingType = "usedefault"

                    Case Else
                        Throw New ApplicationException("Invalid employee defaultdimensionhandlingtype: " & workDay.employeeDefaultDimensionHandlingType)

                End Select

                .WriteStartElement("EmployeeIdentifier")
                .WriteAttributeString("type", employeeIdentifierType)
                .WriteAttributeString("defaultdimensionhandlingtype", employeeDefaultDimensionHandlingType)
                .WriteString(workDay.employeeIdentifier)
                .WriteEndElement()

                For Each workDayHour As NetvisorWorkDayHour In workDay.workDayHours
                    .WriteStartElement("WorkDayHour")

                    .WriteElementString("Hours", workDayHour.Hours)

                    .WriteStartElement("CollectorRatio")
                    .WriteAttributeString("type", "number")
                    .WriteString(workDayHour.CollectorRatioNumber)
                    .WriteEndElement()

                    Dim acceptanceStatus As String = vbNullString

                    Select Case workDayHour.AcceptanceStatus
                        Case NetvisorWorkDayHour.acceptanceStatuses.accepted
                            acceptanceStatus = "accepted"

                        Case NetvisorWorkDayHour.acceptanceStatuses.confirmed
                            acceptanceStatus = "confirmed"

                        Case Else
                            Throw New ApplicationException("Invalid acceptancestatus: " & workDayHour.AcceptanceStatus)

                    End Select

                    .WriteElementString("AcceptanceStatus", acceptanceStatus)
                    .WriteElementString("Description", workDayHour.Description)

                    If Len(workDayHour.CrmProcessIdentifier) > 0 Then

                        Dim billingType As String = vbNullString

                        If workDayHour.CrmProcessIdentifierBillingType = 0 Then
                            workDayHour.CrmProcessIdentifierBillingType = NetvisorWorkDayHour.billingType.unbillable
                        End If

                        Select Case workDayHour.CrmProcessIdentifierBillingType
                            Case NetvisorWorkDayHour.billingType.unbillable
                                billingType = "unbillable"

                            Case NetvisorWorkDayHour.billingType.billable
                                billingType = "billable"

                            Case Else
                                Throw New ApplicationException("Invalid crmprocessidentifierbillingtype: " & workDayHour.CrmProcessIdentifierBillingType)

                        End Select


                        .WriteStartElement("CrmProcessIdentifier")
                        .WriteAttributeString("billingtype", billingType)
                        .WriteString(workDayHour.CrmProcessIdentifier)
                        .WriteEndElement()

                        If Len(workDayHour.InvoicingProductIdentifier) > 0 Then
                            .WriteElementString("InvoicingProductIdentifier", workDayHour.InvoicingProductIdentifier)
                        End If

                    End If


                    For Each dimension As NetvisorDimension In workDayHour.dimensions
                        .WriteStartElement("Dimension")
                        .WriteElementString("DimensionName", dimension.dimensionName)
                        .WriteStartElement("DimensionItem")

                        If dimension.dimensionDetailFatherID > 0 Then
                            .WriteAttributeString("fatherid", dimension.dimensionDetailFatherID)
                        End If

                        .WriteString(dimension.dimensionDetail)
                        .WriteEndElement() '/ DimensionItem
                        .WriteEndElement() '/ Dimension
                    Next

                    .WriteEndElement() '/WorkDayHour
                Next

                .WriteEndElement() '/WorkDay
                .WriteEndElement() '/Root

                .Flush()
            End With

			Dim streamReader As New StreamReader(memoryStream)
			memoryStream.Seek(0, SeekOrigin.Begin)

			Return streamReader.ReadToEnd()
		End Function
	End Class
End Namespace