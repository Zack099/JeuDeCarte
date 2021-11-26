using JeuDeCarte.BO;
using JeuDeCarte.DAL;
using JeuDeCarte.DTO;
using System;

namespace JeuDeCarte
{
    public interface ICarteService
    {
        ModeleCarteDTO ModeleCarteToDTO(ModeleCarte carte);
        ModeleCarteBO ModeleCarteToBO(ModeleCarte carte);
        ModeleCarteDTO BOCarteToDTO(ModeleCarteBO carte);

    }
}
