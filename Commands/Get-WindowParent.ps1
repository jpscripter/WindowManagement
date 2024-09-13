function Get-WindowParent {
[CmdletBinding()]
    param
    (
      [IntPtr]
      $WindowHandle
    )

         $rtnlen = [Pinvoke.User32]::GetParent($WindowHandle)
 }
