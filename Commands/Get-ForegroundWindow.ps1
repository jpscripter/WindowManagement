function Get-ForegroundWindow{
[CmdletBinding()]
param (
)
    [Pinvoke.User32]::GetForegroundWindow()
}