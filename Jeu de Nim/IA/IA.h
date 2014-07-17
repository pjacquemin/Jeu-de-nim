// IA.h

#pragma once

using namespace System;

namespace IA {

	public ref class Ordi
	{
	private : 
		int difficulte;
		int k,b,i,x,nbAllumettesRestantes;
		int saveB,tour;
		int ligne;
		array<int,1>^ TabJeuActuel;
		array<int,1>^ TabConverti;
		array<int,1>^ SaveTabConverti;
		array<int,1>^ TabMinMax;
		
	public :
		Ordi(int diff, array<int,1>^ TabJeu);
		array<int,1>^ Jouer();
		array<int,1>^ minMax(array<int,1>^ jeu, int p);
		int min(array<int,1>^ jeu, int p);
		int max(array<int,1>^ jeu, int p);
		int eval(array<int,1>^ jeu, int p);
		int gagnant(array<int,1>^ jeu);
		int getNbCoup();
		int getAlRest(int ligne);

	};
}
