<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdUserType = New System.Windows.Forms.ComboBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.btExit = New System.Windows.Forms.Button
        Me.btSignIn = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.GroupBox1.BackgroundImage = Global.TutionApplication.My.Resources.Resources.wood02
        Me.GroupBox1.Controls.Add(Me.cmdUserType)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.btExit)
        Me.GroupBox1.Controls.Add(Me.btSignIn)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Kristen ITC", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(322, 118)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 287)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Login "
        '
        'cmdUserType
        '
        Me.cmdUserType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmdUserType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmdUserType.FormattingEnabled = True
        Me.cmdUserType.Items.AddRange(New Object() {"Admin", "Common User"})
        Me.cmdUserType.Location = New System.Drawing.Point(113, 110)
        Me.cmdUserType.Name = "cmdUserType"
        Me.cmdUserType.Size = New System.Drawing.Size(125, 26)
        Me.cmdUserType.TabIndex = 2
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(113, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(125, 25)
        Me.txtPassword.TabIndex = 1
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(113, 34)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(125, 25)
        Me.txtUserName.TabIndex = 0
        '
        'btExit
        '
        Me.btExit.Location = New System.Drawing.Point(185, 168)
        Me.btExit.Name = "btExit"
        Me.btExit.Size = New System.Drawing.Size(75, 23)
        Me.btExit.TabIndex = 4
        Me.btExit.Text = "Exit"
        Me.btExit.UseVisualStyleBackColor = True
        '
        'btSignIn
        '
        Me.btSignIn.Location = New System.Drawing.Point(71, 168)
        Me.btSignIn.Name = "btSignIn"
        Me.btSignIn.Size = New System.Drawing.Size(75, 23)
        Me.btSignIn.TabIndex = 3
        Me.btSignIn.Text = "Sign In"
        Me.btSignIn.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(28, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 18)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "UserType"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(28, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(28, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Rockwell", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(360, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(240, 39)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "I.T.INSTITUTE"
        '
        'Timer1
        '
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BackgroundImage = Global.TutionApplication.My.Resources.Resources._1bac2a49495a8db63bc81310a9f78d08
        Me.ClientSize = New System.Drawing.Size(1221, 559)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.Name = "frmLogin"
        Me.Text = "Login Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdUserType As System.Windows.Forms.ComboBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents btExit As System.Windows.Forms.Button
    Friend WithEvents btSignIn As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
