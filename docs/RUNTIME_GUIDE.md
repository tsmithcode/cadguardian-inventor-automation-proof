# Runtime Guide

## Default public runtime

The default runtime is Node.js plus synthetic fixtures:

```bash
npm run doctor
npm run verify
npm run demo
```

Expected output: `reports/demo-validation-report.json`.

## Optional native/runtime path

Run:

```bash
npm run runtime:check
```

This command only reports visible local runtime hints. It does not prove CAD execution.

## Runtime decision for this proof

Inventor API adapter with iLogic rule inventory and BOM export validation.

## AgentOps boundary

NIST unrestricted Inventor PMI model references stay catalog-controlled. This repo includes generated property and BOM fixtures, not native IPT/IAM files.

Native CAD files, private client material, credentials, source-system exports, and raw opportunity notes stay outside this public repo.
