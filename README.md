# Inventor Automation and Drawing Output Quick-Start Kit

CAD Guardian quick-start automation kit for peer walkthroughs, technical interviews, and buyer-facing business-case discussions.

> This CAD library is in development. This is an early public preview for feedback on the best business case, workflow shape, and proof path.

## STAR story

**Situation:** An engineering team repeats Inventor model, iProperty, drawing, BOM, and package-output work, but manual steps keep leaking time.

**Task:** Create a public-safe quickstart that proves the model/package contract before a native Inventor API or iLogic adapter is used.

**Action:** Bundle approved NIST IPT/STEP fixtures, validate package metadata, represent BOM and iProperty rules, and show C#, iLogic, and VB.NET adapter examples.

**Result:** Reviewers can run the public kit, see package readiness, and discuss the native Inventor automation path without private models.

## Fast run

```bash
npm run doctor
npm run verify
npm run demo
dotnet build quickstart
dotnet run --project quickstart
```

The C# quickstart writes `reports/quickstart-report.json`. The Node demo writes `reports/demo-validation-report.json`.

## What is included

- Runnable C# quickstart in `quickstart/`.
- Optional native/runtime examples in `native/`.
- Safe public fixtures in `fixtures/public/`.
- STAR story, API walkthrough, native runtime notes, interview script, and expected outcome docs.

## Workflow

- Product family request
- IPT/STEP fixture inventory
- iProperty contract
- BOM row check
- DrawingDocument handoff
- iLogic or VB.NET rule boundary
- Release package report
- Pilot decision

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

## Public fixture boundary

Only approved public sample files are bundled. No client files, private drawings, credentials, raw opportunity notes, or license-uncertain CAD assets are included.

## Service page

https://www.cadguardian.com/services/inventor-automation
