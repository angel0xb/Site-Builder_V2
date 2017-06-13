using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScanner : MonoBehaviour
{

    public Texture2D map;
    private Vector2 pos;
    private int[,] binaryImage;
    // Use this for initialization
    void Start()
    {
        binaryImage = GetMapData(); //Get the map data and assign it to a variable;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        drawMap();
    }

    /// <summary>
    /// Using the texture's pixel data, creates a new binary map using black and white values.
    /// </summary>
    /// <returns>mapData</returns>
    public int[,] GetMapData()
    {
        int[,] mapData = new int[map.width, map.height]; //Create a new array to store all the data
        int walker = 0; //Next, create an object to walk every pixel and examine it's color
        Color[] mapPixelData = map.GetPixels(); //Converts the image into a 1D array of color values


		/* We need to convert the 1D to a 2D, so using the heigh and width values, we populate mapData with binary values
		// For every white pixel, we create a blank space, indicated with a 0. A 1 is placed where any color is found.
		// 1 is used later to create a wall object.
		*/

        for (int y = 0; y < map.height; y++)
        {
            for (int x = 0; x < map.width; x++)
            {
                if (mapPixelData[walker] == Color.white) { mapData[x, y] = 0; } //Return a zero if white is found
                else mapData[x, y] = 1;  //Otherwise, return a 1
                walker++; //Finally, incriment the walker
            }
        }
        //Debug.Log(string.Format("Map Data Retrieved. {0} entries", mapData.Length));
       // Debug.Log(string.Format("Map Data: {0}, Color {1}", mapData[1, 1], mapPixelData[10]));
	   
        return mapData;
    }

    /// <summary>
    /// Draws the data extracted for the map for visualization. For debugging purposes.
    /// </summary>
    private void drawMap(){
         if(binaryImage != null){
            for(int y = 0; y < map.height; y++){
                for(int x = 0; x < map.width; x++){
                    if(binaryImage[x,y] == 1){
                        Gizmos.color = Color.black; //If the data returns a 1, draw it
                    Vector3 pos = new Vector3(-map.width/2 + x, -map.height/2 +y, 0);
                    Gizmos.DrawCube(pos, Vector3.one);
                    }
                }
            }
        }
    }
}
