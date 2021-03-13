using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGenerator : MonoBehaviour
{
    public float limitX = 2.5f;
    public float limitY = 5.5f;

    public GameObject stone;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateStones(int qnty)
    {
        int total = 0;
        int interactions = 0;

        var lastX1 = 0f;
        var lastY1 = 0f;
        bool randomY1 = false;
        bool randomX1 = false;

        var lastX2 = 0f;
        var lastY2 = 0f;
        bool randomY2 = false;
        bool randomX2 = false;

        var lastX3 = 0f;
        var lastY3 = 0f;
        bool randomY3 = false;
        bool randomX3 = false;

        var lastX4 = 0f;
        var lastY4 = 0f;
        bool randomY4 = false;
        bool randomX4 = false;

        while (qnty != total &&
            (lastY1 < limitY && lastY2 < limitY && lastY3 < limitY && lastY4 < limitY))
        {
            int quadrant = UnityEngine.Random.Range(1, 4);
            switch (quadrant)
            {
                case 1:
                    total = RandomQuadrant(ref lastX1, ref lastY1,ref randomY1, ref randomX1, total, 1);
                    break;
                case 2:
                    total = RandomQuadrant(ref lastX2, ref lastY2, ref randomY2, ref randomX2, total, 2);
                    break;
                case 3:
                    total = RandomQuadrant(ref lastX3, ref lastY3, ref randomY3, ref randomX3, total, 3);
                    break;
                case 4:
                    total = RandomQuadrant(ref lastX4, ref lastY4, ref randomY4, ref randomX4, total, 4);
                    break;
            }
            interactions++;
        }
    }

    int RandomQuadrant(ref float lastX, ref float lastY, ref bool randomY, ref bool randomX, int total, int quadrant)
    {
        float randX = 0f;
        float randY = 0f;
        switch (quadrant)
        {
            case 1:
                randX = UnityEngine.Random.Range(0.5f, 1.0f);
                randY = UnityEngine.Random.Range(0.5f, 1.0f);
                break;
            case 2:
                randX = UnityEngine.Random.Range(-1.0f, -0.5f);
                randY = UnityEngine.Random.Range(0.5f, 1.0f);
                break;
            case 3:
                randX = UnityEngine.Random.Range(-1.0f, -0.5f);
                randY = UnityEngine.Random.Range(-1.0f, -0.5f);
                break;
            case 4:
                randX = UnityEngine.Random.Range(0.5f, 1.0f);
                randY = UnityEngine.Random.Range(-1.0f, -0.5f);
                break;
        }

        lastX += randX;
        lastY += randY;
        if (Math.Abs(lastX) < limitX && Math.Abs(lastY) < limitY)
        {
            var stoneGen = Instantiate(stone, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            stoneGen.transform.parent = gameObject.transform;
            stoneGen.transform.position = gameObject.transform.position + new Vector3(lastX, lastY, 0);
            total++;
        }
        else if (Math.Abs(lastX) > limitX && Math.Abs(lastY) < limitY && !randomX)
        {
            randomX = true;
            var stoneGen = Instantiate(stone, new Vector3(0, 0, 0), Quaternion.identity);
            stoneGen.transform.parent = gameObject.transform;
            stoneGen.transform.position = gameObject.transform.position + new Vector3(randX, lastY, 0);
            total++;
        }
        else if (Math.Abs(lastX) > limitX && Math.Abs(lastY) < limitY && !randomY)
        {
            randomY = true;
            var stoneGen = Instantiate(stone, new Vector3(0, 0, 0), Quaternion.identity);
            stoneGen.transform.parent = gameObject.transform;
            stoneGen.transform.position = gameObject.transform.position + new Vector3(lastX / 2, limitY, 0);
            total++;
        }
        return total;
    }

}
