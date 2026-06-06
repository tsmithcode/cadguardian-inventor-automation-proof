# Runtime Guide

## Public runtime

The default kit runs with local .NET and does not require licensed CAD software.

```bash
dotnet run --project quickstart
```

## Native runtime

Use C# for fixture/package validation, Inventor API for document operations, and iLogic/VB.NET for rule-level model behavior.

Native examples are intentionally optional. They should be used only inside the matching licensed CAD environment after the package boundary is proven.

## Native handoff points

- **Model package inventory:** `Inventor.Application`, `Document`, `PartDocument`, and `AssemblyDocument`.
- **iProperty and BOM readiness:** `PropertySets`, `BOM`, `BOMView`, Content Center assumptions, and Vault ownership.
- **iLogic / VB.NET rule boundary:** iLogic/VB.NET rule first, Inventor API add-in only when document scope is proven.
