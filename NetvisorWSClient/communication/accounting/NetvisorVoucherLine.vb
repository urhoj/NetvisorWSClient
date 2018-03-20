'
'
'
' Ilmentää netvisorin tositerivin
'
' Revisio $Revision$
'

Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorVoucherLine

        Private m_lineSum As Decimal
        Private m_lineDescription As String
        Private m_accountNumber As Integer
        Private m_vatPercent As Integer
        Private m_vatCode As VatCode.vatCodes
        Private m_vatCodeAbbreviation As String
        Private m_voucherLineDimensions As New ArrayList

        Public Property lineSum() As Decimal
            Get
                Return m_lineSum
            End Get
            Set(ByVal Value As Decimal)
                m_lineSum = Value
            End Set
        End Property

        Public Property lineDescription() As String
            Get
                Return m_lineDescription
            End Get
            Set(ByVal Value As String)
                m_lineDescription = Value
            End Set
        End Property

        Public Property accountNumber() As Integer
            Get
                Return m_accountNumber
            End Get
            Set(ByVal Value As Integer)
                m_accountNumber = Value
            End Set
        End Property

        Public Property vatPercent() As Integer
            Get
                Return m_vatPercent
            End Get
            Set(ByVal Value As Integer)
                m_vatPercent = Value
            End Set
        End Property

        Public Property vatCode() As VatCode.vatCodes
            Get
                Return m_vatCode
            End Get
            Set(ByVal Value As VatCode.vatCodes)
                m_vatCode = Value
            End Set
        End Property

        Public Property vatCodeAbbreviation() As String
            Get
                Return m_vatCodeAbbreviation
            End Get
            Set(ByVal Value As String)
                m_vatCodeAbbreviation = Value
            End Set
        End Property

        Public Property voucherLineDimensions() As ArrayList
            Get
                Return m_voucherLineDimensions
            End Get
            Set(ByVal Value As ArrayList)
                m_voucherLineDimensions = Value
            End Set
        End Property

        Public Sub addVoucherLineDimension(ByVal dimension As NetvisorDimension)
            m_voucherLineDimensions.Add(dimension)
        End Sub
    End Class
End Namespace
