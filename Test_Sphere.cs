﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class Test_Sphere : MonoBehaviour
{
     string line;
    ArrayList arrayOfX = new ArrayList();
    ArrayList arrayOfY = new ArrayList();
    ArrayList arrayOfZ = new ArrayList();
    ArrayList arrayOfGray = new ArrayList();
     static int printCount =0 ;
public static void PrintValues( IEnumerable myList )  {
      foreach ( int obj in myList )
        Debug.Log(obj);
        printCount++;
        if(printCount >4)
        return ;
   }

    // Use this for initialization
   void Start()
    {
StreamReader reader = new StreamReader("Assets/Input/out1.txt");

     using (reader)
      {
          
          line = reader.ReadLine();
                
          if(line != null){
                  // While there's lines left in the text file, do this:
                  do
                  {
                         // Do whatever you need to do with the text line, it's a string now
                         // In this example, I split it into arguments based on comma
                         // deliniators, then send that array to DoStuff()
                         string[] entries = line.Split(' ');
                         if (entries.Length > 0)
                         arrayOfX.Add( (float) System.Convert.ToDouble(entries[0]));
                         arrayOfY.Add((float) System.Convert.ToDouble(entries[1]));
                         arrayOfZ.Add((float) System.Convert.ToDouble(entries[2]));
                         arrayOfGray.Add((float) System.Convert.ToDouble(entries[3]));
                         
                         line = reader.ReadLine();
                  }
                  while (line != null);
          } 
          // Done reading, close the reader and return true to broadcast success    
          reader.Close();
      }
       for(int i=0; i <arrayOfX.Count ;i+=3){
       // transform.localScale -= new Vector3((float) 1500000,0,0);
      GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
     sphere.transform.position = new Vector3((float) arrayOfX[i],(float) arrayOfY[i],(float) arrayOfZ[i]);
           }
   

    	GameObject.Find("Main Camera").transform.position = new Vector3(122,123, -15);
         Camera.main.fieldOfView = 15;
          Debug.Log("Done");
   		
		
    }
	
	// Update is called once per frame
	void Update()
    {

    
}
}
