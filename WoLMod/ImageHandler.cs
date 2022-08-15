using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace WOLModTemplate
{
	public static class ImageHandler
	{

		public static string FolderName = "TemplateSprites";

		
		public static Texture2D LoadPNG(string filePath, bool pointFilter=false)
		{
			Texture2D texture2D = new Texture2D(2, 2);
			byte[] data = File.ReadAllBytes(filePath);
			texture2D.LoadImage(data);
			texture2D.filterMode = (pointFilter ? FilterMode.Point : FilterMode.Bilinear);
			texture2D.Apply();
			//Debug.Log("Loading with color format " + texture2D.format);
			return texture2D;
		}
		public static Texture2D LoadTex2D(string path,bool pointFilter=false)
        {
			string path2 = FolderName+"/" + path + ".png";
			string text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path2);
			Texture2D texture2D = ImageHandler.LoadPNG(text,pointFilter);
			if (pointFilter)
			{
				texture2D.filterMode = FilterMode.Point;
				texture2D.Apply();
			}
			return texture2D;
		}
		
		public static byte[] LoadByteArray(string path)
        {
			string path2 = "Sprites/" + path + ".png";
			string text = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path2);
			return ImageHandler.LoadPNG(text).GetRawTextureData();
		}

		public static AudioClip LoadClip(string path,int samples, int channels, int freq)
        {
			string path2 = "Sprites/" + path ;
			return AudioClip.Create(path2,samples,channels,freq,false);
			
		}

		public static Sprite LoadSprite(string path)
		{
			Texture2D texture2D = LoadTex2D(path,true);
			texture2D.name = path;
			texture2D.filterMode = FilterMode.Point;
			texture2D.Apply();
			Rect rect = new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height);
			Sprite sprite = Sprite.Create(texture2D, rect, new Vector2(0.5f, 0.5f), 16f);
			sprite.name = path;
			return sprite;
		}
		public static Sprite LoadSprite(string path, Vector2 pivot)
		{
			Texture2D texture2D = LoadTex2D(path);
			texture2D.name = path;
			texture2D.filterMode = FilterMode.Point;
			Rect rect = new Rect(0f, 0f, (float)texture2D.width, (float)texture2D.height);
			Sprite sprite = Sprite.Create(texture2D, rect, pivot, 16f);
			sprite.name = path;
			return sprite;
		}



	}
}
