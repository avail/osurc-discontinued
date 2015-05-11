Public Class Crash

    Private Sub Crash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rcerror.Select()
        rcerror.Parent = Me
        rcerror.BackColor = Color.Transparent
        ErrCode.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        BtnCopy.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        BtnContinue.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        BtnTerminate.Font = AllerFont.GetInstance(9, FontStyle.Regular)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Clipboard.SetText(ErrCode.Text)
    End Sub

    Private Sub Crash_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub BtnTerminate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTerminate.Click
        Application.Exit()
    End Sub

    Private Sub BtnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnContinue.Click
        Me.Close()
    End Sub

    Dim t As Integer
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        t += 1
        Select Case t
            Case 1, 3
                rcerror.Visible = False
            Case 2, 4
                rcerror.Visible = True
            Case 5
                t = 0
                Timer1.Stop()
        End Select
    End Sub

End Class
