using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    private int _width;
    private int _height;
    private int[,] _gridArray;
    private float _cellSizeX;
    private float _cellSizeY;

    public Grid (int width, int height, float cellSizeX, float cellSizeY, int count)
    {
        _width = width;
        _height = height;
        _cellSizeX = cellSizeX;
        _cellSizeY = cellSizeY;

        _gridArray = new int[_width, _height];

        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                count--;
                _gridArray = new int[x, y];
            }
        }
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(OffsetCalculate(x, 0) * _cellSizeX, -OffsetCalculate(y, 1) * _cellSizeY);
    }

    public void GetGridSize()
    {
        Debug.Log(_gridArray.GetLength(0) + " X");
        Debug.Log(_gridArray.GetLength(1) + " Y");
    }

    private float OffsetCalculate(float index, int kindOfLength)
    {
        float center = (float)_gridArray.GetLength(kindOfLength) / 2;
        return index - center;
    }
}
