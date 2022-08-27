using Sequence=System.Collections.IEnumerator;

/// <summary>
/// ゲームクラス。
/// 学生が編集すべきソースコードです。
/// </summary>
public sealed class Game : GameBase{
	// 変数の宣言
	int gameState;
	int cursolX;
	int cursolY;
	float playerX;
	float playerY;
	int dungeonX;
	int dungeonY;
	const int shotnum=100;
	int shotnow=0;
	float[] shotX=new float[shotnum];
	float[] shotY=new float[shotnum];
	float[] shotX2=new float[shotnum];
	float[] shotY2=new float[shotnum];
	int[] shotstate=new int[shotnum];
	int[] shotkind=new int[shotnum];
	const int bulnum=300;
	int bulnow=0;
	float[] bulX=new float[bulnum];
	float[] bulY=new float[bulnum];
	float[] bulangle=new float[bulnum];
	float[] bulspeed=new float[bulnum];
	int[] bulkind=new int[bulnum];
	const int itemnum=100;
	int itemnow=0;
	float[] itemX=new float[itemnum];
	float[] itemY=new float[itemnum];
	int[] itemkind=new int[itemnum];
	int shield;
	int fire;
	int speed;
	int time;
	int key;
	int HP;
	int hp;
	int jikistate;
	float keep_angle;
	const float pi=3.141592f;
	float player_angle;
	float ftemp1;
	float ftemp2;
	float ftemp3;
	float ftemp4;
	int itemp1;
	int itemp2;
	int[,] stage0=new int[67,74]{
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,2,2,2,2,2,2,2,2,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,2,2,2,2,2,2,2,2,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,2,2,2,2,2,2,2,2,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,2,2,2,2,2,2,2,2,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,2,2,2,2,2,2,2,2,2,2,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,5,1,1,5,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,2,2,1,1,2,2,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,1,0,0,1,1,0,0,1,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,1,0,1,1,1,1,0,1,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,1,1,1,2,2,1,1,1,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,2,2,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,5,0,1,2,2,1,0,5,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,2,2,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,2,2,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,1,2,2,1,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,1,2,2,1,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,5,1,2,2,1,5,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,2,2,2,2,2,2,2,2,2,2,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,5,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,1,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,1,1,1,1,1,0,1,1,1,1,1,1,1,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,0,0,1,1,1,1,1,0,1,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,7,7,7,0,1,1,1,1,1,1,1,1,1,1,1,1,0,1,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,3,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,7,0,7,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,3,0,0,0,0,0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{0,0,0,0,7,7,7,0,0,1,1,1,1,1,1,1,1,1,0,0,7,0,7,0,0,0,5,1,1,1,1,1,1,5,0,1,1,1,1,1,0,1,1,1,3,1,1,1,1,0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{0,0,0,0,7,0,7,0,0,1,1,1,1,1,1,1,1,1,0,0,7,0,7,0,0,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,3,1,1,1,1,0,3,3,1,1,1,1,5,0,3,3,3,3,3,1,1,1,1,1,1,3,3,3,3,3},
		{6,7,7,0,7,0,7,7,7,1,1,1,1,1,1,1,1,1,7,7,7,0,7,0,7,7,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,3,3,3,3,3,3,3,1,3,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,3,3,3,3,3},
		{0,0,7,0,7,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,7,0,7,0,1,1,1,1,1,1,1,1,0,1,1,1,1,1,0,1,1,1,3,1,1,1,1,0,3,3,1,1,1,1,5,0,3,3,3,3,3,1,1,1,1,1,1,3,3,3,3,3},
		{0,0,7,7,7,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,7,0,7,0,5,1,1,1,1,1,1,5,0,1,1,1,1,1,0,1,1,1,3,1,1,1,1,0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,7,0,7,0,0,0,0,1,1,0,0,0,0,0,0,1,0,0,0,0,0,0,3,0,0,0,0,0,3,3,3,3,3,3,3,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0,0,0,0,7,7,7,0,0,1,1,1,1,1,1,0,0,0,0,1,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,3,0,0,0,0,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,1,1,1,1,1,1,1,3,3,3,3,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,0,1,1,1,1,1,1,0,0,5,0,1,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,0,0,1,0,5,0,0,0,1,1,1,3,1,1,1,1,0,0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,4,1,4,1,1,4,1,4,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,4,1,4,1,1,4,1,4,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,1,4,4,4,4,1,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,1,4,4,4,4,1,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,4,1,4,1,1,4,1,4,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,4,1,4,1,1,4,1,4,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,1,1,4,4,4,4,1,1,0,0,1,1,4,4,4,4,1,1,0,0,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,5,0,1,1,4,4,4,4,1,1,0,0,1,1,4,4,4,4,1,1,0,5,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,4,4,4,4,1,1,0,0,1,1,4,4,4,4,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,1,1,1,4,4,4,1,1,1,1,4,4,4,1,1,1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,0,1,1,1,4,4,4,1,1,1,1,4,4,4,1,1,1,0,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,0,1,1,1,4,4,4,1,1,1,1,4,4,4,1,1,1,0,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,0,4,4,4,1,1,1,4,4,4,4,1,1,1,4,4,4,0,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,4,4,4,4,1,1,1,4,4,4,4,1,1,1,4,4,4,4,4,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5,0,4,4,4,1,1,1,4,4,4,4,1,1,1,4,4,4,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,4,4,4,1,1,1,1,4,4,4,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,4,4,4,1,1,1,1,4,4,4,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
		{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,4,4,4,1,1,1,1,4,4,4,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
	};
	const int enenum=150;
	int enenow;
	float[] eneX=new float[enenum]{
		120,120,120,360,360,600,600,600,840,840,1000,1000,1000,1000,1000,1000,1240,1240,1240,1240,1400,1400,1400,1400,1640,
		1640,1880,1880,2200,2200,2200,2200,2120,2600,2760,3240,2200,3160,2120,2280,3080,3240,2680,2200,3160,2600,2760,2600,2760,2440,
		2920,2120,2680,3240,2440,2920,2440,2920,2680,2440,2920,2680,2440,2920,3200,3200,3320,3320,3800,3800,4120,4120,4200,4200,4280,
		4280,4360,4360,4360,4360,4440,4440,4600,4760,4920,4600,4760,4920,4760,4760,4760,5000,5000,5240,5240,5240,360,360,360,360,
		360,360,360,360,2680,2680,2680,2680,2680,2680,2680,2680,5000,5000,5000,5000,5000,5000,5000,5000,2680,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};
	float[] eneY=new float[enenum]{
		1880,2400,2920,1960,2840,1880,2400,2920,2000,2800,1880,2120,2280,2520,2680,2920,2040,2280,2520,2760,1960,2280,2520,2840,2280,
		2520,1960,2840,2040,2200,2600,2760,3000,3000,3000,3000,3400,3400,3560,3560,3560,3560,3640,3720,3720,3800,3800,4040,4040,4200,
		4200,4280,4280,4280,4360,4360,4760,4760,4920,5280,5280,5640,5800,5800,2280,2520,1960,2840,2200,2600,2280,2520,1640,3160,2000,
		2800,1960,2040,2760,2840,2000,2800,1400,1400,1400,3400,3400,3400,1880,2400,2920,2120,2680,1880,2400,2920,2400,2400,2400,2400,
		2400,2400,2400,2400,5280,5280,5280,5280,5280,5280,5280,5280,2400,2400,2400,2400,2400,2400,2400,2400,1080,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};
	float[] eneangle=new float[enenum]{
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,180,0,0,0,
		0,0,0,0,180,0,0,0,0,0,0,0,180,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};
/*	int[] eneR=new int[enenum]{
		24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,24,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};*/
	int[] eneHP=new int[enenum]{
		500,1000,500,1000,1000,500,1000,500,1000,500,500,500,1000,500,1000,1000,1000,500,1000,500,500,1000,500,1000,500,
		1000,1000,500,500,1000,500,1000,500,500,1000,1000,1000,500,500,500,1000,1000,500,500,1000,500,500,1000,1000,1000,
		1000,500,500,1000,1000,1000,500,500,1000,1000,1000,1000,500,500,1000,500,1000,1000,500,500,1000,1000,1000,1000,1000,
		500,500,500,1000,1000,1000,500,500,500,500,500,500,500,500,1000,500,1000,1000,500,1000,500,2000,2000,2000,2000,
		2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,2000,32000,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};
	int[] enekind=new int[enenum]{
		4,1,4,1,1,4,1,4,1,4,4,4,1,4,1,1,1,4,1,4,4,1,4,1,4,1,1,4,4,1,4,1,5,5,2,2,2,5,5,5,2,2,5,5,2,5,5,2,2,2,
		2,5,5,2,2,2,5,5,2,2,2,2,5,5,3,6,3,3,6,6,3,3,3,3,3,6,6,6,3,3,3,6,6,6,6,6,6,6,6,3,6,3,3,6,3,6,7,7,7,7,
		7,7,7,7,8,8,8,8,8,8,8,8,9,9,9,9,9,9,9,9,10,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};
	int[] enestate=new int[enenum]{
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};
	int[] enesub=new int[enenum]{
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,-1,96,97,98,
		99,100,101,102,-1,104,105,106,107,108,109,110,-1,112,113,114,115,116,117,118,0,0,0,0,0,
		0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
	};

	/// <summary>
	/// 初期化処理
	/// </summary>
	public override void InitGame(){
		// キャンバスの大きさを設定します
		gc.SetResolution(720,1280);
		gameState=0;
	}

	/// <summary>
	/// 動きなどの更新処理
	/// </summary>
	public override void UpdateGame(){
		if(gameState==0){
			if(gc.GetPointerFrameCount(0)==1){
				gameState=1;
				playerX=2680;
				playerY=2400;
				dungeonX=stage0.GetLength(0);
				dungeonY=stage0.GetLength(1);
				for(int i=0;i<shotnum;i++){
					shotstate[i]=0;
				}
				for(int i=0;i<shotnum;i++){
					eneangle[i]=360*gc.Random();
				}
				jikistate=0;
				shield=10;
				fire=10;
				speed=30;
				time=10;
				key=0;
				HP=10;
				hp=3600;
				item(2280,1800,5);
				item(3080,1800,5);
				gameState=1;
			}
		}
		else if(gameState==1){
			shotnow=0;
			bulnow=0;
			itemnow=0;
			enenow=0;
			for(int i=0;i<shotnum;i++){//ショットの処理
				if(shotstate[i]>0){
					shotstate[i]--;
					if(gc.GetPointerFrameCount(0)==0&&shotkind[i]==0){
						shotstate[i]=time;
						shotkind[i]=1;
					}
					for(int j=0;j<enenum;j++){
						if(enekind[j]<=0){continue;}
						if(enekind[j]==10&&gc.CheckHitRect((int)eneX[j]-160,(int)eneY[j]-160,320,320,(int)shotX[i]-6,(int)shotY[i]-6,12,12)){
							if(shotkind[i]==0){
								ftemp1=getangle(eneX[j],eneY[j],playerX,playerY);
								if(ftemp1>=45&&ftemp1<=135){eneY[j]=playerY-200;}
								else if(ftemp1>=-45&&ftemp1<=45){eneX[j]=playerX-200;}
								else if(ftemp1>=-135&&ftemp1<=-45){eneY[j]=playerY+200;}
								else{eneX[j]=playerX+200;}
								enestate[j]=29;
								for(int k=0;k<16;k++){
									bullet(eneX[j]+144*gc.Cos(ftemp1+22.5f*k),eneY[j]+144*gc.Sin(ftemp1+22.5f*k),ftemp1+22.5f*k,1,4);
								}
								ftemp1=4*gc.Random();
								eneangle[j]=(int)ftemp1*90;
							}
							if(shotkind[i]==1){
								eneHP[j]-=fire;
								shotstate[i]=0;
								if(eneHP[j]<=0){
									enemy(eneX[j]-80,eneY[j]-80,8000,11);
									enemy(eneX[j]-80,eneY[j]+80,8000,11);
									enemy(eneX[j]+80,eneY[j]-80,8000,11);
									enemy(eneX[j]+80,eneY[j]+80,8000,11);
									enekind[j]=0;
								}
							}
						}
						else if(enekind[j]==11&&gc.CheckHitRect((int)eneX[j]-80,(int)eneY[j]-80,160,160,(int)shotX[i]-6,(int)shotY[i]-6,12,12)){
							if(shotkind[i]==0){
								ftemp1=getangle(eneX[j],eneY[j],playerX,playerY);
								if(ftemp1>=45&&ftemp1<=135){eneY[j]=playerY-120;}
								else if(ftemp1>=-45&&ftemp1<=45){eneX[j]=playerX-120;}
								else if(ftemp1>=-135&&ftemp1<=-45){eneY[j]=playerY+120;}
								else{eneX[j]=playerX+120;}
								enestate[j]=29;
								for(int k=0;k<4;k++){
									bullet(eneX[j]+64*gc.Cos(ftemp1+90*k),eneY[j]+64*gc.Sin(ftemp1+90*k),ftemp1+90*k,1,4);
								}
								ftemp1=4*gc.Random();
								eneangle[j]=(int)ftemp1*90;
							}
							if(shotkind[i]==1){
								eneHP[j]-=fire;
								shotstate[i]=0;
								if(eneHP[j]<=0){
									enemy(eneX[j]-40,eneY[j]-40,2000,12);
									enemy(eneX[j]-40,eneY[j]+40,2000,12);
									enemy(eneX[j]+40,eneY[j]-40,2000,12);
									enemy(eneX[j]+40,eneY[j]+40,2000,12);
									enekind[j]=0;
								}
							}
						}
						else if(enekind[j]==12&&gc.CheckHitRect((int)eneX[j]-40,(int)eneY[j]-40,80,80,(int)shotX[i]-6,(int)shotY[i]-6,12,12)){
							if(shotkind[i]==0){
								ftemp1=getangle(eneX[j],eneY[j],playerX,playerY);
								if(ftemp1>=45&&ftemp1<=135){eneY[j]=playerY-80;}
								else if(ftemp1>=-45&&ftemp1<=45){eneX[j]=playerX-80;}
								else if(ftemp1>=-135&&ftemp1<=-45){eneY[j]=playerY+80;}
								else{eneX[j]=playerX+80;}
								enestate[j]=29;
								bullet(eneX[j]+24*gc.Cos(ftemp1),eneY[j]+24*gc.Sin(ftemp1),ftemp1,1,4);
								ftemp1=4*gc.Random();
								eneangle[j]=(int)ftemp1*90;
							}
							if(shotkind[i]==1){
								eneHP[j]-=fire;
								shotstate[i]=0;
								if(eneHP[j]<=0){
									item(eneX[j],eneY[j],6);
									enekind[j]=0;
								}
							}
						}
						else if(gc.CheckHitCircle((int)shotX[i],(int)shotY[i],6,(int)eneX[j],(int)eneY[j],24)){
							if(shotkind[i]==0){
								ftemp1=getangle(playerX,playerY,eneX[j],eneY[j]);
								eneX[j]=playerX+64*gc.Cos(ftemp1);
								eneY[j]=playerY+64*gc.Sin(ftemp1);
								enestate[j]=29;
								if(enekind[j]>=7&&enekind[j]<=9){eneangle[j]=360*gc.Random();}
								else{eneangle[j]=getangle(eneX[j],eneY[j],playerX,playerY);}
							}
							if(shotkind[i]==1){
								eneHP[j]-=fire;
								shotstate[i]=0;
								if(eneHP[j]<=0){
									if((enekind[j]==1||enekind[j]==4)&&fire<20){item(eneX[j],eneY[j],1);}
									if((enekind[j]==1||enekind[j]==4)&&fire>=20){item(eneX[j],eneY[j],4);}
									if((enekind[j]==2||enekind[j]==5)&&time<20){item(eneX[j],eneY[j],2);}
									if((enekind[j]==2||enekind[j]==5)&&time>=20){item(eneX[j],eneY[j],4);}
									if((enekind[j]==3||enekind[j]==6)&&shield<20){item(eneX[j],eneY[j],3);}
									if((enekind[j]==3||enekind[j]==6)&&shield>=20){item(eneX[j],eneY[j],4);}
									if((enekind[j]>=7&&enekind[j]<=9)){item(eneX[j],eneY[j],6);}
									enekind[j]=0;
								}
							}
						}
					}
					if(shotkind[i]==0){
						for(int j=0;j<bulnum;j++){
							if(bulkind[j]<=0){continue;}
							if(gc.CheckHitCircle((int)shotX[i],(int)shotY[i],6,(int)bulX[j],(int)bulY[j],24)){
								bulkind[j]=0;
							}
						}
					}
				}
				if(shotstate[i]>0){
					shotX[i]+=shotX2[i];
					shotY[i]+=shotY2[i];
				}
			}
			for(int i=0;i<bulnum;i++){//弾の処理
				itemp1=(int)bulX[i]/80;
				itemp2=(int)bulY[i]/80;
				for(int j=itemp1-1;j<=itemp1+1;j++){//ブロックに当たって消える処理
					for(int k=itemp2-1;k<=itemp2+1;k++){
						if(j<0||j>=dungeonX||k<0||k>=dungeonY||stage0[j,k]==0||stage0[j,k]==7){
							if(gc.CheckHitCircle((int)bulX[i],(int)bulY[i],12,j*80+40,k*80+40,40)){
								bulkind[i]=0;
							}
						}
					}
				}
				if(bulkind[i]<=0){continue;}
				bulX[i]+=bulspeed[i]*gc.Cos(bulangle[i]);
				bulY[i]+=bulspeed[i]*gc.Sin(bulangle[i]);
				if(gc.CheckHitCircle((int)playerX,(int)playerY,24,(int)bulX[i],(int)bulY[i],12)){
					hp-=360;
					jikistate=60;
					bulkind[i]=0;
				}
			}
			if(gc.GetPointerFrameCount(0)==1){
				cursolX=gc.GetPointerX(0);
				cursolY=gc.GetPointerY(0);
			}
			itemp1=(int)playerX/80;
			itemp2=(int)playerY/80;
			if(gc.GetPointerFrameCount(0)>0){//移動処理
				if(!gc.CheckHitCircle(cursolX,cursolY,12,gc.GetPointerX(0),gc.GetPointerY(0),0)){
					player_angle=getangle(cursolX,cursolY,gc.GetPointerX(0),gc.GetPointerY(0));
					if(!gc.CheckHitCircle(cursolX,cursolY,60,gc.GetPointerX(0),gc.GetPointerY(0),0)){
						if(stage0[itemp1,itemp2]==3){
							playerX+=3.0f*gc.Cos(player_angle);
							playerY+=3.0f*gc.Sin(player_angle);
						}
						else{
							playerX+=5.0f*gc.Cos(player_angle);
							playerY+=5.0f*gc.Sin(player_angle);
						}
						keep_angle=player_angle;
					}
					else if(stage0[itemp1,itemp2]==4){
						playerX+=5.0f*gc.Cos(keep_angle);
						playerY+=5.0f*gc.Sin(keep_angle);
					}
				}
				else if(stage0[itemp1,itemp2]==4){
					playerX+=5.0f*gc.Cos(keep_angle);
					playerY+=5.0f*gc.Sin(keep_angle);
				}
				if(gc.CheckHitCircle(cursolX,cursolY,60,gc.GetPointerX(0),gc.GetPointerY(0),0)){
					for(int i=0;i<=shield;i++){
						ftemp1=playerX+30*gc.Cos(player_angle+6.0f*i-(shield-1)*3.0f);
						ftemp2=playerY+30*gc.Sin(player_angle+6.0f*i-(shield-1)*3.0f);
						ftemp3=speed/10*gc.Cos(player_angle+6.0f*i-(shield-1)*3.0f);
						ftemp4=speed/10*gc.Sin(player_angle+6.0f*i-(shield-1)*3.0f);
						shoot(ftemp1,ftemp2,ftemp3,ftemp4,1);
					}
				}
			}
			else if(stage0[itemp1,itemp2]==4){
				playerX+=5.0f*gc.Cos(keep_angle);
				playerY+=5.0f*gc.Sin(keep_angle);
			}
			for(int i=0;i<itemnum;i++){//アイテムの処理
				if(itemkind[i]<=0){continue;}
				if(gc.CheckHitCircle((int)playerX,(int)playerY,24,(int)itemX[i],(int)itemY[i],12)){
					if(itemkind[i]==1&&fire<20){fire++;}
					if(itemkind[i]==2&&time<20){time++;}
					if(itemkind[i]==3&&shield<20){shield++;}
					if(itemkind[i]==4){speed++;}
					if(itemkind[i]==5){
						if(HP<20){HP++;}
						hp+=360;
						if(hp>HP*360){hp=HP*360;}
					}
					if(itemkind[i]==6){key++;}
					itemkind[i]=0;
				}
			}
			for(int i=0;i<enenum;i++){//敵の処理
				if(enekind[i]<=0){continue;}
				if(enekind[i]==10&&gc.CheckHitRect((int)eneX[i]-160,(int)eneY[i]-160,320,320,(int)playerX-18,(int)playerY-18,36,36)){
					if(jikistate<=0&&enestate[i]<=0){
						hp-=360;
						jikistate=60;
					}
					ftemp1=getangle(eneX[i],eneY[i],playerX,playerY);
					if(ftemp1>=45&&ftemp1<=135){playerY=eneY[i]+180;}
					else if(ftemp1>=-45&&ftemp1<=45){playerX=eneX[i]+180;}
					else if(ftemp1>=-135&&ftemp1<=-45){playerY=eneY[i]-180;}
					else{playerX=eneX[i]-180;}
				}
				else if(enekind[i]==11&&gc.CheckHitRect((int)eneX[i]-80,(int)eneY[i]-80,160,160,(int)playerX-18,(int)playerY-18,36,36)){
					if(jikistate<=0&&enestate[i]<=0){
						hp-=360;
						jikistate=60;
					}
					ftemp1=getangle(eneX[i],eneY[i],playerX,playerY);
					if(ftemp1>=45&&ftemp1<=135){playerY=eneY[i]+100;}
					else if(ftemp1>=-45&&ftemp1<=45){playerX=eneX[i]+100;}
					else if(ftemp1>=-135&&ftemp1<=-45){playerY=eneY[i]-100;}
					else{playerX=eneX[i]-100;}
				}
				else if(enekind[i]==12&&gc.CheckHitRect((int)eneX[i]-40,(int)eneY[i]-40,80,80,(int)playerX-18,(int)playerY-18,36,36)){
					if(jikistate<=0&&enestate[i]<=0){
						hp-=360;
						jikistate=60;
					}
					ftemp1=getangle(eneX[i],eneY[i],playerX,playerY);
					if(ftemp1>=45&&ftemp1<=135){playerY=eneY[i]+60;}
					else if(ftemp1>=-45&&ftemp1<=45){playerX=eneX[i]+60;}
					else if(ftemp1>=-135&&ftemp1<=-45){playerY=eneY[i]-60;}
					else{playerX=eneX[i]-60;}
				}
				else if(gc.CheckHitCircle((int)playerX,(int)playerY,24,(int)eneX[i],(int)eneY[i],24)){
					if(jikistate<=0&&enestate[i]<=0&&(enekind[i]<4||enekind[i]>6)){
						hp-=360;
						jikistate=60;
					}
					ftemp1=getangle(eneX[i],eneY[i],playerX,playerY);
					playerX=eneX[i]+48*gc.Cos(ftemp1);
					playerY=eneY[i]+48*gc.Sin(ftemp1);
				}
				if(enekind[i]>=4&&enekind[i]<=6&&enestate[i]<0){enestate[i]++;}
				if(enekind[i]>=7&&enekind[i]<=9){
					if(enesub[i]<0||enesub[i]>=enenum||enekind[enesub[i]]<=0){
						enesub[i]=-1;
						eneX[i]+=7*gc.Cos(eneangle[i]);
						eneY[i]+=7*gc.Sin(eneangle[i]);
					}
					else{
						eneangle[i]=getangle(eneX[i],eneY[i],eneX[enesub[i]],eneY[enesub[i]]);
						if(!gc.CheckHitCircle((int)eneX[i],(int)eneY[i],24,(int)eneX[enesub[i]],(int)eneY[enesub[i]],24)){
							eneX[i]=eneX[enesub[i]]+48*gc.Cos(eneangle[i]+180);
							eneY[i]=eneY[enesub[i]]+48*gc.Sin(eneangle[i]+180);
						}
					}
				}
				if(enekind[i]==10){
					if(enestate[i]>-30){
						enestate[i]--;
						eneX[i]+=5*gc.Cos(eneangle[i]);
						eneY[i]+=5*gc.Sin(eneangle[i]);
					}
					if(enestate[i]<-31){
						enestate[i]++;
						if(enestate[i]%2==0){
							bullet(eneX[i]-160+320*gc.Random(),eneY[i]-160+320*gc.Random(),eneangle[i],8,4);
						}
					}
					if(enestate[i]==-30){
						enestate[i]=-64;
						ftemp1=4*gc.Random();
						eneangle[i]=(int)ftemp1*90;
					}
					if(enestate[i]==-31){
						enestate[i]=0;
						ftemp1=4*gc.Random();
						eneangle[i]=(int)ftemp1*90;
					}
				}
				if(enekind[i]==11){
					if(enestate[i]>-30){
						enestate[i]--;
						eneX[i]+=5*gc.Cos(eneangle[i]);
						eneY[i]+=5*gc.Sin(eneangle[i]);
					}
					if(enestate[i]<-31){
						enestate[i]++;
						if(enestate[i]%8==0){
							bullet(eneX[i]-80+160*gc.Random(),eneY[i]-80+160*gc.Random(),eneangle[i],8,4);
						}
					}
					if(enestate[i]==-30){
						enestate[i]=-64;
						ftemp1=4*gc.Random();
						eneangle[i]=(int)ftemp1*90;
					}
					if(enestate[i]==-31){
						enestate[i]=0;
						ftemp1=4*gc.Random();
						eneangle[i]=(int)ftemp1*90;
					}
				}
				if(enekind[i]==12){
					if(enestate[i]>-30){
						enestate[i]--;
						eneX[i]+=5*gc.Cos(eneangle[i]);
						eneY[i]+=5*gc.Sin(eneangle[i]);
					}
					if(enestate[i]<-31){
						enestate[i]++;
						if(enestate[i]%32==0){
							bullet(eneX[i]-40+80*gc.Random(),eneY[i]-40+80*gc.Random(),eneangle[i],8,4);
						}
					}
					if(enestate[i]==-30){
						enestate[i]=-64;
						ftemp1=4*gc.Random();
						eneangle[i]=(int)ftemp1*90;
					}
					if(enestate[i]==-31){
						enestate[i]=0;
						ftemp1=4*gc.Random();
						eneangle[i]=(int)ftemp1*90;
					}
				}
				if(enestate[i]>0&&enekind[i]<10){enestate[i]--;}
				else{
					if((enekind[i]==1||enekind[i]==4)&&enestate[i]<0){}
					else if(enekind[i]>=7){}
					else{eneangle[i]=getangle(eneX[i],eneY[i],playerX,playerY);}
					if(gc.CheckHitCircle((int)playerX,(int)playerY,0,(int)eneX[i],(int)eneY[i],300)&&enestate[i]<=0){
						if(enekind[i]==1){
							enestate[i]=-1;
							eneX[i]+=5*gc.Cos(eneangle[i]);
							eneY[i]+=5*gc.Sin(eneangle[i]);
						}
						if(enekind[i]==2){
							eneX[i]+=gc.Cos(eneangle[i]);
							eneY[i]+=gc.Sin(eneangle[i]);
						}
						if(enekind[i]==4){
							if(enestate[i]==0){enestate[i]=-1;}
							eneX[i]+=3*gc.Cos(eneangle[i]);
							eneY[i]+=3*gc.Sin(eneangle[i]);
							if(enestate[i]==-1){
								bullet(eneX[i],eneY[i],eneangle[i]+90,3,1);
								bullet(eneX[i],eneY[i],eneangle[i]-90,3,1);
								enestate[i]=-31;
							}
						}
						if(enekind[i]==5){
							eneX[i]+=3*gc.Cos(eneangle[i]);
							eneY[i]+=3*gc.Sin(eneangle[i]);
							if(enestate[i]==0){
								bullet(eneX[i],eneY[i],eneangle[i]+150f+60f*gc.Random(),1,2);
								enestate[i]=-15;
							}
						}
						if(enekind[i]==6&&enestate[i]==0){
							for(int j=0;j<4;j++){
								bullet(eneX[i],eneY[i],j*90,2,3);
							}
							enestate[i]=-60;
						}
					}
					else if(enekind[i]==1||enekind[i]==4){enestate[i]=0;}
					ftemp1=480*gc.Random();
					if(enekind[i]==7&&ftemp1<1){
						bullet(eneX[i],eneY[i],getangle(eneX[i],eneY[i],playerX,playerY),1,1);
						bullet(eneX[i],eneY[i],getangle(eneX[i],eneY[i],playerX,playerY)+180,1,1);
					}
					if(enekind[i]==8&&ftemp1<4){
						bullet(eneX[i],eneY[i],360*gc.Random(),5,2);
					}
					if(enekind[i]==9&&ftemp1<1){
						for(int j=0;j<4;j++){
							bullet(eneX[i],eneY[i],45+j*90,3,3);
						}
					}
				}
				itemp1=(int)eneX[i]/80;
				itemp2=(int)eneY[i]/80;
				if(enekind[i]==10){
					for(int j=itemp1-2;j<=itemp1+2;j++){//ブロックにのめりこまない処理
						for(int k=itemp2-2;k<=itemp2+2;k++){
							if(j<0||j>=dungeonX||k<0||k>=dungeonY||stage0[j,k]==0||stage0[j,k]==7){
								if(gc.CheckHitCircle((int)eneX[i],(int)eneY[i],180,j*80+40,k*80+40,40)){
									ftemp1=getangle(j*80+40,k*80+40,eneX[i],eneY[i]);
									eneX[i]=j*80+40+222*gc.Cos(ftemp1);
									eneY[i]=k*80+40+222*gc.Sin(ftemp1);
									enestate[i]=29;
									ftemp2=getangle(eneX[j],eneY[j],playerX,playerY);
									for(int l=0;l<16;l++){
										bullet(eneX[i]+144*gc.Cos(ftemp2+l*22.5f),eneY[i]+144*gc.Sin(ftemp2+l*22.5f),ftemp2+l*22.5f,1,4);
									}
									ftemp1=4*gc.Random();
									eneangle[i]=(int)ftemp1*90;
								}
							}
						}
					}
				}
				else if(enekind[i]==11){
					for(int j=itemp1-1;j<=itemp1+1;j++){//ブロックにのめりこまない処理
						for(int k=itemp2-1;k<=itemp2+1;k++){
							if(j<0||j>=dungeonX||k<0||k>=dungeonY||stage0[j,k]==0||stage0[j,k]==7){
								if(gc.CheckHitCircle((int)eneX[i],(int)eneY[i],90,j*80+40,k*80+40,40)){
									ftemp1=getangle(j*80+40,k*80+40,eneX[i],eneY[i]);
									eneX[i]=j*80+40+132*gc.Cos(ftemp1);
									eneY[i]=k*80+40+132*gc.Sin(ftemp1);
									enestate[i]=29;
									ftemp2=getangle(eneX[j],eneY[j],playerX,playerY);
									for(int l=0;l<4;l++){
										bullet(eneX[i]+64*gc.Cos(ftemp2+l*90),eneY[i]+64*gc.Sin(ftemp2+l*90),ftemp2+l*90,1,4);
									}
									ftemp1=4*gc.Random();
									eneangle[i]=(int)ftemp1*90;
								}
							}
						}
					}
				}
				else if(enekind[i]==12){
					for(int j=itemp1-1;j<=itemp1+1;j++){//ブロックにのめりこまない処理
						for(int k=itemp2-1;k<=itemp2+1;k++){
							if(j<0||j>=dungeonX||k<0||k>=dungeonY||stage0[j,k]==0||stage0[j,k]==7){
								if(gc.CheckHitCircle((int)eneX[i],(int)eneY[i],45,j*80+40,k*80+40,40)){
									ftemp1=getangle(j*80+40,k*80+40,eneX[i],eneY[i]);
									eneX[i]=j*80+40+87*gc.Cos(ftemp1);
									eneY[i]=k*80+40+87*gc.Sin(ftemp1);
									enestate[i]=29;
									ftemp2=getangle(eneX[j],eneY[j],playerX,playerY);
									bullet(eneX[i]+24*gc.Cos(ftemp2),eneY[i]+24*gc.Sin(ftemp2),ftemp2,1,4);
									ftemp1=4*gc.Random();
									eneangle[i]=(int)ftemp1*90;
								}
							}
						}
					}
				}
				else{
					for(int j=itemp1-1;j<=itemp1+1;j++){//ブロックにのめりこまない処理
						for(int k=itemp2-1;k<=itemp2+1;k++){
							if(j<0||j>=dungeonX||k<0||k>=dungeonY||stage0[j,k]==0||stage0[j,k]==7){
								if(gc.CheckHitCircle((int)eneX[i],(int)eneY[i],24,j*80+40,k*80+40,40)){
									ftemp1=getangle(j*80+40,k*80+40,eneX[i],eneY[i]);
									eneX[i]=j*80+40+66*gc.Cos(ftemp1);
									eneY[i]=k*80+40+66*gc.Sin(ftemp1);
									enestate[i]=29;
									if(enekind[i]>=7&&enekind[i]<=9){eneangle[i]=360*gc.Random();}
								}
							}
						}
					}
				}
			}
			itemp1=(int)playerX/80;
			itemp2=(int)playerY/80;
			for(int i=itemp1-1;i<=itemp1+1;i++){//ブロックにのめりこまない処理
				for(int j=itemp2-1;j<=itemp2+1;j++){
					if(i<0||i>=dungeonX||j<0||j>=dungeonY||stage0[i,j]==0||stage0[i,j]==7){
						if(gc.CheckHitCircle((int)playerX,(int)playerY,24,i*80+40,j*80+40,40)){
							ftemp1=getangle(i*80+40,j*80+40,playerX,playerY);
							playerX=i*80+40+64*gc.Cos(ftemp1);
							playerY=j*80+40+64*gc.Sin(ftemp1);
							if(i>=0&&i<dungeonX&&j>=0&&j<dungeonY&&key>0&&stage0[i,j]==7){
								key--;
								stage0[i,j]=1;
							}
						}
					}
				}
			}
			itemp1=(int)playerX/80;
			itemp2=(int)playerY/80;
			if(stage0[itemp1,itemp2]==6){
				itemp1=0;
				gameState=2;
			}
			if(stage0[itemp1,itemp2]==2){
				hp--;
			}
			if(stage0[itemp1,itemp2]==5&&hp<HP*360){
				hp=HP*360;
				stage0[itemp1,itemp2]=1;
			}
			if(jikistate>0){jikistate--;}
			if(hp<=0){
				itemp1=0;
				gameState=3;
			}
		}
	}

	/// <summary>
	/// 描画の処理
	/// </summary>
	public override void DrawGame(){
		// 画面を白で塗りつぶします
		gc.ClearScreen();
		gc.SetColor(255,191,127);
		gc.FillRect(0,0,720,1280);
		// 黒の文字を描画します
		if(gameState==0){
			gc.SetColor(0,0,0);
			gc.SetFontSize(60);
			gc.DrawString("下南霧と魔法遺跡",120,320);
			gc.DrawString("Tap to start",180,800);
		}
		else if(gameState==1){
			itemp1=(360-(int)playerX)/80;
			itemp2=(640-(int)playerY)/80;
			for(int i=-1-itemp1;i<=9-itemp1;i++){//マップチップの描画
				for(int j=-1-itemp2;j<=16-itemp2;j++){
					if(i<0||i>=dungeonX||j<0||j>=dungeonY){gc.DrawImage(0,(360-(int)playerX)+i*80,(640-(int)playerY)+j*80);}
					else{gc.DrawImage(stage0[i,j],(360-(int)playerX)+i*80,(640-(int)playerY)+j*80);}
				}
			}
			for(int i=0;i<itemnum;i++){//アイテムの描画
				if(itemkind[i]>0){
					gc.DrawImage(itemkind[i]+19,(360-(int)playerX)+(int)itemX[i]-12,(640-(int)playerY)+(int)itemY[i]-12);
				}
			}
			for(int i=0;i<enenum;i++){//敵の描画
				if(enekind[i]<=0||enestate[i]%4>=2){continue;}
				if(enekind[i]==10){
					gc.DrawScaledRotateImage(enekind[i]+7,(360-(int)playerX)+(int)eneX[i],
					(640-(int)playerY)+(int)eneY[i],100,100,eneangle[i],160,160);
				}
				else if(enekind[i]==11){
					gc.DrawScaledRotateImage(enekind[i]+7,(360-(int)playerX)+(int)eneX[i],
					(640-(int)playerY)+(int)eneY[i],100,100,eneangle[i],80,80);
				}
				else if(enekind[i]==12){
					gc.DrawScaledRotateImage(enekind[i]+7,(360-(int)playerX)+(int)eneX[i],
					(640-(int)playerY)+(int)eneY[i],100,100,eneangle[i],40,40);
				}
				else{
					gc.DrawScaledRotateImage(enekind[i]+7,(360-(int)playerX)+(int)eneX[i],
					(640-(int)playerY)+(int)eneY[i],100,100,eneangle[i],24,24);
				}
			}
			for(int i=0;i<shotnum;i++){//ショットの描画
				if(shotstate[i]>0){
					if(shotkind[i]==0){gc.SetColor(0,0,255);}
					if(shotkind[i]==1){gc.SetColor(255,0,0);}
					gc.FillCircle((int)shotX[i]+360-(int)playerX,(int)shotY[i]+640-(int)playerY,6);
				}
			}
			if(jikistate%4<2){
				gc.DrawScaledRotateImage(26,360,640,100,100,player_angle,24,24);//自機の描画
			}
			for(int i=0;i<bulnum;i++){//弾の描画
				if(bulkind[i]>0){
					gc.DrawScaledRotateImage(bulkind[i]+29,(360-(int)playerX)+(int)bulX[i],
					(640-(int)playerY)+(int)bulY[i],100,100,bulangle[i],12,12);
				}
			}
			if(gc.GetPointerFrameCount(0)>0){//カーソルの描画
				gc.DrawImage(27,cursolX-60,cursolY-60);
				for(int i=-1;i<=1;i++){
					for(int j=-1;j<=1;j++){
						gc.SetColor(0,0,0);
						gc.DrawLine(cursolX+i,cursolY+j,gc.GetPointerX(0)+i,gc.GetPointerY(0)+j);
					}
				}
			}
			for(int i=0;i<HP;i++){
				gc.DrawImage(28,2+i*36,2);//最大HPの描画
			}
			for(int i=0;i<(hp/360);i++){
				gc.DrawImage(29,3+i*36,3);//HPの描画
			}
			gc.DrawClipImage(29,3+(hp/360)*36,3,0,0,(hp%360)/12,30);//HPの描画
/*			gc.SetColor(0,0,0);
			gc.SetFontSize(36);
			gc.DrawString($"{enenow}",0,36);
			gc.DrawString($"{eneangle[enenow]}",0,72);
			gc.DrawString($"{enestate[enenow]}",0,108);
			gc.DrawString($"{enekind[enenow]}",0,144);
			gc.DrawString($"{eneX[enenow]}",0,180);
			gc.DrawString($"{eneY[enenow]}",0,216);
			gc.DrawString($"{eneHP[enenow]}",0,252);*/
		}
		else if(gameState==2){
			gc.SetColor(0,0,0);
			gc.SetFontSize(60);
			gc.DrawString("GAME CLEAR",210,800);
			gc.DrawString("長押しでホームに戻る",60,960);
		}
		else if(gameState==3){
			gc.SetColor(0,0,0);
			gc.SetFontSize(60);
			gc.DrawString("GAME OVER",225,800);
			gc.DrawString("長押しでホームに戻る",60,960);
		}
	}
	float getangle(float x1,float y1,float x2,float y2){
		if(x2-x1==0&&y2-y1==0){return 90;}
		float fsub1=gc.Atan2(y2-y1,x2-x1)*180/pi;
		return fsub1;
	}
	float shoot(float x,float y,float x2,float y2,int s){
		for(int i=shotnow;i<shotnum;i++){
			if(shotstate[i]<=0){
				shotnow=i;
				break;
			}
			if(i==shotnum-1){return 1;}
		}
		shotX[shotnow]=x;
		shotY[shotnow]=y;
		shotX2[shotnow]=x2;
		shotY2[shotnow]=y2;
		shotstate[shotnow]=s;
		shotkind[shotnow]=0;
		return 0;
	}
	float bullet(float x,float y,float angle,float speed,int k){
		for(int i=bulnow;i<bulnum;i++){
			if(bulkind[i]<=0){
				bulnow=i;
				break;
			}
			if(i==bulnum-1){return 1;}
		}
		bulX[bulnow]=x;
		bulY[bulnow]=y;
		bulangle[bulnow]=angle;
		bulspeed[bulnow]=speed;
		bulkind[bulnow]=k;
		return 0;
	}
	float item(float x,float y,int k){
		for(int i=itemnow;i<itemnum;i++){
			if(itemkind[i]<=0){
				itemnow=i;
				break;
			}
			if(i==itemnum-1){return 1;}
		}
		itemX[itemnow]=x;
		itemY[itemnow]=y;
		itemkind[itemnow]=k;
		return 0;
	}
	float enemy(float x,float y,int hp,int k){
		for(int i=enenow;i<enenum;i++){
			if(enekind[i]<=0){
				enenow=i;
				break;
			}
			if(i==enenum-1){return 1;}
		}
		eneX[enenow]=x;
		eneY[enenow]=y;
		eneHP[enenow]=hp;
		enekind[enenow]=k;
		return 0;
	}
}
