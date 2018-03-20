'
'
'
' Revisio $Revision$
'
' Ilmentää netvisorin tositteen
Imports NetvisorWSClient.communication.common

Namespace NetvisorWSClient.communication.accounting
    Public Class NetvisorVoucher

        Private m_voucherCalculationModeIsGross As Boolean       
        Private m_VoucherDate As Date
        Private m_voucherNumber As Long
        Private m_description As String
        Private m_voucherclass As String
        Private m_voucherLines As New ArrayList
        Private m_attachments As New ArrayList

        Public Property voucherCalculationModeIsGross() As Boolean
            Get
                Return m_voucherCalculationModeIsGross
            End Get
            Set(ByVal Value As Boolean)
                m_voucherCalculationModeIsGross = Value
            End Set
        End Property

        Public Property VoucherDate() As Date
            Get
                Return m_VoucherDate
            End Get
            Set(ByVal value As Date)
                m_VoucherDate = value
            End Set
        End Property

        Public Property VoucherClass() As String
            Get
                Return m_voucherclass
            End Get
            Set(ByVal value As String)
                m_voucherclass = value
            End Set
        End Property

        Public Property voucherNumber() As Long
            Get
                Return m_voucherNumber
            End Get
            Set(ByVal Value As Long)
                m_voucherNumber = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_description
            End Get
            Set(ByVal value As String)
                m_description = value
            End Set
        End Property

        Public ReadOnly Property voucherLines() As ArrayList
            Get
                Return m_voucherLines
            End Get
        End Property

        Public ReadOnly Property attachments() As ArrayList
            Get
                Return m_attachments
            End Get
        End Property

        Public Sub addVoucherLine(ByVal line As NetvisorVoucherLine)
            m_voucherLines.Add(line)
        End Sub

        Public Sub addAttachment(ByVal attachment As NetvisorAttachment)
            m_attachments.Add(attachment)
        End Sub

    End Class
End Namespace
