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

        //check if nodes on given edge is connected to a group of other nodes
        private bool IsConnected(HashSet<int> group, int x, int y) {

            return group.Contains(x) || group.Contains(y);
        }

        //check if nodes on given edge can merge into any group of nodes
        private bool CanMerge(List<HashSet<int>> groups, int x, int y) {

            return groups.Any(group => IsConnected(group, x, y));
        }

        //check if all disconnected groups can be linked together with given amount of edges
        private bool CanLink(List<HashSet<int>> groups, int edges) {

            return groups.Count - 1 <= edges;
        }

        private HashSet<int> Join(IEnumerable<HashSet<int>> groups) {

            var merged = new HashSet<int>();

            foreach(var group in groups) {

                merged.UnionWith(group);
            }

            return merged;
        }

        //merge nodes on edge to another group of nodes and merge groups when applicable
        private List<HashSet<int>> Merge(List<HashSet<int>> groups, int x, int y) {

            var connected = groups.Where(group => IsConnected(group, x, y));
            var disconnected = groups.Where(group => !IsConnected(group, x, y));
            //merge nodes on edge to connected group of nodes
            if(connected.Count() == 1) {

                Add(connected.First(), x, y);

                return groups;
            }
            //merge groups together when nodes on edge is connected to more than one groups of nodes
            groups = disconnected.ToList();
            groups.Add(Join(connected));

            return groups;
        }

        //add uncovered nodes into node group collection as disconnected groups
        private void MergeUncovered(List<HashSet<int>> groups, HashSet<int> uncovered) {

            foreach(int node in uncovered) {

                groups.Add(new HashSet<int>(new int[] { node }));
            }
        }

        //count total ways to link all groups together with nodes between each pair of groups
        private decimal CountTotalLinks(List<HashSet<int>> groups) {

            decimal links = 0;
            var combinations = new List<decimal>();
            //count total number of links between each pair of groups
            for(int i = 0; i < groups.Count - 1; i++) {

                for(int j = i + 1; j < groups.Count; j++) {

                    combinations.Add(groups[i].Count * groups[j].Count);
                }
            }

            for(int i = 0; i < combinations.Count - 1; i++) {

                links += combinations[i] * combinations.Skip(i + 1).Sum();
            }

            return links;
        }

        public int getNumberOfSpanningTrees(int n, int[] x, int[] y) {

            var groups = new List<HashSet<int>>() { new HashSet<int>(new int[] { x[0], y[0] }) };
            var nodes = new HashSet<int>(Enumerable.Range(1, n));
            Remove(nodes, x[0], y[0]);

            for(int i = 1; i < x.Length; i++) {

                Remove(nodes, x[i], y[i]);
                //create new disconnected group when merging is not possible
                if(!CanMerge(groups, x[i], y[i])) {

                    groups.Add(new HashSet<int>(new int[] { x[i], y[i] }));

                    continue;
                }

                groups = Merge(groups, x[i], y[i]);
            }
            //include covered nodes
            MergeUncovered(groups, nodes);

            if(!CanLink(groups, n - 1 - x.Length)) {

                return 0;
            }

            return (int)(CountTotalLinks(groups) % 987654323);
        }
    }
}