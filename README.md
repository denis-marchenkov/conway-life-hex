# Conway's "Life" On Hex Grid
<br/>
  
<br/>
Variation of Conway's game of "Life" on a hexagonal grid with multiple competing cell types.

<br/><br/>

## Description:

Simple windows forms application since I was mainly focused on understanding hexagonal grid coordinates, "life" implementation just naturally came along.

<br/><br/>

Rules are modified a bit to reflect competing cell types and hexagonal greed structure:

* Any live cell with less than two live neighbours of its type dies of underpopulation;
* any live cell with more than three live neighbours of any type dies of overpopulation;
* any live cell with two or three neighbours of the same type survives to the next generation;
* any dead cell with two live neighbours of the same type becomes live cell, if there are other pairs (or more) cells with different types around it - it stays dead.
