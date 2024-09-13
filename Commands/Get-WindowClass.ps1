function Get-WindowClass {
[CmdletBinding()]
    param
    (
      [IntPtr]
      $WindowHandle
    )

         $sb = New-Object text.stringbuilder -ArgumentList 256 # max length of class na
         $rtnlen = [Pinvoke.User32]::GetClassName($WindowHandle,$sb,$sb.Capacity)
         $sb.tostring()

 }
