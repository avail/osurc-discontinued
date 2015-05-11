<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Crash
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
        Me.rcerror = New System.Windows.Forms.PictureBox()
        Me.ErrCode = New System.Windows.Forms.TextBox()
        Me.BtnCopy = New System.Windows.Forms.Button()
        Me.BtnContinue = New System.Windows.Forms.Button()
        Me.BtnTerminate = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.rcerror, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rcerror
        '
        Me.rcerror.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.rcerror.Image = Global.flan_osurc.My.Resources.Resources._error
        Me.rcerror.Location = New System.Drawing.Point(260, 9)
        Me.rcerror.Name = "rcerror"
        Me.rcerror.Size = New System.Drawing.Size(64, 64)
        Me.rcerror.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.rcerror.TabIndex = 0
        Me.rcerror.TabStop = False
        '
        'ErrCode
        '
        Me.ErrCode.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ErrCode.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ErrCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ErrCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ErrCode.Location = New System.Drawing.Point(12, 84)
        Me.ErrCode.Multiline = True
        Me.ErrCode.Name = "ErrCode"
        Me.ErrCode.ReadOnly = True
        Me.ErrCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ErrCode.Size = New System.Drawing.Size(561, 244)
        Me.ErrCode.TabIndex = 2
        '
        'BtnCopy
        '
        Me.BtnCopy.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BtnCopy.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.BtnCopy.FlatAppearance.BorderSize = 0
        Me.BtnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCopy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnCopy.Location = New System.Drawing.Point(12, 334)
        Me.BtnCopy.Name = "BtnCopy"
        Me.BtnCopy.Size = New System.Drawing.Size(142, 30)
        Me.BtnCopy.TabIndex = 1
        Me.BtnCopy.Text = "Copy to clipboard"
        Me.BtnCopy.UseVisualStyleBackColor = False
        '
        'BtnContinue
        '
        Me.BtnContinue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnContinue.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.BtnContinue.FlatAppearance.BorderSize = 0
        Me.BtnContinue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnContinue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnContinue.Location = New System.Drawing.Point(357, 334)
        Me.BtnContinue.Name = "BtnContinue"
        Me.BtnContinue.Size = New System.Drawing.Size(105, 30)
        Me.BtnContinue.TabIndex = 3
        Me.BtnContinue.Text = "Ignore"
        Me.BtnContinue.UseVisualStyleBackColor = False
        '
        'BtnTerminate
        '
        Me.BtnTerminate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnTerminate.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.BtnTerminate.FlatAppearance.BorderSize = 0
        Me.BtnTerminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTerminate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnTerminate.Location = New System.Drawing.Point(468, 334)
        Me.BtnTerminate.Name = "BtnTerminate"
        Me.BtnTerminate.Size = New System.Drawing.Size(105, 30)
        Me.BtnTerminate.TabIndex = 4
        Me.BtnTerminate.Text = "Exit"
        Me.BtnTerminate.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Crash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.BackgroundImage = Global.flan_osurc.My.Resources.Resources.chans
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(584, 372)
        Me.Controls.Add(Me.BtnTerminate)
        Me.Controls.Add(Me.BtnContinue)
        Me.Controls.Add(Me.BtnCopy)
        Me.Controls.Add(Me.ErrCode)
        Me.Controls.Add(Me.rcerror)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Crash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "osu!rc has encountered an error!"
        CType(Me.rcerror, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rcerror As System.Windows.Forms.PictureBox
    Friend WithEvents ErrCode As System.Windows.Forms.TextBox
    Friend WithEvents BtnCopy As System.Windows.Forms.Button
    Friend WithEvents BtnContinue As System.Windows.Forms.Button
    Friend WithEvents BtnTerminate As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
