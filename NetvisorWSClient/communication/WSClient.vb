'
' Revisio $Revision$
'
' Kaikki kommunikointi Netvisorin ja clientin välillä kulkee tätä kautta. 
' Hoitaa auhtentikointi-headerit, pyynnön muodostuksen ja lähetyksen
'

Imports System.Collections.Specialized
Imports System.Web
Imports System.Net
Imports System.IO
Imports System.Security.Cryptography
Imports System.Xml

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication
    <ComClass(WSClient.ClassId, WSClient.InterfaceId, WSClient.EventsId)> Public Class WSClient

        Public Const ClassId As String = "98349785-8BE2-4604-848D-F5B103D6171D"
        Public Const InterfaceId As String = "36613EE9-125F-493d-9968-771E18C2226F"
        Public Const EventsId As String = "A036F02F-F87E-4548-A536-7DD7EA8E62B2"

        Public Const BASE_URL_PRODUCTION As String = "https://integration.netvisor.fi/"
        Public Const BASE_URL_DEMO As String = "http://integrationdemo.netvisor.fi/"
        Public Const BASE_URL_ISV As String = "http://kehitys.netvisor.fi/"

        Public Const ACTION_CUSTOMER As String = "customer.nv"
        Public Const ACTION_SALESINVOICE As String = "salesinvoice.nv"
        Public Const ACTION_SALESINVOICE_LIST As String = "salesinvoicelist.nv"
        Public Const ACTION_PURCHASEINVOICE_LIST As String = "purchaseinvoicelist.nv"
        Public Const ACTION_ESCAN As String = "escan.nv"
        Public Const ACTION_ACCOUNTING As String = "accounting.nv"
        Public Const ACTION_CUSTOMER_LIST As String = "customerlist.nv"
        Public Const ACTION_SALESPAYMENT As String = "salespayment.nv"
        Public Const ACTION_PURCHASEINVOICE As String = "purchaseinvoice.nv"
        Public Const ACTION_ACCOUNTING_LEDGER As String = "accountingledger.nv"
        Public Const ACTION_PRODUCT As String = "product.nv"
        Public Const ACTION_PRODUCT_LIST As String = "productlist.nv"
        Public Const ACTION_GETPRODUCT As String = "getproduct.nv"
        Public Const ACTION_PAYROLL_PAYCHECK_BATCH As String = "payrollpaycheckbatch.nv"
        Public Const ACTION_SALESPAYMENT_LIST As String = "salespaymentlist.nv"
        Public Const ACTION_GETSALESINVOICE As String = "getsalesinvoice.nv"
        Public Const ACTION_GETCUSTOMER As String = "getcustomer.nv"
        Public Const ACTION_WORKDAY As String = "workday.nv"
        Public Const ACTION_ACCOUNTING_BUDGET As String = "accountingbudget.nv"
        Public Const ACTION_DELETE_SALESINVOICE As String = "deletesalesinvoice.nv"
        Public Const ACTION_OUTGOINGPAYMENT As String = "payment.nv"
        Public Const ACTION_CRM_PROCESS As String = "crmprocess.nv"
        Public Const ACTION_DIMENSION_LIST As String = "dimensionlist.nv"
        Public Const ACTION_EMPLOYEE As String = "employee.nv"
        Public Const ACTION_ACCOUNTING_BUDGET_ACCOUNT_LIST As String = "accountingbudgetaccountlist.nv"
        Public Const ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET As String = "accountingbudgetaccountbudget.nv"
        Public Const ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET As String = "accountingbudgetyearbudget.nv"
        Public Const ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET As String = "accountingbudgetdimensionbudget.nv"
        Public Const ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET As String = "accountingbudgetdimensionyearbudget.nv"
        Public Const ACTION_WEBSHOP_PRODUCT_LIST As String = "webshopproductlist.nv"
        Public Const ACTION_WEBSHOP_PRODUCT_IMAGES As String = "webshopproductimages.nv"
        Public Const ACTION_TRIPEXPENSE As String = "tripexpense.nv"
        Public Const ACTION_ACCOUNTLIST As String = "accountlist.nv"
        Public Const ACTION_ACCOUNTING_PERIODLIST As String = "accountingperiodlist.nv"
        Public Const ACTION_PAYROLL_ADVANCE As String = "payrolladvance.nv"
        Public Const ACTION_PAYMENT_LIST As String = "paymentlist.nv"
        Public Const ACTION_PAYROLL_PERIOD_COLLECTOR As String = "payrollperiodcollector.nv"
        Public Const ACTION_SALESPERSONNELLIST As String = "salespersonnellist.nv"
        Public Const ACTION_PURHASEORDER As String = "purchaseorder.nv"
        Public Const ACTION_PURCHASEORDER_LIST As String = "purchaseorderlist.nv"
        Public Const ACTION_GET_PURCHASEORDER As String = "getpurchaseorder.nv"
        Public Const ACTION_DIMENSIONITEM As String = "dimensionitem.nv"
        Public Const ACTION_EXTERNAL_PAYMENT As String = "payrollexternalsalarypayment.nv"
        Public Const ACTION_PAYSLIPLIST As String = "paysliplist.nv"
        Public Const ACTION_GETPAYSLIP As String = "getpayslip.nv"

        Public Enum NetvisorWebServiceIntegrationActions As Integer
            CUSTOMER = 1
            SALESINVOICE = 2
            SALESINVOICE_LIST = 3
            PURCHASEINVOICE_LIST = 4
            ESCAN = 6
            ACCOUNTING = 9
            CUSTOMER_LIST = 10
            SALESPAYMENT = 11
            PURCHASEINVOICE = 12
            ACCOUNTING_LEDGER = 13
            PRODUCT = 15
            PRODUCT_LIST = 16
            GETPRODUCT = 17
            PAYROLL_PAYCHECK_BATCH = 18
            SALESPAYMENT_LIST = 19
            GETSALESINVOICE = 20
            GETCUSTOMER = 21
            WORKDAY = 22
            ACCOUNTING_BUDGET = 23
            DELETE_SALESINVOICE = 25
            OUTGOINGPAYMENT = 26
            CRM_PROCESS = 29
            DIMENSION_LIST = 34
            ACCOUNTING_BUDGET_ACCOUNT_LIST = 36
            ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET = 37
            ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET = 38
            EMPLOYEE = 39
            ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET = 41
            ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET = 42
            WEBSHOP_PRODUCT_LIST = 44
            WEBSHOP_PRODUCT_IMAGES = 45
            TRIPEXPENSE = 46
            ACCOUNTLIST = 47
            ACCOUNTINGPERIODLIST = 48
            PAYROLL_ADVANCE = 50
            PAYMENT_LIST = 51
            PAYROLL_PERIOD_COLLECTOR = 52
            SALESPERSONNELLIST = 53
            PURCHASE_ORDER = 54
            PURCHASEORDERLIST = 55
            GET_PURCHASEORDER = 56
            DIMENSIONITEM = 57
            EXTERNAL_PAYMENT = 58
            PAYSLIPLIST = 59
            GET_PAYSLIP = 60
        End Enum

        Public Enum Environment As Integer
            PRODUCTION = 1
            DEMO = 2
            ISV = 3
        End Enum

        Private m_customerSettings As CustomerSettings
        Private m_partnerSettings As PartnerSettings
        Private m_targetEnvironment As Environment
        Private m_localDevServerPort As Integer
        Private m_overrideDevelHost As String
        Private m_baseUrl As String

        Public Sub New()
        End Sub

        Public Sub SetSettings(ByVal customer As CustomerSettings, ByVal partner As PartnerSettings)
            m_customerSettings = customer
            m_partnerSettings = partner
        End Sub

        Public Sub New(ByVal customer As CustomerSettings, ByVal partner As PartnerSettings)
            m_customerSettings = customer
            m_partnerSettings = partner
        End Sub

        Public Sub New(ByVal customer As CustomerSettings, ByVal partner As PartnerSettings, ByVal baseUrl As String)
            m_customerSettings = customer
            m_partnerSettings = partner
            m_baseUrl = baseUrl
        End Sub

        Public WriteOnly Property localDevServerPort() As Integer
            Set(ByVal Value As Integer)
                m_localDevServerPort = Value
            End Set
        End Property

        Public Property TargetEnvironment() As Environment
            Get
                Return m_targetEnvironment
            End Get
            Set(ByVal value As Environment)
                m_targetEnvironment = value
            End Set
        End Property

        Public WriteOnly Property overrideDevelHost As String
            Set(value As String)
                m_overrideDevelHost = value
            End Set
        End Property

        Private Function getAuthenticationHeaders(ByVal url As String, ByVal targetOrganisation As FinnishOrganisationIdentifier, Optional ByVal overrideTransactionID As Boolean = False, Optional ByVal transactionID As String = "") As NameValueCollection

            Dim headers As New NameValueCollection()
            Dim timestamp As String = Date.Now.ToString
            Dim uniqueTransactionIdentifier As String = New UniqueIdentifierGenerator().identifier
            Dim h As Hash
            Dim mac As String
            Dim MACHashCalculationAlgorithm As String = "SHA256"

            headers.Add("X-Netvisor-Authentication-Sender", m_partnerSettings.ClientName)
            headers.Add("X-Netvisor-Authentication-PartnerId", m_partnerSettings.PartnerIdentifier)
            headers.Add("X-Netvisor-Authentication-MACHashCalculationAlgorithm", MACHashCalculationAlgorithm)
            headers.Add("X-Netvisor-Authentication-Timestamp", timestamp)
            headers.Add("X-Netvisor-Interface-Language", m_customerSettings.CustomerLanguage)

            If overrideTransactionID AndAlso Len(transactionID) > 0 Then
                headers.Add("X-Netvisor-Authentication-TransactionId", transactionID)
                uniqueTransactionIdentifier = transactionID
            Else
                headers.Add("X-Netvisor-Authentication-TransactionId", uniqueTransactionIdentifier)
            End If

            headers.Add("X-Netvisor-Authentication-CustomerId", m_customerSettings.CustomerIdentifier)

            Dim organisationID As String = vbNullString
            If Not IsNothing(targetOrganisation) Then
                organisationID = targetOrganisation.getHumanReadableFormat()
            End If

            headers.Add("X-Netvisor-Organisation-ID", organisationID)

            h = New Hash(url & "&" &
                m_partnerSettings.ClientName & "&" &
                m_customerSettings.CustomerIdentifier & "&" &
                timestamp & "&" &
                m_customerSettings.CustomerLanguage & "&" &
                organisationID & "&" &
                uniqueTransactionIdentifier & "&" &
                m_customerSettings.CustomerPrivateKey & "&" &
                m_partnerSettings.PartnerPrivateKey)

            mac = h.getHashAs32CharHexString()

            headers.Add("X-Netvisor-Authentication-MAC", mac)

            Return headers
        End Function

        Public Function SendRequest(ByVal fullActionUrl As String, _
                                     Optional ByVal postData As String = vbNullString, _
                                     Optional ByVal targetOrganisation As FinnishOrganisationIdentifier = Nothing) As Object

            Return sendRequest_real(fullActionUrl, postData, targetOrganisation)
        End Function

        Public Function SendRequest(ByVal action As NetvisorWebServiceIntegrationActions, _
                                     Optional ByVal postData As String = vbNullString, _
                                     Optional ByVal targetOrganisation As FinnishOrganisationIdentifier = Nothing, _
                                     Optional ByVal queryStringParameters As NameValueCollection = Nothing, _
                                     Optional ByVal overrideTransactionID As Boolean = False, _
                                     Optional ByVal transactionID As String = "") As Object

            Dim fullActionUrl As String = getActionUrl(action, queryStringParameters)
            Return sendRequest_real(fullActionUrl, postData, targetOrganisation, queryStringParameters, overrideTransactionID, transactionID)
        End Function

        ' For those com-interop callers
        Public Function SendSimpleRequest(ByVal fullActionUrl As String, ByVal postData As String, ByVal targetOrganisation As FinnishOrganisationIdentifier) As NetvisorApplicationResponse
            Dim response As NetvisorApplicationResponse = CType(sendRequest_real(fullActionUrl, postData, targetOrganisation), NetvisorApplicationResponse)
            Return response
        End Function

        Private Function sendRequest_real(ByVal fullActionUrl As String, _
                                        Optional ByVal postData As String = vbNullString, _
                                        Optional ByVal targetOrganisation As FinnishOrganisationIdentifier = Nothing, _
                                        Optional ByVal queryStringParameters As NameValueCollection = Nothing, _
                                        Optional ByVal overrideTransactionID As Boolean = False, _
                                        Optional ByVal transactionID As String = "") As Object

            Dim request As HttpWebRequest = CType(WebRequest.Create(fullActionUrl), HttpWebRequest)

            If Len(postData) > 0 Then
                request.Method = "POST"
            Else
                request.Method = "GET"
            End If

            request.ContentType = "text/xml"

            Dim headers As NameValueCollection = getAuthenticationHeaders(fullActionUrl, targetOrganisation, overrideTransactionID, transactionID)
            For Each header As String In headers.Keys
                request.Headers.Add(header, headers.Item(header))
            Next

            Try
                If Len(postData) > 0 Then
                    Dim sWriter As StreamWriter = New StreamWriter(request.GetRequestStream())
                    sWriter.Write(postData)
                    sWriter.Close()
                Else
                    request.ContentLength = 0
                End If

                Dim response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Dim responseStream As Stream = response.GetResponseStream()
                Dim reader As New StreamReader(responseStream)
                Dim fulldata As String = reader.ReadToEnd()

                reader.Close()
                response.Close()

                Return NetvisorApplicationResponseFactory.getNetvisorApplicationResponse(fullActionUrl, fulldata)
            Catch ex As WebException
                Throw New ApplicationException("Could not process url: " & fullActionUrl & ", error: " & ex.ToString() & ", stack: " & ex.StackTrace())
            End Try

        End Function

        Public Function getBaseUrl() As String

            If (Not String.IsNullOrEmpty(m_baseUrl)) Then
                Return m_baseUrl
            Else
                Select Case m_targetEnvironment
                    Case Environment.PRODUCTION
                        Return BASE_URL_PRODUCTION

                    Case Environment.DEMO
                        Return BASE_URL_DEMO

                    Case Environment.ISV
                        Return BASE_URL_ISV

                    Case Else
                        Throw New ApplicationException("Target environment not defined, use .targetEnvironment = Environment.PRODUCTION")
                End Select
            End If

        End Function

        Private Function getActionUrl(ByVal action As NetvisorWebServiceIntegrationActions, ByVal queryStringParameters As NameValueCollection) As String

            Dim baseUrl As String = Me.getBaseUrl()
            Dim actionUrl As String = vbNullString

            Select Case action
                Case NetvisorWebServiceIntegrationActions.CUSTOMER
                    actionUrl = ACTION_CUSTOMER
                Case NetvisorWebServiceIntegrationActions.SALESINVOICE
                    actionUrl = ACTION_SALESINVOICE
                Case NetvisorWebServiceIntegrationActions.SALESINVOICE_LIST
                    actionUrl = ACTION_SALESINVOICE_LIST
                Case NetvisorWebServiceIntegrationActions.PURCHASEINVOICE_LIST
                    actionUrl = ACTION_PURCHASEINVOICE_LIST
                Case NetvisorWebServiceIntegrationActions.ESCAN
                    actionUrl = ACTION_ESCAN
                Case NetvisorWebServiceIntegrationActions.ACCOUNTING
                    actionUrl = ACTION_ACCOUNTING
                Case NetvisorWebServiceIntegrationActions.CUSTOMER_LIST
                    actionUrl = ACTION_CUSTOMER_LIST
                Case NetvisorWebServiceIntegrationActions.SALESPAYMENT
                    actionUrl = ACTION_SALESPAYMENT
                Case NetvisorWebServiceIntegrationActions.PURCHASEINVOICE
                    actionUrl = ACTION_PURCHASEINVOICE
                Case NetvisorWebServiceIntegrationActions.ACCOUNTING_LEDGER
                    actionUrl = ACTION_ACCOUNTING_LEDGER
                Case NetvisorWebServiceIntegrationActions.PRODUCT
                    actionUrl = ACTION_PRODUCT
                Case NetvisorWebServiceIntegrationActions.PRODUCT_LIST
                    actionUrl = ACTION_PRODUCT_LIST
                Case NetvisorWebServiceIntegrationActions.GETPRODUCT
                    actionUrl = ACTION_GETPRODUCT
                Case NetvisorWebServiceIntegrationActions.PAYROLL_PAYCHECK_BATCH
                    actionUrl = ACTION_PAYROLL_PAYCHECK_BATCH
                Case NetvisorWebServiceIntegrationActions.SALESPAYMENT_LIST
                    actionUrl = ACTION_SALESPAYMENT_LIST
                Case NetvisorWebServiceIntegrationActions.GETSALESINVOICE
                    actionUrl = ACTION_GETSALESINVOICE
                Case NetvisorWebServiceIntegrationActions.GETCUSTOMER
                    actionUrl = ACTION_GETCUSTOMER
                Case NetvisorWebServiceIntegrationActions.WORKDAY
                    actionUrl = ACTION_WORKDAY
                Case NetvisorWebServiceIntegrationActions.ACCOUNTING_BUDGET
                    actionUrl = ACTION_ACCOUNTING_BUDGET
                Case NetvisorWebServiceIntegrationActions.DELETE_SALESINVOICE
                    actionUrl = ACTION_DELETE_SALESINVOICE
                Case NetvisorWebServiceIntegrationActions.OUTGOINGPAYMENT
                    actionUrl = ACTION_OUTGOINGPAYMENT
                Case NetvisorWebServiceIntegrationActions.CRM_PROCESS
                    actionUrl = ACTION_CRM_PROCESS
                Case NetvisorWebServiceIntegrationActions.DIMENSION_LIST
                    actionUrl = ACTION_DIMENSION_LIST
                Case NetvisorWebServiceIntegrationActions.EMPLOYEE
                    actionUrl = ACTION_EMPLOYEE
                Case NetvisorWebServiceIntegrationActions.ACCOUNTING_BUDGET_ACCOUNT_LIST
                    actionUrl = ACTION_ACCOUNTING_BUDGET_ACCOUNT_LIST
                Case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET
                    actionUrl = ACTION_ACCOUNTING_BUDGET_ACCOUNT_BUDGET
                Case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET
                    actionUrl = ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET
                Case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET
                    actionUrl = ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET
                Case NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET
                    actionUrl = ACTION_ACCOUNTING_BUDGET_DIMENSION_YEAR_BUDGET
                Case NetvisorWebServiceIntegrationActions.WEBSHOP_PRODUCT_LIST
                    actionUrl = ACTION_WEBSHOP_PRODUCT_LIST
                Case NetvisorWebServiceIntegrationActions.WEBSHOP_PRODUCT_IMAGES
                    actionUrl = ACTION_WEBSHOP_PRODUCT_IMAGES
                Case NetvisorWebServiceIntegrationActions.TRIPEXPENSE
                    actionUrl = ACTION_TRIPEXPENSE
                Case NetvisorWebServiceIntegrationActions.ACCOUNTLIST
                    actionUrl = ACTION_ACCOUNTLIST
                Case NetvisorWebServiceIntegrationActions.ACCOUNTINGPERIODLIST
                    actionUrl = ACTION_ACCOUNTING_PERIODLIST
                Case NetvisorWebServiceIntegrationActions.PAYROLL_ADVANCE
                    actionUrl = ACTION_PAYROLL_ADVANCE
                Case NetvisorWebServiceIntegrationActions.PAYMENT_LIST
                    actionUrl = ACTION_PAYMENT_LIST
                Case NetvisorWebServiceIntegrationActions.PAYROLL_PERIOD_COLLECTOR
                    actionUrl = ACTION_PAYROLL_PERIOD_COLLECTOR
                Case NetvisorWebServiceIntegrationActions.SALESPERSONNELLIST
                    actionUrl = ACTION_SALESPERSONNELLIST
                Case NetvisorWebServiceIntegrationActions.PURCHASE_ORDER
                    actionUrl = ACTION_PURHASEORDER
                Case NetvisorWebServiceIntegrationActions.PURCHASEORDERLIST
                    actionUrl = ACTION_PURCHASEORDER_LIST
                Case NetvisorWebServiceIntegrationActions.GET_PURCHASEORDER
                    actionUrl = ACTION_GET_PURCHASEORDER
                Case NetvisorWebServiceIntegrationActions.DIMENSIONITEM
                    actionUrl = ACTION_DIMENSIONITEM
                Case NetvisorWebServiceIntegrationActions.EXTERNAL_PAYMENT
                    actionUrl = ACTION_EXTERNAL_PAYMENT
                Case NetvisorWebServiceIntegrationActions.PAYSLIPLIST
                    actionUrl = ACTION_PAYSLIPLIST
                Case NetvisorWebServiceIntegrationActions.GET_PAYSLIP
                    actionUrl = ACTION_GETPAYSLIP
                Case Else
                    Throw New ApplicationException("Invalid Netvisor webservice integration action: " & action)

            End Select

            Dim parameters As String = vbNullString

            If Not queryStringParameters Is Nothing Then
                For Each key As String In queryStringParameters.Keys
                    If parameters Is Nothing Then
                        parameters = "?"
                    Else
                        parameters &= "&"
                    End If

                    parameters &= key & "=" & queryStringParameters.Item(key)
                Next
            End If

            Return String.Concat(baseUrl, actionUrl, parameters)
        End Function
    End Class
End Namespace
