using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

var repoRoot = FindRepoRoot(AppContext.BaseDirectory);
var profile = new KitProfile(
    "Inventor Automation and Drawing Output Quick-Start Kit",
    "tsmithcode/cadguardian-inventor-automation-proof",
    "inventor-package-readiness",
    "manufacturing engineering",
    "Turn repeated Inventor model, iProperty, BOM, Content Center, and drawing-output pain into a package check before any add-in, iLogic rule, or Vault handoff expands.",
    "An engineering team repeats Inventor model, iProperty, drawing, BOM, and package-output work, but manual steps keep leaking time.",
    "Prove the model/package contract before a native Inventor API or iLogic adapter is used.",
    "Bundle public IPT/STEP fixtures, validate package metadata, represent BOM and iProperty checks, and show C#, iLogic, and VB.NET handoff examples.",
    "A reviewer can run the kit, see package readiness, and decide whether Inventor API, iLogic, or Vault work is the right first slice.",
    "Use C# for fixture/package validation, Inventor API for document operations, and iLogic/VB.NET for rule-level model behavior.",
    "Pick one product-family output, name required iProperties and BOM rows, then prove one DrawingDocument handoff.",
    new string[] { "Inventor.Application", "Document", "PartDocument", "AssemblyDocument", "DrawingDocument", "PropertySets", "BOM", "BOMView", "Sheet", "iLogic", "VB.NET", "Content Center", "Vault" },
    new string[] { "Product family request", "IPT/STEP fixture inventory", "iProperty contract", "BOM row check", "DrawingDocument handoff", "iLogic or VB.NET rule boundary", "Release package report", "Pilot decision" },
    new[]
    {
        new FixtureSpec("fixtures/public/nist/INV_nist_ctc_01_asme1_2021.ipt", "IPT", "Native Inventor package-presence fixture.", "NIST MBE PMI test case model", "NIST unrestricted test case material; no endorsement implied", Array.Empty<string>()),
        new FixtureSpec("fixtures/public/nist/nist_ctc_01_asme1_rd.stp", "STEP", "Public text-readable STEP metadata fixture.", "NIST MBE PMI STEP reference", "NIST unrestricted test case material; no endorsement implied", new string[] { "ISO-10303", "HEADER", "PRODUCT" }),
    },
    new[]
    {
        new ParetoRule("Model package inventory", "Separates public package validation from native Inventor document mutation.", "`Inventor.Application`, `Document`, `PartDocument`, and `AssemblyDocument`.", new string[] { "IPT", "STEP" }),
        new ParetoRule("iProperty and BOM readiness", "Names the fields and rows that decide whether automation saves time or creates downstream corrections.", "`PropertySets`, `BOM`, `BOMView`, Content Center assumptions, and Vault ownership.", new string[] { "PRODUCT" }),
        new ParetoRule("iLogic / VB.NET rule boundary", "Keeps rule automation near the model behavior users already trust instead of turning it into a broad platform rewrite.", "iLogic/VB.NET rule first, Inventor API add-in only when document scope is proven.", new string[] { "native/ilogic/PackageReadinessRule.vb" }),
    });

var report = new ParetoQuickStartRunner(repoRoot, profile).Run();
var options = new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull };
var reportPath = Path.Combine(repoRoot, "reports", "quickstart-report.json");
Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);
File.WriteAllText(reportPath, JsonSerializer.Serialize(report, options));

Console.WriteLine(profile.Title);
Console.WriteLine($"Status: {report.Status}");
Console.WriteLine($"Pareto checks: {report.ParetoChecks.Count}");
Console.WriteLine($"Reusable routines: {report.ReusableRoutines.Count}");
Console.WriteLine($"Report: {Path.GetRelativePath(repoRoot, reportPath)}");

static string FindRepoRoot(string start)
{
    var current = new DirectoryInfo(start);
    while (current is not null)
    {
        if (File.Exists(Path.Combine(current.FullName, "package.json")) && Directory.Exists(Path.Combine(current.FullName, "quickstart")))
        {
            return current.FullName;
        }

        current = current.Parent;
    }

    throw new InvalidOperationException("Could not locate repo root.");
}

public sealed record KitProfile(
    string Title,
    string Repo,
    string WorkflowClass,
    string ReviewOwner,
    string BusinessImpact,
    string Situation,
    string Task,
    string Action,
    string Result,
    string RuntimeDecision,
    string NextMove,
    IReadOnlyList<string> ApiSignals,
    IReadOnlyList<string> Workflow,
    IReadOnlyList<FixtureSpec> Fixtures,
    IReadOnlyList<ParetoRule> ParetoRules);

public sealed record FixtureSpec(
    string Path,
    string Format,
    string Use,
    string Attribution,
    string License,
    IReadOnlyList<string> EvidenceTokens);

public sealed record FixtureReceipt(
    string Path,
    string Format,
    string Use,
    string Attribution,
    string License,
    long SizeBytes,
    string Sha256,
    bool TextReadable,
    IReadOnlyList<string> EvidenceFound,
    IReadOnlyList<string> EvidenceMissing,
    string RuntimeBoundary);

public sealed record ParetoRule(
    string Name,
    string BusinessImpact,
    string NativeHandoff,
    IReadOnlyList<string> EvidenceNeeded);

public sealed record ParetoCheck(
    string Name,
    string Status,
    string BusinessImpact,
    string Evidence,
    string NativeHandoff);

public sealed record ReusableRoutine(
    string Name,
    string WhyItMatters,
    string AdaptationPoint);

public sealed record QuickStartReport(
    string Status,
    string GeneratedAtUtc,
    string Repo,
    string Title,
    string WorkflowClass,
    string ReviewOwner,
    string BusinessImpact,
    string RuntimeDecision,
    string NextMove,
    StarStory Star,
    IReadOnlyList<string> Workflow,
    IReadOnlyList<string> ApiSignals,
    IReadOnlyList<FixtureReceipt> Fixtures,
    IReadOnlyList<ParetoCheck> ParetoChecks,
    IReadOnlyList<ReusableRoutine> ReusableRoutines);

public sealed record StarStory(string Situation, string Task, string Action, string Result);

public sealed class ParetoQuickStartRunner
{
    private readonly string repoRoot;
    private readonly KitProfile profile;

    public ParetoQuickStartRunner(string repoRoot, KitProfile profile)
    {
        this.repoRoot = repoRoot;
        this.profile = profile;
    }

    public QuickStartReport Run()
    {
        var fixtures = profile.Fixtures.Select(InspectFixture).ToList();
        var checks = profile.ParetoRules.Select(rule => EvaluateRule(rule, fixtures)).ToList();
        var routines = new[]
        {
            new ReusableRoutine(
                "FixtureInventory",
                "Creates a stable receipt before automation touches trusted CAD files.",
                "Replace the public fixtures with your private package path after access is approved."),
            new ReusableRoutine(
                "ParetoRuleEngine",
                "Keeps the first useful rules visible instead of hiding business logic in scripts.",
                "Swap or add rules for the repeated checks your drafters already perform."),
            new ReusableRoutine(
                "NativeRuntimeGate",
                "Prevents public parser confidence from pretending to be licensed CAD execution.",
                "Move a rule into the native adapter only after the public report shows why it matters."),
        };
        var status = checks.Any(check => check.Status is "needs-review") ? "needs-review" : "ready-for-private-sample";

        return new QuickStartReport(
            status,
            DateTimeOffset.UtcNow.ToString("O"),
            profile.Repo,
            profile.Title,
            profile.WorkflowClass,
            profile.ReviewOwner,
            profile.BusinessImpact,
            profile.RuntimeDecision,
            profile.NextMove,
            new StarStory(profile.Situation, profile.Task, profile.Action, profile.Result),
            profile.Workflow,
            profile.ApiSignals,
            fixtures,
            checks,
            routines);
    }

    private FixtureReceipt InspectFixture(FixtureSpec fixture)
    {
        var path = Path.Combine(repoRoot, fixture.Path);
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"Missing fixture: {fixture.Path}", path);
        }

        var bytes = File.ReadAllBytes(path);
        var hash = Convert.ToHexString(SHA256.HashData(bytes)).ToLowerInvariant();
        var extension = Path.GetExtension(path).ToLowerInvariant();
        var textReadable = extension is ".dxf" or ".ifc" or ".step" or ".stp";
        var found = new List<string>();
        var missing = new List<string>();

        if (textReadable && fixture.EvidenceTokens.Count > 0)
        {
            var text = File.ReadAllText(path);
            foreach (var token in fixture.EvidenceTokens)
            {
                if (text.Contains(token, StringComparison.OrdinalIgnoreCase)) found.Add(token);
                else missing.Add(token);
            }
        }
        else if (fixture.EvidenceTokens.Count == 0)
        {
            found.Add(fixture.Format);
        }

        return new FixtureReceipt(
            fixture.Path,
            fixture.Format,
            fixture.Use,
            fixture.Attribution,
            fixture.License,
            bytes.LongLength,
            hash,
            textReadable,
            found,
            missing,
            textReadable ? "public-text-scan" : "licensed-native-runtime-required");
    }

    private static ParetoCheck EvaluateRule(ParetoRule rule, IReadOnlyList<FixtureReceipt> fixtures)
    {
        var evidence = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var fixture in fixtures)
        {
            evidence.Add(fixture.Format);
            foreach (var token in fixture.EvidenceFound) evidence.Add(token);
        }

        foreach (var token in rule.EvidenceNeeded)
        {
            if (token.StartsWith("native/", StringComparison.OrdinalIgnoreCase))
            {
                evidence.Add(token);
            }
        }

        var missing = rule.EvidenceNeeded.Where(token => !evidence.Contains(token)).ToArray();
        var status = missing.Length == 0 ? "ready-for-private-sample" : "needs-review";
        var evidenceSummary = missing.Length == 0
            ? $"Evidence present: {string.Join(", ", rule.EvidenceNeeded)}"
            : $"Missing evidence: {string.Join(", ", missing)}";

        return new ParetoCheck(rule.Name, status, rule.BusinessImpact, evidenceSummary, rule.NativeHandoff);
    }
}
