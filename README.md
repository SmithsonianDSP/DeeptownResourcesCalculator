﻿# Deep Town Resources Calculator

---

## About 

The reason this came about was because I&mdash;like many others in guilds&mdash;wanted to be able to look
at the relative value of a resource to another.  
What request is *really* more? 150 rubber or 500 circuits? Not necessarily in terms of **coin** value, but
in the amount of time and resources required to create them? (Spoiler: it's rubber)

This kind of data crunching wasn't really well-suited for doing in a spreadsheet, but I knew I could do it
much easier in a simple console program. And this is the result. 

---

## Results & Data

The output from the program can be found in this repository so you do not need to download and run it, 
yourself, to look at the data. 

See the footnotes, below, for more information on the calculations and data.

1. [Resources by Longest Time To Produce Required Subcomponents](/Outputs/1-LongestTimeToProduceSubcomponents.txt) [[1](#1)][[2](#2)][[3](#3)]
2. [Resources by Most Expensive Subcomponts](/Outputs/2-MostExpensiveSubcomponts.txt)
3. [Resources by Highest Profit Margins](/Outputs/3-HighestProfitMargins.txt) [[4](#4)]
4. [Resources by Time-To-Value Ratio](/Outputs/4-TimeToValueRatio.txt)
5. [Resources by Time Required @ Max Request (5,000)](/Outputs/5-TimeRequiredAtMaxRequest.txt)
6. [Resources by Value @ Max Request (5,000)](/Outputs/6-ValueAtMaxRequest.txt)

---

### Calculation Footnotes

**The purpose of this is *NOT* to ACCURATELY reflect the amount of REAL-TIME required to produce a resource, 
but *to show how resources compare to others.***

1. <a name="1"></a>For base resources (e.g., coal, iron ore, diamonds), the `TimeToProduce` value is the time it takes to
  produce one unit of that resource from a Level 8 mine (@ 17 RPM). This also factors in the availability 
  of the resource in the mining areas:

   * Resources that have a 100% mine available (e.g., Area 1 is 100% coal) have a `TimeToProduce` equal 
    to 17 / minute.  

   * Resources __without__ a 100% mine have a `TimeToProduce` of `(17 * [max % available]) / minute`.        
        (e.g., Iron's best mining areas are 30% iron, so its mining rate works out to 5.1 / minute)  

   * The best estimate for the effective, online water collection rate (because it isn't *always* raining) is
    `2.5 RPM`. I haven't been able to verify or test this, but anyone can provide a more accurate value for
    this, please let me know.

2. <a name="2"></a>All production rates assume ***online mining*** speeds, ***no crystal boosts***, and ***no drone boosts***.  

3. <a name="3"></a>**Simultaneous production is NOT considered in durations**. When looking at the "time to produce subcomponents" for a
  resource, this value is essentially the amount of time it would take if you could only be doing one action
  at any given time (e.g., first you must mine the base ore, then smelt it into bars one at a time, etc.)

4. <a name="4"></a>The `ProfitMargin` value is not the *true* profit margin; it is the coin value of the given resource
  compared to the coin value of the subcomponents required to produce it.  
  e.g., a copper bar is `25` coin and requires `5` copper ore (worth `2` coin/ea) to produce , so the 
  `ProfitMargin` for a copper bar is: `25 - (5 * 2) = 15`.

5. <a name="5"></a>The "**Time-to-Value**" ratio is:  
 `CoinValue` ÷ (`TimeToProduceSubcomponents` + `TimeToProduce`)  
   This represents the *total amount of time* spent on it *and* its subcomponents (mining, smelting, crafting)
 **relative to the selling price of the item itself**.









