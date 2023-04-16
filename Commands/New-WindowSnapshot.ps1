function New-WindowSnapshot {
[CmdletBinding()]

    param
    (
      [IntPtr]
      $WindowHandle,
      [io.FileInfo] $path
    )
    
      $bmp = New-Object Drawing.Bitmap $bounds.width, $bounds.height
      $graphics = [Drawing.Graphics]::FromImage($bmp)
  
      $graphics.CopyFromScreen($bounds.Location, [Drawing.Point]::Empty, $bounds.size)
  
      $bmp.Save($path)
  
      $graphics.Dispose()
      $bmp.Dispose()
    

 }
