Отчет по ДЗ №2

НЕСТЕРКИН ДАНИЛА 238

Реализованный функционал

Животные

Добавление через POST /api/animals

Удаление через DELETE /api/animals/{id}

Вольеры

Добавление через POST /api/enclosures

Удаление через DELETE /api/enclosures/{id}

Перемещение животного через POST /api/animals/{id}/transfer

Расписание кормления

Просмотр через GET /api/feedingSchedules

Добавление через POST /api/feedingSchedules

Отметка о выполнении через POST /api/feedingSchedules/{id}/execute

Статистика через GET /api/stats (общее число животных, свободные вольеры)

Хранилище: репозитории на основе памяти в папке Infrastructure/InMemory

Swagger: документация доступна по /swagger (настройки в Startup.cs)

Использованные принципы

Доменные сущности Animal, Enclosure и FeedingSchedule содержат методы с бизнес‑логикой

Value Object: Species, FoodType, Sex, EnclosureType

Domain Events: AnimalMovedEvent и FeedingTimeEvent, публикуемые через InMemoryMessageBus

Clean Architecture: слои Domain, Application, Presentation и Infrastructure, зависимости подключены через интерфейсы и DI (Startup.cs)

