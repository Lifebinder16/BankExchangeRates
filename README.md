# Bank exchange rates

Приложение подключается к открытому API Банка России и получает данные о курсах валют.

## Использование

Пример адреса для выполнения GET-запроса на получение данных:
```
https://localhost:44389/exchangerates?date=2025-05-14&currencyCode=USD
```

## Документирование (Swagger)

Приложение использует OpenAPI 3.0 для формирования документации на API.
Увидеть сформированную документацию (комментарии к методам, полям, свойствам) можно, открыв Swagger по адресу:
```
https://localhost:44389/swagger/index.html
```

Сам выходной файл с собранными комментариями находится в папке:
```
.\BankExchangeRates\bin\Debug\netcoreapp3.1\BankExchangeRates.xml
```

## CI/CD проекта

В рамках тестового задания так же был настроен пайплайн в Jenkins, который автоматически собирает проект и контейнеризует его в Docker.

![photo_2025-05-14_17-54-02](https://github.com/user-attachments/assets/a8cfbf9b-b744-485b-b45c-a087cc8f05d0)

![photo_2025-05-14_17-54-04](https://github.com/user-attachments/assets/e9f86f4f-ea00-4aa8-80df-0cba1f12d090)
