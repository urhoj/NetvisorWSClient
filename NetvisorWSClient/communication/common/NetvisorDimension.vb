'
'
'
' Revisio $Revision$
'
' Ilmentää netvisorin laskentakohteen
' esim. tosite tai laskuriville
'

Imports System.Xml

Namespace NetvisorWSClient.communication.common
	<ComClass(NetvisorDimension.ClassId, NetvisorDimension.InterfaceId, NetvisorDimension.EventsId)> Public Class NetvisorDimension

        Public Enum DimensionMetadataType As Integer
            StartDate = 1
            OrganizationIdentifier = 2
            CurrencyISO4217Code = 3
            Other = 4
            DimensionType = 5
        End Enum

		Public Const ClassId As String = "CD761A57-49D3-4037-AB4E-578594D9157B"
		Public Const InterfaceId As String = "477FDB2E-BFE7-4056-85C9-9AE8D36A2382"
		Public Const EventsId As String = "1F9BC07D-4042-44a8-9AEB-E9EEE76D481E"

		Private m_dimensionName As String
		Private m_dimensionDetail As String
        Private m_dimensionDetailFatherID As Integer
        Private m_integrationDimensionDetailGuid As String
        Private m_dimensionDetailOldItem As String
        Private m_dimensionDetailFatherItem As String
        Private m_integrationDimensionDetailFatherGuid As String
        Private m_dimensionDetailMetaDataList As New List(Of KeyValuePair(Of String, DimensionMetadataType?))

        Public Property dimensionDetailOldItem() As String
            Get
                Return m_dimensionDetailOldItem
            End Get
            Set(ByVal Value As String)
                m_dimensionDetailOldItem = Value
            End Set
        End Property


        Public Property dimensionDetailFatherItem() As String
            Get
                Return m_dimensionDetailFatherItem
            End Get
            Set(ByVal Value As String)
                m_dimensionDetailFatherItem = Value
            End Set
        End Property


        Public Property integrationDimensionDetailFatherGuid() As String
            Get
                Return m_integrationDimensionDetailFatherGuid
            End Get
            Set(ByVal Value As String)
                m_integrationDimensionDetailFatherGuid = Value
            End Set
        End Property

        Public Sub New()
        End Sub

        Public Sub New(ByVal dimensionName As String, ByVal dimensionDetail As String)
            m_dimensionName = dimensionName
            m_dimensionDetail = dimensionDetail
        End Sub

        Public Sub New(ByVal dimensionName As String, ByVal dimensionDetail As String, ByVal dimensionDetailFatherID As Integer)
            m_dimensionName = dimensionName
            m_dimensionDetail = dimensionDetail
            m_dimensionDetailFatherID = dimensionDetailFatherID
        End Sub

        Public Property dimensionName() As String
            Get
                Return m_dimensionName
            End Get
            Set(ByVal Value As String)
                m_dimensionName = Value
            End Set
        End Property

        Public Property dimensionDetail() As String
            Get
                Return m_dimensionDetail
            End Get
            Set(ByVal Value As String)
                m_dimensionDetail = Value
            End Set
        End Property

        Public Property dimensionDetailFatherID() As Integer
            Get
                Return m_dimensionDetailFatherID
            End Get
            Set(ByVal Value As Integer)
                m_dimensionDetailFatherID = Value
            End Set
        End Property

        Public Property integrationDimensionDetailGuid() As String
            Get
                Return m_integrationDimensionDetailGuid
            End Get
            Set(ByVal Value As String)
                m_integrationDimensionDetailGuid = Value
            End Set
        End Property


        Public Sub writeDimensionElement(ByRef xmlWriter As XmlTextWriter)

            With xmlWriter
                .WriteStartElement("Dimension")
                .WriteElementString("DimensionName", m_dimensionName)
                .WriteStartElement("DimensionItem")

                If m_dimensionDetailFatherID > 0 Then
                    .WriteAttributeString("fatherid", m_dimensionDetailFatherID)
                End If

               
                .WriteString(m_dimensionDetail)
                .WriteEndElement() '/ DimensionItem
                .WriteEndElement() '/ Dimension
            End With
        End Sub

        Public Sub addDimensionDetailMetaData(data As String)
            addDimensionDetailMetaData(data, Nothing)
        End Sub

        Public Sub addDimensionDetailMetaDataWithType(data As String, type As DimensionMetadataType)
            addDimensionDetailMetaData(data, type)
        End Sub

        Private Sub addDimensionDetailMetaData(data As String, type As DimensionMetadataType?)
            m_dimensionDetailMetaDataList.Add(New KeyValuePair(Of String, DimensionMetadataType?)(data, type))
        End Sub

        Public ReadOnly Property dimensionDetailMetaDataList As List(Of String)
            Get
                Return m_dimensionDetailMetaDataList.Select(Function(x) x.Key).ToList()
            End Get
        End Property

        Public ReadOnly Property dimensionDetailMetaDataListWithType As List(Of KeyValuePair(Of String, DimensionMetadataType?))
            Get
                Return m_dimensionDetailMetaDataList
            End Get
        End Property


    End Class
End Namespace