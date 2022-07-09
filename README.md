# imdb-service

Сервис для поиска фильмов, где играют два актера.

Сервис использует API IMDB, максимум в день 100 запросов.

Имена актеров нужно вводить на английском языке.

Сервис использует postgresql, actorsdb, которая содержит всего одну таблицу actors
```
create table actors
(
  name     varchar(100) not null,
  actor_id varchar(100) not null
);
```

Пример запроса:

```
{
    "firstActor":"Keanu Reeves",             // Обязательный парамерт
    "secondActor": "Winona Ryder",            // Обязательный парамерт
    "moviesOnly": true,                  // Необязательный параметр
}
```


Пример ответа json

```
[
    "Destination Wedding",
    "The Private Lives of Pippa Lee",
    "A Scanner Darkly",
    "Bram Stoker's Dracula"
]
```
