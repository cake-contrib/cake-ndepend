nuget install secure-file -ExcludeVersion;
If((Test-Path $env:package-key) -and (Test-Path $env:package-pwd))
{
    secure-file\tools\secure-file -decrypt lib\package.zip.enc -secret $env:package-key;
    choco install 7zip.portable -y;
    7z e lib\package.zip -o"lib\package" -p"$ENV:package-pwd";
    
    $packagePath = Resolve-Path .\lib\package;
    $env:PATH += ";$packagePath";
}