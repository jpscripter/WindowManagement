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

    if ($null -eq $Affinity){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
    if (-not $Success){
        $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Write-Error $ErrorMessage
        throw "Failed setting $Affinity"
    }

    if ($null -eq $zOrder){
      $Success = [Pinvoke.User32]::SetWindowPos($WindowHandle,$zorder,0,0,0,0, [Pinvoke.WindowOptions]::SWP_NOSIZE + [Pinvoke.WindowOptions]::SWP_NOMOVE  )
    }
    if (-not $Success){
        $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Write-Error $ErrorMessage
        throw "Failed setting $Zorder"
    }

    if ($null -eq $options){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
    }
    if (-not $Success){
      $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
      Write-Error $ErrorMessage
      throw "Failed setting $Options"
    }

    if ($null -eq $Coordinates){
      $Success = [Pinvoke.User32]::SetWindowPos($WindowHandle,0,$rect.Left,$rect.Top,$rect.right,$rect.bottom, [Pinvoke.WindowOptions]::SWP_SHOWWINDOW  )
    }
    if (-not $Success){
      $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
      Write-Error $ErrorMessage
      throw "Failed setting window location"
    }
 }
