using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using Windows.Media.Protection.PlayReady;
using TP4_FilmRatingsApp.Models;

namespace TP4_FilmRatingsApp.Services
{
    public class WSService : IService
    {
        HttpClient client;

        public WSService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5199/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Utilisateur>> GetUtilisateursAsync(string nomControleur)
        {
            try
            {
                return await client.GetFromJsonAsync<List<Utilisateur>>(nomControleur);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Utilisateur> GetUtilisateurByIdAsync(string nomControleur, int id)
        {
            try
            {
                return await client.GetFromJsonAsync<Utilisateur>(string.Concat(nomControleur, "/GetUtilisateurById/", id));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Utilisateur> GetUtilisateurByEmailAsync(string nomControleur, string email)
        {
            try
            {
                return await client.GetFromJsonAsync<Utilisateur>(string.Concat(nomControleur, "/GetUtilisateurByEmail/", email));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> PostUtilisateurAsync(string nomControleur, Utilisateur utilisateur)
        {
            try
            {
                var reponse = await client.PostAsJsonAsync<Utilisateur>(nomControleur, utilisateur);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> PutUtilisateurAsync(string nomControleur, Utilisateur utilisateur)
        {
            try
            {
                var reponse = await client.PutAsJsonAsync<Utilisateur>(String.Concat(nomControleur, "/", utilisateur.UtilisateurId), utilisateur);
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteUtilisateurAsync(string nomControleur, int id)
        {
            try
            {
                HttpResponseMessage reponse = await client.DeleteAsync(String.Concat(nomControleur, "/", id));
                return reponse.IsSuccessStatusCode;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
