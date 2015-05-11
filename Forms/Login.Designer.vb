<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LogForm = New System.Windows.Forms.PictureBox()
        Me.log_name = New ZBobb.AlphaBlendTextBox()
        Me.log_pas = New ZBobb.AlphaBlendTextBox()
        Me.LogBtn = New System.Windows.Forms.Button()
        Me.StartFade = New System.Windows.Forms.Timer(Me.components)
        Me.EndFade = New System.Windows.Forms.Timer(Me.components)
        Me.Autolog = New System.Windows.Forms.CheckBox()
        Me.AutoSave = New System.Windows.Forms.CheckBox()
        Me.Thr = New System.Windows.Forms.Label()
        CType(Me.LogForm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LogForm
        '
        Me.LogForm.Image = Global.flan_osurc.My.Resources.Resources.login
        Me.LogForm.Location = New System.Drawing.Point(0, 0)
        Me.LogForm.Name = "LogForm"
        Me.LogForm.Size = New System.Drawing.Size(600, 267)
        Me.LogForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LogForm.TabIndex = 0
        Me.LogForm.TabStop = False
        '
        'log_name
        '
        Me.log_name.BackAlpha = 50
        Me.log_name.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.log_name.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.log_name.ForeColor = System.Drawing.Color.White
        Me.log_name.Location = New System.Drawing.Point(17, 128)
        Me.log_name.MaxLength = 20
        Me.log_name.Name = "log_name"
        Me.log_name.Size = New System.Drawing.Size(207, 13)
        Me.log_name.TabIndex = 1
        Me.log_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'log_pas
        '
        Me.log_pas.BackAlpha = 50
        Me.log_pas.BackColor = System.Drawing.Color.FromArgb(CType(CType(57, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(37, Byte), Integer))
        Me.log_pas.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.log_pas.ForeColor = System.Drawing.Color.White
        Me.log_pas.Location = New System.Drawing.Point(249, 128)
        Me.log_pas.MaxLength = 20
        Me.log_pas.Name = "log_pas"
        Me.log_pas.Size = New System.Drawing.Size(207, 13)
        Me.log_pas.TabIndex = 2
        Me.log_pas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.log_pas.UseSystemPasswordChar = True
        '
        'LogBtn
        '
        Me.LogBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.LogBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LogBtn.ForeColor = System.Drawing.Color.White
        Me.LogBtn.Location = New System.Drawing.Point(481, 128)
        Me.LogBtn.Name = "LogBtn"
        Me.LogBtn.Size = New System.Drawing.Size(100, 26)
        Me.LogBtn.TabIndex = 1
        Me.LogBtn.Text = "Log in!"
        Me.LogBtn.UseVisualStyleBackColor = False
        '
        'StartFade
        '
        Me.StartFade.Enabled = True
        Me.StartFade.Interval = 10
        '
        'EndFade
        '
        Me.EndFade.Interval = 10
        '
        'Autolog
        '
        Me.Autolog.AutoSize = True
        Me.Autolog.BackColor = System.Drawing.Color.Transparent
        Me.Autolog.ForeColor = System.Drawing.Color.White
        Me.Autolog.Location = New System.Drawing.Point(446, 22)
        Me.Autolog.Name = "Autolog"
        Me.Autolog.Size = New System.Drawing.Size(125, 17)
        Me.Autolog.TabIndex = 4
        Me.Autolog.Text = "Always auto connect"
        Me.Autolog.UseVisualStyleBackColor = False
        '
        'AutoSave
        '
        Me.AutoSave.AutoSize = True
        Me.AutoSave.BackColor = System.Drawing.Color.Transparent
        Me.AutoSave.Checked = True
        Me.AutoSave.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AutoSave.ForeColor = System.Drawing.Color.White
        Me.AutoSave.Location = New System.Drawing.Point(446, 43)
        Me.AutoSave.Name = "AutoSave"
        Me.AutoSave.Size = New System.Drawing.Size(100, 17)
        Me.AutoSave.TabIndex = 5
        Me.AutoSave.Text = "Save login data"
        Me.AutoSave.UseVisualStyleBackColor = False
        '
        'Thr
        '
        Me.Thr.BackColor = System.Drawing.Color.Transparent
        Me.Thr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Thr.Location = New System.Drawing.Point(562, 229)
        Me.Thr.Name = "Thr"
        Me.Thr.Size = New System.Drawing.Size(38, 38)
        Me.Thr.TabIndex = 6
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 267)
        Me.Controls.Add(Me.Thr)
        Me.Controls.Add(Me.AutoSave)
        Me.Controls.Add(Me.Autolog)
        Me.Controls.Add(Me.LogBtn)
        Me.Controls.Add(Me.log_pas)
        Me.Controls.Add(Me.log_name)
        Me.Controls.Add(Me.LogForm)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Welcome to osu!rc"
        CType(Me.LogForm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogForm As System.Windows.Forms.PictureBox
    Friend WithEvents log_name As ZBobb.AlphaBlendTextBox
    Friend WithEvents log_pas As ZBobb.AlphaBlendTextBox
    Friend WithEvents LogBtn As System.Windows.Forms.Button
    Friend WithEvents StartFade As System.Windows.Forms.Timer
    Friend WithEvents EndFade As System.Windows.Forms.Timer
    Friend WithEvents Autolog As System.Windows.Forms.CheckBox
    Friend WithEvents AutoSave As System.Windows.Forms.CheckBox
    Friend WithEvents Thr As System.Windows.Forms.Label
End Class
