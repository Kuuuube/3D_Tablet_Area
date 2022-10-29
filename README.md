# 3D Tablet Area Plugin for [OpenTabletDriver](https://github.com/OpenTabletDriver/OpenTabletDriver) [![](https://img.shields.io/github/downloads/Kuuuube/3D_Tablet_Area/total.svg)](https://github.com/Kuuuube/3D_Tablet_Area/releases/latest)

Various methods of modifying position values through the use of other values.

## 3D Tablet Area Sens Scale

Scales the tablet area size using multipliers based on hover distance.

**Min Multiplier:** The minimum area size multipier to apply.

**Max Multiplier:** The maximum area size multipier to apply.

**Min Hover Value:** The minimum hover distance value to scale the multipier to. Hover distance values lower than this will use the **Min Multiplier**.

**Max Hover Value:** The maximum hover distance value to scale the multipier to. Hover distance values higher than this will use the **Max Multipier**. 

## 3D Tablet Area Split Area

Maps the full tablet area to half of the screen, the active half of the screen is determined by hover distance.

**Split Hover Value:** The hover distance to switch the active half of the screen.

**Split by X Axis:** Split the halves of the screen by the X axis. Only **Split by X Axis** or **Split by Y Axis** should be enabled not both.

**Split by Y Axis:** Split the halves of the screen by the Y axis. Only **Split by X Axis** or **Split by Y Axis** should be enabled not both.

**Flip Splitting:** Flips the halves used based on whether the hover distance is above or below **Split Hover Value**.