# AlgortihmPlayground
A place to learn, practice and play around with different algorithms

## Fllod Fill

The flood fill algorithm determines how much of a region is accessible from a given node.

`FloodFill` starts at a given node and explores all of its neighbors. If a neighbor is accessible, it is added to the list of nodes to explore. The algorithm continues until there are no more nodes to explore.

`SentinelFloodFill` is a variation of the flood fill algorithm that creates an artificial edge around the map in order to avoid map boundary searches.
Note: The sentinel edge shoul dbe built into the calling class to avoid losing gains from speed up.

## Minimax

The minimax algorithm is a decision making algorithm used in two player games to determine the next best move, assuming the opponent also plays optimally.

`MiniMax` represents a bare minimum Mini Max search, with no optimisations. It uses the `Connect4` `GameState` class to represent the game state and evaluate the board.  This will be used by all other search algorithms to make comparisons fairer.  

The steps for the algorithm are as follows:
1. Calculate all valid moves using `Connsect4.GameState`.
2. For each valid move, apply the move, recursively call MiniMax with the depth decreased by 1 and the player switched, then undo the move. Applying and undoing moves is handled by `Connect4.GameState`.
3. If the current player is the maximizing player, return the maximum value of the recursive calls. If the current player is the minimizing player, return the minimum value of the recursive calls.
4. If the depth is 0 or the game is over, return the score of the board state.