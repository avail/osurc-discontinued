Imports TechLifeForum
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.Text
Public Class Main

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
#Region "Avatar"
    Public Function GetStringBetween(ByVal InputText As String, ByVal starttext As String, ByVal endtext As String)
        Dim lnTextStart As Long
        Dim lnTextEnd As Long
        lnTextStart = InStr(StartPosition, InputText, starttext, vbTextCompare) + Len(starttext)
        lnTextEnd = InStr(lnTextStart, InputText, endtext, vbTextCompare)
        GetStringBetween = Mid$(InputText, lnTextStart, lnTextEnd - lnTextStart)
    End Function
    Private Sub GetAvatar()
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(String.Format("https://osu.ppy.sh/u/{0}", osuirc.Nick))
            Dim response As System.Net.HttpWebResponse = request.GetResponse()
            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
            Dim sourcecode As String = sr.ReadToEnd()
            Dim avatarparse As String = Replace(sourcecode, """", "")
            Dim avatar As String = GetStringBetween(avatarparse, "avatar-holder><img src=", " alt=User avatar")
            Dim avatar2 As String = "http:" + avatar
            My.Computer.Network.DownloadFile(avatar2, Application.StartupPath + "\refs\userdata")
        Catch
        End Try
    End Sub
#End Region
    Public WithEvents osuirc As New IrcClient("cho.ppy.sh", 6667)
    Dim Online As Integer
    Dim Connected As Boolean = False
    Dim CLCount As Integer
    Dim converter As System.ComponentModel.TypeConverter = System.ComponentModel.TypeDescriptor.GetConverter(GetType(Font))
    Dim HighlightIcon As Boolean = False
    Dim UserLines As New AutoCompleteStringCollection

    <Runtime.InteropServices.DllImport("user32.dll", SetLastError:=True)> Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    Private ReadOnly Property IsForegroundWindow As Boolean
        Get
            Dim foreWnd = GetForegroundWindow()
            Return ((From f In Me.MdiChildren Select f.Handle).Union(From f In Me.OwnedForms Select f.Handle).Union({Me.Handle})).Contains(foreWnd)
        End Get
    End Property

    'Public Shared SuppCheck As New System.Net.WebClient()
    'Public Shared SuppString
#Region "ChatManager"
    Dim IsArabic As Boolean : Dim channelarabic As String
    Dim IsBulgarian As Boolean
    Dim IsCantonese As Boolean
    Dim IsChinese As Boolean
    Dim IsCTB As Boolean
    Dim IsCzechoslovak As Boolean
    Dim IsDutch As Boolean
    Dim IsEnglish As Boolean
    Dim IsFilipino As Boolean
    Dim IsFinnish As Boolean
    Dim IsFrench As Boolean
    Dim IsGerman As Boolean
    Dim IsGreek As Boolean
    Dim IsHebrew As Boolean
    Dim IsHelp As Boolean
    Dim IsHungarian As Boolean
    Dim IsIndonesian As Boolean
    Dim IsItalian As Boolean
    Dim IsJapanese As Boolean
    Dim IsKorean As Boolean
    Dim IsLobby As Boolean : Dim channellobby As String
    Dim IsMalaysian As Boolean
    Dim IsModhelp As Boolean
    Dim IsModreqs As Boolean
    Dim IsOsu As Boolean : Dim channelosu As String
    Dim IsOsuMania As Boolean
    Dim IsPolish As Boolean
    Dim IsPortuguese As Boolean
    Dim IsRomanian As Boolean
    Dim IsRussian As Boolean
    Dim IsSkandinavian As Boolean
    Dim IsSpanish As Boolean
    Dim IsTaiko As Boolean
    Dim IsThai As Boolean
    Dim IsTurkish As Boolean
    Dim IsVideogames As Boolean
    Dim IsVietnamese As Boolean
#End Region
    Private Sub JustMain(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf AppDomain_UnhandledException
        AddHandler System.Windows.Forms.Application.ThreadException, AddressOf app_ThreadException
        Me.Location = New Point(Me.Location.X + 200, Me.Location.Y)
        Me.Icon = My.Resources.app
        channame.BackColor = Color.Transparent
        channame.Parent = PictureBox1
        If Not ReadIni(Null.maincfg, Null.Section, Null.Password, "") = "" Then
            Dim password As String = "mysaddle"
            Dim wrapper As New Cryptopass(password)
            osuirc.ServerPass = wrapper.DecryptData(ReadIni(Null.maincfg, Null.Section, Null.Password, ""))
        Else
            osuirc.ServerPass = ""
            Dim password As String = "mysaddle"
            Dim wrapper As New Cryptopass(password)
        End If
        osuirc.Nick = ReadIni(Null.maincfg, Null.Section, Null.Username, "")
        osuirc.Connect()
        user.Font = AllerFont.GetInstance(11, FontStyle.Regular)
        channame.Font = AllerFont.GetInstance(10, FontStyle.Regular)
        Version.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        typename.Font = AllerFont.GetInstance(11, FontStyle.Regular)
        typename.Text = osuirc.Nick & ":"
        typename.Location = New Point(user.Location.X - 5 - typename.Width, typename.Location.Y)
        Version.Parent = PictureBox1
        osuchat.Font = AllerFont.GetInstance(13.5, FontStyle.Regular)
        Select Case True
            Case ReadIni(Null.maincfg, Null.Section, Null.CustomFont, "").Contains("Default")
                osuchat.Font = AllerFont.GetInstance(13.5, FontStyle.Regular)
            Case ReadIni(Null.maincfg, Null.Section, Null.CustomFont, "").Contains(",")
                osuchat.Font = converter.ConvertFromString(ReadIni(Null.maincfg, Null.Section, Null.CustomFont, ""))
            Case Else
                osuchat.Font = AllerFont.GetInstance(13.5, FontStyle.Regular)
        End Select
    End Sub

    Private Sub osuirc_ChannelMessage(ByVal sender As Object, ByVal e As TechLifeForum.ChannelMessageEventArgs) Handles osuirc.ChannelMessage
        CLCount += 1  
        Select Case True
            Case e.Channel.Contains("#osu")
                Select Case True
                    Case e.Message.Contains("ACTION")
                        Dim ame As String = Replace(e.Message, "ACTION", "")
                        channelosu = channelosu & vbNewLine & Date.Now.ToLongTimeString() & " *" & e.From & ame.Substring(1)
                        osuchat.SelectionColor = Color.White
                    Case e.Message.Contains(osuirc.Nick)
                        If IsForegroundWindow = False Then
                            Try
                                If ReadIni(Null.maincfg, Null.Section, Null.HighlightSound, "") = 1 Then
                                    Me.Icon = My.Resources.app_highlight
                                    My.Computer.Audio.Play("refs/highlight.wav", AudioPlayMode.Background)
                                    HighlightIcon = True
                                    HLFlash.Start()
                                End If
                            Catch
                            End Try
                        End If
                        osuchat.SelectionColor = Color.LimeGreen
                        channelosu = channelosu & vbNewLine & "[!] " & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message
                        osuchat.SelectionColor = Color.White
                    Case e.Message.Contains(LCase$(osuirc.Nick))
                        If IsForegroundWindow = False Then
                            Try
                                If ReadIni(Null.maincfg, Null.Section, Null.HighlightSound, "") = 1 Then
                                    Me.Icon = My.Resources.app_highlight
                                    My.Computer.Audio.Play("refs/highlight.wav", AudioPlayMode.Background)
                                    HighlightIcon = True
                                    HLFlash.Start()
                                End If
                            Catch
                            End Try
                        End If
                        osuchat.SelectionColor = Color.LimeGreen
                        channelosu = channelosu & vbNewLine & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message
                        osuchat.SelectionColor = Color.White
                    Case e.From = "BanchoBot"
                        osuchat.SelectionColor = Color.HotPink
                        channelosu = channelosu & vbNewLine & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message
                        osuchat.SelectionColor = Color.White
                        osuchat.AppendText(e.Message)
                    Case e.From = osuirc.Nick
                        channelosu = channelosu & vbNewLine & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message
                    Case True
                        'SuppString = SuppCheck.DownloadString("https://osu.ppy.sh/u/" & e.From)
                        'If SuppString.Contains("profileSupporter") Then
                        ' osuchat.SelectionColor = Color.Yellow
                        ' osuchat.AppendText(vbNewLine & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message)
                        ' osuchat.SelectionColor = Color.White
                        ' Else
                        ' osuchat.SelectionColor = Color.White
                        'osuchat.AppendText(vbNewLine & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message)
                        'End If
                        osuchat.SelectionColor = Color.White
                        channelosu = channelosu & vbNewLine & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message
                End Select
            Case e.Channel.Contains("#lobby")
                channellobby = channellobby & vbNewLine & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message
        End Select

    End Sub

    Private Sub osuirc_ExceptionThrown(ByVal sender As Object, ByVal e As TechLifeForum.ExceptionEventArgs) Handles osuirc.ExceptionThrown
        osuchat.SelectionColor = Color.Red
        osuchat.AppendText(vbNewLine & "Connection lost. Attempting to reconnect")
        osuchat.SelectionColor = Color.White
        osuirc.Connect()
    End Sub

    Private Sub osuirc_OnConnect(ByVal sender As Object, ByVal e As System.EventArgs) Handles osuirc.OnConnect
        user.Enabled = True
        GetAvatar()
        osuirc.JoinChannel("#osu")
        osuirc.JoinChannel("#lobby")
        osuchat.AppendText("Hello, keep in mind this is still in testing phase, so if anything bad happens, report it!")
        osuchat.SelectionColor = Color.White
    End Sub

    Private Sub osuirc_PrivateMessage(ByVal sender As Object, ByVal e As TechLifeForum.PrivateMessageEventArgs) Handles osuirc.PrivateMessage
        osuchat.AppendText(vbNewLine & "[PM] " & Date.Now.ToLongTimeString() & " " & e.From & ": " & e.Message)
    End Sub


    Private Sub osuirc_ServerMessage(ByVal sender As Object, ByVal e As TechLifeForum.StringEventArgs) Handles osuirc.ServerMessage
        If Connected = False Then
            osuchat.AppendText(e.ToString & vbCrLf)
        End If
    End Sub

    Private Sub Main_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If IO.File.Exists("refs\userdata") Then
                Options.PictureBox1.Image.Dispose()
                IO.File.Delete("refs\userdata")
            End If
        Catch
        End Try
        Try
            IO.File.Delete("refs\userdata")
        Catch
        End Try
        Try
            Application.Exit()
            osuirc.Disconnect()
            osuirc.Dispose()
        Catch
        End Try
    End Sub
    Private Function GetAppX() As Integer
        Dim xpos As Integer
        Dim Forms As FormCollection = Application.OpenForms
        For Each ctrl As Form In Forms
            If TypeOf ctrl Is Popup Then
                xpos = ctrl.Bottom + 30
            End If
        Next
        Return xpos
    End Function
    Private Sub user_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles user.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            Select Case True
                Case user.Text = Nothing
                    'do nothing
                Case user.Text = "/help"
                    user.Text = Nothing
                    MsgBox("/info - show memory usage and total chatlines displayed" & vbCrLf & _
                    "/clear - erase all chatlines" & vbCrLf & "/poof - exit the client" & vbCrLf & _
                    "/restart - restart the client" & vbCrLf & "/logout - log out and return to login windo", MsgBoxStyle.Information, "osu!rc commands")
                Case user.Text = "/"
                    user.Text = Nothing
                Case user.Text = "/np"
                    'osuirc.SendMessage("#osu", osuirc.Nick & " is listening to nothing")
                    'osuchat.SelectionColor = Color.FromArgb(200, 200, 200)
                    'osuchat.AppendText(vbNewLine & Date.Now.ToLongTimeString() & " " & osuirc.Nick & " is listening to nothing")
                    user.Text = Nothing
                    'osuchat.SelectionColor = Color.White
                Case user.Text = "/poof"
                    Application.Exit()
                Case user.Text = "/restart"
                    Application.Restart()
                Case user.Text = "/logout"
                    If IO.File.Exists(Null.maincfg) Then
                        Select Case ReadIni(Null.maincfg, Null.Section, Null.AutoLogin, "")
                            Case 0
                                writeIni(Null.maincfg, Null.Section, Null.AutoLogin, 2)
                            Case 1
                                writeIni(Null.maincfg, Null.Section, Null.AutoLogin, 3)
                        End Select
                    End If
                    Application.Restart()
                Case user.Text = "/popup"
                    Dim notification As New Popup
                    user.Text = Nothing
                    notification.Location = New Point(notification.Location.X, GetAppX)
                    notification.Show()
                Case user.Text = "/info"
                    Dim i As Process = Process.GetCurrentProcess()
                    user.Text = Nothing
                    MsgBox(String.Format("You are running osu!rc {0} ({1})", Version.Text, Application.ProductVersion) & vbNewLine & vbNewLine & String.Format("{0} Lines of chat shown.", CLCount) & vbNewLine & "Memory Usage (Working Set): " _
                    & i.WorkingSet64 / 1024 & " K" & vbNewLine & "VM Size (Private Bytes): " & i.PagedMemorySize64 / 1024 & " K" & vbNewLine & "GC Total Memory: " _
                    & GC.GetTotalMemory(True) & " bytes")
                Case user.Text = "/clear"
                    user.Text = Nothing
                    osuchat.Clear()
                Case user.Text.Contains("/me ")
                    Dim a As String = Replace(user.Text, "/me ", "")
                    osuirc.SendMessage("#osu", Chr(1) + "ACTION " + a)
                    osuchat.SelectionColor = Color.FromArgb(200, 200, 200)
                    osuchat.AppendText(vbNewLine & Date.Now.ToLongTimeString() & " *" & osuirc.Nick & " " & a)
                    user.Text = Nothing
                Case Else
                    PrevLines.Items.Add(user.Text)
                    PrevLines.SelectedIndex = -1
                    CLCount += 1
                    osuchat.SelectionColor = Color.FromArgb(200, 200, 200)
                    osuchat.AppendText(vbNewLine & Date.Now.ToLongTimeString() & " " & osuirc.Nick & ": " & user.Text)
                    osuchat.SelectionColor = Color.White
                    osuirc.SendMessage("#osu", user.Text)
                    user.Text = Nothing
            End Select
        End If
        If e.Modifiers = Keys.Control And e.KeyCode = Keys.A Then
            e.SuppressKeyPress = True
            user.SelectAll()
        End If
        Select Case e.KeyCode
            Case Keys.Up
                Select Case PrevLines.SelectedIndex
                    Case 0 Or -1
                        PrevLines.SelectedIndex = PrevLines.Items.Count - 1
                    Case PrevLines.SelectedIndex = PrevLines.Items.Count - 1
                        PrevLines.SelectedIndex -= 1
                    Case Else
                        PrevLines.SelectedIndex -= 1
                End Select
                user.Text = PrevLines.SelectedItem
            Case Keys.Down
                If PrevLines.SelectedIndex = PrevLines.Items.Count - 1 Then
                    PrevLines.SelectedIndex = 0
                Else
                    PrevLines.SelectedIndex += 1
                End If
                user.Text = PrevLines.SelectedItem
        End Select
    End Sub

    Private Sub Motd_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Motd.Tick
        If osuchat.Text.Contains("To get started try joining") Then
            UserLines.AddRange(onlineusers.Items.Cast(Of String)().ToArray())
            osuchat.Clear()
            user.Select()
        End If
        If osuchat.Text.Contains("BanchoBot!BanchoBot") Then
            osuchat.Clear()
            MTitle.Start()
            Motd.Stop()
        End If
    End Sub

    Private Sub osuchatLinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkClickedEventArgs) Handles osuchat.LinkClicked
        Process.Start(e.LinkText)
    End Sub

    Private Sub osuirc_UpdateUsers(ByVal sender As Object, ByVal e As TechLifeForum.UpdateUsersEventArgs) Handles osuirc.UpdateUsers
        For Each u In e.UserList
            onlineusers.Items.Add(u)
        Next
        Connected = True
        Online = onlineusers.Items.Count
    End Sub

    Private Sub osuirc_UserJoined(ByVal sender As Object, ByVal e As TechLifeForum.UserJoinedEventArgs) Handles osuirc.UserJoined
        Online += 1
        onlineusers.Items.Add(e.User)
    End Sub

    Private Sub osuirc_UserLeft(ByVal sender As Object, ByVal e As TechLifeForum.UserLeftEventArgs) Handles osuirc.UserLeft
        Online -= 1
        onlineusers.Items.Remove(e.User)
    End Sub

    Private Sub StartFade_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartFade.Tick
        If Not Me.Opacity >= 1 Then
            Me.Opacity += 0.1
            Me.Location = New Point(Me.Location.X - 20, Me.Location.Y)
        End If
    End Sub

    Private Sub MTitle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTitle.Tick
        If Online < 0 Then Online = 0
        'Me.Text = String.Format("osu!rc [alpha] | {0} ({1} online in {2})", osuirc.Nick, Online, channame.Text)
        Me.Text = String.Format("osu!rc [alpha] | {0}", osuirc.Nick)
    End Sub
    Private Sub MenuButton_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuButton.MouseEnter
        MenuButton.Image = My.Resources.opt_hover
    End Sub

    Private Sub MenuButton_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuButton.MouseLeave
        MenuButton.Image = My.Resources.opt_normal
    End Sub

    Private Sub MenuButton_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MenuButton.MouseDown
        MenuButton.Image = My.Resources.opt_press
    End Sub

    Private Sub MenuButton_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MenuButton.MouseUp
        Options.ShowDialog()
        MenuButton.Image = My.Resources.opt_normal
    End Sub

    Private Sub Main_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize, MyBase.ClientSizeChanged
        osuchat.ScrollToCaret()
    End Sub

    Private Sub Main_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub Main_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        HLFlash.Stop()
        If HighlightIcon = True Then
            Me.Icon = My.Resources.app
            HighlightIcon = False
        End If
    End Sub

    Dim FlTimes As Integer = 0
    Private Sub HLFlash_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HLFlash.Tick
        FlTimes += 1
        Select Case FlTimes
            Case 1, 3, 5, 7, 9
                Me.Icon = My.Resources.app_highlight
            Case 2, 4, 6, 8
                Me.Icon = My.Resources.app
            Case 10
                FlTimes = 0
                HLFlash.Stop()
        End Select
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        IsOsu = True
        IsLobby = False
        osuchat.Text = channelosu
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        IsLobby = True
        IsOsu = False
        osuchat.Text = channellobby
    End Sub
End Class