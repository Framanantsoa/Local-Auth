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
    * Démarrez postgresql
    * Créez votre base de données et importez le dba.dump :
        * **pg_restore -U USER -d DATABASE -v CHEMIN/dba.dump**
    * Accedez dans backend et lancez les commandes : 
        * **dotnet clean**
        * **dotnet run**
    * Utilisez l'API Rest
* **Avec Docker :**
    * (Facu.)Installez les images docker : postgres14, dotnet-sdk-8
    * Lancez le commande : 
        * **docker-compose up --build**
    * Utilisez l'API Rest
