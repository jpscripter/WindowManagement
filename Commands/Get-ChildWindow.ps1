function Get-ChildWindow{
[CmdletBinding()]
param (
    [Parameter(ValueFromPipeline = $true, ValueFromPipelinebyPropertyName = $true)]
    [ValidateNotNullorEmpty()]
    [System.IntPtr]$WindowHandle = [intptr]::zero,
    [switch]$All

)
    $Windows = New-Object Collections.Arraylist 
    foreach ($child in ([Pinvoke.Logic.UserDesktopLogic]::GetChildWindows($WindowHandle))){

        $Null = $Windows.add([PSCustomObject] @{
            WindowHandle = $WindowHandle
            ChildId = $child
            ParentID = (Get-WindowParent -WindowHandle $child)
            ChildClass = (Get-WindowClass -WindowHandle $child)
            ChildTitle = (Get-WindowName -WindowHandle $child)
            processID = Get-WindowProcess -WindowHandle $child
            Children = (Get-ChildWindow -WindowHandle $child -All)
            Visable = [Pinvoke.User32]::IsWindowVisible($child)
        })

    }
    if (-not $all.IsPresent){
        $Windows = $windows.where({[Pinvoke.User32]::IsWindowVisible($Psitem.CHildID)})
    }
    $Windows
}