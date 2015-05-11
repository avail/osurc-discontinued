Imports System.Drawing.Text
Imports System.Runtime.InteropServices
Module AllerFont

    Private dfx As PrivateFontCollection = Nothing
    Public ReadOnly Property GetInstance(ByVal Size As Single, ByVal style As FontStyle) As Font
        Get
            If dfx Is Nothing Then LoadFont()
            Return New Font(dfx.Families(0), Size, style)
        End Get
    End Property

    Private Sub LoadFont()
        Try
            dfx = New PrivateFontCollection
            Dim fontMemPointer As IntPtr = Marshal.AllocCoTaskMem(My.Resources.Aller.Length)
            Marshal.Copy(My.Resources.Aller, 0, fontMemPointer, My.Resources.Aller.Length)
            dfx.AddMemoryFont(fontMemPointer, My.Resources.Aller.Length)
            Marshal.FreeCoTaskMem(fontMemPointer)
        Catch ex As Exception
            MsgBox("Error in loading PrivateFontCollection, how did you manage this?")
        End Try
    End Sub
End Module