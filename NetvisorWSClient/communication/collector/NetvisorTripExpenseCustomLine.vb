'
'
'
' Revisio $Revision$
'
' Ilmentää tripexpensecustomlinesresponsen matkalaskurivin
'

Namespace NetvisorWSClient.communication.collector
    Public Class NetvisorTripExpenseCustomLine

        Private m_netvisorKey As Integer
        Private m_paymentReciever As String
        Private m_expenseRatioName As String
        Private m_unitAmount As Decimal
        Private m_unitSum As Decimal
        Private m_vatPercentage As Decimal
        Private m_lineSum As Decimal
        Private m_comment As String
        Private m_lineStatus As String

        Public Property netvisorKey() As Integer
            Get
                Return m_netvisorKey
            End Get
            Set(ByVal Value As Integer)
                m_netvisorKey = Value
            End Set
        End Property

		Public Property paymentReciever() As String
			 Get
				 Return m_paymentReciever
			 End Get			
			 Set(ByVal Value As String)
				 m_paymentReciever = Value
			 End Set
        End Property

		Public Property expenseRatioName() As String
			 Get
				 Return m_expenseRatioName
			 End Get			
			 Set(ByVal Value As String)
				 m_expenseRatioName = Value
			 End Set
        End Property

        Public Property unitAmount() As Decimal
            Get
                Return m_unitAmount
            End Get
            Set(ByVal Value As Decimal)
                m_unitAmount = Value
            End Set
        End Property

        Public Property unitSum() As Decimal
            Get
                Return m_unitSum
            End Get
            Set(ByVal Value As Decimal)
                m_unitSum = Value
            End Set
        End Property

        Public Property vatPercentage() As Decimal
            Get
                Return m_vatPercentage
            End Get
            Set(ByVal Value As Decimal)
                m_vatPercentage = Value
            End Set
        End Property

        Public Property lineSum() As Decimal
            Get
                Return m_lineSum
            End Get
            Set(ByVal Value As Decimal)
                m_lineSum = Value
            End Set
        End Property

		Public Property comment() As String
			 Get
				 Return m_comment
			 End Get			
			 Set(ByVal Value As String)
				 m_comment = Value
			 End Set
		 End Property

		Public Property lineStatus() As String
			 Get
				 Return m_lineStatus
			 End Get			
			 Set(ByVal Value As String)
				 m_lineStatus = Value
			 End Set
		 End Property
    End Class
End Namespace