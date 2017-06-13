using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class loadimage2 : MonoBehaviour {



 public static Texture2D LoadPNG(string filePath) {
 
     Texture2D tex = null;
     byte[] fileData;
 
     if (File.Exists(filePath))     {
         fileData = File.ReadAllBytes(filePath);
         tex = new Texture2D(2, 2);
         tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
     }
     return tex;
 }

}
