using System;
using System.Collections.Generic;
using JeuDeCarte.BO;
using JeuDeCarte.DAL;

namespace JeuDeCarte.BP
{
    public interface IJeuDeCarteService
    {
        UnJeuDeCarteBO CreateJeuDeCarte(String name, int nbCarte);
        UnJeuDeCarteBO GetJeuDeCarte(int id);
        List<ModeleCarteBO> GetSomeCards(int gameId, int NbCartes);
        List<ModeleCarteBO> ThrowSomeCards(int gameId, String throwcartes);
        List<ModeleCarteBO> FromDefausseToCards(int gameId, int nbCarte);
        List<ModeleCarteBO> GetAllCartes();
        UnJeuDeCarteBO ShuffleCartes(int gameId);

    }
}
