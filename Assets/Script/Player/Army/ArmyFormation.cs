
using System.Collections.Generic;

using UnityEngine;


public class ArmyFormation
{


    public static List<Vector3> Horizontal(int amount)
    {
        List<Vector3> result = new List<Vector3>();
       
       
        int index = 0;
        for (int i = 1; i <= amount; i++)
        {
            if(i < 9)
            {
                result.Add(new Vector3(index, 0, 0));
            }
            else
            {
                result.Add(new Vector3(index, 0, 1));
            }
            if (index == 0) index = 1;
            else if (index > 0) index = -index;
            else
            {
                index = -index;
                index++;
            }
           
            if (index == -4) index = 0;

        }
           


        

        
        return result;
    }

    public static List<Vector3> Vertical(int amount)
    {


        List<Vector3> result = new List<Vector3>();


        int index = 0;
        for (int i = 1; i <= amount; i++)
        {
            if (i < 9)
            {
                result.Add(new Vector3(0, 0, index));
            }
            else
            {
                result.Add(new Vector3(1, 0, index));
            }
            if (index == 0) index = 1;
            else if (index > 0) index = -index;
            else
            {
                index = -index;
                index++;
            }
          
            if (index == -4) index = 0;

        }






        return result;
      
    }


    public static List<Vector3> Triangle(int amount)
    {
    
        List<Vector3> result = new List<Vector3>();


        int h = Mathf.FloorToInt(Mathf.Sqrt(amount));
      
        if (h * h != amount) h++;

        int count = 3;
        result.Add(new Vector3(-(h-1), 0, 0));
        result.Add(new Vector3((h-1), 0, 0));
        result.Add(new Vector3(0, 0, (h-1)));

        

        for(int i = 0; i < h-1; i++)
        {
            int begin = i == 0 ? -(h - 2 - i) : -(h - 1 - i);
            int end = i == 0 ? (h - 2 - i) : (h - 1 - i);
            for(int j = begin; j <= end; j++)
            {
                result.Add(new Vector3(j, 0, i));
                count++;
                if(count >= amount) break;
            }
            if (count >= amount) break;
        }

        return result;
       
    }

    public static List<Vector3> Rectangle(int amount){

        int rows = Mathf.CeilToInt(Mathf.Sqrt(amount));
        int cols = Mathf.CeilToInt((float)amount / rows);
        Vector2 shiftCenter = new Vector2(cols/2, rows/2);

        Vector2[,] matrix = new Vector2[rows,cols];
        CreateMatrix(amount, matrix, rows, cols);
        List<Vector3> result = CreateVector3List(matrix,shiftCenter);


        return result;
    }

    public static void CreateMatrix(int total, Vector2[,] matrix, int rows, int cols)
    {

        int index = 0;
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < cols; y++)
            {
                if (index < total)
                {
                    matrix[x, y] = new Vector2(x, y); 
                    index++;
                }
                else
                {
                    matrix[x, y] = new Vector2(-1, -1); 
                }
            }
        }
    }

    public static List<Vector3> CreateVector3List(Vector2[,] matrix, Vector2 shiftCenter)
    {
        List<Vector3> vector3List = new List<Vector3>();

        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                if (matrix[x, y].x != -1 && matrix[x, y].y != -1)
                {
                    vector3List.Add(new Vector3(matrix[x, y].x -shiftCenter.x , 0, matrix[x, y].y-shiftCenter.y)); 
                }
            }
        }

        return vector3List;
    }

}