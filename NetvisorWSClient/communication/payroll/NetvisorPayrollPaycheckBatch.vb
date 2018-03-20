'
'
'
' Revisio $Revision$
' 
' Imentää Netvisorin palkkalaskelman
'

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorPayrollPaycheckBatch

        Public Const IDENTIFIER_EMPLOYEE_NUMBER As String = "employeenumber"
        Public Const IDENTIFIER_FINNISH_PERSONAL_IDENTIFIER As String = "finnishpersonalidentifier"

        Public Enum employeeIdentifierTypes
            employeeNumber = 1
            finnishPersonalIdentifier = 2
        End Enum

        Private m_employeeIdentifier As Object
        Private m_employeeIdentifierType As employeeIdentifierTypes
        Private m_ruleGroupPeriodStart As Date
        Private m_ruleGroupPeriodEnd As Date
        Private m_freeTextBeforeLines As String
        Private m_freeTextAfterLines As String
        Private m_dueDate As Date
        Private m_valueDate As Date        
        Private m_batchLines As New ArrayList

        Public Property employeeIdentifier() As Object
            Get
                Return m_employeeIdentifier
            End Get
            Set(ByVal Value As Object)
                m_employeeIdentifier = Value
            End Set
        End Property

        Public Property employeeIdentifierType() As employeeIdentifierTypes
            Get
                Return m_employeeIdentifierType
            End Get
            Set(ByVal Value As employeeIdentifierTypes)
                m_employeeIdentifierType = Value
            End Set
        End Property

        Public Property ruleGroupPeriodStart() As Date
            Get
                Return m_ruleGroupPeriodStart
            End Get
            Set(ByVal Value As Date)
                m_ruleGroupPeriodStart = Value
            End Set
        End Property

        Public Property ruleGroupPeriodEnd() As Date
            Get
                Return m_ruleGroupPeriodEnd
            End Get
            Set(ByVal Value As Date)
                m_ruleGroupPeriodEnd = Value
            End Set
        End Property

        Public Property freeTextBeforeLines() As String
            Get
                Return m_freeTextBeforeLines
            End Get
            Set(ByVal Value As String)
                m_freeTextBeforeLines = Value
            End Set
        End Property

        Public Property freeTextAfterLines() As String
            Get
                Return m_freeTextAfterLines
            End Get
            Set(ByVal Value As String)
                m_freeTextAfterLines = Value
            End Set
        End Property

        Public Property dueDate() As Date
            Get
                Return m_dueDate
            End Get
            Set(ByVal Value As Date)
                m_dueDate = Value
            End Set
        End Property

        Public Property valueDate() As Date
            Get
                Return m_valueDate
            End Get
            Set(ByVal Value As Date)
                m_valueDate = Value
            End Set
        End Property

        Public ReadOnly Property batchLines() As ArrayList
            Get
                Return m_batchLines
            End Get
        End Property

        Public Sub addBatchLine(ByVal batchLine As NetvisorPayrollPaycheckBatchLine)
            m_batchLines.Add(batchLine)
        End Sub

        Public Sub clearBatchLines()
            m_batchLines.Clear()
        End Sub
    End Class
End Namespace