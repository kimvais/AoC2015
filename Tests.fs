module AoC2015.Tests

open Xunit
open Xunit.Abstractions
open AoC2015.Utils
open AoC2015.Day5
open AoC2015.Day6


type Puzzles(o: ITestOutputHelper) =
    [<Fact>]
    let ``day 5`` () =
        Assert.True(isNice "ugknbfddgicrmopn")
        Assert.True(isNice "aaa")
        Assert.False(isNice "jchzalrnumimnmhp")
        Assert.False(isNice "haegwjzuvuyypxyu")
        Assert.False(isNice "dvszwmarrgswjxmb")

    [<Fact>]
    let ``day 6`` () =
        Assert.Equal(569999, day6 ())
        Assert.Equal(1, day6' [ "turn on 0,0 through 0,0" ] getValue2 ())
        Assert.Equal(2000000, day6' [ "toggle 0,0 through 999,999" ] getValue2 ())
        Assert.Equal
            (2000000 + 1,
             day6'
                 [ "turn on 0,0 through 0,0"
                   "toggle 0,0 through 999,999" ]
                 getValue2
                 ())
        Assert.Equal
            (2000000 + 1 - 10000,
             day6'
                 [ "turn on 0,0 through 0,0"
                   "turn off 100,100 through 199,199"
                   "toggle 0,0 through 999,999" ]
                 getValue2
                 ())
