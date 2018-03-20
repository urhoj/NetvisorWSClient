'
'
'
' Revisio $Revision$
'
' Generoi yksilöllisiä tunnisteita
'

Namespace NetvisorWSClient.util
    Public Class UniqueIdentifierGenerator

        Private m_identifier As String

        Public ReadOnly Property identifier() As String
            Get
                Return m_identifier
            End Get
        End Property

        Public Sub New()
            Randomize()
            m_identifier = Format(Now, "yyMMddhhmmss") & Now.Millisecond & (Int((10000 * Rnd()) + 1)).ToString
        End Sub

    End Class
End Namespace