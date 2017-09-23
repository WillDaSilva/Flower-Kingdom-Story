using UnityEngine;

public class Parabola
{
    /// <summary>
    /// Used to interpolate a parabola in between startHeight and maxHeight.
    /// </summary>
    /// <param name="startHeight">The initial height of the arc</param>
    /// <param name="maxHeight">The highest point on the parabola</param>
    /// <param name="acceleration">Acceleration</param>
    /// <param name="time">The current time. Initial height is at time = 0</param>
    public static float Calculate(float startHeight, float maxHeight, float acceleration, float time)
    {
        float vi = Mathf.Sqrt(-2 * acceleration * (maxHeight - startHeight)); //Calculates the initial velocity needed in d = vi×t + ½at²
        float y = vi * time + 0.5f * acceleration * time * time + startHeight; //d = vi×t + ½*at²
        return y;
    }
    /// <summary>
    /// Calculates the time it takes to get from startHeight to hitHeight.
    /// </summary>
    /// <param name="startHeight">The initial height of the arc</param>
    /// <param name="maxHeight">The highest point on the parabola</param>
    /// <param name="hitHeight">The final height on the Parabola</param>
    /// <param name="acceleration">Acceleration</param>
    public static float CalculateHitTime(float startHeight, float maxHeight, float hitHeight, float acceleration)
    {
        float fallTime = Mathf.Sqrt(2 * ( hitHeight - maxHeight) / acceleration); //calculates the falling time with √(2·h/a)
        float riseTime = Mathf.Sqrt(2 * ( startHeight - maxHeight) / acceleration); //calculates the rising time with √(2·h/a)
        float totalTime = riseTime + fallTime;
        return totalTime;
    }
    /// <summary>
    /// The derivative of a parabola; Calculates the instantaneous slope (the velocity).
    /// </summary>
    /// <param name="startHeight">The initial height of the arc</param>
    /// <param name="maxHeight">The highest point on the parabola</param>
    /// <param name="acceleration">Acceleration</param>
    /// <param name="time">The current time. Initial height is at time = 0</param>
    public static float CalculateSlope(float startHeight, float maxHeight, float acceleration, float time)
    {
        return Mathf.Sqrt(-2 * acceleration * (maxHeight - startHeight)) + acceleration * time;
    }
}
