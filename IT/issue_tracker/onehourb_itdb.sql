-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Време на генериране:  8 февруари 2011 в 13:04
-- Версия на сървъра: 5.0.91
-- Версия на PHP: 5.2.9

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- БД: `onehourb_itdb`
--

-- --------------------------------------------------------

--
-- Структура на таблица `it_issue`
--

CREATE TABLE IF NOT EXISTS `it_issue` (
  `issue_id` int(20) NOT NULL auto_increment,
  `type_id` int(20) NOT NULL,
  `status_id` int(20) NOT NULL,
  `issue_description` varchar(500) NOT NULL,
  `issue_user_created` varchar(255) NOT NULL,
  `issue_user_closed` varchar(255) default NULL,
  `issue_time_created` datetime NOT NULL,
  `issue_time_closed` datetime default NULL,
  `issue_reopned` int(20) NOT NULL,
  PRIMARY KEY  (`issue_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Дъмп (схема) на данните в таблицата `it_issue`
--

INSERT INTO `it_issue` (`issue_id`, `type_id`, `status_id`, `issue_description`, `issue_user_created`, `issue_user_closed`, `issue_time_created`, `issue_time_closed`, `issue_reopned`) VALUES
(1, 1, 1, 'Bug in system drivers', '1', '2', '2011-01-01 15:39:50', '2011-01-11 15:39:56', 0),
(2, 2, 1, 'Бъг в системните драйвери male', '1', NULL, '2011-01-21 02:37:56', NULL, 0);

-- --------------------------------------------------------

--
-- Структура на таблица `it_people`
--

CREATE TABLE IF NOT EXISTS `it_people` (
  `person_id` int(20) NOT NULL auto_increment,
  `username` varchar(255) character set utf8 NOT NULL,
  `password` varchar(255) character set utf8 NOT NULL,
  `person_firstname` varchar(255) character set utf8 NOT NULL,
  `person_lastname` varchar(255) character set utf8 NOT NULL,
  `person_email` varchar(255) character set utf8 NOT NULL,
  `person_role_id` int(20) NOT NULL,
  PRIMARY KEY  (`person_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=cp1251 AUTO_INCREMENT=3 ;

--
-- Дъмп (схема) на данните в таблицата `it_people`
--

INSERT INTO `it_people` (`person_id`, `username`, `password`, `person_firstname`, `person_lastname`, `person_email`, `person_role_id`) VALUES
(1, 'nasko', 'nasko', 'Атанас', 'Манолов', 'nasko159@gmail.com', 1),
(2, 'gosho', 'gosho', 'Георги', 'Димитров', 'nasko_m_bg@yahoo.com', 2);

-- --------------------------------------------------------

--
-- Структура на таблица `it_person_role`
--

CREATE TABLE IF NOT EXISTS `it_person_role` (
  `person_role_id` int(20) NOT NULL auto_increment,
  `description` varchar(255) NOT NULL,
  PRIMARY KEY  (`person_role_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=cp1251 AUTO_INCREMENT=3 ;

--
-- Дъмп (схема) на данните в таблицата `it_person_role`
--

INSERT INTO `it_person_role` (`person_role_id`, `description`) VALUES
(1, 'OOP engineer'),
(2, 'software engineer');

-- --------------------------------------------------------

--
-- Структура на таблица `it_shedule`
--

CREATE TABLE IF NOT EXISTS `it_shedule` (
  `issue_id` int(20) NOT NULL,
  `person_id` int(20) NOT NULL,
  PRIMARY KEY  (`issue_id`,`person_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Дъмп (схема) на данните в таблицата `it_shedule`
--

INSERT INTO `it_shedule` (`issue_id`, `person_id`) VALUES
(1, 1),
(1, 2);

-- --------------------------------------------------------

--
-- Структура на таблица `it_status`
--

CREATE TABLE IF NOT EXISTS `it_status` (
  `status_id` int(20) NOT NULL auto_increment,
  `description` varchar(255) NOT NULL,
  PRIMARY KEY  (`status_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Дъмп (схема) на данните в таблицата `it_status`
--

INSERT INTO `it_status` (`status_id`, `description`) VALUES
(1, 'open '),
(2, 'working '),
(3, 'closed');

-- --------------------------------------------------------

--
-- Структура на таблица `it_type`
--

CREATE TABLE IF NOT EXISTS `it_type` (
  `type_id` int(20) NOT NULL auto_increment,
  `description` varchar(255) NOT NULL,
  PRIMARY KEY  (`type_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Дъмп (схема) на данните в таблицата `it_type`
--

INSERT INTO `it_type` (`type_id`, `description`) VALUES
(1, 'Bug'),
(2, 'Request for new functionality');
