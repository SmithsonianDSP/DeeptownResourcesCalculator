**[< < Back](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/)**  
## Total Time to Produce Required Subcomponents:

| **#**  	| **Resource**   	| **Production Time Req'd** 	|
|----	|-------------------	|---------------------------------	|
| 1  	| Plastic           	| 18 hours, 3 minutes, 17 seconds 	|
| 2  	| Solar panel       	| 5 hours, 5 minutes              	|
| 3  	| Refined oil       	| 3 hours, 46 minutes, 20 seconds 	|
| 4  	| Motherboard       	| 2 hours, 47 minutes, 27 seconds 	|
| 5  	| Solid propellant  	| 2 hours, 7 minutes, 26 seconds  	|
| 6  	| Accumulator       	| 1 hour, 23 minutes              	|
| 7  	| Ethanol           	| 1 hour, 6 minutes, 31 seconds   	|
| 8  	| Sulfuric acid     	| 50 minutes, 24 seconds          	|
| 9  	| Circuit           	| 43 minutes, 23 seconds          	|
| 10 	| Liana             	| 38 minutes                      	|
| 11 	| Rubber            	| 34 minutes                      	|
| 12 	| Oxygen            	| 31 minutes, 24 seconds          	|
| 13 	| Diamond cutter    	| 27 minutes, 27 seconds          	|
| 14 	| Grapes            	| 18 minutes                      	|
| 15 	| Clean water       	| 16 minutes, 24 seconds          	|
| 16 	| Hydrogen          	| 15 minutes, 42 seconds          	|
| 17 	| Steel plate       	| 13 minutes, 47 seconds          	|
| 18 	| Lamp              	| 13 minutes, 6 seconds           	|
| 19 	| Emerald ring      	| 7 minutes, 5 seconds            	|
| 20 	| Lab flask         	| 6 minutes                       	|
| 21 	| Battery           	| 5 minutes, 35 seconds           	|
| 22 	| Glass             	| 5 minutes                       	|
| 23 	| Insulated wire    	| 4 minutes, 58 seconds           	|
| 24 	| Amber bracelet    	| 4 minutes, 19 seconds           	|
| 25 	| Green laser       	| 3 minutes, 50 seconds           	|
| 26 	| Wood              	| 3 minutes, 24 seconds           	|
| 27 	| Oil               	| 3 minutes, 20 seconds           	|
| 28 	| Polished diamond  	| 2 minutes, 38 seconds           	|
| 29 	| Polished sapphire 	| 2 minutes, 38 seconds           	|
| 30 	| Steel bar         	| 2 minutes, 21 seconds           	|
| 31 	| Sulfur            	| 2 minutes                       	|
| 32 	| Sodium            	| 2 minutes                       	|
| 33 	| Silicon           	| 2 minutes                       	|
| 34 	| Polished topaz    	| 1 minute, 58 seconds            	|
| 35 	| Polished amethyst 	| 1 minute, 47 seconds            	|
| 36 	| Platinum          	| 1 minute, 40 seconds            	|
| 37 	| Silver bar        	| 1 minute, 32 seconds            	|
| 38 	| Amber insulation  	| 1 minute, 26 seconds            	|
| 39 	| Gold bar          	| 1 minute, 17 seconds            	|
| 40 	| Polished ruby     	| 1 minute, 17 seconds            	|
| 41 	| Iron bar          	| 1 minute, 13 seconds            	|
| 42 	| Polished amber    	| 47 seconds                      	|
| 43 	| Polished emerald  	| 47 seconds                      	|
| 44 	| Aluminum bar      	| 32 seconds                      	|
| 45 	| Aluminum bottle   	| 31 seconds                      	|
| 46 	| Copper bar        	| 27 seconds                      	|
| 47 	| Water             	| 24 seconds                      	|
| 48 	| Graphite          	| 22 seconds                      	|
| 49 	| Sapphire          	| 19 seconds                      	|
| 50 	| Diamond           	| 19 seconds                      	|
| 51 	| Iron ore          	| 11 seconds                      	|
| 52 	| Topaz             	| 11 seconds                      	|
| 53 	| Copper wire       	| 11 seconds                      	|
| 54 	| Amethyst          	| 9 seconds                       	|
| 55 	| Amber charger     	| 8 seconds                       	|
| 56	| Silver ore            | 6 seconds                       	|
| 57	| Charcoal              | 5 seconds                       	|
| 58	| Copper nails          | 4 seconds                       	|
| 59	| Coal                  | 3 seconds                       	|
| 60	| Amber                 | 3 seconds                       	|
| 61	| Copper ore            | 3 seconds                       	|
| 62	| Aluminum ore          | 3 seconds                       	|
| 63	| Gold ore              | 3 seconds                       	|
| 64	| Emerald               | 3 seconds                       	|
| 65	| Ruby                  | 3 seconds                       	|

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