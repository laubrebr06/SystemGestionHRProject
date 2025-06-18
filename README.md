# SystemGestionHR
Test Technique pour le Poste de Tech Lead .NET/C#/Angular

INSTRUCTIONS DE CONSTRUCTION ET D’EXÉCUTION

Projet : Gestion des demandes de congé

Auteur : Laura Brenes 

Date : 17 Juin 2025

# API Web de Gestion des Congés des Employés

Il s'agit d'un projet simple d'API Web en .NET Core permettant aux employés de gérer leur solde de congés et de soumettre des demandes de congé. Le projet est développé avec Entity Framework et PostgreSQL.

# Fonctionnalités
-	Soumettre une demande de congé 
-	Approuver ou rejeter une demande de congé

# Les tests couvrent :
- Création de demandes de conge valides ou invalides  
- Approbation ou rejet par un gestionnaire RH  
- Validation métier (dates, statuts, commentaires)

# Getting Started.
To get started with this project, follow these steps:

# Pré requis

- .NET Core 5.0
- PostgreSQL 13.
- .NET SDK 7.0 ou supérieur  
-	Visual Studio 2022 (ou VS Code avec .NET CLI)  
-	Navigateur web pour tester l’API (ou outil comme Postman)


# Installation 

1.	Clonez le dépôt sur votre machine locale :
   
git clone https://github.com/laubrebr06/SystemGestionHR.git

2.	Accédez au répertoire du projet
   
cd SystemGestionHR

3.	Restaurez les dépendances du projet
   
dotnet restore

4.	Mettez à jour le schéma de la base de données
   
dotnet ef database update

5.	Exécutez l'application
    
dotnet run

# Structure du projet

SystemGestionHRSolution/

├── Domain/                   → Repositories, Models, énumérations, objets de valeur

├── Application/              → Cas d’usage, DTOs, Services

├── Infrastructure/           → API Web (contrôleurs, dépendances)

├── Application.Tests/        → Tests unitaires (xUnit)

├── SystemGestionHR.sln   → Fichier de solution Compilation


# Utilisation

Les points de terminaison (endpoints) de l'API peuvent être testés avec un outil comme Postman. Les endpoints suivants sont disponibles :

 ![image](https://github.com/user-attachments/assets/f8d9b202-f77b-4ce9-b584-2ce83ba805c0)

# Contribuer

Les contributions sont les bienvenues ! Si vous souhaitez contribuer à ce projet, suivez ces étapes:

1.	Fork the repository Forkez le dépôt.
   
2.	Créez une nouvelle branche de fonctionnalité.
   
3.	Apportez vos modifications.
   
4.	Créez une pull request.
   
# Licence

Ce projet est sous licence MIT – consultez le fichier LICENSE pour plus de détails.


