# Inventor Automation and Drawing Output Quick-Start Kit

CAD Guardian Pareto quick-start automation kit for drafters, CAD automation peers, technical interviews, and buyer-facing business-case discussions.

> This CAD library is in development. This is an early public preview for feedback on the best business case, workflow shape, and proof path.

## Why this exists

Turn repeated Inventor model, iProperty, BOM, Content Center, and drawing-output pain into a package check before any add-in, iLogic rule, or Vault handoff expands.

## Fast run

```bash
npm run doctor
npm run verify
npm run demo
dotnet build quickstart
```

`npm run demo` runs the C# quickstart and writes `reports/quickstart-report.json`.

## What is worth reusing

- `quickstart/Program.cs`: a small C# package-readiness engine with fixture receipts, Pareto checks, native runtime gates, and a JSON report.
- `native/`: optional API/runtime examples for the licensed CAD environment.
- `fixtures/public/`: approved public CAD fixtures only.
- `docs/USER_GUIDE.md`: how to run and adapt the kit.
- `docs/INTERVIEW_SCRIPT.md`: how to explain the business case without guessing.

## STAR story

**Situation:** An engineering team repeats Inventor model, iProperty, drawing, BOM, and package-output work, but manual steps keep leaking time.

**Task:** Prove the model/package contract before a native Inventor API or iLogic adapter is used.

**Action:** Bundle public IPT/STEP fixtures, validate package metadata, represent BOM and iProperty checks, and show C#, iLogic, and VB.NET handoff examples.

**Result:** A reviewer can run the kit, see package readiness, and decide whether Inventor API, iLogic, or Vault work is the right first slice.

## Pareto checks

- **Model package inventory:** Separates public package validation from native Inventor document mutation. Handoff: `Inventor.Application`, `Document`, `PartDocument`, and `AssemblyDocument`.
- **iProperty and BOM readiness:** Names the fields and rows that decide whether automation saves time or creates downstream corrections. Handoff: `PropertySets`, `BOM`, `BOMView`, Content Center assumptions, and Vault ownership.
- **iLogic / VB.NET rule boundary:** Keeps rule automation near the model behavior users already trust instead of turning it into a broad platform rewrite. Handoff: iLogic/VB.NET rule first, Inventor API add-in only when document scope is proven.

## API and runtime signals

- Inventor.Application
- Document
- PartDocument
- AssemblyDocument
- DrawingDocument
- PropertySets
- BOM
- BOMView
- Sheet
- iLogic
- VB.NET
- Content Center
- Vault

## Public fixture boundary

Only approved public sample files are bundled. No client files, private drawings, credentials, raw opportunity notes, or license-uncertain CAD assets are included.

## Service page

https://www.cadguardian.com/services/inventor-automation
