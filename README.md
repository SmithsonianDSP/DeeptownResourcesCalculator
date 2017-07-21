<sup>**Note:** Best viewed on the GitHub Pages version: https://smithsoniandsp.github.io/DeeptownResourcesCalculator/</sup>

- - -

## About 

The reason this came about was because I&mdash;like many others in guilds&mdash;wanted to be able to look
at the relative value of a resource to another.  
What request is *really* more? 150 rubber or 500 circuits? Not necessarily in terms of **coin** value, but
in the amount of time and resources required to create them? (Spoiler: it's rubber)

This kind of data crunching wasn't really well-suited for doing in a spreadsheet, but I knew I could do it
much easier in a simple console program. And this is the result. 

- - -

## Results & Data

The output from the program can be found in this repository so you do not need to download and run it, 
yourself, to look at the data. 

All in all, most of it is probably not anything you wouldn't have already suspected... but, to me, the real
value is that it is now *compartive*: you can see how much total time each resource requires compared to the rest!

See the footnotes, below, for information on the data and calculation methods.

1. [Resources by Time To Produce Required Subcomponents](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/Outputs/1-LongestTimeToProduceSubcomponents) <sup>[[**1**](#1)][[**2**](#2)][[**3**](#3)]</sup>

2. [Resources by Total Value of Subcomponts](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/Outputs/2-MostExpensiveSubcomponts)

3. [Resources by Profit Margins](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/Outputs/3-HighestProfitMargins) <sup>[[**4**](#4)]</sup>

4. [Resources by Time-To-Value Ratio](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/Outputs/4-TimeToValueRatio)

5. [Resources by Time Required @ Max Request (5,000)](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/Outputs/5-TimeRequiredAtMaxRequest)

6. [Resources by Value @ Max Request (5,000)](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/Outputs/6-ValueAtMaxRequest)

<sup>**Note**: "Charcoal" is the smelted version of coal produced from wood. All calculations for resources that use coal (or graphite)
use the mine-produced version of Coal. If substitued with the Charcoal version, anything that uses coal in its production chain would
have increased `TimeToProduce` and lower `ProfitMargin` values.</sup>

&nbsp;

- - -

### What's Next?

Well, I don't really know. I didn't really have much additional plans beyond this!

However, one potential idea that had occured to me was to break down each resource's time requirements by the 
different production types (e.g., mine, smelter, crafting, chemistry, etc.) to show how the `TotalTimeToProduce`
time is distributed between the different types... 

(If there ***is*** interest in this, let me know! I probably might do this, anyways, but if I know there are people interested,
it will likely happen sooner!)

Beyond that, though, I'm really not sure. I considered building an actual GUI for it and allow you to select resources, quantities,
etc., and display the totals and stats for that, but I'm not really certain there would actually be much use for it.

If you have something in mind or would like to suggest, I'm open to ideas!

&nbsp;

- - -

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

   * Oil rate is based off of a Level 3 oil pump (no boosts)

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

&nbsp;

- - - - -

&nbsp;

### **License:** &nbsp; &nbsp; &nbsp;GNU GPLv3

---
>     DeepTownResourcesCalculator - Statistical Analysis of Game Resources
>              Code Copyright (C) 2017    -    SmithsonianDSP
> 
>     Deep Town (c) is the property of Rockbite Games and is unaffiliated 
>     with this program. 
> 
>     This program is free software: you can redistribute it and/or modify
>     it under the terms of the GNU General Public License as published by
>     the Free Software Foundation, either version 3 of the License, or
>     (at your option) any later version.
> 
>     This program is distributed in the hope that it will be useful,
>     but WITHOUT ANY WARRANTY; without even the implied warranty of
>     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
>     GNU General Public License for more details.
> 
>     You should have received a copy of the GNU General Public License
>     along with this program.  If not, see <http://www.gnu.org/licenses/>.
> 
- - - 
