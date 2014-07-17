// Il s'agit du fichier DLL principal.

#include "stdafx.h"
#include <conio.h>
#include <iostream>
#include "IA.h"

namespace IA
{
	// constructor of one IA
	Ordi::Ordi(int diff, array<int,1>^ TabJeu){
		difficulte = diff;
		TabJeuActuel = gcnew array<int, 1>(9);
		TabJeuActuel = TabJeu;
		TabConverti = gcnew array<int,1>(3);
		SaveTabConverti = gcnew array<int,1>(3);
		TabMinMax = gcnew array<int,1>(3);
		for(int d=0; d<3;d++)
		{
			TabConverti[d]=0;
			TabMinMax[d]=0;			
		}
		tour = 0;
	}
	
	array<int,1>^ Ordi::Jouer() // function called for IA playing
	{
		if(difficulte == 0) // if the difficulty level is easy
		{ 
			ligne = 1+rand()%3; // choose one of the 3 lines by chance
			nbAllumettesRestantes = getAlRest(ligne); // get the remaining matches of this selected line
			if(nbAllumettesRestantes == 1){
				if(ligne == 1) // which line ?
					{	
							i=0;
							while(TabJeuActuel[i]!=0) // we seek for one free place in the array  
								i++;
							TabJeuActuel[i]=2; // we pull one match
		
					}
					else
						if(ligne == 2)
						{
							
								i=5;
								while(TabJeuActuel[i]!=0)
									i++;
								TabJeuActuel[i]=2;
							
						}
						else
							TabJeuActuel[8]=2;
				
			}
			else
				if(nbAllumettesRestantes == 2)
				{
					if(ligne == 1)
					{	
							i=0;
							while(TabJeuActuel[i]!=0)
								i++;
							TabJeuActuel[i]=2;
		
					}
					else
						if(ligne == 2)
						{
							
								i=5;
								while(TabJeuActuel[i]!=0)
									i++;
								TabJeuActuel[i]=2;
							
						}
				}
				else
				{
					if(nbAllumettesRestantes == 0){ // if there is no more matches in the selected line, we repeat the process
						Jouer();
					}
					else
					{ // there is 3 matches or more in the selected line
						b = 1 + rand()%3; // we generate a number of matches 				
						saveB = b; // we save it
						if(b>=nbAllumettesRestantes) // if the generated number of matches is higher than the remaining matches
							b=nbAllumettesRestantes;
						if(ligne == 1)
						{
							while(b>0)
							{
								i=0;
								while(TabJeuActuel[i]!=0)
									i++;
								TabJeuActuel[i]=2;
								b--;
							}
						}
						else{
							if(ligne == 2)
							{
								while(b>0)
								{
									i=6;
									while(TabJeuActuel[i]!=0)
										i++;
									TabJeuActuel[i]=2;
									b--;
								}
							}
							else{
								TabJeuActuel[8]=2;}
						}
					}		
				}
		}
		else
		{ // the difficulty level is hard
			// we create one array with the remaining matches for each line and we save it
			TabConverti[0]=getAlRest(1);
			TabConverti[1]=getAlRest(2);
			TabConverti[2]=getAlRest(3);
				SaveTabConverti[0] = getAlRest(1);			
				SaveTabConverti[1] = getAlRest(2);
				SaveTabConverti[2] = getAlRest(3);
				// we use the min max algorithm
				TabMinMax = minMax(TabConverti, 8);	
			
				// if there is removed matches
					if(SaveTabConverti[0]!=TabMinMax[0])
					{
						if(getAlRest(1) == 2 && getAlRest(2) == 0 && getAlRest(3) == 0) 
							k=1; // k is the number of the matches that will be removed
						else
							k = SaveTabConverti[0]-TabMinMax[0];
						for(int g=0;g<5;g++){ // we seek for free place to remove matches in the game array
							if(k>0 && TabJeuActuel[g]==0){
								TabJeuActuel[g]=2;
								k--;
							}
						}
					}
					else
					{
						if(SaveTabConverti[1]!=TabMinMax[1])
						{
							if(getAlRest(1) == 0 && getAlRest(2) == 2 && getAlRest(3) == 0)
								k=1;
							else
								k = SaveTabConverti[1]-TabMinMax[1];
							for(int g=5;g<8;g++){
								if(k>0 && TabJeuActuel[g]==0){
									TabJeuActuel[g]=2;
									k--;
								}
							}
						}
						else
						{
							if(SaveTabConverti[2]!=TabMinMax[2])
							{
								k = SaveTabConverti[2]-TabMinMax[2];								
								if(k>0 && TabJeuActuel[8]==0)
										TabJeuActuel[8]=2;
								
							}
						}
					}



		}
		

		return TabJeuActuel;
	}

	array<int,1>^ Ordi::minMax(array<int,1>^ jeu,int p)
	{
		int max = -10000;
		int tmp, maxi, maxj, i, j;
		int nbATester, nbAlRest;
		for(i=0;i<3;i++) // for each line
		{
			nbAlRest = getAlRest(i+1); //get the remaining matches on this line
			if(nbAlRest<3)
				nbATester = nbAlRest;
			else
				nbATester = 3;
			j=nbATester; // how many matches is possible to remove ?
			for(;j>0;j--) // for each match that is possible to remove
			{
				if(jeu[i]>=j) // test if there is enough matches to remove on the line
				{
					jeu[i]-=j; // now we test to remove the matches on the line ...
					tmp = min(jeu,p-1); // ... and get a value of this attempt by elaborating the game tree
					if(tmp>max) // if removing this matches is a good idea, we save it
					{
						max=tmp;
						maxi=i;
						maxj=j;
					}
					jeu[i]+=j; // we cancel after the test
				}
				else
				{
					j=-1;
				}

			}
		}

		jeu[maxi]-=maxj; // we remove the best number of matches on the best line
		return jeu;
	}
	int Ordi::min(array<int,1>^ jeu, int p) // the function min is used when it's the turn of the computer
	{
		if(p == 0 || gagnant(jeu)!=0) // is there is a winner or if we are in the end of the game tree
			return eval(jeu,-p); // get the final value of this attempt
		int min = 10000;
		int i, m , tmp;
		int nbATester, nbAlRest;
		for(i=0;i<3;i++)
		{
			nbAlRest = getAlRest(i+1);
			if(nbAlRest<3)
				nbATester = nbAlRest;
			else
				nbATester = 3;
			m=nbATester;
			for(;m>0;m--)
			{
				if(jeu[i]>=m)
				{
					jeu[i]-=m;
					tmp = max(jeu,p-1); // test with the player turn for each possible attempt that he can play
					if(tmp<min) 
					{
						min=tmp;
					}
					jeu[i]+=m;
				}
				else
				{
					m=-1;
				}

			}
		}
		return min;
	}
	int Ordi::max(array<int,1>^ jeu, int p) 
	{
		if(p == 0 || gagnant(jeu)!=0)
			return eval(jeu, p);
		int max = -10000;
		int i, h , tmp;
		int nbATester, nbAlRest;
		for(i=0;i<3;i++)
		{
			nbAlRest = getAlRest(i+1);
			if(nbAlRest<3)
				nbATester = nbAlRest;
			else
				nbATester = 3;
			h=nbATester;
			for(;h>0;h--)
			{
				if(jeu[i]>=h)
				{
					jeu[i]-=h;
					tmp = min(jeu,p-1);
					if(tmp>max)
					{
						max=tmp;
					}
					jeu[i]+=h;
				}
				else
				{
					h=-1;
				}

			}
		}
		return max;
	}

	int Ordi::gagnant(array<int,1>^ jeu) // function to check if there a winner or not
	{
		int r = 0;
		for(int i = 0 ; i<3; i++)
			r += jeu[i];
		if(r==1)
			return 1;
		else
			if(r==0)
				return 1;
			else
				return 0;
	}
	int Ordi::eval(array<int,1>^ jeu, int p) // function to get a value of the last node of the three
	{
		int r = 0;
		for(int i = 0 ; i<3; i++)
			r += jeu[i];
		if(r==1)
			return -100-p;
		else
			if(r==0)
				return +100+p;
			else			
				return 0;
	}
	int Ordi::getAlRest(int ligne) // function to get the remaining matches of one line
	{
		nbAllumettesRestantes = 0;
		
		if(ligne == 1){
			x=0;
			while(x<5){
				if(TabJeuActuel[x]==0){
					nbAllumettesRestantes++;
				}
				x++;
			}
		}
		else
			if(ligne == 2)
			{
				x=5;
					while(x<8){
						if(TabJeuActuel[x]==0){
							nbAllumettesRestantes++;
						}
					x++;
					}
			}
			else
			{
				if(ligne == 3){
					if(TabJeuActuel[8]==0)
						nbAllumettesRestantes = 1;
				}
				
			}

			return nbAllumettesRestantes;
	}

	int Ordi::getNbCoup()
	{
		return saveB;
	}



}