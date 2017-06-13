using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
using UnityEngine.SceneManagement;

public class WallPoints : MonoBehaviour {

	public void firstScene(){
		SceneManager.LoadScene ("read", LoadSceneMode.Single);
	}

//	adds wall WallPoints into a  list from image and returns the list
	public List<Vector3> getWallPoints(int[,] image){
		List<Vector3> wallPoints = new List<Vector3>();
		//i: number of rows
		for (int i = 0; i <= image.GetLength(0)-1; ++i) {
//			print ("rows " + image.GetLength (0) );
			// j: number of cols
			for (int j = 0; j <= image.GetLength(1)-1; ++j) {
//				print ("col " + image.GetLength (1) );
				// if the it is a black pixel(0) add it to the Vector3 array
				if(image[i,j] == 0){


					wallPoints.Add(new Vector3 (j,20,i));

				}  
				// else {
				// 	image[i,j] = 1;
				// }

			}
		}

		return wallPoints;
	}


		
	//returns image of walls in x direction
	public int[,] xIMG(int [,] image){
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {


			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {


				if (image2 [i,j] == 0 && image2[i,j+1] == 0 ) {
					image2 [i,j] = 0;
				}
//			*****************add this if we want to get rid of those with no neighbors (single pix wall)*********
//				else {
//					image [i,j] = 1;
//				}
//			*****************add this if we want to get rid of those with no neighbors (single pix wall)*********
			}
		}
		for (int j = 0; j <= image2.GetLength(0)-1; ++j) {
			if (image2 [j,image2.GetLength(1) - 1] == 0 && image2[j,image2.GetLength(1) - 2] == 0) {
				image2 [j,image2.GetLength(1) - 1] = 0;
			}
//			*****************add this if we want to get rid of those with no neighbors (single pix wall)*********
//			else{
//				image2 [j,image2.GetLength(1) - 1] = 1;
//			}
//			*****************add this if we want to get rid of those with no neighbors(single pix wall)*********
		}
		return image2;
	}
		

	//	returns an image containing only the y points(more than 0 neighbors? more than 1 neighbor)
	public int[,] yIMG(int [,] image){


		for (int i = 0; i <= image.GetLength (0) - 2; ++i) {

			for (int j = 0; j <= image.GetLength (1) - 1; ++j) {
				

				if (image [i, j] == 0 && image[i+1,j] == 0) {
					
					image [i, j] = 0;
				} 
//				else {
//					image [i, j] = 1;
//				}

			}
		}
		for (int j = 0; j <= image.GetLength (1)-1; ++j) {
			if (image [image.GetLength (0) - 1,j] == 0 && image[image.GetLength (0) - 2,j] == 0) {
				image [image.GetLength (0) - 1,j] = 0;
			}
//			else{
//				image [image.GetLength (0) - 1,j] = 1;
//			}
		}
		return image;
	}


	//	returns the amount of continuous wall pixels int the x direction(length) starting from given row and col




	//returns the length of the wall in the x++ direction
	public static int xLen(int[,] image,int row,int col){
		int j =col;
		int count = 0;
		while(image[row,j] == 0 && j != image.GetLength(1) -1){
			j++;
			count++;

		}
		if(j == image.GetLength(1) -1 && image[row,j] ==0){
			count++;
		}

		return count;

	}

	//returns the length of the wall in the y++ direction
	public static int yLen(int [,]image, int row,int col){
		int j =row;
		int count = 0;
		while(image[j,col] == 0.0 && j != (image.GetLength(0) -1)){
			//				System.out.println("HERE");
			//				if(j != image[0].length -1){
			j++;
			//				}
			count++;

		}
		if(j == (image.GetLength(0) -1) && image[j,col] == 0){
			count++;
		}

		return count;

	}
		

//	public static int xLineSegs(int [,] image, int row)



	public Material brick;
	//draws walls in x direction using a cube object per wall
	public void drawX(int[,]image, int xScale,int yScale){
		int hi = 12;
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {

			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {

//				print ("drawing x");
//				if 0 create a cube 
				if (image2 [i,j] == 0  ) {
					GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
//					xcube.GetComponent<Renderer>().material.color = Color.blue;
//					GameObject xcube = GameObject.Find("bube");
					Renderer rend = xcube.GetComponent<Renderer>();
//					Material newMat = Resources.Load("Industrial_stone_Brick", typeof(Material)) as Material;
					rend.material =brick;

					int start = j ; // start at col j
					int length = xLen (image2,i,j) ; // get len in x direction(xwall) of given point(first 0 in x direction)
					int end = length + start - 1; //end point of xwall
					float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



					// x = length-1 (wall len -1 bc scale starts at 1)
					xcube.transform.localScale += new Vector3 (length-1 + xScale ,hi,0 + yScale);
//					xcube.transform.


					// get rid of remaining wall to avoid drawing cube for each 0 point
					for(int k =0; k < length; k++){
						image2 [i, j + k] = 1;
					}

					//create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
					Instantiate(xcube,new Vector3(midPoint + xScale,hi/2,i +yScale  ) , Quaternion.identity);


				
					Destroy (xcube);
				} 


			}
		}
	}




	//draws flat x image
	public void drawXF(int[,]image){
		int hi = 2;
		int [,]image2 =copyIMG (image);
		for (int i = 0; i <=  image2.GetLength (0) - 1; ++i) {

			for (int j = 0; j <= image2.GetLength (1) - 2; ++j) {

				//				if 0 create a cube 
				if (image2 [i,j] == 0  ) {
					GameObject xcube = GameObject.CreatePrimitive(PrimitiveType.Cube);
					xcube.GetComponent<Renderer>().material.color = Color.white;
//					xcube.transform.localPosition += new Vector3(0, -30, 0);
					xcube.transform.localScale += new Vector3 (0, (float)-.8,0 );
					int start = j; // start at col j
					int length = xLen (image2,i,j); // get len in x direction(xwall) of given point(first 0 in x direction)
					int end = length + start - 1; //end point of xwall
					float midPoint = (float)(start + end) / 2;//get mid point for instant. cube



					// x = length-1 (wall len -1 bc scale starts at 1)
					xcube.transform.localScale += new Vector3 (length-1,0,0);

					// get rid of remaining wall to avoid drawing cube for each 0 point
					for(int k =0; k < length; k++){
						image2 [i, j + k] = 1;
					}
					//create cube at midpoint for x bc cube scales both ways, some for y, z = row(i)
					Instantiate(xcube,new Vector3(midPoint,30,i) , Quaternion.identity);
					Destroy (xcube);
				} 


			}
		}
	}


//	returns copy of int[,] image
	public int [,]copyIMG(int[,] image){
		int[,] copy = image.Clone() as int[,];
		return copy;
	}



	public static Texture2D LoadPNG(string filePath) {

		Texture2D tex = null;// initiate texture
		byte[] fileData;

		Debug.Log ("loading.... " + filePath);
		if (File.Exists(filePath)) //if the file exists..    
		{
			Debug.Log ("file exists ");
			fileData = File.ReadAllBytes(filePath);//reads all the byes in the file
			tex = new Texture2D(2, 2);//creates in temperary texture
			tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
		}
		return tex;
	}
		
		

	//turns a flattened Color array into a 2D Color Array
	public Color[,] singleArrayToDouble( Color[] flattenedPixelArray,int width, int height){

		Color[,] pixels = new Color[width, height];

		for (int y = 0; y < height; y++) {

			for (int x = 0; x < width; x++) {

				pixels [x, y] = flattenedPixelArray [x * width + y];

			}
		}

		return pixels;

	}

	//2d Colors Array to a Binary int 2d array
	public int[,] ColorArrayToBinaryIntArray( Color[,] pixels,int width, int height){

		int[,] binaryPixels = new int[width,height];

		for (int y = 0; y < height; y++) {
			for (int x = 0; x < width; x++) {
				if (pixels [x, y] == Color.white) {
					binaryPixels [x,y] = 1;
				} else {
					binaryPixels [x, y] = 0;
				}
			}
		}

		return binaryPixels;

	}



	public Texture2D b;

	void Start () {

		string fp = GameObject.Find ("FileName").GetComponent<getFileName> ().filePath;

//		Texture2D b = LoadPNG("/Users/angelrodriguez/Desktop/house.png");
		Texture2D b = LoadPNG(fp);
		int width = b.width;
		int height = b.height;

		//get the pixels of the Texture/floorplan
		Color []pixelArray = b.GetPixels();

		//change to 2d array
		Color [,]pixels = singleArrayToDouble (pixelArray, width,height);

		//change into integer 2d array
		int[,]binaryPixels = ColorArrayToBinaryIntArray (pixels,width,height);

		GameObject floor = GameObject.Find("Floor");
		floor.transform.localPosition += new Vector3(width/2, 0, height/2);
		floor.transform.localScale += new Vector3 (width,0,height);

	

		drawXF (binaryPixels);
		drawX (binaryPixels,0,0);
//		drawX (binaryPixels, 10,10 );

//		drawXF (scaleX (scaleY (imagex, 8),8));



	}
		
}
