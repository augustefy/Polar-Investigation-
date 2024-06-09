# Diagrame de cas d'Architecture
![][def]

[def]: archiprime.drawio.png

## Description de l'Architecture de la Jue Vidéo
## 1 - Couche de Présentation (Frontend)
### - Technologies Utilisées: MAUI (Multi-platform App UI), XAML, C#
### - Fonctionnalités:
- Utilisation MAUI permet de déployer la jue sur plusieurs plateformes (iOS, Android, Windows, macOS) avec même code. Et donc il rend la jue Multi-platform.
- Utilisation de XAML pour crée les interfaces utilisateur.
- Utilisation de C# pour la logique associée aux interactions utilisateur, la gestion des événements, la navigation entre les pages et la dynamisme de interface.
## 2 - Couche Logique Métier (Backend)
### - Technologies Utilisées: C#
### - Fonctionnalité:
- Contient les règles et la logique spécifique de jue.
-  Interagit avec la base de données pour effectuer les opérations demmandes.

## 3 - Couche Base de Données
### - Technologies Utilisées: PostgreSQL
### - Fonctionnalité:
- Stocke toutes les données nécessaires pour jue, comme les informations des utilisateurs.