**[< < Back](https://smithsoniandsp.github.io/DeeptownResourcesCalculator/)**  

## Most Profit (Over Value of Subcomponents):
#### `[Coin Value]` - `[Sum of subcomponent value]`

**Notes:** 

1. The `ProfitMargin` value is not the *true* profit margin; it is the coin value of the given resource
  compared to the coin value of the base subcomponents required to produce it.  
   * **Example:** a copper bar is `25` coin and requires `5` copper ore (worth `2` coin/ea) to produce , so the 
  `ProfitMargin` for a copper bar is: `25 - (5 * 2) = 15`.  

2. This calculation is **recursive**, in that it doesn't use the *coin value* of the subcomponents, but instead it 
   sums the values of all subcomponent's `SumOfSubcomponentValues`, which continues downward until the value
   of the raw, base materials is returned.  
   &nbsp;  


| **#**| **Resource**             | **Profit Margin**                       |
| ----:|------------------        |-------------------------------:         |
| 1    | Solar panel              | 57,450                                  |
| 2    | Bomb                     | 54,136                                  |
| 3    | Plastic                  | 38,456                                  |
| 4    | Solid propellant         | 25,100                                  |
| 5    | Gear                     | 17,720                                  |
| 6    | Diethyl ether            | 15,295                                  |
| 7    | Refined oil              | 15,065                                  |
| 8    | Motherboard              | 14,850                                  |
| 9    | Uranium rod              | 9,800                                   |
| 10   | Maya calendar            | 5,430                                   |
| 11   | Accumulator              | 5,000                                   |
| 12   | Diamond cutter           | 4,450                                   |
| 13   | Haircomb                 | 3,665                                   |
| 14   | Rubber                   | 3,450                                   |
| 15   | Sulfuric acid            | 3,095                                   |
| 16   | Ethanol                  | 2,900                                   |
| 17   | Titanium bar             | 2,770                                   |
| 18   | Gunpowder                | 2,374                                   |
| 19   | Steel plate              | 1,700                                   |
| 20   | Circuit                  | 1,470                                   |
| 21   | Clean water              | 995                                     |
| 22   | Grapes                   | 863                                     |
| 23   | Oxygen                   | 695                                     |
| 24   | Insulated wire           | 683                                     |
| 25   | Lab flask                | 600                                     |
| 26   | Liana                    | 600                                     |
| 27   | Lamp                     | 590                                     |
| 28   | Green laser              | 341                                     |
| 29   | Emerald ring             | 340                                     |
| 30   | Hydrogen                 | 298                                     |
| 31   | Glass                    | 250                                     |
| 32   | Amber bracelet           | 225                                     |
| 33   | Titanium                 | 214                                     |
| 34   | Polished diamond         | 210                                     |
| 35   | Gold bar                 | 200                                     |
| 36   | Wood                     | 186                                     |
| 37   | Polished alexandrite     | 175                                     |
| 38   | Polished ruby            | 175                                     |
| 39   | Polished amethyst        | 170                                     |
| 40   | Silver bar               | 165                                     |
| 41   | Steel bar                | 160                                     |
| 42   | Polished sapphire        | 150                                     |
| 43   | Battery                  | 131                                     |
| 44   | Polished topaz           | 130                                     |
| 45   | Polished emerald         | 100                                     |
| 46   | Amber insulation         | 60                                      |
| 47   | Polished amber           | 50                                      |
| 48   | Aluminum bottle          | 30                                      |
| 49   | Aluminum bar             | 25                                      |
| 50   | Iron bar                 | 25                                      |
| 51   | Copper bar               | 15                                      |
| 52   | Graphite                 | 10                                      |
| 53   | Copper nails             | 6                                       |
| 54   | Copper wire              | 3                                       |

- - -

### **Zero Cost (all profit)**:

|              |              |              |              |
|--------------|--------------|--------------|--------------|
| Coal         | Copper Ore   | Iron Ore     | Amber        |
| Water        | Aluminum Ore | Silver Ore   | Gold Ore     |
| Emerald      | Platinum     | Topaz        | Ruby         |
| Sapphire     | Diamond      | Amethyst     | Titanium Ore |
| Alexandrite  | Oil          | Uranium Ore  | Sulfur       |
| Sodium       | Silicon      |              |              | 

- - - 

### **Zero (or negative) Values**:

|               |               |
|---------------|---------------|
| Charcoal      | Amber Charger |
