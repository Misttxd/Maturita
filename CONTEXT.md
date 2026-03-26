# Project Context: Aqualoom (Unity 2022.3.10f1)

This document provides a handoff context for any AI agent or developer continuing the work on the **Aqualoom** project.

## 🛠 Environment & Technical Stack
- **Unity Version:** 2022.3.10f1 (LTS).
- **Project Structure:** Standard Unity 2D project with Universal Render Pipeline (URP).
- **Key Scripts:** `GameManager.cs`, `FishingEvent.cs`, `PlayerMovement.cs`, `FishingMiniGame.cs`.

## 🏃 Recent Progress & Completed Tasks
1.  **Codebase Audit:** Verified that the core logic builds successfully with no syntax errors.
2.  **Navigation & Scenes:** Identified the critical scene flow starting from `MainMenu` -> `Forest2/Desert/Iceland`.
3.  **Animation Re-creation:**
    -   Reconstructed the Player 2D movement system.
    -   Strategy: Used a **Blend Tree** (2D Simple Directional) for `Idle` and `Walk` states.
    -   Optimization: Implemented **Animator Override Controllers** for different biomes (Desert, Iceland) to reuse the same logic while swapping sprites.
4.  **Scene Cleanup:** Identified unused legacy scenes (`World1`, `World11`, `World2`) that are not referenced in scripts and can be archived.

## ⚠️ Current Critical Issues (Immediate Priority)
The game is currently experiencing **NullReferenceException (NRE)** during startup and fishing events.

### 🛑 Root Cause:
The `GameManager.cs` heavily relies on `GameObject.Find()`. Since many UI windows (Fail, Ryba, Fishdex) are **inactive** by default, `GameObject.Find()` returns `null`. This breaks the Singleton initialization and cascades into other scripts like `FishingEvent.cs`.

### 📝 Approved Plan:
-   Refactor `GameManager.cs` into a robust **Singleton**.
-   Remove all `GameObject.Find()` calls for UI elements.
-   **Requirement:** Change variables to `public` or `[SerializeField]` and assign references manually in the Unity Inspector.
-   Fix duplicate GameManagers during scene transitions using proper `Awake` checks.

## ⚙️ Technical Blockers
-   **Encoding Issue:** The project's C# files (possibly created with non-UTF8 encoding like Windows-1250) are causing "Charset detection" errors for automated AI editing tools.
-   **Action Needed:** Standardize all `.cs` files to **UTF-8 (with BOM)** to allow AI agents to perform surgical code edits without errors.

## 🎯 Next Steps
2.  Apply the refactored `GameManager.cs` and `FishingEvent.cs` code (logic is ready but blocked by encoding).
3.  Ask the user to manually drag-and-drop the UI element references into the `GameManager` component in the `Forest2` scene once the script is updated.
