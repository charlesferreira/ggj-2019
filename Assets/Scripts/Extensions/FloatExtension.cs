using UnityEngine;

public static class FloatExtension {
    public static string ToSeconds (this float num) {
        return string.Format ("{0:#0}:{1:00}",
            Mathf.Floor (num / 60), //minutes
            Mathf.Floor (num) % 60); //seconds
    }
}