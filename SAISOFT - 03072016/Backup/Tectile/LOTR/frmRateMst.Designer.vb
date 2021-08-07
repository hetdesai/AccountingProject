<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRateMst
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtAcname = New System.Windows.Forms.TextBox
        Me.txtPgroup = New System.Windows.Forms.TextBox
        Me.txtMst = New System.Windows.Forms.TextBox
        Me.txtProcess = New System.Windows.Forms.TextBox
        Me.txtStyle = New System.Windows.Forms.TextBox
        Me.txtItem = New System.Windows.Forms.TextBox
        Me.txtRate = New System.Windows.Forms.TextBox
        Me.butDelete = New System.Windows.Forms.Button
        Me.ButEdit = New System.Windows.Forms.Button
        Me.butExit = New System.Windows.Forms.Button
        Me.butSave = New System.Windows.Forms.Button
        Me.butAdd = New System.Windows.Forms.Button
        Me.dg1 = New System.Windows.Forms.DataGridView
        Me.Liprocess = New System.Windows.Forms.ListBox
        Me.Listyle = New System.Windows.Forms.ListBox
        Me.Liitem = New System.Windows.Forms.ListBox
        Me.dgacm = New System.Windows.Forms.DataGridView
        Me.TextBox1 = New System.Windows.Forms.TextBox
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgacm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(717, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ACNAME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(717, 98)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Party Group"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(717, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Mst"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(717, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Process"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(717, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Style"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(717, 244)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(27, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Item"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(717, 282)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Rate"
        '
        'txtAcname
        '
        Me.txtAcname.Location = New System.Drawing.Point(796, 60)
        Me.txtAcname.Name = "txtAcname"
        Me.txtAcname.Size = New System.Drawing.Size(385, 20)
        Me.txtAcname.TabIndex = 7
        '
        'txtPgroup
        '
        Me.txtPgroup.Location = New System.Drawing.Point(796, 95)
        Me.txtPgroup.Name = "txtPgroup"
        Me.txtPgroup.ReadOnly = True
        Me.txtPgroup.Size = New System.Drawing.Size(385, 20)
        Me.txtPgroup.TabIndex = 8
        '
        'txtMst
        '
        Me.txtMst.Location = New System.Drawing.Point(796, 126)
        Me.txtMst.Name = "txtMst"
        Me.txtMst.ReadOnly = True
        Me.txtMst.Size = New System.Drawing.Size(385, 20)
        Me.txtMst.TabIndex = 9
        '
        'txtProcess
        '
        Me.txtProcess.Location = New System.Drawing.Point(796, 165)
        Me.txtProcess.Name = "txtProcess"
        Me.txtProcess.Size = New System.Drawing.Size(385, 20)
        Me.txtProcess.TabIndex = 10
        '
        'txtStyle
        '
        Me.txtStyle.Location = New System.Drawing.Point(796, 200)
        Me.txtStyle.Name = "txtStyle"
        Me.txtStyle.Size = New System.Drawing.Size(385, 20)
        Me.txtStyle.TabIndex = 11
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(796, 241)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.Size = New System.Drawing.Size(385, 20)
        Me.txtItem.TabIndex = 12
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(796, 275)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(122, 20)
        Me.txtRate.TabIndex = 13
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'butDelete
        '
        Me.butDelete.Location = New System.Drawing.Point(649, 542)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(75, 37)
        Me.butDelete.TabIndex = 167
        Me.butDelete.Text = "&DELETE"
        Me.butDelete.UseVisualStyleBackColor = True
        '
        'ButEdit
        '
        Me.ButEdit.Location = New System.Drawing.Point(561, 542)
        Me.ButEdit.Name = "ButEdit"
        Me.ButEdit.Size = New System.Drawing.Size(75, 37)
        Me.ButEdit.TabIndex = 166
        Me.ButEdit.Text = "&EDIT"
        Me.ButEdit.UseVisualStyleBackColor = True
        '
        'butExit
        '
        Me.butExit.Location = New System.Drawing.Point(831, 542)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(75, 37)
        Me.butExit.TabIndex = 164
        Me.butExit.Text = "EXIT"
        Me.butExit.UseVisualStyleBackColor = True
        '
        'butSave
        '
        Me.butSave.Location = New System.Drawing.Point(741, 542)
        Me.butSave.Name = "butSave"
        Me.butSave.Size = New System.Drawing.Size(75, 37)
        Me.butSave.TabIndex = 163
        Me.butSave.Text = "&SAVE"
        Me.butSave.UseVisualStyleBackColor = True
        '
        'butAdd
        '
        Me.butAdd.Location = New System.Drawing.Point(474, 542)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(75, 37)
        Me.butAdd.TabIndex = 162
        Me.butAdd.Text = "&ADD"
        Me.butAdd.UseVisualStyleBackColor = True
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Location = New System.Drawing.Point(7, 60)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.Size = New System.Drawing.Size(671, 451)
        Me.dg1.TabIndex = 168
        '
        'Liprocess
        '
        Me.Liprocess.FormattingEnabled = True
        Me.Liprocess.Location = New System.Drawing.Point(903, 363)
        Me.Liprocess.Name = "Liprocess"
        Me.Liprocess.Size = New System.Drawing.Size(120, 95)
        Me.Liprocess.TabIndex = 169
        Me.Liprocess.Visible = False
        '
        'Listyle
        '
        Me.Listyle.FormattingEnabled = True
        Me.Listyle.Location = New System.Drawing.Point(876, 396)
        Me.Listyle.Name = "Listyle"
        Me.Listyle.Size = New System.Drawing.Size(120, 95)
        Me.Listyle.TabIndex = 170
        Me.Listyle.Visible = False
        '
        'Liitem
        '
        Me.Liitem.FormattingEnabled = True
        Me.Liitem.Location = New System.Drawing.Point(922, 484)
        Me.Liitem.Name = "Liitem"
        Me.Liitem.Size = New System.Drawing.Size(120, 95)
        Me.Liitem.TabIndex = 171
        Me.Liitem.Visible = False
        '
        'dgacm
        '
        Me.dgacm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgacm.Location = New System.Drawing.Point(370, 95)
        Me.dgacm.Name = "dgacm"
        Me.dgacm.Size = New System.Drawing.Size(865, 320)
        Me.dgacm.TabIndex = 172
        Me.dgacm.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(796, 34)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(385, 20)
        Me.TextBox1.TabIndex = 173
        '
        'frmRateMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 591)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.dgacm)
        Me.Controls.Add(Me.Liitem)
        Me.Controls.Add(Me.Listyle)
        Me.Controls.Add(Me.Liprocess)
        Me.Controls.Add(Me.dg1)
        Me.Controls.Add(Me.butDelete)
        Me.Controls.Add(Me.ButEdit)
        Me.Controls.Add(Me.butExit)
        Me.Controls.Add(Me.butSave)
        Me.Controls.Add(Me.butAdd)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.txtItem)
        Me.Controls.Add(Me.txtStyle)
        Me.Controls.Add(Me.txtProcess)
        Me.Controls.Add(Me.txtMst)
        Me.Controls.Add(Me.txtPgroup)
        Me.Controls.Add(Me.txtAcname)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmRateMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmRateMst"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgacm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAcname As System.Windows.Forms.TextBox
    Friend WithEvents txtPgroup As System.Windows.Forms.TextBox
    Friend WithEvents txtMst As System.Windows.Forms.TextBox
    Friend WithEvents txtProcess As System.Windows.Forms.TextBox
    Friend WithEvents txtStyle As System.Windows.Forms.TextBox
    Friend WithEvents txtItem As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents butDelete As System.Windows.Forms.Button
    Friend WithEvents ButEdit As System.Windows.Forms.Button
    Friend WithEvents butExit As System.Windows.Forms.Button
    Friend WithEvents butSave As System.Windows.Forms.Button
    Friend WithEvents butAdd As System.Windows.Forms.Button
    Friend WithEvents dg1 As System.Windows.Forms.DataGridView
    Friend WithEvents Liprocess As System.Windows.Forms.ListBox
    Friend WithEvents Listyle As System.Windows.Forms.ListBox
    Friend WithEvents Liitem As System.Windows.Forms.ListBox
    Friend WithEvents dgacm As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
