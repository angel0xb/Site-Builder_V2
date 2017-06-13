using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateGen : MonoBehaviour {

	//template for 3d coordinates
	private int[] template = {0, 0, 0};

	public List<int[]> coordList = new List<int[]>();

	//	public coordList2 [,] ; 

	public int[,] coordArray;

	//dummy input from the cornerfinder
	private int[,] pixelMap={{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0}};

	//iterate through the given corner map to find corners and their matching pairs
	public List<int[]> coordinateGeneration(int [,] map)
	{



		for(int i = 0; i < map.GetLength(0); ++i)
		{
			for(int j = 0; j < map.GetLength(1); ++j)
			{
				if( map[i,j] == 1)
				{
					checkConnection(map, i, j);
					if (coordList != null) {
						template [0] = j;
						template [1] = i;
						template [2] = 0;
						coordList.Add(template);
					}
				}
			}
		}
//		Debug.Log (coordList);
		//		coordArray = coordList.ToArray();
		return coordList;

	}

	//check for other corners in the same row or column given the position of a corner
	public void checkConnection(int [,] map, int y, int x)
	{


		//checks the row for a matching corner
		for(int i = x; i < map.GetLength(1); i++)
		{
			if(map[y,i] == 1)
			{
				template[0] = i;
				template[1] = y;
				template[2] = 0;
				coordList.Add(template);
			}
		}

		//checks the colomn for a mathching corner
		for (int i = y; i < map.GetLength(0); i++)
		{
			if (map[i, x] == 1)
			{
				template[0] = x;
				template[1] = i;
				template[2] = 0;
				coordList.Add(template);
			}
		}
		//Debug feed
//		Debug.Log(coordList);
	}
	static T[,] CreateRectangularArray<T>(IList<T[]> arrays)
	{
		// TODO: Validation and special-casing for arrays.Count == 0
		int minorLength = arrays[0].Length;
		T[,] ret = new T[arrays.Count, minorLength];
		for (int i = 0; i < arrays.Count; i++)
		{
			var array = arrays[i];
//			if (array.Length != minorLength)
//			{
//				throw new ArgumentException
//				("All arrays must be the same length");
//			}
			for (int j = 0; j < minorLength; j++)
			{
				ret[i, j] = array[j];
			}
		}
		return ret;
	}

	// Use this for initialization
	void Start () {

		int[,] image = {	
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1, 1, 1, 0, 0, 0 ,0 ,0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
			{1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},


		};

		int [,] newImage = cornerMatch.cornerMatcher (image);
		int [,] newImage2 = cornerMatch.cornerMark (newImage);

		print ("corners " + newImage2[4,4]);
//		Debug.Log ("image length " + image.GetLength (0) * image.GetLength(1));
		//		int[,] coordPairs = 
		List<int[]> c = coordinateGeneration(newImage2);

		int[,] arr = CreateRectangularArray(c);



		for (int i = 0; i < arr.GetLength(0); i++) {
			Debug.Log ("lengh " + arr.GetLength(0));
			for (int j = 0; j < arr.GetLength (1); j++) {
				Debug.Log(" len " + arr.GetLength (1));
				print (arr [i, j]);
			}
			
		
		}
//		print (c.ToString ());ß

	}


}