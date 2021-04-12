using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScript : MonoBehaviour
{
    [SerializeField]
    internal AIManagerScript aiManagerScript;

    [SerializeField]
    internal Vector3 aiJump;

    [SerializeField]
    internal string[,] instructionArray;

    [SerializeField]
    internal List<Vector3> skillList;

    [SerializeField]
    internal bool isSealed;


    private void Start()
    {
        instructionArray = new string[100, 100];
        skillList = new List<Vector3>();
    }

    //El personaje que maneja la AI tiene habilidades (caminar incluida) con las cuales se va a trazar el recorrido mas rapido desde un punto A (donde esta el personaje) hasta un punto B (la proxima seccion del juego). La idea es que use estas habilidades para decir la distancia entre los puntos A y B a 0.
    //Las tres entradas al algoritmo son: la posicion actual del personaje, la posicion del destino, y el mapa de lineas.
    //La salida es una secuencia de acciones para que realize la AI. Es un array que se va leyendo de posicion a posicion, cada cual con una accion y con las caracteristicas de esta.
    //El resultado tiene que ser un array que contenga la secuencia de acciones a tomar por la AI.
    
    //Este algoritmo es extremadamente caro, pero abarca TODAS las posibilidades que puede llegar a tener la AI. Se asegura de que siempre, y solamente, se elija el camino mas corto de todos.

    //Nota: El cambio de direccion no es automatico ni instantaneo. Todo SetCourse tiene que tener en cuenta la inercia actual a la que esta sujeto el rigidbody.

    //Antes de jugar al Curse of Dead Gods voy a terminar con esto.

    public void SetCourse(List<Line> lineList, Vector3 startPosition, Vector3 endPosition)
    {
        Vector3 currentPosition = startPosition;
        //Paso 1: Determinar trayectoria actual. Si la velocidad es 0, no se considera.
        //Una trayectoria esta determinada por una linea con un angulo, por ende es una funcion cuadratica.
        //La idea es, en base a la velocidad actual (vector3) del objeto y la gravedad (10.0f) calcular la funcion cuadratica de la trayectoria. La lineList tiene vectores con dos valores cada uno, una x y una y que determinan la posicion de los vertices, y estos a su vez de la linea. Como hace el AoE para determinar, entonces, donde hay una linea si es incapaz de abarcar sus vertices? Cada linea es, tambien, una funcion lineal. Hay que averiguar la funcion lineal de cada una.
        //Entonces, un cuadrado, por ejemplo, se representaria por sus cuatro funciones lineales siendo limitadas por los vertices. Seria algo como y=3 para una linea horizontal o x=3 para una linea vertical. En el caso de la linea horizontal, su rango estaria determinado por los puntos entre los que existe- por ende, entre x=1 y x=5 si fuera una linea que va de 1 a 5. Como se determinaria entonces, por ejemplo, si la linea vertical la cruza?
        //Atributos:
        //Linea A: y=3 entre x=1 y x=5
        //Linea B= x=3 entre y=1 y y=5

        //Paso 2: Crear dos copias de la trayectoria a una distancia de esta equivalente al rango maximo de cada habilidad, formando el rango.
        //Paso 3: Determinar todas las veces que el rango engloba una linea alcanzable por una habilidad, creando las elecciones. No hacer nada cuenta como una eleccion.
        //Paso 4: Revisar la matriz de las decisiones. Si una de las decisiones a tomar en esa ruta se considera DE o GE, no se añade a las elecciones tomables.
        //Paso 5: Elegir una de las elecciones.
        //Paso 5 else: Si no hay elecciones tomables, insertar un DE en la matriz de decisiones.
        //Paso 6: Calcular el peso de la decision, que es el tiempo que se tarde en ejecutarse.
        //Paso 7: Agregar la eleccion a la matriz de decisiones, junto con su peso.
        //Paso 8: Si la decision actual llego a la endPosition, se añade GE (Good End) al final de ese vector.
        //Paso 9: Actualizar la currentPosition para que sea equivalente a la posicion de la eleccion.



    }


}