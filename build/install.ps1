Write-Output (Test-Path $env:PACKAGE_KEY);

If((Test-Path $env:PACKAGE_KEY) -and (Test-Path $env:LICENSE_KEY))
{
    nuget install secure-file -ExcludeVersion;
    secure-file\tools\secure-file -decrypt lib\package.zip.enc -secret $env:PACKAGE_KEY;
    choco install 7zip.portable -y;
    7z e lib\package.zip -o"lib\package";
    
    $packagePath = Resolve-Path .\lib\package;
    $env:PATH += ";$packagePath";

    $license = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($env:LICENSE_KEY));
    Set-Content -Path "lib\package\NDependProLicense.xml" -Value $license -Force

    Write-Output "All set. Let's start the build!";
}