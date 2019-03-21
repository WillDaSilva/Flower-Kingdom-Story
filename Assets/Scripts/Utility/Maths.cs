using UnityEngine;
using System.Collections;

public class Maths {
	public static int Wrap(int x, int min, int max){//x,l,h
		max = max - min + 1 ; x = (x - min) % max + min; if (x < min) x += max;
		return x;
	}
    public static float PointsToAngle(Vector3 v3a, Vector3 v3b)
    {
        return Mathf.Atan2(v3b.z - v3a.z, v3b.x - v3a.x) * 180 / Mathf.PI;
    }
    
    public static object RandomPosNeg()
    {
        int r = Random.Range(0, 1) * 2 - 1;
        return r;
    }
    public static bool isPrime(int number)
    {
        if (number == 1) return false;
        if (number == 2) return true;

        var boundary = (int)Mathf.Floor(Mathf.Sqrt(number));

        for (int i = 2; i <= boundary; ++i)
        {
            if (number % i == 0) return false;
        }

        return true;
    }
}
