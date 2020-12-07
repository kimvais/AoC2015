module AoC2015.Tests

open Xunit
open Xunit.Abstractions
open AoC2015.Utils
open AoC2015.Day5


type Puzzles(o: ITestOutputHelper) =
    [<Fact>]
    let ``day 5`` () =
        Assert.True(isNice "ugknbfddgicrmopn")
        Assert.True(isNice "aaa")
        Assert.False(isNice "jchzalrnumimnmhp")
        Assert.False(isNice "haegwjzuvuyypxyu")
        Assert.False(isNice "dvszwmarrgswjxmb")