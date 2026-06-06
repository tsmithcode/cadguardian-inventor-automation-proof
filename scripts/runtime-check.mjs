import { existsSync } from "node:fs";

const runtimeHints = [
  "Inventor API",
  "iLogic",
  "IPT/IAM/IDW",
  "Content Center",
  "Vault",
  "BOM"
];
const commonLocalHints = [
  "/Applications/Autodesk",
  "/Applications",
  "C:/Program Files/Autodesk",
  "C:/Program Files/SOLIDWORKS Corp",
  "C:/Program Files/Bentley",
];

const visibleHints = commonLocalHints.filter((path) => existsSync(path));

console.log("Inventor Automation and Drawing Output Proof");
console.log("Runtime vocabulary:", runtimeHints.join(", "));
console.log("Visible local runtime hints:", visibleHints.length > 0 ? visibleHints.join(", ") : "none detected");
console.log("This check does not prove CAD execution. Native geometry, conversion, repair, or API execution requires a separate local tool receipt.");
