# Inventor Automation and Drawing Output Proof

CAD Guardian proof repo for technical interviews, buyer reviews, and peer walkthroughs.

## Story
An engineering team needs one repeatable Inventor package path: model properties, drawing output, BOM rows, Content Center assumptions, and reviewer evidence.

## Business case
The first useful win is a validated model-to-package slice, not an open-ended Inventor automation platform.

## Workflow
- Product family request
- Model and iProperty contract
- Inventor API adapter
- BOM/export fixture
- Drawing package manifest
- Content Center assumption log
- Reviewer notes
- Pilot decision

## Stack vocabulary
- Inventor API
- iLogic
- IPT/IAM/IDW
- Content Center
- Vault
- BOM

## Run

```bash
npm run verify
npm run demo
```

## Public CAD data boundary
NIST unrestricted Inventor PMI model references stay catalog-controlled. This repo includes generated property and BOM fixtures, not native IPT/IAM files.

This repository is built for public proof. It includes source inventory manifests, synthetic input fixtures, validation examples, and adapter code shaped for walkthroughs. It does not include private drawings, proprietary project files, login material, raw opportunity notes, or native CAD files that AgentOps marks catalog-only.

## Related service page
https://www.cadguardian.com/services/inventor-automation
