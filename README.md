# Тестовое задание на C#

## Описание

Это тестовое задание направлено на создание консольного приложения на языке программирования C#, способного выполнять различные операции с базой данных в зависимости от выбранного режима работы.

## Режимы работы приложения

1. **Создание таблицы справочника сотрудников**: Создает таблицу в базе данных с полями "Фамилия Имя Отчество", "дата рождения", "пол".

    *Пример запуска:* `ptmk.exe 1`

2. **Создание записи справочника сотрудников**: Создает запись в таблице сотрудников на основе введенных пользователем данных.

    *Пример запуска:* `ptmk.exe 2 "Ivanov Petr Sergeevich" 2009-07-12 Male`

3. **Вывод всех строк справочника сотрудников**: Выводит все записи справочника сотрудников, с уникальным значением ФИО+дата, отсортированные по ФИО, с указанием пола и возраста.

    *Пример запуска:* `ptmk.exe 3`

4. **Заполнение автоматически 1000000 строк справочника сотрудников**: Автоматически создает и добавляет в базу данных 1000000 записей сотрудников с равномерным распределением пола. Также добавляет 100 записей сотрудников с мужским полом и фамилией, начинающейся с "F".

    *Пример запуска:* `ptmk.exe 4`

5. **Выборка из таблицы по критерию**: Выполняет выборку из таблицы по критерию: пол мужской, Фамилия начинается с "F", замеряя время выполнения.

    *Пример запуска:* `ptmk.exe 5`

6. **Оптимизация запросов к базе**: Производена оптимизация запросов для ускорения выполнения предыдущего пункта. Результаты предствалены в файле `Отчет оптимизации запроса.docx.`
