function Set-WindowAffinity {
[CmdletBinding()]
    param
    (
      [IntPtr]
      $WindowHandle,
      [Pinvoke.WindowAffinity] $Affinity
    )

    [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
 }
