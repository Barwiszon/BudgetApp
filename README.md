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








## Uruchamianie

```bash
git clone https://github.com/Barwiszon/BudgetApp.git
cd BudgetApp
dotnet restore
dotnet ef database update
dotnet run
