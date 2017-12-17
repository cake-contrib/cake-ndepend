nuget install secure-file -ExcludeVersion
If(Test-Path ENV:secret-key)
{
    secure-file\tools\secure-file -decrypt buil\secret.ext.enc -secret ENV:secret-key
}