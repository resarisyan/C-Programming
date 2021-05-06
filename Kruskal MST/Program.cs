using System;

class Graph {

	class Edge : IComparable<Edge> {
		public int src, dest, weight;

		public int CompareTo(Edge compareEdge)
		{
			return this.weight 
				- compareEdge.weight;
		}
	}

		public static void garis(){
            for(int i=0; i<60; i++){
                Console.Write("=");  
            }
        }

	public class subset 
	{
		public int parent, rank;
	};

	int V, E; 
	Edge[] edge; 
	Graph(int v, int e)
	{
		V = v;
		E = e;
		edge = new Edge[E];
		for (int i = 0; i < e; ++i)
			edge[i] = new Edge();
	}

	int find(subset[] subsets, int i)
	{

		if (subsets[i].parent != i)
			subsets[i].parent
				= find(subsets, subsets[i].parent);

		return subsets[i].parent;
	}

	void Union(subset[] subsets, int x, int y)
	{
		int xroot = find(subsets, x);
		int yroot = find(subsets, y);

		if (subsets[xroot].rank < subsets[yroot].rank)
			subsets[xroot].parent = yroot;
		else if (subsets[xroot].rank > subsets[yroot].rank)
			subsets[yroot].parent = xroot;

		else {
			subsets[yroot].parent = xroot;
			subsets[xroot].rank++;
		}
	}
	void KruskalMST()
	{
		Edge[] result = new Edge[V]; 
		int e = 0;
		int i
			= 0; 
		for (i = 0; i < V; ++i)
			result[i] = new Edge();

		Array.Sort(edge);

		subset[] subsets = new subset[V];
		for (i = 0; i < V; ++i)
			subsets[i] = new subset();

		for (int v = 0; v < V; ++v) {
			subsets[v].parent = v;
			subsets[v].rank = 0;
		}

		i = 0;

		while (e < V - 1) 
		{
			Edge next_edge = new Edge();
			next_edge = edge[i++];

			int x = find(subsets, next_edge.src);
			int y = find(subsets, next_edge.dest);

			if (x != y) {
				result[e++] = next_edge;
				Union(subsets, x, y);
			}
		}
		Console.WriteLine("");
		garis();
		Console.WriteLine("\nSetelah Dilakukan MST");
		int minimumCost = 0;
		for (i = 0; i < e; ++i)
		{
			Console.WriteLine("Node = "+ result[i].src + " Terhubung Ke Node = "
							+ result[i].dest
							+ " Dengan Ukuran Edge = " + result[i].weight);
		minimumCost += result[i].weight;
		}
	
		Console.WriteLine("Minimum Cost Spanning Tree = "
						+ minimumCost);
		Console.ReadLine();
	}

	public static void Main(String[] args)
	{
		garis();
        Console.Write("\n\t\tKruskal MST\n");
        garis();

        Console.Write("\nMasukan Jumlah Vertices\t: ");  
		int V = Convert.ToInt32(Console.ReadLine()); 
		Console.Write("Masukan Jumlah Edge\t: ");  
		int E = Convert.ToInt32(Console.ReadLine()); 
		Graph graph = new Graph(V, E);
		for(int i=0; i<E; i++){
			Console.Write("\nVertices  Ke-" + (i+1));
			Console.Write("\nMasukan Sumber Node\t: ");
			graph.edge[i].src = Convert.ToInt32(Console.ReadLine()); 
			Console.Write("Masukan Node Tujuan\t: ");
			graph.edge[i].dest = Convert.ToInt32(Console.ReadLine()); 
			Console.Write("Masukan Ukuran Edge\t: ");
			graph.edge[i].weight = Convert.ToInt32(Console.ReadLine());
		}

		for(int i=0; i<E; i++){
			Console.Write("\nNode = " + graph.edge[i].src + " Terhubung Ke Node = " + graph.edge[i].dest + " Dengan Ukuran Edge = " + graph.edge[i].weight);
		}
		graph.KruskalMST();
	}
}