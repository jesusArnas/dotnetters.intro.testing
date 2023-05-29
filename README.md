# dotnetters.intro.testing
This repo contains information related with this meetup: [Bases del testing en .NET, una visión opinionada](https://www.meetup.com/es-ES/dotnetters/events/293524577/)

## Meetup goals
The main ideas behind this talk are:
- This repo presents some personal ideas about testing. DPlease disregard software architecture, naming, etc. It is specially prepared to create undesired situations in our work.
- We cannot guarantee that a piece of software will work as expected. The only way to ensure it is to run it, and tests do it better than developers.
- Testing is a team activity. There is no silver bullet that can be used in all our projects. There are multiple options, each with its own trade-offs, and team members should reach agreements on how the project will be developed.
- Software architecture is related to its testability. If the design is highly coupled and does not have extensibility points, tests may not be possible, or they may be too tigthly coupled to the implementation.

## Links
Some links with relevant ideas that were used to prepare the talk:
- https://github.com/Xabaril/ManualEffectiveTestingHttpAPI

- https://www.youtube.com/watch?v=sMdrbIbGwFo Test parametrizados en xUnit con InlineData, ClassData, MemberData 

- https://twitter.com/gregor_riegler/status/1659921279481180162 "A unit is a portion of a system that you can exercise and understand with tests, with minimal setup or complication"

- https://www.youtube.com/watch?v=TNuyxB2gvng 3 + 1 herramientas de testing en .NET | CodelyTv #laFunción8x29 

- https://github.com/jbogard/Respawn Respawn

- https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices First principles

- https://www.lambdatest.com/blog/nunit-vs-xunit-vs-mstest/ What testing framework should i use?

- https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/ xUnit parametrized tests

- https://github.dev/dotnet/AspNetCore.Docs.Samples/tree/main/fundamentals/minimal-apis/samples/MinApiTestsSample/UnitTests Minimal Apis unit testing for endpoints
