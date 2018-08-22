Imports System.Management.Automation
Imports System.Xml.Serialization

Public Class AppxUtils
	''' <summary>
	''' Uses OS version to determine if system supports Appx
	''' </summary>
	''' <remarks>Windows 8+</remarks>
	''' <returns>TRUE if system supports Appx packages, otherwise FALSE</returns>
	Public Shared Function IsAppxCapable() As Boolean
		Return (System.Environment.OSVersion.Version.Major = 6 AndAlso System.Environment.OSVersion.Version.Minor >= 2) OrElse (System.Environment.OSVersion.Version.Major > 6)
	End Function

#Region "Listing"
	''' <summary>
	''' Lists all Appx packages installed on system
	''' </summary>
	''' <returns>List of packages</returns>
	Public Shared Function GetPackages() As AppxInfo()
		If Not IsAppxCapable() Then Throw New System.NotSupportedException("Appx packages not supported by system")

		Using ps As PowerShell = PowerShell.Create
			ps.AddScript("$installedapps = get-AppxPackage" & vbNewLine &
			"$pkgList = @()" & vbNewLine &
			"$pkgList = ""<Packages><Collection>""" & vbNewLine &
			"foreach ($pkg in $installedapps)" & vbNewLine &
			"{" & vbNewLine &
			"	$pkgList += ""<Package><Name>"" + $pkg.name + ""</Name><PackageFamilyName>"" + $pkg.packagefamilyname + ""</PackageFamilyName><Publisher>"" + $pkg.publisher + ""</Publisher><Version>"" + $pkg.version + ""</Version><IdCollection>""" & vbNewLine &
			"	foreach ($id in (Get-AppxPackageManifest $pkg).package.applications.application.id) { $pkgList += ""<Id>"" + $id + ""</Id>"" }" & vbNewLine &
			"	$pkgList += ""</IdCollection></Package>""" & vbNewLine &
			"}" & vbNewLine &
			"$pkgList += ""</Collection></Packages>""" & vbNewLine &
			"$pkgList" & vbNewLine)

			Dim pscollection As System.Collections.ObjectModel.Collection(Of PSObject) = ps.Invoke()
			If pscollection.Count > 0 Then
				Dim output As String = String.Join(vbNewLine, pscollection)

				Dim xs As New XmlSerializer(GetType(PackageList))
				Using tr As IO.TextReader = New IO.StringReader(output)
					Dim data As PackageList = DirectCast(xs.Deserialize(tr), PackageList)
					Return data.Package
				End Using
				xs = Nothing
			End If
		End Using
		Return Nothing
	End Function

	''' <summary>
	''' Lists all Appx packages installed on system containing <paramref name="Name">Name</paramref>
	''' </summary>
	''' <param name="Name">Partial name of package</param>
	''' <returns>List of packages containing Name</returns>
	''' <remarks>Case insensitive. If <paramref name="Name">Name</paramref> is empty, returns as <seealso cref="GetPackages">GetPackages</seealso>.</remarks>
	Public Shared Function GetPackages(Name As String) As AppxInfo()
		If String.IsNullOrWhiteSpace(Name) Then Return GetPackages()
		Return Array.FindAll(GetPackages(), Function(x) x.Name.ToUpper.Contains(Name.ToUpper))
	End Function
#End Region

#Region "Starting"
	''' <summary>
	''' Start Appx application by <paramref name="PackageFamilyName">PackageFamilyName</paramref>
	''' </summary>
	''' <param name="PackageFamilyName">Application identifier</param>
	''' <param name="ApplicationId">Entry point of application</param>
	''' <remarks><paramref name="PackageFamilyName">PackageFamilyName</paramref> is in form NAME_PUBLISHERID</remarks>
	Public Shared Sub StartAppx(PackageFamilyName As String, Optional ApplicationId As String = "App")
		If Not IsAppxCapable() Then Throw New System.NotSupportedException("Appx packages not supported by system")
		If String.IsNullOrWhiteSpace(PackageFamilyName) Then Throw New ArgumentNullException("PackageFamilyName")

		Try
			Dim p As Process = New Process()
			Dim startInfo As ProcessStartInfo = New ProcessStartInfo()
			startInfo.UseShellExecute = True
			startInfo.FileName = "shell:AppsFolder\" & PackageFamilyName & "!" & ApplicationId
			p.StartInfo = startInfo
			p.Start()
		Catch ex As Exception
			Throw New ArgumentException("Invalid PackageFamilyName or ApplicationId", ex)
		End Try
	End Sub

	''' <summary>
	''' Start Appx application by <paramref name="Info">Appx info</paramref>
	''' </summary>
	''' <remarks>First or default entry point is used</remarks>
	''' <param name="Info">Application information</param>
	Public Shared Sub StartAppx(Info As AppxInfo)
		StartAppx(Info.PackageFamilyName, If(Info.ApplicationId.Length > 0, Info.ApplicationId(0), Nothing))
	End Sub

	''' <summary>
	''' Start Appx application by <paramref name="Info">Appx info</paramref>
	''' </summary>
	''' <param name="Info">Application information</param>
	''' <param name="ApplicationId">Entry point of application</param>
	Public Shared Sub StartAppx(Info As AppxInfo, ApplicationId As String)
		StartAppx(Info.PackageFamilyName, ApplicationId)
	End Sub
#End Region

#Region "Information structure"
	''' <summary>Basic information about Appx package</summary>
	Structure AppxInfo
		''' <summary>Name of package</summary> 
		<XmlElement()>
		Property Name As String
		''' <summary>Family name of package</summary> 
		<XmlElement()>
		Property PackageFamilyName As String
		''' <summary>Publisher</summary> 
		<XmlElement()>
		Property Publisher As String
		''' <summary>Version</summary> 
		<XmlElement()>
		Property Version As String

		''' <summary>Entry points for application</summary> 
		<XmlArray("IdCollection"), XmlArrayItem("Id")>
		Property ApplicationId As String()

		Public Overrides Function ToString() As String
			Return Name
		End Function

		''' <summary>Starts current application with first or default entry point</summary> 
		Public Sub Start()
			StartAppx(Me)
		End Sub

		''' <summary>Starts current application</summary>
		''' <param name="ApplicationId">Entry point</param>
		Public Sub Start(ApplicationId As String)
			StartAppx(Me, ApplicationId)
		End Sub

		''' <summary>Starts current application</summary>
		''' <param name="ApplicationId">Entry point from list</param>
		Public Sub Start(ApplicationId As Integer)
			StartAppx(Me, Me.ApplicationId(ApplicationId))
		End Sub
	End Structure

	<XmlRoot("Packages")>
	Public Class PackageList
		<XmlArray("Collection"), XmlArrayItem("Package")>
		Property Package() As AppxInfo()
	End Class
#End Region

End Class
