<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.Motd = New System.Windows.Forms.Timer(Me.components)
        Me.Names = New System.Windows.Forms.Timer(Me.components)
        Me.osuchat = New System.Windows.Forms.RichTextBox()
        Me.user = New System.Windows.Forms.TextBox()
        Me.onlineusers = New System.Windows.Forms.ListBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.typename = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PrevLines = New System.Windows.Forms.ListBox()
        Me.StartFade = New System.Windows.Forms.Timer(Me.components)
        Me.MTitle = New System.Windows.Forms.Timer(Me.components)
        Me.MainMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.channame = New System.Windows.Forms.Label()
        Me.Version = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MenuButton = New System.Windows.Forms.PictureBox()
        Me.HLFlash = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.MenuButton, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Motd
        '
        Me.Motd.Enabled = True
        Me.Motd.Interval = 10
        '
        'Names
        '
        Me.Names.Interval = 10
        '
        'osuchat
        '
        Me.osuchat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.osuchat.BackColor = System.Drawing.Color.FromArgb(CType(CType(96, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.osuchat.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.osuchat.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.osuchat.ForeColor = System.Drawing.Color.White
        Me.osuchat.HideSelection = False
        Me.osuchat.Location = New System.Drawing.Point(143, 0)
        Me.osuchat.Name = "osuchat"
        Me.osuchat.ReadOnly = True
        Me.osuchat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.osuchat.Size = New System.Drawing.Size(888, 520)
        Me.osuchat.TabIndex = 6
        Me.osuchat.TabStop = False
        Me.osuchat.Text = ""
        '
        'user
        '
        Me.user.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.user.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.user.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.user.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.user.Font = New System.Drawing.Font("Trebuchet MS", 10.0!)
        Me.user.ForeColor = System.Drawing.Color.White
        Me.user.Location = New System.Drawing.Point(148, 526)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(848, 16)
        Me.user.TabIndex = 8
        '
        'onlineusers
        '
        Me.onlineusers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.onlineusers.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(54, Byte), Integer))
        Me.onlineusers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.onlineusers.ForeColor = System.Drawing.Color.White
        Me.onlineusers.FormattingEnabled = True
        Me.onlineusers.Location = New System.Drawing.Point(1020, -1)
        Me.onlineusers.Name = "onlineusers"
        Me.onlineusers.Size = New System.Drawing.Size(10, 507)
        Me.onlineusers.Sorted = True
        Me.onlineusers.TabIndex = 9
        Me.onlineusers.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(86, Byte), Integer), CType(CType(36, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.typename)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(0, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(143, 511)
        Me.Panel1.TabIndex = 10
        '
        'typename
        '
        Me.typename.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.typename.AutoSize = True
        Me.typename.BackColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(43, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.typename.ForeColor = System.Drawing.Color.White
        Me.typename.Location = New System.Drawing.Point(97, 478)
        Me.typename.Name = "typename"
        Me.typename.Size = New System.Drawing.Size(39, 13)
        Me.typename.TabIndex = 3
        Me.typename.Text = "Label1"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(2, 1)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(139, 24)
        Me.Button1.TabIndex = 1
        Me.Button1.TabStop = False
        Me.Button1.Text = "#osu"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PrevLines)
        Me.Panel2.Location = New System.Drawing.Point(0, 472)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 106)
        Me.Panel2.TabIndex = 4
        '
        'PrevLines
        '
        Me.PrevLines.FormattingEnabled = True
        Me.PrevLines.Location = New System.Drawing.Point(0, 24)
        Me.PrevLines.Name = "PrevLines"
        Me.PrevLines.Size = New System.Drawing.Size(10, 4)
        Me.PrevLines.TabIndex = 12
        Me.PrevLines.Visible = False
        '
        'StartFade
        '
        Me.StartFade.Enabled = True
        Me.StartFade.Interval = 10
        '
        'MTitle
        '
        '
        'MainMenu
        '
        Me.MainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripSeparator, Me.OptionsToolStripMenuItem, Me.AboutToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.MainMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(50, 20)
        Me.MainMenu.Text = "&Menu"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(132, 6)
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.OptionsToolStripMenuItem.Text = "Preferences"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.BackColor = System.Drawing.SystemColors.Control
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.ExitToolStripMenuItem1.Text = "E&xit"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(143, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'channame
        '
        Me.channame.AutoSize = True
        Me.channame.Font = New System.Drawing.Font("Trebuchet MS", 10.0!, System.Drawing.FontStyle.Bold)
        Me.channame.ForeColor = System.Drawing.Color.White
        Me.channame.Location = New System.Drawing.Point(43, 14)
        Me.channame.Name = "channame"
        Me.channame.Size = New System.Drawing.Size(38, 18)
        Me.channame.TabIndex = 2
        Me.channame.Text = "#osu"
        '
        'Version
        '
        Me.Version.AutoSize = True
        Me.Version.BackColor = System.Drawing.Color.Transparent
        Me.Version.ForeColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.Version.Location = New System.Drawing.Point(89, 30)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(44, 13)
        Me.Version.TabIndex = 4
        Me.Version.Text = "client r6"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.MenuButton)
        Me.Panel3.Location = New System.Drawing.Point(143, 520)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(889, 28)
        Me.Panel3.TabIndex = 11
        '
        'MenuButton
        '
        Me.MenuButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MenuButton.Image = CType(resources.GetObject("MenuButton.Image"), System.Drawing.Image)
        Me.MenuButton.Location = New System.Drawing.Point(859, 0)
        Me.MenuButton.Name = "MenuButton"
        Me.MenuButton.Size = New System.Drawing.Size(28, 28)
        Me.MenuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.MenuButton.TabIndex = 12
        Me.MenuButton.TabStop = False
        '
        'HLFlash
        '
        Me.HLFlash.Interval = 250
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(2, 26)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(139, 24)
        Me.Button2.TabIndex = 5
        Me.Button2.TabStop = False
        Me.Button2.Text = "#lobby"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(73, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1030, 548)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.channame)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.user)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.onlineusers)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.osuchat)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(800, 470)
        Me.Name = "Main"
        Me.Opacity = 0.0R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "osu!rc [alpha]"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.MenuButton, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Motd As System.Windows.Forms.Timer
    Friend WithEvents Names As System.Windows.Forms.Timer
    Friend WithEvents osuchat As System.Windows.Forms.RichTextBox
    Friend WithEvents user As System.Windows.Forms.TextBox
    Friend WithEvents onlineusers As System.Windows.Forms.ListBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StartFade As System.Windows.Forms.Timer
    Friend WithEvents MTitle As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MainMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents channame As System.Windows.Forms.Label
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Version As System.Windows.Forms.Label
    Friend WithEvents typename As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents MenuButton As System.Windows.Forms.PictureBox
    Friend WithEvents PrevLines As System.Windows.Forms.ListBox
    Friend WithEvents HLFlash As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
