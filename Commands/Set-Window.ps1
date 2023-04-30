function Set-Window {
[CmdletBinding()]
    param
    (
      [IntPtr] $WindowHandle,
      #[Pinvoke.WindowAffinity] $Affinity,
      [Pinvoke.WindowShowStyle] $Style,
      [Pinvoke.zOrderOptions] $zOrder,
      [Pinvoke.RECT]$Coordinates
    )

    <#
    # This only works for current process
    if ($PSBoundParameters.ContainsKey('Affinity')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
      if (-not $Success){
        $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Write-Error $ErrorMessage
        Write-Error $ErrorMessage
        throw "Failed setting $Affinity"
      }
    }
    #>

    if ($PSBoundParameters.ContainsKey('Zorder')){
      $Success = [Pinvoke.User32]::SetWindowPos($WindowHandle,$zorder,0,0,0,0, [Pinvoke.WindowOptions]::SWP_NOSIZE + [Pinvoke.WindowOptions]::SWP_NOMOVE  )
      if (-not $Success){
        $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Write-Error $ErrorMessage
        throw "Failed setting $Zorder"
      }
    }

    if ($PSBoundParameters.ContainsKey('Options')){
      $Success = [Pinvoke.User32]::SetWindowDisplayAffinity($WindowHandle, $Affinity)
      if (-not $Success){
        $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Write-Error $ErrorMessage
        throw "Failed setting $Options"
      }
    }
    
    if ($PSBoundParameters.ContainsKey('Options')){
      $Success = [Pinvoke.User32]::SetWindowPos($WindowHandle,0,$rect.Left,$rect.Top,$rect.right,$rect.bottom, [Pinvoke.WindowOptions]::SWP_SHOWWINDOW  )
      if (-not $Success){
        $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Write-Error $ErrorMessage
        throw "Failed setting window location"
      }
    }

    if ($PSBoundParameters.ContainsKey('Style')){
      $Success = [Pinvoke.User32]::ShowWindow($WindowHandle,$Style )
      if (-not $Success){
        $ErrorMessage = [System.ComponentModel.Win32Exception][System.Runtime.InteropServices.Marshal]::GetLastWin32Error()
        Write-Error $ErrorMessage
        throw "Failed style $Style"
      }
    }

 }
