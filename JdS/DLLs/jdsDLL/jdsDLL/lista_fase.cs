using System.Collections;
using System.Collections.Generic;
using System;



struct tipo_obj{
	string tipo;
	float x;
	float y;

}
struct tipo_player{
	float x;
	float y;
	int vida_max;
	float corda_max;
	int vida;
	float corda;

}

[System.Serializable]

public class lista_fase{
	tipo_player jog;
	List<tipo_obj> objs;

}