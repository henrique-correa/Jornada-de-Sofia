using System;
using System.IO;


	public class RBS_main {

		private bool bingo = false;
		//string act;

		public string consult_RBS_f1 (string name, string fact1) 
		{
			StreamReader r;
			string act = "empty";
			if(File.Exists(name)){
				string line;
				r = File.OpenText(name);
				line = r.ReadLine();
				string[] l;
				while(bingo != true || r.EndOfStream == true){
					line = r.ReadLine();
					l = line.Split(' ');
					if(l[0] == fact1){
						act = l[1];
						bingo = true;
					}
				}
				r.Close ();
			}
			else{act = "error_RBS_file_not_exist";}

			return act;
		}

		/************************************************************************************************************/

		public string consult_RBS_f2 (string name, string fact1, string fact2)
		{
			StreamReader r;
			string act = "empty";
			if(File.Exists(name)){
				string line;
				r = File.OpenText(name);
				line = r.ReadLine();
				string[] l;
				while(bingo != true || r.EndOfStream == true){
					line = r.ReadLine();
					l = line.Split(' ');
					if(l[0] == fact1){
						if(l[1] == fact2){
							act = l[2];
							bingo = true;
						}
					}
					
				}
				r.Close ();
			}
			else{act = "error_RBS_file_not_exist";}

			return act;
		}

		/************************************************************************************************************/

		public string consult_RBS_f3 (string name, string fact1, string fact2, string fact3)
		{
			StreamReader r;
			string act = "empty";
			if(File.Exists(name)){
				string line;
				r = File.OpenText(name);
				line = r.ReadLine();
				string[] l;
				while(bingo != true || r.EndOfStream == true){
					line = r.ReadLine();
					l = line.Split(' ');
					if(l[0] == fact1){
						if(l[1] == fact2){
							if(l[2] == fact3){
								act = l[3];
								bingo = true;
							}
						}
					}

				}
				r.Close ();
			}
			else{act = "error_RBS_file_not_exist";}

			return act;
		}

		/************************************************************************************************************/

		public string consult_RBS_f4 (string name, string fact1, string fact2, string fact3, string fact4)
		{
			StreamReader r;
			string act = "empty";
			if(File.Exists(name)){
				string line;
				r = File.OpenText(name);
				line = r.ReadLine();
				string[] l;
				while(bingo != true || r.EndOfStream == true){
					line = r.ReadLine();
					l = line.Split(' ');
					if(l[0] == fact1){
						if(l[1] == fact2){
							if(l[2] == fact3){
								if(l[3] == fact4){
									act = l[4];
									bingo = true;
								}
							}
						}
					}
					
				}
				r.Close ();
			}
			else{act = "error_RBS_file_not_exist";}

			return act;
		}

		/************************************************************************************************************/

		public string consult_RBS_f5 (string name, string fact1, string fact2, string fact3, string fact4, string fact5)
		{
			StreamReader r;
			string act = "empty";
			if(File.Exists(name)){
				string line;
				r = File.OpenText(name);
				line = r.ReadLine();
				string[] l;
				while(bingo != true || r.EndOfStream == true){
					line = r.ReadLine();
					l = line.Split(' ');
					if(l[0] == fact1){
						if(l[1] == fact2){
							if(l[2] == fact3){
								if(l[3] == fact4){
									if(l[4] == fact5){
										act = l[5];
										bingo = true;
									}
								}
							}
						}
					}
					
				}
				r.Close ();
			}
			else{act = "error_RBS_file_not_exist";}

			return act;
		}

		/************************************************************************************************************/

		public string consult_RBS_f6 (string name, string fact1, string fact2, string fact3, string fact4, string fact5, string fact6)
		{
			StreamReader r;
			string act = "empty";
			if(File.Exists(name)){
				string line;
				r = File.OpenText(name);
				line = r.ReadLine();
				string[] l;
				while(bingo != true || r.EndOfStream == true){
					line = r.ReadLine();
					l = line.Split(' ');
					if(l[0] == fact1){
						if(l[1] == fact2){
							if(l[2] == fact3){
								if(l[3] == fact4){
									if(l[4] == fact5){
										if(l[5] == fact6){
											act = l[6];
											bingo = true;
										}
									}
								}
							}
						}
					}
					
				}
				r.Close ();
			}
			else{act = "error_RBS_file_not_exist";}

			return act;
		}
	}

	

