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

## à améliorer pour être production ready:
Pour le backend :
- Ajout de plus de tests unitaires surtout au niveau du service et du controlleur.
- Je n'ai pas testé directement les factories ni la strategie, car elles sont testées indirectement via le service.
- pas de tests d'integration ni de end2end.
- pas de strategie pour le calcul des frais de transport dans CollectionnerTousLesFrais() de CalculateurDeFraisService.cs , car ils sont toujours les memes. Mais la logique pourrait être extraite dans le factory/strategy.
- ajout d'exceptions personnalisées pour les erreurs de validation et d'entrées invalides
- les controlleurs sont simples, ils pourraient etre plus robustes avec une meilleur gestion des erreurs http.
- pas de logging
- NOTE : ans un context de production, on calcule les frais d'un vehicule, pourtant le vehicule est lui même un objet complexe dans le domaine. Les données d'un véhicule devraient être stockées en DB, on aurait également des dépendances entre les entités (par exemple, un véhicule doit avoir un type, marque, modèle, liste de frais, etc.). Dans ce contexte, comme l'exercice est simplement de retourner les frais d'un véhicule selon son prix, le véhicule n'existe pas en tant qu'entité car on calcule les frais selon un montant dynamiquement passé en paramètre. Dans un contexte de production et dans la logique du métier, pour calculer les frais d'un véhicule en enchère, celui-ci devrait exister. 
Pour le frontend :
- frontend simple, mais fait ce qu'il doit faire
- idéalement pour un code de production, on devrait avoir des components réutilisables comme pour le tableau des frais par exemple, en plus d'une couche service pour les appels http vers le backend et les tests unitaires des services. Dans le but de rendre le code lisible, maintenable et scalable.
