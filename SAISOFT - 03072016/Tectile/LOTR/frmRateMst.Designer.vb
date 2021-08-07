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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAcname = New System.Windows.Forms.TextBox()
        Me.txtPgroup = New System.Windows.Forms.TextBox()
        Me.txtMst = New System.Windows.Forms.TextBox()
        Me.txtProcess = New System.Windows.Forms.TextBox()
        Me.txtStyle = New System.Windows.Forms.TextBox()
        Me.txtItem = New System.Windows.Forms.TextBox()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.butDelete = New System.Windows.Forms.Button()
        Me.ButEdit = New System.Windows.Forms.Button()
        Me.butExit = New System.Windows.Forms.Button()
        Me.butSave = New System.Windows.Forms.Button()
        Me.butAdd = New System.Windows.Forms.Button()
        Me.dg1 = New System.Windows.Forms.DataGridView()
        Me.Listyle = New System.Windows.Forms.ListBox()
        Me.Liitem = New System.Windows.Forms.ListBox()
        Me.dgacm = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.listshade = New System.Windows.Forms.ListBox()
        Me.Liprocess = New System.Windows.Forms.ListBox()
        Me.txtShade = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgacm, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.Label7.Location = New System.Drawing.Point(717, 315)
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
        Me.txtRate.Location = New System.Drawing.Point(796, 308)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(122, 20)
        Me.txtRate.TabIndex = 13
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'butDelete
        '
        Me.butDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butDelete.Image = Global.Tectile.My.Resources.Resources.DELETE
        Me.butDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butDelete.Location = New System.Drawing.Point(251, 3)
        Me.butDelete.Name = "butDelete"
        Me.butDelete.Size = New System.Drawing.Size(99, 37)
        Me.butDelete.TabIndex = 167
        Me.butDelete.Text = "&DELETE"
        Me.butDelete.UseVisualStyleBackColor = False
        '
        'ButEdit
        '
        Me.ButEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButEdit.Image = Global.Tectile.My.Resources.Resources.edit
        Me.ButEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButEdit.Location = New System.Drawing.Point(133, 3)
        Me.ButEdit.Name = "ButEdit"
        Me.ButEdit.Size = New System.Drawing.Size(99, 37)
        Me.ButEdit.TabIndex = 166
        Me.ButEdit.Text = "&EDIT"
        Me.ButEdit.UseVisualStyleBackColor = False
        '
        'butExit
        '
        Me.butExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butExit.Image = Global.Tectile.My.Resources.Resources._Exit
        Me.butExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butExit.Location = New System.Drawing.Point(487, 3)
        Me.butExit.Name = "butExit"
        Me.butExit.Size = New System.Drawing.Size(99, 37)
        Me.butExit.TabIndex = 164
        Me.butExit.Text = "EXIT"
        Me.butExit.UseVisualStyleBackColor = False
        '
        'butSave
        '
        Me.butSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butSave.Image = Global.Tectile.My.Resources.Resources.SAVE
        Me.butSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butSave.Location = New System.Drawing.Point(369, 3)
        Me.butSave.Name = "butSave"
        Me.butSave.Size = New System.Drawing.Size(99, 37)
        Me.butSave.TabIndex = 163
        Me.butSave.Text = "&SAVE"
        Me.butSave.UseVisualStyleBackColor = False
        '
        'butAdd
        '
        Me.butAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.butAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.butAdd.Image = Global.Tectile.My.Resources.Resources.ADD
        Me.butAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.butAdd.Location = New System.Drawing.Point(15, 3)
        Me.butAdd.Name = "butAdd"
        Me.butAdd.Size = New System.Drawing.Size(99, 37)
        Me.butAdd.TabIndex = 162
        Me.butAdd.Text = "&ADD"
        Me.butAdd.UseVisualStyleBackColor = False
        '
        'dg1
        '
        Me.dg1.AllowUserToAddRows = False
        Me.dg1.AllowUserToDeleteRows = False
        Me.dg1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dg1.Location = New System.Drawing.Point(1, 30)
        Me.dg1.MultiSelect = False
        Me.dg1.Name = "dg1"
        Me.dg1.ReadOnly = True
        Me.dg1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dg1.RowHeadersVisible = False
        Me.dg1.Size = New System.Drawing.Size(671, 455)
        Me.dg1.TabIndex = 168
        '
        'Listyle
        '
        Me.Listyle.FormattingEnabled = True
        Me.Listyle.Location = New System.Drawing.Point(811, 481)
        Me.Listyle.Name = "Listyle"
        Me.Listyle.Size = New System.Drawing.Size(120, 95)
        Me.Listyle.TabIndex = 170
        Me.Listyle.Visible = False
        '
        'Liitem
        '
        Me.Liitem.FormattingEnabled = True
        Me.Liitem.Location = New System.Drawing.Point(735, 481)
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(717, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 174
        Me.Label8.Text = "Sr No"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(151, Byte), Integer), CType(CType(77, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.Panel1.Controls.Add(Me.butAdd)
        Me.Panel1.Controls.Add(Me.ButEdit)
        Me.Panel1.Controls.Add(Me.butDelete)
        Me.Panel1.Controls.Add(Me.butSave)
        Me.Panel1.Controls.Add(Me.butExit)
        Me.Panel1.Location = New System.Drawing.Point(678, 435)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(593, 46)
        Me.Panel1.TabIndex = 175
        '
        'listshade
        '
        Me.listshade.FormattingEnabled = True
        Me.listshade.Location = New System.Drawing.Point(780, 438)
        Me.listshade.Name = "listshade"
        Me.listshade.Size = New System.Drawing.Size(120, 95)
        Me.listshade.TabIndex = 177
        Me.listshade.Visible = False
        '
        'Liprocess
        '
        Me.Liprocess.FormattingEnabled = True
        Me.Liprocess.Location = New System.Drawing.Point(672, 465)
        Me.Liprocess.Name = "Liprocess"
        Me.Liprocess.Size = New System.Drawing.Size(120, 95)
        Me.Liprocess.TabIndex = 169
        Me.Liprocess.Visible = False
        '
        'txtShade
        '
        Me.txtShade.Location = New System.Drawing.Point(796, 277)
        Me.txtShade.Name = "txtShade"
        Me.txtShade.Size = New System.Drawing.Size(385, 20)
        Me.txtShade.TabIndex = 177
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(717, 280)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 177
        Me.Label9.Text = "Shade"
        '
        'frmRateMst
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Global.Tectile.My.MySettings.Default.tranbkcolor
        Me.ClientSize = New System.Drawing.Size(1276, 537)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.listshade)
        Me.Controls.Add(Me.txtShade)
        Me.Controls.Add(Me.Liprocess)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Liitem)
        Me.Controls.Add(Me.Listyle)
        Me.Controls.Add(Me.dg1)
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
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.dgacm)
        Me.DataBindings.Add(New System.Windows.Forms.Binding("BackColor", Global.Tectile.My.MySettings.Default, "tranbkcolor", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.Name = "frmRateMst"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rate Master"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgacm, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents Listyle As System.Windows.Forms.ListBox
    Friend WithEvents Liitem As System.Windows.Forms.ListBox
    Friend WithEvents dgacm As System.Windows.Forms.DataGridView
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents listshade As System.Windows.Forms.ListBox
    Friend WithEvents Liprocess As System.Windows.Forms.ListBox
    Friend WithEvents txtShade As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
