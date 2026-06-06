export function runAdapter(job) {
  return {
    requestId: job.requestId,
    kitType: "CAD Guardian quick-start automation kit",
    repo: "tsmithcode/cadguardian-inventor-automation-proof",
    runtimeDecision: job.runtimeDecision,
    apiSignals: [
  "Inventor.Application",
  "Document",
  "PartDocument",
  "AssemblyDocument",
  "DrawingDocument",
  "PropertySets",
  "BOM",
  "BOMView",
  "Sheet",
  "iLogic",
  "VB.NET",
  "Content Center"
],
    expectedOutputs: [
  "property-map",
  "BOM-readiness-report",
  "fixture receipts",
  "native adapter notes"
],
    validation: [
  "Inventor and STEP fixtures are present and attributed",
  "STEP fixture exposes ISO-10303 model exchange markers",
  "iProperty and BOM readiness checks are represented",
  "iLogic/VB.NET and Inventor API handoff is documented"
].map((rule) => ({
      rule,
      status: "review-ready",
      evidence: "Public quick-start kit fixture, API walkthrough, or native adapter example is present.",
    })),
    publicBoundary: "No private client files, login material, raw opportunity notes, or license-uncertain CAD assets are included.",
  };
}
