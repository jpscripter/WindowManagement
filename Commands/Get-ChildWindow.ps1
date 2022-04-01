function Get-ChildWindow{
[CmdletBinding()]
param (
    [Parameter(ValueFromPipeline = $true, ValueFromPipelinebyPropertyName = $true)]
    [ValidateNotNullorEmpty()]
    [System.IntPtr]$WindowHandle
)
    foreach ($child in ([Pinvoke.user32]::GetChildWindows($WindowHandle))){

        [PSCustomObject] @{
            WindowHandle = $WindowHandle
            ChildId = $child
            ChildTitle = (Get-WindowName -WindowHandle $child)
            processID = Get-WindowProcess -WindowHandle $WindowHandle
        }
    }
}