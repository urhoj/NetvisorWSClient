Imports NetvisorWSClient.communication.sales

'
' Revisio $Revision$
'
' Ilmentää netvisorin tehtävälistauksessa tulevan tehtävän
'

Namespace NetvisorWSClient.communication.crm

    Public Class NetvisorProcessListProcess

        Private m_netvisorKey As Integer
        Private m_ProcessTemplate As NetvisorProcessTemplate
        Private m_ProcessIdentifier As String
        Private m_Name As String
        Private m_DueDate As Date
        Private m_IsClosed As Boolean
        Private m_Customer As NetvisorCustomer
        Private m_CurrentProcessStageName As String
        Private m_Description As String

        Public Property NetvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal value As Integer)
                m_netvisorKey = value
            End Set
        End Property

        Public Property ProcessTemplate() As NetvisorProcessTemplate
            Get
                Return m_ProcessTemplate
            End Get
            Set(ByVal value As NetvisorProcessTemplate)
                m_ProcessTemplate = value
            End Set
        End Property

        Public Property ProcessIdentifier() As String
            Get
                Return m_processIdentifier
            End Get
            Set(ByVal value As String)
                m_processIdentifier = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(ByVal value As String)
                m_Name = value
            End Set
        End Property

        Public Property IsClosed() As Boolean
            Get
                Return m_IsClosed
            End Get
            Set(ByVal value As Boolean)
                m_IsClosed = value
            End Set
        End Property

        Public Property Duedate() As Date
            Get
                Return m_duedate
            End Get
            Set(ByVal value As Date)
                m_duedate = value
            End Set
        End Property


        Public Property Customer() As NetvisorCustomer
            Get
                Return m_Customer
            End Get
            Set(ByVal value As NetvisorCustomer)
                m_Customer = value
            End Set
        End Property

        Public Property CurrentProcessStageName() As String
            Get
                Return m_CurrentProcessStageName
            End Get
            Set(ByVal value As String)
                m_CurrentProcessStageName = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(ByVal value As String)
                m_Description = value
            End Set
        End Property

    End Class

End Namespace