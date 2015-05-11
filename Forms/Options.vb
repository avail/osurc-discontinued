Public Class Options

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

    Dim converter As System.ComponentModel.TypeConverter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(Font))
    Dim IsTab1 As Boolean = False
    Dim IsTab2 As Boolean = False
    Dim IsTab3 As Boolean = False
    Dim IsTab4 As Boolean = False
    Dim IsTabBack As Boolean = False
    Dim IsTabEndFix As Boolean = False
    Private Sub MainOptions(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '569, 379
        If IO.File.Exists("refs\userdata") Then
            PictureBox1.Image = Image.FromFile("refs\userdata")
        Else
            PictureBox1.Image = My.Resources.avatar_404
        End If

        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomain_UnhandledException
        AddHandler System.Windows.Forms.Application.ThreadException, AddressOf app_ThreadException
        B_About.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        B_Channels.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        B_Friends.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        B_General.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        P_Chans.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        P_Friends.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        P_General.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        Label1.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Label1.Parent = P_Chans
        Label2.Parent = P_Chans
        CurrentUser.Text = String.Format("Current user: {0}", Main.osuirc.Nick)
        If IO.File.Exists(Null.maincfg) Then
            Try
                TextBox1.Text = ReadIni(Null.maincfg, Null.Section, Null.Friends, "")
                DeFont.Text = ReadIni(Null.maincfg, Null.Section, Null.CustomFont, "")
                If ReadIni(Null.maincfg, Null.Section, Null.AutoLogin, "") = 1 Then
                    OptnAutoLogin.Checked = True
                Else
                    OptnAutoLogin.Checked = False
                End If
                If ReadIni(Null.maincfg, Null.Section, Null.Popups, "") = 1 Then
                    ShowPopups.Checked = True
                Else
                    ShowPopups.Checked = False
                End If
                If ReadIni(Null.maincfg, Null.Section, Null.HighlightSound, "") = 1 Then
                    PlayHL.Checked = True
                Else
                    PlayHL.Checked = False
                End If
            Catch
            End Try
        End If
        Main.osuchat.DetectUrls = True
        CType(AboutBrowser, System.Windows.Forms.Control).Enabled = False
        B_General.PerformClick()
    End Sub
    Private Sub Options_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not TextBox1.Text = Nothing Then
            writeIni(Null.maincfg, Null.Section, Null.Friends, TextBox1.Text)
        End If
        GC.Collect()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptnAutoLogin.CheckedChanged
        writeIni(Null.maincfg, Null.Section, Null.AutoLogin, OptnAutoLogin.CheckState)
    End Sub

    Private Sub CheckBox37_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowPopups.CheckedChanged
        writeIni(Null.maincfg, Null.Section, Null.Popups, ShowPopups.CheckState)
    End Sub

    Private Sub PlayHL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayHL.CheckedChanged
        writeIni(Null.maincfg, Null.Section, Null.HighlightSound, PlayHL.CheckState)
    End Sub

    Private Sub Options_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.Modifiers
            Case Keys.Control
                Select Case e.KeyCode
                    Case Keys.D1
                        B_General.PerformClick()
                    Case Keys.D2
                        B_Channels.PerformClick()
                    Case Keys.D3
                        B_Friends.PerformClick()
                    Case Keys.D4
                        B_About.PerformClick()
                End Select
        End Select
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelFont.Click
        If ChatFont.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim tempstr As String = Main.osuchat.Text
            Main.osuchat.Clear()
            Main.osuchat.Font = ChatFont.Font
            DeFont.Text = String.Format("{0}, {1}", ChatFont.Font.Name, ChatFont.Font.Size)
            writeIni(Null.maincfg, Null.Section, Null.CustomFont, String.Format("{0}, {1}", ChatFont.Font.Name, ChatFont.Font.Size))
            Main.osuchat.Text = tempstr
            Main.osuchat.ScrollToCaret()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetDefaultFont.Click
        Dim tempstr As String = Main.osuchat.Text
        Main.osuchat.Clear()
        Main.osuchat.Font = AllerFont.GetInstance(13.5, FontStyle.Regular)
        writeIni(Null.maincfg, Null.Section, Null.CustomFont, "Default")
        DeFont.Text = "Default"
        Main.osuchat.Text = tempstr
        Main.osuchat.ScrollToCaret()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOut.Click
        If IO.File.Exists(Null.maincfg) Then
            Select Case ReadIni(Null.maincfg, Null.Section, Null.AutoLogin, "")
                Case 0
                    writeIni(Null.maincfg, Null.Section, Null.AutoLogin, 2)
                Case 1
                    writeIni(Null.maincfg, Null.Section, Null.AutoLogin, 3)
            End Select
        End If
        Application.Restart()
    End Sub
#Region "Alternate"

    Private Sub B_General_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_General.Click
        B_General.BackColor = Color.FromArgb(85, 32, 56)
        B_Channels.BackColor = Color.FromArgb(96, 36, 63)
        B_Friends.BackColor = Color.FromArgb(96, 36, 63)
        B_About.BackColor = Color.FromArgb(96, 36, 63)
        IsTab1 = True
        IsTab2 = False
        IsTab3 = False
        IsTab4 = False
        AboutBrowser.Navigate("")
        P_General.Location = New Point(0, 29)
        P_Friends.Location = New Point(570, 29)
        P_Chans.Location = New Point(571, 360)
        P_About.Location = New Point(0, 357)
    End Sub

    Private Sub B_Channels_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Channels.Click
        B_General.BackColor = Color.FromArgb(96, 36, 63)
        B_Channels.BackColor = Color.FromArgb(85, 32, 56)
        B_Friends.BackColor = Color.FromArgb(96, 36, 63)
        B_About.BackColor = Color.FromArgb(96, 36, 63)
        IsTab1 = False
        IsTab2 = True
        IsTab3 = False
        IsTab4 = False
        AboutBrowser.Navigate("")
        P_General.Location = New Point(571, 360)
        P_Friends.Location = New Point(570, 29)
        P_Chans.Location = New Point(0, 29)
        P_About.Location = New Point(0, 357)
    End Sub

    Private Sub B_Friends_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_Friends.Click
        B_General.BackColor = Color.FromArgb(96, 36, 63)
        B_Channels.BackColor = Color.FromArgb(96, 36, 63)
        B_Friends.BackColor = Color.FromArgb(85, 32, 56)
        B_About.BackColor = Color.FromArgb(96, 36, 63)
        IsTab1 = False
        IsTab2 = False
        IsTab3 = True
        IsTab4 = False
        AboutBrowser.Navigate("")
        P_General.Location = New Point(571, 360)
        P_Friends.Location = New Point(0, 29)
        P_Chans.Location = New Point(570, 29)
        P_About.Location = New Point(0, 357)
    End Sub

    Private Sub B_About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B_About.Click
        B_General.BackColor = Color.FromArgb(96, 36, 63)
        B_Channels.BackColor = Color.FromArgb(96, 36, 63)
        B_Friends.BackColor = Color.FromArgb(96, 36, 63)
        B_About.BackColor = Color.FromArgb(85, 32, 56)
        IsTab1 = False
        IsTab2 = False
        IsTab3 = False
        IsTab4 = True
        AboutBrowser.Navigate("https://www.youtube.com/embed/s_m-Ez3W5h4?rel=0&autoplay=1&showinfo=0&controls=0&autohide=1")
        P_General.Location = New Point(571, 360)
        P_Friends.Location = New Point(0, 357)
        P_Chans.Location = New Point(570, 29)
        P_About.Location = New Point(0, 29)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Select Case IsTabBack
            Case True
                If IsTab1 = True Then
                    IsTabBack = False
                    IsTabEndFix = False
                    Do Until Selight.Location = New Point(0, 23)
                        Selight.Location = New Point(Selight.Location.X - 1, 23)
                    Loop
                End If
                If IsTab2 = True Then
                    IsTabBack = True
                    IsTabEndFix = False
                    Do Until Selight.Location = New Point(141, 23)
                        Selight.Location = New Point(Selight.Location.X - 1, 23)
                    Loop
                End If
                If IsTab3 = True Then
                    IsTabBack = True
                    If IsTabEndFix = True Then
                        Do Until Selight.Location = New Point(282, 23)
                            Selight.Location = New Point(Selight.Location.X - 1, 23)
                        Loop
                    Else
                        Do Until Selight.Location = New Point(282, 23)
                            Selight.Location = New Point(Selight.Location.X + 1, 23)
                        Loop
                    End If
                End If
                If IsTab4 = True Then
                    IsTabBack = True
                    IsTabEndFix = True
                    Do Until Selight.Location = New Point(423, 23)
                        Selight.Location = New Point(Selight.Location.X + 1, 23)
                    Loop
                End If
            Case False
                If IsTab1 = True Then
                    IsTabBack = False
                    IsTabEndFix = False
                    Do Until Selight.Location = New Point(0, 23)
                        Selight.Location = New Point(Selight.Location.X - 1, 23)
                    Loop
                End If
                If IsTab2 = True Then
                    IsTabEndFix = False
                    IsTabBack = True
                    Do Until Selight.Location = New Point(141, 23)
                        Selight.Location = New Point(Selight.Location.X + 1, 23)
                    Loop
                End If
                If IsTab3 = True Then
                    IsTabBack = True
                    IsTabEndFix = False
                    Do Until Selight.Location = New Point(282, 23)
                        Selight.Location = New Point(Selight.Location.X + 1, 23)
                    Loop
                End If
                If IsTab4 = True Then
                    IsTabBack = True
                    IsTabEndFix = True
                    Do Until Selight.Location = New Point(423, 23)
                        Selight.Location = New Point(Selight.Location.X + 1, 23)
                    Loop
                End If
        End Select
    End Sub
#End Region
End Class