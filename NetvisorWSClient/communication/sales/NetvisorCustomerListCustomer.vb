'
'
'
' Revisio $Revision$
'
' Ilmentää netvisorin asiakaslista vastauksessa saadun asiakkaan. Asiakaslistavastauksessa saadaan vain perustiedot
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorCustomerListCustomer

        Private m_netvisorKey As String
        Private m_name As String
        Private m_code As String
        Private m_organisationIdentifier As String
        Private m_uri As String
        
		Public Property netvisorKey() As String
			 Get
				 Return m_netvisorKey
			 End Get			
			 Set(ByVal Value As String)
				 m_netvisorKey = Value
			 End Set
		 End Property

		Public Property name() As String
			 Get
				 Return m_name
			 End Get			
			 Set(ByVal Value As String)
				 m_name = Value
			 End Set
		 End Property

		Public Property code() As String
			 Get
				 Return m_code
			 End Get			
			 Set(ByVal Value As String)
				 m_code = Value
			 End Set
		 End Property

        Public Property organisationIdentifier() As String
            Get
                Return m_organisationIdentifier
            End Get
            Set(ByVal Value As String)
                m_organisationIdentifier = Value
            End Set
        End Property

        Public Property uri() As String
            Get
                Return m_uri
            End Get
            Set(ByVal Value As String)
                m_uri = Value
            End Set
        End Property
    End Class
End Namespace