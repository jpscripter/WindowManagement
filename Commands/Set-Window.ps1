function Set-Window {
[CmdletBinding()]
    param
    (
      [IntPtr]
      $WindowHandle,
      [Pinvoke.WindowAffinity] $Affinity,
      [Pinvoke.zOrderOptions] $zOrder,
      [Pinvoke.WindowOptions] $options,
      $Position
    )

    if ($PSBoundParameters.Contains('Affinity')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
    if ($PSBoundParameters.Contains('zOrder')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
    if ($PSBoundParameters.Contains('options')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
    if ($PSBoundParameters.Contains('Position')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
 }
