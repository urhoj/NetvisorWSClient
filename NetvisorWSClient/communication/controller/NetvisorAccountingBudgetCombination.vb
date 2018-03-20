'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisoriin vietävän budjetin laskentakohdeyhdistelmän
'

Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.controller
    <ComClass(NetvisorAccountingBudgetCombination.ClassId, NetvisorAccountingBudgetCombination.InterfaceId, _
            NetvisorAccountingBudgetCombination.EventsId)> _
    Public Class NetvisorAccountingBudgetCombination

        Public Const ClassId As String = "8D645A3E-9B98-4fd3-A5EF-5F47DFFBC2ED"
        Public Const InterfaceId As String = "B77A75D2-8F9F-4985-B458-AE2D12252958"
        Public Const EventsId As String = "625C8E96-4D43-46a4-AC0A-D07887D71F14"

        Private m_combinationSum As Decimal
        Private m_dimensions As New ArrayList

        Public Property combinationSum() As Decimal
            Get
                Return m_combinationSum
            End Get
            Set(ByVal Value As Decimal)
                m_combinationSum = Value
            End Set
        End Property

        Public ReadOnly Property dimensions() As ArrayList
            Get
                Return m_dimensions
            End Get
        End Property

        Public Sub addDimension(ByVal dimension As NetvisorDimension)
            m_dimensions.Add(dimension)
        End Sub

        Public Sub clearDimensions()
            m_dimensions.Clear()
        End Sub
    End Class
End Namespace