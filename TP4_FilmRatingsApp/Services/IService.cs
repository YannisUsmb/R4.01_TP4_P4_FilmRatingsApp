using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4_FilmRatingsApp.Models;

namespace TP4_FilmRatingsApp.Services
{
    public interface IService
    {
        // Utilisateur
        Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur);
        Task<Utilisateur> GetUtilisateurByIdAsync(string nomControleur, int id);
        Task<Utilisateur> GetUtilisateurByEmailAsync(string nomControleur, string email);
        Task<bool> PostUtilisateurAsync(string nomControleur, Utilisateur utilisateur);
        Task<bool> PutUtilisateurAsync(string nomControleur, Utilisateur utilisateur);
        Task<bool> DeleteUtilisateurAsync(string nomControleur, int id);

    }
}
