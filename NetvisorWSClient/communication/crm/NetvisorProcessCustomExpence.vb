'
' Revisio $Revision$
' 
' Ilmentää tehtävään liittyvän kustannuksen Netvisorin asiakkuuden hallinnassa
'

Public Class NetvisorProcessCustomExpence

    Private m_CrmProcessIdentifier As String
    Private m_InvoicingProductIdentifier As String
    Private m_Description As String
    Private m_Amount As Double
    Private m_PriceGroupName As String

    Public Property PriceGroupName() As String
        Get
            Return m_PriceGroupName
        End Get
        Set(ByVal Value As String)
            m_PriceGroupName = Value
        End Set
    End Property

    Public Property CrmProcessIdentifier() As String
        Get
            Return m_CrmProcessIdentifier
        End Get
        Set(ByVal Value As String)
            m_CrmProcessIdentifier = Value
        End Set
    End Property

    Public Property InvoicingProductIdentifier() As String
        Get
            Return m_InvoicingProductIdentifier
        End Get
        Set(ByVal Value As String)
            m_InvoicingProductIdentifier = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return m_Description
        End Get
        Set(ByVal Value As String)
            m_Description = Value
        End Set
    End Property

    Public Property Amount() As Double
        Get
            Return m_Amount
        End Get
        Set(ByVal value As Double)
            m_Amount = value
        End Set
    End Property
End Class
