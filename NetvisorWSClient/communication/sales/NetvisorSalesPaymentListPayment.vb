'
'
'
' Revisio $Revision$
'
' Ilmentää netvisorin myyntisuoritus listauksessa tulevan tulevan suorituksen
'

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorSalesPaymentListPayment

        Public Structure OptionalLimitSalesPayments
            Public Const ParameterName As String = "limitbytype"
            Public Const ExcludeCreditLoss As String = "excludecreditloss"
            Public Const OnlyCreditLoss As String = "onlycreditloss"
        End Structure

        Public Enum bankStatuses As Integer
            ok = 1
            failed = 2
        End Enum

        Public Enum returnCodes As Integer
            noAccountFound = 1
            balanceIsExceeded = 2
            noPaymentServiceAccount = 3
            payerHasCancelled = 4
            bankHasCancelled = 5
            cancellationNotClearing = 6
            authorizationIsMissing = 7
            errorInDueDate = 8
            formNotCorrect = 9
        End Enum

        Private m_netvisorKey As Integer
        Private m_name As String
        Private m_paymentDate As Date
        Private m_sum As Decimal
        Private m_referenceNumber As String
        Private m_foreignCurrencyAmount As Decimal
        Private m_invoiceNumber As String
        Private m_bankStatus As bankStatuses
        Private m_returnCode As returnCodes
        Private m_returnCodeDescription As String
        
		Public Property netvisorKey() As Integer
			 Get
				 Return m_netvisorKey
			 End Get			
			 Set(ByVal Value As Integer)
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

		Public Property paymentDate() As Date
			 Get
				 Return m_paymentDate
			 End Get			
			 Set(ByVal Value As Date)
				 m_paymentDate = Value
			 End Set
		 End Property

		Public Property sum() As Decimal
			 Get
				 Return m_sum
			 End Get			
			 Set(ByVal Value As Decimal)
				 m_sum = Value
			 End Set
		 End Property

		Public Property referenceNumber() As String
			 Get
				 Return m_referenceNumber
			 End Get			
			 Set(ByVal Value As String)
				 m_referenceNumber = Value
			 End Set
		 End Property

		Public Property foreignCurrencyAmount() As Decimal
			 Get
				 Return m_foreignCurrencyAmount
			 End Get			
			 Set(ByVal Value As Decimal)
				 m_foreignCurrencyAmount = Value
			 End Set
		 End Property

        Public Property invoiceNumber() As String
            Get
                Return m_invoiceNumber
            End Get
            Set(ByVal Value As String)
                m_invoiceNumber = Value
            End Set
        End Property

		Public Property bankStatus() As bankStatuses
			 Get
				 Return m_bankStatus
			 End Get			
			 Set(ByVal Value As bankStatuses)
				 m_bankStatus = Value
			 End Set
		 End Property

		Public Property returnCode() As returnCodes
			 Get
				 Return m_returnCode
			 End Get			
			 Set(ByVal Value As returnCodes)
				 m_returnCode = Value
			 End Set
		 End Property

		Public Property returnCodeDescription() As String
			 Get
				 Return m_returnCodeDescription
			 End Get			
			 Set(ByVal Value As String)
				 m_returnCodeDescription = Value
			 End Set
		 End Property
    End Class
End Namespace