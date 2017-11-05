using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SurfaceDrawer : MonoBehaviour {
	public float scaling;
	public float rotateAngle;
	// Use this for initialization
	public GameObject[,] pointArray;
	void Start () {
		pointArray = new GameObject[40,40];
        //for (int x = -20; x <= 20; x++)
        //{
        //    for (int y = -20; y <= 20; y++)
        //    {
        //        pointArray[x + 20, y + 20] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //        pointArray[x + 20, y + 20].transform.position = gameObject.transform.position + new Vector3((float)((x * Math.Cos(rotateAngle)) - ((y) * Math.Sin(rotateAngle))) * 0.5f / 20, (float)(x * x + y * y) * 0.5f / 20, (float)(((y) * Math.Cos(rotateAngle)) + (x * Math.Sin(rotateAngle))) * 0.5f / 20);
        //        pointArray[x + 20, y + 20].transform.localScale = new Vector3(0.05f * 0.5f, 0.05f * 0.5f, 0.05f * 0.5f);
        //    }
        //}
        for (double x = -1 * 0.5f; x <= 1 * 0.5f; x += 0.05 * 0.5f)
        {
            for (double y = -1 * 0.5f; y <= 1 * 0.5f; y += 0.05 * 0.5f)
            {
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.position = gameObject.transform.position + new Vector3((float)(x * Math.Cos(rotateAngle)) - (float)((y) * Math.Sin(rotateAngle)), (float)(x * x + y * y), (float)((y) * Math.Cos(rotateAngle)) + (float)(x * Math.Sin(rotateAngle)));
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.localScale = new Vector3(0.05f * 0.5f, 0.05f * 0.5f, 0.05f * 0.5f);

            }
        }
    }

	// Update is called once per frame
	void Update () {
        for (double x = -1 * 0.5f; x <= 1 * 0.5f; x += 0.05 * 0.5f)
        {
            for (double y = -1 * 0.5f; y <= 1 * 0.5f; y += 0.05 * 0.5f)
            {
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.position = gameObject.transform.position + new Vector3((float)(x * Math.Cos(rotateAngle)) - (float)((y) * Math.Sin(rotateAngle)), (float)(x * x + y * y), (float)((y) * Math.Cos(rotateAngle)) + (float)(x * Math.Sin(rotateAngle)));
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.localScale = new Vector3(0.05f * 0.5f, 0.05f * 0.5f, 0.05f * 0.5f);

            }
        }
    }

	public enum CoordinateType  {Cartesian, Cylindrical, Spherical};  
	public delegate double MathFunction (double arga, double argb);
	public static GameObject CreateSurface(MathFunction func, double step, int numSteps, CoordinateType coordinateType) { //func is a delegate, CoordinateType is an enum
		GameObject go = new GameObject("Plane");
		MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
		MeshRenderer mr = go.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		Mesh m = new Mesh();
		m.vertices = new Vector3[(numSteps * 2 + 1) * (numSteps * 2 + 1)];
		for(int i = 0; i <= numSteps * 2; i++) {
			for(int j = 0; j <= numSteps * 2; j++) {

				if(coordinateType == CoordinateType.Cartesian) {    
					double x = (i - numSteps) * step;
					double y = (j - numSteps) * step;           
					m.vertices[(numSteps * 2 * i) + j] = new Vector3((float)x, (float)y, (float)func(x, y));
				} else if(coordinateType == CoordinateType.Cylindrical) {
					double r = (i - numSteps) * step;
					double theta = j * 2 * Math.PI / numSteps;
					m.vertices[(numSteps * 2 * i) + j] = new Vector3((float)(r * Math.Cos(theta)), (float)(r * Math.Sin(theta)), (float)(func(r, theta)));
				} else if(coordinateType == CoordinateType.Spherical) {
					double phi = j * Math.PI / numSteps;
					double theta = j * 2 * Math.PI / numSteps;
					m.vertices[(numSteps * 2 * i) + j] = new Vector3((float)(func(phi, theta) * Math.Sin(phi) * Math.Cos(theta)), (float)(func(phi, theta) * Math.Sin(phi) * Math.Sin(theta)), (float)(func(phi, theta) * Math.Cos(phi)));
				}

			}
		}
		int numQuads = numSteps * numSteps * 4;
		m.uv = new Vector2[] {
			new Vector2 (0, 0),
			new Vector2 (0, 1),
			new Vector2 (1, 0),
			new Vector2 (1, 1)
		};
		m.triangles = new int[6 * numQuads];
		int iter = 0;
		for(int i = 0; i < numSteps * 2; i++) {
			for(int j = 0; j < numSteps * 2; j++) {           
				m.triangles[iter++] = (numSteps * 2 * i) + j;
				m.triangles[iter++] = (numSteps * 2 * (i + 1)) + j;
				m.triangles[iter++] = (numSteps * 2 * (i + 1)) + (j + 1);
				m.triangles[iter++] = (numSteps * 2 * i) + j;
				m.triangles[iter++] = (numSteps * 2 * i) + (j + 1);
				m.triangles[iter++] = (numSteps * 2 * (i + 1)) + (j + 1);
			}
		}
		mf.mesh = m;
		m.RecalculateBounds();
		m.RecalculateNormals(); 
		return go;
	}

}
