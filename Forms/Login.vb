Public Class Login

#Region "Catch"

    Private Delegate Sub SafeApplicationThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)

    Private Sub ShowDebugOutput(ByVal ex As Exception)
        Dim pop As New Crash
        Crash.ErrCode.Text = "Something terrible happened inside osu!rc with the following error code:" & vbNewLine & vbNewLine & ex.ToString
        Crash.ShowDialog()
    End Sub

    Private Sub app_ThreadException(ByVal sender As Object, ByVal e As Threading.ThreadExceptionEventArgs)

        'This is not thread safe, so make it thread safe.
        If Me.InvokeRequired Then
            ' Invoke back to the main thread
            Me.Invoke(New SafeApplicationThreadException(AddressOf app_ThreadException), New Object() {sender, e})
        Else
            ShowDebugOutput(e.Exception)
        End If

    End Sub

    Private Sub AppDomain_UnhandledException(ByVal sender As Object, ByVal e As UnhandledExceptionEventArgs)
        ShowDebugOutput(DirectCast(e.ExceptionObject, Exception))
    End Sub

    Private Sub MyApplication_UnhandledException(ByVal sender As Object, ByVal e As Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs)
        ShowDebugOutput(e.Exception)
    End Sub

#End Region

    Private Sub MainLogin(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomain_UnhandledException
        AddHandler System.Windows.Forms.Application.ThreadException, AddressOf app_ThreadException
        LogBtn.Select()
        If IO.File.Exists(Null.maincfg) Then
            If ReadIni(Null.maincfg, Null.Section, Null.AutoLogin, "") = 1 Then
                Autolog.Checked = True
            End If
            Try

                log_name.Text = ReadIni(Null.maincfg, Null.Section, Null.Username, "")
            Catch
            End Try
            Dim password As String = "mysaddle"
            Dim wrapper As New Cryptopass(password)
            log_pas.Text = wrapper.DecryptData(ReadIni(Null.maincfg, Null.Section, Null.Password, ""))
            If AutoSave.Checked = False Then
                writeIni(Null.maincfg, Null.Section, Null.Password, Nothing)
                writeIni(Null.maincfg, Null.Section, Null.Username, Nothing)
                log_pas.Text = Nothing
                log_name.Text = Nothing
            End If
        End If
        Me.Location = New Point(Me.Location.X + 200, Me.Location.Y)
        Me.Icon = My.Resources.app
        log_name.Parent = LogForm
        log_pas.Parent = LogForm
        Autolog.Parent = LogForm
        AutoSave.Parent = LogForm
        Thr.Parent = LogForm
        log_name.Font = AllerFont.GetInstance(16, FontStyle.Regular)
        log_pas.Font = AllerFont.GetInstance(16, FontStyle.Regular)
        LogBtn.Font = AllerFont.GetInstance(10, FontStyle.Regular)
        Autolog.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        AutoSave.Font = AllerFont.GetInstance(9, FontStyle.Regular)
    End Sub

    Private Sub StartFade_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartFade.Tick
        If Not Me.Opacity >= 1 Then
            Me.Opacity += 0.1
            Me.Location = New Point(Me.Location.X - 20, Me.Location.Y)
        Else
            StartFade.Stop()
        End If
    End Sub

    Private Sub EndFade_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EndFade.Tick
        Me.Opacity -= 0.1
        Select Case Me.Opacity
            Case 0
                Main.Show()
                Me.Close()
                GC.Collect()
            Case 0.1 To 1
                Me.Location = New Point(Me.Location.X - 20, Me.Location.Y)
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogBtn.Click
        If log_name.Text = Nothing Then
            MsgBox("Username field cannot be left blank.", MsgBoxStyle.Exclamation, "Input Exception")
            log_name.Select()
        Else
            If AutoSave.Checked = True Then
                Dim password As String = "mysaddle"
                Dim wrapper As New Cryptopass(password)
                Dim cipherText As String = wrapper.EncryptData(log_pas.Text)
                writeIni(Null.maincfg, Null.Section, Null.Password, cipherText)
                writeIni(Null.maincfg, Null.Section, Null.Username, log_name.Text)
                writeIni(Null.maincfg, Null.Section, Null.AutoLogin, Autolog.CheckState)
            Else
                writeIni(Null.maincfg, Null.Section, Null.Password, Nothing)
                writeIni(Null.maincfg, Null.Section, Null.Username, Nothing)
            End If
            EndFade.Start()
        End If
        writeIni(Null.maincfg, Null.Section, Null.HighlightSound, "1")
    End Sub

    Private Sub Autolog_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Autolog.CheckedChanged
        writeIni(Null.maincfg, Null.Section, Null.AutoLogin, Autolog.CheckState)
    End Sub


    Private Sub Thr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Thr.Click
        Process.Start("https://osu.ppy.sh/forum/t/265602")
    End Sub

    Private Sub Login_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
End Class