using System.Collections.Generic;

namespace Graph {
	public class NodeList<T> : List<Node<T>> {

		public NodeList() : base() { }

		public NodeList(int initialSize) {
			for(int i = 0; i < initialSize; i++)
				base.Add(default(Node<T>));
		}

		public Node<T> FindByValue(T value) {
			foreach(Node<T> node in this)
				if(node.Value.Equals(value))
					return node;

			return null;
		}
	}
}