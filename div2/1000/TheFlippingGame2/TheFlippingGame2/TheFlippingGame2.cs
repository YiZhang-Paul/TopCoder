using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlippingGame2 {
    public class TheFlippingGame2 {

        private Dictionary<int, HashSet<int>> Visited { get; set; }

        //fill all empty tiles on board
        private char[][] FillBoard(string[] board, bool useWhite) {

            char tile = useWhite ? 'w' : 'b';

            return board.Select(row => {

                return row.Replace('e', tile).ToCharArray();

            }).ToArray();
        }

        //check if given row and column exist on board
        private bool IsOutOfBound(char[][] board, int row, int column) {

            if(row < 0 || row > board.Length - 1) {

                return true;
            }

            if(column < 0 || column > board[0].Length - 1) {

                return true;
            }

            return false;
        }

        private bool IsVisited(int row, int column) {

            if(!Visited.ContainsKey(row)) {

                return false;
            }

            return Visited[row].Contains(column);
        }

        private void AddVisited(int row, int column) {

            if(!Visited.ContainsKey(row)) {

                Visited[row] = new HashSet<int>();
            }

            Visited[row].Add(column);
        }

        //find a block of interconnected tiles
        private List<int[]> FindBlock(char[][] board, int row, int column, List<int[]> block) {

            if(IsOutOfBound(board, row, column) || IsVisited(row, column)) {

                return null;
            }

            char tile = board[row][column];

            if(block.Count > 0 && tile != board[block[0][0]][block[0][1]]) {

                return null;
            }

            AddVisited(row, column);
            block.Add(new int[] { row, column });

            FindBlock(board, row + 1, column, block);
            FindBlock(board, row - 1, column, block);
            FindBlock(board, row, column + 1, block);
            FindBlock(board, row, column - 1, block);

            return block;
        }

        //find all blocks of interconnected tiles
        private List<List<int[]>> FindBlocks(char[][] board) {

            Visited = new Dictionary<int, HashSet<int>>();
            var blocks = new List<List<int[]>>();

            for(int i = 0; i < board.Length; i++) {

                for(int j = 0; j < board[i].Length; j++) {

                    if(IsVisited(i, j)) {

                        continue;
                    }

                    blocks.Add(FindBlock(board, i, j, new List<int[]>()));
                }
            }

            return blocks;
        }

        private void FlipBlock(char[][] board, List<int[]> block) {

            char tile = board[block[0][0]][block[0][1]] == 'b' ? 'w' : 'b';

            foreach(var grid in block) {

                board[grid[0]][grid[1]] = tile;
            }
        }

        //count total steps to win a game by continuously flipping a block of tiles
        private int CountSteps(char[][] board, List<int[]> block, int minStep) {

            int steps = 0;
            int totalGrids = board.Length * board[0].Length;

            while(block.Count != totalGrids && (minStep < 0 || steps < minStep)) {

                FlipBlock(board, block);
                Visited.Clear();
                block = FindBlock(board, block[0][0], block[0][1], new List<int[]>());
                steps++;
            }

            return steps;
        }

        private char[][] CopyBoard(char[][] board) {

            return board.Select(row => row.ToArray()).ToArray();
        }

        public int MinimumMoves(int n, int m, string[] x) {

            int minStep = -1;
            var boards = new List<char[][]>() { FillBoard(x, true), FillBoard(x, false) };

            foreach(var board in boards) {

                foreach(var block in FindBlocks(board)) {

                    int steps = CountSteps(CopyBoard(board), block, minStep);
                    minStep = minStep == -1 ? steps : Math.Min(minStep, steps);
                }
            }

            return minStep + 1;
        }
    }
}