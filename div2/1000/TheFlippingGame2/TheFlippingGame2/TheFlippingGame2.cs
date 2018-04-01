using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlippingGame2 {
    public class TheFlippingGame2 {

        private char[][] FillEmpty(string[] board, bool useWhite) {

            char tile = useWhite ? 'w' : 'b';

            return board.Select(row => {

                return row.Replace('e', tile).ToCharArray();

            }).ToArray();
        }

        private List<int[]> GetBlock(

            char[][] board,
            int row,
            int column,
            Dictionary<int, HashSet<int>> seen,
            List<int[]> block

        ) {

            if(row < 0 || column < 0 || row > board.Length - 1 || column > board[0].Length - 1) {

                return null;
            }

            if((seen.ContainsKey(row) && seen[row].Contains(column)) || (block.Count > 0 && board[row][column] != board[block[0][0]][block[0][1]])) {

                return null;
            }

            if(!seen.ContainsKey(row)) {

                seen[row] = new HashSet<int>();
            }

            seen[row].Add(column);
            block.Add(new int[] { row, column });
            GetBlock(board, row + 1, column, seen, block);
            GetBlock(board, row - 1, column, seen, block);
            GetBlock(board, row, column + 1, seen, block);
            GetBlock(board, row, column - 1, seen, block);

            return block;
        }

        private List<List<int[]>> GetBlocks(char[][] board) {

            var seen = new Dictionary<int, HashSet<int>>();
            var blocks = new List<List<int[]>>();

            for(int i = 0; i < board.Length; i++) {

                for(int j = 0; j < board[i].Length; j++) {

                    if(seen.ContainsKey(i) && seen[i].Contains(j)) {

                        continue;
                    }

                    blocks.Add(GetBlock(board, i, j, seen, new List<int[]>()));
                }
            }

            return blocks;
        }

        private void Flip(char[][] board, int row, int column, char tile) {

            board[row][column] = tile;
        }

        private void FlipBlock(char[][] board, List<int[]> block) {

            char newTile = board[block[0][0]][block[0][1]] == 'b' ? 'w' : 'b';

            foreach(var tile in block) {

                Flip(board, tile[0], tile[1], newTile);
            }
        }

        private int GetSteps(char[][] board, List<int[]> block, int current) {

            int steps = 0;
            int total = board.Length * board[0].Length;

            while(block.Count != total && (current == -1 || steps < current)) {

                steps++;
                FlipBlock(board, block);
                block = GetBlock(board, block[0][0], block[0][1], new Dictionary<int, HashSet<int>>(), new List<int[]>());
            }

            return steps;
        }

        private char[][] CopyBoard(char[][] board) {

            return board.Select(row => row.ToArray()).ToArray();
        }

        private int GetMinSteps(char[][] board) {

            int minStep = -1;

            foreach(var block in GetBlocks(board)) {

                int steps = GetSteps(CopyBoard(board), block, minStep);
                minStep = minStep == -1 ? steps : Math.Min(minStep, steps);
            }

            return minStep;
        }

        public int MinimumMoves(int n, int m, string[] x) {

            var white = FillEmpty(x, true);
            var black = FillEmpty(x, false);
            int minWhite = GetMinSteps(white);
            int minBlack = GetMinSteps(black);

            return 1 + Math.Min(minWhite, minBlack);
        }
    }
}