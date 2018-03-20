'
'
'
' Revisio $Revision$
'
' Ilmentää laskulle lisättävän asiakaskohtaisen kentän 
'

Imports NetvisorWSClient.util

Namespace NetvisorWSClient.communication.sales
    Public Class NetvisorInvoiceCustomTag

        Public Const ATTRIBUTE_DATATYPE_DATE As String = "date"
        Public Const ATTRIBUTE_DATATYPE_ENUM As String = "enum"
        Public Const ATTRIBUTE_DATATYPE_TEXT As String = "text"
        Public Const ATTRIBUTE_DATATYPE_FLOAT As String = "float"

        Public Enum CustomTagDataTypes As Integer
            [date] = 1
            [enum] = 2
            text = 3
            float = 4
        End Enum

        Private m_name As String
        Private m_value As String
        Private m_valueDataType As CustomTagDataTypes
        
		Public Property name() As String
			 Get
				 Return m_name
			 End Get			
			 Set(ByVal Value As String)
				 m_name = Value
			 End Set
		 End Property

        Public Property value() As String
            Get
                Return m_value
            End Get
            Set(ByVal Value As String)
                m_value = Value
            End Set
        End Property

        Public Property valueDataType() As CustomTagDataTypes
            Get
                Return m_valueDataType
            End Get
            Set(ByVal Value As CustomTagDataTypes)
                m_valueDataType = Value
            End Set
        End Property
    End Class
End Namespace