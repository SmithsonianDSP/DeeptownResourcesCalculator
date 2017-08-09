**[< < Back](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/)**  
## Total Time to Produce Required Subcomponents:

| **#**| **Resource**             | **Production Time Req'd**               |
| ----:|------------------        |--------------------------------         |
| 1    | Solar panel              | 5 hours, 5 minutes                      |
| 2    | Plastic                  | 4 hours, 3 minutes, 10 seconds          |
| 3    | Refined oil              | 3 hours, 46 minutes, 20 seconds         |
| 4    | Motherboard              | 2 hours, 47 minutes, 27 seconds         |
| 5    | Uranium rod              | 2 hours, 26 minutes, 45 seconds         |
| 6    | Solid propellant         | 2 hours, 7 minutes, 26 seconds          |
| 7    | Bomb                     | 2 hours, 5 minutes, 41 seconds          |
| 8    | Diethyl ether            | 1 hour, 58 minutes, 11 seconds          |
| 9    | Accumulator              | 1 hour, 23 minutes                      |
| 10   | Ethanol                  | 1 hour, 6 minutes, 47 seconds           |
| 11   | Sulfuric acid            | 50 minutes, 24 seconds                  |
| 12   | Circuit                  | 43 minutes, 23 seconds                  |
| 13   | Haircomb                 | 41 minutes, 45 seconds                  |
| 14   | Liana                    | 38 minutes                              |
| 15   | Gear                     | 35 minutes, 58 seconds                  |
| 16   | Rubber                   | 34 minutes                              |
| 17   | Oxygen                   | 31 minutes, 24 seconds                  |
| 18   | Diamond cutter           | 27 minutes, 27 seconds                  |
| 19   | Grapes                   | 18 minutes                              |
| 20   | Maya calendar            | 17 minutes                              |
| 21   | Clean water              | 16 minutes, 24 seconds                  |
| 22   | Hydrogen                 | 15 minutes, 42 seconds                  |
| 23   | Steel plate              | 13 minutes, 47 seconds                  |
| 24   | Lamp                     | 13 minutes, 6 seconds                   |
| 25   | Gunpowder                | 11 minutes, 23 seconds                  |
| 26   | Titanium bar             | 7 minutes, 10 seconds                   |
| 27   | Emerald ring             | 7 minutes, 5 seconds                    |
| 28   | Lab flask                | 6 minutes                               |
| 29   | Battery                  | 5 minutes, 35 seconds                   |
| 30   | Insulated wire           | 5 minutes, 14 seconds                   |
| 31   | Glass                    | 5 minutes                               |
| 32   | Amber bracelet           | 4 minutes, 19 seconds                   |
| 33   | Green laser              | 3 minutes, 53 seconds                   |
| 34   | Wood                     | 3 minutes, 24 seconds                   |
| 35   | Oil                      | 3 minutes, 20 seconds                   |
| 36   | Polished diamond         | 2 minutes, 38 seconds                   |
| 37   | Polished sapphire        | 2 minutes, 38 seconds                   |
| 38   | Steel bar                | 2 minutes, 21 seconds                   |
| 39   | Sulfur                   | 2 minutes                               |
| 40   | Sodium                   | 2 minutes                               |
| 41   | Silicon                  | 2 minutes                               |
| 42   | Polished topaz           | 1 minute, 58 seconds                    |
| 43   | Polished alexandrite     | 1 minute, 58 seconds                    |
| 44   | Amber insulation         | 1 minute, 42 seconds                    |
| 45   | Platinum                 | 1 minute, 40 seconds                    |
| 46   | Silver bar               | 1 minute, 32 seconds                    |
| 47   | Gold bar                 | 1 minute, 17 seconds                    |
| 48   | Polished amethyst        | 1 minute, 17 seconds                    |
| 49   | Polished ruby            | 1 minute, 17 seconds                    |
| 50   | Titanium                 | 1 minute, 14 seconds                    |
| 51   | Iron bar                 | 1 minute, 13 seconds                    |
| 52   | Polished amber           | 47 seconds                              |
| 53   | Polished emerald         | 47 seconds                              |
| 54   | Aluminum bottle          | 47 seconds                              |
| 55   | Aluminum bar             | 32 seconds                              |
| 56   | Copper bar               | 27 seconds                              |
| 57   | Water                    | 24 seconds                              |
| 58   | Graphite                 | 22 seconds                              |
| 59   | Uranium ore              | 22 seconds                              |
| 60   | Sapphire                 | 19 seconds                              |
| 61   | Diamond                  | 19 seconds                              |
| 62   | Iron ore                 | 11 seconds                              |
| 63   | Topaz                    | 11 seconds                              |
| 64   | Alexandrite              | 11 seconds                              |
| 65   | Copper wire              | 11 seconds                              |
| 66   | Amber charger            | 8 seconds                               |
| 67   | Titanium ore             | 6 seconds                               |
| 68   | Silver ore               | 6 seconds                               |
| 69   | Charcoal                 | 5 seconds                               |
| 70   | Copper nails             | 4 seconds                               |
| 71   | Coal                     | 3 seconds                               |
| 72   | Amber                    | 3 seconds                               |
| 73   | Copper ore               | 3 seconds                               |
| 74   | Aluminum ore             | 3 seconds                               |
| 75   | Gold ore                 | 3 seconds                               |
| 76   | Emerald                  | 3 seconds                               |
| 77   | Ruby                     | 3 seconds                               |
| 78   | Amethyst                 | 3 seconds                               |

- - -

#### Calculation Footnotes

**The purpose of this is *NOT* to ACCURATELY reflect the amount of REAL-TIME required to produce a resource,** 
but to *show how resources compare to others.*

1. For base resources (e.g., coal, iron ore, diamonds), the `TimeToProduce` value is the time it takes to
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
 
2. All production rates assume ***online mining*** speeds, ***no crystal boosts***, and ***no drone boosts***.  

3. **Simultaneous production is NOT considered in durations**. When looking at the "time to produce subcomponents" for a
  resource, this value is essentially the amount of time it would take if you could only be doing one action
  at any given time (e.g., first you must mine the base ore, then smelt it into bars one at a time, etc.)

- - - 