# Cake.NDepend

A Cake AddIn that extends the `NDepend.Console` [command line tool](https://www.ndepend.com/docs/ndepend-console).

[![Build status](https://ci.appveyor.com/api/projects/status/666egh2grlita76w?svg=true)](https://ci.appveyor.com/project/joaoasrosa/cake-ndepend)
[![NuGet](https://img.shields.io/nuget/v/Cake.NDepend.svg)](https://www.nuget.org/packages/Cake.NDepend)
[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

## Usage

### Prerequisites
The addin is based on the `NDepend.Console` command line tool. Before using it, make sure the NDepend installation location is part of the environment variable `PATH`, and you have a valid license.

### Including the addin

To include the addin, add the following to the beginning of the `cake` script:
```
#addin "Cake.NDepend"
```

### Use the addin

To use the addin, you need to configure the settings and run the `NDepend.Console` alias:
```
#addin "Cake.NDepend"
...
Task("NDepend-Analyse")
    .Description("Runs the NDepend analyser on the project.")
    .Does(() => 
    {
        var settings = new NDependSettings
        {
            ProjectPath = ndependProjectFullPath // Full path to the NDepend project.
        };

        NDependAnalyse(settings);
    });
...
```

### Settings

The `NDependSettings` have *one* mandatory option, `ProjectPath`. The remain options are optional, however, there are certain option combinations that need to be used together. For more information about the usage read the `NDepend.Console` [documentation](https://www.ndepend.com/docs/ndepend-console).


## Built With

* [.NET Framework 4.6 & .NET Core 2.0](https://www.microsoft.com/net/download) - The Framework(s)
* [NuGet](https://www.nuget.org/) - Dependency Management
* [Cake](http://cakebuild.net/) - Cross Platform Build Automation System
* [AppVeyor](https://www.appveyor.com/) - Continuous Integration & Delivery Service
* [TravisCI](https://travis-ci.org/) - Continuous Integration Platform for GitHub
* [NDepend](https://www.ndepend.com/) - Code Quality Platform

## Contributing

Please read [CONTRIBUTING.md](https://github.com/joaoasrosa/cake-ndepend/blob/master/CONTRIBUTING.md) for details on our code of conduct, and the process for submitting pull requests to us.

## Versioning

We use [SemVer](http://semver.org/) for versioning. For the versions available, see the [tags on this repository](https://github.com/joaoasrosa/pullrequests-viewer/tags). For the release notes, see the [release notes](https://github.com/joaoasrosa/pullrequests-viewer/blob/master/ReleaseNotes.md).

## Authors

* **João Rosa** - *Initial work* - [joaoasrosa](https://github.com/joaoasrosa) [![Follow @joaoasrosa](https://img.shields.io/badge/Twitter-Follow%20%40joaoasrosa-blue.svg)](https://twitter.com/intent/follow?screen_name=joaoasrosa) 

See also the list of [contributors](https://github.com/joaoasrosa/cake-ndepend/contributors) who participated in this project.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details

## Project Support

This project is supported by [NDepend](https://www.ndepend.com/) with 2 licenses.