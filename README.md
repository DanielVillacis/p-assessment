# Outil de calcul d’enchères

## Architecture de l'application backend
L'application est construite en utilisant .NET 8.0 et suit une architecture en couches :
- Controlleurs : Couche API
- Services : Couche qui englobe la logique de la business
- Domaine : Couche qui englobe les entités, les modèles de données et les strategies de validation

### Patrons de conception utilisés pour la gestion des enchères
Utilisation du patron Factory (FraisCalculationFactory.cs) pour la gestion des enchères. On crée une stratégie approprié selon le type du vehicule et on l'utilise pour calculer les frais.

Le patron Strategy contient les differentes stratégies pour chaque type de calcul des frais (Base Ordinaire ou deluxe, spéciaux, Association).

Injection de dépendance du service dans le controlleur.

## à améliorer :
- Ajout de plus de tests unitaires surtout au niveau du service et du controlleur.
- Je n'ai pas testé directement les factories ni la strategie, car elles sont testées indirectement via le service.
- frontend simple, mais fait ce qu'il doit faire
- pas de tests d'integration ni de end2end.
- pas de strategie pour le calcul des frais de transport dans CollectionnerTousLesFrais() de CalculateurDeFraisService.cs , car ils sont toujours les memes. Mais la logique pourrait être extraite dans le factory/strategy.
- ajout d'exceptions personnalisées pour les erreurs de validation et d'entrées invalides
- les controlleurs sont simples, ils pourraient etre plus robustes avec une meilleur gestion des erreurs http.
- pas de logging