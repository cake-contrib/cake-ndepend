# Contributing
This project needs you! If you found an issue, or you want to contribute, this is the starting point!

But wait, are you asking... Where should I start?

## The place where it starts
If you get to this point, you have my respect! You are using the tool, and that is awesome! Thanks!!

As a starting point, you need to create an issue. GitHub is awesome, and for a small project like this, the issue tracker is what we need (KISS, right?).
Click on *Issues* tab on top, and open a issue (or use this [link][issues]). Kick-off the discussion and the issue will be tagged accordingly.

## This tool is technical, I'm a techie, and I will enhance it!
If you get this far, you heavily use the tool and that *bug* (sometimes we call it *by design*) annoys you. Well, it's OSS, and you want to left your mark, enhancing it.

Start forking the repo (assuming that you have a [GitHub account][github_account]). The [guide][forking_guide] will help you with the task.
Then clone the repo:

    git clone git@github.com:your-username/pullrequests-viewer.git
    
Setup your machine following this [guide][setup_guide]!

Make sure that it builds, and the tests pass:
- On Windows:
    ```ps
    ./build.ps1
    ```
- On MacOSX/Linux:
    ```sh
    ./build.sh
    ```

At this development stage, you can create your branch, or work on your master. This step is not a game changer. The project uses [SemVer][semver] for release versioning.

Make your bug fix/feature enhancements, making sure the tests pass:
- On Windows:
    ```ps
    ./build.ps1
    ```
- On MacOSX/Linux:
    ```sh
    ./build.sh
    ```

Stage the changes:

    git add <file(s)>

Commit the changes, giving a [meaningful message][git_commit_messages]:

    git commit -m "My meaningful message"

Push the changes to origin:

    git push origin <branch_name>

Then you create a [Pull Request][github_pull_requests] with a [brief description][pr_description] of the PR. I will take a look ASAP (I'm using the tool, any enhancement is welcome), and will merge it. You have higher chances to be approved if:
- Is linked to an issue
- Is covered with [tests][tests]
- Follow the [styling suide][styling_guide]

[issues]: https://github.com/joaoasrosa/cake-ndepend/issues
[github_account]:https://github.com/join
[forking_guide]: https://help.github.com/articles/fork-a-repo/
[setup_guide]: https://github.com/joaoasrosa/cake-ndepend/blob/master/docs/SETUP.md
[semver]: http://semver.org/
[git_commit_messages]: http://tbaggery.com/2008/04/19/a-note-about-git-commit-messages.html
[github_pull_requests]: https://help.github.com/articles/creating-a-pull-request/
[pr_description]: https://github.com/blog/1943-how-to-write-the-perfect-pull-request
[tests]: https://github.com/joaoasrosa/cake-ndepend/blob/master/docs/DEVELOPMENT.md#tests
[styling_guide]: https://github.com/joaoasrosa/cake-ndepend/blob/master/docs/DEVELOPMENT.md#styling-guide