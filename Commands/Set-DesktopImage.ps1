function Set-DesktopImage{
[CmdletBinding()]
param (
    [io.FileInfo]$Image 
)

    $Options = [Pinvoke.User32]::SPIF_UPDATEINIFILE -bor [Pinvoke.User32]::SPIF_SENDWININICHANGE
    $Success = [Pinvoke.User32]::SystemParametersInfo([Pinvoke.User32]::SPI_SETDESKWALLPAPER, 0, $Image.Fullname, $Options )
    if (-not $success){
        ([System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetHRForLastWin32Error()).message
    }
}