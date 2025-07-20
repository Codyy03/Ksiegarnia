# Księgarnia – aplikacja desktopowa WPF

System desktopowy do zarządzania książkami, zamówieniami oraz klientami w księgarni. Stworzony w WPF (C#) + Entity Framework Core z bazą danych PostgreSQL.

## Funkcje

- Przeglądanie i filtrowanie książek  
- Tworzenie zamówień i przypisywanie książek  
- Zarządzanie użytkownikami (admin/klient)  
- Edycja danych książek  
- Koszyk zakupowy z zapisem/odczytem do JSON  
- Obsługa panelu użytkownika i historii zamówień  
- Dynamiczne ładowanie okładek książek z chmury  
- Podział ról na podstawie `appsettings.json` (np. postgres, jan, admin_user)

## Struktura katalogów

Ksiegarnia/
<br> │
<br> ├── Entities/                  # Klasy encji EF (Book, Order, Customer)
<br> ├── Windows/                   # Wszystkie okna aplikacji WPF
<br> ├── Images/                    # Obrazy ładowane dynamicznie
<br> ├── Migrations/                # Migracje EF
<br> ├── database_backup/           # Backupy bazy danych
<br> │
<br> ├── App.xaml                   # Globalne style i konfiguracja
<br> ├── BookstoreContext.cs        # Kontekst DbContext EF
<br> ├── ConnectionStringManager.cs # Zarządzanie połączeniem do DB
<br> ├── DynamicImageSourceExtension.cs # Dynamiczne ładowanie obrazów
<br> ├── GroupedBookViewModel.cs    # Model widoku grupowania książek
<br> ├── ShoppingCart.cs            # Obsługa koszyka
<br> ├── appsettings.json           # Konfiguracja bazy
<br>└── Styles.xaml                # Style globalne WPF


## Technologie

- C# + WPF (.NET Core)  
- Entity Framework Core  
- PostgreSQL  
- JSON (koszyk)  
- Dynamiczne ładowanie obrazów z imgbb.com  

## Zarządzanie obrazami

Okładki książek są hostowane na [imgbb.com](https://imgbb.com), co pozwala na:

- zmniejszenie rozmiaru aplikacji  
- dynamiczną podmianę okładek bez rekompilacji  
- łatwe rozszerzanie katalogu książek  

Przykład linku do okładki:  
`https://i.ibb.co/5XTKXKPz/pan-tadeusz.jpg`

## Baza danych

- PostgreSQL jako główna baza danych  
- EF Core obsługuje migracje oraz CRUD  
- Connection string w `appsettings.json`  
- Mapowanie encji EF Core z dekoratorami `[Table]`, `[Column]`

## Uruchomienie
1. Skonfiguruj bazę PostgreSQL i uzupełnij `appsettings.json` z connection string.  
2. Wykonaj migracje:  
   ```bash
   dotnet ef database update
   ```
3. Uruchom projekt:  
   ```bash
   dotnet run
   ```

## Główne okna
- MainWindow – główny widok z wyszukiwarką i książkami
- BookDetailsWindow – szczegóły książki, dodawanie do koszyka
- ShoppingCartWindow – zarządzanie koszykiem i podsumowanie
- DeliveryAndPayment – finalizacja zakupu
- UserPanel – edycja danych użytkownika
- OrdersWindow – historia zamówień
- BookEditWindow – edycja danych książki

## Licencja
- Projekt stworzony do nauki oraz rozwijania umiejętności WPF + EF Core.
