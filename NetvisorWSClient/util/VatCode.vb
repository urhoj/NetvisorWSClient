'
'
'
' Revisio $Revision$
'
'VatCode
'1	-	    Ei alv-käsittelyä	
'2	KOOS	Kotimaan osto	
'3	EUOS	EU-osto	
'4	EUUO	EU:n ulkopuolinen osto	
'5	EUPO	EU-palveluosto
'6	100%	100% vähennettävä vero
'7	KOMY	Kotimaan myynti	
'8	EUMY	EU-myynti
'9	EUUM	EU:n ulkopuolinen myynti
'10 EUPM312 EU-palvelumyynti (312)
'11 EUPM309 EU-palvelumyynti (309)
'12 MUUL    Muu arvonlisäveroton liikevaihto
'13 EVTO    Ei vähennyskelpoiset  EU-tavaraostot
'14 EVPO    Ei vähennyskelpoiser EU-palveluostot 

Namespace NetvisorWSClient.util
    Public Class VatCode

        Public Const NO_VAT_HANDLING As String = "NONE"
        Public Const DOMESTIC_PURCHASE As String = "KOOS"
        Public Const EU_PURCHASE As String = "EUOS"
        Public Const NON_EU_PURCHASE As String = "EUUO"
        Public Const EU_SERVICE_PURCHASE As String = "EUPO"
        Public Const HUNDREDPERCENT_DEDUCTED_TAX As String = "100"
        Public Const DOMESTIC_SALES As String = "KOMY"
        Public Const EU_SALES As String = "EUMY"
        Public Const NON_EU_SALES As String = "EUUM"
        Public Const EU_SERVICE_SALES = "EUPM"
        Public Const EU_SERVICE_SALES_312 As String = "EUPM312"
        Public Const EU_SERVICE_SALES_309 As String = "EUPM309"
        Public Const NO_TAX_SALES = "MUUL"
        Public Const NO_DEDUCTIBLE_EU_PURCHASE = "EVTO"
        Public Const NO_DEDUCTIBLE_EU_SERVICEPURHASE = "EVPO"
        
        Public Enum vatCodes As Integer
            NO_VAT_HANDLING = 1
            DOMESTIC_PURCHASE = 2
            EU_PURCHASE = 3
            NON_EU_PURCHASE = 4
            EU_SERVICE_PURCHASE = 5
            HUNDREDPERCENT_DEDUCTED_TAX = 6
            DOMESTIC_SALES = 7
            EU_SALES = 8
            NON_EU_SALES = 9
            EU_SERVICE_SALES_312 = 10
            EU_SERVICE_SALES_309 = 11
            NO_TAX_SALES = 12
            NO_DEDUCTIBLE_EU_PURCHASE = 13
            NO_DEDUCTIBLE_EU_SERVICEPURHASE = 14
        End Enum
    End Class
End Namespace