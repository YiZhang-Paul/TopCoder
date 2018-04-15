using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingSpanningTreesDiv2 {
    public class BuildingSpanningTreesDiv2 {

        private void Add(HashSet<int> nodes, int node1, int node2) {

            nodes.Add(node1);
            nodes.Add(node2);
        }

        private void Remove(HashSet<int> nodes, int node1, int node2) {

            nodes.Remove(node1);
            nodes.Remove(node2);
        }

        private bool IsConnected(HashSet<int> group, int x, int y) {

            return group.Contains(x) || group.Contains(y);
        }

        private bool CanMerge(List<HashSet<int>> groups, int x, int y) {

            return groups.Any(group => IsConnected(group, x, y));
        }

        private bool CanLink(List<HashSet<int>> groups, int maxGroups) {

            return groups.Count <= maxGroups;
        }

        private decimal CountTotalTrees(List<HashSet<int>> groups) {

            decimal total = 0;
            var combinations = new List<decimal>();

            for(int i = 0; i < groups.Count - 1; i++) {

                for(int j = i + 1; j < groups.Count; j++) {

                    combinations.Add(groups[i].Count * groups[j].Count);
                }
            }

            for(int i = 0; i < combinations.Count - 1; i++) {

                total += combinations[i] * combinations.Skip(i + 1).Sum();
            }

            return total;
        }

        private List<HashSet<int>> Merge(List<HashSet<int>> groups, int x, int y) {

            var connected = groups.Where(group => IsConnected(group, x, y));
            var disconnected = groups.Where(group => !IsConnected(group, x, y));

            if(connected.Count() == 1) {

                Add(connected.First(), x, y);

                return groups;
            }

            var merged = new HashSet<int>();

            foreach(var group in connected) {

                merged.UnionWith(group);
            }

            groups = disconnected.ToList();
            groups.Add(merged);

            return groups;
        }

        private void MergeUnused(List<HashSet<int>> groups, HashSet<int> unused) {

            foreach(int node in unused) {

                groups.Add(new HashSet<int>(new int[] { node }));
            }
        }

        public int getNumberOfSpanningTrees(int n, int[] x, int[] y) {

            var groups = new List<HashSet<int>>() { new HashSet<int>(new int[] { x[0], y[0] }) };
            var nodes = new HashSet<int>(Enumerable.Range(1, n));
            Remove(nodes, x[0], y[0]);

            for(int i = 1; i < x.Length; i++) {

                Remove(nodes, x[i], y[i]);

                if(!CanMerge(groups, x[i], y[i])) {

                    groups.Add(new HashSet<int>(new int[] { x[i], y[i] }));

                    continue;
                }

                groups = Merge(groups, x[i], y[i]);
            }

            MergeUnused(groups, nodes);

            if(!CanLink(groups, n - x.Length)) {

                return 0;
            }

            return (int)(CountTotalTrees(groups) % 987654323);
        }
    }
}