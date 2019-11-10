# Development
This is the development guide. It gives guidance (is the idea of a guide, right?!) for development on this repo. It is a work in progress; I'm waiting for your feedback (you can contribute in any shape or form, to start using the [contributing guide][contributing_guide]).

## Folder structure
We use the folder structure described [here][folder_structure] by [David Fowler][david_fowler].

## Tests
We use [Xunit][xunit], [Moq][moq] and [Fluent Assertions][fluent_assertions] frameworks to aid with the tests. They make it more readable and easy for the next lad to work.
The test methodology is [system under test][sut], using unit and acceptance tests. You can take a sneak peek into the tests for examples in how to write them.

### Test naming conventions
The test projects are located on `./tests/`. We create *one* unit test and *one* acceptance test project per code project, mimicking the same `src` folder structure. 
The naming convention for the unit test project is `<code-project-name>.Tests.Unit`, for the integration test project is `<code-project-name>.Tests.Integration`, and for the acceptance test project is `<code-project-name>.Tests.Acceptance`. The naming convention for unit, integration and acceptance tests is `<file-name>Tests.cs`.

## Styling guide
We (try our best) to follow the [.NET coding style][dotnet_coding_style]. It's in our plans to integrate it into the build pipeline, producing a report. Everyone will be happy.

## Releasing
The addin is released as NuGet package. When a new tag is added to the repo, it creates the package and upload it to the official NuGet repository.

[contributing_guide]: https://github.com/joaoasrosa/cake-ndepend/blob/feature/add-documentation/CONTRIBUTING.md
[folder_structure]: https://gist.github.com/davidfowl/ed7564297c61fe9ab814
[david_fowler]: https://twitter.com/davidfowl
[xunit]: https://xunit.github.io/
[moq]: https://github.com/Moq/moq4/wiki/Quickstart
[fluent_assertions]: http://fluentassertions.com/
[sut]: https://en.wikipedia.org/wiki/System_under_test
[dotnet_coding_style]: https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md