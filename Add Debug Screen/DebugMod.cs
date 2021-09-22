using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StudioForge.BlockWorld;
using StudioForge.Engine;
using StudioForge.Engine.Core;

namespace DebugScreenMod
{
    /// <summary>
    /// Debug Screen mod by Dave The Monitor for use with debugging. Mod creators, feel free to use this in your mod for debugging.
    /// </summary>
    public class DebugMod
    {
        /// <summary>
        /// Returns a simplified string representing the Vector3.
        /// </summary>
        /// <param name="point">The Vector3 to simplify</param>
        /// <returns>A simplified string representing the Vector3.</returns>
        public static string FriendlyPoint(Vector3 point) { return $"{point.X}, {point.Y}, {point.Z}"; }

        /// <summary>
        /// Returns a simplified string representing the Vector3 with fixed precision. The value will be rounded if necessary.
        /// </summary>
        /// <param name="point">The Vector3 to simplify</param>
        /// <param name="precision">The number of decimals at the end of the values.</param>
        /// <returns>A simplified string representing the Vector3 with fixed precision.</returns>
        public static string FriendlyPoint(Vector3 point, int precision) { return $"{ToFixed(point.X, precision)}, {ToFixed(point.Y, precision)}, {ToFixed(point.Z, precision)}"; }

        /// <summary>
        /// Returns a simplified string representing the GlobalPoint3D.
        /// </summary>
        /// <param name="point">The GlobalPoint3D to simplify</param>
        /// <returns>A simplified string representing the GlobalPoint3D.</returns>
        public static string FriendlyPoint(GlobalPoint3D point) { return $"{point.X}, {point.Y}, {point.Z}"; }

        /// <summary>
        /// Returns a simplified string representing the Point3D.
        /// </summary>
        /// <param name="point">The Point3D to simplify</param>
        /// <returns>A simplified string representing the Point3D.</returns>
        public static string FriendlyPoint(Point3D point) { return $"{point.X}, {point.Y}, {point.Z}"; }

        /// <summary>
        /// Returns a simplified string representing the Vector2.
        /// </summary>
        /// <param name="point">The Vector2 to simplify</param>
        /// <returns>A simplified string representing the Vector2.</returns>
        public static string FriendlyPoint(Vector2 point) { return $"{point.X}, {point.Y}"; }

        /// <summary>
        /// Returns a simplified string representing the Vector2 with fixed precision. The value will be rounded if necessary.
        /// </summary>
        /// <param name="point">The Vector2 to simplify</param>
        /// <param name="precision">The number of decimals at the end of the values.</param>
        /// <returns>A simplified string representing the Vector2 with fixed precision.</returns>
        public static string FriendlyPoint(Vector2 point, int precision) { return $"{ToFixed(point.X, precision)}, {ToFixed(point.Y, precision)}"; }

        /// <summary>
        /// Returns a simplified string representing the BoundingBox.
        /// </summary>
        /// <param name="box">The BoundingBox to simplify</param>
        /// <returns>A simplified string representing the BoundingBox.</returns>
        public static string FriendlyBox(BoundingBox box) { return $"Min: [{box.Min.X}, {box.Min.Y}, {box.Max.Z}] Max: [{box.Max.X}, {box.Max.Y}, {box.Max.Z}]"; }

        /// <summary>
        /// Returns a simplified string representing the BoundingBox with fixed precision. The value will be rounded if necessary.
        /// </summary>
        /// <param name="box">The BoundingBox to simplify</param>
        /// <param name="precision">The number of decimals at the end of the values.</param>
        /// <returns>A simplified string representing the BoundingBox.</returns>
        public static string FriendlyBox(BoundingBox box, int precision) { return $"Min: [{ToFixed(box.Min.X, precision)}, {ToFixed(box.Min.Y, precision)}, {ToFixed(box.Max.Z, precision)}] Max: [{ToFixed(box.Max.X, precision)}, {ToFixed(box.Max.Y, precision)}, {ToFixed(box.Max.Z, precision)}]"; }

        /// <summary>
        /// Returns a string of a double rounded with fixed precision. The value will be rounded if necessary.
        /// </summary>
        /// <param name="num">The value to round.</param>
        /// <param name="precision">The number of decimals at the end of the value.</param>
        /// <returns></returns>
        public static string ToFixed(double num, int precision)
        {
            num = Math.Round(num, precision);
            string numString = num.ToString().IndexOf(".") > -1 ? num.ToString() : num.ToString() + ".";
            int decimals = numString.IndexOf(".") > -1 ? numString.Substring(numString.IndexOf(".") + 1).Length : 0;
            if (decimals < precision)
                for (int i = 0; i < precision - decimals; i++) { numString += "0"; }
            return $"{numString}";
        }

        /// <summary>
        /// Draws each value in a string[] array to a debug SpriteBatchSafe.
        /// <para>Make sure that SpriteBatchSafe.Begin() is called before this method is used, and SpriteBatchDafe.End() is called after. Ideally, SpriteBatchSafe.Begin() should be at the start of the ITMPlugin.Draw method, and SpriteBatchSafe.End() at the end.</para>
        /// <para>For optimization, you should only draw the SpriteBatchSafe if a debug screen is active.</para>
        /// </summary>
        /// <param name="debugInfo">The array of values to draw. Each value in the array will be a separate box in the debug screen.</param>
        /// <param name="debugSpriteBatch">The SpriteBatchSafe to use as the debug screen.</param>
        /// <param name="debugFont">The font to use for the debug screen.</param>
        /// <param name="debugScale">The scale for the debug screen.</param>
        public static void DrawDebugHud(string[] debugInfo, SpriteBatchSafe debugSpriteBatch, SpriteFont debugFont, float debugScale)
        {
            int i = 0;
            foreach (string str in debugInfo)
            {
                DrawDebugHudString(str, i, debugSpriteBatch, debugFont, debugScale);
                i++;
            }
        }
        /// <summary>
        /// Draws a string to a debug SpriteBatchSafe.
        /// <para>Make sure that SpriteBatchSafe.Begin() is called before this method is used, and SpriteBatchDafe.End() is called after. Ideally, SpriteBatchSafe.Begin() should be at the start of the ITMPlugin.Draw method, and SpriteBatchSafe.End() at the end.</para>
        /// <para>For optimization, you should only draw the SpriteBatchSafe if a debug screen is active.</para>
        /// </summary>
        /// <param name="text">The text to draw.</param>
        /// <param name="location">The vertical location of the text. 0 is the top, 1 is one box below, 2 is two boxes below, etc.</param>
        /// <param name="debugSpriteBatch">The SpriteBatchSafe to use as the debug screen.</param>
        /// <param name="debugFont">The font to use for the debug screen.</param>
        /// <param name="debugScale">The scale for the debug screen.</param>
        public static void DrawDebugHudString(string text, int location, SpriteBatchSafe debugSpriteBatch, SpriteFont debugFont, float debugScale)
        {
            Vector2 stringSize = debugFont.MeasureString(text);
            Rectangle backgroundBox = new Rectangle(20, 20 + (location * (int)(5 + (stringSize.Y * debugScale))), 10 + (int)(stringSize.X * debugScale), (5 + (int)(stringSize.Y * debugScale)));
            debugSpriteBatch.DrawFilledBox(backgroundBox, 0, new Color(0, 0, 0, 0.35f), new Color(0, 0, 0, 0.35f));
            debugSpriteBatch.DrawString(debugFont, text, new Vector2(25, 22.5f + (location * (5 + (int)(stringSize.Y * debugScale)))), Color.White, 0, new Vector2(), debugScale, SpriteEffects.None, 0);
        }
    }
}
