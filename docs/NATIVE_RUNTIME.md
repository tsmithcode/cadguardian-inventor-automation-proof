# Native Runtime

The public kit runs without licensed CAD software. The examples in `native/` are intentionally optional.

## Runtime decision

Use C# for fixture/package validation, Inventor API for document operations, and iLogic/VB.NET for rule-level model behavior.

## Native/API examples

- native/inventor-dotnet/InventorPackageAudit.cs
- native/ilogic/PackageReadinessRule.vb

## Rule

Do not claim native geometry mutation, conversion, plotting, PDM state changes, or model edits unless a local tool receipt is produced with approved files and tooling.
