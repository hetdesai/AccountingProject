<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen1))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ApplicationTitle = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.MainLayoutPanel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 195)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(179, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Developed by Het Desai"
        '
        'MainLayoutPanel
        '
        Me.MainLayoutPanel.BackColor = System.Drawing.Color.Black
        Me.MainLayoutPanel.BackgroundImage = Global.TutionApplication.My.Resources.Resources.tutionlogo
        Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.MainLayoutPanel.ColumnCount = 2
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 432.0!))
        Me.MainLayoutPanel.Controls.Add(Me.Label1, 1, 1)
        Me.MainLayoutPanel.Controls.Add(Me.Label7, 1, 2)
        Me.MainLayoutPanel.Controls.Add(Me.ApplicationTitle, 0, 0)
        Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.MainLayoutPanel.Name = "MainLayoutPanel"
        Me.MainLayoutPanel.RowCount = 3
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 230.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.MainLayoutPanel.Size = New System.Drawing.Size(675, 428)
        Me.MainLayoutPanel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(246, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Developed by Het Desai"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(246, 254)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(237, 24)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Contact No : 9925122240"
        '
        'ApplicationTitle
        '
        Me.ApplicationTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
        Me.ApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplicationTitle.ForeColor = System.Drawing.Color.White
        Me.ApplicationTitle.Location = New System.Drawing.Point(3, 98)
        Me.ApplicationTitle.Name = "ApplicationTitle"
        Me.ApplicationTitle.Size = New System.Drawing.Size(237, 34)
        Me.ApplicationTitle.TabIndex = 0
        Me.ApplicationTitle.Text = "Application Title"
        Me.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackgroundImage = CType(resources.GetObject("TableLayoutPanel1.BackgroundImage"), System.Drawing.Image)
        Me.TableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 100)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 1)
        Me.TableLayoutPanel2.ForeColor = System.Drawing.Color.White
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(246, 31)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(94, 57)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(241, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Version {0}.{1:00}"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(241, 29)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Label4"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(237, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Application Title"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'SplashScreen1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 428)
        Me.ControlBox = False
        Me.Controls.Add(Me.MainLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.MainLayoutPanel.ResumeLayout(False)
        Me.MainLayoutPanel.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
