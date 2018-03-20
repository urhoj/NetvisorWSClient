'
' Revisio $Revision$
'
' Netvisoriin lähetettävä matkalaskusanoma
'

Imports System.Xml
Imports System.Text
Imports System.IO

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector
    Public Class NetvisorApplicationCollectorTripExpenseRequest

        Public Function getTripExpenseAsXML(ByVal tripExpense As NetvisorCollectorTripExpense) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

            With xmlWriter
                .Formatting = Formatting.Indented
                .Indentation = 4

                .WriteStartElement("Root")
                .WriteStartElement("TripExpense")

                .WriteElementString("Header", tripExpense.header)
                .WriteElementString("Description", tripExpense.Description)



                ' CustomLines / Muut kulurivit
                If tripExpense.customLines.Count > 0 Then

                    .WriteStartElement("CustomLines")

                    For Each customLine As NetvisorCollectorTripExpenseCustomLine In tripExpense.customLines

                        .WriteStartElement("CustomLine")

                        .WriteStartElement("EmployeeIdentifier")

                        If customLine.employeeIdentifierType = NetvisorCollectorTripExpenseCustomLine.employeeIdentifierTypes.finnishPersonalIdentifier Then
                            .WriteAttributeString("type", "finnishpersonalidentifier")
                        Else
                            .WriteAttributeString("type", "number")
                        End If

                        .WriteString(customLine.employeeIdentifier)
                        .WriteEndElement() '/EmployeeIdentifier

                        .WriteStartElement("Ratio")
                        .WriteAttributeString("type", "name")
                        .WriteString(customLine.ratio)
                        .WriteEndElement() '/Ratio

                        .WriteElementString("Amount", customLine.amount)
                        .WriteElementString("CustomLineUnitPrice", customLine.customLineUnitPrice)
                        If Len(customLine.vatPercentage) > 0 Then
                            .WriteElementString("VatPercentage", customLine.vatPercentage)
                        End If
                        .WriteElementString("LineDescription", customLine.lineDescription)

                        If Len(customLine.CRMProcessIdentifier) > 0 Then
                            .WriteElementString("CRMProcessIdentifier", customLine.CRMProcessIdentifier)
                        End If

                        If Len(customLine.customerIdentifier) > 0 Then
                            .WriteStartElement("CustomerIdentifier")

                            If customLine.customerIdentifierType = NetvisorCollectorTripExpenseCustomLine.customerIdentifierTypes.netvisor Then
                                .WriteAttributeString("type", "netvisor")
                            Else
                                .WriteAttributeString("type", "customer")
                            End If

                            .WriteString(customLine.customerIdentifier)

                            .WriteEndElement() '/CustomerIdentifier
                        End If

                        If Len(customLine.ExpenseAccountNumber) > 0 Then
                            .WriteElementString("ExpenseAccountNumber", customLine.ExpenseAccountNumber)
                        End If

                        If [Enum].IsDefined(GetType(NetvisorCollectorTripExpenseCustomLine.LineStatuses), customLine.lineStatus) Then
                            .WriteElementString("LineStatus", customLine.lineStatus.ToString)
                        End If

                        If customLine.dimensions.Count > 0 Then

                            For Each dimension As NetvisorDimension In customLine.dimensions

                                .WriteStartElement("Dimension")
                                .WriteElementString("DimensionName", dimension.dimensionName)
                                .WriteStartElement("DimensionItem")

                                If dimension.dimensionDetailFatherID > 0 Then
                                    .WriteAttributeString("fatherid", dimension.dimensionDetailFatherID)
                                End If

                                If Len(dimension.integrationDimensionDetailGuid) > 0 Then
                                    .WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid)
                                End If

                                .WriteString(dimension.dimensionDetail)
                                .WriteEndElement() '/ DimensionItem
                                .WriteEndElement() '/ Dimension

                            Next

                        End If

                        If customLine.attachments.Count > 0 Then

                            .WriteStartElement("TripExpenseAttachments")

                            For Each attachment As NetvisorAttachment In customLine.attachments

                                .WriteStartElement("TripExpenseAttachment")

                                .WriteElementString("MimeType", attachment.mimeType)
                                .WriteElementString("AttachmentDescription", attachment.description)
                                .WriteElementString("FileName", attachment.fileName)
                                .WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData))

                                .WriteEndElement() '/TripExpenseAttachment

                            Next

                            .WriteEndElement() '/TripExpenseAttachments

                        End If

                        .WriteEndElement() '/CustomLine

                    Next

                    .WriteEndElement() '/CustomLines

                End If



                ' TravelLines/Kilometrikorvaukset
                If tripExpense.travelLines.Count > 0 Then

                    .WriteStartElement("TravelLines")

                    For Each travelLine As NetvisorCollectorTripExpenseTravelLine In tripExpense.travelLines

                        .WriteStartElement("TravelLine")

                        .WriteStartElement("EmployeeIdentifier")

                        If travelLine.employeeIdentifierType = NetvisorCollectorTripExpenseTravelLine.employeeIdentifierTypes.finnishPersonalIdentifier Then
                            .WriteAttributeString("type", "finnishpersonalidentifier")
                        Else
                            .WriteAttributeString("type", "number")
                        End If

                        .WriteString(travelLine.employeeIdentifier)
                        .WriteEndElement() '/EmployeeIdentifier

                        .WriteStartElement("TravelType")

                        Select Case travelLine.travelType

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR
                                .WriteString("car")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_TRAILER
                                .WriteString("car_with_trailer")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_CARAVAN
                                .WriteString("car_with_caravan")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_HEAVY_CARGO
                                .WriteString("car_with_heavy_cargo")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_BIG_MACHINERY
                                .WriteString("car_with_big_machinery")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_DOG
                                .WriteString("car_with_dog")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_TRAVEL_IN_ROUGH_TERRAIN
                                .WriteString("car_travel_in_rough_terrain")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOTORBOAT_MAX_50HP
                                .WriteString("motorboat_max_50hp")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOTORBOAT_OVER_50HP
                                .WriteString("motorboat_over_50hp")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.SNOWMOBILE
                                .WriteString("snowmobile")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.ATV
                                .WriteString("atv")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOTORBIKE
                                .WriteString("motorbike")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.MOPED
                                .WriteString("moped")

                            Case NetvisorCollectorTripExpenseTravelLine.travelTypes.OTHER
                                .WriteString("other")

                            Case Else
                                Throw New InvalidDataException("Unknow travel type: " & travelLine.travelType)

                        End Select

                        .WriteEndElement() '/TravelType

                        .WriteElementString("PassengerAmount", travelLine.passangerAmount)
                        .WriteElementString("KilometerAmount", travelLine.kilometerAmount)

                        If travelLine.unitPrice <> 0 Then
                            .WriteElementString("UnitPrice", travelLine.unitPrice)
                        End If

                        .WriteElementString("LineDescription", travelLine.lineDescription)
                        .WriteElementString("TravelDate", travelLine.travelDate)
                        .WriteElementString("RouteDescription", travelLine.routeDescription)

                        If Len(travelLine.CRMProcessIdentifier) > 0 Then
                            .WriteElementString("CRMProcessIdentifier", travelLine.CRMProcessIdentifier)
                        End If

                        If Len(travelLine.customerIdentifier) > 0 Then
                            .WriteStartElement("CustomerIdentifier")

                            If travelLine.customerIdentifierType = NetvisorCollectorTripExpenseTravelLine.customerIdentifierTypes.netvisor Then
                                .WriteAttributeString("type", "netvisor")
                            Else
                                .WriteAttributeString("type", "customer")
                            End If

                            .WriteString(travelLine.customerIdentifier)

                            .WriteEndElement() '/CustomerIdentifier
                        End If

                        If [Enum].IsDefined(GetType(NetvisorCollectorTripExpenseTravelLine.LineStatuses), travelLine.lineStatus) Then
                            .WriteElementString("LineStatus", travelLine.lineStatus.ToString)
                        End If


                        If travelLine.dimensions.Count > 0 Then

                            For Each dimension As NetvisorDimension In travelLine.dimensions

                                .WriteStartElement("Dimension")
                                .WriteElementString("DimensionName", dimension.dimensionName)
                                .WriteStartElement("DimensionItem")

                                If dimension.dimensionDetailFatherID > 0 Then
                                    .WriteAttributeString("fatherid", dimension.dimensionDetailFatherID)
                                End If

                                If Len(dimension.integrationDimensionDetailGuid) > 0 Then
                                    .WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid)
                                End If

                                .WriteString(dimension.dimensionDetail)
                                .WriteEndElement() '/ DimensionItem
                                .WriteEndElement() '/ Dimension

                            Next

                        End If

                        If travelLine.attachments.Count > 0 Then

                            .WriteStartElement("TripExpenseAttachments")

                            For Each attachment As NetvisorAttachment In travelLine.attachments

                                .WriteStartElement("TripExpenseAttachment")

                                .WriteElementString("MimeType", attachment.mimeType)
                                .WriteElementString("AttachmentDescription", attachment.description)
                                .WriteElementString("FileName", attachment.fileName)
                                .WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData))

                                .WriteEndElement() '/TripExpenseAttachment

                            Next

                            .WriteEndElement() '/TripExpenseAttachments

                        End If

                        .WriteEndElement() '/TravelLine

                    Next

                    .WriteEndElement() '/TravelLines

                End If



                ' DailyCompensationLines/DailyCompensationLines
                If tripExpense.dailyCompensationLines.Count > 0 Then

                    .WriteStartElement("DailyCompensationLines")

                    For Each compensationLine As NetvisorCollectorTripExpenseDailyCompensationLine In tripExpense.dailyCompensationLines

                        .WriteStartElement("DailyCompensationLine")

                        .WriteStartElement("EmployeeIdentifier")

                        If compensationLine.employeeIdentifierType = NetvisorCollectorTripExpenseDailyCompensationLine.employeeIdentifierTypes.finnishPersonalIdentifier Then
                            .WriteAttributeString("type", "finnishpersonalidentifier")
                        Else
                            .WriteAttributeString("type", "number")
                        End If

                        .WriteString(compensationLine.employeeIdentifier)
                        .WriteEndElement() '/EmployeeIdentifier

                        .WriteStartElement("CompensationType")

                        Select Case compensationLine.compensationType
                            Case NetvisorCollectorTripExpenseDailyCompensationLine.compensationTypes.domesticFull
                                .WriteString("domesticfull")

                            Case NetvisorCollectorTripExpenseDailyCompensationLine.compensationTypes.domesticHalf
                                .WriteString("domestichalf")

                            Case NetvisorCollectorTripExpenseDailyCompensationLine.compensationTypes.foreign
                                .WriteString("foreign")

                            Case Else
                                Throw New InvalidDataException("Unknow compensation type: " & compensationLine.compensationType)

                        End Select

                        .WriteEndElement() '/CompensationType

                        .WriteElementString("Amount", compensationLine.amount)

                        If compensationLine.unitPrice <> 0 Then
                            .WriteElementString("UnitPrice", compensationLine.UnitPrice)
                        End If

                        .WriteElementString("LineDescription", compensationLine.lineDescription)
                        .WriteElementString("TimeOfDeparture", compensationLine.timeOfDeparture)
                        .WriteElementString("ReturnTime", compensationLine.returnTime)

                        If Len(compensationLine.CRMProcessIdentifier) > 0 Then
                            .WriteElementString("CRMProcessIdentifier", compensationLine.CRMProcessIdentifier)
                        End If

                        If Len(compensationLine.customerIdentifier) > 0 Then
                            .WriteStartElement("CustomerIdentifier")

                            If compensationLine.customerIdentifierType = NetvisorCollectorTripExpenseDailyCompensationLine.customerIdentifierTypes.netvisor Then
                                .WriteAttributeString("type", "netvisor")
                            Else
                                .WriteAttributeString("type", "customer")
                            End If

                            .WriteString(compensationLine.customerIdentifier)

                            .WriteEndElement() '/CustomerIdentifier
                        End If

                        If [Enum].IsDefined(GetType(NetvisorCollectorTripExpenseDailyCompensationLine.LineStatuses), compensationLine.lineStatus) Then
                            .WriteElementString("LineStatus", compensationLine.lineStatus.ToString)
                        End If

                        If compensationLine.dimensions.Count > 0 Then

                            For Each dimension As NetvisorDimension In compensationLine.dimensions

                                .WriteStartElement("Dimension")
                                .WriteElementString("DimensionName", dimension.dimensionName)
                                .WriteStartElement("DimensionItem")

                                If dimension.dimensionDetailFatherID > 0 Then
                                    .WriteAttributeString("fatherid", dimension.dimensionDetailFatherID)
                                End If

                                If Len(dimension.integrationDimensionDetailGuid) > 0 Then
                                    .WriteAttributeString("integrationdimensiondetailguid", dimension.integrationDimensionDetailGuid)
                                End If

                                .WriteString(dimension.dimensionDetail)
                                .WriteEndElement() '/ DimensionItem
                                .WriteEndElement() '/ Dimension
                            Next

                        End If

                        If compensationLine.attachments.Count > 0 Then

                            .WriteStartElement("TripExpenseAttachments")

                            For Each attachment As NetvisorAttachment In compensationLine.attachments

                                .WriteStartElement("TripExpenseAttachment")

                                .WriteElementString("MimeType", attachment.mimeType)
                                .WriteElementString("AttachmentDescription", attachment.description)
                                .WriteElementString("FileName", attachment.fileName)
                                .WriteElementString("DocumentData", Convert.ToBase64String(attachment.attachmentData))

                                .WriteEndElement() '/TripExpenseAttachment

                            Next

                            .WriteEndElement() '/TripExpenseAttachments

                        End If

                        .WriteEndElement() '/DailyCompensationLine

                    Next

                    .WriteEndElement() '/DailyCompensationLines

                End If

                .WriteEndElement() '/TripExpense
                .WriteEndElement() '/Root

                .Flush()
            End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function

    End Class
End Namespace