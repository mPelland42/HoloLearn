enum CoordinateType  {Cartesian, Cylindrical, Spherical};  
public delegate double MathFunction (double arga, double argb);
public static GameObject CreateSurface(MathFunction func, double step, int numSteps, CoordinateType coordinateType) { //func is a delegate, CoordinateType is an enum
    GameObject go = new GameObject("Plane");
    MeshFilter mf = go.AddComponent(typeof(MeshFilter)) as MeshFilter;
    MeshRenederer mr = go.AddComponent(typeof(MeshRenederer)) as MeshRenederer;
    Mesh m = new Mesh();
    m.vertices = new Vector3[(numSteps * 2 + 1) * (numSteps * 2 + 1)];
    for(int i = 0; i <= numSteps * 2; i++) {
        for(int j = 0; j <= numSteps * 2; j++) {
           
            if(coordinateType == CoordinateType.Cartesian) {    
                double x = (i - numSteps) * step;
                double y = (j - numSteps) * step;           
                m.vertices[(numSteps * 2 * i + 1) + j] = new Vector3(x, y, func(x, y));
            } else if(coordinateType == CoordinateType.Cylindrical) {
                double r = (i - numSteps) * step;
                double theta = j * 2 * pi / numSteps;
                m.vertices[(numSteps * 2 * i + 1) + j] = new Vector3(r * cos(theta), r * sin(theta), func(x, y));
            } else if(coordinateType == CoordinateType.Spherical) {
                double phi = j * pi / numSteps;
                double theta = j * 2 * pi / numSteps;
                m.vertices[(numSteps * 2 * i + 1) + j] = new Vector3(func(x, y) * sin(phi) * cos(theta), func(x, y) * sin(phi) * sin(theta), func(x, y) * cos(phi));
            }

        }
    }
    int numQuads = numSteps * numSteps * 4;
    m.uv = new Vector2[] {
        new Vector2(0,0);
        new Vector2(0,1);
        new Vector2(1,0);
        new Vector2(1,1);
    }
    m.triangles = new int[6 * numQuads];
    int iter = 0;
    for(int i = 0; i < numSteps * 2; i++) {
        for(int j = 0; j < numSteps * 2; j++) {           
            m.triangles[iter++] = (numSteps * 2 * i + 1) + j;
            m.triangles[iter++] = (numSteps * 2 * (i + 1) + 1) + j;
            m.triangles[iter++] = (numSteps * 2 * (i + 1) + 1) + (j + 1);
            m.triangles[iter++] = (numSteps * 2 * i + 1) + j;
            m.triangles[iter++] = (numSteps * 2 * i + 1) + (j + 1);
            m.triangles[iter++] = (numSteps * 2 * (i + 1) + 1) + (j + 1);
        }
    }
    mf.mesh = m;
    m.RecalculateNormals(); 
}