-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : jeu. 05 juin 2025 à 21:25
-- Version du serveur : 8.3.0
-- Version de PHP : 8.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `monopoly_f1`
--
CREATE DATABASE IF NOT EXISTS `monopoly_f1` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `monopoly_f1`;

-- --------------------------------------------------------

--
-- Structure de la table `banque`
--

DROP TABLE IF EXISTS `banque`;
CREATE TABLE IF NOT EXISTS `banque` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idPartie` int NOT NULL,
  `argentGagne` int NOT NULL,
  `argentDepense` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idPartie` (`idPartie`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `caseevenement`
--

DROP TABLE IF EXISTS `caseevenement`;
CREATE TABLE IF NOT EXISTS `caseevenement` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nomCase` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `nbPassage` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `enchere`
--

DROP TABLE IF EXISTS `enchere`;
CREATE TABLE IF NOT EXISTS `enchere` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idPartie` int NOT NULL,
  `idJoueur1` int NOT NULL,
  `idJoueur2` int NOT NULL,
  `montantFinal` int NOT NULL,
  `gagnant` int NOT NULL,
  `idPropriete` int NOT NULL,
  PRIMARY KEY (`id`),
  KEY `idPartie` (`idPartie`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `historiquepartie`
--

DROP TABLE IF EXISTS `historiquepartie`;
CREATE TABLE IF NOT EXISTS `historiquepartie` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idJoueur1` int NOT NULL,
  `idJoueur2` int NOT NULL,
  `gagnant` int NOT NULL,
  `perdant` int NOT NULL,
  `datePartie` datetime NOT NULL,
  `nbHypothequeJ1` int NOT NULL,
  `nbHypothequeJ2` int NOT NULL,
  `nbProprieteJ1` int NOT NULL,
  `nbProprieteJ2` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `historiquepartie`
--

INSERT INTO `historiquepartie` (`id`, `idJoueur1`, `idJoueur2`, `gagnant`, `perdant`, `datePartie`, `nbHypothequeJ1`, `nbHypothequeJ2`, `nbProprieteJ1`, `nbProprieteJ2`) VALUES
(1, 3, 6, 3, 6, '2025-05-16 17:26:41', 5, 6, 5, 7),
(2, 4, 3, 3, 4, '2025-05-10 17:26:41', 5, 5, 7, 8),
(3, 3, 5, 5, 3, '2025-05-25 17:27:46', 0, 5, 1, 10);

-- --------------------------------------------------------

--
-- Structure de la table `player_connected`
--

DROP TABLE IF EXISTS `player_connected`;
CREATE TABLE IF NOT EXISTS `player_connected` (
  `idComboBox` int NOT NULL,
  `username` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `idJoueur` int NOT NULL,
  KEY `idJoueur1` (`idJoueur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `player_connected`
--

INSERT INTO `player_connected` (`idComboBox`, `username`, `idJoueur`) VALUES
(0, 'invite', 9999999),
(1, 'invite', 9999999);

-- --------------------------------------------------------

--
-- Structure de la table `propriete`
--

DROP TABLE IF EXISTS `propriete`;
CREATE TABLE IF NOT EXISTS `propriete` (
  `id` int NOT NULL AUTO_INCREMENT,
  `nomPropriete` varchar(90) COLLATE utf8mb4_general_ci NOT NULL,
  `valeurPropriete` int NOT NULL,
  `totalAchat` int NOT NULL,
  `revenueGenere` int NOT NULL,
  `nbPassage` int NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `password` varchar(50) COLLATE utf8mb4_general_ci NOT NULL,
  `date_inscription` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `users`
--

INSERT INTO `users` (`id`, `username`, `password`, `date_inscription`) VALUES
(0, 'root', 'root', '0000-00-00 00:00:00'),
(3, 'Thomye', 'blablabla', '2025-05-17 00:00:00'),
(4, 'draco', 'draco', '2025-05-20 00:00:00'),
(5, 'LeJ', 'lej', '2025-05-23 00:00:00'),
(6, 'nath', 'nath', '2025-05-23 00:00:00'),
(7, 'let', 'let', '2025-06-04 00:00:00');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
