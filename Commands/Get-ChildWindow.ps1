function Get-ChildWindow{
[CmdletBinding()]
param (
    [Parameter(ValueFromPipeline = $true, ValueFromPipelinebyPropertyName = $true)]
    [ValidateNotNullorEmpty()]
    [System.IntPtr]$WindowHandle = [intptr]::zero
)
    foreach ($child in ([Pinvoke.Logic.UserDesktopLogic]::GetChildWindows($WindowHandle))){

        [PSCustomObject] @{
            WindowHandle = $WindowHandle
            ChildId = $child
            ChildTitle = (Get-WindowName -WindowHandle $child)
            processID = Get-WindowProcess -WindowHandle $WindowHandle
        }
    }
}