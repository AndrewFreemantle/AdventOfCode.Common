// ReSharper disable once CheckNamespace
namespace AdventOfCode.UnitTests;

public class BronKerboschTests
{
    private static readonly string[] TestCase =
    [
        "kh-tc",
        "qp-kh",
        "de-cg",
        "ka-co",
        "yn-aq",
        "qp-ub",
        "cg-tb",
        "vc-aq",
        "tb-ka",
        "wh-tc",
        "yn-cg",
        "kh-ub",
        "ta-co",
        "de-co",
        "tc-td",
        "tb-wq",
        "wh-td",
        "ta-ka",
        "td-qp",
        "aq-cg",
        "wq-ub",
        "ub-vc",
        "de-ta",
        "wq-aq",
        "wq-vc",
        "wh-yn",
        "ka-de",
        "kh-ta",
        "co-tc",
        "wh-qp",
        "tb-vc",
        "td-yn"];

    private readonly List<Tuple<string, string>> _links = new();
    private readonly Dictionary<string, HashSet<string>> _linksPerTestCase = new();

    public BronKerboschTests()
    {
        foreach (var link in TestCase)
        {
            var parts = link.Split('-');
            _links.Add(new Tuple<string, string>(parts[0], parts[1]));
        }

        // links are bi-directional
        var computers = _links
            .Select(l => l.Item1)
            .ToList();
        computers.AddRange(_links.Select(l => l.Item2));
        computers = computers.Distinct().ToList();

        foreach (var computer in computers.OrderBy(s => s))
        {
            // find all of the other computers this one is linked to...
            var others = new HashSet<string>();
            foreach (var link in _links.Where(link => link.Item1 == computer || link.Item2 == computer))
                others.Add(link.Item1 == computer ? link.Item2 : link.Item1);

            _linksPerTestCase[computer] = others.OrderBy(s => s).ToHashSet();
        }
    }

    [Fact]
    public void BronKerboschTest()
    {
        var links = new Dictionary<string, HashSet<string>> { {"co", ["de", "ka", "ta"] } };

        var result = Algorithms.BronKerbosch(
            new HashSet<string>(),
            _linksPerTestCase.Keys.ToHashSet(),
            new HashSet<string>(),
            _linksPerTestCase);

        Assert.Equal(4, result.MaxBy(r => r.Count).Count);
        Assert.Equal("co,de,ka,ta", string.Join(',', result.MaxBy(r => r.Count)));
    }
}
