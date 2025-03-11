using System;
using System.Collections.Generic;
using UnityEngine;

public class Logical
{
    public static List<int> GenerateLogic(int bricks)
    {
        List<int> places = new List<int>();
        for (int i = 0; i < 10; i++)
            places.Add(0);

        for (int b = 0; b < bricks; b++)
        {
            int place = UnityEngine.Random.Range(0, 10);
            while (places[place] == 1)
                place = UnityEngine.Random.Range(0, 10);
            places[place] = 1;
        }
        return places;
    }
}
