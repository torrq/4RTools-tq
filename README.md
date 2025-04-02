# 4RTools-tq

## Overview
4RTools-tq is a fork of [TalesTools](https://github.com/biancaazuma/TalesTools), which was originally based on [4RTools](https://github.com/4RTools/4RTools). This project refines and adapts the tool for enhanced compatibility with OsRO MR.

## Key Changes
- **Language & Adaptation:** Re-translated back into English and adjusted to align with OsRO MR's status set.
- **Weight-Based Auto-Disable:** Added a setting to disable 4RTools when overweight (at 50% or 90%) and trigger an Alt-# macro.
- **Expanded Skill Support:** Included Padawan (Jedi/Sith) skills along with corresponding skill icons.
- **Pre-Renewal Focus:** Removed most Renewal skills to maintain compatibility.
- **Macro Toggle Simplification:** Reverted from two toggle buttons (one for heal, another for all other macros) back to a single toggle.
- **UI & Theming:** Reverted from a dark theme to a light theme to better match the RO client.
- **Miscellaneous Improvements:**
  - Various UI tweaks.
  - Updated NuGet packages.
  - Upgraded .NET framework from v4.7.2 to v4.8.1 to reduce build warnings.

## Download & Installation

The latest release can be downloaded here: [4RTools-tq v3.1.3](https://github.com/torrq/4RTools-tq/releases/tag/v3.1.3).

### Installation Steps
1. Download the `.zip` file from the release page.
2. Extract the contents to a folder of your choice.
3. Run `4RTools-tq.exe` as Administrator.
4. Configure your settings according to your needs.
5. Ensure your game client is running before enabling macros.

> **Note:** Some antivirus programs may flag the executable as a false positive. If this happens, add an exception for the folder where you extracted the files.

## Screenshots

![6F8UU103zb](https://github.com/user-attachments/assets/3ac0ea1e-54f4-4486-a816-9c41e37bb140)
![IGBpfXuDSS](https://github.com/user-attachments/assets/0a7a8d1d-a0d3-42ea-a036-9f0f6f3af396)

## Known Issues
- Turn off when overweight will trigger whether or not the status is "ON" (will fix soon)
- Macro Songs reset buttons won't reset the form (will fix soon)
- Macro Songs/Macro Switch forms are overloaded with elements. If you switch to one of those tabs and drag the window around, it could lag. This form needs either less elements or be revised to be dynamic (will fix eventually)
