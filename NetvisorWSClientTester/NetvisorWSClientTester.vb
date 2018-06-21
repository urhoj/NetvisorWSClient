'
'
'
' Revisio $Revision$
'
' Testiohjelma. Esimerkit ws-clientin ominaisuuksien käytöstä
'

Imports NetvisorWSClient.communication.sales
Imports NetvisorWSClient.communication.purchase
Imports NetvisorWSClient.communication.collector
Imports NetvisorWSClient.communication
Imports NetvisorWSClient.communication.escan
Imports NetvisorWSClient.communication.accounting
Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication.common
Imports NetvisorWSClient.communication.payroll
Imports NetvisorWSClient.communication.controller
Imports NetvisorWSClient.communication.crm
Imports NetvisorWSClient.communication.webshop

Imports System.Globalization
Imports System.Xml
Imports System.IO
Imports System.Collections.Specialized
Imports System.Text

Module NetvisorWSClientTester

    Private m_partnerSettings As PartnerSettings
    Private m_customerSettings As CustomerSettings
    Private m_netvisorClient As WSClient
    Private m_targetOrganisationIdentifier As FinnishOrganisationIdentifier

    Sub Main()

        m_partnerSettings = New PartnerSettings("Netvisor ExampleClient", "XXXX", "XXXX")
        m_customerSettings = New CustomerSettings("XXXX", "XXXX", CustomerSettings.InterfaceLanguage_Finnish)

        m_targetOrganisationIdentifier = New FinnishOrganisationIdentifier("XXXX")

        m_netvisorClient = New WSClient(m_customerSettings, m_partnerSettings)
        m_netvisorClient.TargetEnvironment = WSClient.Environment.DEMO


        'paymentListExample()
        'AccoutningBudgetYearBudgetExample()
        'accountingPeriodListExample()
        'accountListExample()
        'tripExpenseAddExample()
        'webShopProductImageListExample()
        'webShopProductListExample()
        'webShopCustomerListExample()
        'salesInvoiceDeleteExample()
        'accountingBudgetExample()
        'workDayHoursAddExample()
        'customerLoadExample()
        'customerRawDataLoadExample()
        'salesInvoiceRawDataLoadExample()
        'salesPaymentListExample()
        'paycheckBatchAddExample()
        'productlistExample()
        'productAddExample()
        'netvisorCompanyLoadExample()
        'accountingLedgerListExample()
        'purchaseInvoiceAddExample()
        'salesPaymentAddExample()
        'voucherAddExample()
        'customerAddExample()
        customerListExample()
        'salesInvoiceAddExample() aktiivinen 
        'eScanDocumentSendExample()
        'purchaseInvoiceListExample()
        'salesInvoiceListExample()
        'outgoingPaymentExample()
        'addCRMProcessExample()
        'dimensionListExample()
        'dimensionHandleExample()
        'addEmployeeWithFullParameterSetExample()
        'addEmployeeWithMinmumParameterSetExample()
        'editEmployeeExample()
        'dimensioBudgetExample()
        'tripExpenseAdvanceAddExample()
        'getPurchaseOrderlist()
        'getPurchaseOrder()
        'importPurchaseOrderExample()
        'externalPaymentExample()
        'paysliplistExample()
        'getPayslipExample()


        Console.ReadKey()

    End Sub

    Private Sub paymentListExample()

        Dim paymentListResponse As NetvisorApplicationPaymentListResponse
        paymentListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PAYMENT_LIST,
                                    "", m_targetOrganisationIdentifier, Nothing), NetvisorApplicationPaymentListResponse)

        If paymentListResponse.IsresponseOK Then
            Dim payments As List(Of NetvisorPaymentListPayment) = paymentListResponse.getPaymentList()

            For Each payment As NetvisorPaymentListPayment In payments
                Console.WriteLine(payment.PayerName)
                Console.WriteLine(payment.ForeignCurrencySum)
                Console.WriteLine(payment.invoiceURI)

                Console.WriteLine("-")
            Next

        Else
            Console.WriteLine(paymentListResponse.ErrorMessage)

        End If

    End Sub

    Private Sub accountingPeriodListExample()

        Dim periodListReponse As NetvisorApplicationAccountingPeriodListResponse
        periodListReponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACCOUNTINGPERIODLIST,
                                    "", m_targetOrganisationIdentifier, Nothing), NetvisorApplicationAccountingPeriodListResponse)

        If periodListReponse.IsresponseOK Then
            Dim list As NetvisorAccountingPeriodList = periodListReponse.getNetvisorAccountingPeriods()

            Console.WriteLine("Kausilukitus: " & list.AccountingPeriodLockDate)
            Console.WriteLine("Alv-lukitus: " & list.VatPeriodLockDate)

            Console.WriteLine("--")

            For Each period As NetvisorPeriod In list.periods
                Console.WriteLine(period.Name & " - " & period.beginDate & " - " & period.endDate)
            Next

        Else
            Console.WriteLine(periodListReponse.ErrorMessage)

        End If

    End Sub

    Private Sub accountListExample()

        Dim accountListReponse As NetvisorApplicationAccountListReponse
        accountListReponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACCOUNTLIST,
                                    "", m_targetOrganisationIdentifier, Nothing), NetvisorApplicationAccountListReponse)

        If accountListReponse.IsresponseOK Then
            Dim list As NetvisorAccountList = accountListReponse.getNetvisorAccountList()

            For Each defaultAccount As String In list.companyDefaultAccounts.Keys
                Console.WriteLine(defaultAccount & " -> " & list.companyDefaultAccounts(defaultAccount))
            Next

            Console.WriteLine("--")

            For Each account As NetvisorAccount In list.accountList
                Console.WriteLine(account.Number & " - " & account.Name)
            Next

        Else
            Console.WriteLine(accountListReponse.ErrorMessage)
        End If

    End Sub

    Private Sub AccoutningBudgetYearBudgetExample()

        Dim parameters As New NameValueCollection()
        parameters.Add("year", "2012")

        Dim budgetReponse As NetvisorApplicationAccountingBudgetAccountBudgetResponse
        budgetReponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_YEAR_BUDGET,
                                    "", m_targetOrganisationIdentifier, parameters), NetvisorApplicationAccountingBudgetAccountBudgetResponse)

        If budgetReponse.IsresponseOK Then

            Dim budget As NetvisorAccountingBudgetAccountBudget = budgetReponse.getAccountBudget()

            For Each account As NetvisorAccountingBudgetAccount In budget.BudgetAccountList

                Console.WriteLine(account.AccountName)

                For Each m As NetvisorAccountingBudgetMonth In account.MonthList
                    Console.WriteLine(m.Month & " - " & m.Sum)
                Next

            Next

        Else
            Console.WriteLine(budgetReponse.ErrorMessage)

        End If

    End Sub

    Private Sub tripExpenseAdvanceAddExample()
        Dim advance As New NetvisorPayrollAdvance

        With advance
            .AdvanceSum = 10
            .Description = "Matkaennakkoa kymppi"
            .EmployeeIdentifier = "8"
            .PaymentDate = Date.Now
            .AdvancePaymentStatusType = NetvisorPayrollAdvance.advancePaymentTypes.ispaid
            .AdvanceType = NetvisorPayrollAdvance.advanceTypes.tripExpence
        End With

        Dim request As New NetvisorApplicationPayrollAdvanceRequest()
        Dim response As NetvisorApplicationResponse

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PAYROLL_ADVANCE,
                          request.getPayrollAdvanceAsXML(advance), m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Matkaennnakon vienti onnistui")
        Else
            Console.WriteLine("Matkaennnakon vienti epäonnistui: " & response.ErrorMessage)
        End If

    End Sub

    Private Sub tripExpenseAddExample()

        Dim tripExpense As New NetvisorCollectorTripExpense()

        With tripExpense
            .header = "Testimatkalasku"
            .Description = "Rajapinnan kautta tuotu testimatkalasku"
        End With

        Dim customLine As New NetvisorCollectorTripExpenseCustomLine

        With customLine
            .employeeIdentifier = "123"
            .employeeIdentifierType = NetvisorCollectorTripExpenseCustomLine.employeeIdentifierTypes.number
            .ratio = "Taksikulut"
            .amount = 2
            .customLineUnitPrice = 14.5
            .vatPercentage = 23
            .lineDescription = "Taksimatka Skinnarilaan"
            .ExpenseAccountNumber = 3000

            .addDimension(New NetvisorDimension("Kaupunki", "Lappeenranta"))
        End With

        Dim travelLine As New NetvisorCollectorTripExpenseTravelLine

        With travelLine
            .employeeIdentifier = "123"
            .employeeIdentifierType = NetvisorCollectorTripExpenseTravelLine.employeeIdentifierTypes.number
            .travelType = NetvisorCollectorTripExpenseTravelLine.travelTypes.CAR_WITH_CARAVAN
            .passangerAmount = 3
            .kilometerAmount = 557.5
            .unitPrice = 15
            .lineDescription = "Testimatka"
            .travelDate = Date.Now.ToShortDateString()
            .routeDescription = "Lpr-hki-lpr"

            Dim attachment As New NetvisorAttachment()

            With attachment
                .description = "Testiliite"
                .fileName = "testiliite.pdf"
                .mimeType = "application/pdf"
                .printByDefaultOnSalesInvoice = False

                .attachmentData = Convert.FromBase64String("/9j/4AAQSkZJRgABAQEAYABgAAD//gAcU29mdHdhcmU6IE1pY3Jvc29mdCBPZmZpY2X/2wBDAAoH" &
                                                          "BwgHBgoICAgLCgoLDhgQDg0NDh0VFhEYIx8lJCIfIiEmKzcvJik0KSEiMEExNDk7Pj4+JS5ESUM8")
            End With

            travelLine.addAttachment(attachment)
        End With

        Dim compensationLine As New NetvisorCollectorTripExpenseDailyCompensationLine

        With compensationLine
            .employeeIdentifier = "123"
            .employeeIdentifierType = NetvisorCollectorTripExpenseCustomLine.employeeIdentifierTypes.number
            .compensationType = NetvisorCollectorTripExpenseDailyCompensationLine.compensationTypes.domesticFull
            .amount = 1
            .unitPrice = 50.5
            .lineDescription = "Testimatka"
            .timeOfDeparture = Date.Now.AddDays(-1)
            .returnTime = Date.Now
        End With

        tripExpense.addCustomLine(customLine)
        tripExpense.addTravelLine(travelLine)
        tripExpense.addDailyCompensationLine(compensationLine)

        Dim request As New NetvisorApplicationCollectorTripExpenseRequest()
        Dim response As NetvisorApplicationResponse

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.TRIPEXPENSE,
                          request.getTripExpenseAsXML(tripExpense), m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Matkalaskun vienti onnistui")
        Else
            Console.WriteLine("Matkalaskun vienti epäonnistui: " & response.ErrorMessage)
        End If

    End Sub

    Private Sub webShopProductImageListExample()

        Dim parameters As New NameValueCollection
        parameters.Add(NetvisorApplicationWebShopProductImageResponse.PARAMETER_IDENTIFIER, "105")

        Dim webShopProductImageListResponse As NetvisorApplicationWebShopProductImageResponse
        webShopProductImageListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.WEBSHOP_PRODUCT_IMAGES,
                                    "", m_targetOrganisationIdentifier, parameters), NetvisorApplicationWebShopProductImageResponse)

        If webShopProductImageListResponse.IsresponseOK Then
            Dim list As ArrayList = webShopProductImageListResponse.getNetvisorWebShopProductImageList()

            For Each image As NetvisorWebShopProductImage In list
                Console.WriteLine(image.Title)
                Console.WriteLine(image.DocumentData.Length)
            Next
        Else
            Console.WriteLine(webShopProductImageListResponse.ErrorMessage)
        End If

        m_netvisorClient.SendRequest("http://koulutus.netvisor.fi/webshopproductimages.nv?identifier=24", "", m_targetOrganisationIdentifier)

    End Sub

    Private Sub webShopProductListExample()

        Dim webShopProductListResponse As NetvisorApplicationWebShopProductResponse
        webShopProductListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.WEBSHOP_PRODUCT_LIST,
                                    "", m_targetOrganisationIdentifier), NetvisorApplicationWebShopProductResponse)

        If webShopProductListResponse.IsresponseOK Then
            Dim list As ArrayList = webShopProductListResponse.getNetvisorWebShopProductList()

            For Each product As NetvisorWebShopProduct In list
                Console.WriteLine(product.Names.Item("FI"))
                Console.WriteLine(product.Descriptions.Item("FI"))

                For Each productVariant As NetvisorWebShopProductVariant In product.ProductVariants
                    Console.WriteLine(productVariant.Names("FI"))
                    Console.WriteLine(productVariant.price)
                Next

            Next
        Else
            Console.WriteLine(webShopProductListResponse.ErrorMessage)
        End If
    End Sub

    Private Sub salesInvoiceDeleteExample()

        Dim parameters As New NameValueCollection
        parameters.Add("invoiceid", "24")

        Dim response As NetvisorApplicationResponse
        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.DELETE_SALESINVOICE,
                                           Nothing, m_targetOrganisationIdentifier, parameters), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Lasku poistettu onnistuneesti")
        Else
            Console.WriteLine("Ei voi poistaa laskua: " & response.ErrorMessage)
        End If
    End Sub

    Private Sub accountingBudgetExample()

        Dim accountingBudget As New NetvisorAccountingBudget()

        With accountingBudget
            .ratioType = NetvisorAccountingBudget.ratioTypes.accountNumber
            .ratio = 5000
            .month = 1
            .year = 2009
            .sum = 5000
            .vatClass = 22
            .budgetVersion = "Versio 1"
        End With

        Dim budgetCombination As New NetvisorAccountingBudgetCombination()

        With budgetCombination
            .combinationSum = 5000
            .addDimension(New NetvisorDimension("Projekti", "Netvisor"))
            .addDimension(New NetvisorDimension("Kaupunki", "Valtakatu", 251))
        End With

        accountingBudget.addCombination(budgetCombination)

        Dim budgetRequest As New NetvisorApplicationAccountingBudgetRequest()
        Dim budgetResponse As NetvisorApplicationResponse

        budgetResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACCOUNTING_BUDGET,
                                           budgetRequest.getAccountingBudgetAsXML(accountingBudget), m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If budgetResponse.IsresponseOK Then
            Console.WriteLine("Budjetin vienti Netvisoriin onnistui")
        Else
            Console.WriteLine(budgetResponse.ErrorMessage)
        End If
    End Sub


    Private Sub workDayHoursAddExample()

        Dim employeeWorkDay As New NetvisorWorkDay()

        With employeeWorkDay
            .employeeIdentifierType = NetvisorWorkDay.employeeIdentifierTypes.personalidentificationnumber
            .employeeIdentifier = ""
            .employeeDefaultDimensionHandlingType = NetvisorWorkDay.employeeDefaultDimensionHandlingTypes.usedefault
            .date = Now.Date.AddDays(2)
            .dateMethod = NetvisorWorkDay.dateMethods.replace
        End With

        Dim dayHours As New NetvisorWorkDayHour()

        With dayHours
            .AcceptanceStatus = NetvisorWorkDayHour.acceptanceStatuses.confirmed
            .CollectorRatioNumber = 4545
            .Description = "Netvisor WSClientin tekoa"
            .Hours = 1
            .addDimension(New NetvisorDimension("Kaupunki", "Lappeenranta"))
            .addDimension(New NetvisorDimension("Projekti", "Netvisor"))
        End With

        employeeWorkDay.addHours(dayHours)

        Dim workDayRequest As New NetvisorApplicationWorkDayRequest()
        Dim workDayResponse As NetvisorApplicationResponse

        workDayResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.WORKDAY,
                                           workDayRequest.getWorkDayAsXML(employeeWorkDay), m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If workDayResponse.IsresponseOK Then
            Console.WriteLine("Tuntikirjauksen vienti onnistui")
        Else
            Console.WriteLine(workDayResponse.ErrorMessage)
        End If
    End Sub

    Private Sub customerLoadExample()

        Dim parameters As New NameValueCollection
        parameters.Add(NetvisorApplicationCustomerResponse.PARAMETER_ID, "12")

        Dim customerResponse As NetvisorApplicationCustomerResponse
        customerResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.GETCUSTOMER,
                                    "", m_targetOrganisationIdentifier, parameters), NetvisorApplicationCustomerResponse)

        If customerResponse.IsresponseOK Then
            Dim customer As sales.NetvisorCustomer = customerResponse.getCustomer()

            Console.WriteLine(customer.Name)
            Console.WriteLine(customer.StreetAddress)
            Console.WriteLine(customer.PostNumber)
            Console.WriteLine(customer.City)
        Else
            Console.WriteLine(customerResponse.ErrorMessage)
        End If
    End Sub

    Private Sub salesInvoiceRawDataLoadExample()

        Dim parameters As New NameValueCollection
        parameters.Add("netvisorkey", 7155)

        Dim invoiceResponse As NetvisorApplicationSalesInvoiceResponse
        invoiceResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.GETSALESINVOICE,
                                    "", m_targetOrganisationIdentifier, parameters), NetvisorApplicationSalesInvoiceResponse)

        If invoiceResponse.IsresponseOK Then
            Console.WriteLine(invoiceResponse.responseData)
        Else
            Console.WriteLine(invoiceResponse.ErrorMessage)
        End If
    End Sub

    Private Sub salesPaymentListExample()

        Dim requestParameters As New NameValueCollection()
        requestParameters.Add(NetvisorSalesPaymentListPayment.OptionalLimitSalesPayments.ParameterName, NetvisorSalesPaymentListPayment.OptionalLimitSalesPayments.ExcludeCreditLoss)

        Dim paymentListResponse As NetvisorApplicationSalesPaymentListResponse
        paymentListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.SALESPAYMENT_LIST,
                                    "", m_targetOrganisationIdentifier, requestParameters), NetvisorApplicationSalesPaymentListResponse)

        If paymentListResponse.IsresponseOK Then
            Dim payments As ArrayList = paymentListResponse.getPaymentList()

            For Each payment As NetvisorSalesPaymentListPayment In payments
                Console.WriteLine(payment.name)
                Console.WriteLine(payment.bankStatus)
            Next
        Else
            Console.WriteLine(paymentListResponse.ErrorMessage)
        End If
    End Sub

    Private Sub paycheckBatchAddExample()

        Dim paycheckBatch As New NetvisorPayrollPaycheckBatch()
        With paycheckBatch
            .employeeIdentifier = "123"
            .employeeIdentifierType = NetvisorPayrollPaycheckBatch.employeeIdentifierTypes.employeeNumber
            .freeTextBeforeLines = "Vapaateksti"
            .freeTextAfterLines = "Vapaateksti"
            .ruleGroupPeriodStart = New Date(2009, 4, 1)
            .ruleGroupPeriodEnd = New Date(2009, 4, 30)
            .dueDate = New Date(2009, 4, 30)
            .valueDate = New Date(2009, 4, 30)
        End With

        Dim paycheckBatchLine As New NetvisorPayrollPaycheckBatchLine()
        With paycheckBatchLine
            .description = "kuvaus"
            .lineSum = 3000
            .unitAmount = 3000
            .units = 1
            .payrollRatioIdentifierType = NetvisorPayrollPaycheckBatchLine.payrollRatioIdentifierTypes.rationumber
            .payrollRatioIdentifier = 1
            .addNewDimension(New NetvisorDimension("Kaupunki", "Joensuu"))
            .addNewDimension(New NetvisorDimension("Projekti", "Netvisor"))
        End With

        paycheckBatch.addBatchLine(paycheckBatchLine)

        Dim request As New NetvisorApplicationPayrollPaycheckBatchRequest()
        Dim response As NetvisorApplicationResponse
        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PAYROLL_PAYCHECK_BATCH,
                          request.getPaycheckBatchAsXML(paycheckBatch), m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Palkkalaskelman vienti onnistui")
        Else
            Console.WriteLine("Palkkalaskelman vienti epäonnistui: " & response.ErrorMessage)
        End If
    End Sub

    Private Sub productlistExample()

        Dim productlistResponse As NetvisorApplicationProductListResponse
        productlistResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PRODUCT_LIST,
                                    "", m_targetOrganisationIdentifier), NetvisorApplicationProductListResponse)

        If productlistResponse.IsresponseOK Then
            Dim products As ArrayList = productlistResponse.getProductList()

            If products.Count > 0 Then
                For Each product As NetvisorProductListProduct In products
                    Console.WriteLine(product.name)
                Next

                ' haetaan listassa viimeisen tuotteen tuotetiedot vielä erikseen laajempina
                Dim lastProductUri As String = CType(products.Item(products.Count - 1), NetvisorProductListProduct).uri()
                Dim productResponse As NetvisorApplicationProductResponse
                productResponse = CType(m_netvisorClient.SendRequest(lastProductUri, , m_targetOrganisationIdentifier), NetvisorApplicationProductResponse)

                If productResponse.IsresponseOK Then
                    Dim fullProduct As NetvisorProduct = productResponse.getProduct()
                    Console.WriteLine(fullProduct.netvisorKey & " " & fullProduct.name)
                Else
                    Console.WriteLine("Ei voi hakea tuotteen tietoja: " & productResponse.ErrorMessage)
                End If
            End If
        Else
            Console.WriteLine("Ei voi hakea tuotelistaa: " & productlistResponse.ErrorMessage)
        End If
    End Sub

    Private Sub productAddExample()

        Dim product As New NetvisorProduct()

        With product
            .comissionPercentage = 5
            .defaultVatPercentage = 22
            .description = "Rajapinnan kautta tuotu esimerkkituote"
            .isActive = 1
            .isSalesproduct = 1
            .name = "Esimerkkituote"
            .productCode = "ESIM1"
            .productGroup = "Rajapinnan kautta tuodut" ' perustetaan jos ei löydy
            .purchaseprice = 5
            .tariffHeading = "Tulli"
            .unit = "kg" ' perustetaan jos ei löydy
            .unitPrice = 10
            .unitPriceType = NetvisorProduct.unitPriceTypes.net
            .unitWeight = 5
        End With

        Dim response As NetvisorApplicationResponse
        Dim request As New NetvisorApplicationProductRequest
        Dim parameters As New NameValueCollection()
        parameters.Add("method", "add")

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PRODUCT,
             request.getProductAsXML(product), m_targetOrganisationIdentifier, parameters),
              NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Tuote lisätty")
        Else
            Console.WriteLine(response.ErrorMessage)
        End If
    End Sub

    Private Sub accountingLedgerListExample()

        Dim accountingLedgerResponse As NetvisorApplicationAccountingLedgerResponse
        Dim parameters As New NameValueCollection

        parameters.Add("startdate", Format(Now.Date.AddDays(-720), "yyyy-MM-dd"))
        parameters.Add("enddate", Format(Now.Date, "yyyy-MM-dd"))
        parameters.Add("accountnumberstart", "3000")
        parameters.Add("accountnumberend", "3100")

        accountingLedgerResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACCOUNTING_LEDGER,
, m_targetOrganisationIdentifier, parameters), NetvisorApplicationAccountingLedgerResponse)

        If accountingLedgerResponse.IsresponseOK Then
            For Each voucher As NetvisorAccountingLedgerVoucher In accountingLedgerResponse.getAccountingLedgers()
                Console.WriteLine("Tosite: " & voucher.voucherNumber)
                Console.WriteLine("Netvisor-URI: " & voucher.voucherNetvisorURI)
                Console.WriteLine("Tila:" & voucher.Status)

                If voucher.LinkedSourceNetvisorKey.HasValue Then
                    Console.WriteLine("Lähde: " & voucher.LinkedSourceType)
                    Console.WriteLine("Lähteen linkitystieto Netvisorissa: " & voucher.LinkedSourceNetvisorKey)
                End If

                For Each voucherline As NetvisorVoucherLine In voucher.voucherLines
                    Console.WriteLine("Tositerivi: " & voucherline.accountNumber & " " & voucherline.lineSum)

                    For Each dimension As NetvisorDimension In voucherline.voucherLineDimensions
                        Console.WriteLine("Tositerivin laskentakohde: " & dimension.dimensionName & " " & dimension.dimensionDetail)
                    Next
                Next

                Console.WriteLine("")
            Next
        Else
            Console.WriteLine(accountingLedgerResponse.ErrorMessage)
        End If
    End Sub

    Private Sub purchaseInvoiceAddExample()

        Dim invoice As New NetvisorPurchaseInvoice
        With invoice
            .invoiceSource = NetvisorPurchaseInvoice.invoiceSources.MANUAL
            .AccountNumber = "xxxxx-xxxx"
            .Amount = 10
            .DueDate = Now.Date.AddDays(7)
            .InvoiceDate = Now.Date
            .findNextOpenDateIfInLockedPeriod = True
            .ValueDate = Now.Date
            .InvoiceNumber = "Testi_1"
            .VendorAddressline = "Testikuja 2"
            .VendorCity = "Lappeenranta"
            .VendorName = "Testitoimitaja"
            .VendorPostNumber = "53900"
            .invoiceSource = NetvisorPurchaseInvoice.invoiceSources.MANUAL
            .InvoiceRound = NetvisorPurchaseInvoice.NetvisorPurchaseInvoiceRounds.UNHANDLED
        End With

        Dim line As New NetvisorPurchaseInvoiceLine
        With line
            .Description = "Kuvaus"
            .ProductCode = "Testi"
            .ProductName = "Testituote"
            .OrderedAmount = 1
            .DeliveredAmount = 1
            .UnitName = "kpl"
            .UnitPrice = 100
            .DiscountPercentage = 10
            .LineSum = 90
            .VatPercent = 0
        End With
        invoice.addInvoiceLine(line)

        Dim attachment As New NetvisorAttachment()
        With attachment
            .description = "Testiliite"
            .fileName = "testiliite.pdf"
            .mimeType = "application/pdf"

            .attachmentData = Convert.FromBase64String("/9j/4AAQSkZJRgABAQEAYABgAAD//gAcU29mdHdhcmU6IE1pY3Jvc29mdCBPZmZpY2X/2wBDAAoH" &
                                                       "BwgHBgoICAgLCgoLDhgQDg0NDh0VFhEYIx8lJCIfIiEmKzcvJik0KSEiMEExNDk7Pj4+JS5ESUM8")
        End With
        invoice.addAttachment(attachment)

        Dim request As New NetvisorApplicationPurchaseInvoiceRequest
        Dim response As NetvisorApplicationResponse

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PURCHASEINVOICE,
                     request.getInvoiceAsXML(invoice),
                     m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Ostolasku viety onnistnuneesti")
        Else
            Console.WriteLine(response.ErrorMessage)
        End If
    End Sub

    Private Sub salesPaymentAddExample()

        Dim salespayment As New NetvisorSalesPayment()

        With salespayment
            .currency = NetvisorSalesPayment.CURRENCY_EURO
            .paymentDate = Date.Now
            .targetIdentifierType = NetvisorSalesPayment.targetIdentifierTypes.invoiceId
            .targetIdentifier = 5667
            .targetType = NetvisorSalesPayment.targetTypes.order
            .sourceName = "Matti Meikäläinen"
            .sum = 216.0
            .paymentMethodType = NetvisorSalesPayment.paymentMethodTypes.alternative
            .paymentMethod = "Pankkikortti"
        End With

        Dim request As New NetvisorApplicationSalesPaymentRequest
        Dim response As NetvisorApplicationResponse

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.SALESPAYMENT,
                     request.getSalesPaymentAsXML(salespayment),
                     m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Myyntisuoritus viety onnistuneesti")
        Else
            Console.WriteLine(response.ErrorMessage)
        End If
    End Sub

    Private Sub customerAddExample()

        Dim customer As New sales.NetvisorCustomer
        Dim parameters As New NameValueCollection
        parameters.Add(NetvisorApplicationCustomerRequest.PARAMETER_METHOD, NetvisorApplicationCustomerRequest.PARAMETER_METHOD_ADD)

        customer.Name = "Anni Asiakas"
        customer.OrganisationIdentifier = "1234567-8"
        customer.customerGroupName = "Alennusasiakkaat"
        customer.invoicePrintChannelFormat = 10
        customer.IsPrivateCustomer = True

        Dim response As NetvisorApplicationResponse
        Dim request As New NetvisorApplicationCustomerRequest

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.CUSTOMER,
             request.getCustomerAsXML(customer),
             m_targetOrganisationIdentifier,
             parameters), NetvisorApplicationResponse)

        If Not response.IsresponseOK Then
            Console.WriteLine(response.ErrorMessage)
        End If
    End Sub

    Private Sub customerListExample()

        Dim customerListResponse As NetvisorApplicationCustomerListResponse
        customerListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.CUSTOMER_LIST,
                                    "", m_targetOrganisationIdentifier), NetvisorApplicationCustomerListResponse)

        If customerListResponse.IsresponseOK Then
            Dim customers As ArrayList = customerListResponse.getCustomerList()

            For Each customer As NetvisorCustomerListCustomer In customers
                Console.WriteLine(customer.name)
            Next
        Else
            Console.WriteLine(customerListResponse.ErrorMessage)
        End If
    End Sub

    Private Sub salesInvoiceAddExample()

        Dim invoice As New NetvisorInvoice

        With invoice
            .CustomerIdentifier = "TEMP"
            .CustomerName = "Matti Mallikas"
            .CustomerNameExtension = "Netvisor Oy"
            .CustomerAddress = "Pajukuja 15"
            .CustomerPostNumber = "53900"
            .CustomerTown = "Lappeenranta"
            .invoiceType = NetvisorInvoice.NetvisorInvoiceTypes.invoice
            .InvoiceStatus = NetvisorInvoice.NetvisorInvoiceStatuses.UnSent

            .CustomerIdentifierType = NetvisorInvoice.CustomerIdentifierSource.NETVISOR_IDENTIFIER
            .CustomerIdentifier = 10

            .DeliveryDate = Now.Date.AddDays(2)
            .InvoiceDate = Now.Date
            .InvoiceSum = 100
            .iso4217currencycode = "EUR"
            .overrideCurrencyRate = 1.5
            .ourReference = "Meidän viite"
            .yourReference = "Teidän viite"
            .privateComment = "Laskun kommentti vain omaa käyttöä varten"
            .PaymentTermNetDays = 14
            .ReferenceNumber = New ReferenceNumber("1070", True)
            .SalesInvoiceFreeTextAfterLines = "vapaata tekstiä ennen rivejä"
            .SalesInvoiceFreeTextBeforeLines = "vapaata tekstiä rivien jälkeen"
            .sellerName = "Matti Mallikas"
            .sellerIdentifier = 6 'Myyjälinkitystieto pitää tietää. Ei ole mahdollista saada tietoon muualta, kuin käyttöliittymästä osoiteriviltä. Ei ole mahdollisuutta hakea rajapinnan kautta.
            .DeliveryMethod = "Asennettuna"
            .DeliveryTerm = "Sopimuksen mukaan"
            .PaymentTermNetDays = 14
            .paymentTermCashDiscountDays = 5
            .paymentTermCashDiscountType = NetvisorInvoice.paymentTermCashDiscountTypes.PERCENTAGE
            .paymentTermCashDiscount = 7.5
            .OverrideVoucherSalesReceivablesAccountNumber = 1702
            .DeliveryMethod = ""
        End With

        Dim commentLine As New NetvisorInvoiceCommentLine
        commentLine.comment = "Testikommentti ennen tuotetta"
        invoice.addInvoiceLine(commentLine)

        Dim productLine As New NetvisorInvoiceProductLine
        With productLine
            .DeliveredQuantity = 1
            .LineDiscountPercentage = 0
            .ProductIdentifierType = NetvisorInvoiceProductLine.productIdentifierTypes.EXTERNAL_IDENTIFIER
            .ProductIdentifier = "TEMP"
            .ProductName = "Testituote"
            .ProductUnitPrice = 100
            .productUnitPriceIsGross = False
            .ProductVatPercentage = 0
            .productVatCode = VatCode.vatCodes.DOMESTIC_SALES
            .AccountingSuggestionAccountNumber = 3000

            .addDimension(New NetvisorDimension("IIHF", "Project"))
            .addDimension(New NetvisorDimension("Uusi otsikko", "Uusi kohde"))
        End With

        invoice.addInvoiceLine(productLine)

        invoice.OverrideDefaultSalesAccrualAccountNumber = 2965
        invoice.addInvoiceAccrualEntry(New NetvisorInvoiceAccrualEntry(1, 2012, 50))
        invoice.addInvoiceAccrualEntry(New NetvisorInvoiceAccrualEntry(2, 2012, 50))

        commentLine = New NetvisorInvoiceCommentLine
        commentLine.comment = "Testikommentti tuotteen jälkeen"
        invoice.addInvoiceLine(commentLine)

        Dim attachment As New NetvisorAttachment()
        With attachment
            .description = "Testiliite"
            .fileName = "testiliite.pdf"
            .mimeType = "application/pdf"
            .printByDefaultOnSalesInvoice = False

            .attachmentData = Convert.FromBase64String("/9j/4AAQSkZJRgABAQEAYABgAAD//gAcU29mdHdhcmU6IE1pY3Jvc29mdCBPZmZpY2X/2wBDAAoH" &
                                                      "BwgHBgoICAgLCgoLDhgQDg0NDh0VFhEYIx8lJCIfIiEmKzcvJik0KSEiMEExNDk7Pj4+JS5ESUM8")
        End With

        invoice.addAttachment(attachment)

        Dim response As NetvisorApplicationResponse
        Dim request As New NetvisorApplicationInvoiceRequest

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.SALESINVOICE,
                                                       request.getInvoiceAsXML(invoice),
                                                       m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Myyntilasku lisätty")
        Else
            Console.WriteLine("Virhe: " & response.ErrorMessage)
        End If
    End Sub

    Private Sub dimensionHandleExample()
        'Laskentakohteen lisäys ja muokkaus voidaan tehdä myös uudella dimensionitem.nv resurssilla

        Dim addUrl As String = "dimensionadd.nv?dimensionname=Projekti&dimensionsubname=Projekti 12346"
        Dim addResponse As NetvisorApplicationResponse = CType(m_netvisorClient.SendRequest(m_netvisorClient.getBaseUrl() & addUrl, "", m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If addResponse.IsresponseOK Then

            Console.WriteLine("insert ok")

            Dim editUrl As String = "dimensionedit.nv?dimensionname=Projekti&olddimensionsubname=Projekti 12346&newdimensionsubname=Projekti 1235"
            Dim editResponse As NetvisorApplicationResponse = CType(m_netvisorClient.SendRequest(m_netvisorClient.getBaseUrl() & editUrl, "", m_targetOrganisationIdentifier), NetvisorApplicationResponse)

            If editResponse.IsresponseOK Then

                Console.WriteLine("edit ok")

                Dim deleteUrl As String = "dimensiondelete.nv?dimensionname=Projekti&dimensionsubname=Projekti 1235"
                Dim deleteResponse As NetvisorApplicationResponse = CType(m_netvisorClient.SendRequest(m_netvisorClient.getBaseUrl() & deleteUrl, "", m_targetOrganisationIdentifier), NetvisorApplicationResponse)

                If deleteResponse.IsresponseOK Then
                    Console.WriteLine("delete ok")
                Else
                    Console.WriteLine(deleteResponse.ErrorMessage)
                End If
            Else
                Console.WriteLine(editResponse.ErrorMessage)
            End If
        Else
            Console.WriteLine(addResponse.ErrorMessage)
        End If

    End Sub

    Private Sub voucherAddExample()

        Dim voucher As New NetvisorVoucher
        With voucher
            .voucherCalculationModeIsGross = False
            .VoucherDate = Now.Date
            .Description = "WSClientin luoma testitosite"
            .VoucherClass = "Myyntireskontra"
        End With

        Dim line As New NetvisorVoucherLine
        With line
            .accountNumber = 3000
            .lineDescription = "WSClientin luoma testitositerivi"
            .lineSum = 100
            .vatCode = VatCode.vatCodes.DOMESTIC_SALES
            .vatPercent = 22

            .addVoucherLineDimension(New NetvisorDimension("projekti", "Kongressitilat"))
            .addVoucherLineDimension(New NetvisorDimension("Kustannuspaikat", "50 Markkinointi"))
        End With

        voucher.addVoucherLine(line)

        line = New NetvisorVoucherLine
        With line
            .accountNumber = 1701
            .lineDescription = "WSClientin luoma testitositerivi"
            .lineSum = -122
            .vatCode = VatCode.vatCodes.NO_VAT_HANDLING
            .vatPercent = 0

            .addVoucherLineDimension(New NetvisorDimension("Kaupunki", "Lappeenranta"))
        End With

        voucher.addVoucherLine(line)

        line = New NetvisorVoucherLine
        With line
            .accountNumber = 2939
            .lineDescription = "WSClientin luoma testitositerivi"
            .lineSum = 22
            .vatCode = VatCode.vatCodes.NO_VAT_HANDLING
            .vatPercent = 0

            .addVoucherLineDimension(New NetvisorDimension("Kaupunki", "Käpylä", 591))
        End With

        voucher.addVoucherLine(line)

        Dim response As NetvisorApplicationResponse
        Dim request As New NetvisorApplicationVoucherRequest

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACCOUNTING,
                                                                request.getVoucherAsXML(voucher),
                                                                m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Tosite lisätty")
        Else
            Console.WriteLine("Virhe: " & response.ErrorMessage)
        End If
    End Sub

    Private Sub eScanDocumentSendExample()

        Dim doc As New EScanDocument

        With doc
            .documentData = Convert.FromBase64String("/9j/4AAQSkZJRgABAQEAYABgAAD//gAcU29mdHdhcmU6IE1pY3Jvc29mdCBPZmZpY2X/2wBDAAoH" &
                                                    "BwgHBgoICAgLCgoLDhgQDg0NDh0VFhEYIx8lJCIfIiEmKzcvJik0KSEiMEExNDk7Pj4+JS5ESUM8" &
                                                    "SDc9Pjv/2wBDAQoLCw4NDhwQEBw7KCIoOzs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7Ozs7" &
                                                    "Ozs7Ozs7Ozs7Ozs7Ozs7Ozv/wAARCAGtAoIDASIAAhEBAxEB/8QAHAAAAQUBAQEAAAAAAAAAAAAA" &
                                                    "AQACAwQFBgcI/8QASBAAAQMCBAQDBQYCCQMDAwUAAQACAwQRBRIhMQYTQVEiYXEUMoGRoQdCUrHB" &
                                                    "0SNiFSQzQ1NyguHwFjSSY6LCJUTxNXODstL/xAAaAQEBAQEBAQEAAAAAAAAAAAAAAQIDBAUG/8QA" &
                                                    "KREBAQACAgIDAAEDBQEBAAAAAAECEQMhEjEEQVEFE2FxFCIykaGBsf/dAAQAKP/aAAwDAQACEQMR" &
                                                    "AD8A5YN63SIUwYiI9F5bUQ5b7otjU4jTxH5KbVCIyntjU3LTsluizsRBmqeI1IGpwCzsMDLJ4aEb")

            .Compression = EScanDocument.CompressionSettings.NO_COMPRESSION
            .Description = "testidokumentti"
            .DocumentMimeType = EScanDocument.SupportedDocumentMimeTypes.APPLICATION_PDF
            .DocumentType = 1
            .fileSize = doc.documentData.Length
            .Version = 1
            .addTarget(EScanDocument.EScanDocumentTargets.SALES_INVOICE, 6985)
        End With

        Dim request As New NetvisorApplicationEscanRequest
        Dim response As NetvisorApplicationResponse
        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ESCAN,
                                                        request.getEScanDocumentAsXML(doc),
                                                        m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("OK")
        Else
            Console.WriteLine(response.ErrorMessage)
        End If
    End Sub

    Private Sub purchaseInvoiceListExample()

        Dim parameters As New NameValueCollection
        parameters.Add("invoicestatus", "approved")

        Dim invoiceResponse As NetvisorApplicationPurchaseInvoiceListResponse
        invoiceResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PURCHASEINVOICE_LIST,
                                    "", m_targetOrganisationIdentifier,
                                    parameters), NetvisorApplicationPurchaseInvoiceListResponse)

        If invoiceResponse.IsresponseOK Then
            Dim invoices As ArrayList = invoiceResponse.getPurchaseInvoiceList()

            For Each line As NetvisorPurchaseInvoiceListInvoice In invoices
                Console.WriteLine(line.vendor)
            Next
        Else
            Console.WriteLine(invoiceResponse.ErrorMessage)
        End If
    End Sub

    Private Sub salesInvoiceListExample()

        Dim invoiceListResponse As NetvisorApplicationSalesInvoiceListResponse
        invoiceListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.SALESINVOICE_LIST,
                                    "", m_targetOrganisationIdentifier), NetvisorApplicationSalesInvoiceListResponse)

        If invoiceListResponse.IsresponseOK Then
            Dim invoices As ArrayList = invoiceListResponse.getSalesInvoiceList()

            For Each invoice As NetvisorSalesInvoiceListInvoice In invoices
                Console.WriteLine(invoice.customerName & ", " & invoice.invoiceNumber & ", " & invoice.invoiceSum)
            Next
        Else
            Console.WriteLine(invoiceListResponse.ErrorMessage)
        End If
    End Sub

    Private Sub outgoingPaymentExample()

        Dim outgoingPayment As New NetvisorOutgoingPayment()

        With outgoingPayment
            .BankPaymentMessageType = NetvisorOutgoingPayment.BankPaymentMessageTypes.FINNISH_REFERENCE
            .BankPaymentMessage = "1231234"
            .RecipientOrganizationCode = New FinnishOrganisationIdentifier("xxx-yyy")
            .RecipientName = "Teppo Teikäläinen"
            .SourceBankAccountNumber = New FinnishBankAccountNumber("xxx-yyy")
            .DestinationBankName = ""
            .DestinationBankBranch = ""
            .DestinationBankAccountNumber = New FinnishBankAccountNumber("xxx-yyy")
            .DueDate = DateAdd(DateInterval.Day, 10, Now).Date
            .Amount = 95.99
        End With

        Dim request As New NetvisorApplicationOutgoingPaymentRequest
        Dim response As NetvisorApplicationResponse

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.OUTGOINGPAYMENT,
                     request.getOutgoingPaymentAsXML(outgoingPayment),
                     m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Tilisiirto viety onnistuneesti")
        Else
            Console.WriteLine(response.ErrorMessage)
        End If
    End Sub

    Private Sub addCRMProcessExample()

        Dim process As New NetvisorProcess()

        With process
            .CustomerIdentifier = "1"
            .Duedate = DateAdd(DateInterval.Day, 7, Now)
            .Name = "Rajapinnan kautta luotu tehtävä"
            .ProcessIdentifier = "TEST #1"

            Dim template As New NetvisorProcessTemplate

            template.Name = "Netvisor tukiprosessi"
            .ProcessTemplate = template
        End With

        Dim request As New NetvisorApplicationProcessRequest()
        Dim response As NetvisorApplicationResponse

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.CRM_PROCESS,
                          request.getCRMProcessAsXML(process), m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Tehtävän vienti onnistui")
        Else
            Console.WriteLine("Tehtävän vienti epäonnistui: " & response.ErrorMessage)
        End If
    End Sub

    Private Sub dimensionListExample()

        Dim dimensionListResponse As NetvisorApplicationDimensionListResponse
        dimensionListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.DIMENSION_LIST,
                                    "", m_targetOrganisationIdentifier), NetvisorApplicationDimensionListResponse)

        If dimensionListResponse.IsresponseOK Then
            Dim dimensionNames As ArrayList = dimensionListResponse.getDimensionNameList()

            For Each dimensionName As NetvisorDimensionName In dimensionNames
                Console.WriteLine(dimensionName.Name)
                For Each dimensionDetail As NetvisorDimensionNameDimensionDetail In dimensionName.DimensionDetails
                    Console.WriteLine("    " & dimensionDetail.Name)
                Next
            Next
        Else
            Console.WriteLine(dimensionListResponse.ErrorMessage)
        End If
    End Sub

    Private Sub budgetAccountListExample()
        Dim accountListResponse As NetvisorApplicationAccountingBudgetAccountListResponse

        accountListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACCOUNTING_BUDGET_ACCOUNT_LIST,
                                   "", m_targetOrganisationIdentifier), NetvisorApplicationAccountingBudgetAccountListResponse)

        If accountListResponse.IsresponseOK Then
            Dim accounts As ArrayList = accountListResponse.getAccountList()

            For Each account As NetvisorAccountingBudgetAccountListAccount In accounts
                Console.WriteLine(account.NetvisorKey)
                Console.WriteLine(account.Name)
                Console.WriteLine(account.Number)
                Console.WriteLine(account.Group)
                Console.WriteLine(account.Type)

                Console.WriteLine(String.Empty)
            Next
        Else
            Console.WriteLine(accountListResponse.ErrorMessage)
        End If
    End Sub

    Private Sub dimensioBudgetExample()

        Dim parameters As New NameValueCollection
        parameters.Add("accountid", 639)
        parameters.Add("year", 2011)
        parameters.Add("dimensionheaderid", 1)
        parameters.Add("lockeddimensionitemid", "70,17")

        Dim dimensionBudgetResponse As NetvisorApplicationAccountingBudgetDimensionBudgetResponse
        dimensionBudgetResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACTION_ACCOUNTING_BUDGET_DIMENSION_BUDGET,
                                    "", m_targetOrganisationIdentifier, parameters), NetvisorApplicationAccountingBudgetDimensionBudgetResponse)

        If dimensionBudgetResponse.IsresponseOK Then
            Dim budget As NetvisorAccountingBudgetDimensionBudget = dimensionBudgetResponse.getDimensionBudget()

            For Each dimension As NetvisorAccountingBudgetDimension In budget.BudgetDimensionList
                Console.WriteLine(dimension.DimensionItemName)

                For Each month As NetvisorAccountingBudgetMonth In dimension.MonthList
                    Console.Write(" | " & month.Sum)
                Next
                Console.WriteLine("")
            Next
        Else
            Console.WriteLine(dimensionBudgetResponse.ErrorMessage)
        End If
    End Sub

    Private Sub addEmployeeWithMinmumParameterSetExample()
        'Default value for country, nationality and language is Finland
        'Default value for accounting account number is 1751
        'Default value for employee number is empty value

        Dim employee As New payroll.NetvisorEmployee
        Dim parameters As New NameValueCollection
        parameters.Add(NetvisorApplicationEmployeeRequest.PARAMETER_METHOD, NetvisorApplicationEmployeeRequest.PARAMETER_METHOD_ADD)

        With employee
            .Employeeidentifier = "151280-078H"
            .FirstName = "Anna"
            .LastName = "Asiakas"
            .Email = "anna.asiakas@yritys.fi"
            .PhoneNumber = "0500 123456"
            .StreetAddress = "Keisarinkatu 1"
            .PostNumber = "56120"
            .City = "Lappeenranta"
            .Municipality = "Lappeenranta"
            .Profession = "Myyjä"
            .Payrollrulegroupname = "Kuukausipalkkalaiset"
            .JobBeginDate = New DateTime(2011, 3, 9)
            .Bankaccountnumber = "FI21 1234 5600 0007 85"
            .BankIdentificationCode = "NDEAFIHH"
        End With

        Dim response As NetvisorApplicationResponse
        Dim request As New NetvisorApplicationEmployeeRequest

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.EMPLOYEE,
             request.getEmployeeAsXML(employee),
             m_targetOrganisationIdentifier,
             parameters), NetvisorApplicationResponse)

        If Not response.IsresponseOK Then
            Console.WriteLine(response.ErrorMessage)
        Else
            Console.WriteLine("No error occurred.")
        End If
    End Sub

    Private Sub addEmployeeWithFullParameterSetExample()

        Dim employee As New payroll.NetvisorEmployee
        Dim parameters As New NameValueCollection
        parameters.Add(NetvisorApplicationEmployeeRequest.PARAMETER_METHOD, NetvisorApplicationEmployeeRequest.PARAMETER_METHOD_ADD)

        With employee
            .Employeeidentifier = "151280-078H"
            .FirstName = "Anna"
            .LastName = "Asiakas"
            .Email = "anna.asiakas@yritys.fi"
            .PhoneNumber = "0500 123456"
            .StreetAddress = "Keisarinkatu 1"
            .PostNumber = "56120"
            .City = "Lappeenranta"
            .Municipality = "Lappeenranta"
            .Country = "fi"
            .Nationality = "fi"
            .Language = "fi"
            .Profession = "Myyjä"
            .EmployeeNumber = 14
            .Payrollrulegroupname = "Kuukausipalkkalaiset"
            .JobBeginDate = New DateTime(2011, 3, 9)
            .Bankaccountnumber = "FI21 1234 5600 0007 85"
            .BankIdentificationCode = "NDEAFIHH"
            .Accountingaccountnumber = 1751
        End With

        Dim response As NetvisorApplicationResponse
        Dim request As New NetvisorApplicationEmployeeRequest

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.EMPLOYEE,
             request.getEmployeeAsXML(employee),
             m_targetOrganisationIdentifier,
             parameters), NetvisorApplicationResponse)

        If Not response.IsresponseOK Then
            Console.WriteLine(response.ErrorMessage)
        Else
            Console.WriteLine("No error occurred.")
        End If
    End Sub
    Private Sub editEmployeeExample()

        Dim employee As New payroll.NetvisorEmployee
        Dim parameters As New NameValueCollection
        parameters.Add(NetvisorApplicationEmployeeRequest.PARAMETER_METHOD, NetvisorApplicationEmployeeRequest.PARAMETER_METHOD_EDIT)

        With employee
            .Employeeidentifier = "151280-078H"
            .FirstName = "Anna"
            .LastName = "Asiakas"
            .Email = "anna.asiakas@yritys.fi"
            .PhoneNumber = "0500 123456"
            .StreetAddress = "Keisarinkatu 1"
            .PostNumber = "56120"
            .City = "Lappeenranta"
            .Municipality = "Lappeenranta"
            .Country = "fi"
            .Nationality = "fi"
            .Language = "se"
            .Profession = "Myyjä"
            .EmployeeNumber = 13
            .Payrollrulegroupname = "Kuukausipalkkalaiset"
            .JobBeginDate = New DateTime(2011, 3, 9)
            .Bankaccountnumber = "FI21 1234 5600 0007 85"
            .Accountingaccountnumber = 1751
        End With

        Dim response As NetvisorApplicationResponse
        Dim request As New NetvisorApplicationEmployeeRequest

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.EMPLOYEE,
             request.getEmployeeAsXML(employee),
             m_targetOrganisationIdentifier,
             parameters), NetvisorApplicationResponse)

        If Not response.IsresponseOK Then
            Console.WriteLine(response.ErrorMessage)
        Else
            Console.WriteLine("No error occurred.")
        End If
    End Sub

    Private Sub getPurchaseOrderlist()
        Dim purchaseOrderListResponse As NetvisorApplicationPurchaseOrderListResponse

        purchaseOrderListResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PURCHASEORDERLIST,
                                   "", m_targetOrganisationIdentifier), NetvisorApplicationPurchaseOrderListResponse)

        If purchaseOrderListResponse.IsresponseOK Then
            Dim orders As ArrayList = purchaseOrderListResponse.getPurchaseOrderList()

            For Each order As NetvisorPurchaseOrderListOrder In orders
                Console.WriteLine(order.netvisorKey)
                Console.WriteLine(order.orderNumber)
                Console.WriteLine(order.orderDate)
                Console.WriteLine(order.orderStatus)
                Console.WriteLine(order.vendorName)
                Console.WriteLine(order.amount)
                Console.WriteLine(order.uri)

                Console.WriteLine(String.Empty)
            Next
        Else
            Console.WriteLine(purchaseOrderListResponse.ErrorMessage)
        End If
    End Sub

    Private Sub getPurchaseOrder()

        Dim parameters As New NameValueCollection
        parameters.Add("netvisorkey", "366")

        Dim purchaseOrderResponse As NetvisorApplicationPurchaseOrderResponse

        purchaseOrderResponse = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.GET_PURCHASEORDER, "", m_targetOrganisationIdentifier, parameters, False, ""), NetvisorApplicationPurchaseOrderResponse)

        If purchaseOrderResponse.IsresponseOK Then
            Dim order As NetvisorPurchaseOrder
            order = purchaseOrderResponse.getPurchaseOrder()

            Console.WriteLine("Order")
            Console.WriteLine("Netvisor-key: " & order.netvisorKey.ToString())
            Console.WriteLine("Number: " & order.orderNumber)
            Console.WriteLine("Date: " & order.orderDate.ToShortDateString())
            Console.WriteLine("Status: " & order.orderStatus)
            Console.WriteLine("Comment: " & order.comment)
            Console.WriteLine("Private comment: " & order.privateComment)
            Console.WriteLine("Our reference: " & order.ourReference)
            Console.WriteLine("Sum: " & order.amount)
            Console.WriteLine("Payment term: " & order.paymentTermDescription)
            Console.WriteLine(String.Empty)

            Console.WriteLine("Vendor")
            Console.WriteLine("Name: " & order.vendorName)
            Console.WriteLine("Address: " & order.vendorAddressline)
            Console.WriteLine("Post number: " & order.vendorPostnumber)
            Console.WriteLine("City: " & order.vendorCity)
            Console.WriteLine("Country: " & order.vendorCountry)
            Console.WriteLine(String.Empty)

            Console.WriteLine("Delivery")
            Console.WriteLine("Term: " & order.deliveryTerm)
            Console.WriteLine("Method: " & order.deliveryMethod)
            Console.WriteLine("Name: " & order.deliveryName)
            Console.WriteLine("Address: " & order.deliveryAddressLine)
            Console.WriteLine("Post number: " & order.deliveryPostNumber)
            Console.WriteLine("City: " & order.deliveryCity)
            Console.WriteLine("Country: " & order.deliveryCountry)
            Console.WriteLine(String.Empty)

            For Each productLine As NetvisorPurchaseOrderLine In order.ProductLines
                Console.WriteLine("Productline")
                Console.WriteLine("Product: " & productLine.productName & ", " & productLine.productCode & ", " & productLine.vendorProductCode)
                Console.WriteLine("Price: " & productLine.orderedAmount & " * " & productLine.unitPrice & " = " & productLine.lineSum & ", VAT " & productLine.vatPercent & "%")
                Console.WriteLine("Ordered: " & productLine.orderedAmount & " from warehouse " & productLine.inventoryPlace)
                Console.WriteLine("Delivered: " & productLine.deliveredAmount & " at " & productLine.DeliveryDate)

                For Each dimension As NetvisorDimension In productLine.dimensions
                    Console.WriteLine("Dimension: " & dimension.dimensionName & "." & dimension.dimensionDetail)
                Next
                Console.WriteLine(String.Empty)
            Next

            For Each commentLine As NetvisorPurchaseOrderCommentLine In order.CommentLines
                Console.WriteLine("CommentLine")
                Console.WriteLine(commentLine.comment)
                Console.WriteLine(String.Empty)
            Next
        Else
            Console.WriteLine(purchaseOrderResponse.ErrorMessage)
        End If
    End Sub

    Private Sub importPurchaseOrderExample()
        Dim order As New NetvisorPurchaseOrder()

        Dim parameters As New NameValueCollection
        parameters.Add("method", "add")

        With order
            .orderNumber = "091220141"
            .orderStatus = "proposal"
            .orderDate = Now().Date
            .vendorIdentifier = "1706058-7"
            .vendorIdentifier_type = "organisationidentifier"
            .vendorName = "DnB NOR Testitoimittaja"
            .vendorAddressline = "Koulukatu 54"
            .vendorPostnumber = "53945"
            .vendorCity = "Lappeenranta"
            .vendorCountry = "FI"
            .deliveryTerm = "Sopimuksen mukaan"
            .deliveryMethod = "posti"
            .deliveryAddressLine = "Kauppakatu 23"
            .deliveryPostNumber = "53984"
            .deliveryCity = "Lappeenranta"
            .deliveryCountry = "FI"
            .privateComment = "Sisäinen kommentti"
            .comment = "Julkinen kommentti"
            .ourReference = "091220141436"
            .paymentTermNetDays = 6
            .paymentTermCashDiscountDays = 5
            .paymentTermDiscountPercent = 4
        End With

        Dim productLine As New NetvisorPurchaseOrderLine()

        With productLine
            .productCode = "6608"
            .productCode_type = "netvisor"
            .productName = "Asiantuntijapalvelut"
            .vendorProductCode = "Projektinjohto"
            .orderedAmount = 37.5
            .unitPrice = 55
            .vatPercent = 24
            .DeliveryDate = Date.Parse("12.12.2014")
        End With
        order.addProductline(productLine)

        Dim commentLine As New NetvisorPurchaseOrderCommentLine()
        commentLine.comment = "Kommenttirivin teksti"

        order.addCommentLine(commentLine)

        Dim request As New NetvisorApplicationPurchaseOrderRequest()
        Dim response As NetvisorApplicationResponse

        response = m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PURCHASE_ORDER, request.getOrderAsXML(order), m_targetOrganisationIdentifier, parameters, False, "")

        If response.IsresponseOK Then
            Console.WriteLine("Ostotilauksen vienti onnistui, tilauksen id: " & response.insertedDataIdentifier)
        Else
            Console.WriteLine("Ostotilauksen vienti epäonnistui, virheviesti: " & response.ErrorMessage)
        End If
    End Sub

    Private Sub externalPaymentExample()
        Dim externalPayment As New NetvisorPayrollExternalPayment

        With externalPayment
            .ExternalPaymentSum = "-1000000"
            .Description = "Ulkoinen maksu testi"
            .PaymentDate = Date.Now
            .IBAN = "FI6556121120212078"
            .BIC = "OKOYFIHH"
            '.HETU = "123545-0000"
            .HETU = "180648-2884"
            .Realname = "Lassi Pesari"
        End With

        Dim request As New NetvisorApplicationPayrollExternalPaymentRequest()
        Dim response As NetvisorApplicationResponse

        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.EXTERNAL_PAYMENT, _
                          request.getPayrollExternalPaymentAsXML(externalPayment), m_targetOrganisationIdentifier), NetvisorApplicationResponse)

        If response.IsresponseOK Then
            Console.WriteLine("Ulkoisen maksun vienti onnistui")
        Else
            Console.WriteLine("Ulkoisen maksun vienti epäonnistui: " & response.ErrorMessage)
        End If

    End Sub


    Private Sub paysliplistExample()

        Dim response As NetvisorApplicationPaysliplistResponse
        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PAYSLIPLIST,
                                                                 "", m_targetOrganisationIdentifier, Nothing), NetvisorApplicationPaysliplistResponse)

        If response.IsresponseOK Then

            Try
                Dim payslips As PaysliplistXml = response.getPayslipList

                For Each payslip As PayslipXml In payslips.Payslips
                    Console.WriteLine("Payslip:")
                    Console.WriteLine("NetvisorKey: " & payslip.Netvisorkey)
                    Console.WriteLine("CompanyName: " & payslip.CompanyName)
                    Console.WriteLine("EmployeeID: " & payslip.EmployeeId)
                    Console.WriteLine("EmployeeNumber: " & payslip.EmployeeNumber)
                    Console.WriteLine("EmployeeName: " & payslip.EmployeeName)
                    Console.WriteLine("Payperiod: " & payslip.PayperiodStart & " - " & payslip.PayperiodEnd)
                    Console.WriteLine("Duedate: " & payslip.DueDate)
                    Console.WriteLine("PaidAmount: " & payslip.PaidAmount)
                    Console.WriteLine("URI: " & payslip.Uri)
                    Console.WriteLine(String.Empty)
                Next

            Catch ex As FormatException

                Console.WriteLine("Error. Deserialization of the XML content failed.")
            End Try

        Else

            Console.WriteLine(response.ErrorMessage)
        End If

    End Sub

    Private Sub getPayslipExample()

        Dim parameters As New NameValueCollection()
        parameters.Add(NetvisorApplicationGetPayslipResponse.FORMAT_PARAMETER, NetvisorApplicationGetPayslipResponse.FORMAT_PAYSLIP_XML)
        parameters.Add(NetvisorApplicationGetPayslipResponse.PAYSLIPID_PARAMETER, 1800)

        Dim response As NetvisorApplicationGetPayslipResponse
        response = CType(m_netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.GET_PAYSLIP,
                                                      "", m_targetOrganisationIdentifier, parameters), NetvisorApplicationGetPayslipResponse)

        If response.IsresponseOK Then

            Try
                Dim payslip As PayslipContentRoot = response.getPayslip

                Console.WriteLine("Encoded payslipcontent: " & payslip.PayslipData)

                Dim decodedBytes As Byte() = Convert.FromBase64String(payslip.PayslipData)
                Dim decodedContent As String = Encoding.UTF8.GetString(decodedBytes)
                Console.WriteLine("Decoded payslipcontent: " & decodedContent)

            Catch ex As FormatException

                Console.WriteLine("Error. Deserialization of the XML content failed.")
            End Try

        Else

            Console.WriteLine(response.ErrorMessage)
        End If

    End Sub

End Module


