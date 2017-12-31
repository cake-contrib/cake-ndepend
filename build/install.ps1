If((Test-Path env:PACKAGE_KEY) -and (Test-Path env:LICENSE_KEY))
{
    nuget install secure-file -ExcludeVersion;
    secure-file\tools\secure-file -decrypt .\lib\package.zip.enc -secret $env:PACKAGE_KEY;
    choco install 7zip.portable -y;
    7z x lib\package.zip -o".\lib\NDepend";
    
    $packagePath = Resolve-Path .\lib\NDepend;
    $env:PATH += ";$packagePath";

    $license = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($env:LICENSE_KEY));
    Set-Content -Path "lib\NDepend\NDependProLicense.xml" -Value $license -Force

    Write-Output "All set. Let's start the build!";
}