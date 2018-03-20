'
'
'
' Revisio $Revision$
'
' Ilmentää palkkajaksokohtaisen kirjauksen
'

Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.collector
    <ComClass(NetvisorPayrollRatioLine.ClassId, NetvisorPayrollRatioLine.InterfaceId, NetvisorPayrollRatioLine.EventsId)> Public Class NetvisorPayrollRatioLine

        Public Const ClassId As String = "D8BFED1B-1F6A-442E-95A9-FFCA30D3EDAB"
        Public Const InterfaceId As String = "D91EA0D4-93A6-4D26-BE1A-F432E0891713"
        Public Const EventsId As String = "55D99983-A752-4B8C-83F0-2B31B792095A"

        Private m_Amount As Decimal
        Private m_PayrollRatioNumber As String
        Private m_dimensions As New ArrayList

        Public Property Amount() As Decimal
            Get
                Return m_Amount
            End Get
            Set(ByVal Value As Decimal)
                m_Amount = Value
            End Set
        End Property

        Public Sub setAmount(ByVal amount As String)
            m_Amount = Decimal.Parse(amount)
        End Sub

        Public Property PayrollRatioNumber() As String
            Get
                Return m_PayrollRatioNumber
            End Get
            Set(ByVal Value As String)
                m_PayrollRatioNumber = Value
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