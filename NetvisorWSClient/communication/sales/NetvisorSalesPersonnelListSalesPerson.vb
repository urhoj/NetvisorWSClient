Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorSalesPersonnelListSalesPerson


        Private m_netvisorKey As Integer
        Private m_firstName As String
        Private m_lastName As String
        Private m_provisionPercent As Decimal


		Public Property firstName() As String
			 Get
				 Return m_firstName
			 End Get			
			 Set(ByVal Value As String)
				 m_firstName = Value
			 End Set
		 End Property


		Public Property lastName() As String
			 Get
				 Return m_lastName
			 End Get			
			 Set(ByVal Value As String)
				 m_lastName = Value
			 End Set
		 End Property


		Public Property provisionPercent() As Decimal
			 Get
				 Return m_provisionPercent
			 End Get			
			 Set(ByVal Value As Decimal)
				 m_provisionPercent = Value
			 End Set
		 End Property


        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

    End Class
End Namespace