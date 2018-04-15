using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianPathsInGraph {
    public class HamiltonianPathsInGraph {

        private bool IsConnected(int node1, int node2, string[] edges) {

            return edges[node1][node2] == '+';
        }

        private bool InsertAtStart(int node, string[] edges, List<int> route) {

            if(!IsConnected(node, route.First(), edges)) {

                return false;
            }

            route.Insert(0, node);

            return true;
        }

        private bool InsertAtEnd(int node, string[] edges, List<int> route) {

            if(!IsConnected(route.Last(), node, edges)) {

                return false;
            }

            route.Add(node);

            return true;
        }

        private bool InsertInMiddle(int node, string[] edges, List<int> route) {

            for(int i = 1; i < route.Count; i++) {

                if(IsConnected(route[i - 1], node, edges) && IsConnected(node, route[i], edges)) {

                    route.Insert(i, node);

                    return true;
                }
            }

            return false;
        }

        private bool Insert(int node, string[] edges, List<int> route) {

            if(InsertAtEnd(node, edges, route)) {

                return true;
            }

            if(InsertAtStart(node, edges, route)) {

                return true;
            }

            return InsertInMiddle(node, edges, route);
        }

        public int[] findPath(string[] X) {

            var route = new List<int>() { 0 };
            var nodes = new HashSet<int>(Enumerable.Range(1, X.Length - 1));

            while(nodes.Count > 0) {

                foreach(int node in nodes.ToList()) {

                    if(Insert(node, X, route)) {

                        nodes.Remove(node);
                    }
                }
            }

            return route.ToArray();
        }
    }
}