'
' Revisio $Revision$
'
' Ilmentää Netvisorin työntekijän
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.payroll
    Public Class NetvisorEmployee

        Private m_employeeidentifier As String
        Private m_firstName As String
        Private m_lastName As String
        Private m_phoneNumber As String
        Private m_email As String
        Private m_streetAddress As String
        Private m_postNumber As String
        Private m_city As String
        Private m_municipality As String
        Private m_country As String
        Private m_nationality As String
        Private m_language As String
        Private m_employeeNumber As Integer = -1
        Private m_profession As String
        Private m_payrollrulegroupname As String
        Private m_jobbegindate As Date
        Private m_bankaccountnumber As String
        Private m_accountingaccountnumber As Integer = -1
        Private m_BankIdentificationCode As String

        Public Property Employeeidentifier() As String
            Get
                Return m_employeeidentifier
            End Get
            Set(ByVal value As String)
                If Len(value) > 25 Then
                    Throw New ApplicationException("Employeeidentifier too long")
                Else
                    m_employeeidentifier = value
                End If
            End Set
        End Property

        Public Property FirstName() As String
            Get
                Return m_firstName
            End Get
            Set(ByVal value As String)
                If Len(value) > 250 Then
                    Throw New ApplicationException("First name too long")
                Else
                    m_firstName = value
                End If
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return m_lastName
            End Get
            Set(ByVal value As String)
                If Len(value) > 250 Then
                    Throw New ApplicationException("Last name too long")
                Else
                    m_lastName = value
                End If
            End Set
        End Property

        Public Property PhoneNumber() As String
            Get
                Return m_phoneNumber
            End Get
            Set(ByVal Value As String)
                m_phoneNumber = Value
            End Set
        End Property

        Public Property Email() As String
            Get
                Return m_email
            End Get
            Set(ByVal Value As String)
                m_email = Value
            End Set
        End Property

        Public Property StreetAddress() As String
            Get
                Return m_streetAddress
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 80 Then
                    Throw New ApplicationException("Streetaddress too long")
                Else
                    m_streetAddress = Value
                End If
            End Set
        End Property

        Public Property PostNumber() As String
            Get
                Return m_postNumber
            End Get
            Set(ByVal Value As String)
                m_postNumber = Value
            End Set
        End Property

        Public Property City() As String
            Get
                Return m_city
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 80 Then
                    Throw New ApplicationException("City too long")
                Else
                    m_city = Value
                End If
            End Set
        End Property

        Public Property Municipality() As String
            Get
                Return m_municipality
            End Get
            Set(ByVal Value As String)
                m_municipality = Value
            End Set
        End Property

        Public Property Country() As String
            Get
                Return m_country
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 2 Then
                    Throw New ApplicationException("Country too long")
                Else
                    m_country = Value
                End If
            End Set
        End Property

        Public Property Nationality() As String
            Get
                Return m_nationality
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 2 Then
                    Throw New ApplicationException("Nationality too long")
                Else
                    m_nationality = Value
                End If
            End Set
        End Property

        Public Property Language() As String
            Get
                Return m_language
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 2 Then
                    Throw New ApplicationException("Language too long")
                Else
                    m_language = Value
                End If
            End Set
        End Property

        Public Property EmployeeNumber() As Integer
            Get
                Return m_employeeNumber
            End Get
            Set(ByVal Value As Integer)
                m_employeeNumber = Value
            End Set
        End Property

        Public Property Profession() As String
            Get
                Return m_profession
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 80 Then
                    Throw New ApplicationException("Profession too long")
                Else
                    m_profession = Value
                End If
            End Set
        End Property

        Public Property JobBeginDate() As Date
            Get
                Return m_jobbegindate
            End Get
            Set(ByVal Value As Date)
                m_jobbegindate = Value
            End Set
        End Property

        Public Property Payrollrulegroupname() As String
            Get
                Return m_payrollrulegroupname
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 50 Then
                    Throw New ApplicationException("Payroll rule group name too long")
                Else
                    m_payrollrulegroupname = Value
                End If
            End Set
        End Property

        Public Property Bankaccountnumber() As String
            Get
                Return m_bankaccountnumber
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 34 Then
                    Throw New ApplicationException("Bank account number too long")
                Else
                    m_bankaccountnumber = Value
                End If
            End Set
        End Property

        Public Property BankIdentificationCode() As String
            Get
                Return m_BankIdentificationCode
            End Get
            Set(ByVal Value As String)
                If Len(Value) > 20 Then
                    Throw New ApplicationException("Bank identification code too long")
                Else
                    m_BankIdentificationCode = Value
                End If
            End Set
        End Property

        Public Property Accountingaccountnumber() As Integer
            Get
                Return m_accountingaccountnumber
            End Get
            Set(ByVal Value As Integer)
                m_accountingaccountnumber = Value
            End Set
        End Property

    End Class
End Namespace
