function New-WindowSnapshot {
[CmdletBinding()]

    param
    (
      [IntPtr]
      $WindowHandle,
      [io.FileInfo] $path
    )

      $rect = New-Object -TypeName Pinvoke.RECT
      $Success = [Pinvoke.User32]::GetWindowRect($WindowHandle,[ref]$rect)
      $rect

      [int]$Width = ( $rect.right - $rect.left )
      [int]$Height = ($rect.bottom - $rect.top )
      $bmp = New-Object -typename Drawing.Bitmap -argumentlist ($width, $Height)
      $graphics = [Drawing.Graphics]::FromImage($bmp)
  
      $Size  = [System.Drawing.Size]::new($width,$height)
      $graphics.CopyFromScreen($rect.bottom,$rect.left,$rect.top,$rect.top, $size,'Blackness')
  
      $bmp.Save($path)
  
      $graphics.Dispose()
      $bmp.Dispose()
    

 }
