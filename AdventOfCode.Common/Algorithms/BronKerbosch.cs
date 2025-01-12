// ReSharper disable once CheckNamespace
namespace AdventOfCode;

public static partial class Algorithms
{
    /// <summary>
    /// The Bron–Kerbosch algorithm is an enumeration algorithm for finding all maximal cliques in an undirected graph.
    ///
    /// That is, it lists all subsets of vertices with the two properties that each pair of vertices in one of the listed subsets is connected by an edge,
    /// and no listed subset can have any additional vertices added to it while preserving its complete connectivity.
    /// </summary>
    /// <seealso cref="https://en.wikipedia.org/wiki/Bron–Kerbosch_algorithm"/>
    /// <param name="R">Result or the maximum clique. Initialise this with an empty HashSet</param>
    /// <param name="P">Potential vertices to be included. Initialise this with a list of all vertices in the graph</param>
    /// <param name="X">eXcluded vertices, those that don't connect to all in <paramref name="R"/>. Initialise this with an empty HashSet</param>
    /// <param name="graph">The graph: each node and the collection of its neighbours/vertices</param>
    /// <returns>A collection of all cliques found, ordered by maximum/largest first</returns>
    public static List<HashSet<string>> BronKerbosch(HashSet<string> R, HashSet<string> P, HashSet<string> X, Dictionary<string, HashSet<string>> graph)
    {
        var results = new List<HashSet<string>>();

        if (!P.Any() && !X.Any())
        {
            // R is a maximal clique
            results.Add(R);
        }

        foreach (var v in P.ToList())
        {
            var newR = new HashSet<string>(R) { v }; // R ∪ {v}
            var newP = new HashSet<string>(P.Intersect(graph[v])); // P ∩ Neighbours(v)
            var newX = new HashSet<string>(X.Intersect(graph[v])); // X ∩ Neighbours(v)

            results.AddRange(BronKerbosch(newR, newP, newX, graph));

            P.Remove(v); // P \ {v}
            X.Add(v);    // X ∪ {v}
        }

        return results
            .OrderByDescending(r => r.Count)
            .ToList();
    }

}
