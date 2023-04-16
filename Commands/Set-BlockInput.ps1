function Set-BlockInput {
[CmdletBinding()]
    param
    (
      [bool]
      $Enable = $false
    )
    [pinvoke.User32]::BlockInput($true)
   
 }
