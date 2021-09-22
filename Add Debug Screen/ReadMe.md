This minimum amount of code required to add a working Debug Screen to your mod.

Copy the file "DebugMod.cs" to your mod project, and copy the code in ITMPlugin.HandleInput() and ITMPlugin.Draw(), as well as the variables defined at the top of the class to your mod to add a working Debug Screen. From there, you can start adding variables to debug, or even add more debug screens if one isn't enough.

DebugMod Methods:

**DebugMod.FriendlyPoint(Vector3 point)**
Returns a simplified string of the Vector3. The simplified string removes the brackets and XYZ.

new Vector3(10, 20, 30).ToString() returns "{X:10, Y:20, Z:30}"

DebugMod.FriendlyPoint(new Vector3(10, 20, 30)) returns "10, 20, 30"

//

**DebugMod.FriendlyPoint(Vector3 point, int precision)**
Returns a simplified string of the Vector3 with fixed precision. The simplified string removes the brackets and XYZ. The values will be rounded if necessary.

new Vector3(10.12345f, 20.123f, 30.1f).ToString() returns "{X:10.12345, Y:20.123, Z:30.1}"

DebugMod.FriendlyPoint(new Vector3(10.12345f, 20.123f, 30.1f)) returns "10.124, 20.123, 30.100"

//

**DebugMod.FriendlyPoint(GlobalPoint3D point)**
Returns a simplified string of the GlobalPoint3D.

new GlobalPoint3D(10, 20, 30).ToString() returns "StudioForge.BlockWorld.GlobalPoint3D"

DebugMod.FriendlyPoint(new GlobalPoint3D(10, 20, 30)) returns "10, 20, 30"

//

**DebugMod.FriendlyPoint(Point3D point)**
Returns a simplified string of the Point3D.

new Point3D(10, 20, 30).ToString() returns "StudioForge.BlockWorld.Point3D"

DebugMod.FriendlyPoint(new Point3D(10, 20, 30)) returns "10, 20, 30"

//

**DebugMod.FriendlyPoint(Vector2 point)**
Returns a simplified string of the Vector2. The simplified string removes the brackets and XY.

new Vector2(10, 20).ToString() returns "{X:10, Y:20}"

DebugMod.FriendlyPoint(new Vector2(10, 20)) returns "10, 20"

//

**DebugMod.FriendlyPoint(Vector2 point, int precision)**
Returns a simplified string of the Vector2 with fixed precision. The simplified string removes the brackets and XY. The values will be rounded if necessary.

new Vector2(10.12345f, 20.1f).ToString() returns "{X:10.12345, Y:20.1}"

DebugMod.FriendlyPoint(new Vector2(10.12345f, 20.1f)) returns "10.124, 20.100"

//

**DebugMod.FriendlyBox(BoundingBox box)**
Returns a simplified string of the BoundingBox. The simplified string removes the XYZ.

new BoundingBox(new Vector3(10, 20, 30), new Vector3(20, 30, 40)).ToString() returns "{Min:{X:10, Y:20, Z:30} Max:{X:20, Y:30, Z:40}}"

DebugMod.FriendlyBox(new BoundingBox(new Vector3(10, 20, 30), new Vector3(20, 30, 40))) returns "\[Min: \[10, 20, 30\], Max: \[20, 30, 40\]\]"

//

**DebugMod.FriendlyBox(BoundingBox box, int precision)**
Returns a simplified string of the BoundingBox with fixed precision. The simplified string removes the XYZ. The values will be rounded if necessary.

new BoundingBox(new Vector3(10.12345f, 20.123f, 30.1f), new Vector3(20.12345f, 30.123f, 40.1f)).ToString() returns "{Min:{X:10.12345, Y:20.123, Z:30.1} Max:{X:20.12345, Y:30.123, Z:40.1}}"

DebugMod.FriendlyBox(new BoundingBox(new Vector3(10.12345f, 20.123f, 30.1f), new Vector3(20.12345f, 30.123f, 40.1f)), 3) returns "\[Min: \[10.124, 20.123, 30.100\], Max: \[20.124, 30.123, 40.100\]\]"

//

**DebugMod.ToFixed(double num, int precision)**
Returns a string representing the parameter number with a fixed precision. The value will be rounded if necessary.

Math.Round(1.1, 3) returns 1.1

DebugMod.ToFixed(1.1, 3) returns "1.100"

//

**public static void DrawDebugHud(string[] debugInfo, SpriteBatchSafe debugSpriteBatch, SpriteFont debugFont, float debugScale)**
Draws a Debug Screen using the parameter debugInfo.

This should be called after debugSpriteBatch.Begin() and before debugSpriteBatch.End().
Ideally, debugSpriteBatch.Begin() should be at the start of ITMPlugin.Draw() and debugSpriteBatch.End() should be at the end.

**public static void DrawDebugHudString(string text, int location, SpriteBatchSafe debugSpriteBatch, SpriteFont debugFont, float debugScale)**
Draws a single string using the parameter text.

This should be called after debugSpriteBatch.Begin() and before debugSpriteBatch.End().
Ideally, debugSpriteBatch.Begin() should be at the start of ITMPlugin.Draw() and debugSpriteBatch.End() should be at the end.
