<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.cmdFind = New System.Windows.Forms.Button()
		Me.txtFind = New System.Windows.Forms.TextBox()
		Me.lstPackages = New System.Windows.Forms.ListView()
		Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.cmdRefresh = New System.Windows.Forms.Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.cmdStart = New System.Windows.Forms.Button()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtVersion = New System.Windows.Forms.TextBox()
		Me.txtPublisher = New System.Windows.Forms.TextBox()
		Me.txtPFN = New System.Windows.Forms.TextBox()
		Me.txtName = New System.Windows.Forms.TextBox()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.lblIsCapable = New System.Windows.Forms.Label()
		Me.Label6 = New System.Windows.Forms.Label()
		Me.GroupBox1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.SuspendLayout()
		'
		'GroupBox1
		'
		Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
							Or System.Windows.Forms.AnchorStyles.Left) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.GroupBox1.Controls.Add(Me.cmdFind)
		Me.GroupBox1.Controls.Add(Me.txtFind)
		Me.GroupBox1.Controls.Add(Me.lstPackages)
		Me.GroupBox1.Controls.Add(Me.cmdRefresh)
		Me.GroupBox1.Location = New System.Drawing.Point(12, 38)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(441, 219)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Package list"
		'
		'cmdFind
		'
		Me.cmdFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cmdFind.Location = New System.Drawing.Point(360, 19)
		Me.cmdFind.Name = "cmdFind"
		Me.cmdFind.Size = New System.Drawing.Size(75, 23)
		Me.cmdFind.TabIndex = 2
		Me.cmdFind.Text = "Find"
		Me.cmdFind.UseVisualStyleBackColor = True
		'
		'txtFind
		'
		Me.txtFind.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtFind.Location = New System.Drawing.Point(235, 21)
		Me.txtFind.Name = "txtFind"
		Me.txtFind.Size = New System.Drawing.Size(119, 20)
		Me.txtFind.TabIndex = 1
		'
		'lstPackages
		'
		Me.lstPackages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
							Or System.Windows.Forms.AnchorStyles.Left) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.lstPackages.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
		Me.lstPackages.FullRowSelect = True
		Me.lstPackages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
		Me.lstPackages.Location = New System.Drawing.Point(7, 48)
		Me.lstPackages.MultiSelect = False
		Me.lstPackages.Name = "lstPackages"
		Me.lstPackages.Size = New System.Drawing.Size(428, 165)
		Me.lstPackages.TabIndex = 3
		Me.lstPackages.UseCompatibleStateImageBehavior = False
		Me.lstPackages.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Text = "Name"
		Me.ColumnHeader1.Width = 200
		'
		'ColumnHeader2
		'
		Me.ColumnHeader2.Text = "PackageFamilyName"
		Me.ColumnHeader2.Width = 200
		'
		'cmdRefresh
		'
		Me.cmdRefresh.Location = New System.Drawing.Point(6, 19)
		Me.cmdRefresh.Name = "cmdRefresh"
		Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
		Me.cmdRefresh.TabIndex = 0
		Me.cmdRefresh.Text = "Refresh all"
		Me.cmdRefresh.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.GroupBox2.Controls.Add(Me.Label6)
		Me.GroupBox2.Controls.Add(Me.cmdStart)
		Me.GroupBox2.Controls.Add(Me.Label4)
		Me.GroupBox2.Controls.Add(Me.Label3)
		Me.GroupBox2.Controls.Add(Me.Label2)
		Me.GroupBox2.Controls.Add(Me.Label1)
		Me.GroupBox2.Controls.Add(Me.txtVersion)
		Me.GroupBox2.Controls.Add(Me.txtPublisher)
		Me.GroupBox2.Controls.Add(Me.txtPFN)
		Me.GroupBox2.Controls.Add(Me.txtName)
		Me.GroupBox2.Location = New System.Drawing.Point(459, 38)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(280, 219)
		Me.GroupBox2.TabIndex = 1
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Details"
		'
		'cmdStart
		'
		Me.cmdStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.cmdStart.Enabled = False
		Me.cmdStart.Location = New System.Drawing.Point(199, 125)
		Me.cmdStart.Name = "cmdStart"
		Me.cmdStart.Size = New System.Drawing.Size(75, 23)
		Me.cmdStart.TabIndex = 2
		Me.cmdStart.Text = "Start"
		Me.cmdStart.UseVisualStyleBackColor = True
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(6, 76)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(53, 13)
		Me.Label4.TabIndex = 1
		Me.Label4.Text = "Publisher:"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(6, 50)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(110, 13)
		Me.Label3.TabIndex = 1
		Me.Label3.Text = "PackageFamilyName:"
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(6, 24)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(38, 13)
		Me.Label2.TabIndex = 1
		Me.Label2.Text = "Name:"
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(6, 102)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(45, 13)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Version:"
		'
		'txtVersion
		'
		Me.txtVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtVersion.Location = New System.Drawing.Point(121, 99)
		Me.txtVersion.Name = "txtVersion"
		Me.txtVersion.ReadOnly = True
		Me.txtVersion.Size = New System.Drawing.Size(153, 20)
		Me.txtVersion.TabIndex = 0
		'
		'txtPublisher
		'
		Me.txtPublisher.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtPublisher.Location = New System.Drawing.Point(121, 73)
		Me.txtPublisher.Name = "txtPublisher"
		Me.txtPublisher.ReadOnly = True
		Me.txtPublisher.Size = New System.Drawing.Size(153, 20)
		Me.txtPublisher.TabIndex = 0
		'
		'txtPFN
		'
		Me.txtPFN.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtPFN.Location = New System.Drawing.Point(121, 47)
		Me.txtPFN.Name = "txtPFN"
		Me.txtPFN.ReadOnly = True
		Me.txtPFN.Size = New System.Drawing.Size(153, 20)
		Me.txtPFN.TabIndex = 0
		'
		'txtName
		'
		Me.txtName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
							Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.txtName.Location = New System.Drawing.Point(121, 21)
		Me.txtName.Name = "txtName"
		Me.txtName.ReadOnly = True
		Me.txtName.Size = New System.Drawing.Size(153, 20)
		Me.txtName.TabIndex = 0
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Location = New System.Drawing.Point(9, 15)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(89, 13)
		Me.Label5.TabIndex = 3
		Me.Label5.Text = "Is Appx capable?"
		'
		'lblIsCapable
		'
		Me.lblIsCapable.AutoSize = True
		Me.lblIsCapable.Location = New System.Drawing.Point(104, 15)
		Me.lblIsCapable.Name = "lblIsCapable"
		Me.lblIsCapable.Size = New System.Drawing.Size(44, 13)
		Me.lblIsCapable.TabIndex = 4
		Me.lblIsCapable.Text = "<result>"
		'
		'Label6
		'
		Me.Label6.AutoSize = True
		Me.Label6.Location = New System.Drawing.Point(6, 200)
		Me.Label6.Name = "Label6"
		Me.Label6.Size = New System.Drawing.Size(175, 13)
		Me.Label6.TabIndex = 3
		Me.Label6.Text = "Note: not all packages are startable"
		'
		'Form1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(751, 261)
		Me.Controls.Add(Me.lblIsCapable)
		Me.Controls.Add(Me.Label5)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.GroupBox1)
		Me.Name = "Form1"
		Me.Text = "Appx utils testing"
		Me.GroupBox1.ResumeLayout(False)
		Me.GroupBox1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
	Friend WithEvents cmdFind As System.Windows.Forms.Button
	Friend WithEvents txtFind As System.Windows.Forms.TextBox
	Friend WithEvents lstPackages As System.Windows.Forms.ListView
	Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
	Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
	Friend WithEvents cmdRefresh As System.Windows.Forms.Button
	Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
	Friend WithEvents Label4 As System.Windows.Forms.Label
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents txtVersion As System.Windows.Forms.TextBox
	Friend WithEvents txtPublisher As System.Windows.Forms.TextBox
	Friend WithEvents txtPFN As System.Windows.Forms.TextBox
	Friend WithEvents txtName As System.Windows.Forms.TextBox
	Friend WithEvents cmdStart As System.Windows.Forms.Button
	Friend WithEvents Label5 As System.Windows.Forms.Label
	Friend WithEvents lblIsCapable As System.Windows.Forms.Label
	Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
