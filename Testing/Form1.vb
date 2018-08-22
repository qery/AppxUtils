Imports QerysUtilities

Public Class Form1
	Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
		lblIsCapable.Font = New Drawing.Font(lblIsCapable.Font, Drawing.FontStyle.Bold)

		If AppxUtils.IsAppxCapable Then
			lblIsCapable.Text = "Yes"
			lblIsCapable.ForeColor = Drawing.Color.DarkGreen
			GroupBox1.Enabled = True
			GroupBox2.Enabled = True
		Else
			lblIsCapable.Text = "No"
			lblIsCapable.ForeColor = Drawing.Color.DarkRed
			GroupBox1.Enabled = False
			GroupBox2.Enabled = False
		End If
	End Sub


	Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click
		txtFind.Clear()
		cmdFind.PerformClick()
	End Sub

	Private Sub cmdFind_Click(sender As System.Object, e As System.EventArgs) Handles cmdFind.Click
		lstPackages.BeginUpdate()
		lstPackages.Items.Clear()

		For Each info As AppxUtils.AppxInfo In AppxUtils.GetPackages(txtFind.Text)
			Dim item As New ListViewItem
			item.Text = info.Name
			item.Tag = info
			item.SubItems.Add(info.PackageFamilyName)
			lstPackages.Items.Add(item)
		Next

		lstPackages.EndUpdate()
	End Sub

	Private Sub lstPackages_ItemSelectionChanged(sender As System.Object, e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles lstPackages.ItemSelectionChanged
		If e.IsSelected Then
			With DirectCast(e.Item.Tag, AppxUtils.AppxInfo)
				txtName.Text = .Name
				txtPFN.Text = .PackageFamilyName
				txtPublisher.Text = .Publisher
				txtVersion.Text = .Version
				lstIds.Items.Clear()
				For Each id As String In .ApplicationId
					lstIds.Items.Add(id)
				Next
				cmdStart.Enabled = True
				cmdStart.Tag = e.Item.Tag
			End With
		Else
			txtName.Clear()
			txtPFN.Clear()
			txtPublisher.Clear()
			txtVersion.Clear()
			lstIds.Items.Clear()
			cmdStart.Enabled = False
			cmdStart.Tag = Nothing
		End If
	End Sub

	Private Sub cmdStart_Click(sender As System.Object, e As System.EventArgs) Handles cmdStart.Click
		If cmdStart.Tag IsNot Nothing AndAlso TypeOf cmdStart.Tag Is AppxUtils.AppxInfo Then
			If lstIds.SelectedItems.Count > 0 Then
				DirectCast(cmdStart.Tag, AppxUtils.AppxInfo).Start(lstIds.SelectedItems(0).Text)
			ElseIf lstIds.Items.Count > 0 Then
				DirectCast(cmdStart.Tag, AppxUtils.AppxInfo).Start(lstIds.Items(0).Text)
			End If
		End If
	End Sub
End Class

