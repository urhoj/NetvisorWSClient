Imports NetvisorWSClient.communication.common

'
'
'
' Revisio $Revision$
'
' Ilmentää Netvisorin palkkalaskelman rivin
' 

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorPayrollPaycheckBatchLine

        Public Const RATIO_IDENTIFIER_RATIO_NUMBER As String = "rationumber"

        Public Enum payrollRatioIdentifierTypes
            rationumber = 1
        End Enum

        Private m_payrollRatioIdentifier As Object
        Private m_payrollRatioIdentifierType As payrollRatioIdentifierTypes
        Private m_units As Decimal
        Private m_unitAmount As Decimal
        Private m_lineSum As Decimal
        Private m_description As String
        Private m_batchLineDimensions As New ArrayList

        Public Property payrollRatioIdentifier() As Object
            Get
                Return m_payrollRatioIdentifier
            End Get
            Set(ByVal Value As Object)
                m_payrollRatioIdentifier = Value
            End Set
        End Property

        Public Property payrollRatioIdentifierType() As payrollRatioIdentifierTypes
            Get
                Return m_payrollRatioIdentifierType
            End Get
            Set(ByVal Value As payrollRatioIdentifierTypes)
                m_payrollRatioIdentifierType = Value
            End Set
        End Property

        Public Property units() As Decimal
            Get
                Return m_units
            End Get
            Set(ByVal Value As Decimal)
                m_units = Value
            End Set
        End Property

        Public Property unitAmount() As Decimal
            Get
                Return m_unitAmount
            End Get
            Set(ByVal Value As Decimal)
                m_unitAmount = Value
            End Set
        End Property

        Public Property lineSum() As Decimal
            Get
                Return m_lineSum
            End Get
            Set(ByVal Value As Decimal)
                m_lineSum = Value
            End Set
        End Property

        Public Property description() As String
            Get
                Return m_description
            End Get
            Set(ByVal Value As String)
                m_description = Value
            End Set
        End Property

        Public ReadOnly Property batchLineDimensions() As ArrayList
            Get
                Return m_batchLineDimensions
            End Get
        End Property

        Public Sub addNewDimension(ByVal dimension As NetvisorDimension)
            m_batchLineDimensions.Add(dimension)
        End Sub

    End Class
End Namespace