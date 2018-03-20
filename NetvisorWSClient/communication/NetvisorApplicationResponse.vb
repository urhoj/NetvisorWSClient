'
'
'
' Revisio $Revision$
'
' Netvisorin antama perusvastaus. 
'

Imports System.Xml
Imports NetvisorWSClient.communication

Namespace NetvisorWSClient.communication
    <ComClass(NetvisorApplicationResponse.ClassId, NetvisorApplicationResponse.InterfaceId, NetvisorApplicationResponse.EventsId)> Public Class NetvisorApplicationResponse

        Public Const ClassId As String = "98349785-8BE2-4604-848D-F5B103D61723"
        Public Const InterfaceId As String = "36613EE9-125F-493d-9968-771E18C22223"
        Public Const EventsId As String = "A036F02F-F87E-4548-A536-7DD7EA8E6223"

        Private m_isResponseOK As Boolean
        Private m_ErrorMessage As String
        Private m_responsedata As String
        Private m_insertedDataIdentifier As String

        Public ReadOnly Property IsresponseOK() As Boolean
            Get
                Return m_isResponseOK
            End Get
        End Property

        Public ReadOnly Property ErrorMessage() As String
            Get
                Return m_ErrorMessage
            End Get
        End Property

        Public ReadOnly Property responseData() As String
            Get
                Return m_responsedata
            End Get
        End Property

        Public ReadOnly Property insertedDataIdentifier() As String
            Get
                Return m_insertedDataIdentifier
            End Get
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal responseData As String)
            m_responsedata = responseData

            Try
                Dim doc As New XmlDocument
                doc.LoadXml(responseData)

                Dim responseStatus As XmlNodeList = doc.SelectNodes("/Root/ResponseStatus/Status")

                If responseStatus.Item(0).InnerText = "OK" Then
                    m_isResponseOK = True

                    For Each reply As XmlNode In doc.SelectNodes("/Root/Replies")

                        If reply.FirstChild.Name = "InsertedDataIdentifier" Then
                            m_insertedDataIdentifier = reply.SelectSingleNode("InsertedDataIdentifier").InnerText
                        End If

                    Next

                Else
                    m_isResponseOK = False
                    m_ErrorMessage = responseStatus.Item(1).InnerText

                End If

            Catch ex As Exception
                m_isResponseOK = False
                m_ErrorMessage = "Error while processing response: " & ex.Message

            End Try

        End Sub
    End Class
End Namespace