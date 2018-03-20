
'
' Revisio $Revision$
'

Namespace NetvisorWSClient.communication.accounting

    Public Class NetvisorAccountList

        Private m_accountList As New List(Of NetvisorAccount)
        Private m_companyDefaultAccounts As New Hashtable

        Public Property accountList As List(Of NetvisorAccount)
            Get
                Return m_accountList
            End Get
            Set(value As List(Of NetvisorAccount))
                m_accountList = value
            End Set
        End Property

        Public Property companyDefaultAccounts As Hashtable
            Get
                Return m_companyDefaultAccounts
            End Get
            Set(value As Hashtable)
                m_companyDefaultAccounts = value
            End Set
        End Property

    End Class

End Namespace