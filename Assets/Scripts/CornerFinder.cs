using UnityEngine;
using System.Collections;

public class CornerFinder : MonoBehaviour {
	 
	int[,] pixelMap = new int [10,10] {{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,1,1,1,1,1,1,0,0},{0,0,1,0,0,0,0,1,0,0},{0,0,1,0,0,0,0,1,0,0},{0,0,1,0,0,0,0,1,0,0},{0,0,1,0,0,0,0,1,0,0},{0,0,1,1,1,1,1,1,0,0},{0,0,0,0,0,0,0,0,0,0},{0,0,0,0,0,0,0,0,0,0}};

	public bool checkNeighbors(int i_y, int i_x, int[,] currentMap){
		if ((currentMap [i_y + 1, i_x] == 1) || (currentMap [i_y - 1, i_x] == 1)) {
			if ((currentMap [i_y, i_x + 1] == 1) || (currentMap [i_y, i_x - 1] == 1)) {
				return true;
			}else{
				return false;
			}
		} else {
			return false;
		}
	}
	public void findingCorners(int[,] pixelMap){

		for(int y = 0; y < pixelMap.GetLength(0); y++){
			for(int x = 0; x < pixelMap.GetLength (1); x++){
				if(pixelMap[y,x] == 1){
					bool isCorner = checkNeighbors(y,x,pixelMap);
					Debug.Log(isCorner);
					}
				}
			}

		}

	public void Start(){
		findingCorners (pixelMap);
	}
}

