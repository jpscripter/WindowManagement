function Get-WindowProcess {
[CmdletBinding()]

    param
    (
      [IntPtr]
      $WindowHandle
    )
    $ProcessID = 0
    $ThreadID = [Pinvoke.User32]::GetWindowThreadProcessId($WindowHandle, [ref]$ProcessID)
    $ProcessID
 }
