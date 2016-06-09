-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: 127.0.0.1
-- Время создания: Июн 09 2016 г., 01:55
-- Версия сервера: 5.5.25
-- Версия PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;


-- База данных: `library_base`



 CREATE DATABASE IF NOT EXISTS  library_base;
 
--
-- Структура таблицы `autors`
--

CREATE TABLE IF NOT EXISTS library_base.autors (
  `Autor` text NOT NULL,
  `BookId` mediumint(9) NOT NULL,
  KEY `BookId` (`BookId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Таблица Авторов';

--
-- Дамп данных таблицы `autors`
--

INSERT INTO library_base.autors (`Autor`, `BookId`) VALUES
('Sir Arthur Conan Doyle', 1),
('Mark Twain', 4),
('Richard Curtis', 5),
('Oscar Wilde', 6),
('Agatha Christie', 7),
('John Escott', 8),
('Sir Arthur Conan Doyle', 9),
('Nosov', 11),
('Grigoriev, Aphanaseva', 12),
('Book Autor1, Book Autor2', 13);

-- --------------------------------------------------------

--
-- Структура таблицы `book`
--

CREATE TABLE IF NOT EXISTS library_base.book (
  `id` mediumint(9) NOT NULL AUTO_INCREMENT,
  `Book` text NOT NULL,
  `IsAvailable` varchar(11) NOT NULL DEFAULT 'True',
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_4` (`id`),
  KEY `id` (`id`),
  KEY `id_2` (`id`),
  KEY `id_3` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=14 ;

--
-- Дамп данных таблицы `book`
--

INSERT INTO library_base.book (`id`, `Book`, `IsAvailable`) VALUES
(1, 'The Hound of the Baskervilles', 'true'),
(4, 'The Million Pound Bank Note', 'true'),
(5, 'Mr. Bean In Town', 'false'),
(6, 'The Picture of Dorian Gray', 'false'),
(7, 'Appointment With Death', 'True'),
(8, 'Forrest Gump', 'True'),
(9, 'Sherlock Homes', 'True'),
(11, 'Neznaika', 'TRUE'),
(12, 'English', 'TRUE'),
(13, 'Book', 'True');

-- --------------------------------------------------------

--
-- Структура таблицы `took_books`
--

CREATE TABLE IF NOT EXISTS library_base.took_books (
  `Action` text NOT NULL,
  `Login` text NOT NULL,
  `BookID` text NOT NULL,
  `Date` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `took_books`
--

INSERT INTO library_base.took_books (`Action`, `Login`, `BookID`, `Date`) VALUES
('Taken', 'soomker@gmail.com', '3', '08.06.2016 17:05:40'),
('Taken', 'soomker@yandex.ru', '6', '08.06.2016 23:47:44'),
('Taken', 'soomker@gmail.com', '5', '09.06.2016 0:16:56');

-- --------------------------------------------------------

--
-- Структура таблицы `users`
--

CREATE TABLE IF NOT EXISTS library_base.users (
  `id` mediumint(9) NOT NULL AUTO_INCREMENT,
  `Email` text NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Дамп данных таблицы `users`
--

INSERT INTO library_base.users (`id`, `Email`) VALUES
(4, 'soomker@gmail.com'),
(5, 'soomker@yandex.ru');

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `autors`
--
ALTER TABLE library_base.autors
  ADD CONSTRAINT `autors_ibfk_1` FOREIGN KEY (`BookId`) REFERENCES `book` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
