function Set-Window {
[CmdletBinding()]
    param
    (
      [IntPtr]
      $WindowHandle,
      [Pinvoke.WindowAffinity] $Affinity,
      [Pinvoke.zOrderOptions] $zOrder,
      [Pinvoke.RECT]$Coordinates
    )

    if ($PSBoundParameters.Contains('Affinity')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
    if ($PSBoundParameters.Contains('zOrder')){
      $Success = [Pinvoke.User32]::SetWindowPos($WindowHandle,$zorder,0,0,0,0, [Pinvoke.WindowOptions]::SWP_NOSIZE + [Pinvoke.WindowOptions]::SWP_NOMOVE  )
    }
    if ($PSBoundParameters.Contains('options')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
    if ($PSBoundParameters.Contains('Coordinates')){
      $Success = [Pinvoke.User32]::SetWindowPos($WindowHandle,0,$rect.Left,$rect.Top,$rect.right,$rect.bottom, [Pinvoke.WindowOptions]::SWP_SHOWWINDOW  )
    }
 }
