import { existsSync } from "node:fs";

const runtimeHints = [
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
  "Content Center",
  "Vault"
];
const commonLocalHints = [
  "/Applications/Autodesk",
  "/Applications",
  "C:/Program Files/Autodesk",
  "C:/Program Files/SOLIDWORKS Corp",
  "C:/Program Files/Bentley",
];
const visibleHints = commonLocalHints.filter((path) => existsSync(path));

console.log("Inventor Automation and Drawing Output Quick-Start Kit");
console.log("Native/API vocabulary:", runtimeHints.join(", "));
console.log("Visible local runtime hints:", visibleHints.length > 0 ? visibleHints.join(", ") : "none detected");
console.log("Public quickstart is runnable without licensed CAD. Native adapters require the matching local CAD/runtime environment.");
