$files = Get-ChildItem -Path . -Recurse -Include *.cs
foreach ($file in $files) {
    $content = [System.IO.File]::ReadAllText($file.FullName)
    if ($content -match '<<<<<<< Updated upstream') {
        $newContent = [System.Text.RegularExpressions.Regex]::Replace($content, '(?s)<<<<<<< Updated upstream\r?\n(.*?)\r?\n=======\r?\n(.*?)\r?\n>>>>>>> Stashed changes', '$1')
        [System.IO.File]::WriteAllText($file.FullName, $newContent)
        Write-Host "Fixed "
    }
}
