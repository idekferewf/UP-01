-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Окт 14 2025 г., 08:14
-- Версия сервера: 5.7.25
-- Версия PHP: 7.1.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `aptekaeu`
--

-- --------------------------------------------------------

--
-- Структура таблицы `categories`
--

CREATE TABLE `categories` (
  `id` int(11) NOT NULL COMMENT 'ID категории',
  `name` varchar(50) NOT NULL COMMENT 'Наименование'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Категории товаров';

--
-- Дамп данных таблицы `categories`
--

INSERT INTO `categories` (`id`, `name`) VALUES
(1, 'Рецептурные препараты'),
(2, 'Безрецептурные препараты'),
(3, 'Витамины и БАДы'),
(4, 'Медицинские изделия'),
(5, 'Гигиена и уход');

-- --------------------------------------------------------

--
-- Структура таблицы `inventory`
--

CREATE TABLE `inventory` (
  `inventory_date` date NOT NULL COMMENT 'Дата инвентаризации',
  `product_id` int(11) NOT NULL COMMENT 'ID товара',
  `actual_quantity` int(11) NOT NULL COMMENT 'Фактическое кол-во',
  `system_quantity` int(11) NOT NULL COMMENT 'Общее кол-во',
  `difference` int(11) NOT NULL COMMENT 'Разница количество'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Инвентаризация';

-- --------------------------------------------------------

--
-- Структура таблицы `products`
--

CREATE TABLE `products` (
  `id` int(11) NOT NULL COMMENT 'ID товара',
  `name` varchar(200) NOT NULL COMMENT 'Наименование',
  `category_id` int(11) NOT NULL COMMENT 'ID категории',
  `purchase_price` decimal(10,2) NOT NULL COMMENT 'Цена закупки',
  `sale_price` decimal(10,2) NOT NULL COMMENT 'Цена продажи',
  `actual_quantity` int(11) NOT NULL COMMENT 'Актуальное количество'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Товары';

--
-- Дамп данных таблицы `products`
--

INSERT INTO `products` (`id`, `name`, `category_id`, `purchase_price`, `sale_price`, `actual_quantity`) VALUES
(1, 'Парацетамол 500мг таб. №20', 2, '45.00', '80.50', 150),
(2, 'Нурофен 200мг таб. №10', 2, '95.00', '165.00', 89),
(3, 'Амоксиклав 625мг таб. №14', 1, '320.00', '550.00', 45),
(4, 'Компливит таб. №60', 3, '180.00', '299.00', 67),
(5, 'Бинт стерильный 7м х 14см', 4, '25.50', '48.90', 234),
(6, 'Мыло жидкое антибактериальное', 5, '65.00', '120.00', 56),
(7, 'Називин капли 0.05% 10мл', 2, '89.00', '149.00', 112),
(8, 'Эналаприл 5мг таб. №20', 1, '55.00', '99.00', 203),
(9, 'Супрадин кидс мишки №30', 3, '340.00', '520.00', 34),
(10, 'Глюкометр Акку-Чек', 4, '1250.00', '2199.00', 12),
(11, 'Ватные палочки 100шт', 5, '32.00', '65.00', 178),
(12, 'Кагоцел таб. №10', 2, '210.00', '359.00', 76),
(13, 'Лозап 50мг таб. №30', 1, '280.00', '480.00', 58),
(14, 'Магне B6 форте таб. №30', 3, '420.00', '689.00', 41),
(15, 'Термометр электронный', 4, '190.00', '350.00', 23),
(16, 'Зубная паста Лесной бальзам', 5, '78.00', '145.00', 91),
(17, 'Смекта пак. №10', 2, '115.00', '199.00', 124),
(18, 'Фенибут 250мг таб. №20', 1, '410.00', '650.00', 32),
(19, 'Аевит капс. №20', 3, '65.00', '110.00', 156),
(20, 'Тонометр механический', 4, '890.00', '1590.00', 8),
(21, 'Влажные салфетки антисепт. 15шт', 5, '42.00', '85.00', 267),
(22, 'Гексорал аэрозоль 40мл', 2, '235.00', '399.00', 63);

-- --------------------------------------------------------

--
-- Структура таблицы `sales`
--

CREATE TABLE `sales` (
  `id` int(11) NOT NULL COMMENT 'ID продажи',
  `product_id` int(11) NOT NULL COMMENT 'ID товара',
  `sale_date` datetime NOT NULL COMMENT 'Дата и время продажи',
  `quantity` int(11) NOT NULL COMMENT 'Кол-во проданного товара',
  `total_amount` decimal(10,2) NOT NULL COMMENT 'Сумма продажи'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Продажи';

-- --------------------------------------------------------

--
-- Структура таблицы `suppliers`
--

CREATE TABLE `suppliers` (
  `tin` int(11) NOT NULL COMMENT 'ИНН поставщика',
  `name` varchar(100) NOT NULL COMMENT 'Наименование',
  `contact_person` varchar(100) NOT NULL COMMENT 'ФИО контактного лица',
  `phone` varchar(20) NOT NULL COMMENT 'Контактный телефон',
  `address` varchar(200) NOT NULL COMMENT 'Юридический адрес'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Поставщики';

--
-- Дамп данных таблицы `suppliers`
--

INSERT INTO `suppliers` (`tin`, `name`, `contact_person`, `phone`, `address`) VALUES
(1001, 'ООО \"Ромашка\"', 'Иванов Петр Сергеевич', '+7-495-123-45-67', 'г. Москва, ул. Ленина, д. 15, офис 25'),
(1002, 'ЗАО \"Технопром\"', 'Сидорова Анна Владимировна', '+7-812-234-56-78', 'г. Санкт-Петербург, Невский пр-т, д. 45'),
(1003, 'ИП Козлов Д.А.', 'Козлов Дмитрий Александрович', '+7-383-345-67-89', 'г. Новосибирск, ул. Кирова, д. 12, кв. 34'),
(1004, 'ООО \"СтройГарант\"', 'Петрова Мария Игоревна', '+7-843-456-78-90', 'г. Казань, пр-т Победы, д. 78'),
(1005, 'АО \"Электросила\"', 'Васильев Андрей Николаевич', '+7-351-567-89-01', 'г. Челябинск, ул. Свободы, д. 23'),
(1006, 'ИП Смирнова Е.В.', 'Смирнова Елена Викторовна', '+7-3812-678-90-12', 'г. Омск, ул. Мира, д. 56'),
(1007, 'ООО \"ТоргСервис\"', 'Николаев Сергей Петрович', '+7-863-789-01-23', 'г. Ростов-на-Дону, ул. Садовая, д. 89'),
(1008, 'ЗАО \"МеталлПрофи\"', 'Кузнецов Алексей Дмитриевич', '+7-4852-890-12-34', 'г. Ярославль, ул. Чкалова, д. 34'),
(1009, 'ООО \"АгроПром\"', 'Федорова Ольга Сергеевна', '+7-4722-901-23-45', 'г. Белгород, ул. Гагарина, д. 67'),
(1010, 'ИП Волков П.С.', 'Волков Павел Станиславович', '+7-391-012-34-56', 'г. Красноярск, ул. Карла Маркса, д. 90'),
(1011, 'ООО \"ТрансЛогистик\"', 'Алексеева Ирина Васильевна', '+7-343-123-45-67', 'г. Екатеринбург, ул. Малышева, д. 123'),
(1012, 'АО \"НефтеХим\"', 'Борисов Виктор Иванович', '+7-846-234-56-78', 'г. Самара, ул. Московская, д. 45'),
(1013, 'ООО \"МедТехника\"', 'Григорьева Татьяна Алексеевна', '+7-861-345-67-89', 'г. Краснодар, ул. Красная, д. 78'),
(1014, 'ИП Морозов А.К.', 'Морозов Артем Константинович', '+7-383-456-78-90', 'г. Новосибирск, ул. Дуси Ковальчук, д. 156'),
(1015, 'ООО \"СтройИнвест\"', 'Тихонова Надежда Павловна', '+7-815-567-89-01', 'г. Мурманск, ул. Ленинградская, д. 23');

-- --------------------------------------------------------

--
-- Структура таблицы `supplies`
--

CREATE TABLE `supplies` (
  `id` int(11) NOT NULL COMMENT 'ID поставки',
  `product_id` int(11) NOT NULL COMMENT 'ID товара',
  `supplier_tin` int(11) NOT NULL COMMENT 'ИНН поставщика',
  `quantity` int(11) NOT NULL COMMENT 'Количество приходного товара',
  `production_date` date NOT NULL COMMENT 'Дата производства',
  `expiry_date` date NOT NULL COMMENT 'Срок годности'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='Поставки';

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `inventory`
--
ALTER TABLE `inventory`
  ADD PRIMARY KEY (`inventory_date`),
  ADD KEY `product_id` (`product_id`);

--
-- Индексы таблицы `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`,`category_id`),
  ADD KEY `category_id` (`category_id`);

--
-- Индексы таблицы `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`id`,`sale_date`),
  ADD KEY `product_id` (`product_id`);

--
-- Индексы таблицы `suppliers`
--
ALTER TABLE `suppliers`
  ADD PRIMARY KEY (`tin`);

--
-- Индексы таблицы `supplies`
--
ALTER TABLE `supplies`
  ADD PRIMARY KEY (`id`),
  ADD KEY `product_id` (`product_id`),
  ADD KEY `supplier_tin` (`supplier_tin`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `categories`
--
ALTER TABLE `categories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID категории', AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `products`
--
ALTER TABLE `products`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID товара', AUTO_INCREMENT=25;

--
-- AUTO_INCREMENT для таблицы `sales`
--
ALTER TABLE `sales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID продажи';

--
-- AUTO_INCREMENT для таблицы `supplies`
--
ALTER TABLE `supplies`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT COMMENT 'ID поставки';

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `inventory_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);

--
-- Ограничения внешнего ключа таблицы `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `categories` (`id`);

--
-- Ограничения внешнего ключа таблицы `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `sales_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`);

--
-- Ограничения внешнего ключа таблицы `supplies`
--
ALTER TABLE `supplies`
  ADD CONSTRAINT `supplies_ibfk_1` FOREIGN KEY (`product_id`) REFERENCES `products` (`id`),
  ADD CONSTRAINT `supplies_ibfk_2` FOREIGN KEY (`supplier_tin`) REFERENCES `suppliers` (`tin`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
