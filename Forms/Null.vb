Public Class Null

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

    Public Shared maincfg = Application.StartupPath + String.Format("\osu!rc.{0}.cfg", Environment.UserName)
    Public Shared Section = String.Format("osu!rc config for {0}", Environment.UserName)
    Public Shared AutoLogin = "AutoLogin"
    Public Shared Username = "Username"
    Public Shared Password = "Password"
    Public Shared Channels = "Channels"
    Public Shared Friends = "Friends"
    Public Shared Popups = "Popups"
    Public Shared CustomFont = "CustomFont"
    Public Shared HighlightSound = "HighlightSound"

    Private Sub JustNull(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomain_UnhandledException
        AddHandler System.Windows.Forms.Application.ThreadException, AddressOf app_ThreadException
        Select Case Not IO.File.Exists(True)
            Case Not IO.File.Exists("refs\AlphaBlendTextBox.dll") AndAlso Not IO.File.Exists("AlphaBlendTextBox.dll")
                MsgBox("The referenced component 'AlphaBlendTextBox.dll' seems to be missing." & vbNewLine & "Find it pls.", MsgBoxStyle.Critical, "osu!rc cannot start?!")
                Me.Close()
            Case Not IO.File.Exists("refs\IrcClient.dll") AndAlso Not IO.File.Exists("IrcClient.dll")
                MsgBox("The referenced component 'IrcClient.dll' seems to be missing." & vbNewLine & "Find it pls.", MsgBoxStyle.Critical, "osu!rc cannot start?!")
                Me.Close()
        End Select
        Me.Location = New Point(0, 0)
        If IO.File.Exists(maincfg) Then
            If ReadIni(maincfg, Section, AutoLogin, "") = 1 Then
                If ReadIni(maincfg, Section, Password, "") = "" Then
                    writeIni(maincfg, Section, AutoLogin, "0")
                    Login.Show()
                    Me.Close()
                Else
                    Main.Show()
                    Me.Close()
                End If
            ElseIf ReadIni(maincfg, Section, AutoLogin, "") = 2 Then
                writeIni(maincfg, Section, AutoLogin, "0")
                Login.Show()
                Me.Close()
            ElseIf ReadIni(maincfg, Section, AutoLogin, "") = 3 Then
                writeIni(maincfg, Section, AutoLogin, "1")
                Login.Show()
                Me.Close()
            Else
                Login.Show()
                Me.Close()
            End If
        Else
            Login.Show()
            Me.Close()
        End If
        GC.Collect()
    End Sub
End Class