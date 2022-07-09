# imdb-service

Сервис для поиска фильмов, где играют два актера.

Сервис использует API IMDB, максимум в день 100 запросов.

Имена актеров нужно вводить на английском языке.

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
