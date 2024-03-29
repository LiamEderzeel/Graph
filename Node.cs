using System.Collections.Generic;

namespace Graph {
	public class Node<T> {
		private T data;
		private NodeList<T> neighbors = null;

		public Node() { }
		public Node(T data) : this(data, null) { }
		public Node(T data, NodeList<T> neighbors) {
			this.data = data;
			this.neighbors = neighbors;
		}

		public T Value {
			get {
				return data;
			}
			set {
				data = value;
			}
		}

		protected NodeList<T> Neighbors {
			get {
				return neighbors;
			}
			set {
				neighbors = value;
			}
		}
	}
}