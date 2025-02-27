using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP4_FilmRatingsApp.Models;
using TP4_FilmRatingsApp.Services;

namespace TP4_FilmRatingsApp.ViewModels
{
    public class VisualiserUtilisateurViewModel : ObservableObject
    {
        private WSService service;

        public IRelayCommand BtnSearchUtilisateurCommand { get; }
        public IRelayCommand BtnModifyUtilisateurCommand { get; }
        public IRelayCommand BtnClearUtilisateurCommand { get; }
        public IRelayCommand BtnAddUtilisateurCommand { get; }

        private Utilisateur utilisateurSearch;

        private string searchMail;

        public Utilisateur UtilisateurSearch
        {
            get
            {
                return this.utilisateurSearch;
            }

            set
            {
                this.utilisateurSearch=value;
                OnPropertyChanged();
            }
        }

        public string SearchMail
        {
            get
            {
                return this.searchMail;
            }

            set
            {
                this.searchMail=value;
                OnPropertyChanged();
            }
        }

        public VisualiserUtilisateurViewModel()
        {
            this.service = new WSService();

            this.UtilisateurSearch = new Utilisateur();

            BtnSearchUtilisateurCommand = new RelayCommand(ActionSearchUtilisateur);
            BtnModifyUtilisateurCommand = new RelayCommand(ActionModifyUtilisateur);
            BtnClearUtilisateurCommand = new RelayCommand(ActionClearUtilisateur);
            BtnAddUtilisateurCommand = new RelayCommand(ActionAddUtilisateur);

            GetDataOnLoadAsync();
        }

        public async void GetDataOnLoadAsync()
        {
            List<Utilisateur> result = await service.GetUtilisateursAsync("Utilisateurs");

            if (result == null)
                MessageAsync("API non disponible !", "Erreur");
        }

        public async void ActionSearchUtilisateur()
        {
            Utilisateur reponse = await service.GetUtilisateurByEmailAsync("Utilisateurs", SearchMail);

            if (reponse == null)
            {
                MessageAsync("Aucun utilisateur trouvé", "Erreur");
            }
            else
            {
                UtilisateurSearch = reponse;
            }
        }

        public async void ActionModifyUtilisateur()
        {
            if (SearchMail == null)
            {
                MessageAsync("Aucun utilisateur sélectionné", "Erreur");
            }
            else
            {
                bool result = VerifieProprieteNulle();

                if (!result)
                {
                    bool reponse = await service.PutUtilisateurAsync("Utilisateurs", this.UtilisateurSearch);

                    if (reponse)
                        MessageAsync("Utilisateur modifié avec succès", "Succès");
                    else
                        MessageAsync("Erreur lors de la modification", "Erreur");
                }
            }
            
        }

        public void ActionClearUtilisateur()
        {
            this.UtilisateurSearch = null;
            this.SearchMail = null;
        }

        public async void ActionAddUtilisateur()
        {
            bool result = VerifieProprieteNulle();

            if (!result)
            {
                bool reponse = await service.PostUtilisateurAsync("Utilisateurs", this.UtilisateurSearch);

                if (reponse)
                    MessageAsync("Utilisateur ajouté avec succès", "Succès");
                else
                    MessageAsync("Erreur lors de l'ajout", "Erreur");
            }
        }

        private async void MessageAsync(string message, string title)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = title,
                Content = message,
                CloseButtonText = "OK"
            };
            dialog.XamlRoot = App.MainRoot.XamlRoot;
            ContentDialogResult result = await dialog.ShowAsync();
        }

        private bool VerifieProprieteNulle()
        {
            if (UtilisateurSearch == null)
            {
                MessageAsync("Aucun utilisateur sélectionné", "Erreur");
                return true;
            }

            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Nom))
            {
                MessageAsync("Le nom est requis", "Erreur");
                return true;
            }

            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Prenom))
            {
                MessageAsync("Le prénom est requis", "Erreur");
                return true;
            }

            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Mobile))
            {
                MessageAsync("Le numéro de mobile est requis", "Erreur");
                return true;
            }

            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Mail))
            {
                MessageAsync("L'email est requis", "Erreur");
                return true;
            }

            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Pwd))
            {
                MessageAsync("Le mot de passe est requis", "Erreur");
                return true;
            }

            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Rue))
            {
                MessageAsync("La rue est requise", "Erreur");
                return true;
            }
            
            if (string.IsNullOrWhiteSpace(UtilisateurSearch.CodePostal))
            {
                MessageAsync("Le code postal est requis", "Erreur");
                return true;
            }
            
            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Ville))
            {
                MessageAsync("La ville est requise", "Erreur");
                return true;
            }
            
            if (string.IsNullOrWhiteSpace(UtilisateurSearch.Pays))
            {
                MessageAsync("Le pays est requis", "Erreur");
                return true;
            }

            return false;

        }

    }
}
