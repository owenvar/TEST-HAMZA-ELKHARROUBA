#Cahier de charges :
Le but de l'exercice est de faire une REST API pour de la gestion d'evenement.
Il doit etre possible d'ajouter, modifier, supprimer et visualiser des evenements (sous forme de liste et de manière individuel).
Je dois etre capable de lister mes evenements pour un tableau les récapitulant tous, ainsi que pour des listes de sélection.
Je peux gérer des commentaires pour un evenements (création, modification, suppression, visualisation).
La liste des événements doit permettre la pagination.
Les migrations de database doivent etre faite avec Entity Framework Core.
Les retours doivent etre de type JSON.

Un évènement est constitué d'un titre, d'une description et d'une personne impliquée dans l'évènement.

#Fournis :
	Projet de base sans controlleur avec Context (complet + migration auto) et docker de setup avec un postgresql