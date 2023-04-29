$ModuleInfo = Import-PowerShellDataFile -Path "$PSScriptRoot\WindowManagement.psd1"
Add-Type -AssemblyName System.Drawing

if (Test-Path -Path $PSScriptRoot\Classes\){
    $Class = Get-ChildItem -Path $PSScriptRoot\Classes\*.cs -file -Recurse
    Foreach($CLS in $Class){
	    Write-Verbose -Message "Class File: $CLS"  
	    $Content = Get-Content -raw -path $CLS
        $LocalFilePath = "$PSScriptRoot\Classes\Pinvoke.$($cls.BaseName)-$($ModuleInfo.ModuleVersion).dll"
        $FilePath = "$env:Tmp\Pinvoke.$($cls.BaseName)-$($ModuleInfo.ModuleVersion).dll"
        Remove-Item -path $FilePath -ErrorAction Ignore
        if (Test-Path -Path $LocalFilePath){
            Add-Type -Path $LocalFilePath
        }elseif(Test-Path -Path $FilePath)
        {
            Add-Type -Path $FilePath
        }
        else{
            Write-Verbose -Message "Compliling Class File: $CLS -with Unsafe"  
            if ($PSVersionTable.PSVersion.Major -lt 6){
                $cp = New-Object System.CodeDom.Compiler.CompilerParameters
                $cp.CompilerOptions = '/unsafe' 
                $references.ForEach({$cp.ReferencedAssemblies.Add($PSItem)})
                $cp.OutputAssembly = $FilePath 
                $Options = @{CompilerParameters =  $cp}
            }else{
                throw 'Compile this module using powershell 5 before you use it.'
            }
            $null = Add-Type -TypeDefinition $Content @Options 
        }
        $references += $FilePath
    }
}
if (Test-Path -Path $PSScriptRoot\PrivateCommands\){
    $Commands = Get-ChildItem -Path $PSScriptRoot\PrivateCommands\*.ps1 -file -Recurse
    Foreach($PCMD in $Commands){
	    Write-Verbose -Message "Private Cmdlet File: $PCMD"  
	    . $PCMD
    }
}

if (Test-Path -Path $PSScriptRoot\Commands\){
    $Commands = Get-ChildItem -Path $PSScriptRoot\Commands\*.ps1 -file -Recurse
    Foreach($CMD in $Commands){
	    Write-Verbose -Message "Cmdlet File: $CMD"  
	    . $CMD
        
    }
    Export-ModuleMember -Function $Commands.BaseName 
}