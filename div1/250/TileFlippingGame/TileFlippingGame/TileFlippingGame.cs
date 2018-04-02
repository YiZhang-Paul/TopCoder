using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TileFlippingGame {
    public class TileFlippingGame {

        private Dictionary<int, HashSet<int>> Visited { get; set; }
        private char[][] Board { get; set; }

        private void GetBoard(string[] x) {

            Board = x.Select(row => row.ToCharArray()).ToArray();
        }

        private List<int[]> GetAllGrids() {

            var grids = new List<int[]>();

            for(int i = 0; i < Board.Length; i++) {

                for(int j = 0; j < Board[0].Length; j++) {

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

        private bool IsEmpty(int row, int column) {

            return Board[row][column] == 'e';
        }

        private bool IsOutOfBound(int row, int column) {

            if(row < 0 || row > Board.Length - 1) {

                return true;
            }

            if(column < 0 || column > Board[0].Length - 1) {

                return true;
            }

            return false;
        }

        private void AddVisited(int row, int column) {

            if(!Visited.ContainsKey(row)) {

                Visited[row] = new HashSet<int>();
            }

            Visited[row].Add(column);
        }

        private List<int[]> FindBlock(char[][] board, int row, int column, List<int[]> block, bool useSeparator) {

            if(IsOutOfBound(row, column) || IsVisited(row, column) || IsEmpty(row, column)) {

                return null;
            }

            if(block.Count > 0 && useSeparator && board[row][column] != board[block[0][0]][block[0][1]]) {

                return null;
            }

            AddVisited(row, column);
            block.Add(new int[] { row, column });

            FindBlock(board, row + 1, column, block, useSeparator);
            FindBlock(board, row - 1, column, block, useSeparator);
            FindBlock(board, row, column + 1, block, useSeparator);
            FindBlock(board, row, column - 1, block, useSeparator);

            return block;
        }

        private List<List<int[]>> FindBlocks(char[][] board, List<int[]> grids, bool useSeparator) {

            Visited = new Dictionary<int, HashSet<int>>();
            var blocks = new List<List<int[]>>();

            foreach(var grid in grids) {

                if(IsVisited(grid[0], grid[1]) || IsEmpty(grid[0], grid[1])) {

                    continue;
                }

                blocks.Add(FindBlock(board, grid[0], grid[1], new List<int[]>(), useSeparator));
            }

            return blocks;
        }

        private void FlipBlock(char[][] board, List<int[]> block) {

            char tile = board[block[0][0]][block[0][1]] == 'b' ? 'w' : 'b';

            foreach(var grid in block) {

                board[grid[0]][grid[1]] = tile;
            }
        }

        private int CountSteps(char[][] board, List<int[]> block, int total, ref char result) {

            int steps = 0;

            while(block.Count != total) {

                steps++;
                FlipBlock(board, block);
                Visited.Clear();
                block = FindBlock(board, block[0][0], block[0][1], new List<int[]>(), true);
            }

            result = board[block[0][0]][block[0][1]];

            return steps;
        }

        private char[][] CopyBoard() {

            return Board.Select(row => row.ToArray()).ToArray();
        }

        private int[] GetMinSteps(List<int[]> block) {

            int black = -1;
            int white = -1;

            foreach(var subBlock in FindBlocks(Board, block, true)) {

                char result = '\0';
                int steps = CountSteps(CopyBoard(), subBlock, block.Count, ref result);

                if(result == 'b') {

                    black = black == -1 ? steps : Math.Min(black, steps);
                }
                else {

                    white = white == -1 ? steps : Math.Min(white, steps);
                }
            }

            black = black == -1 ? white + 1 : black;
            white = white == -1 ? black + 1 : white;

            return new int[] { black, white };
        }

        public int HowManyMoves(int n, int m, string[] x) {

            GetBoard(x);
            var blocks = FindBlocks(Board, GetAllGrids(), false);
            var steps = blocks.Select(block => GetMinSteps(block));

            return Math.Min(steps.Sum(step => step[0]), steps.Sum(step => step[1]));
        }
    }
}