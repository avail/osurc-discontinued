Public Class Popup

    Dim f As Integer
    Dim c As Integer

    Private Sub MainPopup(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Main.osuirc.Nick
        Me.Opacity = 0
        Me.Location = New Point(Screen.PrimaryScreen.Bounds.Width - Me.Width - 5, Screen.PrimaryScreen.Bounds.Height - 100)
        Label1.BackColor = Color.Transparent
        Label2.BackColor = Color.Transparent
        Label3.BackColor = Panel1.BackColor
        Label1.Parent = PictureBox1
        Label2.Parent = PictureBox1
        Label1.Font = AllerFont.GetInstance(12, FontStyle.Regular)
        Label2.Font = AllerFont.GetInstance(9, FontStyle.Regular)
        Label3.Font = AllerFont.GetInstance(20, FontStyle.Regular)
    End Sub

    Private Sub Pop_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Pop.Tick
        Main.BringToFront()
        If Not Me.Opacity >= 1 Then
            Me.Opacity += 0.06
        End If
        f += 1
        Select Case f
            Case 1 To 2
                Panel1.BackColor = Color.FromArgb(96, 36, 63)
                Label3.BackColor = Panel1.BackColor
            Case 11 To 20
                Panel1.BackColor = Color.MediumVioletRed
                Label3.BackColor = Panel1.BackColor
            Case 21
                f = 0
                c += 1
                If c = 5 Then
                    Panel1.BackColor = Color.FromArgb(96, 36, 63)
                    Label3.BackColor = Panel1.BackColor
                    Pop.Stop()
                    Tart.Start()
                End If
        End Select
    End Sub

    Private Sub Tart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tart.Tick
        Tart.Interval = 10
        If Not Me.Opacity = 0 Then
            Me.Opacity -= 0.05
        Else
            Me.Close()
            GC.Collect()
        End If
    End Sub
End Class