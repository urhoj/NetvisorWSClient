'
'
'
' Revisio $Revision$
'
' Ilmentää kirjanpitoaineiston haussa saadun tositteen
' eroaa vähän netvisoriin vietävästä tositteesta
' perii netvisorvoucherin
'

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorAccountingLedgerVoucher
        Inherits NetvisorVoucher

        Public Enum VoucherResponseStatus As Integer

            VALID = 1
            INVALIDATED = 2
            DELETED = 3

        End Enum

        Private m_netvisorKey As Integer
        Private m_voucherNetvisorURI As String
        Private m_Status As VoucherResponseStatus? = Nothing
        Private m_LinkedSourceType As String
        Private m_LinkedSourceNetvisorKey As Integer?

        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

        Public Property voucherNetvisorURI() As String
            Get
                Return m_voucherNetvisorURI
            End Get
            Set(ByVal Value As String)
                m_voucherNetvisorURI = Value
            End Set
        End Property

        Public Property Status() As VoucherResponseStatus?
            Get
                Return m_Status
            End Get
            Set(ByVal value As VoucherResponseStatus?)
                m_Status = value
            End Set
        End Property

        Public Property LinkedSourceType As String
            Get
                Return m_LinkedSourceType
            End Get
            Set(ByVal value As String)
                m_LinkedSourceType = value
            End Set
        End Property

        Public Property LinkedSourceNetvisorKey As Integer?
            Get
                Return m_LinkedSourceNetvisorKey
            End Get
            Set(ByVal value As Integer?)
                m_LinkedSourceNetvisorKey = value
            End Set
        End Property

    End Class
End Namespace
