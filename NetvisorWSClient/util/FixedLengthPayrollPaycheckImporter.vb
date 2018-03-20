'
'
'
' Revisio $Revision$
'
' Parsii eräänlaisen määrämittaisen palkkalaskelma-tiedoston
'

Imports System.Web
Imports System.IO

Namespace NetvisorWSClient.util
    Public Class FixedLengthPayrollPaycheckImporter

        Private Const MINROWLENGTH As Integer = 92
        Private Const MAXROWLENGTH As Integer = 106

        Private Const INDEX As Integer = 0
        Private Const LENGHT As Integer = 1
        'Index,Lenght
        Private m_InstructionsTable(,) As Integer = { _
                                    {0, 3}, _
                                    {4, 2}, _
                                    {6, 7}, _
                                    {27, 2}, _
                                    {30, 4}, _
                                    {35, 8}, _
                                    {44, 8}, _
                                    {55, 10}, _
                                    {66, 8}, _
                                    {75, 8}, _
                                    {84, 8}, _
                                    {93, 4}, _
                                    {98, 8}}

        Private Enum Fields As Integer
            RECORD = 0
            ORG = 1
            PIN = 2
            MONTH = 3
            PAYMENTTYPE = 4
            AMOUNT = 5
            COSTPLACE = 6
            UNITPRICE = 7
            TRANSFERDATE = 8
            FIRSTDATE = 9
            LASTDATE = 10
            SENDID = 11
            ACCOUNT = 12
        End Enum

        Private m_file As String = Nothing
        Private m_importedFileRows As New ArrayList
        Private m_importedFileProcessError As New ArrayList
        Private m_rowsList As New ArrayList
        Private m_isProcessingOk As Boolean
        Private m_rowsUniquePersonalNumbers As New ArrayList


        Public Sub New()

        End Sub

        Public Property File() As String
            Get
                Return m_file
            End Get
            Set(ByVal value As String)
                m_file = value
            End Set
        End Property

        Public Function ProcessFile() As Boolean

            m_isProcessingOk = ReadReceivedFile()
            m_isProcessingOk = ProcessRows()

            Return m_isProcessingOk

        End Function

        Private Sub addFileRow(ByVal row As String)
            m_importedFileRows.Add(row)
        End Sub

        Public Function FileRowCount() As Integer
            Return m_importedFileRows.Count
        End Function

        Private Sub addFileProcessErrorRow(ByVal errorRow As String)
            m_importedFileProcessError.Add(errorRow)
        End Sub

        Public Function getFileProcessErrorRows() As ArrayList
            Return m_importedFileProcessError
        End Function

        Public Function FileProcessErrorRowCount() As Integer
            Return m_importedFileProcessError.Count
        End Function

        Private Function ReadReceivedFile() As Boolean

            Dim isReadOk As Boolean = True
            Dim reader As New StringReader(m_file)

            Try

                Dim Line As String = reader.ReadLine()
                Dim rowCount As Integer = 0

                While Not Line Is Nothing

                    If Line.Length >= MINROWLENGTH Then
                        rowCount += 1
                        addFileRow(Line)
                    End If

                    Line = reader.ReadLine()

                End While

                If rowCount <> Me.m_importedFileRows.Count Then
                    isReadOk = False
                End If

            Catch ex As Exception
                isReadOk = False
                Throw New Exception("READ-error : " & ex.StackTrace.ToString)

            Finally
                reader.Close()
            End Try

            Return isReadOk

        End Function

        Private Sub addRowObjects(ByVal obj As Row)
            Me.m_rowsList.Add(obj)
        End Sub

        ''' <summary>
        ''' Palauttaa listan row olioita
        ''' </summary>    
        ''' <remarks>Palauttaa tyhjän listan, jos luku epäonnistui</remarks>
        Public Function getAllRowObjectsList() As ArrayList

            If Me.m_isProcessingOk Then
                Return m_rowsList
            Else
                Return New ArrayList
            End If

        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns>ArrayList of row objects</returns>
        ''' <remarks></remarks>
        Public Function getUniquePersonalNumbersList() As ArrayList

            For Each obj As Row In m_rowsList

                Dim pinExists As Boolean = isRowPersonalNumberListed(obj.PersonalNumber)
                If pinExists = False Then
                    AddUniquePersonalNumberToList(obj.PersonalNumber)
                End If
            Next

            Return m_rowsUniquePersonalNumbers

        End Function

        ''' <summary>
        ''' Row olio-listasta haku annetulla yksilöllisellä henkilönumerolla
        ''' </summary>
        ''' <param name="personalnumber"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function SearchByPersonalNumber(ByVal personalnumber As Integer) As ArrayList

            Dim tempArrayList As New ArrayList
            For Each obj As Row In m_rowsList
                If obj.PersonalNumber = personalnumber Then
                    tempArrayList.Add(obj)
                End If
            Next

            Return tempArrayList

        End Function

        Private Sub AddUniquePersonalNumberToList(ByVal pin As Integer)
            m_rowsUniquePersonalNumbers.Add(pin)
        End Sub

        ''' <summary>
        ''' Tarkastetaan onko henkilönumero jo listassa
        ''' </summary>
        ''' <param name="personalnumber"></param>    
        Private Function isRowPersonalNumberListed(ByVal personalnumber As Integer) As Boolean

            Dim isFound As Boolean = False
            For Each existingPin As Integer In Me.m_rowsUniquePersonalNumbers
                If existingPin = personalnumber Then
                    Return True
                End If
            Next

            Return isFound

        End Function

        ''' <summary>
        ''' Käsittelee tiedosto rivit row-olioiksi
        ''' </summary>
        Private Function ProcessRows() As Boolean

            Dim isInitializeOk As Boolean = True
            Dim RowCounter As Integer = 1

            For Each row As String In Me.m_importedFileRows

                Try

                    Dim record As String = row.Substring(m_InstructionsTable(Fields.RECORD, INDEX), m_InstructionsTable(Fields.RECORD, LENGHT))
                    Dim organisation As String = row.Substring(m_InstructionsTable(Fields.ORG, INDEX), m_InstructionsTable(Fields.ORG, LENGHT))
                    Dim personalnumber As String = row.Substring(m_InstructionsTable(Fields.PIN, INDEX), m_InstructionsTable(Fields.PIN, LENGHT))

                    Dim month As String = ""
                    Try
                        month = row.Substring(m_InstructionsTable(Fields.MONTH, INDEX), m_InstructionsTable(Fields.MONTH, LENGHT))

                        month.Trim(" ")

                        If month.Length < 2 OrElse month.Length > 2 Then
                            month = vbNullString
                        End If

                    Catch ex As Exception
                        month = vbNullString
                        Console.WriteLine("month : " & ex.StackTrace)
                    End Try

                    Dim paymenttype As String = row.Substring(m_InstructionsTable(Fields.PAYMENTTYPE, INDEX), m_InstructionsTable(Fields.PAYMENTTYPE, LENGHT))
                    Dim amount As String = row.Substring(m_InstructionsTable(Fields.AMOUNT, INDEX), m_InstructionsTable(Fields.AMOUNT, LENGHT))
                    Dim costplace As String = row.Substring(m_InstructionsTable(Fields.COSTPLACE, INDEX), m_InstructionsTable(Fields.COSTPLACE, LENGHT))
                    Dim unitprice As String = row.Substring(m_InstructionsTable(Fields.UNITPRICE, INDEX), m_InstructionsTable(Fields.UNITPRICE, LENGHT))
                    Dim transferdate As String = row.Substring(m_InstructionsTable(Fields.TRANSFERDATE, INDEX), m_InstructionsTable(Fields.TRANSFERDATE, LENGHT))
                    Dim firstdate As String = row.Substring(m_InstructionsTable(Fields.FIRSTDATE, INDEX), m_InstructionsTable(Fields.FIRSTDATE, LENGHT))
                    Dim lastdate As String = row.Substring(m_InstructionsTable(Fields.LASTDATE, INDEX), m_InstructionsTable(Fields.LASTDATE, LENGHT))

                    Dim sendid As String = ""

                    If row.Length >= 97 Then
                        Try
                            sendid = row.Substring(m_InstructionsTable(Fields.SENDID, INDEX), m_InstructionsTable(Fields.SENDID, LENGHT))
                        Catch ex As Exception
                            Console.WriteLine("SenID->" & ex.StackTrace)
                            sendid = vbNullString
                        End Try
                    Else
                        sendid = vbNullString
                    End If

                    Dim accountnumber As String = ""

                    If row.Length = 106 Then
                        Try
                            accountnumber = row.Substring(m_InstructionsTable(Fields.ACCOUNT, INDEX), m_InstructionsTable(Fields.ACCOUNT, LENGHT))
                        Catch ex As Exception
                            accountnumber = vbNullString
                        End Try
                    Else
                        accountnumber = vbNullString
                    End If

                    Dim objRow As New Row(RowCounter)
                    objRow.Record = record
                    objRow.Oraganisation = organisation
                    objRow.PersonalNumber = Integer.Parse(personalnumber)

                    If IsNumeric(month) Then
                        objRow.Month = Integer.Parse(month)
                    Else
                        objRow.Month = 0
                    End If

                    objRow.PaymentType = Integer.Parse(paymenttype)

                    Try

                        Dim tempamount As Integer = Integer.Parse(amount)
                        objRow.Amount = tempamount / 100

                    Catch ex As Exception
                        Console.WriteLine("virhe amount : " & ex.StackTrace)
                        Throw New Exception("amount : " & ex.StackTrace)
                    End Try

                    objRow.CostPlace = Integer.Parse(costplace)

                    If IsNumeric(unitprice) Then

                        Try
                            Dim tempunitprice As Integer = Integer.Parse(unitprice)
                            objRow.UnitPrice = tempunitprice / 100

                            If objRow.Amount < 0 And objRow.UnitPrice < 0 Then
                                Dim tempacalc As Single = -(objRow.Amount * objRow.UnitPrice)
                                objRow.CalculatedAmount = tempacalc
                            Else
                                objRow.CalculatedAmount = objRow.Amount * objRow.UnitPrice
                            End If

                        Catch ex As Exception
                            Console.WriteLine("virhe costplace : " & ex.StackTrace)
                            Throw New Exception("unitprice : " & ex.StackTrace)
                        End Try

                    Else
                        objRow.UnitPrice = 0
                    End If

                    Try

                        objRow.TransferDate = parseDate(transferdate)
                        objRow.FirstDate = parseDate(firstdate)
                        objRow.LastDate = parseDate(lastdate)

                        If IsNumeric(sendid) Then
                            objRow.SendId = sendid
                        Else
                            objRow.SendId = 0
                        End If

                        objRow.AccountNumber = accountnumber

                    Catch ex As Exception
                        Throw New Exception("TimeFormat error")
                    End Try

                    Me.addRowObjects(objRow)
                    RowCounter += 1

                Catch ex As Exception
                    Console.WriteLine("messagevirhe : " & ex.Message)
                    Console.WriteLine("stackvirhe : " & ex.StackTrace)
                    Dim rowError As String = "Row : " & RowCounter & " Error : " & ex.Message & " processing row: " & row
                    Console.WriteLine(rowError)
                    addFileProcessErrorRow(rowError)
                    isInitializeOk = False
                End Try

            Next

            Return isInitializeOk

        End Function

        ''' <summary>
        ''' Konvertoi päivämäärän
        ''' </summary>
        ''' <param name="dateFormat">"vvvvkkpp</param>
        ''' <returns>"pp.kk.vvvv"</returns>    
        Private Function parseDate(ByVal dateFormat As String) As DateTime

            Dim vvvv As Integer = dateFormat.Substring(0, 4)
            Dim kk As Integer = dateFormat.Substring(4, 2)
            Dim pp As Integer = dateFormat.Substring(6, 2)

            Dim returnDate As New DateTime(vvvv, kk, pp)
            Return returnDate.ToShortDateString
        End Function

    End Class

    Public Class Row

        Private m_objectID As Integer
        Private m_record As String
        Private m_organisation As String
        Private m_personalNumber As Integer
        Private m_month As Integer
        Private m_paymenttype As Integer
        Private m_amount As Single
        Private m_unitprice As Single
        Private m_calculatedamount As Single
        Private m_costplace As Integer
        Private m_transferdate As DateTime
        Private m_firstdate As DateTime
        Private m_lastdate As DateTime
        Private m_sendid As Long
        Private m_accountnumber As String

        Public Sub New(ByVal ID As Integer)
            m_objectID = ID
        End Sub

        Public ReadOnly Property ObjectID() As Integer
            Get
                Return m_objectID
            End Get
        End Property

        Public Function hasCalculatedAmount() As Boolean
            If Me.CalculatedAmount > 0 Then
                Return True
            Else
                Return False
            End If
        End Function
        Public Property Record() As String
            Get
                Return m_record
            End Get
            Set(ByVal value As String)
                m_record = value
            End Set
        End Property

        Public Property Oraganisation() As String
            Get
                Return m_organisation
            End Get
            Set(ByVal value As String)
                m_organisation = value
            End Set
        End Property

        Public Property PersonalNumber() As Integer
            Get
                Return m_personalNumber
            End Get
            Set(ByVal value As Integer)
                m_personalNumber = value
            End Set
        End Property

        Public Property Month() As Integer
            Get
                Return m_month
            End Get
            Set(ByVal value As Integer)
                m_month = value
            End Set
        End Property

        Public Property PaymentType() As Integer
            Get
                Return m_paymenttype
            End Get
            Set(ByVal value As Integer)
                m_paymenttype = value
            End Set
        End Property

        Public Property Amount() As Single
            Get
                Return m_amount
            End Get
            Set(ByVal value As Single)
                m_amount = value
            End Set
        End Property

        Public Property UnitPrice() As Single
            Get
                Return m_unitprice
            End Get
            Set(ByVal value As Single)
                m_unitprice = value
            End Set
        End Property

        Public Property CalculatedAmount() As Single
            Get
                Return m_calculatedamount
            End Get
            Set(ByVal value As Single)
                m_calculatedamount = value
            End Set
        End Property

        Public Property CostPlace() As Integer
            Get
                Return m_costplace
            End Get
            Set(ByVal value As Integer)
                m_costplace = value
            End Set
        End Property

        Public Property TransferDate() As DateTime
            Get
                Return m_transferdate
            End Get
            Set(ByVal value As DateTime)
                m_transferdate = value
            End Set
        End Property

        Public Property FirstDate() As DateTime
            Get
                Return m_firstdate
            End Get
            Set(ByVal value As DateTime)
                m_firstdate = value
            End Set
        End Property

        Public Property LastDate() As DateTime
            Get
                Return m_lastdate
            End Get
            Set(ByVal value As DateTime)
                m_lastdate = value
            End Set
        End Property

        Public Property SendId() As Integer
            Get
                Return m_sendid
            End Get
            Set(ByVal value As Integer)
                m_sendid = value
            End Set
        End Property


        Public Property AccountNumber() As String
            Get
                Return m_accountnumber
            End Get
            Set(ByVal value As String)
                m_accountnumber = value
            End Set
        End Property

    End Class

End Namespace