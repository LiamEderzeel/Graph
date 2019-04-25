using System;
using System.Collections;
using System.Collections.Generic;

namespace Graph {
	public class Graph<T> : IEnumerable {

		IEnumerator IEnumerable.GetEnumerator() {
			return (IEnumerator<T>)GetEnumerator();
		}

		public GraphEnumerator<T> GetEnumerator() {
			return new GraphEnumerator<T>(nodeSet);
		}
		private NodeList<T> nodeSet;


		public Graph() : this(null) { }
		public Graph(NodeList<T> nodeSet) {
			if(nodeSet == null)
				this.nodeSet = new NodeList<T>();
			else
				this.nodeSet = nodeSet;
		}

		public void AddNode(GraphNode<T> node) {
			nodeSet.Add(node);
		}

		public void AddNode(T value) {
			nodeSet.Add(new GraphNode<T>(value));
		}

		public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost) {
			from.Neighbors.Add(to);
			from.Costs.Add(cost);
		}

		public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost) {
			from.Neighbors.Add(to);
			from.Costs.Add(cost);

			to.Neighbors.Add(from);
			to.Costs.Add(cost);
		}

		public GraphNode<T> FindByValue(T value) {
			return (GraphNode<T>)nodeSet.FindByValue(value);
		}

		public bool Contains(T value) {
			return nodeSet.FindByValue(value) != null;
		}

		public bool Remove(T value) {
			GraphNode<T> nodeToRemove = (GraphNode<T>)nodeSet.FindByValue(value);
			if(nodeToRemove == null)
				return false;

			nodeSet.Remove(nodeToRemove);

			foreach(GraphNode<T> node in nodeSet) {
				int index = node.Neighbors.IndexOf(nodeToRemove);
				if(index != -1) {
					node.Neighbors.RemoveAt(index);
					node.Costs.RemoveAt(index);
				}
			}

			return true;
		}

		public NodeList<T> Nodes {
			get {
				return nodeSet;
			}
		}

		public int Count {
			get { return nodeSet.Count; }
		}
	}

	public class GraphEnumerator<T> : IEnumerator<GraphNode<T>> {
		public NodeList<T> nodeSet;
		int position = -1;

		public GraphEnumerator(NodeList<T> list) {
			nodeSet = list;
		}

		public bool MoveNext() {
			position++;
			return (position < nodeSet.Count);
		}

		public void Reset() {
			position = -1;
		}

		void IDisposable.Dispose() { }

		object IEnumerator.Current {
			get { return Current; }
		}

		public GraphNode<T> Current {
			get {
				try {
					return (GraphNode<T>)nodeSet[position];
				}
				catch(IndexOutOfRangeException) {
					throw new InvalidOperationException();
				}
			}
		}
	}
}
