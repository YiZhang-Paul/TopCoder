using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileFlippingGame {
    public class TileFlippingGame {

        private Dictionary<int, HashSet<int>> Visited { get; set; }

        private char[][] GetBoard(string[] x) {

            return x.Select(row => {

                return row.ToCharArray();

            }).ToArray();
        }

        //retrieve all grids on a board
        private List<int[]> GetGrids(char[][] board) {

            var grids = new List<int[]>();

            for(int i = 0; i < board.Length; i++) {

                for(int j = 0; j < board[0].Length; j++) {

                    grids.Add(new int[] { i, j });
                }
            }

            return grids;
        }

        private bool IsVisited(int row, int column) {

            if(!Visited.ContainsKey(row)) {

                return false;
            }

            return Visited[row].Contains(column);
        }

        private bool IsEmpty(char[][] board, int row, int column) {

            return board[row][column] == 'e';
        }

        //check if given grid is within board boundary
        private bool IsOutOfBound(char[][] board, int row, int column) {

            if(row < 0 || row > board.Length - 1) {

                return true;
            }

            if(column < 0 || column > board[0].Length - 1) {

                return true;
            }

            return false;
        }

        //check if given grid is unvisited non empty grid
        private bool IsValidGrid(char[][] board, int row, int column) {

            if(IsOutOfBound(board, row, column)) {

                return false;
            }

            return !IsVisited(row, column) && !IsEmpty(board, row, column);
        }

        private void AddVisited(int row, int column) {

            if(!Visited.ContainsKey(row)) {

                Visited[row] = new HashSet<int>();
            }

            Visited[row].Add(column);
        }

        /*
         * get block of non empty grids that are adjacent to each other;
         * only get grids of same color when separate is set to true
         */
        private List<int[]> GetBlock(char[][] board, int row, int column, List<int[]> block, bool separate) {

            if(!IsValidGrid(board, row, column)) {

                return null;
            }

            if(block.Count > 0 && separate) {

                if(board[row][column] != board[block[0][0]][block[0][1]]) {

                    return null;
                }
            }

            AddVisited(row, column);
            block.Add(new int[] { row, column });

            GetBlock(board, row + 1, column, block, separate);
            GetBlock(board, row - 1, column, block, separate);
            GetBlock(board, row, column + 1, block, separate);
            GetBlock(board, row, column - 1, block, separate);

            return block;
        }

        private List<List<int[]>> GetBlocks(char[][] board, List<int[]> grids, bool separate) {

            Visited = new Dictionary<int, HashSet<int>>();
            var blocks = new List<List<int[]>>();

            foreach(var grid in grids) {

                if(IsVisited(grid[0], grid[1]) || IsEmpty(board, grid[0], grid[1])) {

                    continue;
                }

                blocks.Add(GetBlock(board, grid[0], grid[1], new List<int[]>(), separate));
            }

            return blocks;
        }

        //flip all grids in a block
        private void Flip(char[][] board, List<int[]> block) {

            char tile = board[block[0][0]][block[0][1]] == 'b' ? 'w' : 'b';

            foreach(var grid in block) {

                board[grid[0]][grid[1]] = tile;
            }
        }

        private char[][] CopyBoard(char[][] board) {

            return board.Select(row => row.ToArray()).ToArray();
        }

        //count total steps needed to flip a block until all tiles have same color
        private int CountSteps(char[][] board, List<int[]> block, int total, ref char result) {

            int steps = 0;

            while(block.Count != total) {

                steps++;
                Flip(board, block);
                Visited.Clear();
                block = GetBlock(board, block[0][0], block[0][1], new List<int[]>(), true);
            }

            result = board[block[0][0]][block[0][1]];

            return steps;
        }

        //count minimum steps needed to make all tiles in a block have same color
        private int[] CountMinSteps(char[][] board, List<int[]> block) {

            int black = -1; //steps needed to make all tiles black
            int white = -1; //steps needed to make all tiles white

            foreach(var subBlock in GetBlocks(board, block, true)) {

                char result = '\0'; //resulting color
                int steps = CountSteps(CopyBoard(board), subBlock, block.Count, ref result);

                if(result == 'b') {

                    black = black == -1 ? steps : Math.Min(black, steps);
                }
                else {

                    white = white == -1 ? steps : Math.Min(white, steps);
                }
            }
            //-1 means the block must be flipped one more time to get given color
            black = black == -1 ? white + 1 : black;
            white = white == -1 ? black + 1 : white;

            return new int[] { black, white };
        }

        public int HowManyMoves(int n, int m, string[] x) {

            var board = GetBoard(x);
            var blocks = GetBlocks(board, GetGrids(board), false);
            var steps = blocks.Select(block => CountMinSteps(board, block));

            return Math.Min(steps.Sum(step => step[0]), steps.Sum(step => step[1]));
        }
    }
}