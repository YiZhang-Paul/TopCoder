using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamiltonianPathsInGraph {
    public class HamiltonianPathsInGraph {

        private bool IsConnected(int node1, int node2, string[] X) {

            return X[node1][node2] == '+';
        }

        private bool InsertAtStart(int node, string[] X, List<int> route) {

            if(!IsConnected(node, route.First(), X)) {

                return false;
            }

            route.Insert(0, node);

            return true;
        }

        private bool InsertAtEnd(int node, string[] X, List<int> route) {

            if(!IsConnected(route.Last(), node, X)) {

                return false;
            }

            route.Add(node);

            return true;
        }

        private bool InsertInMiddle(int node, string[] X, List<int> route) {

            for(int i = 1; i < route.Count; i++) {

                if(IsConnected(route[i - 1], node, X) && IsConnected(node, route[i], X)) {

                    route.Insert(i, node);

                    return true;
                }
            }

            return false;
        }

        private bool Insert(int node, string[] X, List<int> route) {

            if(InsertAtEnd(node, X, route)) {

                return true;
            }

            if(InsertAtStart(node, X, route)) {

                return true;
            }

            return InsertInMiddle(node, X, route);
        }

        public int[] findPath(string[] X) {

            var route = X[0][1] == '+' ? new List<int>() { 0, 1 } : new List<int>() { 1, 0 };
            var others = new HashSet<int>(Enumerable.Range(2, X.Length - 2));

            while(others.Count > 0) {

                foreach(int node in others.ToList()) {

                    if(Insert(node, X, route)) {

                        others.Remove(node);
                    }
                }
            }

            return route.ToArray();
        }
    }
}