using UnityEngine;
using System.Collections;
using System.IO;
//using UnityStandardAssets.ImageEffects;

//https://forum.unity3d.com/threads/contribution-texture2d-blur-in-c.185694/
public class Blur : MonoBehaviour {

	private float avgR = 0;
	private float avgG = 0;
	private float avgB = 0;
	private float avgA = 0;
	private float blurPixelCount = 0;

	public int radius =2;
	public int iterations =2;

	private Texture2D oringalIMG;
	private Texture2D blurredIMG;




	Texture2D FastBlur(Texture2D image, int radius, int iterations){
		Texture2D tex = image;

		for (var i = 0; i < iterations; i++) {

			tex = BlurImage(tex, radius, true);
			tex = BlurImage(tex, radius, false);

		}

		return tex;
	}



	Texture2D BlurImage(Texture2D image, int blurSize, bool horizontal){

		Texture2D blurred = new Texture2D(image.width, image.height);
		int _W = image.width;
		int _H = image.height;
		int xx, yy, x, y;

		if (horizontal) {
			for (yy = 0; yy < _H; yy++) {
				for (xx = 0; xx < _W; xx++) {
					ResetPixel();

					//Right side of pixel

					for (x = xx; (x < xx + blurSize && x < _W); x++) {
						AddPixel(image.GetPixel(x, yy));
					}

					//Left side of pixel

					for (x = xx; (x > xx - blurSize && x > 0); x--) {
						AddPixel(image.GetPixel(x, yy));

					}


					CalcPixel();

					for (x = xx; x < xx + blurSize && x < _W; x++) {
						blurred.SetPixel(x, yy, new Color(avgR, avgG, avgB, 1.0f));

					}
				}
			}
		}

		else {
			for (xx = 0; xx < _W; xx++) {
				for (yy = 0; yy < _H; yy++) {
					ResetPixel();

					//Over pixel

					for (y = yy; (y < yy + blurSize && y < _H); y++) {
						AddPixel(image.GetPixel(xx, y));
					}
					//Under pixel

					for (y = yy; (y > yy - blurSize && y > 0); y--) {
						AddPixel(image.GetPixel(xx, y));
					}
					CalcPixel();
					for (y = yy; y < yy + blurSize && y < _H; y++) {
						blurred.SetPixel(xx, y, new Color(avgR, avgG, avgB, 1.0f));

					}
				}
			}
		}

		blurred.Apply();
		return blurred;
	}
	void AddPixel(Color pixel) {
		avgR += pixel.r;
//		Debug.Log ("pixel r " + pixel.r);
		avgG += pixel.g;
//		Debug.Log ("pixel g " + pixel.g);
		avgB += pixel.b;
//		Debug.Log ("pixel b " + pixel.b);
		blurPixelCount++;
	}

	void ResetPixel() {
		avgR = 0.0f;
		avgG = 0.0f;
		avgB = 0.0f;
		blurPixelCount = 0;
	}

//	Guasian Calculation
	void CalcPixel() {
		avgR = avgR / blurPixelCount;
		avgG = avgG / blurPixelCount;
		avgB = avgB / blurPixelCount;
	}



	// Use this for initialization
	void Start () {



		oringalIMG = LoadPNG("/Users/angelrodriguez/GitHub/Site-Builder-462/Assets/Images/bp1.jpg");

		Debug.Log ("we blurring bby");

		blurredIMG = FastBlur(oringalIMG,5,2);

	}



	//loads image using file path creating a 2D texture
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

	void OnGUI() {

		//		Rect rect = new Rect(Screen.width/4, 200, Screen.width/2, Screen.height/2);//Rect to put the texture on\
		Rect rect = new Rect(10, 150, 350, 453);//Rect to put the original texture on
		Rect rect2 = new Rect(410, 150, 350, 453);//Rect to put the blurred texture on
		Rect rect3 = new Rect(800,150,350,453);
		if (oringalIMG != null) {
//			Debug.Log ("Drawing OG verison");
			GUI.DrawTexture(rect, oringalIMG,ScaleMode.StretchToFill);//draws the texture on the rect

//			TextureFilter

		}

		// if blurred image exists then draw it on a rect
		if (blurredIMG != null) {
//			Debug.Log ("Drawing blurry bby");
			GUI.DrawTexture(rect2, blurredIMG,ScaleMode.StretchToFill);//draws the texture on the rect


		}



	}

}
