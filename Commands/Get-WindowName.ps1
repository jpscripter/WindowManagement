function Get-WindowName {
[CmdletBinding()]
    param
    (
      [IntPtr]
      $WindowHandle
    )

     $length = [Pinvoke.User32]::GetWindowTextLength($WindowHandle)
     if($length -gt 0){
         $sb = New-Object text.stringbuilder -ArgumentList ($length + 1)
         $rtnlen = [Pinvoke.User32]::GetWindowText($WindowHandle,$sb,$sb.Capacity)
         $sb.tostring()
     }
 }
