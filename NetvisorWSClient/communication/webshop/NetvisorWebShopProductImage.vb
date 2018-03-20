'
'
' Ilmentää Netvisorin verkkokauppatuotteen tuotekuvan
'

Imports System.Xml
Imports NetvisorWSClient.util
Imports System.Collections.Specialized

Namespace NetvisorWSClient.communication.webshop

    Public Class NetvisorWebShopProductImage

        Private m_MimeType As String
        Private m_Title As String
        Private m_FileName As String
        Private m_DocumentData As Byte()

        Public Property MimeType() As String
            Get
                Return m_MimeType
            End Get
            Set(ByVal Value As String)
                m_MimeType = Value
            End Set
        End Property

        Public Property Title() As String
            Get
                Return m_title
            End Get
            Set(ByVal Value As String)
                m_title = Value
            End Set
        End Property

        Public Property FileName() As String
            Get
                Return m_fileName
            End Get
            Set(ByVal Value As String)
                m_fileName = Value
            End Set
        End Property

        Public Property DocumentData() As Byte()
            Get
                Return m_documentData
            End Get
            Set(ByVal Value As Byte())
                m_documentData = Value
            End Set
        End Property

    End Class

End Namespace