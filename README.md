# BudgetApp

**BudgetApp** to nowoczesna aplikacja webowa typu **Blazor Server**, stworzona z myślą o kompleksowym zarządzaniu finansami rodzinnymi i osobistymi.

---

##Funkcje

## Uwierzytelnianie
- Rejestracja i logowanie przy użyciu ASP.NET Core Identity
- Obsługa użytkowników bez rodziny i należących do rodziny
- Automatyczne przekierowanie po zalogowaniu (setup konta lub dashboard)

## Zarządzanie rodziną
- Tworzenie i edycja rodziny
- Role: **Owner** (twórca) i **Member**
- Członkowie mogą opuścić rodzinę
- Tylko właściciel może:
  - Usunąć rodzinę
  - Usuwać innych członków

## Kontrola kont i transakcji
- Tworzenie kont z saldem startowym
- Obsługa wielu kont przypisanych do rodziny i użytkownika
- Rejestracja transakcji (wpływy/wydatki)
- Filtrowanie po dacie
- Eksport danych do CSV

## Kategorie
- Kategorie globalne (dla rodziny) i prywatne (dla użytkownika)
- Każda transakcja przypisana do kategorii

## Dashboard
- Zbiorcze saldo wszystkich kont rodziny
- Podsumowanie wpływów i wydatków w bieżącym miesiącu
- Wykres kołowy wydatków według kategorii
- Lista ostatnich transakcji z widocznością kto dodał (cała rodzina)
- Ranking wydatków członków

## Skarbonka
- Dodawanie celów oszczędnościowych
- Obsługa depozytów i wypłat

---

## Schemat bazy danych

| Tabela             | Kluczowe kolumny                                           | Relacje                                                   |
|--------------------|------------------------------------------------------------|------------------------------------------------------------|
| **AspNetUsers**    | Id, Email, PasswordHash, FamilyId                          | 1:N Transactions, 1:N Accounts, 1:N Categories             |
| **Families**       | Id, Name, CreatedByUserId                                  | 1:N Users                                                  |
| **Accounts**       | Id, Name, Balance, FamilyId, UserId                        | N:1 Families, N:1 Users, 1:N Transactions                  |
| **Categories**     | Id, Name, FamilyId (nullable), UserId (nullable)           | N:1 Families/User, 1:N Transactions                        |
| **Transactions**   | Id, Date, Amount, Note, CategoryId, AccountId, UserId      | N:1 Category, Account, User, Family                        |
| **RecurringExpense** | Id, Interval, Amount, CategoryId, UserId, FamilyId       | N:1 Category, User, Family                                 |
| **RecurringDeposit** | Id, Interval, Amount, CategoryId, UserId, FamilyId       | N:1 Category, User, Family                                 |

---

## Wymagania

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download)
- EF Core (domyślnie SQLite)
- Chart.js i Bootstrap (dostarczone w wwwroot)

---
## Widoki
![obraz](https://github.com/user-attachments/assets/6812acd5-52d6-4cde-ac75-a153fa4712fc)
![obraz](https://github.com/user-attachments/assets/645ddb6b-5fa8-4d73-a7c0-aa20249d663c)

## Dashboard rodziny
![obraz](https://github.com/user-attachments/assets/c406acf2-5c5f-4d67-9f03-1966e735eb3a)
## Account 
![obraz](https://github.com/user-attachments/assets/fd8bd06a-a137-4a1f-9243-fed5a119675a)

##
Dodawanie wpływu
![obraz](https://github.com/user-attachments/assets/4d2c4697-bebf-4f28-bb57-e1aa38ea4d72)

## Dodawanie wydatku
![obraz](https://github.com/user-attachments/assets/72ab33ea-9747-49ae-9b2f-ada990fb2507)
## Kategorie i dodawanie kategorii
![obraz](https://github.com/user-attachments/assets/67431005-011f-4114-a956-f71a0bb28dc4)
![obraz](https://github.com/user-attachments/assets/3c72db81-fc8e-4b6c-a648-6cd224872d5c)

## Moja rodzina(członkowie, zarządzanie rodziną i zaproszenie do rodziny)
![obraz](https://github.com/user-attachments/assets/cbc6e6e8-8b50-4a37-877f-b95d32f702f3)
![obraz](https://github.com/user-attachments/assets/a96845e1-1ed8-477b-96b4-41c2201497ec)
![obraz](https://github.com/user-attachments/assets/65be719c-636c-401f-9b93-354fb23695d1)

## Przelew rodzinny
![obraz](https://github.com/user-attachments/assets/9a0ae27d-64ed-4721-b28a-061dfda511f3)
## Skarboka i cele rodzinne 
![obraz](https://github.com/user-attachments/assets/6c0e1793-d137-495c-8704-e52bdc733c02)
![obraz](https://github.com/user-attachments/assets/5671f984-d5f0-4a00-a2c4-e4d62435bcdc)
![obraz](https://github.com/user-attachments/assets/c9ffd358-dff9-4f11-be07-4b5b845c6546)



## Uruchamianie

```bash
git clone https://github.com/Barwiszon/BudgetApp.git
cd BudgetApp
dotnet restore
dotnet ef database update
dotnet run
