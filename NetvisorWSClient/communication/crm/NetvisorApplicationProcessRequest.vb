'
' Revisio $Revision$
' 
' Ilmentää Netvisoriin lähetettävän tehtävän
' muodostaa xml-sanoman
'

Imports System.IO
Imports System.Xml
Imports System.Text
Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.crm
    Public Class NetvisorApplicationProcessRequest

        Public Function getCRMProcessAsXML(ByVal process As NetvisorProcess) As String

            Dim memoryStream As New MemoryStream
            Dim xmlWriter As New XmlTextWriter(memoryStream, Encoding.UTF8)

			With xmlWriter
				.Formatting = Formatting.Indented
				.Indentation = 4

				.WriteStartElement("Root")
				.WriteStartElement("CrmProcess")

				.WriteElementString("ProcessIdentifier", process.ProcessIdentifier)
				.WriteElementString("Name", process.Name)
				.WriteElementString("Description", process.Description)
				.WriteElementString("ProcessTemplateName", process.ProcessTemplate.Name)
				.WriteElementString("CustomerIdentifier", process.CustomerIdentifier)

				If Len(process.Duedate) > 0 Then
					.WriteStartElement("DueDate")
					.WriteAttributeString("format", "ansi")
					.WriteString(process.Duedate.ToString("dd-MM-yyyy"))
					.WriteEndElement() '/DueDate
				End If

				If Len(process.InvoicingStatusIdentifier) > 0 Then
					.WriteElementString("InvoicingStatusIdentifier", process.InvoicingStatusIdentifier)
                End If

                If process.IsClosed Then
                    .WriteElementString("IsClosed", "1")
                End If

				.WriteEndElement() '/ CrmProcess
				.WriteEndElement() '/Root

				.Flush()
			End With

            Dim streamReader As New StreamReader(memoryStream)
            memoryStream.Seek(0, SeekOrigin.Begin)

            Return streamReader.ReadToEnd()
        End Function
    End Class
End Namespace