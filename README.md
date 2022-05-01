<br />
<p align="center">
<img src="logo.PNG" alt="Logo" width="Auto" height="Auto">

  <h3 align="center">Клиент CRUD приложения для БД</h3>

  <p align="center">
    Это проект, помогающий пользователю выполнять классические CRUD действия с бд.
    <br />
    <a href="https://t.me/bisnachauszuvorbei">Телеграм автора</a>
  </p>
</p>

<details open="open">
  <summary>Оглавление</summary>
  <ol>
    <li>
      <a href="#О проекте">О проекте</a>
      <ul>
        <li><a href="#Технологии">Технологии</a></li>
      </ul>
    </li>
    <li><a href="#Демонстрация работы">Демонстрация работы</a></li>
    <li><a href="#Контакты">Контакты</a></li>
  </ol>
</details>

### О проекте

___
Концепция проекта заключается в создании клиета CRUD приложения для Windows, позволяюещего работать с некоторой базой данных на СУБД PostgreSQL. В данном случае создавалась некая база данных реестра пользоватетелей reestr_users
каждый из которых имел следующие  свойства:
* [ID]() - уникальный идентификатор пользователя
* [Name]() - имя пользователя
* [Vorname]() - фамилия пользователя	
* [Lastname]() - отчетво пользователя
* [INN]() - ИНН
* [OrgInn]() - ИНН организации, где пользователь работает
* [OrgName]() - название организации, где пользователь работает
* [OrgAdress]() - адрес организации, где пользователь работает

Предполагается что ползователь приложения ReestrApp. может управлять записями БД реестра, тоесть производить поиск по базе данных, добавлять новых пользователей, удалять и редактировать старых пользователей.
___

### Технологии

Здесь перечисленны технологии, которые использованы для создания
клиентского приложения:

* [C#]() - Поскольку я неплохо знаю C#, стал писать на нём 
* [WPF]() - Платформа Windows Presentation Foundation (WPF), позволяющая создавать клиентские приложения для настольных систем Windows с привлекательным пользовательским интерфейсом.
* [.NET 5.0]() - .NET — это бесплатная платформа разработки с открытым исходным кодом для создания различных типов приложений.
* [Dapper]() - мини-ORM, в данном случае для выполнения запросов к бд и создании сущностей модели User на основе получаемого ответа.
* [Postgre SQL]() - СУБД



### Демонстрация пользовательского интерфейса

<p align="center">
<img src="UI.PNG" alt="Logo" width="Auto" height="Auto">


### Контакты

* [Email]() - [a.sadilov.official@gmail.com](mailto:a.sadilov.official@gmail.com)
* [Telegram]() - [@bisnachauszuvorbei](https://t.me/bisnachauszuvorbei)
