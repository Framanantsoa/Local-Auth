# LOC-AUTHS

## Description : Système d'authentification <br>

## Fonctionnalités :
* **Inscription :**
    * Créer un nouveau compte utilisateur.

* **Connexion :**
    * Authentifier un utilisateur.

* **Vérification du token :**
    * Sécuriser les routes.

* **Déconnexion :**
    * Invalider la session.

* **Renouvellement du token :**
    * Éviter que l'utilisateur soit déconnecté trop souvent.

* **Récupération / modification de profil :**
    * Consulter et modifier les informations.

* **Réinitialisation du mot de passe :**
    * Permettre d'obtenir un nouveau mot de passe.

## Technologies :
* **Backend :** .NET Core 8
* **Base de données :** Postgresql 14

## Étapes de lancement :
* **En Local :**
    * Démarrer postgresql
    * Entrer les scripts sql dans "bdd" : de 1 à 4
    * Acceder dans backend et lancer les commandes : 
        * **dotnet restore**
        * **dotnet clean**
        * **dotnet run**
    * Utiliser l'API Rest
* **Avec Docker :**
    * (Facu.)Installer les images docker : postgres14, dotnet-sdk-8
    * Lancer le commande : 
        * **docker-compose up --build**
    * Utiliser l'API Rest
