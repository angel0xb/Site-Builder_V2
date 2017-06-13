using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData {
	public int[,] data {get; set;}
	public int width{get; set;}
	public int height{get; set;}


	public MapData(int[,] _data, int _width, int _height){
		this.data = _data;
		this.width = _width;
		this.height = _height;
	}
}
