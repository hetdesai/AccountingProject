<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStateMaster
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.butExit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.butEdit = New System.Windows.Forms.Button()
        Me.butFind = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.txtScode = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.butSave = New System.Windows.Forms.Button()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dateyl1 = New System.Windows.Forms.Label()
        Me.companyname1 = New System.Windows.Forms.Label()
        Me.dateyf1 = New System.Windows.Forms.Label()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "labelfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "labelcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label1.Font = Global.Tectile.My.MySettings.Default.labelfont
        Me.Label1.ForeColor = Global.Tectile.My.MySettings.Default.labelcolor
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "STCode"
        '
        'butExit
        '
        Me.butExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.butExit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butExit.ForeColor = System.Drawing.Color.White
        Me.butExit.Location = New System.Drawing.Point(462, 446)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(78, 27)
        Me.butExit.TabIndex = 47
        Me.butExit.Text = "EXIT"
        Me.butExit.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "labelfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "labelcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label3.Font = Global.Tectile.My.MySettings.Default.labelfont
        Me.Label3.ForeColor = Global.Tectile.My.MySettings.Default.labelcolor
        Me.Label3.Location = New System.Drawing.Point(9, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "STName"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(129, 241)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 20)
        Me.Label2.TabIndex = 20
        '
        'Timer1
        '
        '
        'butEdit
        '
        Me.butEdit.BackColor = System.Drawing.Color.Lime
        Me.butEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butEdit.ForeColor = System.Drawing.Color.White
        Me.butEdit.Location = New System.Drawing.Point(278, 446)
        Me.butEdit.Name = "butEdit"
        Me.butEdit.Size = New System.Drawing.Size(78, 27)
        Me.butEdit.TabIndex = 48
        Me.butEdit.Text = "&EDIT"
        Me.butEdit.UseVisualStyleBackColor = False
        '
        'butFind
        '
        Me.butFind.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.butFind.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butFind.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butFind.ForeColor = System.Drawing.Color.White
        Me.butFind.Location = New System.Drawing.Point(370, 446)
        Me.butFind.Name = "butFind"
        Me.butFind.Size = New System.Drawing.Size(78, 27)
        Me.butFind.TabIndex = 49
        Me.butFind.Text = "&FIND"
        Me.butFind.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "labelfont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "labelcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label5.Font = Global.Tectile.My.MySettings.Default.labelfont
        Me.Label5.ForeColor = Global.Tectile.My.MySettings.Default.labelcolor
        Me.Label5.Location = New System.Drawing.Point(253, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 17
        '
        'butAdd
        '
        Me.butAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.butAdd.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butAdd.ForeColor = System.Drawing.Color.White
        Me.butAdd.Location = New System.Drawing.Point(186, 446)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(78, 27)
        Me.butAdd.TabIndex = 46
        Me.butAdd.Text = "&ADD"
        Me.butAdd.UseVisualStyleBackColor = False
        '
        'txtScode
        '
        Me.txtScode.Location = New System.Drawing.Point(84, 14)
        Me.txtScode.Name = "txtScode"
        Me.txtScode.ReadOnly = True
        Me.txtScode.Size = New System.Drawing.Size(100, 20)
        Me.txtScode.TabIndex = 19
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = Global.Tectile.My.MySettings.Default.contbackColor
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.butSave)
        Me.GroupBox1.Controls.Add(Me.txtScode)
        Me.GroupBox1.Controls.Add(Me.txtState)
        Me.GroupBox1.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "contbackColor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(341, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(377, 345)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'butSave
        '
        Me.butSave.BackColor = System.Drawing.Color.DarkRed
        Me.butSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.butSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butSave.ForeColor = System.Drawing.Color.White
        Me.butSave.Location = New System.Drawing.Point(143, 102)
        Me.butSave.Name = "butSave"
        Me.butSave.Size = New System.Drawing.Size(86, 40)
        Me.butSave.TabIndex = 14
        Me.butSave.Text = "SAVE"
        Me.butSave.UseVisualStyleBackColor = False
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(84, 47)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(227, 20)
        Me.txtState.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("Font", Global.Tectile.My.MySettings.Default, "titlefont", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.DataBindings.Add(New System.Windows.Forms.Binding("ForeColor", Global.Tectile.My.MySettings.Default, "Titlecolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Label4.Font = Global.Tectile.My.MySettings.Default.titlefont
        Me.Label4.ForeColor = Global.Tectile.My.MySettings.Default.Titlecolor
        Me.Label4.Location = New System.Drawing.Point(310, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 24)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "State Master"
        '
        'Panel1
        '
        Me.Panel1.BackColor = Global.Tectile.My.MySettings.Default.Comcolor
        Me.Panel1.Controls.Add(Me.dateyl1)
        Me.Panel1.Controls.Add(Me.companyname1)
        Me.Panel1.Controls.Add(Me.dateyf1)
        Me.Panel1.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "Comcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Panel1.Location = New System.Drawing.Point(1, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(724, 28)
        Me.Panel1.TabIndex = 70
        '
        'dateyl1
        '
        Me.dateyl1.AutoSize = True
        Me.dateyl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateyl1.ForeColor = System.Drawing.Color.White
        Me.dateyl1.Location = New System.Drawing.Point(643, 6)
        Me.dateyl1.Name = "dateyl1"
        Me.dateyl1.Size = New System.Drawing.Size(52, 13)
        Me.dateyl1.TabIndex = 2
        Me.dateyl1.Text = "Label10"
        '
        'companyname1
        '
        Me.companyname1.AutoSize = True
        Me.companyname1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.companyname1.ForeColor = System.Drawing.Color.White
        Me.companyname1.Location = New System.Drawing.Point(340, 6)
        Me.companyname1.Name = "companyname1"
        Me.companyname1.Size = New System.Drawing.Size(45, 13)
        Me.companyname1.TabIndex = 1
        Me.companyname1.Text = "Label9"
        '
        'dateyf1
        '
        Me.dateyf1.AutoSize = True
        Me.dateyf1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dateyf1.ForeColor = System.Drawing.Color.White
        Me.dateyf1.Location = New System.Drawing.Point(3, 7)
        Me.dateyf1.Name = "dateyf1"
        Me.dateyf1.Size = New System.Drawing.Size(45, 13)
        Me.dateyf1.TabIndex = 0
        Me.dateyf1.Text = "Label8"
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.AllowUserToResizeColumns = False
        Me.dg1.AllowUserToResizeRows = False
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Location = New System.Drawing.Point(16, 86)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dg1.Size = New System.Drawing.Size(319, 345)
        Me.dg1.TabIndex = 71
        '
        'frmStateMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.Tectile.My.MySettings.Default.Masterbkcolor
        Me.ClientSize = New System.Drawing.Size(726, 487)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butEdit)
        Me.Controls.Add(Me.butFind)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label4)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "Masterbkcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.KeyPreview = True
        Me.Name = "frmStateMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "State Master"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents butEdit As System.Windows.Forms.Button
    Friend WithEvents butFind As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents txtScode As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butSave As System.Windows.Forms.Button
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dateyl1 As System.Windows.Forms.Label
    Friend WithEvents companyname1 As System.Windows.Forms.Label
    Friend WithEvents dateyf1 As System.Windows.Forms.Label
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
End Class
