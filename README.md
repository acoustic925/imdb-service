# imdb-service

Сервис для поиска фильмов, где играют два актера

Пример:

{
    "firstActor":"Keanu Reeves",             // Обязательный парамерт
    "secondActor": "Winona Ryder",            // Обязательный парамерт
    "moviesOnly": true,                  // Необязательный параметр
}

Пример ответа json
[
    "Destination Wedding",
    "The Private Lives of Pippa Lee",
    "A Scanner Darkly",
    "Bram Stoker's Dracula"
]
