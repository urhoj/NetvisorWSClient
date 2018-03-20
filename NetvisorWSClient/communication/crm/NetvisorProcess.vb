Imports NetvisorWSClient.communication.sales

'
' Revisio $Revision$
' 
' Ilmentää tehtävän Netvisorin asiakkuuden hallinnassa
'

Namespace NetvisorWSClient.communication.crm

    Public Class NetvisorProcess

        Private m_ProcessTemplate As NetvisorProcessTemplate
        Private m_ProcessIdentifier As String
        Private m_CustomerIdentifier As String
        Private m_Description As String
        Private m_Name As String
        Private m_DueDate As Date
        Private m_IsClosed As Boolean
        Private m_Customer As NetvisorCustomer
        Private m_CurrentProcessStageName As String
        Private m_Project As NetvisorProcessProject
        Private m_CorrespondPersonName As String
        Private m_CompletedDate As Date
        Private m_ContactPersonName As String
        Private m_ContactPersonPhoneNumber As String
        Private m_ContactPersonEmail As String
        Private m_SalesInvoiceStatusDescription As String
        Private m_SalesInvoices As ArrayList
        Private m_Expences As ArrayList
        Private m_Comments As ArrayList
        Private m_InvoicingStatusIdentifier As String


        Public Property ProcessTemplate() As NetvisorProcessTemplate
            Get
                Return m_ProcessTemplate
            End Get
            Set(ByVal value As NetvisorProcessTemplate)
                m_ProcessTemplate = value
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

        Public Property ProcessIdentifier() As String
            Get
                Return m_processIdentifier
            End Get
            Set(ByVal value As String)
                m_processIdentifier = value
            End Set
        End Property

        Public Property InvoicingStatusIdentifier() As String
            Get
                Return m_InvoicingStatusIdentifier
            End Get
            Set(ByVal value As String)
                m_InvoicingStatusIdentifier = value
            End Set
        End Property

        Public Property CustomerIdentifier() As String
            Get
                Return m_customerIdentifier
            End Get
            Set(ByVal value As String)
                m_customerIdentifier = value
            End Set
        End Property

        Public Property Name() As String
            Get
                Return m_name
            End Get
            Set(ByVal value As String)
                m_name = value
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


        Public Property Customer() As netvisorcustomer
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

        Public Property Project() As NetvisorProcessProject
            Get
                Return m_Project
            End Get
            Set(ByVal value As NetvisorProcessProject)
                m_Project = value
            End Set
        End Property

        Public Property CorrespondPersonName() As String
            Get
                Return m_CorrespondPersonName
            End Get
            Set(ByVal value As String)
                m_CorrespondPersonName = value
            End Set
        End Property

        Public Property ContactPersonName() As String
            Get
                Return m_ContactPersonName
            End Get
            Set(ByVal value As String)
                m_ContactPersonName = value
            End Set
        End Property

        Public Property ContactPersonPhoneNumber() As String
            Get
                Return m_ContactPersonPhoneNumber
            End Get
            Set(ByVal value As String)
                m_ContactPersonPhoneNumber = value
            End Set
        End Property

        Public Property ContactPersonEmail() As String
            Get
                Return m_ContactPersonEmail
            End Get
            Set(ByVal value As String)
                m_ContactPersonEmail = value
            End Set
        End Property

        Public Property SalesInvoiceStatusDescription() As String
            Get
                Return m_SalesInvoiceStatusDescription
            End Get
            Set(ByVal value As String)
                m_SalesInvoiceStatusDescription = value
            End Set
        End Property

        Public Property CompletedDate() As Date
            Get
                Return m_CompletedDate
            End Get
            Set(ByVal value As Date)
                m_CompletedDate = value
            End Set
        End Property

        Public Property Comments() As ArrayList
            Get
                Return m_Comments
            End Get
            Set(ByVal value As ArrayList)
                m_Comments = value
            End Set
        End Property

        Public Property SalesInvoices() As ArrayList
            Get
                Return m_SalesInvoices
            End Get
            Set(ByVal value As ArrayList)
                m_SalesInvoices = value
            End Set
        End Property

        Public Property Expences() As ArrayList
            Get
                Return m_Expences
            End Get
            Set(ByVal value As ArrayList)
                m_Expences = value
            End Set
        End Property

    End Class

End Namespace