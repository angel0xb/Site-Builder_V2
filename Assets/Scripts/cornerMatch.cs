using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cornerMatch : MonoBehaviour {

	//	int[,] image = 
	//	{	{ 1,0,0,0,1}, 
	//		{ 0,246,250,246,0},
	//		{ 0,252,255,252,0},
	//		{ 0,246,250,246,0},
	//		{ 1,0,0,0,1}
	//	} ;

	//	int[,] image = {	
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1, 1, 1, 0, 0, 0 ,0 ,0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//		{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	//
	//		
	//	} ;

	public static int [,] cornerMark(int[,] image){


		for (int i = 0; i < image.GetLength(0)-1; ++i) {

			for (int j = 0; j < image.GetLength(1)-1; ++j) {

				if(image[i,j] != 9){

					image[i,j] = 0;

				}  

				else {
					image[i,j] = 1;
				}

			}
		}
		return image;
	}

	public static int[,] cornerMatcher(int[,] image){

		int[, ]topLeft =
		{{1, 1, 1} , 
		{1, 0,  0} , 
		{1, 0,  1}} ;

		int[,] topRight= 
		{{1, 1, 1} , 
			{   0,  0, 1} , 
			{   1,  0, 1}} ;


		int[,] botLeft = 
		{{1, 0, 1,}, 
			{1, 0, 0,}, 
			{1, 1, 1}} ;


		int[,] botRight = 
		{{  1, 0, 1} , 
			{   0, 0, 1} , 
			{1, 1,  1}} ;

		int[,] T = 
		{
			{1,0,1} ,
			{1,0,1} ,
			{0,0,0}
		} ;

		int [,] Tbot = 
		{
			{0,0,0} ,
			{1,0,1} ,
			{1,0,1}
		} ;

		//every column in the array
		for(int i = 1; i < image.GetLength(0)-1; ++i) {
			// every row in the array
			for (int j = 1; j < image.GetLength(0)-1; ++j) {

				// counter for each corner
				int topLeftMatchCount = 0;
				int topRightMatchCount = 0;
				int botLeftMatchCount = 0;
				int botRightMatchCount = 0;
				int Tcount = 0;
				int Tbotcount = 0; 
				//k and m are used to check compare to the preset arrays
				for(int k = 0;k < 3;++k){
					for(int m = 0;m < 3;++m){

						//if it is a match with pattern increment pattern count
						if(image[i+k-1,j+m-1] == topLeft[k,m]){
							//		                            	 System.out.println("MATCHED ");
							//		                            	 int x = i+k-1;
							//		                            	 int y = j+m-1;                    	 
							//		                            	 System.out.println("image ["+ x + "] [" + y+"]: " + image[i+k-1][j+m-1] + 
							//		                            			 "\ncorner ["+k+"] ["+m+"]: " + topLeft[k][m]);

							++topLeftMatchCount;            
						}

						if(image[i+k-1,j+m-1] == topRight[k,m]){

							++topRightMatchCount;
						}

						if(image[i+k-1,j+m-1] == botLeft[k,m]){

							++botLeftMatchCount;
						}

						if(image[i+k-1,j+m-1] == botRight[k,m]){

							++botRightMatchCount;
						}


						if(image[i+k-1,j+m-1] == T[k,m]){
//							Debug.Log("image " + image[i+k-1,j+m-1]);
//							Debug.Log("T " + T[k,m]);
//							Debug.Log("t count " + Tcount);
							++Tcount;
						}
						if(image[i+k-1,j+m-1] == Tbot[k,m]){

							++Tbotcount;
						}



					}

				}

				// if full match with pattern change vale accordingly 
				if(topLeftMatchCount == 9){
					Debug.Log("Found topLeft pattern at " + i + ", " + j);
					//		                  9 = top 7 = left
					image[i,j] = 9;
				}

				if(topRightMatchCount == 9){
					Debug.Log("Found topRight pattern at " + i + ", " + j);
					//		            	  top = 9 right = 8
					image[i,j] = 9;
				}

				if(botLeftMatchCount == 9 ){
					Debug.Log("Found botLeft pattern at " + i + ", " + j);
					//		            	  bot = 2 left = 7
					image[i,j] = 9;  
				}

				if(botRightMatchCount == 9 ){
					Debug.Log("Found botRight pattern at " + i + ", " + j);
					//		            	  bot = 2 right = 8
					image[i,j] = 9;  
				}


				if(Tbotcount== 9 ){
					Debug.Log("Found T pattern at " + i + ", " + j);
					//		            	  bot = 2 right = 8
					image[i,j] = 9;  
				}

				if(Tcount == 9 ){
					Debug.Log("Found Tbot pattern at " + i + ", " + j);
					//		            	  bot = 2 right = 8
					image[i,j] = 9;  
				}

			}
		}
		return image;
	}  
	//
		public void Start(){

			int[,] image = {	
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1, 1, 1, 0, 0, 0 ,0 ,0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
				{ 1, 1 ,1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
		
				
			} ;
	//
			cornerMatcher (image);
			cornerMark(image);
	//		print (image[4,5]);
	//
	////		for (int r = 0; r < image.GetLength(0); r++) {
	////			for (int p = 0; p < image.GetLength(1); p++)  {
	////				print (r);
	////				print( image[r]);
	////			}
	////			print("\n");
	////		}
	//////		Debug.Log();
		}

}

