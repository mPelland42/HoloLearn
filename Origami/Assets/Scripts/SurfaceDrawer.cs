using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class SurfaceDrawer : MonoBehaviour {
    public bool rotating;
    public float scaling;
    public float rotateAngle;
    public float rotatingDelta;
    public static BinaryExpression function = new BinaryExpression("x^2 - y^2");
	string functionString;
	bool makingNewFunction;
	GameObject text;
    // Use this for initialization
    public GameObject[,] pointArray;
	public float[,] targetValues;
    /*public static void main(String[] args) {
		Scanner s = new Scanner(System.in);
		while(true) {
			String ex = s.nextLine();
			Matcher matcher;
			do {
				matcher = Pattern.compile("[A-Za-z0-9\\)]\\s*[\\(\\-a-zA-Z0-9]").matcher(ex); //implied multiplication
				if(matcher.find()) {
					ex = ex.substring(0, matcher.start() + 1) + "*" + ex.substring(matcher.start() + 1);
				}
			} while(matcher.find());
			BinaryExpression exp = new BinaryExpression(ex); 
			System.out.println(exp.evaluate(s.nextDouble(), s.nextDouble()));
			s.nextLine();
		}
	}*/
    void Start() {
		text = GameObject.Find ("Text");
		functionString = "x^2 - y^2";
		rotating = false;
		makingNewFunction = false;
        pointArray = new GameObject[40, 40];
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
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.position = gameObject.transform.position + new Vector3((float)(x * Math.Cos(rotateAngle + rotatingDelta)) - (float)((y) * Math.Sin(rotateAngle + rotatingDelta)), (float)(function.evaluate(x, y)), (float)((y) * Math.Cos(rotateAngle + rotatingDelta)) + (float)(x * Math.Sin(rotateAngle + rotatingDelta)));
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.localScale = new Vector3(0.05f * 0.5f, 0.05f * 0.5f, 0.05f * 0.5f);

            }
        }
    }

    // Update is called once per frame
    void Update() {
		if (rotating) {
			rotateAngle += (float)(Math.PI / 100);
		}
		float deltaZ;
		float newZ;
        for (double x = -1 * 0.5f; x <= 1 * 0.5f; x += 0.05 * 0.5f)
        {
            for (double y = -1 * 0.5f; y <= 1 * 0.5f; y += 0.05 * 0.5f)
            {
				pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.position = gameObject.transform.position + new Vector3((float)(x * Math.Cos(rotateAngle + rotatingDelta)) - (float)((y) * Math.Sin(rotateAngle + rotatingDelta)), (float)(function.evaluate(x, y)), (float)((y) * Math.Cos(rotateAngle + rotatingDelta)) + (float)(x * Math.Sin(rotateAngle + rotatingDelta)));
                pointArray[(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)].transform.localScale = new Vector3(0.05f * 0.5f, 0.05f * 0.5f, 0.05f * 0.5f);

            }
        }
    }

    void OnRotate() {
        rotating = true;
    }
    void OnStop() {
        rotating = false;
    }
	void OnPlane(){
		function = new BinaryExpression ("0");
	}
	void OnSaddle(){
		function = new BinaryExpression("x^2-y^2");
	}
	void OnParaboloid(){
		function = new BinaryExpression("x^2+y^2");
	}
	public void updateEquation(string expression){
		function = new BinaryExpression (expression);
		for (double x = -1 * 0.5f; x <= 1 * 0.5f; x += 0.05 * 0.5f)
		{
			for (double y = -1 * 0.5f; y <= 1 * 0.5f; y += 0.05 * 0.5f)
			{
				targetValues [(int)(x * 40 + 40 * 0.5f), (int)(y * 40 + 40 * 0.5f)] = gameObject.transform.position.y + (float)(function.evaluate (x, y));
			}
		}
	}

	void OnGraph(){
        OnSaddle();
		makingNewFunction = true;
		functionString = "";
	}
	void OnGo(){
        OnPlane();
		makingNewFunction = false;
		function = new BinaryExpression (functionString);

	}
	void On0(){
		functionString += "0";
		text.GetComponent<Text> ().text = functionString;
	}
	void On1(){
		functionString += "1";
		text.GetComponent<Text> ().text = functionString;
	}
	void On2(){
		functionString += "2";
		text.GetComponent<Text> ().text = functionString;;
	}
	void On3(){
		functionString += "3";
		text.GetComponent<Text> ().text = functionString;
	}
	void On4(){
		functionString += "4";
		text.GetComponent<Text> ().text = functionString;
	}
	void On5(){
		functionString += "5";
		text.GetComponent<Text> ().text = functionString;
	}
	void On6(){
		functionString += "6";
		text.GetComponent<Text> ().text = functionString;
	}
	void On7(){
		functionString += "7";
		text.GetComponent<Text> ().text = functionString;
	}
	void On8(){
		functionString += "8";
		text.GetComponent<Text> ().text = functionString;
	}
	void On9(){
		functionString += "9";
		text.GetComponent<Text> ().text = functionString;
	}
	void OnX(){
        OnParaboloid();
		functionString += "x";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnY(){
		functionString += "y";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnOpenParen(){
		functionString += "(";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnCloseParen(){
		functionString += ")";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnTimes(){
		functionString += "*";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnDividedBy(){
		functionString += "/";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnPlus(){
		functionString += "+";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnMinus(){
		functionString += "-";
		text.GetComponent<Text> ().text = functionString;

	}
	void OnPower(){
		functionString += "^";
		text.GetComponent<Text> ().text = functionString;

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
