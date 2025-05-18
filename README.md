# BudgetApp

**BudgetApp** to nowoczesna aplikacja webowa typu Blazor Server, stworzona z myślą o kompleksowym zarządzaniu finansami rodzinnymi. Użytkownicy mogą założyć „rodzinę” jako wspólną przestrzeń budżetową, zapraszać do niej członków, a następnie wspólnie:

    Zarządzać kontami — dodawać konta bankowe z początkowymi saldami, edytować je oraz usuwać.

    Definiować kategorie — tworzyć, zmieniać i usuwać kategorie wydatków/inwestycji (np. „Zakupy”, „Rachunki”, „Rozrywka”).

    Rejestrować transakcje — wprowadzać wpływy i wydatki, przypisywać je do kont i kategorii, dodawać notatki.

    Monitorować stan — na interaktywnym dashboardzie widoczne jest łączne saldo rodzinne, miesięczne podsumowanie wpływów i wydatków, najnowsze transakcje oraz wykresy (kołowy i słupkowy) generowane przy użyciu Chart.js.

    Współpracować — Owner rodziny może zapraszać nowe osoby poprzez e-mail (tokeny zaproszeniowe), nadawać role (Owner/Member) i zarządzać członkami.

---

## Funkcje

- **Uwierzytelnianie**  
  - Rejestracja i logowanie przez ASP .NET Identity  
  - Role w rodzinie: Owner i Member  
- **Zarządzanie rodziną**  
  - Tworzenie i edycja rodziny  
  - Zaproszenia e-mailem (tokeny)  
  - Lista członków, usuwanie, zmiana roli  
- **Kontrola kont i transakcji**  
  - CRUD dla kont bankowych (nazwa, saldo)  
  - CRUD dla kategorii wydatków  
  - CRUD dla transakcji (data, kwota, konto, kategoria, notatka)  
- **Dashboard**  
  - Łączne saldo wszystkich kont  
  - Podsumowanie wpływów i wydatków bieżącego miesiąca  
  - Ostatnie transakcje w rodzinie  
  - Wykres kołowy rozkładu wydatków wg kategorii  
  - Wykres słupkowy wpływów vs wydatków za ostatnie pół roku  

---

## Schemat bazy danych

| Tabela           | Kolumny                                                            | Relacje                                       |
|------------------|--------------------------------------------------------------------|-----------------------------------------------|
| **AspNetUsers**  | Id, Email, PasswordHash, FamilyId, …                                | 1:N Transactions, 1:N Accounts, 1:N Categories |
| **Families**     | Id, Name, CreatedByUserId                                          | 1:N Users, 1:N Invites                        |
| **FamilyInvites**| Id (token), FamilyId, Email, CreatedAt                             | N:1 Families                                   |
| **Accounts**     | Id, Name, Balance, FamilyId, UserId                                | N:1 Families, N:1 Users, 1:N Transactions     |
| **Categories**   | Id, Name, FamilyId, UserId                                         | N:1 Families, N:1 Users, 1:N Transactions     |
| **Transactions** | Id, Date, Amount, Note, FamilyId, AccountId, CategoryId, UserId    | N:1 Families, N:1 Accounts, N:1 Categories, N:1 Users |

---

## Wymagania

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)  
- SQLite (domyślnie) lub inny provider EF Core  
- Konto e-mail do wysyłki zaproszeń (opcjonalnie)

---



Widoki:
Dashborad(strona główna)
![obraz](https://github.com/user-attachments/assets/008f0931-38d6-4e7b-b15d-34d8bde2d1aa)
Moje Kategorie
![obraz](https://github.com/user-attachments/assets/8bdd82d6-1390-466d-86b8-a94716f60b95)
![obraz](https://github.com/user-attachments/assets/3a0b6048-1191-4316-aa7d-350d57221863)

Transakcje
![obraz](https://github.com/user-attachments/assets/0103410c-78db-4b7b-abbe-ff0b980bc301)
![obraz](https://github.com/user-attachments/assets/d248e282-64cd-44f9-8ce2-3ae6df314c6b)
Moja rodzina
![obraz](https://github.com/user-attachments/assets/127b7b51-9478-4142-8b66-072198c873ae)
![obraz](https://github.com/user-attachments/assets/155fee4b-042e-47a2-bcd8-a9f892c57376)
![obraz](https://github.com/user-attachments/assets/3d0e1844-7063-4d98-a784-9ce60b631618)


![obraz](https://github.com/user-attachments/assets/910b2f79-c5ce-4f8c-b642-1f7a7205a784)
