'
' Revisio $Revision$
'
' Ilmentää budjetille lukitun laskentakohteen
'

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetLockedDimension.ClassId, NetvisorAccountingBudgetLockedDimension.InterfaceId, _
                NetvisorAccountingBudgetLockedDimension.EventsId)> _
    Public Class NetvisorAccountingBudgetLockedDimension

        Public Const ClassId As String = "EB9E1894-90E4-4a7c-A66E-058A8B28E9BF"
        Public Const InterfaceId As String = "1847EDEC-9C9A-488b-8351-8DB055B51E55"
        Public Const EventsId As String = "C09E5D3D-7D6A-4bb9-B1A6-3BBAE3C86B1A"

        Private m_dimensionName As String
        Private m_dimensionItemName As String

        Public Property DimensionName As String
            Get
                Return m_dimensionName
            End Get
            Set(ByVal Value As String)
                m_dimensionName = Value
            End Set
        End Property

        Public Property DimensionItemName As String
            Get
                Return m_dimensionItemName
            End Get
            Set(ByVal Value As String)
                m_dimensionItemName = Value
            End Set
        End Property

        Public Sub New()

        End Sub

    End Class
End Namespace