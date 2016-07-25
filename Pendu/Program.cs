using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Version
            Console.WriteLine("Jeu du pendu V1.0 22/07/2016\n\n");

            //Variables
            string mot;

            //Opérations
            mot = GetString("Joueur 1, entrez le mot à faire deviner : ");
            Pendu(mot);

            Console.ReadLine();
        }

        static string GetString(string phrase)
        {
            string entry;

            int test = 1;
            string check = "abcdefghijklmnopqrstuvwxyz";

            Console.Write(phrase);
            do
            {
                entry = Console.ReadLine();
                for (int i = 0; i < entry.Length; i++)
                {
                    test = 0;
                    if (check.IndexOf(entry.Substring(i, 1)) == -1)
                    {
                        test++;
                    }
                }
                if (test > 0)
                {
                    Console.WriteLine("Erreur de saisie, veuillez rééssayer.");
                }
            } while (test != 0);
            return entry;
        }

        static void Pendu(string mot)
        {
            //Variables
            string [] tbPendu = new string[mot.Length];
            string [] tbMot = new string[mot.Length];
            string [] tbEssai = new string[11];
            bool victoire = true, testLettre = true;
            int essai = 0;

            //Remplissage des tableaux Mot et Pendu
            for (int i = 0; i < mot.Length; i++)
            {
                tbPendu[i] = "_";
                tbMot[i] = mot.Substring(i, 1);
            }

            //Découverte du mot
            Console.Clear();
            Console.WriteLine("Joueur 2, essayez de deviner le mot du joueur 1 en entrant une lettre à chaque essai.\nVous avez 11 essais en tout.\n");
            
            do 
            {
                //Début de l'essai                
                Console.Write("Mot à deviner : ");
                Console.WriteLine();
                for (int j = 0; j < mot.Length; j++)
                {
                    Console.Write(tbPendu[j]);
                }
                Console.WriteLine("\n");
                tbEssai[essai] = GetString("Essai numéro " + (essai + 1) + " : ");
                do
                {
                    if (tbEssai[essai].Length != 1)
                    {
                        tbEssai[essai] = GetString("Erreur, entrez une seule lettre : ");
                    }
                } while (tbEssai[essai].Length != 1);




                //Test de la lettre entrée par rapport au tableau contenant le mot
                testLettre = false;
                for (int i = 0; i < mot.Length; i++)
                {
                    if (tbEssai[essai] == tbMot[i])
                    {
                        tbPendu[i] = tbMot[i];
                        testLettre = true;
                    }
                }
                if (testLettre == true)
                {
                    Console.WriteLine("Bravo, la lettre est présente dans le mot.");
                }
                else
                {
                    Console.WriteLine("Dommage, votre lettre n'est pas dans le mot.");
                }

                //Vérification des tableaux mot et pendu, ils doivent être identique pour que victoire reste en true
                victoire = true; 
                for (int i = 0; i < mot.Length; i++)
                {
                    if(tbPendu[i] != tbMot[i])
                    {
                        victoire = false;
                    }
                }

                //Condition de fin d'essai                
                if (victoire == true)
                {
                    Console.WriteLine("\nFélicitation, le mot était " + mot + ". Vous avez gagnez en " + (essai+1) + " essai(s).");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Nombre d'essai restant : " + (10 - essai) + "\n\n");
                }
                essai++;
            } while (victoire == false) ;
        }
    }
}
