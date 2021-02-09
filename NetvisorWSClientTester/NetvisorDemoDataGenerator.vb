'
'
'
' Revisio $Revision$
'
' Työkalu/esimerkki testiaineiston generointiin Netviosriin
' rajapinnan kautta. 
'
' 1. Muutama tuote, Asiakkaita ja toimittajia (10 kutakin)
'    - Tilinumeron toimittajille (alkaen jollain pääpankkien alkunumerolla jolle sitten vain tarkiste loppuun)
' 2. Myyntilaskuja + niiden kirjaustositteet (10 kpl per kk * 12 kk) (porautumisessa laskulinkki löytyy) 
' 3. Ostolaskuja + niiden kirjaustositteet (10 kpl per kk * 12 kk) + joku pdf liitteenä
' 4. Kirjanpidon tapahtumia  useille kulutileille ( kirjaus = kulutili debet AN 1910 Pankkitili Kredit
'    - 7000 – 7999 välisiä tilejä. Eli 7000 debet alv 8-24 ja 1910 kredit.


Imports NetvisorWSClient.communication.sales
Imports NetvisorWSClient.communication.purchase
Imports NetvisorWSClient.util
Imports NetvisorWSClient.communication
Imports System.Collections.Specialized
Imports NetvisorWSClient.communication.common
Imports NetvisorWSClient.communication.accounting

Module NetvisorDemoDataGenerator

    Sub Main()

        Dim partnerSettings As New PartnerSettings("Netvisor DemoDataGenerator", My.Settings.partnerIdentifier, My.Settings.partnerPrivateKey)
        Dim customerSettings As New CustomerSettings(My.Settings.customerIdentifier, My.Settings.customerPrivateKey, CustomerSettings.InterfaceLanguage_Finnish)
        Dim targetOrganisationIdentifier As New FinnishOrganisationIdentifier(My.Settings.organizationID)
        Dim netvisorClient As WSClient
        Dim response As NetvisorApplicationResponse

        netvisorClient = New WSClient(customerSettings, partnerSettings)

        Select Case My.Settings.environment.ToLowerInvariant
            Case "demo"
                netvisorClient.TargetEnvironment = WSClient.Environment.DEMO
            Case "production"
                netvisorClient.TargetEnvironment = WSClient.Environment.PRODUCTION
            Case "devel", "development"
                netvisorClient = New WSClient(customerSettings, partnerSettings)
            Case "isv"
                netvisorClient.TargetEnvironment = WSClient.Environment.ISV
            Case Else
                Throw New ArgumentNullException("Environment not spesified on appsettings.")
        End Select

        Dim addresses() As String = {"Kalastajatorpantie 1", "Katajanokanlaituri 7", "Sorsavuorenkatu 14 B 92", "Koskelantie 42", "Liisantie 11", "Kasarmikatu 15", "Kasarmikatu 12", "Bubbiksentie 6", "Mankkaantie 39", "Topeliuksenkatu 99", "Ainonkatu 4 ", "Ahertajantie 6", "Henry Fordin katu 5 C", "Malminkaari 24", "Ainonkatu 5", "Ainonkatu 6"}
        Dim postcodes() As String = {"02781", "02180", "00260", "00700", "00100", "02100", "00150", "81700", "53100", "53850", "81810"}
        Dim cities() As String = {"Espoo", "Helsinki", "Lappeenranta", "Pori", "Hollola", "Lieksa", "Joensuu", "Kuopio"}
        Dim vatclasses() As String = {"8", "12", "17", "22"}
        Dim random As New Random

        Dim requestparams As New NameValueCollection
        requestparams.Add("method", "add")

        ' Lisätään(asiakkaat)
        Console.WriteLine("")
        Console.WriteLine("ASIAKKAAT:")

        Dim customers As New ArrayList
        Dim customer As NetvisorCustomer

        For customerNumber As Integer = 1 To 10
            customer = New NetvisorCustomer()

            With customer
                .customerGroupName = "Asiakasryhmä 1"
                .customerGroupNetvisorKey = 2

                .CustomerIdentifier = (customerNumber + 1000).ToString()
                .Name = "Demoasiakas " & customerNumber
                .StreetAddress = addresses(random.Next(addresses.Length))
                .PostNumber = postcodes(random.Next(postcodes.Length))
                .City = cities(random.Next(cities.Length))
                .CountryISO3166Code = "FI"
            End With

            customers.Add(customer)

            Dim customerRequest As New NetvisorApplicationCustomerRequest
            response = CType(netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.CUSTOMER, customerRequest.getCustomerAsXML(customer), targetOrganisationIdentifier, requestparams), NetvisorApplicationResponse)

            If response.IsresponseOK Then
                Console.WriteLine(customer.CustomerIdentifier & " - OK")
            ElseIf response.responseData.Contains("AUTHENTICATION_FAILED") Then
                Console.WriteLine(customer.CustomerIdentifier & response.ErrorMessage)
                Throw New Exception("Authentication failed with partnersettings: " & partnerSettings.PartnerIdentifier & " - " & partnerSettings.PartnerPrivateKey &
                                    " and customersettings: " & customerSettings.CustomerIdentifier & " - " & customerSettings.CustomerPrivateKey)
            Else
                Console.WriteLine(customer.CustomerIdentifier & " - FAILED " & response.ErrorMessage)
            End If
        Next

        ' Lisätään tuotteet
        Console.WriteLine("")
        Console.WriteLine("TUOTTEET:")

        Dim products As New ArrayList()
        Dim product As NetvisorProduct

        For productNumber As Integer = 1 To 10
            product = New NetvisorProduct

            With product
                .productCode = (productNumber + 1000).ToString()
                .name = "Demotuote " & productNumber
                .productGroup = "Tuoteryhmä 1"
                .unitPrice = FormatNumber(random.Next(1, 1000), 2)
                .unitPriceType = NetvisorProduct.unitPriceTypes.net
                .purchaseprice = .unitPrice * 0.5
                .defaultVatPercentage = 24
                .isActive = 1
                .isSalesproduct = 1
            End With

            products.Add(product)

            Dim productRequest As New NetvisorApplicationProductRequest
            response = CType(netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PRODUCT, productRequest.getProductAsXML(product), targetOrganisationIdentifier, requestparams), NetvisorApplicationResponse)

            If response.IsresponseOK Then
                Console.WriteLine(product.productCode & " - OK")
            Else
                Console.WriteLine(product.productCode & " - FAILED " & response.ErrorMessage)
            End If
        Next

        ' Myyntilaskut
        Console.WriteLine("")
        Console.WriteLine("MYYNTILASKUT:")

        Dim invoice As NetvisorInvoice
        Dim invoiceCustomer As NetvisorCustomer
        Dim invoiceProduct As NetvisorProduct
        Dim invoiceLine As NetvisorInvoiceProductLine

        For invoiceMonth As Integer = 1 To 12
            For invoiceNumber As Integer = 1 To 10
                invoice = New NetvisorInvoice
                invoiceCustomer = customers.Item(random.Next(customers.Count))
                invoiceProduct = products.Item(random.Next(products.Count))

                With invoice
                    .InvoiceStatus = NetvisorInvoice.NetvisorInvoiceStatuses.Open
                    .invoiceType = NetvisorInvoice.NetvisorInvoiceTypes.invoice
                    .InvoiceDate = New Date(Now.Year, invoiceMonth, random.Next(1, 28))
                    .InvoiceSum = invoiceProduct.unitPrice

                    .CustomerIdentifierType = NetvisorInvoice.CustomerIdentifierSource.EXTERNAL_IDENTIFIER
                    .CustomerIdentifier = invoiceCustomer.CustomerIdentifier
                    .CustomerName = invoiceCustomer.Name
                    .CustomerAddress = invoiceCustomer.StreetAddress
                    .CustomerPostNumber = invoiceCustomer.PostNumber
                    .CustomerTown = invoiceCustomer.City

                    .PaymentTermNetDays = 14
                End With

                invoiceLine = New NetvisorInvoiceProductLine

                With invoiceLine
                    .AccountingSuggestionAccountNumber = 3000
                    .DeliveredQuantity = random.Next(1, 5)
                    .ProductIdentifier = invoiceProduct.productCode
                    .ProductName = invoiceProduct.name
                    .ProductUnitPrice = invoiceProduct.unitPrice
                    .productUnitPriceIsGross = False
                    .productVatCode = VatCode.vatCodes.DOMESTIC_SALES
                    .ProductVatPercentage = invoiceProduct.defaultVatPercentage
                End With

                invoice.addInvoiceLine(invoiceLine)
                invoice.InvoiceSum = invoiceLine.DeliveredQuantity * invoiceLine.productUnitPriceIsGross

                Dim invoiceRequest As New NetvisorApplicationInvoiceRequest
                response = CType(netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.SALESINVOICE, invoiceRequest.getInvoiceAsXML(invoice), targetOrganisationIdentifier), NetvisorApplicationResponse)

                If response.IsresponseOK Then
                    Console.WriteLine(invoiceMonth & "/" & Now.Year & " " & invoiceNumber & " - OK")
                Else
                    Console.WriteLine(invoiceMonth & "/" & Now.Year & " " & invoiceNumber & " - FAILED " & response.ErrorMessage)
                End If
            Next
        Next

        ' Ostolaskut
        Console.WriteLine("")
        Console.WriteLine("OSTOLASKUT:")

        Dim purchaseinvoice As NetvisorPurchaseInvoice
        Dim purchaseInvoiceVendor As NetvisorCustomer
        Dim purchaseInvoiceLine As NetvisorPurchaseInvoiceLine
        Dim purchaseInvoiceProduct As NetvisorProduct

        For invoiceMonth As Integer = 1 To 12
            For invoiceNumber As Integer = 1 To 10
                purchaseinvoice = New NetvisorPurchaseInvoice
                purchaseInvoiceVendor = customers.Item(random.Next(customers.Count))
                purchaseInvoiceProduct = products.Item(random.Next(products.Count))

                With purchaseinvoice
                    .VendorAddressline = purchaseInvoiceVendor.StreetAddress
                    .VendorName = "Demotoimittaja " & invoiceNumber
                    .VendorPostNumber = purchaseInvoiceVendor.PostNumber
                    .vendorCountry = "FI"
                    .VendorCity = purchaseInvoiceVendor.City
                    .invoiceSource = NetvisorPurchaseInvoice.invoiceSources.MANUAL
                    .InvoiceDate = New Date(Now.Year, invoiceMonth, random.Next(1, 28))
                    .DueDate = .InvoiceDate.AddDays(14)
                    .ValueDate = .InvoiceDate
                    .deliveryDate = .InvoiceDate
                    .InvoiceNumber = .InvoiceDate.Day & .InvoiceDate.Month & .InvoiceDate.Year & Now.Hour & Now.Minute & Now.Millisecond
                    .overdueFinePercent = 11
                    .AccountNumber = getRandomValidFinnishBankAccountNumber().getMachineReadableLongFormat
                End With

                purchaseInvoiceLine = New NetvisorPurchaseInvoiceLine
                With purchaseInvoiceLine
                    .ProductName = purchaseInvoiceProduct.name
                    .VatPercent = purchaseInvoiceProduct.defaultVatPercentage
                    .ProductCode = purchaseInvoiceProduct.productCode
                    .UnitPrice = purchaseInvoiceProduct.unitPrice * (1 + (.VatPercent / 100))
                    .DeliveredAmount = 1
                    .vatSum = (.DeliveredAmount * .UnitPrice) * (.VatPercent / 100)
                    .LineSum = .UnitPrice
                End With

                purchaseinvoice.Amount = purchaseInvoiceLine.LineSum
                purchaseinvoice.addInvoiceLine(purchaseInvoiceLine)

                Dim invoiceRequest As New NetvisorApplicationPurchaseInvoiceRequest
                response = CType(netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.PURCHASEINVOICE, invoiceRequest.getInvoiceAsXML(purchaseinvoice), targetOrganisationIdentifier), NetvisorApplicationResponse)

                If response.IsresponseOK Then
                    Console.WriteLine(invoiceMonth & "/" & Now.Year & " " & invoiceNumber & " - OK")
                Else
                    Console.WriteLine(invoiceMonth & "/" & Now.Year & " " & invoiceNumber & " - FAILED " & response.ErrorMessage)
                End If
            Next
        Next

        ' Tositteet
        Console.WriteLine("")
        Console.WriteLine("TOSITTEET:")

        Dim voucher As NetvisorVoucher
        Dim line As NetvisorVoucherLine
        Dim lineSum As Decimal
        Dim accountNumber As String

        For voucherMonth As Integer = 1 To 12
            For voucherNumber As Integer = 1 To 20
                voucher = New NetvisorVoucher

                With voucher
                    .voucherCalculationModeIsGross = True
                    .VoucherDate = New Date(Now.Year, voucherMonth, random.Next(1, 28))
                    .VoucherClass = "Muut"
                    .Description = "Tosite " & voucherNumber & " " & voucherMonth & "/" & Now.Year
                End With

                line = New NetvisorVoucherLine
                lineSum = FormatNumber(random.Next(1000), 2)
                accountNumber = random.Next(700, 799).ToString & "0"

                With line
                    .accountNumber = accountNumber
                    .lineSum = lineSum
                    .vatCode = VatCode.vatCodes.DOMESTIC_SALES
                    .vatPercent = vatclasses(random.Next(vatclasses.Length))
                    .lineDescription = "Tosite " & voucherNumber & " " & voucherMonth & "/" & Now.Year
                End With

                voucher.addVoucherLine(line)

                line = New NetvisorVoucherLine
                With line
                    .accountNumber = 1910
                    .lineSum = -lineSum
                    .vatCode = VatCode.vatCodes.NO_VAT_HANDLING
                    .vatPercent = 0
                    .lineDescription = "Tosite " & voucherNumber & " " & voucherMonth & "/" & Now.Year
                End With

                voucher.addVoucherLine(line)

                Dim voucherRequest As New NetvisorApplicationVoucherRequest
                response = CType(netvisorClient.SendRequest(WSClient.NetvisorWebServiceIntegrationActions.ACCOUNTING, voucherRequest.getVoucherAsXML(voucher), targetOrganisationIdentifier), NetvisorApplicationResponse)

                If response.IsresponseOK Then
                    Console.WriteLine(voucherMonth & "/" & Now.Year & " " & voucherNumber & " - OK")
                Else
                    Console.WriteLine(voucherMonth & "/" & Now.Year & " " & voucherNumber & " - FAILED " & response.ErrorMessage)
                End If
            Next
        Next

        Console.WriteLine("Press any key to continue")
        Console.ReadKey()
    End Sub

    Public Function getRandomValidFinnishBankAccountNumber() As FinnishBankAccountNumber

        ' Arvotaan ensin pankki jonka tilinumero muodostetaan ja sitten tilinumeroon "runko" nykyhetkestä
        ' Kun random-tilinumero kasassa, laskentaan sille sitten tarkiste
        ' Lopputuloksena validi suomalainen jonkin pankin tilinumero

        Dim banknumbers() As String = {"1", "2", "31", "5", "8"}
        Dim accountNumberStart As String = banknumbers(New Random().Next(banknumbers.Length))
        Dim accountNumberBody As String = Now.Month & Now.Day & Now.Hour & Now.Millisecond
        Dim accountNumberWithoutCheckSum As String = accountNumberStart & FixedLengthFieldFormatter.FormatInteger(accountNumberBody, 13 - Len(accountNumberStart))

        Dim sum As Long
        Dim product As Long
        Dim weight As Single = 2
        Dim nextTenth As Long
        Dim ownCheckSum As Integer

        For i As Integer = accountNumberWithoutCheckSum.Length To 1 Step -1
            product = weight * CInt(accountNumberWithoutCheckSum.Substring(i - 1, 1))

            If Len(product.ToString) = 2 Then
                sum = sum + CInt(Mid(product.ToString, 1, 1))
                sum = sum + CInt(Mid(product.ToString, 2, 1))
            Else
                sum = sum + product
            End If

            If weight = 2 Then
                weight = 1
            Else
                weight = 2
            End If
        Next

        nextTenth = sum

        Do While nextTenth Mod 10 <> 0
            nextTenth = nextTenth + 1
        Loop

        ownCheckSum = nextTenth - sum

        Return New FinnishBankAccountNumber(accountNumberWithoutCheckSum & ownCheckSum)
    End Function
End Module