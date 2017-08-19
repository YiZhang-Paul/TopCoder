/* jslint esversion: 6 */
(() => {
	document.addEventListener("DOMContentLoaded", () => {
		/**
		 * check if destination is reached
		 * @param {Object} [curNode] - current node
		 * @param {Object} [destination] - destination node
		 *
		 * @return {boolean} [test result] 
		 */
		function atDestination(curNode, destination) {
			return curNode.row == destination.row && curNode.col == destination.col;
		}
		/**
		 * get all adjacent grids
		 * @param {Object} [curNode] - current node
		 * @param {int} [maxRow] - maximum row available
		 * @param {Array} [visited] - nodes already visited
		 *
		 * @return {Array} [adjacent nodes]
		 */
		function getAdjacentNode(curNode, maxRow, visited) {
			let adjacent = [{row : curNode.row, col : curNode.col + 1}];
			if(curNode.row - 1 >= 0) adjacent.push({row : curNode.row - 1, col : curNode.col});
			if(curNode.row + 1 <= maxRow) adjacent.push({row : curNode.row + 1, col : curNode.col});
			if(curNode.col - 1 >= 0) adjacent.push({row : curNode.row, col : curNode.col - 1});  
			return adjacent.filter(node => visited.every(pastNode => pastNode.row != node.row || pastNode.col != node.col));
		}
		/**
		 * calculate weight for each node
		 * @param {Object} [candidate] - candidate node
		 * @param {Object} [destination] - destination node
		 * @param {Array} [times] - time spend for all nodes
		 *
		 * @return {float} [node weight]
		 */
		function getWeight(candidate, destination, times) {
			let rowDiff = Math.abs(candidate.row - destination.row);
			let colDiff = Math.abs(candidate.col - destination.col);
			let hDistance = !rowDiff ? colDiff * times[candidate.row] : colDiff * Math.min(times[candidate.row], times[destination.row]);
			let vDistance = !rowDiff ? 0 : times.slice(candidate.row, candidate.row + rowDiff).reduce((acc, val) => acc + val);
			return hDistance + vDistance;
		}
		/**
		 * find best nodes locally available with lowest weight
		 * @param {Array} [nodes] - nodes to be evaluated
		 * @param {Object} [destination] - destination node
		 * @param {Array} [times] - time spend for all nodes
		 *
		 * @return {Object} [best node]
		 */
		function getBestNode(nodes, destination, times) {
			return nodes.reduce((curBest, next) => 
				getWeight(curBest, destination, times) > getWeight(next, destination, times) ? next : curBest);
		}
		/**
		 * check if destination can be reached
		 * @param {Array} [adjacent] - all adjacent nodes
		 * @param {Object} [destination] - destination node
		 *
		 * @return {boolean} [test result]
		 */
		function canReachEnd(adjacent, destination) {
			return adjacent.some(node => atDestination(node, destination));
		}
		/**
		 * find path
		 * @param {Array} [times] - times spend on cells on each row
		 * @param {int} [startRow] - starting row
		 * @param {int} [startCol] - starting column
		 * @param {int} [endRow] - ending row
		 * @param {int} [endCol] - ending column
		 *
		 * @return {Array} [total time spent and path]
		 */
		function findPath(times, startRow, startCol, endRow, endCol) {
			let [path, visited] = [[{row : startRow, col : startCol}], [{row : startRow, col : startCol}]];
			let [curNode, destination] = [path[path.length - 1], {row : endRow, col : endCol}];
			while(!atDestination(curNode, destination)) {
				let adjacent = getAdjacentNode(curNode, times.length - 1, visited);
				let bestNode = canReachEnd(adjacent, destination) ? destination : getBestNode(adjacent, destination, times);
				path.push(bestNode);
				visited.push(bestNode);
				curNode = bestNode;
			}
			return [path, path.reduce((acc, val) => acc + times[val.row], 0)];
		}
		console.log(findPath([5, 3, 10], 2, 0, 2, 2));
		console.log(findPath([5, 3, 10], 0, 2, 0, 0));
		console.log(findPath([137, 200, 184, 243, 252, 113, 162], 0, 2, 4, 2));
		console.log(findPath([995, 996, 1000, 997, 999, 1000, 997, 996, 1000, 996, 1000, 997, 999, 996, 1000, 998, 999, 995, 995, 998, 995, 998, 995, 997, 998, 996, 998, 996, 997, 1000, 998, 997, 995, 1000, 996, 997, 1000, 997, 997, 999, 998, 995, 999, 999, 1000, 1000, 998, 997, 995, 999], 18, 433156521, 28, 138238863));	
		console.log(findPath([1], 0, 0, 0, 0));
	});
})();