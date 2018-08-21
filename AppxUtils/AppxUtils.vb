Imports System.Management.Automation

Public Class AppxUtils
	''' <summary>
	''' Uses OS version to determine if system supports Appx
	''' </summary>
	''' <remarks>Windows 8+</remarks>
	''' <returns>TRUE if system supports Appx packages, otherwise FALSE</returns>
	Public Shared Function IsAppxCapable() As Boolean
		Return (System.Environment.OSVersion.Version.Major = 6 AndAlso System.Environment.OSVersion.Version.Minor >= 2) OrElse (System.Environment.OSVersion.Version.Major > 6)
	End Function

	''' <summary>
	''' Lists all Appx packages installed on system
	''' </summary>
	''' <returns>List of packages</returns>
	''' <remarks>Status must be OK (0) and IsFramework must be FALSE</remarks>
	Public Shared Function GetPackages() As AppxInfo()
		If Not IsAppxCapable() Then Throw New System.NotSupportedException("Appx packages not supported by system")

		Dim output As New List(Of AppxInfo)

		Using ps As PowerShell = PowerShell.Create
			ps.AddCommand("Get-AppxPackage")
			Dim pscollection As System.Collections.ObjectModel.Collection(Of PSObject) = ps.Invoke()

			For Each psobj As PSObject In pscollection
				If psobj.ImmediateBaseObject.GetType.FullName = "Microsoft.Windows.Appx.PackageManager.Commands.AppxPackage" AndAlso psobj.ImmediateBaseObject.Status = 0 AndAlso psobj.ImmediateBaseObject.IsFramework = False Then
					output.Add(New AppxInfo With {
						 .Name = psobj.ImmediateBaseObject.Name,
						 .PackageFamilyName = psobj.ImmediateBaseObject.PackageFamilyName,
						 .Publisher = psobj.ImmediateBaseObject.Publisher,
						 .Version = psobj.ImmediateBaseObject.Version,
						 .BaseObject = psobj.ImmediateBaseObject})
				End If
			Next
		End Using

		Return output.ToArray
	End Function

	''' <summary>
	''' Lists all Appx packages installed on system containing <paramref name="Name">Name</paramref>
	''' </summary>
	''' <param name="Name">Partial name of package</param>
	''' <returns>List of all packages containing Name</returns>
	''' <remarks>Case insensitive. If <paramref name="Name">Name</paramref> is empty, returns as <seealso cref="GetPackages">GetPackages</seealso>.</remarks>
	Public Shared Function GetPackages(Name As String) As AppxInfo()
		If String.IsNullOrWhiteSpace(Name) Then Return GetPackages()
		Return Array.FindAll(GetPackages(), Function(x) x.Name.ToUpper.Contains(Name.ToUpper))
	End Function

	''' <summary>
	''' Start Appx application by <paramref name="PackageFamilyName">PackageFamilyName</paramref>
	''' </summary>
	''' <param name="PackageFamilyName">Application identifier</param>
	''' <remarks><paramref name="PackageFamilyName">PackageFamilyName</paramref> is in form NAME_PUBLISHERID</remarks>
	Public Shared Sub StartAppx(PackageFamilyName As String)
		If Not IsAppxCapable() Then Throw New System.NotSupportedException("Appx packages not supported by system")
		If String.IsNullOrWhiteSpace(PackageFamilyName) Then Throw New ArgumentNullException("PackageFamilyName")

		Try
			Dim p As Process = New Process()
			Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
			startInfo.UseShellExecute = True
			startInfo.FileName = "shell:AppsFolder\" & PackageFamilyName & "!App"
			p.StartInfo = startInfo
			p.Start()
		Catch ex As Exception
			Throw New ArgumentException("Invalid PackageFamilyName", "PackageFamilyName", ex)
		End Try
	End Sub

	''' <summary>
	''' Start Appx application by <paramref name="Info">Appx info</paramref>
	''' </summary>
	''' <param name="Info">Application information</param>
	Public Shared Sub StartAppx(Info As AppxInfo)
		StartAppx(Info.PackageFamilyName)
	End Sub

	''' <summary>Basic information about Appx package</summary>
	Structure AppxInfo
		''' <summary>Name of package</summary> 
		Property Name As String
		''' <summary>Full name of package</summary> 
		Property PackageFamilyName As String
		''' <summary>Publisher</summary> 
		Property Publisher As String
		''' <summary>Version</summary> 
		Property Version As String
		''' <summary>Base object of type Microsoft.Windows.Appx.PackageManager.Commands.AppxPackage</summary> 
		Property BaseObject As Object

		Public Overrides Function ToString() As String
			Return Name
		End Function

		''' <summary>Starts current application</summary> 
		Public Sub Start()
			StartAppx(Me)
		End Sub
	End Structure

	'DirectCast(z.ImmediateBaseObject, Microsoft.Windows.Appx.PackageManager.Commands.AppxPackage)
End Class
