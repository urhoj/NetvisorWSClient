'
'
'
' Revisio $Revision$
'
' Pankkitilinumeron internationalisointia helpottava rajapinta, jonka
' kaikkien pankkitilien pit‰‰ pysty‰ toteuttamaan
'

Namespace NetvisorWSClient.util
    Public Interface IBankAccountNumber
        Function getHumanReadableLongFormat() As String
        Function getMachineReadableLongFormat() As String
    End Interface
End Namespace
